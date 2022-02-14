using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartPanel
{
    [Parameter]
    public RenderFragment? Header { get; set; }

    [Parameter]
    public RenderFragment? Body { get; set; }

    [Parameter]
    public SmartPanelTitle? Title { get; set; }
}