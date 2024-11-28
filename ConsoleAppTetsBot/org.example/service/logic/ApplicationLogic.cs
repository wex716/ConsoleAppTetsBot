using System.Text;
using System.Text.RegularExpressions;
using ConsoleAppTetsBot.org.example.Buttons;
using ConsoleAppTetsBot.org.example.statemachine;

namespace ConsoleAppTetsBot.org.example.service.logic;

public class ApplicationLogic
{
    #region ввод номена кабинета

    public BotTextMessage ProcessWaitingInputCabinetNumber(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        int minLength = 2;
        int maxLength = 6;

        String cleanedNumber = textFromUser.Replace("[^0-9]", "");

        if (cleanedNumber.Length < 1)
        {
            messageToUser.Text = "Ошибка ввода номера кабинета. Введите число.";
            return messageToUser;
        }

        if (cleanedNumber.Length < minLength || cleanedNumber.Length > maxLength)
        {
            messageToUser.Text = "Ошибка ввода номера кабинета. Номер должен содержать от " + minLength + " до " +
                                 maxLength + " цифр.";
            return messageToUser;
        }

        var cabinetNumber = Convert.ToInt32(cleanedNumber);

        transmittedData.DataStorage.Add("cabinetNumber", cabinetNumber);

        messageToUser.Text = "Номер кабинета успешно записан. Теперь введите ФИО.";
        transmittedData.State = State.WaitingInputFullName;

        return messageToUser;
    }

    #endregion

    #region ввод фио

    public BotTextMessage ProcessWaitingInputFullName(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (textFromUser.Length < 100)
        {
            messageToUser.Text = "Ошибка. Максимальная длина ФИО 100 символов. Пожалуйста, введите ФИО заново.";
        }

        if (!Regex.IsMatch(textFromUser, @"^[А-Яа-яЁё\s\-\']+$", RegexOptions.IgnoreCase))
        {
            messageToUser.Text = "Введите ФИО на русском языке";
            return messageToUser;
        }

        transmittedData.DataStorage.Add("FIO", textFromUser);
        messageToUser.Text = "ФИО успешно записан. Теперь введите номер телефона.";
        transmittedData.State = State.WaitingInputNumberPhone;
        return messageToUser;
    }

    #endregion

    #region ввод номера телефона

    public BotTextMessage ProcessWaitingInputNumberPhone(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        String cleanedNumber = textFromUser.Replace("[^0-9]", "");

        if (string.IsNullOrEmpty(textFromUser))
        {
            messageToUser.Text = "Ошибка ввода номера телефона. Введите номер телефона";
            return messageToUser;
        }

        int minLength = 10;
        int maxLength = 30;
        if (cleanedNumber.Length < minLength || cleanedNumber.Length > maxLength)
        {
            messageToUser.Text = "Ошибка ввода номера телефона. Номер должен содержать от " + minLength + " до " +
                                 maxLength + " цифр.";
            return messageToUser;
        }

        transmittedData.DataStorage.Add("numberPhone", cleanedNumber);
        messageToUser.Text = "Номер телефона успешно записан. Теперь опишите проблему.";
        transmittedData.State = State.WaitingDescriptionProblem;

        return messageToUser;
    }

    #endregion

    #region ввод описание проблемы

    public BotTextMessage ProcessWaitingDescriptionProblem(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (string.IsNullOrEmpty(textFromUser))
        {
            messageToUser.Text = "Ошибка. Не может быть пустое сообщение.";
        }

        transmittedData.DataStorage.Add("descriptionProblem", textFromUser);
        messageToUser.Text = "Описание проблемы успешно записано. Хотите добавить фото?";
        transmittedData.State = State.WaitingQuestionAddPhoto;

        return new BotTextMessage(
            messageToUser.Text,
            InlineKeyboardsStorage.GetQuestionKeyboard
        );
    }

    #endregion

    #region обработчик нажатия кнопок (хотите ли вы добавить фото(

