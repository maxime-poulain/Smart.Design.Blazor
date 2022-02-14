using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartPanelTitle
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}