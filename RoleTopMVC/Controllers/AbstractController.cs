using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Enums;

namespace RoleTopMVC.Controllers
{
    public class AbstractController : Controller
    {
        protected const string SESSION_CLIENTE_EMAIL = "email";
        protected const string SESSION_CLIENTE_NOME = "nome";
        protected const string SESSION_CLIENTE_TIPO = "usuario_tipo";
        protected string ObterUsuarioSession()
        {
            var email = HttpContext.Session.GetString(SESSION_CLIENTE_EMAIL); //HttpContext.Session == recebe um (chave,conteudo)

            return !string.IsNullOrEmpty(email) ? email : "";
        }
        protected string ObterUsuario_Nome_Session()
        {
            var nome = HttpContext.Session.GetString(SESSION_CLIENTE_NOME); //HttpContext.Session == recebe um (chave,conteudo)

            return !string.IsNullOrEmpty(nome) ? nome : "";
        }

        protected TipoUsuario ObterUsuarioTipoSession()
        {
            var tipoUsuario = HttpContext.Session.GetString(SESSION_CLIENTE_TIPO);

            return tipoUsuario == "CLIENTE" ? TipoUsuario.CLIENTE : TipoUsuario.ADMINISTRADOR;
        }


    }
}