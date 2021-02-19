using System;
using System.Collections.Generic;

namespace FW_Assessment2.Models
{
    public interface ITrashBagRepository
    {
        IEnumerable<TrashBag> AllTrashBags();
        TrashBag GetTrashBagById (int Id);

        // Remove a bag
        IEnumerable<TrashBag> Delete(int id);

        // Add a bag
        IEnumerable<TrashBag> Add(TrashBag trashBag);

        // Update a bag
        IEnumerable<TrashBag> Update(TrashBag trashBag);
    }
}
