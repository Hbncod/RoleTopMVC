using System.IO;
using RoleTopMVC.Models;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Repositories
{
    public class ClienteRepository : RepositoryBase
    {
        private const string PATH = "Database/Cliente.csv";

        public ClienteRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Cliente cliente)
        {
            var linha = new string[] { PrepararRegistroCSV(cliente) };
            File.AppendAllLines(PATH, linha);

            return true;            
        }

        public bool ObterPorEmails(string email)
        { 
            var linhas = File.ReadAllLines(PATH);
            var cliente = new Cliente();
            foreach (var linha in linhas)
            {
                if(string.IsNullOrEmpty(linha))
                {
                    continue;
                }
                var Email = ExtrairValorDoCampo ("email",linha);
                
                if(email.Equals(Email))
                {
                    return true;
                }
            }
            return false;
        }

        public Cliente ObterPor(string email)
        {
            var linhas = File.ReadAllLines(PATH);
            foreach(var linha in linhas)
            {
                if(ExtrairValorDoCampo("email", linha).Equals(email))
                {
                    Cliente c = new Cliente();
                    c.Nome = ExtrairValorDoCampo ("nome", linha);
                    c.Cpf = ExtrairValorDoCampo ("cpf",linha);
                    c.Telefone = ExtrairValorDoCampo ("telefone",linha);
                    c.Email = ExtrairValorDoCampo ("email",linha);
                    c.Senha = ExtrairValorDoCampo ("senha",linha);
                    
                    return c;
                }
            }
            return null;
        }

        private string PrepararRegistroCSV(Cliente cliente)
        {
            return $"nome={cliente.Nome};cpf={cliente.Cpf};telefone={cliente.Telefone};email={cliente.Email};senha={cliente.Senha}";
        }
    }
}
