using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp1.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp1.Pages
{
    public partial class TabPage
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    var ret = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "https://design.smart.coop/js/bundle-client.js");
        //    await JSRuntime.InvokeVoidAsync("_nonIterableSpread");
        //    Console.WriteLine(ret.ToJson());
        //    //await ret.InvokeVoidAsync("Tabs");
        //    await base.OnAfterRenderAsync(firstRender);
        //}
    }
}
