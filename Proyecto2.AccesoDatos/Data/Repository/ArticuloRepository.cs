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
    public class ArticuloRepository : Repository<Articulo>, IArticuloRepository
    {

        public readonly ApplicationDbContext _db;

        public ArticuloRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IQueryable<Articulo> AsQueryable()
        {
            return _db.Set<Articulo>().AsQueryable();
        }

        public void Update(Articulo articulo)
        {
            var item = _db.Articulo.FirstOrDefault(s => s.Id == articulo.Id);

            item.Nombre = articulo.Nombre;
            item.Descripcion = articulo.Descripcion;
            item.UrlImagen = articulo.UrlImagen;
            item.CategoriaId = articulo.CategoriaId;

            //_db.SaveChanges(); 

        }
    }
}
