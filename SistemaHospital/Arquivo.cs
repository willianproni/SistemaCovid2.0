using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SistemaHospital
{
    internal class Arquivo
    {
        public List<Pessoa> filanormal { get; set; }
        public List<Pessoa> filaprioritaria { get; set; }

        public Arquivo()
        {
            filanormal = new List<Pessoa>();
            filaprioritaria = new List<Pessoa>();

            try
            {
                StreamReader sr;
                string line;

                if (!Directory.Exists("C:\\5by5\\HospitalCovid\\"))
                {
                    Directory.CreateDirectory("C:\\5by5\\HospitalCovid\\");
                }

                if (File.Exists("C:\\5by5\\HospitalCovid\\Filanormal.txt"))
                {
                    sr = new StreamReader("C:\\5by5\\HospitalCovid\\Filanormal.txt");
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        string nome = line.Substring(0, 50).Trim();
                        float cpf = float.Parse(line.Substring(50, 11));
                        DateTime datanasc = DateTime.Parse(line.Substring(61, 10));
                        string sexo = line.Substring(72, 10);
                        filanormal.Add(new Pessoa(nome, cpf, datanasc, sexo));
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Console.WriteLine("Carregado com sucesso");
            }
        }



        public Arquivo(Pessoa fnormal)
        {
            if (fnormal != null)
            {
                if (fnormal.Idade < 60)
                {


                    try
                    {
                        StreamWriter sw = new StreamWriter("C:\\5by5\\HospitalCovid\\Filanormal.txt", append: true);
                        sw.WriteLine(fnormal.ArquivoPaciente());
                        sw.Close();
                        Console.WriteLine("Paciente na adicionado na Fila Normal!!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Execption" + e.Message);
                    }
                }
                else
                {
                    try
                    {
                        StreamWriter sw = new StreamWriter("C:\\5by5\\HospitalCovid\\Filaprioritaria.txt", append: true);
                        sw.WriteLine(fnormal.ArquivoPaciente());
                        sw.Close();
                        Console.WriteLine("Paciente na adicionado na Fila Prioritária!!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Excetion" + e.Message);
                    }
                }
            }
        }
    }
}
