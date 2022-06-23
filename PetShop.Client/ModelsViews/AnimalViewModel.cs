using PetShop.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Client.Models
{
    public class AnimalViewModel
    {
        [Display(Name = "Animal Id:")]
        public int AnimalId { get; set; }
        [Display(Name = "Animal Name:")]
        [Required(ErrorMessage = "Please Enter a name")]
        public string Name { get; set; } = null!;
        [Display(Name = "Description:")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please Enter a description")]
        [StringLength(30, ErrorMessage = "Only 30 letters allowed")]
        public string? Description { get; set; }
        [Display(Name = "BirthDate:")]
        [DataType(DataType.DateTime)]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Protate:")]
        [DataType(DataType.Upload)]
        public IFormFile? Photo { get; set; }
        public string? PhotoUrl { get; set; }
        [Display(Name = "Category Name:")]
        [Required(ErrorMessage = "Please Enter a Category")]
        public int? CategoryId { get; set; }
        [Display(Name = "Category")]
        public Category? Category { get; set; }
    }
}
