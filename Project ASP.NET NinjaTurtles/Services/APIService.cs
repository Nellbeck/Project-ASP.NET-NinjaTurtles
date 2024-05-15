using Newtonsoft.Json;
using Project_ASP.NET_NinjaTurtles.Models;
using System.Text;

namespace Project_ASP.NET_NinjaTurtles.Services
{
    public class APIService
    {

        private readonly HttpClient _client;

        public APIService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("API Client");
        }

        public async Task<List<Customer>> GetCutomersAsync()
        {
            try
            {
                var response = await _client.GetAsync("customers");
                if (!response.IsSuccessStatusCode)
                {
                    return new List<Customer>();
                }
                var jsonstring = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<Customer>>(jsonstring);
                return customers;
            }
            catch (Exception ex)
            {
                return new List<Customer>();
            }
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            var json = JsonConvert.SerializeObject(customer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("customers", data);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCustomerAsync(Guid id, Customer customer)
        {
            var json = JsonConvert.SerializeObject(customer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var respone = await _client.PutAsync($"customers/{id}", data);
            respone.EnsureSuccessStatusCode();
        }
        public async Task<Customer> FindCustomerAsync(Guid id)
        {
            var response = await _client.GetAsync($"customers/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Customer>();
            }
            else
            {
                throw new InvalidOperationException($"API failed {response.StatusCode}");
            }
        }
        public async Task DeleteCustomerAsync(Guid id)
        {
            var response = await _client.DeleteAsync($"customers/{id}");
            response.EnsureSuccessStatusCode();
        }

        //
        //              Product
        //

        public async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                var response = await _client.GetAsync("products");
                if (!response.IsSuccessStatusCode)
                {
                    return new List<Product>();
                }
                var jsonstring = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(jsonstring);
                return products;
            }
            catch (Exception ex)
            {
                return new List<Product>();
            }
        }

        public async Task AddProductAsync(Product product)
        {
            var json = JsonConvert.SerializeObject(product);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("products", data);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductAsync(Guid id, Product product)
        {
            var json = JsonConvert.SerializeObject(product);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var respone = await _client.PutAsync($"products/{id}", data);
            respone.EnsureSuccessStatusCode();
        }
        public async Task<Product> FindProductAsync(Guid id)
        {
            var response = await _client.GetAsync($"products/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Product>();
            }
            else
            {
                throw new InvalidOperationException($"API failed {response.StatusCode}");
            }
        }
        public async Task DeleteProductAsync(Guid id)
        {
            var response = await _client.DeleteAsync($"products/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
