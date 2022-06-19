using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartGlobalBanner : ComponentBase
{
    [Parameter]
    public GlobalBannerStyle BannerStyle { get; set; }

    public Icon IconToDisplay => BannerStyle == GlobalBannerStyle.Warning ? Icon.Warning : Icon.CircleInformation;

    [Parameter]
    public RenderFragment? ChildContent { get ; set ; }

    public bool Show { get ; set ; } = true;

    public void OnCloseClicked()
    {
        ChildContent = null;
        Show = false;
    }
}