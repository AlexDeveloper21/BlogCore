using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.AccesoDatos.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>>? filter = null, // Se trata de un filtro en el que puedes ponerle algun condición,
                                                      // por ejemplo que los items que quieres que se rescaten de la bbdd sean mayores de 50 euros
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, // El parametro de ordenacion, ya sea el nombre, el articulo, la categoria, etc.
            string? includeProperties = null // Incluir la propiedad relacionada, en este caso, "Categoria"
        );

        T GetFirstOrDefault(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null
        );


        void Add(T entity);
        void Remove(int id);
        void Remove(T entity);

    }
}