    public BotTextMessage ProcessWaitingQuestionAddPhoto(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (!textFromUser.Equals(InlineButtonsStorage.YesSendPhoto.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.NoSendPhoto.CallBackData))
        {
            messageToUser.Text = "Ошибка. Нажмите на кнопку.";
            return messageToUser;
        }

        if (textFromUser.Equals(InlineButtonsStorage.YesSendPhoto.CallBackData))
        {
            messageToUser.Text = "Отправьте фото, чтобы прикрепить его к заявке";

            transmittedData.State = State.WaitingPhoto;

            return messageToUser;
        }

        if (textFromUser.Equals(InlineButtonsStorage.NoSendPhoto.CallBackData))
        {
            StringBuilder text = new StringBuilder("Проверьте данные\n\n");

            //messageText.append("Адрес площадки: ").append(data.get("cabinetNumber")).append("\n"); - тянется с бд

            text.Append("номер кабинета: ").Append(transmittedData.DataStorage.Get("cabinetNumber")).Append("\n");
            text.Append("ФИО: ").Append(transmittedData.DataStorage.Get("FIO")).Append("\n");
            ;
            text.Append("номер телефона: ").Append(transmittedData.DataStorage.Get("numberPhone")).Append("\n");
            ;
            text.Append("описание проблемы: ").Append(transmittedData.DataStorage.Get("descriptionProblem"))
                .Append("\n");
            ;

            messageToUser.Text = text.ToString();

            transmittedData.State = State.WaitingDataVerification;

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetVerificationDataKeyboard
            );
        }

        return messageToUser;
    }

    #endregion

    #region обработка фото

    public BotTextMessage ProcessWaitingPhoto(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        messageToUser.Text = "Фото успешно прикреплено!";

        StringBuilder text = new StringBuilder("Проверьте данные\n\n");

        //messageText.append("Адрес площадки: ").append(data.get("cabinetNumber")).append("\n"); - тянется с бд

        text.Append("номер кабинета: ").Append(transmittedData.DataStorage.Get("cabinetNumber")).Append("\n");
        text.Append("ФИО: ").Append(transmittedData.DataStorage.Get("FIO")).Append("\n");
        ;
        text.Append("номер телефона: ").Append(transmittedData.DataStorage.Get("numberPhone")).Append("\n");
        ;
        text.Append("описание проблемы: ").Append(transmittedData.DataStorage.Get("descriptionProblem")).Append("\n");
        ;

        messageToUser.Text = text.ToString();

        transmittedData.State = State.WaitingDataVerification;

        return new BotTextMessage(
            messageToUser.Text,
            InlineKeyboardsStorage.GetVerificationDataKeyboard
        );
    }

    #endregion

    #region проверка данных на точность ввода + заявка и отправка заявки

    public BotTextMessage ProcessWaitingDataVerification(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (!textFromUser.Equals(InlineButtonsStorage.SendApplication.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.CancelApplication.CallBackData))
        {
            messageToUser.Text = "Ошибка. Нажмите на кнопку.";

            return messageToUser;
        }

        if (textFromUser.Equals(InlineButtonsStorage.SendApplication.CallBackData))
        {
            messageToUser.Text =
                "Заявка №222 успешно создана! Вам придет уведомление, когда статус заявки будет изменен"; // тянется с бд

            transmittedData.State = State.WaitingReadApplication;

            transmittedData.DataStorage.Clear();

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetMenuKeyboard
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.CancelApplication.CallBackData))
        {
            messageToUser.Text = "Пожалуйста, выберите адрес площадки.";

            transmittedData.State = State.WaitingApplication;

            transmittedData.DataStorage.Clear();

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetAddressKeyboard
            );
        }

        return messageToUser;
    }

    #endregion

    #region обработчик кнопок для отправки заявки и отмены заявки

    public BotTextMessage ProcessWaitingReadApplication(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (!textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            messageToUser.Text = "Ошибка. Нажмите на кнопку.";

            return messageToUser;
        }

        if (textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            messageToUser.Text = "Выберите то что вы хотите.";
            transmittedData.State = State.WaitingQuestionsOrApplicationOrHistory;

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetStartKeyboard
            );
        }

        return messageToUser;
    }

    #endregion
}