using CRUD_WEB.Models;
using CRUD_WEB.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_WEB.Controllers
{
    public class TimeController : Controller
    {
        private TimeRepositorio _repositorio;
        public ActionResult ObterTimes()
        {
            _repositorio = new TimeRepositorio();
            _repositorio.ObterTimes();
            ModelState.Clear();
            return View(_repositorio.ObterTimes());
        }
        [HttpGet] // Linha de preenchimento
        public ActionResult IncluirTime()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IncluirTime(Times timeObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new TimeRepositorio();
                    if (_repositorio.AdicionarTime(timeObj))
                    {
                        ViewBag.Mensagem = "Time cadastrdo com sucesso";
                    }
                }
                return View();
            }
            catch(Exception)
            {
                return View("ObterTimes"); // se der erro ele volta para ObterTimes
            }
        }

        [HttpGet]
        public ActionResult EditarTime(int id)
        {
            _repositorio = new TimeRepositorio();
            return View(_repositorio.ObterTimes().Find(t => t.TimeId == id));
        }
        [HttpPost]
        public ActionResult EditarTime(int id, Times timeObj)
        {
            try
            {
                _repositorio = new TimeRepositorio();
                _repositorio.AtualizarTime(timeObj);
                return RedirectToAction("ObterTimes");
            }
            catch (Exception)
            {
                return View("ObterTimes");
            }
        }

        public ActionResult ExcluirTime(int id)
        {
            try
            {
                _repositorio = new TimeRepositorio();
                if (_repositorio.ExcluirTime(id)) 
                {
                    ViewBag.Mensagem = "Time excruido com sucesso";
                }
                return RedirectToAction("ObterTimes");
            }
            catch (Exception)
            {
                return View("ObterTimes"); ;
            }
        }
    }
}