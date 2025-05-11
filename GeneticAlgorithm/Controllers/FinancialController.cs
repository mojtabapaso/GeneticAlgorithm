using GeneticAlgorithm.Data;
using GeneticAlgorithm.Models;
using GeneticAlgorithm.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeneticAlgorithm.Controllers;



public class FinancialController : Controller
{
    private readonly AppDbContext _context;
    private readonly Random _rnd = new Random();

    public FinancialController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var allData = _context.CompanyFinancials
            .OrderBy(f => f.ReportMonth)
            .ToList();

        var optimizedList = new List<CompanyFinancial>();

        foreach (var current in allData)
        {
            var randomPartner = allData[_rnd.Next(allData.Count)];
            var service = new GeneticService(current, randomPartner);
            var optimized = service.OptimizeGPD();
            optimizedList.Add(optimized);
        }

        ViewBag.OptimizedData = optimizedList;
        return View(allData);
    }
}

