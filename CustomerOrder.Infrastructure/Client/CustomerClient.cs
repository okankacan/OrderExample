using CustomerOrder.Core.Helpers.httpClient;
using CustomerOrder.Core.Interface.Client;
using CustomerOrder.Core.Model.DbModel;
using CustomerOrder.Core.Model.ResponseModel;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Infrastructure.Client
{
    public class CustomerClient : ICustomerClient
    {
        private readonly IConfiguration _configuration;

        public CustomerClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> CustomerAdd(Customer model)
        {
            var apiUrl = _configuration.GetSection("ApiUrl:BaseAdress").Value + _configuration.GetSection("ApiUrl:CustomerAdd").Value;
            var request = await HttpRequestFactory.Post(apiUrl, model);
            var responseContent = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<BaseResponseModel>(responseContent);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.SerializeObject(response.Data);
                return JsonConvert.DeserializeObject<bool>(data);
            }

            return false;
        }

        public async Task<Customer> CustomerById(int customerId)
        {
            var apiUrl = _configuration.GetSection("ApiUrl:BaseAdress").Value + _configuration.GetSection("ApiUrl:CustomerById").Value;
            var request = await HttpRequestFactory.Post(apiUrl, customerId);
            var responseContent = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<BaseResponseModel>(responseContent);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.SerializeObject(response.Data);
                return JsonConvert.DeserializeObject<Customer>(data);
            }

            return null;
        }

        public async Task<List<Customer>> Customers()
        {
            var apiUrl = _configuration.GetSection("ApiUrl:BaseAdress").Value + _configuration.GetSection("ApiUrl:Customers").Value;
            var request = await HttpRequestFactory.Get(apiUrl);
            var responseContent = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<BaseResponseModel>(responseContent);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.SerializeObject(response.Data);
                return JsonConvert.DeserializeObject<List<Customer>>(data);
            }

            return null;
        }
    }
}
