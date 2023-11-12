using System.Diagnostics;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using tl2_tp09_2023_jmfloress.Repository;
using tl2_tp10_2023_jmfloress.Models;

namespace tl2_tp10_2023_jmfloress.Controllers;

public class UsuarioController : Controller
{
    private UsuarioRepository usuarioRepository;
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        usuarioRepository = new UsuarioRepository();
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(usuarioRepository.GetAll());
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View(new Usuario());
    }

    [HttpPost]
    public IActionResult Add(Usuario usuario)
    {
        usuarioRepository.Add(usuario);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        Usuario usuario = usuarioRepository.GetById(id);
        return View(usuario);
    }

    [HttpPost]
    public IActionResult Update(Usuario usuario)
    {
        usuarioRepository.Update(usuario.Id, usuario);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        usuarioRepository.Delete(id);
        return RedirectToAction("Index");
    }
}
