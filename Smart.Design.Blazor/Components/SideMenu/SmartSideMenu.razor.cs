using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartSideMenu : ComponentBase
{
    internal SideMenuContext SideMenuContext { get; set; } = new();

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public static SmartSideMenu Instance = default!;

    protected override void OnInitialized()
    {
        Instance = this;
    }
}
