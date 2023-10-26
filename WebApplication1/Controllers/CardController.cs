using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;
using m = WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CardController : Controller
    {
        // GET: CardController
        [HttpPost]
        public  ActionResult Create(string photo, string bank, string emisor, string owner, string cardnumber, int cvv, DateTime duedate)
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@photo","../img/"+photo),
                new SqlParameter("@bank",bank),
                new SqlParameter("@emisor",emisor),
                new SqlParameter("@owner",owner),
                new SqlParameter("@cardnumber",cardnumber),
                new SqlParameter("@cvv",cvv),
                new SqlParameter("@duedate",duedate)

            };
            DataBaseWebHelper.DataBaseHelper.ExecuteNonQuery("spCreateCard", param);


            return RedirectToAction("Index","Home");
        }
      
        [HttpPost]
        public ActionResult Update(int id, string photo, string bank, string emisor, string owner, string cardnumber, int cvv, DateTime duedate)
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@ID",id),
                new SqlParameter("@photo","../img/"+photo),
                new SqlParameter("@bank",bank),
                new SqlParameter("@emisor",emisor),
                new SqlParameter("@owner",owner),
                new SqlParameter("@cardnumber",cardnumber),
                new SqlParameter("@cvv",cvv),
                new SqlParameter("@duedate",duedate)

            };
            DataBaseWebHelper.DataBaseHelper.ExecuteNonQuery("spUpdateCard", param);


            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        { 
            
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("id",Id)
            };

            DataBaseWebHelper.DataBaseHelper.ExecuteNonQuery("spDeleteCard", param);
            return RedirectToAction("Index", "Home");
        }

    }
}
