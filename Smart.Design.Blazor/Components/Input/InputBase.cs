using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Smart.Design.Blazor;

public class InputBase<TValue> : ComponentBase
{
    protected string? UniqueId = Guid.NewGuid().ToString();

    private TValue? _value;

    [Parameter]
    public bool IsDisabled { get; set; }

    [Parameter]
    public string? Placeholder { get; set; }

    [Parameter]
    public TValue? Value
    {
        get => _value;
        set
        {
            if (EqualityComparer<TValue>.Default.Equals(_value, value))
                return;

            _value = value;
            ValueChanged.InvokeAsync(Value);
        }
    }

    [Parameter]
    public EventCallback<TValue> ValueChanged { get; set; }

    [Parameter]
    public EventCallback<KeyboardEventArgs> OnKeyUp { get; set; }

    [Parameter]
    public EventCallback<KeyboardEventArgs> OnKeyPress { get; set; }

    [Parameter]
    public EventCallback<KeyboardEventArgs> OnKeyDown { get; set; }

    protected virtual void OnChangeCallback(ChangeEventArgs obj)
    {
        if (obj.Value is TValue newValue)
        {
            Value = newValue;
        }
    }
}