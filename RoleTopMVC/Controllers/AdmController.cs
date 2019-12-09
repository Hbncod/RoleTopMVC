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
                var avm = new AgendarViewModel();

                foreach(var i in agenda )
                {
                    switch(i.Status)
                    {
                        case (uint) StatusAgendamento.APROVADO:
                            avm.EventosAprovados++;
                        break;
                        case (uint) StatusAgendamento.REPROVADO:
                            avm.EventosReprovados++;
                        break;
                        default:
                            avm.EventosPendentes++;
                        break;
                    }
                }
                    avm.NomeView = "Administrador";
                    avm.UsuarioEmail = ObterUsuarioSession();
                    return View(avm);
            }
            else
                {
                    return RedirectToAction("Index","Login", new RespostaViewModel(){
                        NomeView = "Administrador",
                        Mensagem = "Você não deveria estar aqui!"
                    });
                }
        }
    }
}