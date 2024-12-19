﻿using System.Text;
using ConsoleAppTetsBot.org.example.ApiWorker;
using ConsoleAppTetsBot.org.example.Buttons;
using ConsoleAppTetsBot.org.example.statemachine;

namespace ConsoleAppTetsBot.org.example.service.logic;

public class StartLogic
{
    private HistoryApplication _historyApplication;
    private ApplicationApiWorker _applicationApiWorker;

    public StartLogic()
    {
        _historyApplication = new HistoryApplication();
        _applicationApiWorker = new ApplicationApiWorker();
    }

    #region старт

    public BotTextMessage ProcessWaitingCommandStart(string textFromUser, TransmittedData transmittedData)
    {
        if (textFromUser != "/start")
        {
            textFromUser =
                "Здравстуйте! Это теханическая поддержка МГОК.\n \nДанный бот призван упростить взаимодействие преподавателей и Сис админов\n \nБудем рады помочь решить проблему, которая у вас возникла\n \nДля того, чтобы бот начал работу, нажмите /start";

            return new BotTextMessage(textFromUser);
        }

        transmittedData.State = State.WaitingQuestionsOrApplicationOrHistory;

        textFromUser = "Выберите то что вы хотите";

        return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetStartKeyboard);
    }

    #endregion

    #region выбор действия

    public BotTextMessage ProcessWaitingQuestionsOrApplicationOrHistory(string textFromUser,
        TransmittedData transmittedData)
    {
        if (!textFromUser.Equals(InlineButtonsStorage.ShowQuestions.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.SubmitApplication.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.SubmitHistory.CallBackData))
        {
            textFromUser = "Ошибка. Нажмите на кнопку.";
            return new BotTextMessage(
                textFromUser
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.ShowQuestions.CallBackData))
        {
            transmittedData.State = State.WaitingQuestions;

            textFromUser = "Выберите, с чем возникла проблема";

            return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetProblemSystemShowKeyboard);
        }

        if (textFromUser.Equals(InlineButtonsStorage.SubmitApplication.CallBackData))
        {
            transmittedData.State = State.WaitingApplication;

            textFromUser = "Пожалуйста, выберите адрес площадки.";

            return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetAddressKeyboard);
        }

        if (textFromUser.Equals(InlineButtonsStorage.SubmitHistory.CallBackData))
        {
            List<HistoryApplication> historyApplications = _applicationApiWorker.GetByAllApplication();

            if (historyApplications.Count == 0)
            {
                return new BotTextMessage("Нет истории заявок.", InlineKeyboardsStorage.GetNextShowKeyboard);
            }

            int countHistoriesLogic = historyApplications.Count();
            int currentHistoriesLogic = 1;

            transmittedData.DataStorage.Add("historyApplications", historyApplications);
            transmittedData.DataStorage.Add("countHistoriesLogic", countHistoriesLogic);
            transmittedData.DataStorage.Add("currentHistoriesLogic", currentHistoriesLogic);

            HistoryApplication currentHistories = historyApplications[currentHistoriesLogic - 1];

            textFromUser =
                $"userId:{currentHistories.UserId}\nid:{currentHistories.Id}\ntitle:{currentHistories.Title}\nbody:{currentHistories.Title}";

            //  textFromUser = $"Заявка номер: {currentHistories.IdHistoryApplication} \nСтатус: {currentHistories.Status} \nАдерс: {currentHistories.Address} \nКабинет: {currentHistories.Cabinet} \nФИО: {currentHistories.Fullname} \nТелефон: {currentHistories.NumberPhone} \nДата создания: {currentHistories.DateTime} \nПроблема: {currentHistories.Description}";

            transmittedData.State = State.WaitingShowHistory;

            return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetNextShowKeyboard);
        }

        return null;
    }

    #endregion

    #region вопросы

    public BotTextMessage ProcessWaitingQuestions(string textFromUser, TransmittedData transmittedData)
    {
        if (!textFromUser.Equals(InlineButtonsStorage.ViewProblemComputer.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.ViewProblemPrinter.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.ViewProblemProjector.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            textFromUser = "Ошибка. Нажмите на кнопку.";

            return new BotTextMessage(textFromUser);
        }

        if (textFromUser.Equals(InlineButtonsStorage.ViewProblemComputer.CallBackData))
        {
            transmittedData.State = State.WaitingViewProblemComputer;

            textFromUser =
                "Список проблем: \n1. Отсутствует подключение к сети Интернет \n2. Не включается компьютер \n3. Проблема с монитором.";

            return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetProblemFiveButtonsKeyboard);
        }

        if (textFromUser.Equals(InlineButtonsStorage.ViewProblemPrinter.CallBackData))
        {
            transmittedData.State = State.WaitingViewProblemPrinter;

            textFromUser = "Список проблем: \n1. Не подключается к компьютеру \n2. Замятие бумаги.";

            return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetProblemFoursButtonsKeyboard);
        }

        if (textFromUser.Equals(InlineButtonsStorage.ViewProblemProjector.CallBackData))
        {
            transmittedData.State = State.WaitingViewProblemProjector;

            textFromUser =
                "Список проблем: \n1. Не выводится изображение \n2. Проектор не включается \n3. Слишком тусклое изображение.";

            return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetProblemFiveButtonsKeyboard);
        }

        if (textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            transmittedData.State = State.WaitingQuestionsOrApplicationOrHistory;

            textFromUser = "Выберите то что вы хотите.";

            return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetStartKeyboard);
        }

        return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetProblemSystemShowKeyboard);
    }

    #endregion

    #region заявка

    public BotTextMessage ProcessWaitingApplication(string textFromUser, TransmittedData transmittedData)
    {
        if (!textFromUser.Equals(InlineButtonsStorage.FirstAddressPlace.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.SecondAddressPlace.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.ThirdAddressPlace.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.FourAddressPlace.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.FiveAddressPlace.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            textFromUser = "Ошибка. Нажмите на кнопку.";

            return new BotTextMessage(textFromUser);
        }

        if (textFromUser.Equals(InlineButtonsStorage.FirstAddressPlace.CallBackData))
        {
            transmittedData.State = State.WaitingInputCabinetNumber;

            transmittedData.DataStorage.Add("addressPlace", InlineButtonsStorage.FirstAddressPlace.Name);

            transmittedData.DataStorage.Add("addressId", 1);

            textFromUser = "Введите номер кабинета.";

            return new BotTextMessage(textFromUser);
        }

        if (textFromUser.Equals(InlineButtonsStorage.SecondAddressPlace.CallBackData))
        {
            transmittedData.State = State.WaitingInputCabinetNumber;

            transmittedData.DataStorage.Add("addressPlace", InlineButtonsStorage.SecondAddressPlace.Name);
            
            transmittedData.DataStorage.Add("addressId", 2);

            textFromUser = "Введите номер кабинета.";

            return new BotTextMessage(textFromUser);
        }

        if (textFromUser.Equals(InlineButtonsStorage.ThirdAddressPlace.CallBackData))
        {
            transmittedData.State = State.WaitingInputCabinetNumber;
            
            transmittedData.DataStorage.Add("addressPlace", InlineButtonsStorage.ThirdAddressPlace.Name);
            
            transmittedData.DataStorage.Add("addressId", 3);
            
            textFromUser = "Введите номер кабинета.";

            return new BotTextMessage(textFromUser);
        }

        if (textFromUser.Equals(InlineButtonsStorage.FourAddressPlace.CallBackData))
        {
            transmittedData.State = State.WaitingInputCabinetNumber;
            
            transmittedData.DataStorage.Add("addressPlace", InlineButtonsStorage.FourAddressPlace.Name);
            
            transmittedData.DataStorage.Add("addressId", 4);
            
            textFromUser = "Введите номер кабинета.";

            return new BotTextMessage(textFromUser);
        }

        if (textFromUser.Equals(InlineButtonsStorage.FiveAddressPlace.CallBackData))
        {
            transmittedData.State = State.WaitingInputCabinetNumber;
            
            transmittedData.DataStorage.Add("addressPlace", InlineButtonsStorage.FiveAddressPlace.Name);
            
            transmittedData.DataStorage.Add("addressId", 5);

            textFromUser = "Введите номер кабинета.";

            return new BotTextMessage(textFromUser);
        }

        if (textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            transmittedData.State = State.WaitingQuestionsOrApplicationOrHistory;

            textFromUser = "Выберите то что вы хотите.";

            return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetStartKeyboard);
        }

        return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetProblemSystemShowKeyboard);
    }

    #endregion
}