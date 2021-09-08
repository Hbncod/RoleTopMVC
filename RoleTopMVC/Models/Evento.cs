using RoleTopMVC.Enums;
using System;

namespace RoleTopMVC.Models
{
    public class Evento
    {
        public ulong Id { get; set; }
        public Responsavel Responsavel { get; set; }
        public uint Status { get; set; }
        public String Agendado { get; set; }
        public String Horario { get; set; }
        public string NomeEvento { get; set; }
        public int NumeroConvidados { get; set; }
        public string DescricaoEvento { get; set; }
        public string OqueAcontecera { get; set; }
        public bool EventoPublico { get; set; }
        public bool Luzes { get; set; }
        public bool Som { get; set; }
        public string Img { get; set; }
        public decimal Preco { get; set; }

        public Evento()
        {

        }
        public Evento(Responsavel responsavel, string nomeEvento, int numeroConvidados, bool publico, bool luzes, bool som, string desc, string imagem, string agendado, string oqueAcontecera)
        {
            Responsavel = responsavel;

            Status = (uint)StatusAgendamento.PENDENTE;
            NomeEvento = nomeEvento;
            NumeroConvidados = numeroConvidados;
            EventoPublico = publico;
            DescricaoEvento = desc;
            Img = imagem;

            Agendado = agendado;

            Horario = DateTime.Now.ToShortTimeString();
            OqueAcontecera = oqueAcontecera;
            Som = som;
            Luzes = luzes;
        }
    }
}