using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartTab
{
    public string? UniqueId = Guid.NewGuid().ToString();

    [CascadingParameter]
    public TabsContext? Context { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public bool IsSelected { get ; set ; }

    protected override void OnInitialized()
    {
        if (Context is null)
        {
            throw new InvalidOperationException($"a {nameof(SmartTab)} instance required a {nameof(TabsContext)}");
        }

        Context.RegisterTab(this);
    }
}