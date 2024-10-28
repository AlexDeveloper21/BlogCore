using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto2.AccesoDatos.Data.Repository.IRepository;
using Proyecto2.Data;
using Proyecto2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.AccesoDatos.Data.Repository
{
    internal class SliderRepository : Repository<Slider>, ISliderRepository
    {

        public readonly ApplicationDbContext _db;

        public SliderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Slider slider)
        {
            var item = _db.Slider.FirstOrDefault(s => s.Id == slider.Id);

            item.Nombre = slider.Nombre;
            item.Estado = slider.Estado;
            item.UrlImagen = slider.UrlImagen;
        }
    }
}
