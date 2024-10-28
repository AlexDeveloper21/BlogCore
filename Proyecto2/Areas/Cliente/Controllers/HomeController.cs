using Proyecto2.AccesoDatos.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Proyecto2.Models;
using System.Diagnostics;
using Proyecto2.Models.ViewModel;
using SQLitePCL;
using System.Drawing.Printing;

namespace Proyecto2.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public HomeController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        //Primera versión sin paginación
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    HomeVM homeVM = new HomeVM()
        //    {
        //        Sliders = _contenedorTrabajo.Slider.GetAll(),
        //        ListaArticulos = _contenedorTrabajo.Articulo.GetAll(),
        //    };

        //    /*Esto es para saber si está en Home o no*/

        //    ViewBag.IsHome = true;

        //    return View(homeVM);
        //}

        //Segunda versión: pagina de Inicio con Paginación

        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 6)
        {

            var articulos = _contenedorTrabajo.Articulo.AsQueryable();
            var paginatedEntries = articulos.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            HomeVM homeVM = new HomeVM()
            {
                Sliders = _contenedorTrabajo.Slider.GetAll(),
                ListaArticulos = paginatedEntries.ToList(),
                PageIndex = page,
                TotalPages = (int)Math.Ceiling(articulos.Count() / (double)pageSize)
            };



            /*Esto es para saber si está en Home o no*/

            ViewBag.IsHome = true;

            return View(homeVM);
        }

        [HttpGet]
        public IActionResult ResultadoBusqueda(string searchString, int page = 1, int pageSize = 3)
        {
            var articulos = _contenedorTrabajo.Articulo.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                articulos = articulos.Where(e => e.Nombre.Contains(searchString));
            }

            var totalItems = articulos.Count();

           
            var paginatedEntries = articulos.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            
            var model = new ListaPaginada<Articulo>(paginatedEntries, totalItems, page, pageSize, searchString);

            return View(model);
        }

        [HttpGet]

        public IActionResult Detalle(int id)
        {

            var articuloDesdeDb = _contenedorTrabajo.Articulo.Get(id);

            return View(articuloDesdeDb);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
