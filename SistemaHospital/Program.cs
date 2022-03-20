using System;
using System.Collections.Generic;

namespace SistemaHospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opc, opcfila;
            Pessoa pessoa = new Pessoa();
            //Arquivo arquivo = new Arquivo();
            do
            {
                MenuPrincipal();
                opc = Console.ReadLine();

                switch (opc)
                {
                    case "1":
                        pessoa.CadastrarPessoaRecepcao();
                        break;
                    case "2":
                        pessoa.chamarTriagem();
                        Console.ReadKey();
                        break;
                    case "3":
                        pessoa.RealizarAltaPaciente();
                        break;
                    case "4":
                        do
                        {
                            MenuFilas();
                            opcfila = Console.ReadLine();
                            switch (opcfila)
                            {
                                case "1":
                                    pessoa.ExibirPessoasFilaPrioritaria();
                                    break;
                                case "2":
                                    pessoa.ExibirPessoasFilaNormal();
                                    break;
                                case "3":
                                    pessoa.ExibirPessoasInternadas();
                                    break;
                                case "0":
                                    break;
                                default:
                                    Console.WriteLine("\n\t\t\tOpção Inválida");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (opcfila != "0");
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("\n\t\t\tOpção Inválida");
                        Console.ReadKey();
                        break;
                }
            } while (opc != "0");
        }

        public static void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t----- Menu Principal -----" +
                              "\n\t\t\t[1] - Cadastrar Pessoa" +
                              "\n\t\t\t[2] - Realizar Triagem" +
                              "\n\t\t\t[3] - Realizar Alta Paciente" +
                              "\n\t\t\t[4] - Verificar Filas" +
                              "\n\t\t\t[0] - Sair do sistema" +
                              "\n\t\t\t-------------------------");
            Console.Write("\t\t\tOpção: ");
        }
        public static void MenuFilas()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t----- Explorar Filas -----" +
                              "\n\t\t\t[1] - Fila Prioritário" +
                              "\n\t\t\t[2] - Fila Normal" +
                              "\n\t\t\t[3] - Lista Internados" +
                              "\n\t\t\t[0] - Voltar ao Menu Principal" +
                              "\n\t\t\t--------------------------");
            Console.Write("\t\t\tOpção: ");
        }

    }
}
