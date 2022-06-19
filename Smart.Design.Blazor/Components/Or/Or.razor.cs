using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class Or
{
    [Parameter]
    public string? OrLabel { get; set; }

    public RenderFragment? LeftContent { get; set; }

    public RenderFragment? RightContent { get; set; }

    protected override void OnParametersSet()
    {
        if (LeftContent is null)
        {
            throw new InvalidOperationException("Or component requires a left content");
        }

        if (RightContent is null)
        {
            throw new InvalidOperationException("Or component requires a right content");
        }
    }
}