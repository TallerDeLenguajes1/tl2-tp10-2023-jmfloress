using System.Diagnostics;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_jmfloress.Repository;
using tl2_tp10_2023_jmfloress.Models;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace tl2_tp10_2023_jmfloress.Controllers;

public class TareaController : Controller
{
    private TareaRepository tareaRepository;
    private readonly ILogger<TareaController> _logger;

    public TareaController(ILogger<TareaController> logger)
    {
        tareaRepository = new TareaRepository();
        _logger = logger;
    }

     [HttpGet]
    public IActionResult Index()
    {
        List<Tarea> tareasPorTablero = tareaRepository.GetByTablero(1);
        return View(tareasPorTablero);
    }

    [HttpGet]
    public IActionResult GetByUsuario(int idUsuario)
    {
        return View(tareaRepository.GetByUsuario(idUsuario));
    }

    [HttpGet]
    public IActionResult Add(int idTablero)
    {
        Tarea tarea = new Tarea();
        tarea.IdTablero = 1; // unico tablero >.<
        return View(tarea);
    }

    [HttpPost]
    public IActionResult Add(int idTablero, Tarea tarea)
    {
        idTablero = 1;// eliminar luego xd
        tareaRepository.Add(idTablero, tarea);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        Tarea tarea = tareaRepository.GetById(id);
        return View(tarea);
    }

    [HttpPost]
    public IActionResult Update(Tarea tarea)
    {
        tarea.IdTablero = 1; // no me llega el idTablero x.x
        tareaRepository.Update(tarea.Id, tarea);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        tareaRepository.Delete(id);
        return RedirectToAction("Index");
    }
}