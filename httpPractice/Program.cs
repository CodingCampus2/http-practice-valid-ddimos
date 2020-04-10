using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace httpPractice
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Client started");
            var Client = new Client();
            Client.Init("http://localhost:5000/somedata/");
            Client.AddHeader("appId", "campus-task");

            Console.WriteLine("cmd: get");
            await Client.GetAll(true);
            Console.WriteLine(" ");

            Data data = new Data();
            data.dataId = "sadf";
            data.weight = 5;
            Console.WriteLine($"cmd: post 'dataId': '{data.dataId}', 'weight': {data.weight}");
            await Client.Post(data);
            Console.WriteLine(" ");

            Data data2 = new Data();
            data2.dataId = "wer";
            data2.weight = 7;
            Console.WriteLine($"cmd: post 'dataId': '{data2.dataId}', 'weight': {data2.weight}");
            await Client.Post(data2);
            Console.WriteLine(" ");

            Console.WriteLine("cmd: get");
            await Client.GetAll(true);
            Console.WriteLine(" ");

            Console.WriteLine("cmd: get --id wer");
            await Client.GetOne("wer");
            Console.WriteLine(" ");

            Console.WriteLine("cmd: get --id war");
            await Client.GetOne("war");
            Console.WriteLine(" ");

            Console.WriteLine("cmd: delete wer");
            await Client.Delete("wer");
            Console.WriteLine(" ");

            Console.WriteLine("cmd: put sadf");
            Data data3 = new Data();
            data3.dataId = "sadf";
            data3.weight = 15;
            await Client.Put(data3, "sadf");
            Console.WriteLine(" ");

            Console.WriteLine("cmd: get");
            await Client.GetAll(true);
            Console.WriteLine(" ");

        }
    }

}
