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
    public class CustomerOrderClient : ICustomerOrderClient
    {
        private readonly IConfiguration _configuration;

        public CustomerOrderClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> CustomerOrderAdd(CustomerOrders model)
        {
            var apiUrl = _configuration.GetSection("ApiUrl:BaseAdress").Value + _configuration.GetSection("ApiUrl:CustomerOrderAdd").Value;
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

        public async Task<CustomerOrders> CustomerOrderById(int CustomerOrderId)
        {
            var apiUrl = _configuration.GetSection("ApiUrl:BaseAdress").Value + _configuration.GetSection("ApiUrl:CustomerOrderById").Value;
            var request = await HttpRequestFactory.Post(apiUrl, CustomerOrderId);
            var responseContent = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<BaseResponseModel>(responseContent);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.SerializeObject(response.Data);
                return JsonConvert.DeserializeObject<CustomerOrders>(data);
            }

            return null;
        }

        public async Task<List<CustomerOrders>> CustomerOrders(int CustomerId)
        {
            var apiUrl = _configuration.GetSection("ApiUrl:BaseAdress").Value + _configuration.GetSection("ApiUrl:CustomerOrders").Value;
            var request = await HttpRequestFactory.Post(apiUrl, CustomerId);
            var responseContent = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<BaseResponseModel>(responseContent);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.SerializeObject(response.Data);
                return JsonConvert.DeserializeObject<List<CustomerOrders>>(data);
            }

            return null;
        }
    }
}
