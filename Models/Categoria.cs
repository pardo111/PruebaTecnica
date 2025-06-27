namespace App.Models;

using System.ComponentModel.DataAnnotations;
public class Categoria
{
    [Key]
    public int CodigoCategoria { get; set; }
    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; }
    public ICollection<Producto> Productos { get; set; }

}