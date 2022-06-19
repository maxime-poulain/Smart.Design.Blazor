using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartContainer : ComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public ContainerSize Size { get; set; } = ContainerSize.Default;

    public string SizeCssClass => ContainerSizeCss();

    private string ContainerSizeCss()
    {
        return Size switch
        {
            ContainerSize.Default => string.Empty,
            ContainerSize.Small   => "o-container--small",
            ContainerSize.Medium  => "o-container--medium",
            ContainerSize.Large   => "o-container--large",
            _                     => throw new NotImplementedException($"No css class defined for size {Size}")
        };
    }
}