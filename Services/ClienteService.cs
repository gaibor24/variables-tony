using variables.Models;
using System.Collections.Concurrent;

namespace variables.Services
{
    public class ClienteService
    {
        private static List<ClienteModel> _clientes = new List<ClienteModel>();
        private static int _idCounter = 1;
        private static readonly object _lock = new object();

        // Método para agregar un nuevo cliente
        public void AgregarCliente(ClienteModel cliente)
        {
            lock (_lock)
            {
                cliente.Id = _idCounter++;
                _clientes.Add(cliente);
            }
        }

        // Método para obtener todos los clientes
        public List<ClienteModel> ObtenerTodos()
        {
            return _clientes.ToList();
        }

        // Método para obtener un cliente por ID
        public ClienteModel ObtenerPorId(int id)
        {
            return _clientes.FirstOrDefault(c => c.Id == id);
        }

        // Método para actualizar un cliente
        public void ActualizarCliente(ClienteModel clienteActualizado)
        {
            lock (_lock)
            {
                var cliente = _clientes.FirstOrDefault(c => c.Id == clienteActualizado.Id);
                if (cliente != null)
                {
                    cliente.Nombre = clienteActualizado.Nombre;
                    cliente.Apellido = clienteActualizado.Apellido;
                    cliente.Edad = clienteActualizado.Edad;
                    cliente.Direccion = clienteActualizado.Direccion;
                    cliente.Telefono = clienteActualizado.Telefono;
                    cliente.Genero = clienteActualizado.Genero;
                    cliente.Cedula_RUC = clienteActualizado.Cedula_RUC;
                }
            }
        }

        // Método para eliminar un cliente por ID
        public void EliminarCliente(int id)
        {
            lock (_lock)
            {
                var cliente = _clientes.FirstOrDefault(c => c.Id == id);
                if (cliente != null)
                {
                    _clientes.Remove(cliente);
                }
            }
        }
    }
}
