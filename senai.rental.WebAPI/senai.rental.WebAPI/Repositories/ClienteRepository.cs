using senai.rental.WebAPI.Domains;
using senai.rental.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.rental.WebAPI.Repositorys
{
    public class ClienteRepository : IClienteRepository
    {

        private string stringConexao = @"Data Source=LAPTOP-BSMJ3RKB\SQLEXPRESS; initial catalog=A_RENTAL; user Id=sa; pwd=senai@132";


        public void AtualizarIdCorpo(ClienteDomain clienteAtualizado)
        {
            if (clienteAtualizado.nomeCliente != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE CLIENTE SET nomeCliente = @novoNomeCliente, sobrenome = @novoSobrenomeCliente, RG = @novoRGCliente WHERE idCliente = @idClienteAtualizado";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@NovoNomeCliente", clienteAtualizado.nomeCliente);
                        cmd.Parameters.AddWithValue("@novoSobrenomeCliente", clienteAtualizado.sobrenome);
                        cmd.Parameters.AddWithValue("@novoRGCliente", clienteAtualizado.RG);
                        cmd.Parameters.AddWithValue("@idClienteAtualizado", clienteAtualizado.idCliente);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AtualizarIdUrl(int idCliente, ClienteDomain clienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE CLIENTE SET nomeCliente = @novoNomeCliente, sobrenome = @novoSobrenomeCliente, RG = @novoRGCliente WHERE idCliente = @idClienteAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeCliente", clienteAtualizado.nomeCliente);
                    cmd.Parameters.AddWithValue("@novoSobrenomeCliente", clienteAtualizado.sobrenome);
                    cmd.Parameters.AddWithValue("@novoRGCliente", clienteAtualizado.RG);
                    cmd.Parameters.AddWithValue("@idClienteAtualizado", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorID(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idCliente, nomeCliente, sobrenome, RG FROM CLIENTE WHERE idCliente = @idCliente";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClienteDomain clienteBuscado = new ClienteDomain
                        {
                            idCliente = Convert.ToInt32(reader["idCliente"]),
                            nomeCliente = reader["nomeCliente"].ToString(),
                            sobrenome = reader["sobrenome"].ToString(),
                            RG = reader["RG"].ToString()
                        };
                        return clienteBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO CLIENTE (nomeCliente, sobrenome, RG) VALUES (@nomeCliente, @sobrenome, @RG)";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenome", novoCliente.sobrenome);
                    cmd.Parameters.AddWithValue("@RG", novoCliente.RG);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM CLIENTE WHERE idCliente = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> ListaClientes = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idCliente, nomeCliente, sobrenome, RG FROM CLIENTE";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ClienteDomain Cliente = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(rdr[0]),
                            nomeCliente = rdr[1].ToString(),
                            sobrenome = rdr[2].ToString(),
                            RG = rdr[3].ToString()
                        };
                        ListaClientes.Add(Cliente);
                    }
                }
            }
            return ListaClientes;
        }
    }
}
