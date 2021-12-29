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

public static class EventManager
{
    private static Dictionary<string, IEventInfo> actions = new Dictionary<string, IEventInfo>();

    public static void AddEvent(string name)
    {
        if (!actions.ContainsKey(name))
        {
            actions.Add(name, new EventInfo());
        }
        else
        {
            Debug.Log("事件已存在");
        }
    }
    public static void AddEvent<T>(string name)
    {
        if (!actions.ContainsKey(name))
        {
            actions.Add(name, new EventInfo<T>());
        }
    }
    public static void AddEvent<T1, T2>(string name)
    {
        if (!actions.ContainsKey(name))
        {
            actions.Add(name, new EventInfo<T1, T2>());
        }
    }

    public static void AddFunc<R>(string name)
    {
        if (!actions.ContainsKey(name))
        {
            actions.Add(name, new FuncInfo<R>());
        }
    }

    public static void AddFunc<R, T>(string name)
    {
        if (!actions.ContainsKey(name))
        {
            actions.Add(name, new FuncInfo<R, T>());
        }
    }


    public static void AddListener(string name, UnityAction action)
    {
        try
        {
            if (actions.ContainsKey(name))
            {
                (actions[name] as EventInfo).action += action;
            }
            else
            {
                Debug.LogError($"不存在 {name} 事件");
            }
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("泛型填写错误");
            Debug.LogError(e.Message);
        }
    }
    public static void AddListener<T>(string name, UnityAction<T> action)
    {
        try
        {
            if (actions.ContainsKey(name))
                (actions[name] as EventInfo<T>).action += action;
            else
                Debug.LogError($"不存在 {name} 事件");
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("泛型填写错误");
            Debug.LogError(e.Message);
        }
    }
    public static void AddListener<T1, T2>(string name, UnityAction<T1, T2> action)
    {
        try
        {
            if (actions.ContainsKey(name))
                (actions[name] as EventInfo<T1, T2>).action += action;
            else
                Debug.LogError($"不存在 {name} 事件");
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("泛型填写错误");
            Debug.LogError(e.Message);
        }
    }

    public static void AddListener<T, R>(string name, Func<T, R> action)
    {
        try
        {
            if (actions.ContainsKey(name))
                (actions[name] as FuncInfo<T, R>).action += action;
            else
                Debug.LogError($"不存在 {name} 事件");
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("泛型填写错误");
            Debug.LogError(e.Message);
        }
    }

    public static void SetListener<R>(string name, Func<R> action)
    {
        try
        {
            if (actions.ContainsKey(name))
                (actions[name] as FuncInfo<R>).action = action;
            else
                Debug.LogError($"不存在 {name} 事件");
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("泛型填写错误");
            Debug.LogError(e.Message);
        }
    }


    public static void DelListener(string name, UnityAction action)
    {
        try
        {
            if (actions.ContainsKey(name))
            {
                (actions[name] as EventInfo).action -= action;
            }
            else
            {
                Debug.LogError($"不存在 {name} 事件");
            }
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("泛型填写错误");
            Debug.LogError(e.Message);
        }
    }

    public static int GetEventCount(string name)
    {
        if (actions.ContainsKey(name) && (actions[name] as EventInfo).action != null)
        {
            return (actions[name] as EventInfo).action.GetInvocationList().Length;
        }
        return 0;
    }

    public static void DelListener<T>(string name, UnityAction<T> action)
    {
        try
        {
            if (actions.ContainsKey(name))
                (actions[name] as EventInfo<T>).action -= action;
            else
                Debug.LogError($"不存在 {name} 事件");
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("泛型填写错误");
            Debug.LogError(e.Message);
        }
    }
    public static void DelListener<T1, T2>(string name, UnityAction<T1, T2> action)
    {
        try
        {
            if (actions.ContainsKey(name))
                (actions[name] as EventInfo<T1, T2>).action -= action;
            else
                Debug.LogError($"不存在 {name} 事件");
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("泛型填写错误");
            Debug.LogError(e.Message);
        }
    }

    public static void UnsetListener<R>(string name)
    {
        try
        {
            if (actions.ContainsKey(name))
                (actions[name] as FuncInfo<R>).action = null;
            else
                Debug.LogError($"不存在 {name} 事件");
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("泛型填写错误");
            Debug.LogError(e.Message);
        }
    }


    public static void Invoke(string name)
    {
        try
        {
            if (actions.ContainsKey(name) && (actions[name] as EventInfo).action != null)
            {
                (actions[name] as EventInfo).action.Invoke();
            }
            else
            {
                Debug.Log($"不存在 {name} 事件或无触发事件");
            }
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("泛型填写错误");
            Debug.LogError(e.Message);
        }
    }
    public static void Invoke<T>(string name, T parameter)
    {
        if (actions.ContainsKey(name) && (actions[name] as EventInfo<T>).action != null)
        {
            (actions[name] as EventInfo<T>).action.Invoke(parameter);
        }
        else
        {
            Debug.Log($"不存在 {name} 事件或无触发事件");
        }
    }
    public static void Invoke<T1, T2>(string name, T1 parameter1, T2 parameter2)
    {
        try
        {
            if (actions.ContainsKey(name) && (actions[name] as EventInfo<T1, T2>).action != null)
            {
                (actions[name] as EventInfo<T1, T2>).action.Invoke(parameter1, parameter2);
            }
            else
            {
                Debug.Log($"不存在 {name} 事件或无触发事件");
            }
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("泛型填写错误");
            Debug.LogError(e.Message);
        }
    }

    public static R Call<R>(string name)
    {
        if (actions.ContainsKey(name) && (actions[name] as FuncInfo<R>).action != null)
        {
            return (actions[name] as FuncInfo<R>).action.Invoke();
        }
        else
        {
            Debug.Log($"不存在 {name} 事件或无触发事件");
            return default(R);
        }
    }

    public static Delegate[] GetFunc<T, R>(string name)
    {
        if (actions.ContainsKey(name) && (actions[name] as FuncInfo<T, R>).action != null)
        {
            return (actions[name] as FuncInfo<T, R>).action.GetInvocationList();
        }
        else
        {
            Debug.Log($"不存在 {name} 事件或无触发事件");
            return null;
        }
    }

}
