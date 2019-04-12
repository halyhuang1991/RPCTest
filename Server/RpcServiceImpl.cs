using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using Grpc.Core;
namespace RPCTest.server
{
    public class RpcStreamingServiceImpl : RpcStreamingService.RpcStreamingServiceBase
    {
        public override Task GetStreamContent(StreamRequest request, IServerStreamWriter<StreamContent> response, ServerCallContext context)
        {
            return Task.Run(async () =>
            {
                using (var fs = File.Open(request.FileName, FileMode.Open))
                // 从 request 中读取文件名并打开文件流 
                {
                    int count=1024*1024;
                    var remainingLength = fs.Length; // 剩余长度 
                    var buff = new byte[count]; // 缓冲区，这里我们设置为 1 Mb 
                    while (remainingLength > 0) // 若未读完则继续读取 
                    {
                        var len = await fs.ReadAsync(buff,0,count,CancellationToken.None); // 异步从文件中读取数据到缓冲区中 
                        remainingLength -= len; // 剩余长度减去刚才实际读取的长度 // 向流中写入我们刚刚读取的数据 
                        await response.WriteAsync(new StreamContent { Content = ByteString.CopyFrom(buff, 0, len) });
                    }
                }
            });
        }
        
          
    }

}