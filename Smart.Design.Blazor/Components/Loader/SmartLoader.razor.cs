using Microsoft.AspNetCore.Components;
using Smart.Design.Blazor.Components.Common.Enums;

namespace Smart.Design.Blazor;

public partial class SmartLoader
{
    private Alignment _alignment;

    [Parameter]
    public bool IsLoading { get; set; }

    [Parameter]
    public RenderFragment? ContentTemplate { get ; set ; }

    [Parameter]
    public RenderFragment? LoadingTemplate { get ; set ; }

    [Parameter]
    public double Height { get ; set ; } = 4d;

    [Parameter]
    public double Width { get ; set ; } = 4d;

    [Parameter]
    public Alignment Alignment
    {
        get => _alignment;
        set
        {
            _alignment = value;
            StateHasChanged();
        }
    }

    private string AlignmentCssClass
    {
        get
        {
            return Alignment switch
            {
                Alignment.Center => "o-flex--horizontal-center",
                Alignment.Start  => "o-flex--align-start",
                Alignment.End    => "o-flex--justify-end",
                _                => throw new ArgumentException("Unknown alignment", nameof(Alignment))
            };
        }
    }
}