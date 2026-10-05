import { css, html, customElement, state, nothing } from '@umbraco-cms/backoffice/external/lit';
import { UmbLitElement } from '@umbraco-cms/backoffice/lit-element';
import { loadEnvironmentInfo, safeColor, type EnvironmentInfo } from './environment-info.js';

@customElement('dd-environment-badge')
export class DdEnvironmentBadgeElement extends UmbLitElement {
  @state() private _info?: EnvironmentInfo;

  override async connectedCallback() {
    super.connectedCallback();
    this._info = await loadEnvironmentInfo();
  }

  override render() {
    if (!this._info) return nothing;
    const title = [
      `${this.localize.term('ddEnvironmentIndicator_environment')}: ${this._info.environmentName}`,
      this._info.host ? `${this.localize.term('ddEnvironmentIndicator_host')}: ${this._info.host}` : '',
      `${this.localize.term('ddEnvironmentIndicator_version')}: ${this._info.umbracoVersion}`,
    ].filter(Boolean).join('\n');
    return html`<span class="badge" style="background:${safeColor(this._info.color)}" title=${title}>${this._info.label}</span>`;
  }

  static override styles = css`
    :host { display: flex; align-items: center; height: 100%; padding: 0 var(--uui-size-space-3); }
    .badge { color: #fff; font-weight: 700; font-size: 11px; letter-spacing: .05em; padding: 3px 8px; border-radius: 3px; }
  `;
}

export default DdEnvironmentBadgeElement;
