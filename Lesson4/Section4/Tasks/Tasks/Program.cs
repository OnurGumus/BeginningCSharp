using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        async static Task Main(string[] args)
        {

            var t = new Thread(DoWork);
            t.Start();

            Thread.Sleep(10000);
            //never use! even not supported on .net core
            //t.Abort();


            var ts = new CancellationTokenSource();
            var token = ts.Token;

            var task = Task.Run(() => DoWork(token), token);

            ts.CancelAfter(10000);
            //will throw
            //task.Wait();
            var content = await GetContent("http://google.com");
            Console.WriteLine(content);
            Console.ReadLine();


        }


        public async static Task<string> GetContent(string url)
        {
            var httpClient = new HttpClient();
            var res = await httpClient.GetAsync(url);
            return await res.Content.ReadAsStringAsync();


        }

        public static void DoWork()
        {
            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine("From Thread:" + Thread.CurrentThread.ManagedThreadId);
            }

        }

        public static void DoWork(CancellationToken token)
        {
            while (true)
            {
                Thread.Sleep(1000);
                token.ThrowIfCancellationRequested();
                Console.WriteLine("From task:"+Thread.CurrentThread.ManagedThreadId);
            }

        }
    }
}
