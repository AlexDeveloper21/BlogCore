using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "El nombre es obligatorio" ) ]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria")]
        public string? Ciudad { get; set; }

        [Required(ErrorMessage = "El país es obligatoria")]
        public string? Pais { get; set; }
    }
}
