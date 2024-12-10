namespace ConsoleAppTetsBot.org.example.EmulatorBd;

public class EntityHistoryShowManager
{
    public List<EntityHistoryShow> EntityHistoryShows { get; } = new List<EntityHistoryShow>()
    {
        new EntityHistoryShow
        {
            Id = "001", IsActive = "завершена", AddressOfPlace = "Лодочная", NumberCabinet = "405",
            NumberPhone = "89104968864", DesciptionOfProblem = "сломаляс принтер", DateTime = DateTime.Now
        }
    };
}