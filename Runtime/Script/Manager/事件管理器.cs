using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IEventInfo
{

}
public class EventInfo<T1, T2> : IEventInfo
{
    public UnityAction<T1, T2> action;
}
public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> action;
}
public class EventInfo : IEventInfo
{
    public UnityAction action;
}

public class FuncInfo<R> : IEventInfo
{
    public Func<R> action;
}

public class FuncInfo<T, R> : IEventInfo
{
    public Func<T, R> action;
}

public static class �¼�������
{
    private static Dictionary<string, IEventInfo> actions = new Dictionary<string, IEventInfo>();

    public static void ����¼�(string name)
    {
        if (!actions.ContainsKey(name))
        {
            actions.Add(name, new EventInfo());
        }
        else
        {
            Debug.Log("�¼��Ѵ���");
        }
    }
    public static void ����¼�<T>(string name)
    {
        if (!actions.ContainsKey(name))
        {
            actions.Add(name, new EventInfo<T>());
        }
    }
    public static void ����¼�<T1, T2>(string name)
    {
        if (!actions.ContainsKey(name))
        {
            actions.Add(name, new EventInfo<T1, T2>());
        }
    }

    public static void ��ӻش��¼�<R>(string name)
    {
        if (!actions.ContainsKey(name))
        {
            actions.Add(name, new FuncInfo<R>());
        }
    }

    public static void ��ӻش��¼�<R, T>(string name)
    {
        if (!actions.ContainsKey(name))
        {
            actions.Add(name, new FuncInfo<R, T>());
        }
    }


    public static void ��Ӽ�����(string name, UnityAction action)
    {
        try
        {
            if (actions.ContainsKey(name))
            {
                (actions[name] as EventInfo).action += action;
            }
            else
            {
                Debug.LogError($"������ {name} �¼�");
            }
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("������д����");
            Debug.LogError(e.Message);
        }
    }
    public static void ��Ӽ�����<T>(string name, UnityAction<T> action)
    {
        try
        {
            if (actions.ContainsKey(name))
                (actions[name] as EventInfo<T>).action += action;
            else
                Debug.LogError($"������ {name} �¼�");
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("������д����");
            Debug.LogError(e.Message);
        }
    }
    public static void ��Ӽ�����<T1, T2>(string name, UnityAction<T1, T2> action)
    {
        try
        {
            if (actions.ContainsKey(name))
                (actions[name] as EventInfo<T1, T2>).action += action;
            else
                Debug.LogError($"������ {name} �¼�");
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("������д����");
            Debug.LogError(e.Message);
        }
    }

    public static void ��Ӽ�����<T, R>(string name, Func<T, R> action)
    {
        try
        {
            if (actions.ContainsKey(name))
                (actions[name] as FuncInfo<T, R>).action += action;
            else
                Debug.LogError($"������ {name} �¼�");
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("������д����");
            Debug.LogError(e.Message);
        }
    }

    /// <summary>
    /// ֱ�Ӹ��Ƕ�Ӧ���¼�������
    /// </summary>
    /// <typeparam name="R"></typeparam>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public static void ���ü�����<R>(string name, Func<R> action)
    {
        try
        {
            if (actions.ContainsKey(name))
                (actions[name] as FuncInfo<R>).action = action;
            else
                Debug.LogError($"������ {name} �¼�");
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("������д����");
            Debug.LogError(e.Message);
        }
    }


    public static void ɾ��������(string name, UnityAction action)
    {
        try
        {
            if (actions.ContainsKey(name))
            {
                (actions[name] as EventInfo).action -= action;
            }
            else
            {
                Debug.LogError($"������ {name} �¼�");
            }
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("������д����");
            Debug.LogError(e.Message);
        }
    }

    public static int ��ȡ�¼�����(string name)
    {
        if (actions.ContainsKey(name) && (actions[name] as EventInfo).action != null)
        {
            return (actions[name] as EventInfo).action.GetInvocationList().Length;
        }
        return 0;
    }

    public static void ��ȡ�¼�����<T>(string name, UnityAction<T> action)
    {
        try
        {
            if (actions.ContainsKey(name))
                (actions[name] as EventInfo<T>).action -= action;
            else
                Debug.LogError($"������ {name} �¼�");
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("������д����");
            Debug.LogError(e.Message);
        }
    }
    public static void ��ȡ�¼�����<T1, T2>(string name, UnityAction<T1, T2> action)
    {
        try
        {
            if (actions.ContainsKey(name))
                (actions[name] as EventInfo<T1, T2>).action -= action;
            else
                Debug.LogError($"������ {name} �¼�");
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("������д����");
            Debug.LogError(e.Message);
        }
    }

    public static void ����¼�����<R>(string name)
    {
        try
        {
            if (actions.ContainsKey(name))
                (actions[name] as FuncInfo<R>).action = null;
            else
                Debug.LogError($"������ {name} �¼�");
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("������д����");
            Debug.LogError(e.Message);
        }
    }


    public static void ����(string name)
    {
        try
        {
            if (actions.ContainsKey(name) && (actions[name] as EventInfo).action != null)
            {
                (actions[name] as EventInfo).action.Invoke();
            }
            else
            {
                Debug.Log($"������ {name} �¼����޴����¼�");
            }
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("������д����");
            Debug.LogError(e.Message);
        }
    }
    public static void ����<T>(string name, T parameter)
    {
        if (actions.ContainsKey(name) && (actions[name] as EventInfo<T>).action != null)
        {
            (actions[name] as EventInfo<T>).action.Invoke(parameter);
        }
        else
        {
            Debug.Log($"������ {name} �¼����޴����¼�");
        }
    }
    public static void ����<T1, T2>(string name, T1 parameter1, T2 parameter2)
    {
        try
        {
            if (actions.ContainsKey(name) && (actions[name] as EventInfo<T1, T2>).action != null)
            {
                (actions[name] as EventInfo<T1, T2>).action.Invoke(parameter1, parameter2);
            }
            else
            {
                Debug.Log($"������ {name} �¼����޴����¼�");
            }
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("������д����");
            Debug.LogError(e.Message);
        }
    }

    public static R ����<R>(string name)
    {
        if (actions.ContainsKey(name) && (actions[name] as FuncInfo<R>).action != null)
        {
            return (actions[name] as FuncInfo<R>).action.Invoke();
        }
        else
        {
            Debug.Log($"������ {name} �¼����޴����¼�");
            return default(R);
        }
    }

    public static Delegate[] ��ȡ�¼��б�<T, R>(string name)
    {
        if (actions.ContainsKey(name) && (actions[name] as FuncInfo<T, R>).action != null)
        {
            return (actions[name] as FuncInfo<T, R>).action.GetInvocationList();
        }
        else
        {
            Debug.Log($"������ {name} �¼����޴����¼�");
            return null;
        }
    }

}
