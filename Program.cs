using System;
using Google.Protobuf;
using Grpc.Core;
using RPCTest.server;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
namespace RPCTest
{
    class Program
    {
        static void Main(string[] args)
        {
            runServer();
            Task task= run();
            task.Wait();
            Console.WriteLine("Hello World!");
        }
        private static void runServer()
        {
            Server server =new Server
            {
                Services = { RpcStreamingService.BindService(new RpcStreamingServiceImpl()) }, // 绑定我们的实现 
                Ports = { new ServerPort("localhost", 23333, ServerCredentials.Insecure) }
            };
            server.Start();
            server.Ports.ToList().ForEach(a => Console.WriteLine($"RpcStreamingService Server listening on port {a.Port}..."));
            Server server1 =new Server
            {
                Services = { MathService.BindService(new MathServiceImpl()) }, // 绑定我们的实现 
                Ports = { new ServerPort("localhost", 23334, ServerCredentials.Insecure) }
            };
            server1.Start();
            server1.Ports.ToList().ForEach(a => Console.WriteLine($"MathService Server listening on port {a.Port}..."));
        }
        private static async Task run()
        {
            await runClient();
            await runClient1();
        }
        private static async Task runClient1()
        {
            var channel = new Channel("localhost:23334", ChannelCredentials.Insecure);
            var client = new MathService.MathServiceClient(channel);
            AddReply a =await client.AddAsync(new AddRequest { First = 1, Second = 2 });
            Console.WriteLine("a.Sum=" + a.Sum);
            MultiplyReply r= await client.MultiplyAsync(new MultiplyRequest{First=12,Second=444});
             Console.WriteLine("r.Multiply=" + r.Result);
        }
        private static async Task runClient()
        {
            string path=@"D:\C\halyhuang\Visual Studio 2015\Projects\webSite1\TEMP\test.txt";
            string outpath=@"C:\Users\halyhuang\Desktop\test.txt";
            var channel = new Channel("localhost:23333", ChannelCredentials.Insecure);
            // 建立到 localhost:23333 的 channel 
            var client = new RpcStreamingService.RpcStreamingServiceClient(channel); // 建立 client // 调用 RPC API 
            var result = client.GetStreamContent(new StreamRequest { FileName = path });
            var iter = result.ResponseStream; // 拿到响应流 
            using (Stream fs = new FileStream(outpath, FileMode.Create))
            // 新建一个文件流用于存放我们获取到数据 
            {
                while (await iter.MoveNext(CancellationToken.None))
                {
                    iter.Current.Content.WriteTo(fs); // 将数据写入到文件流中 
                }
            }
            // var a=await client.Add(new AddRequest{first=1,second=3});
            // Console.WriteLine(a);
            
        }
    }
}
