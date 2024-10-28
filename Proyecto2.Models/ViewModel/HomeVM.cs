using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Articulo> ListaArticulos { get; set; }

        //Paginación del inicio

        public int PageIndex { get; set; }

        public int TotalPages { get; set; }

    }
}
