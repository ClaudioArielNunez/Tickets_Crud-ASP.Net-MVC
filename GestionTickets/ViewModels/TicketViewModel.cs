using GestionTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionTickets.ViewModels
{
    //El view model lo usamos cuando necesitamos ver mas de un modelo en la vista
    //en este view model agrupamos todo lo que necesitamos ver en la vista Nuevo,
    public class TicketViewModel
    {
        public Ticket Ticket { get; set; }
        public List<Responsable> Responsables { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<Estado> Estados { get; set; }
    }
}