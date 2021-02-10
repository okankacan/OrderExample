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
    public class ProductClient : IProductClient
    {
        private readonly IConfiguration _configuration;

        public ProductClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ProductAdd(Product model)
        {
            var apiUrl = _configuration.GetSection("ApiUrl:BaseAdress").Value + _configuration.GetSection("ApiUrl:ProductAdd").Value;
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

        public async Task<Product> ProductById(int productId)
        {
            var apiUrl = _configuration.GetSection("ApiUrl:BaseAdress").Value + _configuration.GetSection("ApiUrl:ProductById").Value;
            var request = await HttpRequestFactory.Post(apiUrl, productId);
            var responseContent = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<BaseResponseModel>(responseContent);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.SerializeObject(response.Data);
                return JsonConvert.DeserializeObject<Product>(data);
            }

            return null;
        }

        public async Task<List<Product>> Products()
        {
            var apiUrl = _configuration.GetSection("ApiUrl:BaseAdress").Value + _configuration.GetSection("ApiUrl:Products").Value;
            var request = await HttpRequestFactory.Get(apiUrl);
            var responseContent = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<BaseResponseModel>(responseContent);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.SerializeObject(response.Data);
                return JsonConvert.DeserializeObject<List<Product>>(data);
            }

            return null;

     
        }
    }
}
