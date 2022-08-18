using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using MySql.Data.MySqlClient;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;

namespace WebApplicationRestApiPizza_1.Models
{
    public class PizzaDB
    {

        //Return list of all Pizzas
        public List<Pizza> ListAll()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("pizzabox");
            var collPizza = database.GetCollection<Pizza>("pizza");
            var results = collPizza.Find(new BsonDocument()).ToList();
            return results;
        }

        /*******************************************************/
        //Return list of all Pizzas

        public static Pizza EditPizza(string id)
        {
            Pizza maPizza = new Pizza();
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("pizzabox");
            var collPizza = database.GetCollection<Pizza>("pizza");
            var builder = Builders<Pizza>.Filter;
            var filter = builder.Eq("NroPizz", id);
            maPizza = collPizza.Find(filter).First();
            return maPizza;
        }

        public static string DeletePizza(string id)
        {
            Pizza maPizza = new Pizza();
            string msg;
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("pizzabox");
            var collPizza = database.GetCollection<Pizza>("pizza");
            var builder = Builders<Pizza>.Filter;
            var filter = builder.Eq("NroPizz", id);
            collPizza.FindOneAndDelete(filter);
            msg = "La pizza a été supprimée";
            return msg;
        }
    }
}