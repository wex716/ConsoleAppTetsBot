using Telegram.Bot.Types.ReplyMarkups;

namespace ConsoleAppTetsBot;

public class BotTextMessage
{
    public string Text { set; get; }
    public InlineKeyboardMarkup InlineKeyboardMarkup { set; get; }
    public long ChatId { get; set; }

    public BotTextMessage(string text)
    {
        Text = text;
        InlineKeyboardMarkup = null;
    }

    public BotTextMessage(string text, InlineKeyboardMarkup inlineKeyboardMarkup)
    {
        Text = text;
        InlineKeyboardMarkup = inlineKeyboardMarkup;
    }
}