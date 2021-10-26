using Entities.Concrete;
using System.Collections.Generic;

namespace UI.Models
{
    public class ProductUpdateViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}