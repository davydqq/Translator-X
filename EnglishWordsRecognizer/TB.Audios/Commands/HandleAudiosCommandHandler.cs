using CQRS.Commands;
using CQRS.Queries;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata;
using TB.Audios.Entities;
using TB.Core.Queries;
using TB.User;

namespace TB.Audios.Commands;

public class HandleAudiosCommandHandler : ICommandHandler<HandleAudiosCommand>
{
    private readonly ILogger<HandleAudiosCommandHandler> logger;
    private readonly IUserService userService;
    private readonly IQueryDispatcher queryDispatcher;
    private readonly IOptions<AzureSpeechConfig> options;

    public HandleAudiosCommandHandler(
        ILogger<HandleAudiosCommandHandler> logger,
        IUserService userService,
        IQueryDispatcher queryDispatcher,
        IOptions<AzureSpeechConfig> options)
    {
        this.logger = logger;
        this.userService = userService;
        this.queryDispatcher = queryDispatcher;
        this.options = options;
    }

    public async Task HandleAsync(HandleAudiosCommand command, CancellationToken cancellation = default)
    {
        var res = await userService.ValidateThatUserSelectLanguages(command);

        if (res)
        {
            var config = SpeechConfig.FromSubscription(options.Value.Key, options.Value.Location);
            var bytes = await queryDispatcher.DispatchAsync(new DownloadFileQuery(command.File.FileId));
            Stream bytesStream = new MemoryStream(bytes);
            using var stream = new AudioStreamReader(bytesStream);
            using var audioConfig = AudioConfig.FromStreamInput(stream);
            using var recognizer = new SpeechRecognizer(config, audioConfig);
            var recognizer_result = await recognizer.RecognizeOnceAsync();
            Console.WriteLine(recognizer_result);
        }
    }
}
