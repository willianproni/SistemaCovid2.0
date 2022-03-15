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
        List<Pessoa> internados = new List<Pessoa>();
        List<Pessoa> todosPacientes = new List<Pessoa>();
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

        public string IformacoesTriagem()
        {
            Console.Clear();
            return $"\t\t---------- Triagem -----------\n" +
                   $"\n\t\tNome: {Nome}" +
                   $"\n\t\tCpf: {CPF}" +
                   $"\n\t\tIdade: {Idade}" +
                   $"\n\t\tSexo = {Sexo}";
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
        public bool FilaVaziaInternada()
        {
            if (internados.Count == 0)
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
            Console.WriteLine("\t--------- Cadastro de pessoa ---------\n");
            Console.Write("\tDigite o Nome da Pessoa: ");
            string nome = Console.ReadLine();
            do
            {
                Console.Write("\tDigite o CPF da Pessoa: ");
                cpff = Console.ReadLine();
                if (!float.TryParse(cpff, out cpf))
                {
                    Console.WriteLine("\tCpf Inválido Digite Novamento!\n");
                }
            } while (!float.TryParse(cpff, out cpf));
            do
            {
                Console.Write("\tDigite a data de Nascimento da pessoa (dd/mm/aaaa): ");
                dNascimento = Console.ReadLine();
                if (!DateTime.TryParse(dNascimento, out dataNascimento))
                {
                    Console.WriteLine("\tData Digitada Incorreta!\n");
                }
            } while (!DateTime.TryParse(dNascimento, out dataNascimento));
            Console.WriteLine("\tDigite o Sexo\n\t[M] - Masculino\n\t[F] - Feminino");
            Console.Write("\tOpção: ");
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
            }
            else
            {
                Console.WriteLine("\n\t--->> Fila Normal <<----");
                normal.Add(paciente);
            }
            Console.ReadKey();
        }
        public void ExibirPessoasFilaPrioritaria()
        {
            Console.Clear();
            Console.WriteLine("\t-------- Fila Preferencial --------");
            if (FilaVaziaPreferencial())
            {
                Console.WriteLine("\n\tFila Vazia");
                Console.ReadKey();
            }
            else
            {
                preferencial.ForEach(paciente => Console.WriteLine(paciente.InformacoesPessoa()));
                Console.ReadKey();
            }
        }
        public void ExibirPessoasFilaNormal()
        {
            Console.Clear();
            Console.WriteLine("\t -------- Fila Normal --------");
            if (FilaVaziaNormal())
            {
                Console.WriteLine("\n\tFila Vazia");
            }
            else
            {
                Console.Clear();
                normal.ForEach(paciente => Console.WriteLine(paciente.InformacoesPessoa()));
            }
            Console.ReadKey();
        }
        public void ExibirPessoasInternadas()
        {
            Console.Clear();
            Console.WriteLine("\t-------- Fila Internados --------");
            if (FilaVaziaInternada())
            {
                Console.WriteLine("\n\tFila Vazia");
            }
            else
            {
                internados.ForEach(paciente => Console.WriteLine(paciente.InformacoesInternados()));
                Console.ReadKey();
            }
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
                Console.WriteLine(normal[0].IformacoesTriagem());
                paciente = normal[0];
                normal.Remove(normal[0]);
                InformacoesTriagem(paciente);
                cont = 0;
            }
            else
            {
                if (cont < 2)
                {
                    Console.WriteLine(preferencial[0].IformacoesTriagem());
                    paciente = preferencial[0];
                    preferencial.Remove(preferencial[0]);
                    InformacoesTriagem(paciente);
                }
                else
                {
                    Console.WriteLine(normal[0].IformacoesTriagem());
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
                Console.Write("\n\t\tInforme os Batimentos cardíacos: ");
                batimentosconf = Console.ReadLine();
                if (!int.TryParse(batimentosconf, out batimentos))
                {
                    Console.WriteLine("\t\t\tBatimesntos Digitado de forma Incorreta!!\n");
                }
            } while (!int.TryParse(batimentosconf, out batimentos));
            do
            {
                Console.Write("\n\t\tInforme a Saturação: ");
                saturacaoconf = Console.ReadLine();
                if (!int.TryParse(saturacaoconf, out saturacao))
                {
                    Console.WriteLine("\t\t\tSaturação Digitada de forma Incorreta!!\n");
                }
            } while (!int.TryParse(saturacaoconf, out saturacao));
            do
            {
                Console.Write("\n\t\tDigite a Pressão:");
                pressaoconf = Console.ReadLine();
                if (!int.TryParse(pressaoconf, out pressao))
                {
                    Console.WriteLine("\t\t\tPressão Digitada de forma Incorreta!!\n");
                }
            } while (!int.TryParse(pressaoconf, out pressao));
            do
            {
                Console.Write("\n\t\tDias sintomas: ");
                diasSintomasconf = Console.ReadLine();
                if (!int.TryParse(diasSintomasconf, out diasSintomas))
                {
                    Console.WriteLine("\t\t\tDias digitado de forma Incorreta!!\n");
                }
            } while (!int.TryParse(diasSintomasconf, out diasSintomas));

            if (diasSintomas < 3)
            {
                Console.Clear();
                Console.WriteLine("\n\t\t------------------- Retorno -------------------");
                Console.WriteLine("\n\t\tRetornar quando Passar de 3 dias de sintomas!!");
            }
            else
            {
                Console.Write("\n\t\tPaciente Vai Realizar teste de Covid? (S/N): ");
                string testeconf = Console.ReadLine().ToUpper();
                if (testeconf == "S" || testeconf == "SIM")
                {
                    Console.Write("\n\t\tResultado Positivo (S/N): ");
                    string resultadocovid = Console.ReadLine().ToUpper();
                    if (resultadocovid == "S" || resultadocovid == "SIM")
                    {
                        Console.Write("\n\t\tPaciente Vai ser Internado? (S/N): ");
                        string internar = Console.ReadLine().ToUpper();
                        if (internar == "S" || internar == "SIM")
                        {
                            Console.WriteLine("\n\t\tPaciente Internado!!");
                            internados.Add(new Pessoa(paciente, new Triagem(batimentos, saturacao, pressao, diasSintomas)));
                        }
                        else
                        {
                            Console.WriteLine($"\t\tPaciente vai cumprir quarentena em casa até de 15 dias");
                            todosPacientes.Add(new Pessoa(paciente, new Triagem(batimentos, saturacao, pressao, diasSintomas)));
                        }
                    }
                    else
                    {
                        Console.WriteLine("\t\tDispensando Teste de Covid Negativo!!");
                        todosPacientes.Add(new Pessoa(paciente, new Triagem(batimentos, saturacao, pressao, diasSintomas)));
                    }
                }
                else
                {
                    Console.WriteLine("\t\tDispensando Sem suspeita de Covid!!");
                    todosPacientes.Add(new Pessoa(paciente, new Triagem(batimentos, saturacao, pressao, diasSintomas)));
                }
            }
        }
    }
}
