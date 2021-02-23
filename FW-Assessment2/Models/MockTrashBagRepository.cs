using System;
using System.Collections.Generic;
using System.Linq;

namespace FW_Assessment2.Models
{
    public class MockTrashBagRepository : ITrashBagRepository
    {
        private static readonly IBrandRepository _brandRepository = new MockBrandRepository();

        List<TrashBag> trashBags = new List<TrashBag> {
            new TrashBag { Id = 1, Brand = _brandRepository.AllBrands.ToList()[1], Volume = 50, Compostable = false },
            new TrashBag { Id = 2, Brand = _brandRepository.AllBrands.ToList()[1], Volume = 30, Compostable = false },
            new TrashBag { Id = 3, Brand = _brandRepository.AllBrands.ToList()[1], Volume = 10, Compostable = true },
            new TrashBag { Id = 4, Brand = _brandRepository.AllBrands.ToList()[0], Volume = 100, Compostable = false },
            new TrashBag { Id = 5, Brand = _brandRepository.AllBrands.ToList()[0], Volume = 1000, Compostable = true }
        };

        public IEnumerable<TrashBag> AllTrashBags()
        {
            return trashBags;
        }

        public TrashBag GetTrashBagById(int Id)
        {
            return trashBags.FirstOrDefault(t => t.Id == Id);
        }

        // Remove a bag
        public IEnumerable<TrashBag> Delete(int id)
        {
            TrashBag bagToDelete = trashBags.FirstOrDefault(b => b.Id == id);
            trashBags.Remove(bagToDelete);
            return trashBags;
        }

        // Add a bag
        public IEnumerable<TrashBag> Add(TrashBag trashBag)
        {
            trashBags.Add(trashBag);
            return trashBags;
        }

        // Update a bag
        public IEnumerable<TrashBag> Update(TrashBag trashBag)
        {
            var bagIdx = trashBags.FindIndex(m => m.Id == trashBag.Id);
            if (bagIdx != -1)
                trashBags[bagIdx] = trashBag;

            return trashBags;
        }
    }
}
