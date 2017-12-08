using Carros.Models;
using Carros.Models.DbContext;
using Carros.Utils;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Carros.Controllers
{
    [AutorizacaoFilter]
    public class CarroController : Controller
    {
        private CarroRepository _carroRepository;

        /// <summary>
        /// Metodo responsavel para obter todos os carros do banco
        /// </summary>
        /// <returns></returns>
        public ActionResult Obter()
        {
            _carroRepository = new CarroRepository();
            List<Carro> carrosViewModel = _carroRepository.Obter();
            ModelState.Clear();

            return View(carrosViewModel);
        }

        /// <summary>
        /// Método responsavel para adicionar um carro no banco
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Adicionar()
        {
            return View(new Carro());
        }

        /// <summary>
        /// Método responsavel para adicionar um carro no banco
        /// </summary>
        /// <param name="carro">Objeto que sera adicionado</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Adicionar(Carro carro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _carroRepository = new CarroRepository();

                    if (_carroRepository.Adicionar(carro))
                    {
                        return RedirectToAction("Obter", "Carro");
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

        /// <summary>
        /// Método responsavel para alterar um carro no banco
        /// </summary>
        /// <param name="Id">Objeto utilizado para tratar o método</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Alterar(int Id)
        {
            _carroRepository = new CarroRepository();

            var resultado = _carroRepository.Obter().Find(carro => carro.Id == Id);

            return View(resultado);
        }

        /// <summary>
        /// Método responsavel para alterar o carro
        /// </summary>
        /// <param name="carro">Objeto utilizado para tratar método</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Alterar(Carro carro)
        {
            _carroRepository = new CarroRepository();
            try
            {
                if (ModelState.IsValid)
                {
                    var resultado = _carroRepository.Atualizar(carro);
                }
                return RedirectToAction("Obter");
            }
            catch (Exception)
            {
                return View("Obter");
            }

        }

        /// <summary>
        /// Método responsavel para exclusão de carro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Excluir(int id)
        {
            _carroRepository = new CarroRepository();

            try
            {
                var resultado = _carroRepository.Excluir(id);
                
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