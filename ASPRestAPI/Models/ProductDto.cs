using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ASPRestAPI.Models
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public ProductDto()
        {

        }
    }
}