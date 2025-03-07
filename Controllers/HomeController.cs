using Microsoft.AspNetCore.Mvc;
using variables.Models;
using variables.Services;

namespace variables.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClienteService _clienteService;

        public HomeController()
        {
            _clienteService = new ClienteService();
        }

        public IActionResult Index()
        {
            var listaClientes = _clienteService.ObtenerTodos();
            return View(listaClientes);
        }

        public IActionResult Privacy(int? id)
        {
            ClienteModel cliente = id.HasValue
                ? _clienteService.ObtenerPorId(id.Value)
                : new ClienteModel();

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Guardar(ClienteModel cliente)
        {
            if (cliente.Id == 0)
            {
                _clienteService.AgregarCliente(cliente);
            }
            else
            {
                _clienteService.ActualizarCliente(cliente);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            _clienteService.EliminarCliente(id);
            return RedirectToAction("Index");
        }
    }
}
