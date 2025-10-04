using System.Diagnostics;
using System.Text;
using App.Client.PL.Models;
using App.Client.PL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Client.PL.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IScopedService scopedService1;
        private readonly IScopedService scopedService2;
        private readonly ITransentService transentService1;
        private readonly ITransentService transentService2;
        private readonly ISingeltonService singeltonService1;
        private readonly ISingeltonService singeltonService2;

        public HomeController(ILogger<HomeController> logger,
            IScopedService scopedService1,
            IScopedService scopedService2,
            ITransentService transentService1,
            ITransentService transentService2,
            ISingeltonService singeltonService1,
            ISingeltonService singeltonService2) {

            _logger = logger;
            this.scopedService1 = scopedService1;
            this.scopedService2 = scopedService2;
            this.transentService1 = transentService1;
            this.transentService2 = transentService2;
            this.singeltonService1 = singeltonService1;
            this.singeltonService2 = singeltonService2;
        }


        public string TestLifeTime() {

            StringBuilder builder = new StringBuilder();


            builder.Append($"ScopS1: {scopedService1.GetGuid()}\n\n");
            builder.Append($"ScopS2: {scopedService2.GetGuid()}\n\n");
            builder.Append($"TranS1: {transentService1.GetGuid()}\n\n");
            builder.Append($"TranS1: {transentService1.GetGuid()}\n\n");
            builder.Append($"SingS1: {singeltonService1.GetGuid()}\n\n");
            builder.Append($"SingS2: {singeltonService2.GetGuid()}\n\n");

            return builder.ToString();

        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
