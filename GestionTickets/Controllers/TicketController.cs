using GestionTickets.Models;
using GestionTickets.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionTickets.Controllers
{
    public class TicketController : Controller
    {
        private TicketContext contex = new TicketContext();
        // GET: Ticket
        public ActionResult Index()
        {

                var listado = contex.Ticket;
                return View(listado);
               
        }

        //vamos a armar parejas de metodos, Nuevo get, Nuevo post
        //  Get lista la pagina, Post procesa la info
        public ActionResult Nuevo()
        {
            var viewModel = new TicketViewModel();
            viewModel.Responsables = contex.Responsable.ToList();
            viewModel.Estados = contex.Estado.ToList();
            viewModel.Usuarios = contex.Usuario.ToList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Nuevo(Ticket ticket)
        {
            contex.Ticket.Add(ticket);
            contex.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detalle(int id)
        {     //Espera un viewModel no un Modelo Ticket       
            var viewModel = new TicketViewModel();
            viewModel.Ticket = contex.Ticket.FirstOrDefault(x=>x.Id==id);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Actualizar(int id)
        {    //Primeras lineas igual a vista detalle
            var viewModel = new TicketViewModel();
            viewModel.Ticket = contex.Ticket.FirstOrDefault(x=>x.Id==id);
            //Cargamos los datos desplegables
            viewModel.Responsables = contex.Responsable.ToList();
            viewModel.Usuarios = contex.Usuario.ToList();
            viewModel.Estados = contex.Estado.ToList();            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Actualizar(Ticket ticket)
        {
            //1º forma
            contex.Entry(ticket).State=System.Data.Entity.EntityState.Modified;
            contex.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult Delete(int id)
        {
            Ticket ticket = contex.Ticket.FirstOrDefault(x=>x.Id == id);
            contex.Ticket.Remove(ticket);
            contex.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}