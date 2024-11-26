using Telegram.Bot.Types.ReplyMarkups;

namespace ConsoleAppTetsBot.org.example.Buttons;

public class InlineKeyboardsStorage
{
    public static InlineKeyboardMarkup GetStartKeyboard = new(new[]
    {
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.ShowQuestionsStart.Name,
                InlineButtonsStorage.ShowQuestionsStart.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.SubmitApplication.Name,
                InlineButtonsStorage.SubmitApplication.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.SubmitHistory.Name,
                InlineButtonsStorage.SubmitHistory.CallBackData),
        },
    });

    public static InlineKeyboardMarkup GetProblemSystemShowKeyboard = new(new[]
    {
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.ViewProblemComputer.Name,
                InlineButtonsStorage.ViewProblemComputer.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.ViewProblemPrinter.Name,
                InlineButtonsStorage.ViewProblemPrinter.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.ViewProblemProjector.Name,
                InlineButtonsStorage.ViewProblemProjector.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.BackToMenu.Name,
                InlineButtonsStorage.BackToMenu.CallBackData),
        },
    });

    public static InlineKeyboardMarkup GetProblemFiveButtonsKeyboard = new(new[]
    {
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.First.Name,
                InlineButtonsStorage.First.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.Second.Name,
                InlineButtonsStorage.Second.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.Third.Name,
                InlineButtonsStorage.Third.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.MovePrevShow.Name,
                InlineButtonsStorage.MovePrevShow.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.BackToMenu.Name,
                InlineButtonsStorage.BackToMenu.CallBackData),
        },
    });

    public static InlineKeyboardMarkup GetProblemFoursButtonsKeyboard = new(new[]
    {
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.First.Name,
                InlineButtonsStorage.First.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.Second.Name,
                InlineButtonsStorage.Second.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.MovePrevShow.Name,
                InlineButtonsStorage.MovePrevShow.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.BackToMenu.Name,
                InlineButtonsStorage.BackToMenu.CallBackData),
        },
    });

    public static InlineKeyboardMarkup GetBackKeyboard = new(new[]
    {
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.MovePrevShow.Name,
                InlineButtonsStorage.MovePrevShow.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.BackToMenu.Name,
                InlineButtonsStorage.BackToMenu.CallBackData),
        },
    });

    public static InlineKeyboardMarkup GetAddressKeyboard = new(new[]
    {
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.FirstAddressPlace.Name,
                InlineButtonsStorage.FirstAddressPlace.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.SecondAddressPlace.Name,
                InlineButtonsStorage.SecondAddressPlace.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.ThirdAddressPlace.Name,
                InlineButtonsStorage.ThirdAddressPlace.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.FourAddressPlace.Name,
                InlineButtonsStorage.FourAddressPlace.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.FiveAddressPlace.Name,
                InlineButtonsStorage.FiveAddressPlace.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.BackToMenu.Name,
                InlineButtonsStorage.BackToMenu.CallBackData),
        },
    });

    public static InlineKeyboardMarkup GetQuestionKeyboard = new(new[]
    {
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.YesSendPhoto.Name,
                InlineButtonsStorage.YesSendPhoto.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.NoSendPhoto.Name,
                InlineButtonsStorage.NoSendPhoto.CallBackData),
        }
    });

    public static InlineKeyboardMarkup GetVerificationDataKeyboard = new(new[]
    {
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.SendApplication.Name,
                InlineButtonsStorage.SendApplication.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.CancelApplication.Name,
                InlineButtonsStorage.CancelApplication.CallBackData),
        }
    });

    public static InlineKeyboardMarkup GetMenuKeyboard = new(new[]
    {
        new[]
        {
            InlineKeyboardButton.WithCallbackData(InlineButtonsStorage.BackToMenu.Name,
                InlineButtonsStorage.BackToMenu.CallBackData),
        }
    });
}