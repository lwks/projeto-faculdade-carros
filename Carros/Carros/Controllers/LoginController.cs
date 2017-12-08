using Carros.Models;
using Carros.Models.DbContext;
using Carros.Utils;
using System.Web.Mvc;

namespace Carros.Controllers
{
    public class LoginController : Controller
    {
        private LoginRepository _loginRepository;

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AutenticarAcesso(Login login)
        {
            if(ModelState.IsValid)
            {
                _loginRepository = new LoginRepository();

                string criptoSenha = CriptografiaMd5.CriptografaMd5(login.Senha);

                Login loginViewModel = _loginRepository.ObterPorEmailSenha(login.Email, criptoSenha);

                if (string.IsNullOrWhiteSpace(loginViewModel.Nome) || string.IsNullOrWhiteSpace(loginViewModel.Email))
                {
                    ModelState.AddModelError("login.Invalido", "Login ou senha inválido!");
                    return View("Index", login);
                }
                else
                {
                    SessionManager.UsuarioLogado = loginViewModel;
                    System.Web.Security.FormsAuthentication.SetAuthCookie(loginViewModel.Email, true);
                    return RedirectToAction("Obter", "Carro");
                }
            }
            return View("Index", login);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            return View("Index");
        }
    }
}