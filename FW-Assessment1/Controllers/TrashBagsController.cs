using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FWAssessment1.Models;

namespace FWAssessment1.Controllers
{
    public class TrashBagsController : Controller
    {
        private List<TrashBag> trashbags
        {
            get
            {
                if (Session["Trashbags"] == null)
                {
                    Session["Trashbags"] = new List<TrashBag> {
                        new TrashBag { Id = 1, Brand = "Tesco", Volume = 50, Compostable = false },
                        new TrashBag { Id = 2, Brand = "Tesco", Volume = 30, Compostable = false },
                        new TrashBag { Id = 3, Brand = "Tesco", Volume = 10, Compostable = true },
                        new TrashBag { Id = 4, Brand = "Killeen", Volume = 100, Compostable = false },
                        new TrashBag { Id = 5, Brand = "Killeen", Volume = 1000, Compostable = true }
                    };
                }
                return Session["Trashbags"] as List<TrashBag>;
            }
            set
            {
                Session["Trashbags"] = value;
            }
        }

        // Trash bags home with bags list
        public ActionResult Index()
        {
            return View (trashbags);
        }

        // Display details of a specific bag
        public ActionResult Details (int? id)
        {
            var bag = trashbags.SingleOrDefault(a => a.Id == id);

            if (bag == null)
            {
                return HttpNotFound();
            }

            return View(bag);
        }

        // Put back all default bags
        public ActionResult Reset ()
        {
            trashbags = new List<TrashBag> {
                new TrashBag { Id = 1, Brand = "Tesco", Volume = 50, Compostable = false },
                new TrashBag { Id = 2, Brand = "Tesco", Volume = 30, Compostable = false },
                new TrashBag { Id = 3, Brand = "Tesco", Volume = 10, Compostable = true },
                new TrashBag { Id = 4, Brand = "Killeen", Volume = 100, Compostable = false },
                new TrashBag { Id = 5, Brand = "Killeen", Volume = 1000, Compostable = true }
            };

            return RedirectToAction("Index");
        }

        // Remove a bag
        public ActionResult Delete (int? id)
        {
            var bag = trashbags.Find(a => a.Id == id);

            if (bag != null)
            {
                trashbags.Remove(bag);
            }

            return RedirectToAction("Index");
        }

        // Add a bag
        public ActionResult Add (string brand, int volume, string compostable)
        {
            int id = trashbags.Last().Id + 1;
            trashbags.Add(
                new TrashBag
                {
                    Id = id,
                    Brand = brand,
                    Volume = volume,
                    Compostable = compostable == "on"
                }
            );

            return RedirectToAction("Index");
        }

        // Update a bag
        public ActionResult Update(int id, string brand, int volume, string compostable)
        {
            var bagIdx = trashbags.FindIndex(m => m.Id == id);
            if (bagIdx != -1)
                trashbags[bagIdx] = new TrashBag
                {
                    Id = id,
                    Brand = brand,
                    Volume = volume,
                    Compostable = compostable == "on"
                };

            return RedirectToAction("Index");
        }
    }
}
