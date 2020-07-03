using System.Web.Mvc;
using ServerB.DAO;

namespace ServerB.Controllers
{
    public class CashStreamController : Controller
    {
        // GET: CashStream
        public ActionResult Index()
        {
            return View();
        }

        public string Create()
        {
            var CashStreamDAO = new CashStreamDAO();
            while (true)
            {
                var status = CashStreamDAO.UpadateCashStream();
                if (status == 1)
                    break;
            }

            return "Processing Successfully Complete !";
        }
    }
}