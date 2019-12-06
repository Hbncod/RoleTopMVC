using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Models;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    
    public class CadController : AbstractController
    {
        ClienteRepository clienteRepository = new ClienteRepository();

        [HttpGet]
        public IActionResult Index(RespostaViewModel respostaViewModel){
            if (respostaViewModel == null)
            {
            return View(new BaseViewModel()
            {
                NomeView = "Cadastro",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome  = ObterUsuario_Nome_Session()
            });
            }
            else{
                return View(respostaViewModel);
            }
        }

        [HttpPost]
        public IActionResult CadastrarCliente (IFormCollection form)
        {
            try
            {
                string email;
                email = form["email"];
                
                var cliente = new Cliente(
                    form["nome"],
                    form["cpf"],
                    form["tel"],
                    form["email"],
                    form["senha"] );
                
                if(clienteRepository.ObterPorEmails(email))
                {   
                    return RedirectToAction("Index", "Cad", new RespostaViewModel($"Usuário {email} Já Existe"));
                }
                else
                {
                    clienteRepository.Inserir(cliente);
                    return RedirectToAction("Index", "Home");
                }
                
                
                
            }catch(Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro",new RespostaViewModel{
                NomeView = "Erro",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome  = ObterUsuario_Nome_Session()
            });
            }
        }
    }
}