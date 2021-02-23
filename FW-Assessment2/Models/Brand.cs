using System;
using System.Collections.Generic;

namespace FW_Assessment2.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TrashBag> TrashBags { get; set; }
    }
}
