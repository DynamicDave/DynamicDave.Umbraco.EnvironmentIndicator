import { css, html, customElement, state, nothing } from '@umbraco-cms/backoffice/external/lit';
import { UmbLitElement } from '@umbraco-cms/backoffice/lit-element';
import { loadEnvironmentInfo, safeColor, type EnvironmentInfo } from './environment-info.js';

const BAR_HEIGHT = '20px';

@customElement('dd-environment-banner')
export class DdEnvironmentBannerElement extends UmbLitElement {
  @state() private _info?: EnvironmentInfo;

  override async connectedCallback() {
    super.connectedCallback();
    this._info = await loadEnvironmentInfo();
    if (this.isConnected && this._info && !document.getElementById('dd-environment-banner-offset')) {
      const style = document.createElement('style');
      style.id = 'dd-environment-banner-offset';
      style.textContent = `body > umb-app { position: fixed !important; top: ${BAR_HEIGHT} !important; right: 0 !important; bottom: 0 !important; left: 0 !important; height: auto !important; }`;
      document.head.appendChild(style);
    }
  }

  override disconnectedCallback() {
    super.disconnectedCallback();
    document.getElementById('dd-environment-banner-offset')?.remove();
  }

  override render() {
    if (!this._info) return nothing;
    const text = this._info.host ? `${this._info.label} · ${this._info.host}` : this._info.label;
    return html`<div class="bar" style="background:${safeColor(this._info.color)}">${text}</div>`;
  }

  static override styles = css`
    .bar { position: fixed; top: 0; left: 0; right: 0; height: 20px; z-index: 10000;
      display: flex; align-items: center; justify-content: center; color: #fff;
      font-size: 11px; font-weight: 700; letter-spacing: .08em; }
  `;
}

export default DdEnvironmentBannerElement;
