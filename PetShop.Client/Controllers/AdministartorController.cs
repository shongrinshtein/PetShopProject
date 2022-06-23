using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShop.Client.Models;
using PetShop.Data.Models;
using PetShop.Service.Interfaces;
namespace PetShop.Client.Controllers
{
    public class AdministartorController : Controller
    {
        private IAdminstartorService adminstartorService;
        private readonly IMapper mapper;
        private IWebHostEnvironment environment;

        public AdministartorController(IAdminstartorService adminstartorService, IMapper mapper, IWebHostEnvironment Environment)
        {
            this.mapper = mapper;
            this.adminstartorService = adminstartorService;
            this.environment = Environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.categories = new SelectList(adminstartorService.GetAllCategorys(), "CategoryId", "Name", id);
            var animals = await adminstartorService.GetAnimalsByCategory(id);
            return View(mapper.Map<IList<AnimalViewModel>>(animals.ToList()));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.categories = new SelectList(adminstartorService.GetAllCategorys(), "CategoryId", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AnimalViewModel animalViewModel)//After creation get the data
        {
            if (ModelState.IsValid)
            {
                if (animalViewModel.Photo != null)
                    animalViewModel.PhotoUrl = await UploadPhoto(animalViewModel.Photo);
                var animal = mapper.Map<Animal>(animalViewModel);
                await adminstartorService.AddAnimal(animal);
                return RedirectToAction("Index");
            }
            ViewBag.categories = new SelectList(adminstartorService.GetAllCategorys(), "CategoryId", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AnimalViewModel animalViewModel)//After creation get the data
        {
            if (ModelState.IsValid)
            {
                var animal = mapper.Map<Animal>(animalViewModel);
                if (animalViewModel.Photo != null)
                {
                    RemovePhoto(animal);
                    animal.PhotoUrl = await UploadPhoto(animalViewModel.Photo);
                }
                await adminstartorService.EditAnimal(animal);
                return RedirectToAction("Index");
            }
            ViewBag.categories = new SelectList(adminstartorService.GetAllCategorys(), "CategoryId", "Name");
            return View();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) throw new ArgumentNullException("id is null");
            var animal = await adminstartorService.GetAnimalById(id);
            ViewBag.categories = new SelectList(adminstartorService.GetAllCategorys(), "CategoryId", "Name", animal.Category.CategoryId);
            return View(mapper.Map<AnimalViewModel>(animal));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) throw new ArgumentNullException("id is null");
            var animal = await adminstartorService.GetAnimalById(id);
            return View(mapper.Map<AnimalViewModel>(animal));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) throw new ArgumentNullException("id is null");

            RemovePhoto(await adminstartorService.GetAnimalById(id));
            await adminstartorService.RemoveAnimal(id);
            return RedirectToAction("Index");
        }

        public async Task<string> UploadPhoto(IFormFile? file)
        {
            if (file == null)
                return null;
            string wwwPath = this.environment.WebRootPath;
            wwwPath += "\\Images";
            Guid fileName = Guid.NewGuid();
            string tempFilePath = fileName.ToString() + ".png";
            string filePath = Path.Combine(wwwPath, tempFilePath);
            if (file.Length > 0)
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            return tempFilePath;
        } // Upload photo from static files

        private void RemovePhoto(Animal animal)
        {
            if (animal.PhotoUrl != null)
            {
                string wwwPath = this.environment.WebRootPath + "\\Images";
                string filePath = Path.Combine(wwwPath, animal.PhotoUrl);
                if (System.IO.File.Exists($"{filePath}"))
                    System.IO.File.Delete($"{filePath}");

            }
        }// remove photo from static files

    }
}
