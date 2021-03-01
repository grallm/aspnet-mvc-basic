using System;
using System.Collections.Generic;

namespace FW_Assessment2.Models
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> AllBrands();
        Brand GetBrandById(int id);
    }
}
