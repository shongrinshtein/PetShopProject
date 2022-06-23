using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShop.Client.Models;
using PetShop.Data.Models;
using PetShop.Service;
using PetShop.Service.Interfaces;

namespace PetShop.Client.Controllers
{
    public class CatalogController : Controller
    {
        private ICatalogService catalogService;
        private readonly IMapper mapper;

        public CatalogController(ICatalogService catalogService, IMapper mapper)
        {
            this.mapper = mapper;
            this.catalogService = catalogService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.categories = new SelectList(catalogService.GetAllCategorys(), "CategoryId", "Name", id);
            var animals = await catalogService.GetAnimalsByCategory(id);
            animals = animals.ToList();
            var tempanim = mapper.Map<IList<AnimalViewModel>>(animals);
            return View(tempanim);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) throw new ArgumentNullException("id is null");
            var animal = await catalogService.GetAnimalById(id);
            return View(animal);
        }        
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            //if (id == null) throw new ArgumentNullException("id is null");
            await catalogService.AddComment(comment);
            return RedirectToAction("Index");
        }

    }
}
