using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Smart.Design.Blazor;

public partial class SmartRadio<TValue>
{
    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public TValue? Value { get; set; }

    public string? Name { get ; set ; }

    [CascadingParameter]
    private InputRadioContext<TValue>? CascadedContext { get; set; }

    private InputRadioContext<TValue>? Context { get; set; }

    private bool IsChecked => Context is not null && EqualityComparer<TValue?>.Default.Equals(Context.CurrentValue, Value);

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        Context = string.IsNullOrEmpty(Name) ? CascadedContext : CascadedContext?.FindContextInAncestors(Name);

        if (Context is null)
        {
            throw new InvalidOperationException(
                $"{GetType()} must have an ancestor {typeof(InputRadioGroup<TValue>)} with a matching 'Name' property, if specified.");
        }
    }

    private void OnChange(ChangeEventArgs changeEventArgs)
    {
        Context?.CallBack(changeEventArgs);
    }
}