using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorApp1.Dtos;
using CurrieTechnologies.Razor.SweetAlert2;
using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Newtonsoft.Json;

namespace BlazorApp1.Pages;

public partial class TestTest
{
    private List<Country> _countries = new List<Country>();

    private readonly Member _smartMember = new Member();

    public string? Feedback { get ; set ; }

    public bool IsBusy { get ; set ; }

    /// <summary>
    /// Executed when user press the register button
    /// </summary>
    /// <param name="obj"></param>
    /// <exception cref="NotImplementedException"></exception>
    private async void Register(EditContext obj)
    {
        try
        {
            IsBusy = true;
            var validator = new MemberRegistrationValidator();
            var validationResult = await validator.ValidateAsync(_smartMember);

            await Task.Delay(4500);

            if (!validationResult.IsValid)
            {
                await _swal.FireAsync("Error", $@"One or more errors occurred, please correct the following:<br/> {string.Join($"<br /> ",
                    validationResult.Errors.Select(e => $"<span style=\"color:red;\">{e.ErrorMessage}</span>"))}",
                    SweetAlertIcon.Error);
            }
            else
            {
                await _swal.FireAsync("", "User registered !!", SweetAlertIcon.Success);
                //navigationManager.NavigateTo("/");
            }
        }
        finally
        {
            IsBusy = false;
            StateHasChanged();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        //await Task.Delay(20000);
        _countries = await GetCountriesAsync();
    }

    private async Task<List<Country>> GetCountriesAsync()
    {
        HttpClient httpClient = new HttpClient();
        var countriesAsJson = await httpClient.GetStringAsync("https://gist.githubusercontent.com/keeguon/2310008/raw/bdc2ce1c1e3f28f9cab5b4393c7549f38361be4e/countries.json");
        return JsonConvert.DeserializeObject<List<Country>>(countriesAsJson);
    }

    private void Go()
    {
        InputRadioGroup<string> s = null;
        InputRadio<string> s2 = null;
    }
}
