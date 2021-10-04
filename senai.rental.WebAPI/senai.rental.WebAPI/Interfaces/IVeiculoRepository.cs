using senai.rental.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.rental.WebAPI.Interfaces
{
    interface IVeiculoRepository
    {

        List<VeiculoDomain> ListarTodos();

        VeiculoDomain BuscarPorID(int idVeiculo);

        void Cadastrar(VeiculoDomain novoVeiculo);

        void AtualizarIdCorpo(VeiculoDomain veiculoAtualizado);

        void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculoAtualizado);

        void Deletar(int idVeiculo);

    }
}
