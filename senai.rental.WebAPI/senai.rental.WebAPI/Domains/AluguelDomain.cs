using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.rental.WebAPI.Domains
{
    public class AluguelDomain
    {

        public int idAluguel { get; set; }

        public ClienteDomain cliente { get; set; }

        public VeiculoDomain veiculo { get; set; }

        public double preco { get; set; }

        public DateTime Adata { get; set; }

    }
}
