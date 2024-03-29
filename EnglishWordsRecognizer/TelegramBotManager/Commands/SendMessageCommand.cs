﻿using CQRS.Commands;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TB.Core.Commands;

public class SendMessageCommand : ICommand<List<Message>>
{
	public SendMessageCommand(
		long chatId, 
		string message, 
		ParseMode? parseMode = null, 
		IReplyMarkup replyMarkup = null,
		int? replyToMessageId = null)
	{
		ChatId = chatId;
		Message = message;
		ParseMode = parseMode;
		ReplyMarkup = replyMarkup;
		ReplyToMessageId = replyToMessageId;
	}

	public long ChatId { get; }

	public string Message { get; }

	public ParseMode? ParseMode { get; }

	public IReplyMarkup ReplyMarkup { get; }

	public int? ReplyToMessageId { get; }
}
