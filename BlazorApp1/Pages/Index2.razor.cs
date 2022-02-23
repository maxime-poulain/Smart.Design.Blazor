using BlazorApp1.Dtos;
using CurrieTechnologies.Razor.SweetAlert2;
using FluentValidation;
using Newtonsoft.Json;

namespace BlazorApp1.Pages;

public partial class Index2
{
    private readonly Member _smartMember = new();

    private List<Country>? _countries;

    public string? Feedback { get ; set ; }

    public bool IsBusy { get ; set ; }

    /// <summary>
    /// Executed when user press the register button.
    /// </summary>
    private async void RegisterAsync()
    {
        try
        {
            IsBusy = true;
            var result = await _validator.ValidateAsync(_smartMember);
            if (!result.IsValid)
            {
                await _swal.FireAsync("Error", "Invalid request", SweetAlertIcon.Error);
                return;
            }

            await Task.Delay(2500);

            await _swal.FireAsync("", "User registered !!", SweetAlertIcon.Success);

            // Redirect to some page.
            //navigationManager.NavigateTo("/");
        }
        finally
        {
            IsBusy = false;
            StateHasChanged();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        // Countries are retrieves from an external API.
        _countries = await GetCountriesAsync();
    }

    private async Task<List<Country>?> GetCountriesAsync()
    {
       var countriesAsJson = await _httpClient.GetStringAsync(CountriesRequestUrl);
       return JsonConvert.DeserializeObject<List<Country>?>(countriesAsJson);
    }

    private static string CountriesRequestUrl => "https://gist.githubusercontent.com/keeguon/2310008/raw/bdc2ce1c1e3f28f9cab5b4393c7549f38361be4e/countries.json";
}

public class MemberRegistrationValidator : AbstractValidator<Member>
{
    public MemberRegistrationValidator()
    {
        CascadeMode = CascadeMode.Stop;

        RuleFor(member => member)
            .Must(member =>
            {
                if (member.Firstname is not null && member.Firstname.Trim().Equals("louis", StringComparison.OrdinalIgnoreCase)
                                                 && member.Lastname is not null && member.Lastname.Trim().Equals("bersini", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                return true;
            })
            .WithMessage("You know it is forbidden for you !!!!!!!");

        RuleFor(member => member)
            //.Cascade(CascadeMode.Stop)
            .Must(member =>
            {
                var likeOnlyVegetables = !member.LikeCheese && !member.LikeBurgers && member.LikeVegetables;

                return !likeOnlyVegetables;
            })
            .WithMessage("Smart doesn't accept vegans")
            .DependentRules(GenericRules);
    }

    private void GenericRules()
    {
        RuleFor(member => member.Firstname)
            .NotEmpty()
            .WithMessage("Firstname is mandatory")
            .MinimumLength(5)
            .WithMessage("Firstname is way too short");

        RuleFor(member => member.Lastname)
            .NotEmpty()
            .WithMessage("Lastname is mandatory");

        RuleFor(member => member.BirthDate)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("Birth date is mandatory")
            .Must(date => date >= DateTime.Now.AddYears(-100))
            .WithMessage("W00t you are older than Jeanne Calment which 122 years old when she died");

        RuleFor(member => member.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Email is mandatory")
            .EmailAddress()
            .WithMessage("Invalid email");

        RuleFor(member => member.Phone)
            .NotEmpty()
            .WithMessage("A phone number is mandatory");

        RuleFor(member => member.Street)
            .NotEmpty()
            .WithMessage("Street is mandatory");

        RuleFor(member => member.Number)
            .NotEmpty()
            .WithMessage("House number if mandatory");

        RuleFor(member => member.City)
            .NotEmpty()
            .WithMessage("City if mandatory");

        RuleFor(member => member.Country)
            .NotNull()
            .WithMessage("Country is mandatory");
    }
}

public class Member
{
    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Street { get; set; }

    public string? Number { get; set; }

    public string? City { get; set; }

    public Country? Country { get ; set ; }

    public bool LikeCheese { get; set; }

    public bool LikeVegetables { get; set; }

    public bool LikeBurgers { get; set; }

    public DateTime? BirthDate { get ; set ; }
}