using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartAlert : ComponentBase
{
    [Parameter]
    public bool Closable { get ; set ; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string? Message { get; set; }

    [Parameter]
    public IEnumerable<string>? Messages { get; set; }

    [Parameter]
    public Icon? Icon { get; set; }

    [Parameter]
    public AlertStyle AlertStyle { get; set; } = AlertStyle.Default;

    /// <summary>
    /// Used internally when <see cref="Closable" /> is set to <see langword="true"/>.
    /// </summary>
    protected bool Show { get; set; } = true;

    protected override void OnParametersSet()
    {
        if (!string.IsNullOrWhiteSpace(Message) && Messages?.Count() > 0)
        {
            throw new InvalidOperationException($"{nameof(SmartAlert)} cannot have Message and Messages properties set at the same time");
        }
    }
}