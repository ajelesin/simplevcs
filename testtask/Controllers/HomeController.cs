using System.Web;
using System.Web.Mvc;
using testtask.Models.BusinessLogic;
using testtask.Models.DataAccess;

namespace testtask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataProvider _dataProvider;

        public HomeController()
        {
            _dataProvider = new EntityDataProvider();
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View((object) null);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return View((object)null);
            }

            var model = new SimpleVcs(_dataProvider);
            var result = model.SaveNewChanges(file.FileName, file.InputStream);

            return View(result);
        }

        [HttpGet]
        public ActionResult History()
        {
            var model = new SimpleVcs(_dataProvider);
            var result = model.LoadAssembliesHistory();
            return View(result);
        }

        [HttpGet]
        public ActionResult HistoryItem(string guid)
        {
            if (string.IsNullOrEmpty(guid))
            {
                return View("History");
            }

            var model = new SimpleVcs(_dataProvider);
            var result = model.LoadChangesHistory(guid);
            return View("HistoryItem", result);
        }

    }
}
