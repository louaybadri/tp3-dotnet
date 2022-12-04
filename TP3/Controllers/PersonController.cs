using Microsoft.AspNetCore.Mvc;
using TP3.Models;

namespace TP3.Controllers
{
    public class PersonController : Controller
    {
        [Route("Person/{id:int}")]
        public IActionResult index(int id)
        {
            Personal_info personal_Info = new Personal_info();

            return View(personal_Info.GetPerson(id));
        }
        [Route("Person/")]
        public IActionResult all()
        {
            Personal_info personal_Info = new Personal_info();

            return View(personal_Info.GetAllPerson());
        }
        [HttpGet]
        public IActionResult search()
        {
            ViewBag.notFound = false;
            return View();
        }
        [HttpPost]
        public IActionResult search(String first_name, String country)
        {
            Personal_info personal_info = new Personal_info();
            List<Person> personal__info = personal_info.GetAllPerson();
            foreach (Person person in personal__info)
            {
                if (person.first_name == first_name && person.country == country)
                {
                    return Redirect(person.id.ToString());

                }
            }
            ViewBag.notFound = true;
            return View();
        }
    }
}
