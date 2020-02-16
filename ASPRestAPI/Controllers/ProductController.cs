using ASPRestAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ASPRestAPI.Controllers
{
    public class ProductController : ApiController
    {
        public List<ProductDto> Products;
        public string LoadJson()
        {
            string sFileName = HttpContext.Current.Server.MapPath(@"products.json");
            string productsJson = File.ReadAllText(sFileName);
            return productsJson;
        }
        // GET: api/Product
        [Route("GetAll")]
        public IEnumerable<ProductDto> Get()
        {
            var jsonString = LoadJson();
            List<ProductDto> productDtos = JsonConvert.DeserializeObject<List<ProductDto>>(jsonString);
            return productDtos;
        }

        // GET: api/Product/5
        [Route("FilterCategory")]
        public List<ProductDto> Get(string id)
        {
            var jsonString = LoadJson();
            List<ProductDto> productDtos = JsonConvert.DeserializeObject<List<ProductDto>>(jsonString);
            var filteredList = new List<ProductDto>();
            foreach (var item in productDtos)
            {
                if (item.Category == id)
                {
                    filteredList.Add(item);
                }
            }
            return filteredList;
        }

        // GET : api/Product
        [Route("Categories")]
        public List<string> GetCategories()
        {
            var jsonString = LoadJson();
            List<ProductDto> productDtos = JsonConvert.DeserializeObject<List<ProductDto>>(jsonString);
            var filteredList = new List<string>();
            foreach (var item in productDtos)
            {
                filteredList.Add(item.Category);
            }
            return filteredList.Distinct().ToList();
        }

        // PUT: api/Product/5
        [Route("AddProduct")]
        public void Put(string name, [FromBody]string value)
        {
            var jsonString = LoadJson();
            List<ProductDto> productDtos = JsonConvert.DeserializeObject<List<ProductDto>>(jsonString);
            var newProd = new ProductDto
            {
                Name = name
            };

            productDtos.Add(newProd);
        }

        // DELETE: api/Product/5
        [Route("RemoveProduct")]
        public void Delete(string id)
        {
            var jsonString = LoadJson();
            List<ProductDto> productDtos = JsonConvert.DeserializeObject<List<ProductDto>>(jsonString);
            foreach(var item in productDtos)
            {
                if(item.Name == id)
                {
                    productDtos.Remove(item);
                }
            }
        }
    }
}
