using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Enums;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    public class AdmController : AbstractController
    {
        AgendaRepository agendaRepository = new AgendaRepository();

        public IActionResult Index()
        {
            var ninguemLogado = string.IsNullOrEmpty(ObterUsuarioTipoSession());
            if(!ninguemLogado && (uint) TipoUsuario.ADMINISTRADOR == uint.Parse(ObterUsuarioTipoSession()))
            {
                var agenda = agendaRepository.ObterTodos();
                var AdmVM = new AdmViewModel();

                foreach(var eventos in agenda )
                {
                    switch(eventos.Status)
                    {
                        case (uint) StatusAgendamento.APROVADO:
                            AdmVM.EventosAprovados++;
                        break;
                        case (uint) StatusAgendamento.REPROVADO:
                            AdmVM.EventosReprovados++;
                        break;
                        default:
                            AdmVM.EventosPendentes++;
                            AdmVM.Eventos.Add(eventos);
                        break;
                    }
                }
                    AdmVM.NomeView = "Administrador";
                    AdmVM.UsuarioEmail = ObterUsuarioSession();
                    return View(AdmVM);
            }
            else
                {
                    return RedirectToAction("Index","Login", new AdmViewModel(){
                        NomeView = "Login",
                        Mensagem = "Você não deveria estar aqui!"
                    });
                }
        }
    }
}