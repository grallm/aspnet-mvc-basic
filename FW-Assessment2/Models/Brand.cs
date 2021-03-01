using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FW_Assessment2.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string Name { get; set; }
        public List<TrashBag> TrashBags { get; set; }
    }
}
