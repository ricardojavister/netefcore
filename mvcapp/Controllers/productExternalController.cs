using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvcapp.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace mvcapp.Controllers
{
    public class productExternalController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<productExternal> productsExternal = null;

            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:85/apis/product/getall.php");
                //HTTP GET
                var responseTask = client.GetAsync("product");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<productExternal>>();
                    readTask.Wait();

                    productsExternal = readTask.Result;
                }
                else
                {
                    productsExternal = Enumerable.Empty<productExternal>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(productsExternal);
        }
    }
}