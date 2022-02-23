using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp1.Pages
{
    public partial class Tab
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
    }
}
