using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Client.Models;
using Newtonsoft.Json;

public class AuthenticationController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;

    public AuthenticationController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.Username == "user2@gmail.com" && model.Password == "User@123")
            {
                // Login successful
                ViewBag.LoginMessage = "Login successful!";
                return RedirectToAction("Index", "Product"); // Redirect to the Product view upon successful login
            }
            else
            {
                // Invalid login
                ModelState.AddModelError(string.Empty, "Email or password is incorrect.");
            }
        }

        return View(model);
    }

    public IActionResult Logout()
    {
        // Clear the JWT token from storage (e.g., remove cookie or clear session)

        Response.Cookies.Delete("AuthToken");

        return RedirectToAction("Index", "Home"); // Redirect to the Home view after logout
    }
}
