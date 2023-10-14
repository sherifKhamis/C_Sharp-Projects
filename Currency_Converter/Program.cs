
using Newtonsoft.Json;
using currencyapi;


namespace Currency_Converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            console_IO();
        }

        static void console_IO()
        {
            Console.WriteLine("Welcome to Currency Converter in C#");
            Console.WriteLine("You can choose your input currency from 4: EURO, USD, YEN and the British Pound");
            Console.Write("What do you choose ? EUR (a) USD (b) CAD (c) GBP (d) ? Choice: ");

            char iCurrency_key = Console.ReadKey().KeyChar;
            while (iCurrency_key != 'a' && iCurrency_key != 'b' && iCurrency_key != 'c' && iCurrency_key != 'd')
            {
                Console.WriteLine("\nWrong input, try again!");
                Console.Write("What do you choose ? EUR (a) USD (b) CAD (c) GBP (d) ? Choice: ");
                iCurrency_key = Console.ReadKey().KeyChar;
            }

            Console.WriteLine("\n\nYou can choose your output currency from 4: EURO, USD, YEN and the British Pound");
            Console.Write("What do you choose ? EUR (a) USD (b) CAD (c) GBP (d) ? Choice: ");

            char oCurrency_key = Console.ReadKey().KeyChar;
            while (oCurrency_key != 'a' && oCurrency_key != 'b' && oCurrency_key != 'c' && oCurrency_key != 'd')
            {
                Console.WriteLine("\nWrong input, try again!");
                Console.Write("What do you choose ? EUR (a) USD (b) CAD (c) GBP (d) ? Choice: ");
                oCurrency_key = Console.ReadKey().KeyChar;
            }

            Dictionary<char, string> letterToCurrency = new Dictionary<char ,string>()
            {
                {'a', "EUR"},
                {'b', "USD"},
                {'c', "CAD"},
                {'d', "GBP"},
            };

            Console.Write("\n\nHow much money do you want to convert ? Amount: ");
            double amount = double.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine("Your {0} {1} are {2} {3}.",amount, letterToCurrency[iCurrency_key], Math.Round(amount * currency_rate(letterToCurrency[iCurrency_key], letterToCurrency[oCurrency_key])), letterToCurrency[oCurrency_key]);
        }

        static double currency_rate(string base_currency, string target_currency)
        {
            var fx = new Currencyapi(File.ReadAllText(@"C:\Users\sheri\OneDrive\Dokumente\GitHub\C_Sharp-Projects\Currency_Converter\api_key.txt"));
            string response = fx.Latest(base_currency, target_currency);
            dynamic json = JsonConvert.DeserializeObject(response);
            return json["data"][target_currency]["value"];

        }

    }
}