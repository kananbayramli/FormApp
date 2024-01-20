using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models;

public class Product {

    [Display(Name="Id")]
    public int ProductId { get; set; }

    [Display(Name="Ad")]
    public string Name { get; set; } = string.Empty;

    [Display(Name="Qiymet")]
    public decimal  Price { get; set; }

    [Display(Name="Resm")]
    public string Image { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public int CategoryId { get; set; }

}