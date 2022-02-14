using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartGrid
{
    [Parameter]
    public RenderFragment? ChildContent { get ; set ; }
}