
using NUnit.Framework;
using System.Threading.Tasks;
using CrmUcu.Core;
using CrmUcu.Models.Personas;
using CrmUcu.Repositories;

namespace Library.Tests
{
    [TestFixture]
    public class HU15_RegistrarVenta
    {
        [Test]
        public async Task ConvertirCotizacionAVenta()
        {
            var repoClientes = RepositorioCliente.ObtenerInstancia();
            repoClientes.ObtenerTodos().Clear();

            var interfaz = new Interfaz();

            var vendedor = new Vendedor(
                1, "nacho@gmail.com", "Nacho", "Silva",
                "098xxxyyy", "Tachoviendo", "123nacho");

            RepositorioVendedor.ObtenerInstancia().ObtenerTodos().Clear();
            RepositorioVendedor.ObtenerInstancia().ObtenerTodos().Add(vendedor);

            interfaz.IniciarSesion("Tachoviendo", "123nacho");

            var cliente = repoClientes.CrearCliente("flor@gmail.com", "Florencia", "Ferreira", "098111222", vendedor.Id);

            // Registrar cotización primero
            var rCot = interfaz.RegistrarCotizacion(cliente.Id, "Cotización Laptop Dell", 1200m);
            Assert.That(rCot, Does.Contain("exitosamente"));
            var cotizacion = cliente.Cotizaciones[0];

            // Convertir cotización a venta
            var rVenta = interfaz.ConvertirCotizacionAVenta(cliente.Id, cotizacion.Id, "Laptop Dell");

            Assert.That(rVenta, Does.Contain("exitosamente"));
           

            await Task.CompletedTask;
        }

         
}
    }
