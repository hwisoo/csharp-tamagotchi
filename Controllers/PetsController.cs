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
    }
}