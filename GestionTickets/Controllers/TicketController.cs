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
    }
}