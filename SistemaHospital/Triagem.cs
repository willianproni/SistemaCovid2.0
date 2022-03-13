using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospital
{
    internal class Triagem
    {
        public int Pressao { get; set; }
        public int Saturacao { get; set; }
        public int BatimentoCardiaco { get; set; }
        public int DiasSintomas { get; set; }

        public Triagem(int pressao, int saturacao, int batimentoCardiaco, int diasSintomas)
        {
            Pressao = pressao;
            Saturacao = saturacao;
            BatimentoCardiaco = batimentoCardiaco;
            DiasSintomas = diasSintomas;
        }

        public override string ToString()
        {
            return $"\nPressão: {Pressao}" +
                   $"\nSaturação: {Saturacao}" +
                   $"\nBatimentos: {BatimentoCardiaco}" +
                   $"\nDias Sintomas: {DiasSintomas}";
        }
    }
}
