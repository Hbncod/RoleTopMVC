using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    public class LoginController : AbstractController
    {
        private ClienteRepository clienteRepository = new ClienteRepository();
        
        [HttpGet]
        public IActionResult Index(RespostaViewModel rvm)
        {
            if (rvm == null)
            {
                return View(new BaseViewModel()
                {
                    NomeView = "Login" , 
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuario_Nome_Session()
                }); 
            } else {
                return View(rvm);
            }
            
        }
        [HttpPost]
        public IActionResult Entrar(IFormCollection form)
        {
            try
            {
                System.Console.WriteLine("==============VER SE ESTÁ RECEBENDO================");
                System.Console.WriteLine("==============VER SE ESTÁ RECEBENDO================");
                System.Console.WriteLine("==============VER SE ESTÁ RECEBENDO================");
                System.Console.WriteLine(form["email"]);
                System.Console.WriteLine(form["senha"]);

                var email = form["email"];
                var senha = form["senha"];

                var cliente = clienteRepository.ObterPor(email);

                if (cliente != null)
                {
                    if(cliente.Senha.Equals(senha))
                    {
                        HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, email);
                        HttpContext.Session.SetString(SESSION_CLIENTE_NOME,cliente.Nome);
                        return RedirectToAction("MeusEventos","Login");  //! CRIAR MEUS EVENTOS
                    }
                    else
                    {
                        return RedirectToAction("Index", "Login", new RespostaViewModel("Senha Incorreta"));
                    }
                }else{
                    return RedirectToAction("Index", "Login", new RespostaViewModel($"Usuário {email} não foi encontrado"));
                }
            }catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro");
            }
        }
        public IActionResult MeusEventos(){

            var emailCliente = ObterUsuarioSession();
            // aqui colocar os ultimos eventos da pessoa e próximos eventos
            return View(new BaseViewModel()
            {
                NomeView = "Meus Eventos" , 
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuario_Nome_Session()
            });
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Remove(SESSION_CLIENTE_EMAIL);
            HttpContext.Session.Remove(SESSION_CLIENTE_NOME);
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");

        }
        
    }
}