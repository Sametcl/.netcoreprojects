using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    public class Product
    {
        [Display(Name = "Urun Id")]
        public int ProductId { get; set; }


        [Display(Name = "Urun Adı")]
        [Required(ErrorMessage = "Ürün adı boş geçilemez")]
        [StringLength(30, ErrorMessage = "Lütfen 100 karakterden daha kısa bir ürün adı giriniz.")]
        public string Name { get; set; } = null!;



        [Display(Name = "Fiyat")]
        [Range(0,100000)]
        [Required]
        public decimal? Price { get; set; }


        [Display(Name = "Resim")]
   
        public string? Image { get; set; } = string.Empty;

        public bool IsActive { get; set; }


        [Display(Name = "Category")]
        [Required]
        public int? CategoryId { get; set; }
    }
}
