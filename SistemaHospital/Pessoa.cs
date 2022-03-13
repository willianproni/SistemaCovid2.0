using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospital
{
    internal class Pessoa
    {
        public string Nome { get; set; }
        public float CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public int Idade => DateTime.Now.Year - DataNascimento.Year;

        List<Pessoa> preferencial = new List<Pessoa>();
        List<Pessoa> normal = new List<Pessoa>();
        int cont = 0;

        public string InformacoesPessoa()
        {
            return $"---------------------" +
                   $"\nNome: {Nome}" +
                   $"\nCpf: {CPF}" +
                   $"\nIdade: {Idade}" +
                   $"\nSexo = {Sexo}" +
                   $"\n---------------------";
        }
        public Pessoa(string nome, float cpf, DateTime dataNascimento, char sexo)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            Sexo = sexo;
        }
        public Pessoa()
        {
        }

        public void CadastrarPessoaRecepcao()
        {
            string cpff;
            float cpf;
            DateTime dataNascimento;
            string dNascimento;

            Console.Clear();
            Console.WriteLine("--------- Cadastro de pessoa ---------\n");
            Console.Write("Digite o Nome da Pessoa: ");
            string nome = Console.ReadLine();
            do
            {
                Console.Write("Digite o CPF da Pessoa: ");
                cpff = Console.ReadLine();
                if (!float.TryParse(cpff, out cpf))
                {
                    Console.WriteLine("\tCpf Inválido Digite Novamento!\n");
                }
            } while (!float.TryParse(cpff, out cpf));
            do
            {
                Console.Write("Digite a data de Nascimento da pessoa: ");
                dNascimento = Console.ReadLine();
                if (!DateTime.TryParse(dNascimento, out dataNascimento))
                {
                    Console.WriteLine("\tData Digitada Incorreta!\n");
                }
            } while (!DateTime.TryParse(dNascimento, out dataNascimento));
            Console.WriteLine("Digite o Sexo\n[1] - Masculino\n[2] - Feminino");
            Console.Write("Opção: ");
            char sexo = char.Parse(Console.ReadLine());
            VerificaFilaPessoa(new Pessoa(nome, cpf, dataNascimento, sexo));
        }
        public void VerificaFilaPessoa(Pessoa paciente)
        {
            if (paciente.Idade >= 60)
            {
                Console.WriteLine("\n\t--->> Fila Prioritária <<----");
                preferencial.Add(paciente);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\t--->> Fila Normal <<----");
                normal.Add(paciente);
                Console.ReadKey();
            }
        }
        public void ExibirPessoasFilaPrioritaria()
        {
            Console.Clear();
            preferencial.ForEach(paciente => Console.WriteLine(paciente.InformacoesPessoa()));
            Console.ReadKey();
        }
        public void ExibirPessoasFilaNormal()
        {
            Console.Clear();
            normal.ForEach(paciente => Console.WriteLine(paciente.InformacoesPessoa()));
            Console.ReadKey();
        }

        public void chamarTriagem()
        {
            Pessoa paciente;
            if (cont < 2)
            {
                Console.WriteLine(preferencial[0].InformacoesPessoa());
                paciente = preferencial[0];
                preferencial.Remove(preferencial[0]);
                InformacoesTriagem(paciente);
            }
            else
            {
                Console.WriteLine(normal[0].InformacoesPessoa());
                paciente = normal[0];
                InformacoesTriagem(paciente);
                cont = 0;
            }
            
        }

        public void InformacoesTriagem(Pessoa paciente)
        {
            Console.Write("Informe os Batimentos cardíacos: ");
            int batimentos = int.Parse(Console.ReadLine());
            Console.Write("Informe a Saturação: ");
            int saturacao = int.Parse(Console.ReadLine());


        }
    }
}
