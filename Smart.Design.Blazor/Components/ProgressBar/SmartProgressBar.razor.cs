using System.Globalization;
using Microsoft.AspNetCore.Components;

namespace Smart.Design.Blazor;

public partial class SmartProgressBar
{
    private const string BaseCss = "c-progress-bar";

    public string ValueAsCss { get ; set; } = "0";

    private int _value;

    [Parameter]
    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            if (_value < 0)
            {
                _value = 0;
            }
            if (Value > 100)
            {
                _value = 100;
            }

            ValueAsCss = (Value / 100d).ToString("0.##", CultureInfo.InvariantCulture);
        }
    }

    public string CssClass
    {
        get
        {
            var css = BaseCss;
            if (Value >= 100)
            {
                css += " c-progress-bar--success";
            }

            return css;
        }
    }
}
