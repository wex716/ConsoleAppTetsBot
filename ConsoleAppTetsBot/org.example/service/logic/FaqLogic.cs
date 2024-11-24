using ConsoleAppTetsBot.org.example.Buttons;
using ConsoleAppTetsBot.org.example.statemachine;

namespace ConsoleAppTetsBot.org.example.service.logic;

public class FaqLogic
{
    #region проблемы компьютера

    public BotTextMessage ProcessWaitingViewProblemComputer(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (!textFromUser.Equals(InlineButtonsStorage.First.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.Second.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.Third.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            messageToUser.Text = "Ошибка. Нажмите на кнопку.";

            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.First.CallBackData))
        {
            transmittedData.State = State.WaitingFirstInfoProblemComputer;

            messageToUser.Text = "Отсутствует подключение к сети Интернет\n" +
                                 "При отсутствии подключения к сети Интернет на компьютере:\n" +
                                 "1. Проверьте кабель сети в компьютере и розетке для кабеля сети;\n" +
                                 "2. Если Вы подключены через кабель сети и проверив его концы не обнаружили проблему, то оставьте запрос техническому специалисту.\n" +
                                 "\n" +
                                 "При отсутствии подключения к сети Интернет на ноутбуке:\n" +
                                 "1. Нажмите на значок настроек (шестерня);\n" +
                                 "2. Перейдите в раздел сети (WI-FI);\n" +
                                 "3. Найдите ближайшую рабочую WI-FI сеть;\n" +
                                 "4. Нажмите на кнопку \"Подключиться\".\n";

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetBackKeyboard
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.Second.CallBackData))
        {
            transmittedData.State = State.WaitingSecondInfoProblemComputer;

            messageToUser.Text =
                "1. Проверьте кабель питания (подключен ли он к компьютеру и вставлена ли вилка в розетку);\n" +
                "2. Проверьте кнопку на блоке питания (должна быть в режиме \"I\");\n" +
                "3. Если Ваш компьютер подключен к сети электропитания через удлинитель, проверьте включен ли он;\n";

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetBackKeyboard
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.Third.CallBackData))
        {
            messageToUser.Text = "Монитор выводит изображения с помехами;\n" +
                                 "\n" +
                                 "1. Попробуйте переставить кабель вывода изображения в мониторе\n" +
                                 "2. Если монитор мигает, то:\n" +
                                 "2.1 Проверьте, включен ли компьютер;\n" +
                                 "2.2 Выключите и снова включите монитор.\n" +
                                 "\n" +
                                 "Монитор не выводит изображение;\n" +
                                 "\n" +
                                 "1. Проверьте кабель вывода изображения с компьютера на монитор;\n" +
                                 "2. Проверьте кабель питания на мониторе;\n" +
                                 "3. Проверьте включен ли монитор;\n";

            transmittedData.State = State.WaitingThirdInfoProblemComputer;

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetBackKeyboard
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData))
        {
            messageToUser.Text = "Выберите с чем возникла проблема";

            transmittedData.State = State.WaitingQuestions;

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetProblemSystemShowKeyboard
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            messageToUser.Text = "Выберите то что вы хотите";

            transmittedData.State = State.WaitingQuestionsOrApplicationOrHistory;

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetStartKeyboard
            );
        }

        return messageToUser;
    }

    public BotTextMessage ProcessWaitingFirstInfoProblemComputer(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (!textFromUser.Equals(InlineButtonsStorage.First.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.Second.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.Third.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            messageToUser.Text = "Ошибка. Нажмите на кнопку.";
            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData))
        {
            messageToUser.Text =
                "Список проблем: \n1. Отсутствует подключение к сети Интернет \n2. Не включается компьютер \n3. Проблема с монитором.";

            transmittedData.State = State.WaitingViewProblemComputer;

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

        return messageToUser;
    }

    public BotTextMessage ProcessWaitingSecondInfoProblemComputer(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (!textFromUser.Equals(InlineButtonsStorage.First.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.Second.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            messageToUser.Text = "Ошибка. Нажмите на кнопку.";
            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData))
        {
            messageToUser.Text =
                "Список проблем: \n1. Отсутствует подключение к сети Интернет \n2. Не включается компьютер \n3. Проблема с монитором.";

            transmittedData.State = State.WaitingViewProblemComputer;

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetProblemFoursButtonsKeyboard
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

        return messageToUser;
    }

    public BotTextMessage ProcessWaitingThirdInfoProblemComputer(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (!textFromUser.Equals(InlineButtonsStorage.First.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.Second.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.Third.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            messageToUser.Text = "Ошибка. Нажмите на кнопку.";
            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData))
        {
            messageToUser.Text =
                "Список проблем: \n1. Отсутствует подключение к сети Интернет \n2. Не включается компьютер \n3. Проблема с монитором.";

            transmittedData.State = State.WaitingViewProblemComputer;

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

        return messageToUser;
    }

    #endregion

    #region проблемы принтера

    public BotTextMessage ProcessWaitingViewProblemPrinter(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (!textFromUser.Equals(InlineButtonsStorage.First.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.Second.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            messageToUser.Text = "Ошибка. Нажмите на кнопку.";

            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.First.CallBackData))
        {
            transmittedData.State = State.WaitingFirstInfoProblemPrinter;

            messageToUser.Text = "1. Перейдите в настройки Windows;\n" +
                                 "2. Зайдите в параметры устройств и выберите категорию с принтерами;\n" +
                                 "3. Если в списке подключенных принтеров нет вашего, то запустите поиск;\n" +
                                 "3.1. В списке найденных устройств выбери ваш принтер и ожидайте подключения;\n" +
                                 "3. Если Ваш принтер подключен к компьютеру, то удалите его и подключите заново.\n";

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetBackKeyboard
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.Second.CallBackData))
        {
            transmittedData.State = State.WaitingSecondInfoProblemPrinter;

            messageToUser.Text =
                "1. При замятии бумаги посмотрите на панель управления принтера и следуйте инструкции;\n" +
                "2. Откройте заднюю панель принтера;\n" +
                "3. Вытащите замятый лист и закройте панель;\n";

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetBackKeyboard
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData))
        {
            messageToUser.Text = "Выберите с чем возникла проблема";

            transmittedData.State = State.WaitingQuestions;

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetProblemSystemShowKeyboard
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            messageToUser.Text = "Выберите то что вы хотите";

            transmittedData.State = State.WaitingQuestionsOrApplicationOrHistory;

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetStartKeyboard
            );
        }

        return messageToUser;
    }

    public BotTextMessage ProcessWaitingFirstInfoProblemPrinter(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (!textFromUser.Equals(InlineButtonsStorage.First.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.Second.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            messageToUser.Text = "Ошибка. Нажмите на кнопку.";
            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData))
        {
            messageToUser.Text =
                "Список проблем: \n1. Не подключается к компьютеру \n2. Замятие бумаги";

            transmittedData.State = State.WaitingViewProblemPrinter;

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetProblemFoursButtonsKeyboard
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

        return messageToUser;
    }

    public BotTextMessage ProcessWaitingSecondInfoProblemPrinter(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (!textFromUser.Equals(InlineButtonsStorage.First.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.Second.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            messageToUser.Text = "Ошибка. Нажмите на кнопку.";
            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData))
        {
            messageToUser.Text =
                "Список проблем: \n1. Не подключается к компьютеру \n2. Замятие бумаги";

            transmittedData.State = State.WaitingViewProblemPrinter;

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetProblemFoursButtonsKeyboard
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

        return messageToUser;
    }

    #endregion
    
    #region проблемы компьютера

    public BotTextMessage ProcessWaitingViewProblemProjector(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (!textFromUser.Equals(InlineButtonsStorage.First.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.Second.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.Third.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            messageToUser.Text = "Ошибка. Нажмите на кнопку.";

            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.First.CallBackData))
        {
            transmittedData.State = State.WaitingFirstInfoProblemProjector;

            messageToUser.Text = "1. Проверьте, включен ли проектор/интерактивная доска;\n" +
                                  "2. Проверьте кабель вывода изображения;\n" +
                                  "3. На компьютере нажмите комбинацию клавиш WIN + P и в открывшейся панели выберите \"Повторяющийся\".\n";

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetBackKeyboard
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.Second.CallBackData))
        {
            transmittedData.State = State.WaitingSecondInfoProblemProjector;

            messageToUser.Text = "1. Проверьте кабель питания, вставлен ли он в розетку;\n" +
                                  "2. Проверьте рубильник в щитке:\n" +
                                  "2.1 Если включен, но при этом нет электричества, обратитесь к заведующему хозяйству по зданию.\n";
            
            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetBackKeyboard
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.Third.CallBackData))
        {
            messageToUser.Text = "1. Попробуйте выключить свет в кабинете;\n" +
                                  "2. Возьмите пульт и перейдите в настройки проектора, затем перейдите во вкладку \"Изображение\" и измените уровень яркости.\n";

            transmittedData.State = State.WaitingThirdInfoProblemProjector;

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetBackKeyboard
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData))
        {
            messageToUser.Text = "Выберите с чем возникла проблема";

            transmittedData.State = State.WaitingQuestions;

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetProblemSystemShowKeyboard
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            messageToUser.Text = "Выберите то что вы хотите";

            transmittedData.State = State.WaitingQuestionsOrApplicationOrHistory;

            return new BotTextMessage(
                messageToUser.Text,
                InlineKeyboardsStorage.GetStartKeyboard
            );
        }

        return messageToUser;
    }

    public BotTextMessage ProcessWaitingFirstInfoProblemProjector(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (!textFromUser.Equals(InlineButtonsStorage.First.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.Second.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.Third.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            messageToUser.Text = "Ошибка. Нажмите на кнопку.";
            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData))
        {
            messageToUser.Text =
                "Список проблем: \n1. Не выводится изображение \n2. Проектор не включается \n3. Слишком тусклое изображение.";

            transmittedData.State = State.WaitingViewProblemProjector;

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

        return messageToUser;
    }

    public BotTextMessage ProcessWaitingSecondInfoProblemProjector(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (!textFromUser.Equals(InlineButtonsStorage.First.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.Second.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            messageToUser.Text = "Ошибка. Нажмите на кнопку.";
            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData))
        {
            messageToUser.Text =
                "Список проблем: \n1. Не выводится изображение \n2. Проектор не включается \n3. Слишком тусклое изображение.";

            transmittedData.State = State.WaitingViewProblemProjector;

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

        return messageToUser;
    }

    public BotTextMessage ProcessWaitingThirdInfoProblemProjector(string textFromUser,
        TransmittedData transmittedData)
    {
        var messageToUser = new BotTextMessage(textFromUser)
        {
            ChatId = transmittedData.ChatId,
        };

        if (!textFromUser.Equals(InlineButtonsStorage.First.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.Second.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.Third.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData) &&
            !textFromUser.Equals(InlineButtonsStorage.BackToMenu.CallBackData))
        {
            messageToUser.Text = "Ошибка. Нажмите на кнопку.";
            return new BotTextMessage(
                messageToUser.Text
            );
        }

        if (textFromUser.Equals(InlineButtonsStorage.MovePrevShow.CallBackData))
        {
            messageToUser.Text =
                "Список проблем: \n1. Не выводится изображение \n2. Проектор не включается \n3. Слишком тусклое изображение.";

            transmittedData.State = State.WaitingViewProblemProjector;

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

        return messageToUser;
    }

    #endregion
}