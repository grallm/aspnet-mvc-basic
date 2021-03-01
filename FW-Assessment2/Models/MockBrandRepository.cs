using System;
using System.Collections.Generic;
using System.Linq;

namespace FW_Assessment2.Models
{
    public class MockBrandRepository : IBrandRepository
    {
        private readonly TrashBagsContext _context;

        public MockBrandRepository(TrashBagsContext context)
        {
            _context = context;
        }

        public  IEnumerable<Brand> AllBrands()
        {
            List<Brand> myBrands =  _context.Brands.ToList();
            return myBrands;
        }

        public Brand GetBrandById(int id)
        {
            Brand brand = _context.Brands.FirstOrDefault(b => b.BrandId == id);
            return brand;
        }
    }
}
