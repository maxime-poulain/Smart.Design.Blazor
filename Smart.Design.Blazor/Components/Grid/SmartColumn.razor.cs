using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartColumn
{
    private short _width = 12;

    [Parameter]
    public short Width
    {
        get => _width;
        set
        {
            _width = value switch
            {
                <= 0 => 1,
                > 12 => 12,
                _ => value
            };
        }
    }

    [Parameter]
    public RenderFragment? ChildContent { get ; set ; }
}