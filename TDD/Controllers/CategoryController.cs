using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDD.Models;

namespace TDD.Controllers
{


    //En Test Driven Development primero creas las pruebas que hacen referencia a metodos vacios de un controlador y eso provoca que fallen las pruebas al ejecutarlas
    //El segundo paso es implementar codigo en los metodos con codigo simple o incluso quemado solo para que pasen la prueba
    public class CategoryController : Controller
    {

        public CategoryController()
        {
            //Instanciar un contexto entity framework , Produccion
            Context = new NorthWindContext();
        }

        public CategoryController(INorthWindContext context)
        {
            //Utilizar el contexto doble de prueba
            this.Context = context;
        }

        private INorthWindContext Context;
        // GET: Category
        public ActionResult Index()
        {
            return View("Index");
        }

        public PartialViewResult _CategoryList(int n = 0)
        {
            List<Models.Category> Categories;
            if (n == 0)
            {
                Categories = Context.Categories.ToList();
            }else
            {
                Categories = Context.Categories.Take(n).ToList();
            }

            return PartialView("_CategoryList",Categories);
         }

        public ActionResult GetImage(int id)
        {
            int Offset = 78;
            var Category = Context.FindCategoryByID(id);
            byte[] Image = Category == null ? null :
                Category.Picture.Skip(Offset).ToArray();

            return Image == null ? null : File(Image, "image/jepg");
            
        }

        public ActionResult Display(int id)
        {
            var Category = Context.FindCategoryByID(id);
            return Category == null ? HttpNotFound() as ActionResult : View("Display", Category);
           
        }
    }
}