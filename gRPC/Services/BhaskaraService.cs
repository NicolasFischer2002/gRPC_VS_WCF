using gRPC.Protos;
using Grpc.Core;

namespace gRPC.Services
{
    public class BhaskaraService : Protos.Bhaskara.BhaskaraBase
    {
        private readonly ILogger<BhaskaraService> _logger;

        public BhaskaraService(ILogger<BhaskaraService> logger)
        {
            _logger = logger;
        }

        public override async Task<BhaskaraReply> Resolver(BhaskaraRequest request, ServerCallContext context)
        {
            try
            {
                await SimularLicenciamento();

                Entities.Bhaskara bhaskara = new Entities.Bhaskara(request.A, request.B, request.C);
                double[] raizes = bhaskara.Resolver();

                BhaskaraReply reply = new BhaskaraReply
                {
                    ResolvidoComSucesso = true,
                    MensagemErro = string.Empty
                };

                reply.Resolucao.AddRange(raizes);
                return reply;
            }
            catch (Exception error)
            {
                BhaskaraReply errorReply = new BhaskaraReply
                {
                    ResolvidoComSucesso = false,
                    MensagemErro = error.Message
                };

                errorReply.Resolucao.AddRange([]);
                return errorReply;
            }
        }

        private async Task SimularLicenciamento()
        {
            await Task.Delay(10);
        }
    }
}