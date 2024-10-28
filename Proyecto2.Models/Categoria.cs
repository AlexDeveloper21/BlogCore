using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre para la categoría")]
        [Display(Name = "Nombre Categoria")]
        public string Nombre { get; set; }

        [Display(Name = "Orden de visualización")]
        [Range(1, 100, ErrorMessage = "El valor debe estar entre 0 y 100")]
        public int? Orden { get; set; }
    }
}
