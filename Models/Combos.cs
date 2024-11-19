using System.ComponentModel.DataAnnotations;

namespace CarlosCustodio_Ap1_P2.Models;

public class Combos
{
    [Key]
    public int combosId { get; set; }
    public DateTime fecha { get; set; } = DateTime.Now;
    public string? descripcion { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public decimal? costo { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public decimal? precio { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public int vendido { get; set; }
}
