using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FW_Assessment2.ViewModels;
using FW_Assessment2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FW_Assessment2.Controllers
{
    public class TrashBagsController : Controller
    {
        private readonly IBrandRepository _brandRepository = new MockBrandRepository();
        private readonly ITrashBagRepository _trashBagRepository;

        public TrashBagsController(ITrashBagRepository trashBagRepository)
        {
            _trashBagRepository = trashBagRepository;
        }

        // Trash bags home with bags list
        public ActionResult Index()
        {
            TrashBagViewModel trashBagViewModel = new TrashBagViewModel();
            trashBagViewModel.TrashBags = _trashBagRepository.AllTrashBags();

            return View(trashBagViewModel);
        }

        // Display details of a specific bag
        public ActionResult Details(int id)
        {
            return View(_trashBagRepository.GetTrashBagById(id));
        }

        // Put back all default bags
        public ActionResult Reset()
        {
            TrashBagViewModel trashBagViewModel = new TrashBagViewModel();
            trashBagViewModel.TrashBags = new MockTrashBagRepository().AllTrashBags();

            return RedirectToAction("Index");
        }

        // Remove a bag
        public ActionResult Delete(int id)
        {
            TrashBagViewModel trashBagViewModel = new TrashBagViewModel();

            trashBagViewModel.TrashBags = _trashBagRepository.Delete(id);

            return RedirectToAction("Index");
        }

        // Add a bag
        public ActionResult Add(string brand, int volume, string compostable)
        {
            TrashBagViewModel trashBagViewModel = new TrashBagViewModel();

            // Find the brand
            Brand brandFound = _brandRepository.AllBrands.ToList().Find(x => x.Name.Equals(brand));

            if (brandFound != null) {
              int id = _trashBagRepository.AllTrashBags().Last().Id + 1;
              trashBagViewModel.TrashBags = _trashBagRepository.Add(
                  new TrashBag
                  {
                      Id = id,
                      Brand = brandFound,
                      Volume = volume,
                      Compostable = compostable == "on"
                  }
              );
            }

            return RedirectToAction("Index");
        }

        // Update a bag
        public ActionResult Update(int id, string brand, int volume, string compostable)
        {
            TrashBagViewModel trashBagViewModel = new TrashBagViewModel();

            // Find the brand
            Brand brandFound = _brandRepository.AllBrands.ToList().Find(x => x.Name.Equals(brand));

            if (brandFound != null) {
              trashBagViewModel.TrashBags = _trashBagRepository.Update(new TrashBag
                  {
                      Id = id,
                      Brand = brandFound,
                      Volume = volume,
                      Compostable = compostable == "on"
                  });
            }

            return RedirectToAction("Index");
        }
    }
}
