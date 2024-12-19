using ConsoleAppTetsBot.org.example.service;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;

namespace ConsoleAppTetsBot.org.example.statemachine;

public class ChatsRouter
{
    private Dictionary<long, TransmittedData> _routings;
    private ServiceManager _serviceManager;
    private readonly TelegramBotClient _botClient;

    public ChatsRouter()
    {
        _routings = new Dictionary<long, TransmittedData>();
        _serviceManager = new ServiceManager();
    }

    public async Task<BotTextMessage> Route(long chatId, string textFromUser, InputOnlineFile? photo = null)
    {
        if (!_routings.ContainsKey(chatId))
        {
            _routings[chatId] = new TransmittedData(chatId);
        }

        TransmittedData transmittedData = _routings[chatId];

        transmittedData.DataStorage.Add("userId", chatId);

        if (photo != null)
        {
            try
            {
                if (photo is InputOnlineFile inputOnlineFile)
                {
                    string fileId = inputOnlineFile.FileId;
                    transmittedData.DataStorage.Add("fileId", fileId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Бля фотка");
            }
        }

        return _serviceManager.ProcessBotUpdate(textFromUser, transmittedData);
    }
}