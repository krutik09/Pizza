using System.Net.Http.Json;
using System.Text.Json;
using Pizza.Model;
using Pizza.Services;
namespace Pizza.Services
{
    public  class MonkeyServices
    {
        HttpClient _httpClient;
        List<Monkey> monkeyList=new List<Monkey>();
        public MonkeyServices()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<Monkey>> GetMonkeys()
        {
            if(monkeyList.Count>0) {
                return monkeyList;
            }
            var url = "https://montemagno.com/monkeys.json";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
            }
            return monkeyList;

        }
    }
}
