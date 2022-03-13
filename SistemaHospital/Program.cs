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
                            case "0":
                                break;
                            default:
                                Console.WriteLine("Opção Inválida");
                                break;
                        }
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
            } while (opc != "0");

        }

        public static void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("----- Menu Principal -----" +
                              "\n[1] - Cadastrar Pessoa" +
                              "\n[2] - Realizar Triagem" +
                              "\n[3] - Verificar Filas" +
                              "\n[0] - Sair do sistema" +
                              "\n-------------------------");
            Console.Write("Opção: ");
        }
        public static void MenuFilas()
        {
            Console.Clear();
            Console.WriteLine("----- Explorar Filas -----" +
                              "\n[1] - Fila Prioritário" +
                              "\n[2] - Fila Normal" +
                              "\n[0] - Voltar pro Menu Principal" +
                              "\n--------------------------");
            Console.Write("Opção: ");
        }
        public static void ExibirFilaPrioridade()
        {

        }
    }
}
