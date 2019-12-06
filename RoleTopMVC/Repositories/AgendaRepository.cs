using System;
using System.Collections.Generic;
using System.IO;
using RoleTopMVC.Models;

namespace RoleTopMVC.Repositories
{
    public class AgendaRepository : RepositoryBase
    {
        private const string PATH = "Database/Agenda.csv";
        public AgendaRepository(){
            if(!File.Exists(PATH)){
                File.Create (PATH).Close();
            }
        }
        public bool Inserir (Eventos eventos) {
            var quantidadeEventos = File.ReadAllLines(PATH).Length;
            eventos.Id = (ulong) ++quantidadeEventos;
            var linha = new string[] { PrepararEventoCSV (eventos) };
            File.AppendAllLines (PATH, linha);

            return true;
        }

        public List<Eventos> ObterTodosPorCliente(string emailCliente)
        {
            var eventos = ObterTodos();
            List<Eventos> eventosCliente = new List<Eventos>();

            foreach (var evento in eventos)
            {
                if(evento.Cliente.Email.Equals(emailCliente))
                {
                    eventosCliente.Add(evento);
                }
            }
            return eventosCliente;
        }

        public List<Eventos> ObterTodos()
        {
            var linhas = File.ReadAllLines(PATH);
            List<Eventos> eventos = new List<Eventos>();

            foreach (var linha in linhas)
            {
                
            }
            return null;
        
        }
        
        public bool ObterPorDatas(DateTime data)
        { 
            var linhas = File.ReadAllLines(PATH);
            var evento = new Eventos();
            foreach (var linha in linhas)
            {
                if(string.IsNullOrEmpty(linha))
                {
                    continue;
                }
                var Datas = DateTime.Parse(ExtrairValorDoCampo ("data_Agendada",linha));
                
                if(data.Equals(Datas))
                {
                    return true;
                }
            }
            return false;
        }

        //! copiado
        public string reverseString(string data)
        {
                char[] arrChar = data.ToCharArray();
                Array.Reverse(arrChar);
                string invertida = new String(arrChar);
                data = invertida;
                return data;
        }

        private string PrepararEventoCSV (Eventos eventos)
        {
            Cliente c = eventos.Cliente;

            return $"Id={eventos.Id};data_Agendada={eventos.Agendado};cliente_nome={c.Nome};cliente_telefone={c.Telefone};cliente_email={c.Email};Evento_nome={eventos.NomeEvento};número_convidados={eventos.NumeroConvidados};horario_inicio={eventos.Horario};descricao_evento={eventos.DescricaoEvento};oq_ocorrera={eventos.OqueAcontecera};evento_publico?={eventos.Publico};luzes={eventos.Luzes};som={eventos.Som};preco_total={eventos.PrecoTotal};status_evento={eventos.Status};";
        }
    }
}