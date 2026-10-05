import { EnvironmentInfoService, type EnvironmentInfoModel } from './api/index.js';

export type EnvironmentInfo = EnvironmentInfoModel;

const FALLBACK_COLOR = '#607d8b';
const SAFE_COLOR =
  /^(#[0-9a-f]{3,4}|#[0-9a-f]{6}|#[0-9a-f]{8}|(rgb|rgba|hsl|hsla)\(\s*[\d.%\s,\/]+\)|[a-z]{3,20})$/i;

/** Returns the color only if it is a plain hex/rgb()/hsl()/named color; otherwise a neutral fallback. */
export function safeColor(color: string | null | undefined): string {
  const value = color?.trim();
  return value && SAFE_COLOR.test(value) ? value : FALLBACK_COLOR;
}

let pending: Promise<EnvironmentInfo | undefined> | undefined;

/** Loads the environment info once; only a successful result stays cached (failures are retried). */
export function loadEnvironmentInfo(): Promise<EnvironmentInfo | undefined> {
  if (!pending) {
    const current: Promise<EnvironmentInfo | undefined> = EnvironmentInfoService.getEnvironmentInfo()
      .then((response) => response.data as EnvironmentInfo | undefined)
      .catch(() => undefined)
      .then((data) => {
        if (!data && pending === current) pending = undefined;
        return data;
      });
    pending = current;
  }
  return pending;
}
