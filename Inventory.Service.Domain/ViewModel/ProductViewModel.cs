using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Service.Domain.ViewModel
{
    public class ProductViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
    }
}
