﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FW_Assessment2.Models
{
    public class MockTrashBagRepository : ITrashBagRepository
    {
        List<TrashBag> trashBags = new List<TrashBag> {
            new TrashBag { Id = 1, BrandId = 1, Volume = 50, Compostable = false },
            new TrashBag { Id = 2, BrandId = 1, Volume = 30, Compostable = false },
            new TrashBag { Id = 3, BrandId = 1, Volume = 10, Compostable = true },
            new TrashBag { Id = 4, BrandId = 1, Volume = 100, Compostable = false },
            new TrashBag { Id = 5, BrandId = 1, Volume = 1000, Compostable = true }
        };

        private readonly TrashBagsContext _context;

        public MockTrashBagRepository(TrashBagsContext context)
        {
            _context = context;
        }

        public  IEnumerable<TrashBag> AllTrashBags()
        {
            List<TrashBag> trashBags =  _context.TrashBags.ToList();
            return trashBags;
        }

        public TrashBag GetTrashBagById(int id)
        {
            TrashBag trashBag = _context.TrashBags.FirstOrDefault(b => b.Id == id);
            return trashBag;
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
