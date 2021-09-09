using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Enums;
using RoleTopMVC.Models;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;
using System;

namespace RoleTopMVC.Controllers
{
    public class AgendarController : AbstractController
    {
        AgendaRepository agendarRepository = new AgendaRepository();
        ClienteRepository clienteRepository = new ClienteRepository();

        [HttpGet]
        public IActionResult Index()
        {
            var avm = new AgendarViewModel()
            {
                NomeView = "Agendar",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuario_Nome_Session()
            };

            var usuarioLogado = ObterUsuarioSession();

            var clienteLogado = clienteRepository.ObterPor(usuarioLogado);
            if (clienteLogado != null)
            {
                avm.Cliente = clienteLogado;
            }

            return View(avm);

        }
        [HttpPost]
        public IActionResult CadastrarEvento(IFormCollection form)
        {
            try
            {

                bool luzes = Convert.ToBoolean(form["luzes"]);

                bool som = Convert.ToBoolean(form["som"]);

                var evento = new Evento(
                    new Responsavel(form["nomec"],
                        form["cpf"],
                        form["tel"],
                        form["email"]
                        ),
                    form["nomeEv"],
                    int.Parse(form["convidados"]),
                    bool.Parse(form["tipoEvento"]),
                    luzes,
                    som,
                    form["desc"],
                    form["img"],
                    form["dataEvento"],
                    form["oqOcorrera"]
                );
                string data = (form["dataEvento"]);


                if (agendarRepository.ObterPorDatas(data))
                {
                    return RedirectToAction("Index", "Agendar", new AgendarViewModel($"a data {data} não está disponível"));
                }
                else
                {
                    agendarRepository.Inserir(evento);
                    return RedirectToAction("MeusEventos", "Agendar");
                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                return View(("Erro", new RespostaViewModel
                {
                    NomeView = "Erro",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuario_Nome_Session()
                }
                ));
            }
        }

        public IActionResult MeusEventos()
        {

            var emailCliente = ObterUsuarioSession();

            var eventosCliente = agendarRepository.ObterTodosPorCliente(emailCliente);
            return View(new HistoricoViewModel()
            {
                Eventos = eventosCliente,
                NomeView = "MeusEventos",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuario_Nome_Session()
            });
        }
        public IActionResult Aprovar(ulong id)
        {
            var evento = agendarRepository.ObterPorId(id);
            evento.Status = (uint)StatusAgendamento.APROVADO;

            if (agendarRepository.Atualizar(evento))
            {
                return RedirectToAction("Index", "Adm");
            }
            else
            {
                return RedirectToAction("Index", "Adm", new AdmViewModel("Não foi possivel Aprovar o Evento")
                {
                    NomeView = "Adm",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuario_Nome_Session()
                });
            }
        }

        public IActionResult Reprovar(ulong id)
        {
            var evento = agendarRepository.ObterPorId(id);
            evento.Status = (uint)StatusAgendamento.REPROVADO;

            if (agendarRepository.Atualizar(evento))
            {
                return RedirectToAction("Index", "Adm");
            }
            else
            {
                return RedirectToAction("Index", "Adm", new AdmViewModel("Não foi possivel Reprovar o Evento")
                {
                    NomeView = "Adm",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuario_Nome_Session()
                });
            }
        }
    }
}