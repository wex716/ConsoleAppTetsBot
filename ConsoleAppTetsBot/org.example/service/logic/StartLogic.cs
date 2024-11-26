using ConsoleAppTetsBot.org.example.Buttons;
using ConsoleAppTetsBot.org.example.statemachine;
using Telegram.Bot.Types.ReplyMarkups;

namespace ConsoleAppTetsBot.org.example.service.logic;

public class StartLogic
{
    #region старт

    public BotTextMessage ProcessWaitingCommandStart(string textFromUser, TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (textFromUser != "/start")
        {
            messageToUser.Text =
                "Здравстуйте! Это теханическая поддержка МГОК.\n \nДанный бот призван упростить взаимодействие преподавателей и Сис админов\n \nБудем рады помочь решить проблему, которая у вас возникла\n \nДля того, чтобы бот начал работу, нажмите /start";
            return messageToUser;
        }

        transmittedData.State = State.WaitingQuestionsOrApplicationOrHistory;

        messageToUser.Text = "Выберите то что вы хотите";

        return new BotTextMessage(
            messageToUser.Text,
            InlineKeyboardsStorage.GetStartKeyboard
        );
    }

    #endregion

    #region выбор действия

    public BotTextMessage ProcessWaitingQuestionsOrApplicationOrHistory(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (!textFromUser.Equals(InlineButtonsStorage.ShowQuestionsStart.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.SubmitApplication.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.SubmitHistory.CallBackData))
        {
            messageToUser.Text = "Ошибка. Нажмите на кнопку.";
            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.ShowQuestionsStart.CallBackData))
        {
            transmittedData.State = State.WaitingQuestions;
            messageToUser.Text = "Выберите, с чем возникла проблема";

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetProblemSystemShowKeyboard
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.SubmitApplication.CallBackData))
        {
            transmittedData.State = State.WaitingApplication;
            messageToUser.Text = "Пожалуйста, выберите адрес площадки.";

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetAddressKeyboard
            );
        }

        return messageToUser;
    }

    #endregion


    #region вопросы

    public BotTextMessage ProcessWaitingQuestions(string textFromUser, TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (!textFromUser.Equals(InlineButtonsStorage.ViewProblemComputer.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.ViewProblemPrinter.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.ViewProblemProjector.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            messageToUser.Text = "Ошибка. Нажмите на кнопку.";
            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.ViewProblemComputer.CallBackData))
        {
            transmittedData.State = State.WaitingViewProblemComputer;

            messageToUser.Text =
                "Список проблем: \n1. Отсутствует подключение к сети Интернет \n2. Не включается компьютер \n3. Проблема с монитором.";

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetProblemFiveButtonsKeyboard
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.ViewProblemPrinter.CallBackData))
        {
            messageToUser.Text = "Список проблем: \n1. Не подключается к компьютеру \n2. Замятие бумаги.";

            transmittedData.State = State.WaitingViewProblemPrinter;

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetProblemFoursButtonsKeyboard
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.ViewProblemProjector.CallBackData))
        {
            transmittedData.State = State.WaitingViewProblemProjector;

            messageToUser.Text =
                "Список проблем: \n1. Не выводится изображение \n2. Проектор не включается \n3. Слишком тусклое изображение.";

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetProblemFiveButtonsKeyboard
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            transmittedData.State = State.WaitingQuestionsOrApplicationOrHistory;

            messageToUser.Text = "Выберите то что вы хотите.";

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetStartKeyboard
            );
        }

        return new BotTextMessage(
            messageToUser.Text,
            InlineKeyboardsStorage.GetProblemSystemShowKeyboard
        );
    }

    #endregion

    public BotTextMessage ProcessWaitingApplication(string textFromUser, TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (!textFromUser.Equals(InlineButtonsStorage.FirstAddressPlace.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.SecondAddressPlace.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.ThirdAddressPlace.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.FourAddressPlace.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.FiveAddressPlace.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            messageToUser.Text = "Ошибка. Нажмите на кнопку.";
            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.FirstAddressPlace.CallBackData))
        {
            transmittedData.State = State.WaitingInputCabinetNumber;

            messageToUser.Text = "Введите номер кабинета.";

            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.SecondAddressPlace.CallBackData))
        {
            transmittedData.State = State.WaitingInputCabinetNumber;

            messageToUser.Text = "Введите номер кабинета.";

            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.ThirdAddressPlace.CallBackData))
        {
            transmittedData.State = State.WaitingInputCabinetNumber;

            messageToUser.Text = "Введите номер кабинета.";

            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.FourAddressPlace.CallBackData))
        {
            transmittedData.State = State.WaitingInputCabinetNumber;

            messageToUser.Text = "Введите номер кабинета.";

            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.FiveAddressPlace.CallBackData))
        {
            transmittedData.State = State.WaitingInputCabinetNumber;

            messageToUser.Text = "Введите номер кабинета.";

            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            transmittedData.State = State.WaitingQuestionsOrApplicationOrHistory;

            messageToUser.Text = "Выберите то что вы хотите.";

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetStartKeyboard
            );
        }

        return new BotTextMessage(
            messageToUser.Text,
            InlineKeyboardsStorage.GetProblemSystemShowKeyboard
        );
    }
}