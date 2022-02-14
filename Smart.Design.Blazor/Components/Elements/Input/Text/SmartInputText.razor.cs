using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartInputText : InputBase<string>
{
    [Parameter]
    public string? Name { get; set; }
}