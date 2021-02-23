using System;
using System.Collections.Generic;
using System.Linq;

namespace FW_Assessment2.Models
{
    public class MockBrandRepository : IBrandRepository
    {
        public IEnumerable<Brand> AllBrands =>
        new List<Brand>
        {
            new Brand{Id=1, Name="Killeen"},
            new Brand{Id=2, Name="Tesco" }
        };
    }
}
