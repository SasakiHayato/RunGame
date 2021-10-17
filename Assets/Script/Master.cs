using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AssemblyUtils
using System;
using System.Reflection;
using System.Linq;

public interface IManager
{
    void SetUp();
    void ManageUpDate();
}

public class Master : MonoBehaviour
{
    AssemblyUtils m_utils = new AssemblyUtils();
    List<IManager> m_managers = new List<IManager>();

    private void Awake()
    {
        foreach (IManager manage in m_utils.Request<IManager>())
        {
            manage.SetUp();
            m_managers.Add(manage);
        }
            
    }

    void Update()
    {
        foreach (IManager manage in m_managers)
            manage.ManageUpDate();
    }
}

// https://baba-s.hatenablog.com/entry/2014/06/10/200710 参照
class AssemblyUtils
{
    // 呼び出し
    public T[] Request<T>() where T : class => CreateInterfaceInstances<T>();
    /// <summary>
    /// 現在実行中のコードを格納しているアセンブリ内の指定された
    /// インターフェイスが実装されているすべての Type を返します
    /// </summary>
    public static Type[] GetInterfaces<T>()
    {
        return Assembly.GetExecutingAssembly().
            GetTypes().Where(c => c.GetInterfaces().Any(t => t == typeof(T))).ToArray();
    }

    /// <summary>
    /// 現在実行中のコードを格納しているアセンブリ内の指定された
    /// インターフェイスが実装されているすべての Type のインスタンスを作成して返します
    /// </summary>
    public static T[] CreateInterfaceInstances<T>() where T : class
        => GetInterfaces<T>().Select(c => Activator.CreateInstance(c) as T).ToArray();
}
