using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Smart.Design.Blazor;

public partial class SmartButton : ComponentBase
{
    [Parameter]
    public ButtonStyle ButtonStyle { get; set; } = ButtonStyle.Primary;

    [Parameter]
    public ButtonType Type { get; set; } = ButtonType.Button;

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public Icon? LeadingIcon { get; set; }

    [Parameter]
    public Icon? TrailingIcon { get; set; }

    [Parameter]
    public bool Block { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    public string? CssClass => GetCssClass();

    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }

    private string GetCssClass()
    {
        var styleCss = ButtonStyle switch
        {
            ButtonStyle.Primary         => " c-button--primary",
            ButtonStyle.Secondary       => " c-button--secondary",
            ButtonStyle.Danger          => " c-button--danger",
            ButtonStyle.DangerSecondary => " c-button--danger-secondary",
            ButtonStyle.Borderless      => " c-button--borderless",
            _                           => throw new NotImplementedException($"Missing css class for style {ButtonStyle}")
        };

        if (Block)
        {
            styleCss += " c-button--block";
        }

        if (string.IsNullOrWhiteSpace(Label))
        {
            styleCss += " c-button--icon";
        }

        return styleCss;
    }
}