using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using SlowoWiaryWarszawaBot.Resources;
using SlowoWiaryWarszawaBot.Keyboards;
using Telegram.Bot.Types.ReplyMarkups;

namespace SlowoWiaryWarszawaBot.Handlers;

/// <summary>
/// Обробник callback запитів від inline кнопок
/// </summary>
public class CallbackHandler
{
    private readonly ITelegramBotClient _botClient;
    private readonly ILogger<CallbackHandler> _logger;

    public CallbackHandler(ITelegramBotClient botClient, ILogger<CallbackHandler> logger)
    {
        _botClient = botClient;
        _logger = logger;
    }

    /// <summary>
    /// Обробка callback query
    /// </summary>
    public async Task HandleCallbackAsync(CallbackQuery callbackQuery, CancellationToken cancellationToken)
    {
        if (callbackQuery.Data is null)
            return;
        
        var chatId = callbackQuery.Message!.Chat.Id;
        var messageId = callbackQuery.Message.MessageId;
        var callbackData = callbackQuery.Data;
        
        _logger.LogInformation("Отримано callback: {CallbackData} від користувача {ChatId}",
            callbackData, chatId);

        try
        {
            await _botClient.AnswerCallbackQuery(
                callbackQueryId: callbackQuery.Id,
                cancellationToken: cancellationToken);
            
            await ProcessCallbackDataAsync(chatId, messageId, callbackData, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Помилка при обробці callback query");
        }
    }

    /// <summary>
    /// Обробка різних типів callback data
    /// </summary>
    private async Task ProcessCallbackDataAsync(long chatId, int messageId, string callbackData,
        CancellationToken cancellationToken)
    {
        switch (callbackData)
        {
            case "church_about":
                await EditMessageAsync(chatId, messageId, BotMessages.Church.About, 
                    BotKeyboards.GetBackToAboutChurchKeyboard(), cancellationToken);
                break;
            
            case "church_mission":
                await EditMessageAsync(chatId, messageId, BotMessages.Church.AboutChurchMission, 
                    BotKeyboards.GetBackToAboutChurchKeyboard(), cancellationToken);
                break;
            
            case "church_doctrine":
                await EditMessageAsync(chatId, messageId, BotMessages.Church.AboutChurchDoctrine, 
                    BotKeyboards.GetBackToAboutChurchKeyboard(), cancellationToken);
                break;
            
            case "church_pastors":
                await EditMessageAsync(chatId, messageId, BotMessages.Church.AboutChurchPastors, 
                    BotKeyboards.GetBackToAboutChurchKeyboard(), cancellationToken);
                break;
            
            case "church_history":
                await EditMessageAsync(chatId, messageId, BotMessages.Church.AboutChurchHistory, 
                    BotKeyboards.GetBackToAboutChurchKeyboard(), cancellationToken);
                break;
            
            case "ministry_sunday":
                await EditMessageAsync(chatId, messageId, BotMessages.Ministry.Sunday, 
                    BotKeyboards.GetBackToMinistryKeyboard(), cancellationToken);
                break;
            
            case "ministry_home_groups":
                await EditMessageAsync(chatId, messageId, BotMessages.Ministry.HomeGroups, 
                    BotKeyboards.GetBackToMinistryKeyboard(), cancellationToken);
                break;
            
            case "ministry_prayer":
                await EditMessageAsync(chatId, messageId, BotMessages.Ministry.Prayer, 
                    BotKeyboards.GetBackToMinistryKeyboard(), cancellationToken);
                break;
            
            case "ministry_youth":
                await EditMessageAsync(chatId, messageId, BotMessages.Ministry.Youth, 
                    BotKeyboards.GetBackToMinistryKeyboard(), cancellationToken);
                break;
            
            case "ministry_teenagers":
                await EditMessageAsync(chatId, messageId, BotMessages.Ministry.Teenagers, 
                    BotKeyboards.GetBackToMinistryKeyboard(), cancellationToken);
                break;
            
            case "ministry_kindergarten":
                await EditMessageAsync(chatId, messageId, BotMessages.Ministry.Kindergarten, 
                    BotKeyboards.GetBackToMinistryKeyboard(), cancellationToken);
                break;
            
                        
            case "back_to_church_menu":
                await EditMessageAsync(chatId, messageId, BotMessages.Church.AboutMenu, 
                    BotKeyboards.GetAboutChurchKeyboard(), cancellationToken);
                break;
            
            case "back_to_ministry_menu":
                await EditMessageAsync(chatId, messageId, BotMessages.Ministry.MinistryMenu, 
                    BotKeyboards.GetMinistryKeyboard(), cancellationToken);
                break;
            
            case "back_to_start":
                try
                {
                    await _botClient.DeleteMessages(
                        chatId: chatId,
                        messageIds: [messageId],
                        cancellationToken: cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Не вдалося видалити повідомлення {MessageId}", messageId);
                }
                
                await _botClient.SendMessage(
                    chatId: chatId,
                    text: BotMessages.Commands.Start,
                    replyMarkup: BotKeyboards.GetMainMenuKeyboard(),
                    parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
                break;
            
            default:
                _logger.LogWarning("Невідомий callback data: {CallbackData}", callbackData);
                break;
        }
    }

    private async Task EditMessageAsync(long chatId, int messageId, string text, InlineKeyboardMarkup replyMarkup,
        CancellationToken cancellationToken)
    {
        try
        {
            await _botClient.EditMessageText(
                chatId: chatId,
                messageId: messageId,
                text: text,
                parseMode: ParseMode.Html,
                replyMarkup: replyMarkup,
                cancellationToken: cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Помилка при редагуванні повідомлення");
            
            await _botClient.SendMessage(
                chatId: chatId,
                text: text,
                parseMode: ParseMode.Html,
                replyMarkup: replyMarkup,
                cancellationToken: cancellationToken);
        }
    }
}