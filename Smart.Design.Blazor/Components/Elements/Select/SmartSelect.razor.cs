using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartSelect<TItem> : ComponentBase
{
    private readonly Type _itemType;

    [Parameter]
    public string? DisplayField { get; set; }

    [Parameter]
    public string? ValueField { get; set; }

    [Parameter]
    public List<TItem>? Items { get; set; } = new();

    private TItem? _selectedItem;

    [Parameter]
    public TItem? SelectedItem
    {
        get => _selectedItem;
        set
        {
            if (ReferenceEquals(SelectedItem, value) || EqualityComparer<TItem>.Default.Equals(SelectedItem, value))
                return;

            _selectedItem = value;
            SelectedItemChanged.InvokeAsync(SelectedItem);
        }
    }

    [Parameter]
    public EventCallback<TItem> SelectedItemChanged { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get ; set ; }

    public SmartSelect()
    {
        _itemType ??= typeof(TItem);
    }

    private void OnSelectChangeCallback(ChangeEventArgs obj)
    {
        if (Items is null)
            return;

        // ChangeEventArgs' Value property is the actual HTML value of the selected <option> element.
        var selectedValue = obj.Value?.ToString();

        // foundItem may be null if for example the user selected the label <option>.
        var foundItem     = Items.FirstOrDefault(item => GetPropertyValueByName(item, ValueField) == selectedValue);
        SelectedItem      = foundItem;
    }

    private string GetPropertyValueByName(TItem item, string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return string.Empty;

        var property = _itemType.GetProperty(name);
        if (property is null)
        {
            throw new InvalidOperationException($"Property {name} doesn't exist for type {_itemType.Name}");
        }

        return property.GetValue(item, null)?.ToString() ?? string.Empty;
    }
}