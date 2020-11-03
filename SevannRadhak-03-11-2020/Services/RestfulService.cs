using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SevannRadhak_03_11_2020.Interfaces;
using SevannRadhak_03_11_2020.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SevannRadhak_03_11_2020.Services
{
    public abstract class RestfulService<T> : IRestfulService<T> where T : class
    {

        //protected static TimeSpan timeout = TimeSpan.FromSeconds(20);
        private string endpointUrl;

        protected abstract string EndpointPrefix(); 



        public RestfulService(IConfiguration config, string key)
        {
            EndpointUrl = config.GetValue<string>(key);
        }

        protected string EndpointUrl
        {
            get => endpointUrl;
            private set
            {
                endpointUrl = value;
                if (!endpointUrl.EndsWith('/'))
                {
                    endpointUrl = string.Concat(endpointUrl, '/');
                }
                if (!Uri.IsWellFormedUriString(endpointUrl, UriKind.Absolute))
                {
                    throw new Exception($"Url {value} is not well formed");
                }
            }
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            using HttpClient httpClient = new HttpClient();
            using HttpResponseMessage response = await httpClient.GetAsync(endpointUrl);
            try
            {
                string responseStream = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ICollection<T>>(responseStream);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<T>> GetManyAsync(int id)
        {
            using HttpClient httpClient = new HttpClient();
            var a = $"{ParametrizedEndpoint()}{id}";
            using HttpResponseMessage response = await httpClient.GetAsync($"{ParametrizedEndpoint()}{id}");
            try
            {
                string responseStream = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ICollection<T>>(responseStream);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private string ParametrizedEndpoint() => $"{endpointUrl}{EndpointPrefix()}";
    }
}
