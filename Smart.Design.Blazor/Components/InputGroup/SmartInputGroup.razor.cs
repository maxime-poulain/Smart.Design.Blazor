using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartInputGroup : SmartInputText
{
    [Parameter]
    public RenderFragment? PrependContent { get ; set ; }

    [Parameter]
    public RenderFragment? AppendContent { get ; set ; }
}