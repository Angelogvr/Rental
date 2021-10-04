﻿using senai.rental.WebAPI.Domains;
using senai.rental.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.rental.WebAPI.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {

        private string stringConexao = @"Data Source=LAPTOP-BSMJ3RKB\SQLEXPRESS; initial catalog=A_RENTAL; user Id=sa; pwd=senai@132";


        public void AtualizarIdCorpo(EmpresaDomain empresaAtualizada)
        {
            if (empresaAtualizada.nomeEmpresa != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE EMPRESA SET nomeEmpresa = @novoNomeEmpresa, endereco = @novoEnderecoEmpresa WHERE idEmpresa = @idEmpresaAtualizada";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@novoNomeEmpresa", empresaAtualizada.nomeEmpresa);
                        cmd.Parameters.AddWithValue("@novoEnderecoEmpresa", empresaAtualizada.endereco);
                        cmd.Parameters.AddWithValue("@idEmpresaAtualizada", empresaAtualizada.idEmpresa);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AtualizarIdUrl(int idEmpresa, EmpresaDomain empresaAtualizada)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE EMPRESA SET nomeEmpresa = @novoNomeEmpresa, endereco = @novoEnderecoEmpresa WHERE idEmpresa = @idEmpresaAtualizada";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeEmpresa", empresaAtualizada.nomeEmpresa);
                    cmd.Parameters.AddWithValue("@novoEnderecoEmpresa", empresaAtualizada.endereco);
                    cmd.Parameters.AddWithValue("@idEmpresaAtualizada", idEmpresa);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public EmpresaDomain BuscarPorID(int idEmpresa)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idEmpresa, nomeEmpresa, endereco FROM EMPRESA WHERE idEmpresa = @idEmpresa";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        EmpresaDomain empresaBuscada = new EmpresaDomain
                        {
                            idEmpresa = Convert.ToInt32(reader["idEmpresa"]),
                            nomeEmpresa = reader["nomeEmpresa"].ToString(),
                            endereco = reader["endereco"].ToString()
                        };
                        return empresaBuscada;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(EmpresaDomain novaEmpresa)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO EMPRESA (nomeEmpresa, endereco) VALUES (@nomeEmpresa, @endereco)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeEmpresa", novaEmpresa.nomeEmpresa);
                    cmd.Parameters.AddWithValue("@endereco", novaEmpresa.endereco);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idEmpresa)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM EMPRESA WHERE idEmpresa = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idEmpresa);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EmpresaDomain> ListarTodos()
        {
            List<EmpresaDomain> ListaEmpresas = new List<EmpresaDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idEmpresa, nomeEmpresa, endereco FROM EMPRESA";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EmpresaDomain empresa = new EmpresaDomain()
                        {
                            idEmpresa = Convert.ToInt32(rdr[0]),
                            nomeEmpresa = rdr[1].ToString(),
                            endereco = rdr[2].ToString()
                        };
                        ListaEmpresas.Add(empresa);
                    }
                }
            }
            return ListaEmpresas;
        }
    }
}