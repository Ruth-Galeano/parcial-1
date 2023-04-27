using Parcial1.Models;
using Parcial1.Repositories;

namespace Parcial1.Services
{
    public class ClienteService
    {
        private ClienteRepository clienteRepository;

        public ClienteService(string connectionString)
        {
            this.clienteRepository = new ClienteRepository(connectionString);
        }
       
        public string insertarCliente(ClienteModel cliente)
        {
            return validarDatosCliente(cliente) ? clienteRepository.insertarCliente(cliente) : throw new Exception("Error en la validacion");
        }

        public string modificarCliente(ClienteModel cliente, int id)
        {
            if (clienteRepository.consultarCliente(id) != null)
                return validarDatosCliente(cliente) ?
                  clienteRepository.modificarCliente(cliente, id) :
                    throw new Exception("Error en la validacion");
            else
                return "No se encontraron los datos de este cliente";
        }

        public string eliminarCliente(int id)
        {
            return clienteRepository.eliminarCliente(id);
        }

        public ClienteModel consultarCliente(int id)
        {
            return clienteRepository.consultarCliente(id);
        }

        public IEnumerable<ClienteModel> listarCliente()
        {
            return clienteRepository.listarCliente();
        }

        private bool validarDatosCliente(ClienteModel cliente)
        {
            //if (persona.Nombre.Trim().Length < 2)
            //{
            //    return false;
            //}

            return true;
        }
    }
}

