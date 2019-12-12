using System;
using System.IO;
using RoleTopMVC.Models;

namespace RoleTopMVC.Repositories
{
    public class RepositoryBase
    {
        
        protected string ExtrairValorDoCampo (string nomeCampo, string linha) {
            var chave = nomeCampo;

            var indiceChave = linha.IndexOf (chave);
            var indiceTerminal = linha.IndexOf (";", indiceChave);

            var valor = "";

            if (indiceTerminal != -1) {
                valor = linha.Substring (indiceChave, indiceTerminal - indiceChave);
            } else {
                valor = linha.Substring (indiceChave);
            }
            System.Console.WriteLine ($"Campo {nomeCampo} e valor {valor}");
            return valor.Replace (nomeCampo + "=", "");
        }
        public string ArrumarData(string data)
        {
            string[] dataslpit = data.Split("-");
            string dt = dataslpit[2] + "-" + dataslpit[1] + "-" + dataslpit[0];
            return dt;
        }
    }
}