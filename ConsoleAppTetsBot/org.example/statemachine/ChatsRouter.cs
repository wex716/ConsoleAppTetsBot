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
}