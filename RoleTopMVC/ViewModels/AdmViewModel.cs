using System.Collections.Generic;
using RoleTopMVC.Models;

namespace RoleTopMVC.ViewModels
{
    public class AdmViewModel : BaseViewModel
    {
        public List<Evento> Eventos {get;set;}
        public uint EventosAprovados {get;set;}
        public uint EventosReprovados {get;set;}
        public uint EventosPendentes {get;set;}
        public string Mensagem {get;set;}
        public AdmViewModel()
        {
            this.Eventos = new List<Evento>();
        }
        public AdmViewModel(string mensagem)
        {
            this.Mensagem = mensagem;
        }
    }
}