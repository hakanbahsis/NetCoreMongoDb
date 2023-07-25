using DataAccess.Repository;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;
using System.Text.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Category> _categoryRepository;

        public HomeController(ILogger<HomeController> logger, IRepository<Category> repository)
        {
            _logger = logger;
            _categoryRepository = repository;
        }

        public IActionResult Index()
        {

            

            //const string connectionUri = "mongodb+srv://hakanbahsis:1q2w3e.@netcorecluster.mhhvq3u.mongodb.net/?retryWrites=true&w=majority";

            //var settings = MongoClientSettings.FromConnectionString(connectionUri);

            //// Set the ServerApi field of the settings object to Stable API version 1
            //settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            //// Create a new client and connect to the server
            //var client = new MongoClient(settings);

            //// Send a ping to confirm a successful connection
            //try
            //{
            //    // var result = client.GetDatabase("CasgemDb").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
            //    var result = client.GetDatabase("CasgemDb").GetCollection<Category>("Category");
            //    var cat = new Category()
            //    {
            //        Id = ObjectId.GenerateNewId(),
            //        CategoryName = "Elektronik",
            //        Products = new List<Product>()
            //        {
            //            new Product()
            //            {
            //                Id = ObjectId.GenerateNewId(),
            //                ProductName = "Televizyon",
            //                Price = 7500,
            //                Stock = 100
            //            },
            //            new Product()
            //            {
            //                Id = ObjectId.GenerateNewId(),
            //                ProductName="Klima",
            //                Price=13700,
            //                Stock=57
            //            }
            //        }
            //    };
            //    result.InsertOne(cat);
            //    Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}

            return View();
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

        public IActionResult Create()
        {
            var result = _categoryRepository.CreateAsync(new Category
            {
                CategoryName = "Temizlik Ürünleri",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        ProductName="Fairy",
                        Price=18,
                        Stock=155
                    }
                }
            }) ;
            return View(result);
        }
    }
}