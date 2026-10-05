import { css, html, customElement, state, nothing, unsafeCSS } from '@umbraco-cms/backoffice/external/lit';
import { UmbLitElement } from '@umbraco-cms/backoffice/lit-element';
import { loadEnvironmentInfo, safeColor, type EnvironmentInfo } from './environment-info.js';

const BAR_HEIGHT = '3px';

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
    return html`<div class="bar" style="background:${safeColor(this._info.color)}"></div>`;
  }

  static override styles = css`
    .bar { position: fixed; top: 0; left: 0; right: 0; height: ${unsafeCSS(BAR_HEIGHT)}; z-index: 10000; }
  `;
}

export default DdEnvironmentBannerElement;
