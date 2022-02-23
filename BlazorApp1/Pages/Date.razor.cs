using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Smart.Design.Blazor;

namespace BlazorApp1.Pages;

public partial class Date
{
    private DateTime? _someDate = DateTime.Now.AddYears(-100);

    public DateTime? SomeDate
    {
        get => _someDate;
        set
        {
            _someDate = value;
        }
    }

    public Icon SuperIcon { get; set; } = Icon.Check;

    public string? SomeText { get; set; }

    public void ButtonClick(MouseEventArgs obj)
    {
        SomeText = SomeDate?.ToString("dd/MM/yyyy") ?? "";

        SuperIcon = Icon.Archive;
    }
}