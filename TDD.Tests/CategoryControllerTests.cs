using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using TDD.Models;
using TDD.Controllers;
using System.Web.Mvc;
using System.Linq;
using TDD.Tests.Doubles;

namespace TDD.Tests
{
    [TestClass]
    public class CategoryControllerTests
    {

        //En el TDD Test Driven Development primero creas las pruebas antes que el  codigo
        //Creas un metodo de prueba por cada funcionalidad requerida


        //Una sola prueba consiste en codigo que se ejecuta e 3 fases
        //1.-Preparar (Arrange)
        //2.-Actuar (Act)
        //3.-Asegurar (Assert)
        [TestMethod]
        public void Test_Index_Return_View()
        {
            //1.-Preparar (Arrange) : Crear instancia de clase  a probar y asignarle las propiedades requeridas y crear cualquier objeto requerido para completar la prueba
            var Context = new FakeNorthWindContext();
            CategoryController controller =
                new CategoryController(Context);




            //2.-Actuar(Act): Ejecutar funcionalidad que debe probar, invoar metodo y almacenarlo en una variable
            var result = controller.Index() as ViewResult;


            //3.-Asegurar (Assert) Verificar resultado comparandolo vs un resultado esperado
            Assert.AreEqual("Index",result.ViewName);
        }


        [TestMethod]
        public void Test_CategoryList_Model_Type()
        {
            //Fase 1 Preparar (Arrange)
            var Context = new FakeNorthWindContext();

            Context.Categories = new[]
            {
                new Category(), new Category(),
                new Category(), new Category()
            }.AsQueryable();

            var controller = new CategoryController(Context);

            //Fase 2 Actuar (Act)
            var result = controller._CategoryList() as PartialViewResult;

            //Fase 3 Aegurar(Assert)
            Assert.AreEqual(typeof(List<Category>), result.Model.GetType());

        }


        [TestMethod]
        public void Test_GetImage_Return_Type()
        {
            //1
            var Context = new FakeNorthWindContext();

            Context.Categories = new[]
            {
                new Category{ CategoryID=1,Picture= new byte[0]},
                new Category{ CategoryID=2,Picture= new byte[0]},
                new Category{ CategoryID=3,Picture= new byte[0]},
                new Category{ CategoryID=4,Picture= new byte[0]}
            }.AsQueryable();

            var controller = new CategoryController(Context);

            //2
            var result = controller.GetImage(1) as ActionResult;

            //3
            Assert.AreEqual(typeof(FileContentResult), result.GetType());

        }


        [TestMethod]
        public void Test_Display_Model_Type()
        {
            //1
            var Context = new FakeNorthWindContext();

            Context.Categories = new[]
           {
                new Category{ CategoryID=1},
                new Category{ CategoryID=2},
                new Category{ CategoryID=3},
                new Category{ CategoryID=4}
            }.AsQueryable();

            var controller = new CategoryController(Context);


            //2
            var result = controller.Display(1) as ViewResult;

            //3 
            Assert.AreEqual(typeof(Category),result.Model.GetType());
        }


        [TestMethod]
        public void Test_CategoryList_No_Parameter()
        {
            //1
            var Context = new FakeNorthWindContext();
             Context.Categories = new[]
            {
                new Category(), new Category(),
                new Category(), new Category()
            }.AsQueryable();


            var controller = new CategoryController(Context);

            //2
            var result = controller._CategoryList() as PartialViewResult;


            //3
            var model = result.Model as IEnumerable<Category>;
            Assert.AreEqual(4, model.Count());
        }


        [TestMethod]
        public void Test_CategoryList_Int_Parameter()
        {
            //1
            var Context = new FakeNorthWindContext();
            Context.Categories = new[]
           {
                new Category(), new Category(),
                new Category(), new Category()
            }.AsQueryable();


            var controller = new CategoryController(Context);

            //2
            var result = controller._CategoryList(3) as PartialViewResult;


            //3
            var model = result.Model as IEnumerable<Category>;
            Assert.AreEqual(3, model.Count());
        }


    }
}
