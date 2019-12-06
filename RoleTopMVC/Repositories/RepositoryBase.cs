using System.IO;
using RoleTopMVC.Models;

namespace RoleTopMVC.Repositories
{
    public class RepositoryBase
    {
        
        protected string ExtrairValorDoCampo(string nomeCampo, string linha) //USADO PARA RETIRAR ALGO DO CSV TAMBÉM
        {
            var chave = nomeCampo;
            var indiceChave = linha.IndexOf(chave);

            var indiceTerminal = linha.IndexOf(";" ,indiceChave);
            var valor = "";

            if(indiceTerminal != -1)
            {
                valor = linha.Substring(indiceChave, indiceTerminal - indiceChave);
            }
            else{
                valor = linha.Substring(indiceChave);
            }
            System.Console.WriteLine("=============================================================================================================================================================");
            System.Console.WriteLine($"Campo: {nomeCampo} tem valor: {valor}"); //! chave era nomeCampo
            return valor.Replace(nomeCampo + "=", "");  //Replace apaga o q está do lado direito, no caso "=" e troca pelo o que está do lado direito ""
        }
    }
}