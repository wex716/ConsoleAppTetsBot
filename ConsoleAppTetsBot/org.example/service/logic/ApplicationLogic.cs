using System.Text;
using System.Text.RegularExpressions;
using ConsoleAppTetsBot.org.example.Buttons;
using ConsoleAppTetsBot.org.example.statemachine;

namespace ConsoleAppTetsBot.org.example.service.logic;

public class ApplicationLogic
{
    #region ввод номера кабинета

    public BotTextMessage ProcessWaitingInputCabinetNumber(string textFromUser,
        TransmittedData transmittedData)
    {
        int minLength = 2;
        int maxLength = 6;

        String cleanedNumber = textFromUser.Replace("[^0-9]", "");

        if (cleanedNumber.Length < 1)
        {
            return new BotTextMessage("Ошибка ввода номера кабинета. Введите число.");
        }

        if (cleanedNumber.Length < minLength || cleanedNumber.Length > maxLength)
        {
            return new BotTextMessage("Ошибка ввода номера кабинета. Номер должен содержать от " + minLength + " до " +
                                      maxLength + " цифр.");
        }

        var cabinetNumber = Convert.ToInt32(cleanedNumber);

        transmittedData.DataStorage.Add("cabinetNumber", cabinetNumber);

        transmittedData.State = State.WaitingInputFullName;

        return new BotTextMessage("Номер кабинета успешно записан. Теперь введите ФИО.");
    }

    #endregion

    #region ввод фио

    public BotTextMessage ProcessWaitingInputFullName(string textFromUser,
        TransmittedData transmittedData)
    {
        if (string.IsNullOrEmpty(textFromUser))
        {
            return new BotTextMessage("Пожалуйста, введите ФИО.");
        }

        textFromUser = textFromUser.Trim();

        if (textFromUser.Length > 100)
        {
            return new BotTextMessage("Ошибка. Максимальная длина ФИО 100 символов. Пожалуйста, введите ФИО заново.");
        }

        if (!Regex.IsMatch(textFromUser, @"^[А-Яа-яЁё\s\-\']+$", RegexOptions.IgnoreCase))
        {
            return new BotTextMessage("Введите ФИО на русском языке");
        }

        transmittedData.DataStorage.Add("fullName", textFromUser);

        transmittedData.State = State.WaitingInputNumberPhone;

        return new BotTextMessage("ФИО успешно записан. Теперь введите номер телефона.");
    }

    #endregion

    #region ввод номера телефона

    public BotTextMessage ProcessWaitingInputNumberPhone(string textFromUser,
        TransmittedData transmittedData)
    {
        if (string.IsNullOrEmpty(textFromUser))
        {
            return new BotTextMessage("Пожалуйста, введите номер телефона.");
        }

        string cleanedNumber = Regex.Replace(textFromUser, "[^0-9]", "");

        int minLength = 10;
        int maxLength = 30;

        if (cleanedNumber.Length < minLength || cleanedNumber.Length > maxLength)
        {
            return new BotTextMessage($"Ошибка: Номер телефона должен содержать от {minLength} до {maxLength} цифр.");
        }

        if (!cleanedNumber.All(char.IsDigit))
        {
            return new BotTextMessage("Ошибка: Номер телефона должен содержать только цифры.");
        }

        transmittedData.DataStorage.Add("numberPhone", cleanedNumber);

        transmittedData.State = State.WaitingDescriptionProblem;

        return new BotTextMessage("Номер телефона успешно записан. Теперь опишите проблему.");
    }

    #endregion

    #region ввод описание проблемы

