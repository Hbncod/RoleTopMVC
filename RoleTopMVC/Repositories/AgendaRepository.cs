using RoleTopMVC.Enums;
using RoleTopMVC.Models;
using System.Collections.Generic;
using System.IO;

namespace RoleTopMVC.Repositories
{
    public class AgendaRepository : RepositoryBase
    {
        private const string PATH = "Database/Agenda.csv";
        public AgendaRepository()
        {
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }
        public bool Inserir(Evento eventos)
        {
            var quantidadeEventos = File.ReadAllLines(PATH).Length;
            eventos.Id = (ulong)++quantidadeEventos;
            var linha = new string[] { PrepararEventoCSV(eventos) };
            File.AppendAllLines(PATH, linha);

            return true;
        }

        public List<Evento> ObterTodosPorCliente(string emailCliente)
        {
            var eventos = ObterTodos();
            List<Evento> eventosCliente = new List<Evento>();

            foreach (var evento in eventos)
            {
                if (evento.Responsavel.Email.Equals(emailCliente))
                {
                    eventosCliente.Add(evento);
                }
            }
            return eventosCliente;
        }
        public List<Evento> ObterPorPrincipal()
        {
            var publicos = ObterTodos();
            List<Evento> eventosPrincipal = new List<Evento>();

            foreach (var evento in publicos)
            {
                if (evento.EventoPublico)
                {
                    if (evento.Status == (uint)StatusAgendamento.APROVADO)
                    {
                        eventosPrincipal.Add(evento);
                    }
                }
            }
            return eventosPrincipal;
        }

        public List<Evento> ObterTodos()
        {
            var linhas = File.ReadAllLines(PATH);

            List<Evento> eventos = new List<Evento>();


            foreach (var linha in linhas)
            {
                var DataVirada = ExtrairValorDoCampo("data_Agendada", linha); ;

                var evento = new Evento();

                evento.Responsavel.Nome = ExtrairValorDoCampo("cliente_nome", linha);
                evento.Responsavel.Cpf = ExtrairValorDoCampo("cliente_cpf", linha);
                evento.Responsavel.Telefone = ExtrairValorDoCampo("cliente_telefone", linha);
                evento.Responsavel.Email = ExtrairValorDoCampo("cliente_email", linha);
                evento.Status = uint.Parse(ExtrairValorDoCampo("status_evento", linha));
                evento.Id = ulong.Parse(ExtrairValorDoCampo("Id", linha));
                evento.NomeEvento = ExtrairValorDoCampo("Evento_nome", linha);
                evento.NumeroConvidados = int.Parse(ExtrairValorDoCampo("numero_convidados", linha));
                evento.EventoPublico = bool.Parse(ExtrairValorDoCampo("evento_publico?", linha));
                evento.DescricaoEvento = ExtrairValorDoCampo("descricao_evento", linha);
                evento.Img = ExtrairValorDoCampo("Imagem", linha);
                evento.Agendado = ArrumarData(DataVirada);
                evento.Horario = ExtrairValorDoCampo("horario_inicio", linha);
                evento.OqueAcontecera = ExtrairValorDoCampo("oq_ocorrera", linha);
                evento.Preco = decimal.Parse(ExtrairValorDoCampo("preco_total", linha));
                evento.Luzes = bool.Parse(ExtrairValorDoCampo("luzes", linha));
                evento.Som = bool.Parse(ExtrairValorDoCampo("som", linha));

                eventos.Add(evento);
            }
            return eventos;
        }
        public bool ObterPorDatas(string data)
        {
            var linhas = File.ReadAllLines(PATH);
            foreach (var linha in linhas)
            {
                if (string.IsNullOrEmpty(linha))
                {
                    continue;
                }
                var Datas = ExtrairValorDoCampo("data_Agendada", linha);
                if (data.Equals(Datas))
                {
                    return true;
                }
            }
            return false;
        }
        public Evento ObterPorId(ulong id)
        {
            var allEventos = ObterTodos();
            foreach (var evento in allEventos)
            {
                if (id.Equals(evento.Id))
                {
                    return evento;
                }
            }
            return null;
        }
        public bool Atualizar(Evento evento)
        {
            var allEventos = File.ReadAllLines(PATH);
            var eventoCSV = PrepararEventoCSV(evento);
            var linhaEvento = -1; //!Colocar -1 para ele n encontrar nenhuma antes
            var resultado = false;

            for (int i = 0; i < allEventos.Length; i++)
            {
                var idConvertido = ulong.Parse(ExtrairValorDoCampo("Id", allEventos[i]));
                if (evento.Id.Equals(idConvertido))
                {
                    linhaEvento = i;
                    resultado = true;
                    break;
                }
            }
            if (resultado)
            {
                allEventos[linhaEvento] = eventoCSV;
                File.WriteAllLines(PATH, allEventos); // Reescreve o código no csv;
            }
            return resultado;
        }
        private string PrepararEventoCSV(Evento evento)
        {
            var c = evento.Responsavel;

            return $"Id={evento.Id};data_Agendada={evento.Agendado};cliente_nome={c.Nome};cliente_cpf={c.Cpf};cliente_telefone={c.Telefone};cliente_email={c.Email};Evento_nome={evento.NomeEvento};numero_convidados={evento.NumeroConvidados};horario_inicio={evento.Horario};descricao_evento={evento.DescricaoEvento};Imagem={evento.Img};oq_ocorrera={evento.OqueAcontecera};evento_publico?={evento.EventoPublico};luzes={evento.Luzes};som={evento.Som};preco_total={evento.Preco};status_evento={evento.Status};";
        }
    }
}