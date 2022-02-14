using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartTextArea : InputBase<string>
{
    /// <summary>
    /// Number of textarea rows
    /// </summary>
    [Parameter]
    public int Rows { get ; set ; } = 5;
}