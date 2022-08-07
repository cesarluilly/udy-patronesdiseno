using System.ComponentModel.DataAnnotations;

namespace DesignPatternsAsp.Models.ViewModels
{
    public class FormBeerViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Estilo")]
        public String? Style { get; set; }

        [Display(Name = "Marca")]
        public int? BrandId { get; set; }

        [Display(Name = "Otra marca")]
        public String? OtherBrand { get; set; }

    }
}
