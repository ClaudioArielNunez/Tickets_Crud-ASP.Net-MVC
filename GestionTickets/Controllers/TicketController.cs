using GestionTickets.Models;
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
            return View();
        }
    }
}