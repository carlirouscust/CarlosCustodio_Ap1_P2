using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarlosCustodio_Ap1_P2.Models;

public class CombosDetalle
{
	[Key]
	public int detalleId { get; set; }

	[Required(ErrorMessage = "El campo es obligatorio")]

	public Combos? combos { get; set; }
	[ForeignKey("combos")]
	public int combosId { get; set; }

	public ArticulosC? articulos { get; set; }
	[ForeignKey("articulos")]
	public int articuloId { get; set; }

	[Required(ErrorMessage = "El campo es obligatorio")]
	public int? cantidad { get; set; }

	[Required(ErrorMessage = "El campo es obligatorio")]
	public decimal? costo { get; set; }
	
	
}
