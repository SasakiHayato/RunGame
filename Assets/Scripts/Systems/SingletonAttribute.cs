
/// <summary>
/// Singletonにするクラスに継承するクラス
/// </summary>
/// <typeparam name="Singleton">派生クラス</typeparam>

public class SingletonAttribute<Singleton> where Singleton : class
{
    Singleton _sigleton = default;
    public static Singleton Access => s_instance._sigleton;

    private static SingletonAttribute<Singleton> s_instance = null;
    public static void SetInstance(Singleton singleton)
    {
        if (s_instance == null)
        {
            s_instance = new SingletonAttribute<Singleton>();
            s_instance._sigleton = singleton;
            s_instance.SetUp();
        }
    }

    public virtual void SetUp() { }
    public void Destory() => s_instance.Destory();
}
