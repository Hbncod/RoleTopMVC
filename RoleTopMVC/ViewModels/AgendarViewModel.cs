using System;
using System.Collections.Generic;
using RoleTopMVC.Models;

namespace RoleTopMVC.ViewModels
{
    public class AgendarViewModel : BaseViewModel
    {
        //! por as opçoes de itens q o usuario pode pedir

        public Cliente Cliente {get;set;}
        public string Datastring {get;set;}
        public string Mensagem {get;set;}
        public List<Eventos> EventosPrincipal {get;set;}
        public AgendarViewModel()
        {
            this.EventosPrincipal = new List<Eventos>();

            this.Cliente = new Cliente();
        }
        public AgendarViewModel(string mensagem)
        {
            this.Mensagem = mensagem;
        }
        
    }
}