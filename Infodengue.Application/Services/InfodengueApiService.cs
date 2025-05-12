using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infodengue.Application.Services
{
    public class InfodengueApiService
    {
        private readonly HttpClient _httpClient;

        public InfodengueApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ObterDadosAsync(string arbovirose, int codigoIbge, string dataInicio, string dataFim)
        {
            var url = $"https://info.dengue.mat.br/api/{arbovirose}/{codigoIbge}?startDate={dataInicio}&endDate={dataFim}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }

}
