using NBADataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace NBACRUD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Game> games = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = Utility.baseAddress;
                client.DefaultRequestHeaders.Accept.Add(Utility.acceptHeader);

                //HTTP GET
                var responseTask = client.GetAsync(Utility.requestiUri);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Game>>();
                    readTask.Wait();
                    games = readTask.Result;
                }
                else
                {
                    games = Enumerable.Empty<Game>();
                    ModelState.AddModelError(string.Empty, "Error !");
                }
            }
            return View(games);
        }

        public ActionResult Edit(int gameid)
        {
            using(var client = new HttpClient())
            {
                Game game = null;
                client.BaseAddress = Utility.baseAddress;
                client.DefaultRequestHeaders.Accept.Add(Utility.acceptHeader);
                
                //GET
                var getTask = client.GetAsync(Utility.requestiUri + "/" + gameid);
                getTask.Wait();
                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Game>();
                    readTask.Wait();
                    game = readTask.Result;
                }
                else
                {
                    game = null;
                    ModelState.AddModelError(string.Empty, "Error !");
                }
            }
            return View();
        }

        public ActionResult Create(Game game)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = Utility.baseAddress;
                client.DefaultRequestHeaders.Accept.Add(Utility.acceptHeader);

                //POST
                var postTask = client.PostAsJsonAsync<Game>(Utility.requestiUri, game);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = Utility.baseAddress;
                client.DefaultRequestHeaders.Accept.Add(Utility.acceptHeader);
                
                //HTTP DELETE
                var deleteTask = client.DeleteAsync(Utility.requestiUri + "/" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
