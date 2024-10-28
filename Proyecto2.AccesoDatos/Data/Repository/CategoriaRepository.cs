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
    internal class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {

        public readonly ApplicationDbContext _db;

        public CategoriaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaCategorias()
        {
            return _db.Categoria.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public void Update(Categoria categoria)
        {
            var item = _db.Categoria.FirstOrDefault(s => s.Id == categoria.Id);

            item.Nombre = categoria.Nombre;
            item.Orden = categoria.Orden;

            //_db.SaveChanges(); 

        }


    }
}
