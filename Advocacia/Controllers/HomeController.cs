using Advocacia.Domain.Entities;
using Advocacia.Domain.Services;
using Advocacia.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Advocacia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceCliente _service;

        public HomeController(ILogger<HomeController> logger, IServiceCliente service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Cliente cliente)
        {
            try
            {
                string documento = Regex.Replace(cliente.Documento, "[^0-9]", "");
                string telefone = Regex.Replace(cliente.Telefone, "[^0-9]", "");

                cliente.Documento = documento;
                cliente.Telefone = telefone;
                cliente.DataCadastro = DateTime.Today;


                if (Request.Form["TipoAcao"] == "Cadastrar")
                {
                    var linhasAfetadas = await _service.Criar(Guid.NewGuid(), cliente);
                    if (linhasAfetadas > 0)
                    {
                        return RedirectToAction(nameof(Cliente));
                    }


                }
                return View(cliente);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }

        public async Task<IActionResult> Cliente()
        {
            try
            {
                ListaCliente listaCliente = new ListaCliente();

                var result = await _service.BuscarTodos();

                listaCliente.Clientes = result;

                return View(listaCliente);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
          
        }

        [HttpPost]
        public async Task<IActionResult> Cliente(ListaCliente listaCliente)
        {
            
            try
            {
                string documento = listaCliente.Documento;

                if (listaCliente.Documento != null)
                {
                    documento = Regex.Replace(listaCliente.Documento, "[^0-9]", "");
                }

                var result = await _service.BuscarFiltro(listaCliente.Nome, documento);

                listaCliente.Clientes = result;

                return View(listaCliente);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }


        public async Task<IActionResult> Editar(Guid id)
        {
            
            try
            {
                Cliente cliente = new Cliente();

                if (id != Guid.Empty)
                {
                    var _cliente = await _service.BuscarPorId(id);

                    cliente = _cliente;

                }
                return View(cliente);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

      
        [HttpPost]
        public async Task<IActionResult> Editar(Cliente cliente)
        {
            try
            {
                string documento = Regex.Replace(cliente.Documento, "[^0-9]", "");
                string telefone = Regex.Replace(cliente.Telefone, "[^0-9]", "");

                cliente.Documento = documento;
                cliente.Telefone = telefone;

                if (Request.Form["TipoAcao"] == "Editar")
                {
                    var linhasAfetadas = await _service.Atualizar(cliente.Id, cliente);

                    if (linhasAfetadas > 0)
                    {
                        return RedirectToAction(nameof(Cliente));
                    }


                }
                return View(cliente);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
          
        }

        public async Task<IActionResult> Deletar(Guid id)
        {
            try
            {
                if (id != Guid.Empty)
                {
                    var result = await _service.BuscarPorId(id);
                    if (result != null)
                    {
                        return View(result);
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(Cliente cliente)
        {
            try
            {
                var linhasAfetadas = await _service.Excluir(cliente.Id);

                if (linhasAfetadas > 0)
                {
                    return RedirectToAction(nameof(Cliente));
                }

                return View();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}