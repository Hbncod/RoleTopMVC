using System;
using RoleTopMVC.Enums;
using RoleTopMVC.Repositories;

namespace RoleTopMVC.Models
{
    public class Eventos
    {
        ClienteRepository clienteRepository = new ClienteRepository();
        public ulong Id {get;set;}
        public Cliente Cliente {get;set;}
        public uint Status {get;set;}
        public double PrecoTotal {get;set;}
        public String  Agendado {get;set;}
        public String Horario {get;set;}
        public string NomeEvento {get;set;}
        public int NumeroConvidados {get;set;}
        public string DescricaoEvento {get;set;}
        public string OqueAcontecera {get;set;}
        public int Publico {get;set;}
        public int  Luzes {get;set;}
        public int Som {get;set;}
        public string Img {get;set;}
        public Eventos()
        {
            this.Cliente = new Cliente();
        }
        public Eventos(string nomeCliente, string cpf, string tel, string email ,string nomeEvento, int numeroConvidados,int publico, int luzes, int som, string desc,string imagem ,string agendado, string horario, string oqueAcontecera)
        {
            this.Cliente = new Cliente();
            Cliente.Nome = nomeCliente;
            Cliente.Cpf = cpf;
            Cliente.Telefone =  tel;
            Cliente.Email = email;
            
            this.Status = (uint) StatusAgendamento.PENDENTE;
            Id = (ulong) 0 ;
            this.NomeEvento = nomeEvento;
            this.NumeroConvidados = numeroConvidados;
            this.Publico = publico; //publico = 1,Privado = 0
            this.DescricaoEvento = desc;
            this.Img = imagem;
            
            this.Agendado = agendado;

            var hora = DateTime.Now.ToShortTimeString();
            hora = horario ;
            this.Horario = horario;
            this.OqueAcontecera = oqueAcontecera;
            this.PrecoTotal = som + luzes + 10000;
            this.Som = som;
            this.Luzes = luzes;
        }
    }
}