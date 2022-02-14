using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartGlobalBanner
{
    [Parameter]
    public RenderFragment? Body { get ; set ; }

    public bool Show { get ; set ; } = true;

    public void OnCloseClicked()
    {
        Body = null;
        Show = false;
    }
}