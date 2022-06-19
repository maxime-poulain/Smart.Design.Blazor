using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Smart.Design.Blazor;

public class SmartNavbar : ComponentBase
{
    [Parameter]
    public Bordered Border { get; set; }

    [Parameter]
    public Height Height { get; set; }

    public string BorderedCssClass
    {
        get
        {
            return Border switch
            {
                Bordered.None   => string.Empty,
                Bordered.Top    => " c-navbar--bordered-top",
                Bordered.Bottom => " c-navbar--bordered-bottom",
                _               => throw new ArgumentOutOfRangeException($"Unknown bordered style {BorderedCssClass} for {nameof(SmartNavbar)}")
            };
        }
    }

    public string HeightCssClass
    {
        get
        {
            return Height switch
            {
                Height.Default => string.Empty,
                Height.Auto    => " c-navbar--auto",
                Height.Small   => " c-navbar--small",
                Height.Medium  => " c-navbar--medium",
                Height.Large   => " c-navbar--large",
                _            => throw new ArgumentOutOfRangeException($"Unknown Height {Height} for {nameof(SmartNavbar)}")
            };
        }
    }

    /// <summary>
    /// Gets or sets a collection of additional attributes that will be applied to the created element.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);
        builder.OpenElement(0, "div");
        builder.AddAttribute(1,  "class", "c-navbar" + BorderedCssClass + HeightCssClass);
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    }
}