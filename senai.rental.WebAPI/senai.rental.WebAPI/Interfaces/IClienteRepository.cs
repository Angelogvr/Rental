using senai.rental.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.rental.WebAPI.Interfaces
{
    interface IClienteRepository
    {

        List<ClienteDomain> ListarTodos();

        ClienteDomain BuscarPorID(int idCliente);

        void Cadastrar(ClienteDomain novoCliente);

        void AtualizarIdCorpo(ClienteDomain clienteAtualizado);

        void AtualizarIdUrl(int idCliente, ClienteDomain clienteAtualizado);

        void Deletar(int idCliente);

    }
}
