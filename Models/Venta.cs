namespace App.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Venta
{

    [Key]
    public int CodigoVenta { get; set; }
    [Required]
    public DateTime Fecha { get; set; }
    [ForeignKey("Producto")]
    public int CodigoProducto { get; set; }
    public Producto Producto { get; set; }

}