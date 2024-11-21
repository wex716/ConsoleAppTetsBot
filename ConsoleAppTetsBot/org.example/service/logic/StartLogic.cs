using ConsoleAppTetsBot.org.example.Buttons;
using ConsoleAppTetsBot.org.example.statemachine;
using Telegram.Bot.Types.ReplyMarkups;

namespace ConsoleAppTetsBot.org.example.service.logic;

public class StartLogic
{
    public BotTextMessage ProcessWaitingCommandStart(string textFromUser, TransmittedData transmittedData) {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
            InlineKeyboardMarkup = new InlineKeyboardMarkup()
        };

        if (textFromUser != "/start")
        {
            messageToUser.Text = "Здравстуйте! Это теханическая поддержка МГОК.\n \nДанный бот призван упростить взаимодействие преподавателей и Сис админов\n \nБудем рады помочь решить проблему, которая у вас возникла\n \nДля того, чтобы бот начал работу, нажмите /start";
            return messageToUser;
        }

        messageToUser.Text = "Выберите то что вы хотите";
        messageToUser.InlineKeyboardMarkup = messageToUser.InlineKeyboardMarkup.GetStartKeyboard();
        transmittedData.State = State.WaitingQuestionsOrApplicationOrHistory;

        return messageToUser;
    }
}