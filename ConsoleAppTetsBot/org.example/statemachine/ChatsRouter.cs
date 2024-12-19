using ConsoleAppTetsBot.org.example.service;
using Microsoft.AspNetCore.Components.Forms;
using Telegram.Bot;

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
        //_botClient = new TelegramBotClient("8108328648:AAEc9MytfhK1aypmrQ__MUVBteFljBbo9zs");
    }

    public async Task<BotTextMessage> Route(long chatId, string textFromUser, InputFile photo)
    {
        if (!_routings.ContainsKey(chatId))
        {
                _routings[chatId] = new TransmittedData(chatId);
        }

        TransmittedData transmittedData = _routings[chatId];
        
        transmittedData.DataStorage.Add("userId", chatId);

        return _serviceManager.ProcessBotUpdate(textFromUser, transmittedData);
    }
}




        //     string filePath = null;
        //     
        //     try
        //     {
        //         if (photo != null)
        //         {
        //             filePath = Path.Combine("photos", $"{Guid.NewGuid()}.jpg");
        //             using (var fileStream = new FileStream(filePath, FileMode.Create))
        //             {
        //                 await _botClient.DownloadFile(photo.ToString(), fileStream);
        //             }
        //     
        //             transmittedData.DataStorage.Add("photo", photo);
        //         }
        //     
        //         transmittedData = _routings[chatId];
        //         
        //         return _serviceManager.ProcessBotUpdate(textFromUser, transmittedData);
        //     }
        //     
        //     catch (Exception ex)
        //     {
        //         return new BotTextMessage("пиздец");
        //     }
    