﻿using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TB.Database.Entities.Requests;
using TB.Database.GenericRepositories;
using TB.Database.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace TB.Meaning.Commands;

public class GetSynonymsCommandHandler : ICommandHandler<GetSynonymsCommand, IEnumerable<string>>
{
    private readonly ILogger<GetSynonymsCommandHandler> logger;

    private readonly TextRequestRepository textRequestRepository;

    private readonly ThesaurusService thesaurusService;

    private readonly UserPlansRepository userPlansRepository;

    public GetSynonymsCommandHandler(
        ILogger<GetSynonymsCommandHandler> logger,
        TextRequestRepository textRequestRepository, 
        ThesaurusService thesaurusService,
        UserPlansRepository userPlansRepository)
    {
        this.logger = logger;
        this.textRequestRepository = textRequestRepository;
        this.thesaurusService = thesaurusService;
        this.userPlansRepository = userPlansRepository;
    }

    public async Task<IEnumerable<string>> HandleAsync(GetSynonymsCommand command, CancellationToken cancellation = default)
    {
        if (string.IsNullOrEmpty(command.Text))
        {
            logger.LogError("Text null");
            return null;
        }

        var plan = await userPlansRepository.GetUserPlan(command.UserId);

        var texts = new string[] { command.Text };
        var request = new TextRequest(ApiTypeENUM.Thesaurus, texts, 0, command.UserId, plan.Id).InitSynonyms();

        var synonyms = await thesaurusService.GetSynonymsAsync(command.Text);

        var isSuccess = synonyms == null ? false : true;
        var resJson = isSuccess ? JsonConvert.SerializeObject(synonyms) : null;
        request.InitResponse(resJson, isSuccess);

        await textRequestRepository.AddAsync(request);

        return synonyms;
    }
}
