using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartCheckboxGroup
{
    [Parameter]
    public RenderFragment? ChildContent { get ; set ; }

    [Parameter]
    public bool InlineContent { get; set; }
}