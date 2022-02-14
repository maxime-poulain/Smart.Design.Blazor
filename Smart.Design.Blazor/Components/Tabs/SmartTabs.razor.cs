using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartTabs
{
    [Parameter]
    public TabsContext Context { get; set; } = new();

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    private RenderFragment? _activeTab;

    public void OnTabClicked(SmartTab tab)
    {
        Context.UpdateSelectedTab(tab);
        _activeTab = tab.ChildContent;
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender && Context.Tabs.Count > 0)
        {
            var firstTab = Context.Tabs[0];
            firstTab.IsSelected = true;
            _activeTab = firstTab.ChildContent;
            StateHasChanged();
        }
    }
}