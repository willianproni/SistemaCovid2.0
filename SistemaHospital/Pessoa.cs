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
        public string Sexo { get; set; }
        public int Idade => DateTime.Now.Year - DataNascimento.Year;
        public Triagem Triagem { get; set; }

        public Pessoa Paciente { get; set; }

        List<Pessoa> preferencial = new List<Pessoa>();
        List<Pessoa> normal = new List<Pessoa>();
        List<Pessoa> Internados = new List<Pessoa>();
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

        public string InformacoesInternados()
        {
            return $"---------------------" +
                   $"\nNome: {Paciente.Nome}" +
                   $"\nCpf: {Paciente.CPF}" +
                   $"\nIdade: {Paciente.Idade}" +
                   $"\nSexo = {Paciente.Sexo}" +
                   $"\n{Triagem.ToString()}" +
                   $"\n---------------------";
        }
        public Pessoa(string nome, float cpf, DateTime dataNascimento, string sexo)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            Sexo = sexo;
        }

        public Pessoa(Pessoa paciente, Triagem triagem)
        {
            Paciente = paciente;
            Triagem = triagem;
        }

        public Pessoa()
        {
        }
        public bool FilaVaziaPreferencial()
        {
            if (preferencial.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool FilaVaziaNormal()
        {
            if (normal.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            Console.WriteLine("Digite o Sexo\n[M] - Masculino\n[F] - Feminino");
            Console.Write("Opção: ");
            string sexo = Console.ReadLine().ToUpper();
            if (sexo == "M")
            {
                sexo = "Masculino";
            }
            else
            {
                sexo = "Femininno";
            }
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
            Console.WriteLine("---- Fila Preferencial ----");
            if (FilaVaziaPreferencial())
            {
                Console.WriteLine("\n\tFila Vazia");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                preferencial.ForEach(paciente => Console.WriteLine(paciente.InformacoesPessoa()));
                Console.ReadKey();
            }
        }
        public void ExibirPessoasFilaNormal()
        {
            Console.Clear();
            Console.WriteLine("---- Fila Normal ----");
            if (FilaVaziaNormal())
            {

                Console.WriteLine("\n\tFila Vazia");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                normal.ForEach(paciente => Console.WriteLine(paciente.InformacoesPessoa()));
                Console.ReadKey();
            }
        }
        public void ExibirPessoasInternadas()
        {
            Console.Clear();
            Internados.ForEach(paciente => Console.WriteLine(paciente.InformacoesInternados()));
            Console.ReadKey();
        }
        public void chamarTriagem()
        {
            Pessoa paciente;
            if (FilaVaziaNormal() && FilaVaziaPreferencial())
            {
                Console.WriteLine("Nenhum Paciente para ser atendido");
            }
            else if (FilaVaziaPreferencial())
            {
                Console.WriteLine(normal[0].InformacoesPessoa());
                paciente = normal[0];
                normal.Remove(normal[0]);
                InformacoesTriagem(paciente);
                cont = 0;
            }
            else
            {
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
                    normal.Remove(normal[0]);
                    InformacoesTriagem(paciente);
                }
            }
        }
        public void InformacoesTriagem(Pessoa paciente)
        {
            int batimentos;
            string batimentosconf;
            int saturacao;
            string saturacaoconf;
            int pressao;
            string pressaoconf;
            int diasSintomas;
            string diasSintomasconf;
            do
            {
                Console.Write("Informe os Batimentos cardíacos: ");
                batimentosconf = Console.ReadLine();
                if (!int.TryParse(batimentosconf, out batimentos))
                {
                    Console.WriteLine("\tBatimesntos Digitado de forma Incorreta!!\n");
                }
            } while (!int.TryParse(batimentosconf, out batimentos));
            do
            {
                Console.Write("Informe a Saturação: ");
                saturacaoconf = Console.ReadLine();
                if (!int.TryParse(saturacaoconf, out saturacao))
                {
                    Console.WriteLine("\tSaturação Digitada de forma Incorreta!!\n");
                }
            } while (!int.TryParse(saturacaoconf, out saturacao));
            do
            {
                Console.Write("Digite a Pressão:");
                pressaoconf = Console.ReadLine();
                if (!int.TryParse(pressaoconf, out pressao))
                {
                    Console.WriteLine("\tPressão Digitada de forma Incorreta!!\n");
                }
            } while (!int.TryParse(pressaoconf, out pressao));
            do
            {
                Console.Write("Dias sintomas: ");
                diasSintomasconf = Console.ReadLine();
                if (!int.TryParse(diasSintomasconf, out diasSintomas))
                {
                    Console.WriteLine("\tDias digitado de forma Incorreta!!\n");
                }
            } while (!int.TryParse(diasSintomasconf, out diasSintomas));

            if (diasSintomas < 3)
            {
                Console.Clear();
                Console.WriteLine("------------------- Retorno -------------------");
                Console.WriteLine("\nRetornar quando Passar de 3 dias de sintomas!!");
            }
            else
            {
                Console.Write("\n\tPaciente Vai Realizar teste de Covid? (S/N): ");
                string testeconf = Console.ReadLine().ToUpper();
                if (testeconf == "S" || testeconf == "SIM")
                {
                    Console.Write("\n\tResultado Positivo (S/N): ");
                    string resultadocovid = Console.ReadLine().ToUpper();
                    if (resultadocovid == "S" || resultadocovid == "SIM")
                    {
                        Console.Write("\n\tPaciente Vai ser Internado? (S/N): ");
                        string internar = Console.ReadLine().ToUpper();
                        if (internar == "S" || internar == "SIM")
                        {
                            Console.WriteLine("\n\tPaciente Internado!!");
                            Internados.Add(new Pessoa(paciente, new Triagem(batimentos, saturacao, pressao, diasSintomas)));
                        }
                        else
                        {
                            Console.WriteLine($"\tPaciente vai cumprir quarentena em casa até de 15 dias");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\tDispensando Teste de Covid Negativo!!");
                    }
                }
                else
                {
                    Console.WriteLine("\tDispensando Sem suspeita de Covid!!");
                }
            }
        }
    }
}
