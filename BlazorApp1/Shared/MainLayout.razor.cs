using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp1.Shared
{
    public partial class MainLayout
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
            }

            //await JSRuntime.InvokeAsync<IJSObjectReference>("import", "https://design.smart.coop/js/bundle-client.js");
            //await JSRuntime.InvokeAsync<IJSObjectReference>("import", "https://design.smart.coop/js/bundle-prototype.js");
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
