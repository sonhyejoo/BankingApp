namespace BankingApp.Utils;

public class Singleton<T> where T : new()
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance is null)
            {
                _instance = new T();
            }
            
            return _instance;
        }
    }
}