using Carros.Models;
using Carros.Models.DbContext;
using System;
using System.Web.Mvc;

namespace Carros.Controllers
{
    public class CarroController : Controller
    {
        private Conexao _conexao;

        public ActionResult Obter()
        {
            _conexao = new Conexao();
            var retorno = _conexao.Obter();
            ModelState.Clear();

            return View(retorno);
        }

        [HttpGet]
        public ActionResult Adicionar()
        {
            return View(new Carro());
        }

        [HttpPost]
        public ActionResult Adicionar(Carro carro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _conexao = new Conexao();

                    if (_conexao.Adicionar(carro))
                    {
                        ViewBag.Mensagem = "Cadastro com sucesso!";
                    }
                }

                return View();

            }
            catch (Exception)
            {
                ViewBag.Mensagem = "Ocorreu um erro ao realizar o cadastro!";
                return View("Obter");
            }

        }

        [HttpGet]
        public ActionResult Alterar(int Id)
        {
            _conexao = new Conexao();

            var resultado = _conexao.Obter().Find(carro => carro.Id == Id);

            return View(resultado);
        }

        [HttpPost]
        public ActionResult Alterar(Carros.Models.Carro carro)
        {
            _conexao = new Conexao();
            try
            {
                if (ModelState.IsValid)
                {
                    var resultado = _conexao.Atualizar(carro);
                }
                return RedirectToAction("Obter");
            }
            catch (Exception)
            {
                return View("Obter");
            }

        }

        public ActionResult Excluir(int Id)
        {
            _conexao = new Conexao();

            try
            {
                //var resultado = _conexao.Excluir(Id);
                var resultado = true;
                if (resultado)
                {
                    ViewBag.Messagem = "Excluido com sucesso!";
                }

                return RedirectToAction("Obter");
            }
            catch (Exception)
            {
                return View("Obter");

            }
        }
    }
}