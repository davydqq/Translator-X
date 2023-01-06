using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TB.Database.Entities.Requests;
using TB.Database.GenericRepositories;
using static System.Net.Mime.MediaTypeNames;

namespace TB.Meaning.Commands;

public class GetSynonymsCommandHandler : ICommandHandler<GetSynonymsCommand, IEnumerable<string>>
{
    private readonly ILogger<GetSynonymsCommandHandler> logger;

    private readonly IRepository<TextRequest, int> textRequestRepository;

    private readonly ThesaurusService thesaurusService;

    public GetSynonymsCommandHandler(
        ILogger<GetSynonymsCommandHandler> logger,
        IRepository<TextRequest, int> textRequestRepository, 
        ThesaurusService thesaurusService)
    {
        this.logger = logger;
        this.textRequestRepository = textRequestRepository;
        this.thesaurusService = thesaurusService;
    }

    public async Task<IEnumerable<string>> HandleAsync(GetSynonymsCommand command, CancellationToken cancellation = default)
    {
        if (string.IsNullOrEmpty(command.Text))
        {
            logger.LogError("Text null");
            return null;
        }

        var texts = new string[] { command.Text };
        var request = new TextRequest(ApiTypeENUM.Thesaurus, texts, 0).InitSynonyms();

        var synonyms = await thesaurusService.GetSynonymsAsync(command.Text);

        var isSuccess = synonyms == null ? false : true;
        var resJson = isSuccess ? JsonConvert.SerializeObject(synonyms) : null;
        request.InitResponse(resJson, isSuccess);

        await textRequestRepository.AddAsync(request);

        return synonyms;
    }
}
