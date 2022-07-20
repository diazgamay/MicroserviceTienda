using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Persistencia;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta:IRequest<CarritoDto>
        {
            public int CarritoSesionId { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, CarritoDto>
        {
            private readonly CarritoContexto _contexto;
            private readonly ILibrosServices _librosServices;

            public Manejador(CarritoContexto contexto, ILibrosServices librosServices)
            {
                _contexto = contexto;
                _librosServices = librosServices;
            }

            public async Task<CarritoDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSession = await _contexto.CarritoSesions.FirstOrDefaultAsync(x => x.CarritoSesionId == request.CarritoSesionId);
                var carritoSessinDetalle = await _contexto.CarritoSesionDetalles.Where(x => x.CarritoSesionId == request.CarritoSesionId).ToListAsync();

                var listaCarritoDto =new List<CarritoDetalleDto>();

                foreach(var libro in carritoSessinDetalle)
                {
                    var response = await _librosServices.GetLibro(new Guid(libro.ProductoSelecciondo));
                    if (response.resultado)
                    {
                        var objetoLibro = response.Libro;
                        var carritoDetalle = new CarritoDetalleDto
                        {
                            AutorLibro = objetoLibro.Titulo,
                            FechaPublicacion = objetoLibro.FechaPublicacion,
                            LibroId = objetoLibro.LibreriaMaterialId
                        };
                        listaCarritoDto.Add(carritoDetalle);
                    }
                }

                var carritoSessionDto = new CarritoDto
                {
                    CarritoId = carritoSession.CarritoSesionId,
                    FechaCreacionSesion = carritoSession.FechaCreacion,
                    ListaProductos = listaCarritoDto
                };

                return carritoSessionDto;
            }
        }
    }
}
