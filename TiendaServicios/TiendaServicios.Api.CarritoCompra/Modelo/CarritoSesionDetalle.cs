﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.CarritoCompra.Modelo
{
    public class CarritoSesionDetalle
    {
        public int CarritoSesionDetalleId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string ProductoSelecciondo { get; set; }
        public int CarritoSesionId { get; set; }//Clave foranea
        public CarritoSesion CarritoSesion { get; set; }//Ancla para unir CarritoSesion y CarritoSesionDetalle
    }
}
