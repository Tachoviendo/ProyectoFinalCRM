    using CrmUcu.Models.Interacciones;
using CrmUcu.Repositories;
using CrmUcu.Models.Personas;
namespace CrmUcu
{
    /// <summary>
    /// Punto de entrada principal de la aplicación.
    /// Inicializa y ejecuta el bot de Discord.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Método principal que inicia el bot y lo mantiene en ejecución.
        /// </summary>
        public static async Task Main(string[] args)
        {

            // Arrange
            var repoClientes = RepositorioCliente.ObtenerInstancia();
            var repoVendedores = RepositorioVendedor.ObtenerInstancia();
            // Limpiar repositorio para asegurar estado controlado

            //string resultado = _interfaz.CrearVendedor(nombre, apellido, mail, telefono, nombreUsuario, password);
            
            repoVendedores.CrearVendedor("a", "a" , "a@mail.com", "123123", "a", "a"); //id = 0
            repoVendedores.CrearVendedor("b", "b" , "b@mail.com", "123123", "b", "b"); //id = 1
            repoVendedores.CrearVendedor("c", "c" , "a@mail.com", "123123", "c", "c"); //id = 2
            repoVendedores.CrearVendedor("d", "d" , "a@mail.com", "123123", "d", "d"); //id = 3
            repoVendedores.CrearVendedor("e", "e" , "a@mail.com", "123123", "e", "e"); // id =4  
            repoVendedores.CrearVendedor("f", "f" , "a@mail.com", "123123", "f", "f"); // id = 5
                        

            // Crear clientes
            var cliente1 = repoClientes.CrearCliente("a", "a", "a", "123123", 0);
            var cliente2 = repoClientes.CrearCliente("b", "b", "B", "123", 1);
            var cliente3 = repoClientes.CrearCliente("c", "c", "c", "123", 2);
            var cliente4 = repoClientes.CrearCliente("d", "d", "d", "123", 3);
            var cliente5 = repoClientes.CrearCliente("e", "e", "e", "123", 4);
            var cliente6 = repoClientes.CrearCliente("f", "f", "f", "123", 4);
            var cliente7 = repoClientes.CrearCliente("g", "g", "g", "123", 5);


            List<Cliente> clientes = repoClientes.ObtenerTodos();
            List<Vendedor> vendedores =  repoVendedores.ObtenerTodos();
            
            var cotizacion = new Cotizacion(cliente1.Id, DateTime.Now, "a", 200);
            vendedores[0].RegistrarInteraccion(cliente1.Id, cotizacion);
            vendedores[0].ConvertirCotizacionAVenta(cliente1.Id, cotizacion.Id, "a");

            cotizacion = new Cotizacion(cliente2.Id, DateTime.Now, "b", 100);
            vendedores[1].RegistrarInteraccion(cliente2.Id, cotizacion);
            vendedores[1].ConvertirCotizacionAVenta(cliente2.Id, cotizacion.Id, "b");
            Console.WriteLine(cliente2.MostrarInfo());


            cotizacion = new Cotizacion(cliente3.Id, DateTime.Now, "c", 100);
            vendedores[2].RegistrarInteraccion(cliente3.Id, cotizacion);
            vendedores[2].ConvertirCotizacionAVenta(cliente3.Id, cotizacion.Id, "c");

            cotizacion = new Cotizacion(cliente4.Id, DateTime.Now, "d", 100);
            vendedores[3].RegistrarInteraccion(cliente4.Id, cotizacion);
            vendedores[3].ConvertirCotizacionAVenta(cliente4.Id, cotizacion.Id, "d");

            cotizacion = new Cotizacion(cliente5.Id, DateTime.Now, "e", 100);
            vendedores[4].RegistrarInteraccion(cliente5.Id, cotizacion);
            vendedores[4].ConvertirCotizacionAVenta(cliente5.Id, cotizacion.Id, "a");

            cotizacion = new Cotizacion(cliente6.Id, DateTime.Now, "e", 100);
            vendedores[4].RegistrarInteraccion(cliente6.Id, cotizacion); 
            vendedores[4].ConvertirCotizacionAVenta(cliente5.Id, cotizacion.Id, "a");



            var listado = vendedores[0].mejoresVendedores(100);
            Console.WriteLine("a");

            
            Console.WriteLine(listado[vendedores[0]]);
            foreach (var item in listado)
            {
                Console.WriteLine("a");
                Console.WriteLine("vendedor: ", item.Key ,"vendió ",item.Value);
                
            }


                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n");


            var bot = new Bot();
            await bot.StartAsync();
            await Task.Delay(-1); // Mantiene el bot corriendo indefinidamente
        }
    }
}
