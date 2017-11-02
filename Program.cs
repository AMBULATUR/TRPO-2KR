using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Zaz
{
    class InputOutput
    {
        /// <summary>
        /// Проверка каждой строки in.txt на наличие даты mm.dd.yyyy
        /// </summary>
        /// <param name="data_mass">Массив данных</param>
        /// <param name="regex">Pattern mm.dd.yyyy</param>
        /// <param name="sw">Права на доступ к управлению файлом</param>
        public void DoRegex(string[] data_mass, Regex regex, StreamWriter sw)
        {
            for (int i = 0; i < data_mass.Length; i++)
            {
                MatchCollection matches = regex.Matches(data_mass[i]);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        Console.WriteLine(match.Value + " Подходит");
                        sw.WriteLine(match.Value);
                    }
                }
                else
                {
                    Console.WriteLine(data_mass[i] + " Не подходит");
                }
            }
            sw.Close();
            Console.ReadKey();
        }
    }

    class Initialization
    {
        public StreamWriter InitOutput()
        {
            string fileName = @"out.txt";
            FileStream aFile = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamWriter sw;
            return sw = new StreamWriter(aFile);
        }
        public string[] InitInput()
        {
            string[] data_mass;
            return data_mass = File.ReadAllLines(@"in.txt", Encoding.UTF8);
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(0[1-9]|1[012]).(0[1-9]|1[0-9]|2[0-9]|3[01]).[0-9]{4}");

            Initialization UnitsInit = new Initialization();
            InputOutput obj = new InputOutput();

            string[] data_mass = UnitsInit.InitInput();
            StreamWriter sw = UnitsInit.InitOutput();

            obj.DoRegex(data_mass, regex, sw);
        }
    }
}
