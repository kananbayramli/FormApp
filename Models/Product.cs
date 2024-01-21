using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models;

public class Product {

    [Display(Name="Id")]
    public int ProductId { get; set; }

    [Required(ErrorMessage ="Mehsul adini daxil edin!")]
    [Display(Name="Ad")]
    public string? Name { get; set; } = string.Empty;


    [Required(ErrorMessage ="Mehsul qiymetini daxil edin!")]
    [Display(Name="Qiymet")]
    public decimal?  Price { get; set; }


    [Display(Name="Resm")]
    public string? Image { get; set; } = string.Empty;


    [Display(Name ="Aktiv")]
    public bool IsActive { get; set; }



    [Required(ErrorMessage ="Kateqoriya secin!")]
    [Display(Name="Kateqoriya")]
    public int? CategoryId { get; set; }

}