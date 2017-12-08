using Carros.Models;
using System.Web;
using System.Web.Mvc;

namespace Carros.Utils
{
    public class AutorizacaoAcesso : AuthorizeAttribute
    {
        public static bool IsPermission
        {
            get
            {
                return ((Login)HttpContext.Current.Session["UsuarioLogado"]) != null;
            }
        }
    }
}