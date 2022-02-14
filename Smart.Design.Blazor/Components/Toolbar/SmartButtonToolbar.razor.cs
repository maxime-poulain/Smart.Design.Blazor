using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartButtonToolbar : ComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get ; set ; }
}