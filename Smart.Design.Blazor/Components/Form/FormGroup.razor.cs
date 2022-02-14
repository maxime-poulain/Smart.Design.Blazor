using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class FormGroup
{
    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public string? HelperText { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}