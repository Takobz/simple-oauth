using SimpleAuthServer.Data.Repositories;

namespace SimpleAuthServer.Services.Orchestrator
{
    public interface IRegistrationOrchestrator
    {
        //return create client response DTO for the Handler or Result so the handler can decide which HTTP response to give.
    }

    public class RegistrationOrchestrator(IClientRepo clientRepo) : IRegistrationOrchestrator
    {
        private readonly IClientRepo _clientRepo = clientRepo ?? throw new ArgumentNullException(nameof(clientRepo));

    }
}