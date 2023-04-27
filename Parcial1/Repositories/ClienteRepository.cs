using Dapper;
using Parcial1.Models;

namespace Parcial1.Repositories
{
    public class ClienteRepository
    {
        private string _connectionString;
        private Npgsql.NpgsqlConnection connection;
        public ClienteRepository(string connectionString)
        {
            this._connectionString = connectionString;
            this.connection = new Npgsql.NpgsqlConnection(this._connectionString);
        }
        public string insertarCliente(ClienteModel cliente)
        {
            try
            {
                connection.Execute("insert into cliente(nombres, apellidos, email,documento, telefono, FechaNacimiento, idCiudad, Nacionalidad) " +
                    " values(@nombres, @apellidos, @email, @documento, @telefono,@FechaNacimiento, @idCiudad, @nacionalidad)", cliente);
                return "Se inserto correctamente...";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string modificarCliente(ClienteModel cliente, int id)
        {
            try
            {
                connection.Execute($"UPDATE cliente SET " +
                    "nombres = @nombres, " +
                    "apellidos = @apellidos, " +
                    "email = @email, " +
                    "documento = @documento, " +
                    "telefono = @telefono, " +
                    "fechaNacimiento = @fechaNacimiento, " +
                    "idciudad = @idCiudad, " +
                    "nacionalidad = @nacionalidad " +
                    $"WHERE id = {id}", cliente);
                return "Se modificaron los datos correctamente...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string eliminarCliente(int id)
        {
            try
            {
                connection.Execute($" DELETE FROM cliente WHERE id = {id}");
                return "Se eliminó correctamente el registro...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ClienteModel consultarCliente(int id)
        {
            try
            {
                return connection.QueryFirst<ClienteModel>($"SELECT c.id as id, c.nombres, c.apellidos, c.documento, c.telefono, c.email, c.fechanacimiento, c.nacionalidad, c.idciudad, ci.ciudad FROM cliente as c, ciudad as ci WHERE ci.id = c.idciudad and c.id = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ClienteModel> listarCliente()
        {
            try
            {
                return connection.Query<ClienteModel>($"SELECT c.id as id, c.nombres, c.apellidos, c.documento, c.telefono, c.email, c.fechanacimiento, c.nacionalidad, c.idciudad, ci.ciudad FROM cliente as c, ciudad as ci WHERE ci.id = c.idciudad order by id asc");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

