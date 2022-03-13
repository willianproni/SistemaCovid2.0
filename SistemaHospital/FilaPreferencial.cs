using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospital
{
    internal class FilaPreferencial
    {
        public  Pessoa Paciente { get; set; }

        public FilaPreferencial(Pessoa paciente)
        {
            Paciente = paciente;
        }
    }
}
