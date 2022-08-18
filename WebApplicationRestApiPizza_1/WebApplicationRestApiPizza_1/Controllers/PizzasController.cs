using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationRestApiPizza_1.Models;

namespace WebApplicationRestApiPizza_1.Controllers
{
    public class PizzasController : Controller
    {
        // GET: Pizzas
        public ActionResult Index()
        {
            Models.PizzaDB pizzasDB = new Models.PizzaDB();
            ViewBag.Message = "pizza crud";
            ViewBag.Tablopizza = pizzasDB.ListAll();
            return View();
        }

       
        // GET: Pizzas/Details/5
        public ActionResult Details(string id)
        {
            //Models.PizzaDB pizzasDB = new Models.PizzaDB();
            ViewBag.Message = "pizza crud";
            ViewBag.pizza = Models.PizzaDB.EditPizza(id);
            ViewBag.id = id ;
            return View();
        }

        // POST: Pizzas/Details/5
        [HttpPost]
        public ActionResult Details(Pizza pizza)
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("pizzabox");
                var collPizza = database.GetCollection<Pizza>("pizza");
                collPizza.FindOneAndUpdate(Builders<Pizza>.Filter.Eq("NroPizz", pizza.NroPizz), Builders<Pizza>.Update.Set("DesignPizz", pizza.DesignPizz).Set("TarifPizz", pizza.TarifPizz));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizzas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pizzas/Create
        [HttpPost]
        public ActionResult Create(Pizza pizza)
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("pizzabox");
                var collPizza = database.GetCollection<Pizza>("pizza");
                collPizza.InsertOne(pizza);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizzas/Delete/5
        public ActionResult Delete(string id)
        {
            Models.PizzaDB.DeletePizza(id);
            return RedirectToAction("Index");
        }
    }
}
