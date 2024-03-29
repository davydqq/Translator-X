﻿using CQRS.Commands;

namespace TB.Core.Commands;

public class DeleteMessageCommand : ICommand<bool>
{
    public DeleteMessageCommand(long chatId, int messageId)
    {
        ChatId = chatId;
        MessageId = messageId;
    }

    public long ChatId { get; }

    public int MessageId { get; }
}
