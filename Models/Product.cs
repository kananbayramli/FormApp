using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models;

public class Product {

    [Display(Name="Id")]
    public int ProductId { get; set; }

    [Display(Name="Ad")]
    [Required]
    public string Name { get; set; } = string.Empty;

    [Display(Name="Qiymet")]
    public decimal  Price { get; set; }

    [Display(Name="Resm")]
    public string Image { get; set; } = string.Empty;

    [Display(Name ="Aktiv")]
    public bool IsActive { get; set; }

    [Display(Name="Kateqoriya")]
    public int CategoryId { get; set; }

}