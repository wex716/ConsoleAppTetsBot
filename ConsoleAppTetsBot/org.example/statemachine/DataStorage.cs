namespace ConsoleAppTetsBot.org.example.statemachine;

public class DataStorage
{
    private Dictionary<string, object> _data;

    public DataStorage()
    {
        _data = new Dictionary<string, object>();
    }

    public void Add(string key, object value)
    {
        _data[key] = value;
    }

    public void Delete(string key)
    {
        _data.Remove(key);
    }

    public string Get(string key)
    {
        return (string)_data[key];
    }

    public void Clear()
    {
        _data.Clear();
    }
}