using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartCheckbox : ComponentBase
{
    [Parameter]
    public string? Label { get; set; }

    private bool _isChecked;

    [Parameter]
    public bool IsChecked
    {
        get => _isChecked;
        set
        {
            if (_isChecked == value)
                return;

            _isChecked = value;
            _ = IsCheckedChanged.InvokeAsync(value);
            OnChange.InvokeAsync(new ChangeEventArgs()
            {
                Value = value
            });
        }
    }

    [Parameter]
    public EventCallback<bool> IsCheckedChanged { get; set; }


    [Parameter]
    public EventCallback<ChangeEventArgs> OnChange { get; set; }
}