    public BotTextMessage ProcessWaitingDescriptionProblem(string textFromUser,
        TransmittedData transmittedData)
    {
        if (string.IsNullOrEmpty(textFromUser))
        {
            return new BotTextMessage("Ошибка. Не может быть пустое сообщение.");
        }

        transmittedData.DataStorage.Add("descriptionProblem", textFromUser);

        transmittedData.State = State.WaitingQuestionAddPhoto;

        textFromUser = "Описание проблемы успешно записано. Хотите добавить фото?";

        return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetQuestionKeyboard);
    }

    #endregion

    #region обработчик нажатия кнопок (хотите ли вы добавить фото(

    public BotTextMessage ProcessWaitingQuestionAddPhoto(string textFromUser,
        TransmittedData transmittedData)
    {
        if (!textFromUser.Equals(InlineButtonsStorage.YesSendPhoto.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.NoSendPhoto.CallBackData))
        {
            textFromUser = "Ошибка. Нажмите на кнопку.";

            return new BotTextMessage(textFromUser);
        }

        if (textFromUser.Equals(InlineButtonsStorage.YesSendPhoto.CallBackData))
        {
            transmittedData.State = State.WaitingPhoto;

            textFromUser = "Отправьте фото, чтобы прикрепить его к заявке";

            return new BotTextMessage(textFromUser);
        }

        if (textFromUser.Equals(InlineButtonsStorage.NoSendPhoto.CallBackData))
        {
            var text = new StringBuilder("Проверьте данные\n\n");

            //messageText.append("Адрес площадки: ").append(data.get("cabinetNumber")).append("\n");
            text.Append("номер кабинета: ").Append(transmittedData.DataStorage.Get("cabinetNumber")).Append("\n");
            text.Append("ФИО: ").Append(transmittedData.DataStorage.Get("fullName")).Append("\n");
            text.Append("номер телефона: ").Append(transmittedData.DataStorage.Get("numberPhone")).Append("\n");
            text.Append("описание проблемы: ").Append(transmittedData.DataStorage.Get("descriptionProblem"))
                .Append("\n");

            textFromUser = text.ToString();

            transmittedData.State = State.WaitingDataVerification;

            return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetVerificationDataKeyboard);
        }

        return new BotTextMessage(textFromUser);
    }

    #endregion

    #region обработка фото

    public BotTextMessage ProcessWaitingPhoto(string textFromUser,
        TransmittedData transmittedData)
    {
        textFromUser = "Фото успешно прикреплено!";

        var text = new StringBuilder("Проверьте данные\n\n");

        //messageText.append("Адрес площадки: ").append(data.get("cabinetNumber")).append("\n"); - тянется с бд
        text.Append("номер кабинета: ").Append(transmittedData.DataStorage.Get("cabinetNumber")).Append("\n");
        text.Append("ФИО: ").Append(transmittedData.DataStorage.Get("FIO")).Append("\n");
        text.Append("номер телефона: ").Append(transmittedData.DataStorage.Get("numberPhone")).Append("\n");
        text.Append("описание проблемы: ").Append(transmittedData.DataStorage.Get("descriptionProblem")).Append("\n");

        textFromUser = text.ToString();

        transmittedData.State = State.WaitingDataVerification;

        return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetVerificationDataKeyboard);
    }

    #endregion

    #region проверка данных на точность ввода + заявка и отправка заявки

    public BotTextMessage ProcessWaitingDataVerification(string textFromUser,
        TransmittedData transmittedData)
    {
        if (!textFromUser.Equals(InlineButtonsStorage.SendApplication.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.CancelApplication.CallBackData))
        {
            textFromUser = "Ошибка. Нажмите на кнопку.";

            return new BotTextMessage(textFromUser);
        }

        if (textFromUser.Equals(InlineButtonsStorage.SendApplication.CallBackData))
        {
            transmittedData.State = State.WaitingReadApplication;

            textFromUser = "Заявка №222 успешно создана! Вам придет уведомление, когда статус заявки будет изменен";

            transmittedData.DataStorage.Clear();

            return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetBackToMenuKeyboard);
        }

        if (textFromUser.Equals(InlineButtonsStorage.CancelApplication.CallBackData))
        {
            transmittedData.State = State.WaitingApplication;

            textFromUser = "Пожалуйста, выберите адрес площадки.";

            transmittedData.DataStorage.Clear();

            return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetAddressKeyboard);
        }

        return new BotTextMessage(textFromUser);
    }

    #endregion

    #region обработчик кнопок для отправки заявки и отмены заявки

    public BotTextMessage ProcessWaitingReadApplication(string textFromUser,
        TransmittedData transmittedData)
    {
        if (!textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            textFromUser = "Ошибка. Нажмите на кнопку.";

            return new BotTextMessage(textFromUser);
        }

        if (textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            transmittedData.State = State.WaitingQuestionsOrApplicationOrHistory;

            textFromUser = "Выберите то что вы хотите.";

            return new BotTextMessage(textFromUser, InlineKeyboardsStorage.GetStartKeyboard);
        }

        return new BotTextMessage(textFromUser);
    }

    #endregion
}