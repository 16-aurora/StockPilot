using System.ComponentModel.DataAnnotations;

namespace StockPilot.Api.Models;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "El SKU es obligatorio.")]
    [StringLength(50, ErrorMessage = "El SKU no puede superar los 50 caracteres.")]
    public string SKU { get; set; } = string.Empty;

    [Range(0.01, 999999999, ErrorMessage = "El precio debe ser mayor que cero.")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
    public int Stock { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "El stock mínimo no puede ser negativo.")]
    public int MinimumStock { get; set; }
}