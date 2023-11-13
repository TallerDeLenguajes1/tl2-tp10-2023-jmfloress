using System.Diagnostics;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_jmfloress.Repository;
using tl2_tp10_2023_jmfloress.Models;

namespace tl2_tp10_2023_jmfloress.Controllers;

public class TableroController : Controller
{
    private TableroRepository tableroRepository;
    private readonly ILogger<TableroController> _logger;

    public TableroController(ILogger<TableroController> logger)
    {
        tableroRepository = new TableroRepository();
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(tableroRepository.GetAll());
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View(new Tablero());
    }

    [HttpPost]
    public IActionResult Add(Tablero tablero)
    {
        tableroRepository.Add(tablero);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        Tablero tablero = tableroRepository.GetById(id);
        return View(tablero);
    }

    [HttpPost]
    public IActionResult Update(Tablero tablero)
    {
        tableroRepository.Update(tablero.Id, tablero);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        tableroRepository.Delete(id);
        return RedirectToAction("Index");
    }
}