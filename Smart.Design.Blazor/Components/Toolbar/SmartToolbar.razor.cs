using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartToolbar
{
    [Parameter]
    public RenderFragment? Left { get ; set ; }

    [Parameter]
    public RenderFragment? Center { get ; set ; }

    [Parameter]
    public RenderFragment? Right { get ; set ; }
}