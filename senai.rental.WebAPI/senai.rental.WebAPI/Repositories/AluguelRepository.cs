using senai.rental.WebAPI.Domains;
using senai.rental.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.rental.WebAPI.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {

        private string stringConexao = @"Data Source=LAPTOP-BSMJ3RKB\SQLEXPRESS; initial catalog=A_RENTAL; user Id=sa; pwd=senai@132";


        public void AtualizarIdCorpo(AluguelDomain aluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE ALUGUEL SET idCliente = @novoCliente, idVeiculo = @novoVeiculo, preco = @novoPreco, Adata = @novaData WHERE idAluguel = @idAluguelAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoCliente", aluguelAtualizado.cliente.idCliente);
                    cmd.Parameters.AddWithValue("@novoVeiculo", aluguelAtualizado.veiculo.idVeiculo);
                    cmd.Parameters.AddWithValue("@novoPreco", aluguelAtualizado.preco);
                    cmd.Parameters.AddWithValue("@novaData", aluguelAtualizado.Adata);
                    cmd.Parameters.AddWithValue("@idAluguelAtualizado", aluguelAtualizado.idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int idAluguel, AluguelDomain aluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE ALUGUEL SET idCliente = @novoCliente, idVeiculo = @novoVeiculo, preco = @novoPreco, Adata = @novaData WHERE idAluguel = @idAluguelAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoCliente", aluguelAtualizado.cliente.idCliente);
                    cmd.Parameters.AddWithValue("@novoVeiculo", aluguelAtualizado.veiculo.idVeiculo);
                    cmd.Parameters.AddWithValue("@novoPreco", aluguelAtualizado.preco);
                    cmd.Parameters.AddWithValue("@novaData", aluguelAtualizado.Adata);
                    cmd.Parameters.AddWithValue("@idAluguelAtualizado", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarPorID(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idAluguel, C.idCliente, nomeCliente, sobrenome, RG, V.idVeiculo, E.idEmpresa, nomeEmpresa, endereco, cor, placa, preco, Adata FROM ALUGUEL A INNER JOIN CLIENTE C ON C.idCliente = A.idCliente INNER JOIN VEICULO V ON V.idVeiculo = A.idVeiculo INNER JOIN EMPRESA E ON V.idEmpresa = E.idEmpresa WHERE idAluguel = @idAluguel";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        AluguelDomain AluguelBuscado = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(reader["idAluguel"]),
                            cliente = new ClienteDomain
                            {
                                idCliente = Convert.ToInt32(reader["idCliente"]),
                                nomeCliente = reader["nomeCliente"].ToString(),
                                sobrenome = reader["sobrenome"].ToString(),
                                RG = reader["RG"].ToString()
                            },
                            veiculo = new VeiculoDomain
                            {
                                idVeiculo = Convert.ToInt32(reader["idVeiculo"]),
                                empresa = new EmpresaDomain
                                {
                                    idEmpresa = Convert.ToInt32(reader["idEmpresa"]),
                                    nomeEmpresa = reader["nomeEmpresa"].ToString(),
                                    endereco = reader["endereco"].ToString()
                                },
                                cor = reader["cor"].ToString(),
                                placa = reader["placa"].ToString()
                            },
                            preco = Convert.ToDouble(reader["preco"]),
                            Adata = Convert.ToDateTime(reader["Adata"])
                        };
                        return AluguelBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO ALUGUEL (idCliente, idVeiculo, preco, Adata) VALUES (@idCliente, @idVeiculo, @preco, @Adata)";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@idCliente", novoAluguel.cliente.idCliente);
                    cmd.Parameters.AddWithValue("@idVeiculo", novoAluguel.veiculo.idVeiculo);
                    cmd.Parameters.AddWithValue("@preco", novoAluguel.preco);
                    cmd.Parameters.AddWithValue("@Adata", novoAluguel.Adata);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> ListaAlugueis = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idAluguel, C.idCliente, nomeCliente, sobrenome, RG, V.idVeiculo, E.idEmpresa, nomeEmpresa, endereco, cor, placa, preco, Adata FROM ALUGUEL A INNER JOIN CLIENTE C ON C.idCliente = A.idCliente INNER JOIN VEICULO V ON V.idVeiculo = A.idVeiculo INNER JOIN EMPRESA E ON V.idEmpresa = E.idEmpresa";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AluguelDomain Aluguel = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(reader["idAluguel"]),
                            cliente = new ClienteDomain
                            {
                                idCliente = Convert.ToInt32(reader["idCliente"]),
                                nomeCliente = reader["nomeCliente"].ToString(),
                                sobrenome = reader["sobrenome"].ToString(),
                                RG = reader["RG"].ToString()
                            },
                            veiculo = new VeiculoDomain
                            {
                                idVeiculo = Convert.ToInt32(reader["idVeiculo"]),
                                empresa = new EmpresaDomain
                                {
                                    idEmpresa = Convert.ToInt32(reader["idEmpresa"]),
                                    nomeEmpresa = reader["nomeEmpresa"].ToString(),
                                    endereco = reader["endereco"].ToString()
                                },
                                cor = reader["cor"].ToString(),
                                placa = reader["placa"].ToString()
                            },
                            preco = Convert.ToDouble(reader["preco"]),
                            Adata = Convert.ToDateTime(reader["Adata"])
                        };
                        ListaAlugueis.Add(Aluguel);
                    }
                }
            }
            return ListaAlugueis;
        }
    }
}
