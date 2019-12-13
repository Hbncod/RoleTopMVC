using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Models;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    
    public class HomeController : AbstractController
    {
        AgendaRepository agr = new AgendaRepository();
        public IActionResult Index()
        {
            List<Eventos> EventosPublicos = agr.ObterPorPrincipal();
            return View(new AgendarViewModel()
            {
                EventosPrincipal = EventosPublicos,
                NomeView = "Home" , 
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuario_Nome_Session()
            });
        }
        public IActionResult Galeria()
        {
            return View(new AgendarViewModel()
            {
                NomeView="Galeria",
                UsuarioEmail=ObterUsuarioSession(),
                UsuarioNome=ObterUsuario_Nome_Session()
            });
        }
    }
}
