using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDD.Models
{
    public interface INorthWindContext
    {
        //Implementar funcionalidad  para evaluar consultas sobre el catalogo de categorias de la aplicacion NorthWind
        IQueryable<Category> Categories { get;  }

        IQueryable<Product> Products { get;  }


        Category FindCategoryByID(int ID);

        Product FindProductByID(int ID);

        T Add<T>(T entity) where T : class;

        T Delete<T>(T entity) where T : class;

        int SaveChanges();

    }
}