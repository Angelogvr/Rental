using senai.rental.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.rental.WebAPI.Interfaces
{
    interface IAluguelRepository
    {

        List<AluguelDomain> ListarTodos();

        AluguelDomain BuscarPorID(int idAluguel);

        void Cadastrar(AluguelDomain novoAluguel);

        void AtualizarIdCorpo(AluguelDomain aluguelAtualizado);

        void AtualizarIdUrl(int idAluguel, AluguelDomain aluguelAtualizado);

        void Deletar(int idAluguel);


    }
}
