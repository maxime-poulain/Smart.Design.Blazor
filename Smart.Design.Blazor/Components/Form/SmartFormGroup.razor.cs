using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartFormGroup
{
    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public string? HelperText { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}