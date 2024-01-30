using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionTickets.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public int IdEstado { get; set; }
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public int IdResponsable { get; set; }
        public string Solucion { get; set; }

    }
}