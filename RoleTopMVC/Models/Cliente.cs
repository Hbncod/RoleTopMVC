namespace RoleTopMVC.Models
{
    public class Cliente
    {
        public string Nome {get;set;}
        public string Cpf {get;set;}
        public string Telefone {get;set;}
        public string Email {get;set;}
        public string Senha {get;set;}
        public uint TipoUsuario{get;set;}
        
        public Cliente()
        {

        }
        public Cliente(string nome, string cpf, string telefone, string email, string senha)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Telefone = telefone;
            this.Email = email;
            this.Senha = senha;
        }
    }
}