using gRPC.Protos;
using Grpc.Core;

namespace gRPC.Services
{
    public class BhaskaraService : Bhaskara.BhaskaraBase
    {
        private readonly ILogger<BhaskaraService> _logger;

        public BhaskaraService(ILogger<BhaskaraService> logger)
        {
            _logger = logger;
        }

        public override async Task<BhaskaraReply> Resolver(BhaskaraRequest request, ServerCallContext context)
        {
            await SimularLicenciamento();

            var reply = new BhaskaraReply
            {
                ResolvidoComSucesso = true,
                MensagemErro = string.Empty
            };

            reply.Resolucao.Add(1);
            return reply;
        }

        private async Task SimularLicenciamento()
        {
            await Task.Delay(10);
        }
    }
}