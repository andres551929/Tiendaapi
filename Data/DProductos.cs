using Microsoft.Data.SqlClient;
using System.Data;
using Tiendaapi.Conexion;
using Tiendaapi.Models;

namespace Tiendaapi.Data
{
    public class DProductos
    {

        Conexionbd cn = new Conexionbd();
        public async Task<List<MProductos>> MostrarProductos()
        {
            var lista = new List<MProductos>();
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarProductos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproductos = new MProductos();
                            mproductos.descripcion = (string)item["descripcion"];
                            mproductos.precio = (decimal)item["precio"];
                            mproductos.id = (int)item["id"];
                            lista.Add(mproductos);
                        }
                    }
                }
                return lista;
            }
        }

        public async Task InsertarProductos(MProductos parametros)
        {
            using(var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", parametros.descripcion);
                    cmd.Parameters.AddWithValue("@precio", parametros.precio);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EditarProductos(MProductos parametros)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", parametros.descripcion);
                    cmd.Parameters.AddWithValue("@precio", parametros.precio);
                    cmd.Parameters.AddWithValue("@id", parametros.id);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarProductos(int id)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;          
                    cmd.Parameters.AddWithValue("@id", id);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
