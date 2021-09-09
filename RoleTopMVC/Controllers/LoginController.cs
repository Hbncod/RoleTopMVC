using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Enums;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;
using System;

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
                    NomeView = "Login",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuario_Nome_Session()
                });
            }
            else
            {
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
                    if (cliente.Senha.Equals(senha))
                    {
                        switch (cliente.TipoUsuario)
                        {
                            case TipoUsuario.CLIENTE:
                                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, email);
                                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                                HttpContext.Session.SetString(SESSION_CLIENTE_TIPO, cliente.TipoUsuario.ToString());
                                return RedirectToAction("MeusEventos", "Agendar");

                            default:
                                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, email);
                                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                                HttpContext.Session.SetString(SESSION_CLIENTE_TIPO, cliente.TipoUsuario.ToString());

                                return RedirectToAction("Index", "Adm");
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index", "Login", new RespostaViewModel("Senha Incorreta"));
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Login", new RespostaViewModel($"Usuário {email} não foi encontrado"));
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro");
            }
        }
        public IActionResult Logoff()
        {
            HttpContext.Session.Remove(SESSION_CLIENTE_EMAIL);
            HttpContext.Session.Remove(SESSION_CLIENTE_NOME);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");

        }

    }
}