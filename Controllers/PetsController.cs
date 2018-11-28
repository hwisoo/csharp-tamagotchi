using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;
using System.Collections.Generic;

namespace Tamagotchi.Controllers
{
    public class PetsController : Controller
    {

        
        [HttpGet("/pet")]
        public ActionResult Index()
        {
        List<Pet> allPets = Pet.GetAll();
        return View(allPets);
        }

        [HttpGet("pets/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/pets")]
        public ActionResult Create(string name)
        {
        Pet myPet = new Pet(name);
        return RedirectToAction("Index");
        }

        [HttpGet("/pets/{id}")]
        public ActionResult Show(int id)
        {
        Pet pet = Pet.Find(id);
        return View(pet);
        }
     [HttpPost("/pets/food/{id}")]
        public ActionResult UpdateFood(int id)
        {
            Pet pet = Pet.Find(id);
            pet.SetHealth(pet.GetHealth()+10);
            return View("Show", pet);
        }

        [HttpPost("/pets/rest/{id}")]
        public ActionResult UpdateSleep(int id)
        {
            Pet pet = Pet.Find(id);
            pet.SetHealth(pet.GetHealth()+10);
            return View("Show", pet);
        }

        [HttpPost("/pets/time/{id}")]
        public ActionResult UpdateAge(int id)
        {
            Pet pet = Pet.Find(id);
            pet.SetAge(pet.GetAge()+1);
            pet.SetHealth(pet.GetHealth()-10);
            if (pet.GetHealth() <= 0)
            {
                pet.SetAlive("dead");
            }

            if (pet.GetAge() >= 10)
            {
                pet.SetAlive("Your pet is OLD");
            }
            return View("Show", pet);
        }
    }
}