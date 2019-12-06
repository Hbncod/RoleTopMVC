using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Models;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    public class AgendarController : AbstractController
    {
        AgendaRepository agendarRepository = new AgendaRepository();
        ClienteRepository clienteRepository = new ClienteRepository();

        [HttpGet]
        public IActionResult Index(){
            var avm = new AgendarViewModel(){
                NomeView = "Agendar" , 
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuario_Nome_Session()
            };

            var usuarioLogado = ObterUsuarioSession();

            var clienteLogado = clienteRepository.ObterPor(usuarioLogado);
            if(clienteLogado != null)
            {
                avm.Cliente = clienteLogado;
            }

            return View(avm);

        }
        [HttpPost]
        public IActionResult CadastrarEvento (IFormCollection form)
        {
            try{
            
            string luzes = (form["luzes"]);
            if(string.IsNullOrEmpty(luzes))
            { 
                luzes = "0";
            }

            string som = (form["som"]);
            if(string.IsNullOrEmpty(som))
            {
                som = "0";
            }
            Eventos evento = new Eventos(
                form["nomec"],
                form["cpf"],
                form["tel"],
                form["email"],
                form["nomeEv"],
                int.Parse(form["convidados"]),
                int.Parse(form["tipoEvento"]),
                int.Parse(luzes),
                int.Parse(som),
                form["desc"],
                DateTime.Parse(form["dataEvento"]),
                DateTime.Parse(form["horarioEvento"]),
                form["oqOcorrera"]  
            );
                DateTime data = DateTime.Parse(form["dataEvento"]);


                if(agendarRepository.ObterPorDatas(data))
                {
                    return RedirectToAction("Index","Agendar", new AgendarViewModel($"a data {data} não está disponível"));
                }
                else{
                    agendarRepository.Inserir(evento);
                    return RedirectToAction("MeusEventos","Login");
                }
            
            }catch(Exception e)
            {
                System.Console.WriteLine(e);
                return View(("Erro",new RespostaViewModel
                {
                NomeView = "Erro",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome  = ObterUsuario_Nome_Session()
                }
                ));
            }
        }
    }
}