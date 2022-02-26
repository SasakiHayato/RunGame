
/// <summary>
/// Singletonにするクラスに継承するクラス
/// </summary>
/// <typeparam name="Sigleton">派生クラス</typeparam>

public class SingletonAttribute<Sigleton> where Sigleton : class
{
    bool _isSetUp = false;

    Sigleton _sigleton;
    public static Sigleton Access
    {
        get
        {
            if (Instance._isSetUp) return Instance._sigleton;
            else return null;
        }
    }

    private static SingletonAttribute<Sigleton> _instance = null;
    public static SingletonAttribute<Sigleton> Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SingletonAttribute<Sigleton>();
                _instance.SetUp();
            }

            return _instance;
        }
    }

    public virtual void SetUp() => _isSetUp = true;
    public void Destory() => _instance.Destory();
}
