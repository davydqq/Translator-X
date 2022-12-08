using CQRS.Commands;
using CQRS.Queries;
using Microsoft.Extensions.Logging;
using TB.Core.Queries;
using TB.User;

namespace TB.Audios.Commands;

public class HandleAudiosCommandHandler : ICommandHandler<HandleAudiosCommand>
{
    private readonly ILogger<HandleAudiosCommandHandler> logger;
    private readonly IUserService userService;
    private readonly IQueryDispatcher queryDispatcher;
    private readonly ISpeechToTextService speechToTextService;

    public HandleAudiosCommandHandler(
        ILogger<HandleAudiosCommandHandler> logger,
        IUserService userService,
        IQueryDispatcher queryDispatcher,
        ISpeechToTextService speechToTextService)
    {
        this.logger = logger;
        this.userService = userService;
        this.queryDispatcher = queryDispatcher;
        this.speechToTextService = speechToTextService;
    }

    public async Task HandleAsync(HandleAudiosCommand command, CancellationToken cancellation = default)
    {
        var res = await userService.ValidateThatUserSelectLanguages(command);

        if (res)
        {
            var bytes = await queryDispatcher.DispatchAsync(new DownloadFileQuery(command.File.FileId));

            var result = await speechToTextService.RecognizeAsync(bytes);

            Console.WriteLine(5);
        }
    }
}
