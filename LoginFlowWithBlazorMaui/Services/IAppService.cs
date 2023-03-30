//using System;
//using System.Text;
//using LoginFlowWithBlazorMaui.Models;
//using System.Threading.Tasks;
//using Newtonsoft.Json;

using LoginFlowWithBlazorMaui.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LoginFlowWithBlazorMaui.Services
{
    public interface IAppService
    {
        public Task<string> login(LoginModel loginModel);

        public Task<(bool isSuccess, string ErrorMessage)> AddUser(RegistrationModel registerUser);
        public  Task<List<CountryModel>> GetCountry();
        public  Task<List<StateModel>> GetStates(int id);
    }


    public class AppService : IAppService
    {
        //private string _baseUrl = "http://localhost:5031";
        public async Task<string> login(LoginModel loginModel)
        {
            string returnStr = string.Empty;
            using (var client = new HttpClient())
            {
                var url = $"http://10.0.2.2:5031/api/SecurityMaster/login";

                var serializedStr = JsonConvert.SerializeObject(loginModel);

                var response = await client.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    returnStr = await response.Content.ReadAsStringAsync();

                }
            }
            return returnStr;
        }

        public async Task<(bool isSuccess, string ErrorMessage)> AddUser(RegistrationModel registerUser)
        {
            string errorMassage = string.Empty;
            bool isSuccess = false;
            using (var client = new HttpClient())
            {
                var url = $"http://10.0.2.2:5031/api/SecurityMaster/AddUser";

                var serializedStr = JsonConvert.SerializeObject(registerUser);

                var response = await client.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    isSuccess = true;

                }
                else
                {
                    errorMassage = await response.Content.ReadAsStringAsync();
                }
                return (isSuccess, errorMassage);
            }
        }

        public async Task<List<CountryModel>> GetCountry()
        {
            List<CountryModel> result = new List<CountryModel>();
            using (var client = new HttpClient())
            {
                var url = $"http://10.0.2.2:5031/api/Master/GetCountry";


                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<List<CountryModel>>(json);

            }
            return result;
        }

        public async Task<List<StateModel>> GetStates(int id)
        {
            List<StateModel> result = new List<StateModel>();
            using (var client = new HttpClient())
            {
                var url = $"http://10.0.2.2:5031/api/Master/GetState?parent_id={id}";


                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<List<StateModel>>(json);

            }
            return result;
        }
    }
}

