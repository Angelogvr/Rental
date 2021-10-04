using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.rental.WebAPI.Domains
{
    public class VeiculoDomain
    {

        public int idVeiculo { get; set; }

        public EmpresaDomain empresa { get; set; }

        public string cor { get; set; }

        public string placa { get; set; }


    }
}
