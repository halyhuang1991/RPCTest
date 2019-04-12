using System.Threading.Tasks;
using Grpc.Core;

namespace RPCTest.server
{
    public class MathServiceImpl:MathService.MathServiceBase
    {
        public override Task<AddReply> Add(AddRequest request, ServerCallContext context)
        {
            return Task.FromResult(new AddReply { Sum = request.First + request.Second });
        }

        public override Task<MultiplyReply> Multiply(MultiplyRequest request, ServerCallContext context)
        {
            return Task.FromResult(new MultiplyReply { Result = request.First * request.Second });
        }
    }
}