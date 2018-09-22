using netvuejs.app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace netvuejs.app.Api
{
    public class UsersController : Controller
    {

        private string url = "https://jsonplaceholder.typicode.com";
        // GET: User
        public async Task<JsonResult> Get()
        {
            var uri = $"{url}/users";
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(uri);
                var data = await result.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<IEnumerable<User>>(data);
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }
 
    }
}