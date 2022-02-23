using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorApp1.Dtos;
using Newtonsoft.Json;

namespace BlazorApp1.Pages
{
    public partial class Radio
    {
        private string? _selectedvalue;

        public string? X { get; set; } = "1";

        public string? XX { get; set; } = "3";

        public string? Selectedvalue
        {
            get => _selectedvalue;
            set
            {
                _selectedvalue = value;
            }
        }

        public Country? SelectedCountry { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _countries = await GetCountriesAsync();
        }

        private async Task<List<Country>> GetCountriesAsync()
        {
            HttpClient httpClient = new HttpClient();
            var countriesAsJson = await httpClient.GetStringAsync("https://gist.githubusercontent.com/keeguon/2310008/raw/bdc2ce1c1e3f28f9cab5b4393c7549f38361be4e/countries.json");
            return JsonConvert.DeserializeObject<List<Country>>(countriesAsJson);
        }


        public Model Model = new();
        private List<Country> _countries = new();
    }

    public class Model
    {
        private Country? _selectedCountry;

        public string? Selected { get; set; } = "BE";

        public Country? SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                _selectedCountry = value;
            }
        }
    }
}
