using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UnsecureMVC.Models;

namespace UnsecureMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    // GET: Home/InputExample
    public ActionResult InputExample()
    {
        return View();
    }

    [HttpPost]
    public ActionResult InsecureSubmit(string untrustedInput)
    {
        ViewBag.UntrustedInput = untrustedInput;
        return View("InputExample");
    }

    [HttpPost]
    public ActionResult SecureSubmit(string trustedInput)
    {
        ViewBag.TrustedInput = trustedInput;
        return View("InputExample");
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