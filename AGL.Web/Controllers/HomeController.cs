using AGL.Entity;
using AGL.Business.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AGL.Web.Model;
using System.Collections.Generic;

namespace AGL.Web.Controllers
{
    public class HomeController : Controller
    {
        private IPeopleService _service;
        public HomeController(IPeopleService service)
        {
            _service = service;
        }
        public ActionResult Index()
        {
            List<PetGroupModel> model = new List<PetGroupModel>();

            var people = _service.GetPeople();

            var groups = people.GroupBy(x => x.Gender);
            foreach (var group in groups)
            {
                List<Pet> pets = new List<Pet>();
                foreach (var item in group)
                {
                    if (item.Pets != null)
                        pets.AddRange(item.Pets.Where(x=> x.Type == "Cat"));
                }
                pets.Sort((a, b) => a.Name.CompareTo(b.Name));
                model.Add(new PetGroupModel { Gender = group.Key, Pets = pets });
            }

            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
