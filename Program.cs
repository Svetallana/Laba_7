using Newtonsoft.Json.Linq;
using System;

namespace KM_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"(Програма працює з лiтерами англiйського алфавiту)" +
                $"\nДля отримання додаткових даних потрiбно ввести назву країни, пiсля чого натиснути Enter");

            var country = "";
            Console.Write("\t> ");
            country = Console.ReadLine();

            if (country == "russia")
            {
                Console.WriteLine("\nКраїна - терорист! За новими даними скоро уся країна точно по кордону пiде пiд воду разом iз всiма тварями, якi у нiй проживають. На планетi Земля нiколи бiльше не буде вiйн i небо завжди буде мирне)");
            }
            else
            {
                var request = new Getting($"https://restcountries.com/v3.1/name/{country}");
                request.Run();

                var response = request.Responce;

                if (response != null)
                {
                    Console.WriteLine("\nResult:\n");
                    JArray j_arr = JArray.Parse(response);
                    JObject j_obj = j_arr[0].ToObject<JObject>();
                    string country_name = j_obj["name"]["official"].ToString();
                    string country_capital = j_obj["capital"][0].ToString();
                    string country_region = j_obj["region"].ToString();
                    Console.WriteLine($" Country: {country_name}");
                    Console.WriteLine($" The capital of the country: {country_capital}");
                    Console.WriteLine($" Location region: {country_region}");
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine("Помилка при введеннi! Переверте, будь ласка, назву країни)");
                }
            }
        }
    }
}