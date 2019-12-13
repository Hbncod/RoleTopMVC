using System;
using System.Collections.Generic;
using System.IO;
using RoleTopMVC.Enums;
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
        public List<Eventos> ObterPorPrincipal()
        {
            var publicos = ObterTodos();
            List<Eventos> eventosPrincipal = new List<Eventos>();
            
            foreach (var evento in publicos)
            {
                if(evento.Publico == 1)
                {
                    if(evento.Status == (uint) StatusAgendamento.APROVADO)
                    {
                        eventosPrincipal.Add(evento);
                    }
                }
            }
            return eventosPrincipal;
        }

        public List<Eventos> ObterTodos()
        {
            var linhas = File.ReadAllLines(PATH);

            List<Eventos> eventos = new List<Eventos>();

            
            foreach (var linha in linhas)
            {
                var DataVirada = ExtrairValorDoCampo("data_Agendada",linha);  ;
                
                Eventos evento = new Eventos();

                evento.Cliente.Nome = ExtrairValorDoCampo("cliente_nome", linha);
                evento.Cliente.Cpf = ExtrairValorDoCampo("cliente_cpf", linha);
                evento.Cliente.Telefone = ExtrairValorDoCampo("cliente_telefone",linha);
                evento.Cliente.Email = ExtrairValorDoCampo("cliente_email",linha);
                evento.Status = uint.Parse(ExtrairValorDoCampo("status_evento", linha));
                evento.Id = ulong.Parse(ExtrairValorDoCampo("Id", linha));
                evento.NomeEvento = ExtrairValorDoCampo("Evento_nome",linha);
                evento.NumeroConvidados = int.Parse(ExtrairValorDoCampo("numero_convidados",linha));
                evento.Publico = int.Parse(ExtrairValorDoCampo("evento_publico?",linha));
                evento.DescricaoEvento = ExtrairValorDoCampo("descricao_evento",linha);
                evento.Img = ExtrairValorDoCampo("Imagem", linha);
                evento.Agendado = ArrumarData(DataVirada);
                evento.Horario = ExtrairValorDoCampo("horario_inicio", linha); 
                evento.OqueAcontecera = ExtrairValorDoCampo("oq_ocorrera",linha);
                evento.PrecoTotal = int.Parse(ExtrairValorDoCampo("preco_total", linha));
                evento.Luzes = int.Parse(ExtrairValorDoCampo("luzes",linha));
                evento.Som = int.Parse(ExtrairValorDoCampo("som",linha));

                eventos.Add(evento);
            }
            return eventos;
        }
        public bool ObterPorDatas(string data)
        { 
            var linhas = File.ReadAllLines(PATH);
            var evento = new Eventos();
            foreach (var linha in linhas)
            {
                if(string.IsNullOrEmpty(linha))
                {
                    continue;
                }
                var Datas = ExtrairValorDoCampo ("data_Agendada",linha);
                // Datas = ArrumarData(Datas);
                if(data.Equals(Datas))
                {
                    return true;
                }
            }
            return false;
        }
        public Eventos ObterPorId(ulong id)
        {
            var allEventos = ObterTodos();
            foreach (var evento in allEventos)
            {
                if(id.Equals(evento.Id))
                {
                    return evento;
                }
            }
            return null;
        }
        public bool Atualizar (Eventos evento)
        {
            var allEventos = File.ReadAllLines(PATH);
            var eventoCSV = PrepararEventoCSV(evento);
            var linhaEvento = -1; //!Colocar -1 para ele n encontrar nenhuma antes
            var resultado = false;
            
            for(int i = 0; i < allEventos.Length; i++)
            {
                var idConvertido = ulong.Parse(ExtrairValorDoCampo("Id",allEventos[i]));
                if(evento.Id.Equals(idConvertido))
                {
                    linhaEvento = i;
                    resultado = true;
                    break;
                }
            }
            if(resultado)
            {
                allEventos[linhaEvento] = eventoCSV;
                File.WriteAllLines(PATH, allEventos); // Reescreve o código no csv;
            }
            return resultado;
        }
        private string PrepararEventoCSV (Eventos eventos)
        {
            Cliente c = eventos.Cliente;

            return $"Id={eventos.Id};data_Agendada={eventos.Agendado};cliente_nome={c.Nome};cliente_cpf={c.Cpf};cliente_telefone={c.Telefone};cliente_email={c.Email};Evento_nome={eventos.NomeEvento};numero_convidados={eventos.NumeroConvidados};horario_inicio={eventos.Horario};descricao_evento={eventos.DescricaoEvento};Imagem={eventos.Img};oq_ocorrera={eventos.OqueAcontecera};evento_publico?={eventos.Publico};luzes={eventos.Luzes};som={eventos.Som};preco_total={eventos.PrecoTotal};status_evento={eventos.Status};";
        }
    }
}