using Microsoft.AspNetCore.Http;
using NetCuisine.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCuisine.ViewModels
{
    public class ProductViewModel
    {
        public List<ProductModel> Products { get; set; }
        public List<ProductCategoryModel> Categories { get; set; }
    }
}
