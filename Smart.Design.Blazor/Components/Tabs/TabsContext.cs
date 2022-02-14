namespace Smart.Design.Blazor;

/// <summary>
/// Context between the tabs and each tab.
/// </summary>
public class TabsContext
{
    public List<SmartTab> Tabs = new();

    public void RegisterTab(SmartTab tab)
    {
        if (!Tabs.Contains(tab))
            Tabs.Add(tab);
    }

    public void UpdateSelectedTab(SmartTab selectedTab)
    {
        foreach (var activeTab in Tabs.Where(tab => tab.IsSelected)) activeTab.IsSelected = false;
        selectedTab.IsSelected = true;
    }
}