using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace Smart.Design.Blazor;

public class SmartFileUpload : InputFile
{
    [Parameter]
    public string? Label { get ; set ; }

    [Parameter]
    public string? HelperText { get ; set ; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var sequence = 1;
        builder.OpenElement(sequence++, "div");
        builder.AddAttribute(sequence++, "class", "c-file-upload");

        // This will generate an <input type=file />
        base.BuildRenderTree(builder);

        builder.OpenElement(sequence++, "div");
        builder.AddAttribute(sequence++, "class", "c-file-upload__content");

        builder.OpenElement(sequence++, "div");
        builder.AddAttribute(sequence++, "class", "u-spacer-bottom");

        builder.OpenComponent<SmartButton>(sequence++);
        builder.AddAttribute(sequence++, nameof(SmartButton.ButtonStyle), ButtonStyle.Secondary);
        builder.AddAttribute(sequence++, nameof(SmartButton.Label), Label);
        builder.AddAttribute(sequence++, nameof(SmartButton.LeadingIcon), Icon.Attachment);
        builder.CloseComponent();

        builder.CloseElement();

        builder.OpenElement(sequence++, "p");
        builder.AddContent(sequence++, HelperText);
        builder.CloseElement();

        builder.CloseElement();
        builder.CloseElement();
    }
}