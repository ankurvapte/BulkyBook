using Microsoft.AspNetCore.Mvc;
using BulkyBookWeb.Data;

namespace BulkyBookWeb.Models;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _dbconnection;

    public CategoryController(ApplicationDbContext db)
    {
        _dbconnection = db;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> categories = _dbconnection.Categories.ToList();
        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category category)
    {
        _dbconnection.Categories.Add(category);
        var result = _dbconnection.SaveChanges();
        return RedirectToAction("Index");
    }
}