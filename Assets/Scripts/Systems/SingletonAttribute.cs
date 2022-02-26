
/// <summary>
/// Singletonにするクラスに継承するクラス
/// </summary>
/// <typeparam name="Sigleton">派生クラス</typeparam>

public interface ISingleton
{
    object Type();
    void SetUp();
}

public class SingletonAttribute<Singleton> where Singleton : ISingleton
{
    Singleton _sigleton = default; 

    private static SingletonAttribute<Singleton> _instance = null;
    public static void SetInstance(Singleton singleton)
    {
        if (_instance == null)
        {
            _instance = new SingletonAttribute<Singleton>();
            _instance._sigleton = singleton;
            _instance._sigleton.SetUp();
        }
    }

    public static SingletonAttribute<Singleton> GetInstance => _instance;

    public object Access() => _sigleton.Type();
    public void Destory()
    {
        _instance.Destory();
    }
}
