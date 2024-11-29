using ConsoleAppTetsBot.org.example.service;

namespace ConsoleAppTetsBot.org.example.statemachine;

public class ChatsRouter
{
    private Dictionary<long, TransmittedData> _routings;
    private ServiceManager _serviceManager;

    public ChatsRouter()
    {
        _routings = new Dictionary<long, TransmittedData>();
        _serviceManager = new ServiceManager();
    }

    public BotTextMessage Route(long chatId, string textFromUser)
    {
        if (!_routings.ContainsKey(chatId))
        {
            _routings[chatId] = new TransmittedData(chatId);
        }

        TransmittedData transmittedData = _routings[chatId];

        return _serviceManager.ProcessBotUpdate(textFromUser, transmittedData);
    }

    /*public BotTextMessage RoutePhoto(long chatId, InputFile photo, ITelegramBotClient botClient)
    {
        try
        {
            string filePath =
                Path.Combine("photos", $"{chatId}_{photo.FileType}");
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                botClient.DownloadFile(photo.FileType.ToString(), fileStream);
            }

            return new BotTextMessage("Все гуд");
        }
        catch (Exception ex)
        {
            return new BotTextMessage("Ошибка");
        }
    }*/
}