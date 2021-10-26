using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace UI.Models
{
    public class ProductListViewModel
    {
       // public List<Product> Products { get; internal set; }
        public List<Product> Products { get; set; }
        public int CurrentPage { get; internal set; }
        public int PageCount { get; internal set; }
        public int PageSize { get; internal set; }
        public int CurrentCategory { get; internal set; }
    }
}