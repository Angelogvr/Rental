using senai.rental.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.rental.WebAPI.Interfaces
{
    interface IEmpresaRepository
    {

        List<EmpresaDomain> ListarTodos();

        EmpresaDomain BuscarPorID(int idEmpresa);

        void Cadastrar(EmpresaDomain novaEmpresa);

        void AtualizarIdCorpo(EmpresaDomain empresaAtualizada);

        void AtualizarIdUrl(int idEmpresa, EmpresaDomain empresaAtualizada);

        void Deletar(int idEmpresa);


    }
}
