using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartTable<TItem>
{
    private string? _borderedCssClass = "";
    private string? _invisibleCssClass = "";
    private string? _styledCssClass = "";

    [Parameter]
    public IReadOnlyList<TItem>? Items { get; set; }

    private bool _bordered;

    [Parameter]
    public bool Bordered
    {
        get => _bordered;
        set
        {
            _bordered = value;
            _borderedCssClass = Bordered ? "c-table--bordered" : string.Empty;
        }
    }


    private bool _invisible;
    
    [Parameter]
    public bool Invisible
    {
        get => _invisible;
        set
        {
            _invisible = value;
            _invisibleCssClass = Invisible ? "c-table--invisible" : string.Empty;
        }
    }

    private bool _styled;

    [Parameter]
    public bool Styled
    {
        get => _styled;
        set
        {
            _styled = value;
            _styledCssClass = Styled ? "c-table--styled" : string.Empty;
        }
    }

    [Parameter]
    public RenderFragment? TableHeader { get; set; }

    [Parameter]
    public RenderFragment<TItem>? RowTemplate { get; set; }
}