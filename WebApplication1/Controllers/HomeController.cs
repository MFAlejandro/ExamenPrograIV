using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {   
            ViewBag.Cardlist = GetCards();
            return View();
        }
        public List<Card> GetCards()
        {
            //Aqui nos traemos los Resorts de SQL Server
            List<Card> CardList = new List<Card>();
            DataTable ds = DataBaseWebHelper.DataBaseHelper.ExecuteQuery("spGetCards", null);
            //

            //Recorremos el objeto para crear la lista de Resorts
            foreach (DataRow dr in ds.Rows)
            {
                CardList.Add(new Card
                {
                    Id = Convert.ToInt32(dr["ID"]),
                    photo = dr["photo"].ToString(),
                    Bank = dr["bank"].ToString(),
                    emisor = dr["emisor"].ToString(),
                    owner = dr["owner"].ToString(),
                    cardnumber = (dr["cardnumber"]).ToString(),
                    cvv = Convert.ToInt32(dr["cvv"]),
                    DueDate = Convert.ToDateTime(dr["DueDate"])
                });
            }

            return CardList;
        }
        public IActionResult CreateCard()
        {
            return View();
        }
        public List<Card> GetCard(int Id)
        {
            //Aqui nos traemos los Resorts de SQL Server
            List<Card> CardList = new List<Card>();
            List<SqlParameter> param = new List<SqlParameter>() { new SqlParameter("@Id",Id)};
            DataTable ds = DataBaseWebHelper.DataBaseHelper.ExecuteQuery("spGetCard", param);
            //

            //Recorremos el objeto para crear la lista de Resorts
            foreach (DataRow dr in ds.Rows)
            {
                CardList.Add(new Card
                {
                    Id = Convert.ToInt32(dr["ID"]),
                    photo = dr["photo"].ToString(),
                    Bank = dr["bank"].ToString(),
                    emisor = dr["emisor"].ToString(),
                    owner = dr["owner"].ToString(),
                    cardnumber = (dr["cardnumber"]).ToString(),
                    cvv = Convert.ToInt32(dr["cvv"]),
                    DueDate = Convert.ToDateTime(dr["DueDate"])
                });
            }
            return CardList;
            
        }
        public IActionResult UpdateCard(int Id) 
        {  
            ViewBag.Update = GetCard(Id);
            return View(); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}