using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ_Service.Models;
using RabbitMQ_Service.RabbitMQ;

namespace RabbitMQ_Service.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRabbitMQProducer _rabbitMQProducer;

        public HomeController(ILogger<HomeController> logger, IRabbitMQProducer rabbitMQProducer)
        {
            _logger = logger;
            _rabbitMQProducer = rabbitMQProducer;
        }

        public IActionResult Index()
        {
            _rabbitMQProducer.SendMessage<string>("Your registration is complete");
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
    }
}
