using System;
using System.Net;
using System.Text;
using System.Threading;

namespace ConsoleClient
{
    class Program
    {
        static int _value = 1;
        static string _apiBaseAddress = "https://localhost:44333";

        static void Main(string[] args)
        {
            while(true)
            {
                ShowMenu();
                var input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch(input)
                {
                    case '1':
                        GetRequest();
                        break;
                    case '2':
                        PostData();
                        break;
                    case 'q':
                    case 'Q':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        Thread.Sleep(2000);
                        break;
                };
            }
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine(Environment.NewLine + "  Menu" + Environment.NewLine);
            Console.WriteLine("  1) List Foos");
            Console.WriteLine("  2) Create a Foo");
            Console.WriteLine("  Q) Exit" + Environment.NewLine);
            Console.Write("Enter choice: ");
        }

        private static void PostData()
        {
            var client = CreateWebClient(_apiBaseAddress);

            var json = $@"{{""One"": {_value++}, ""Two"": {_value++}, ""Three"": {_value++}}}";
            var data = Encoding.UTF8.GetBytes(json);

            var response = client.UploadData("/api/Foo", data);
            Console.WriteLine("A new Foo was created:");
            Console.WriteLine(Encoding.UTF8.GetString(response));

            Console.WriteLine("Perss Enter to continue");
            Console.ReadLine();
        }

        private static void GetRequest()
        {
            var client = CreateWebClient(_apiBaseAddress);

            var response = client.DownloadString("/api/Foo");
            Console.WriteLine("Foos currently available:");
            Console.WriteLine(response);

            Console.WriteLine("Perss Enter to continue");
            Console.ReadLine();
        }

        private static WebClient CreateWebClient(string baseAddress)
        {
            var client = new WebClient
            {
                Encoding = Encoding.UTF8,
                BaseAddress = baseAddress
            };

            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.Headers.Add(HttpRequestHeader.Accept, "application/json");

            return client;
        }
    }
}
