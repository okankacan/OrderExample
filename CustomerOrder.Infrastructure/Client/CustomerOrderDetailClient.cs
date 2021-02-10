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
    public class CustomerOrderDetailClient : ICustomerOrderDetailClient
    {
        private readonly IConfiguration _configuration;

        public CustomerOrderDetailClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async  Task<CustomerOrderDetail> CustomerOrderDetailById(int CustomerOrderDetailId)
        {
            var apiUrl = _configuration.GetSection("ApiUrl:BaseAdress").Value + _configuration.GetSection("ApiUrl:CustomerOrderDetailById").Value;
            var request = await HttpRequestFactory.Post(apiUrl, CustomerOrderDetailId);
            var responseContent = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<BaseResponseModel>(responseContent);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.SerializeObject(response.Data);
                return JsonConvert.DeserializeObject<CustomerOrderDetail>(data);
            }

            return null;
        }

        public async Task<bool> CustomerOrderDetailRemove(int CustomerOrderDetailId)
        {
            var apiUrl = _configuration.GetSection("ApiUrl:BaseAdress").Value + _configuration.GetSection("ApiUrl:CustomerOrderDetailRemove").Value;
            var request = await HttpRequestFactory.Post(apiUrl, CustomerOrderDetailId);
            var responseContent = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<BaseResponseModel>(responseContent);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.SerializeObject(response.Data);
                return JsonConvert.DeserializeObject<bool>(data);
            }

            return false;
        }

        public async Task<bool> CustomerOrderDetailAdd(CustomerOrderDetail model)
        {
            var apiUrl = _configuration.GetSection("ApiUrl:BaseAdress").Value + _configuration.GetSection("ApiUrl:CustumerOrderDetailAdd").Value;
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

        public async Task<List<CustomerOrderDetail>> CustomerOrderDetails(int CustomerOrderId)
        {
            var apiUrl = _configuration.GetSection("ApiUrl:BaseAdress").Value + _configuration.GetSection("ApiUrl:CustomerOrderDetails").Value;
            var request = await HttpRequestFactory.Post(apiUrl, CustomerOrderId);
            var responseContent = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<BaseResponseModel>(responseContent);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.SerializeObject(response.Data);
                return JsonConvert.DeserializeObject<List<CustomerOrderDetail>>(data);
            }

            return null;
        }
    }
}
