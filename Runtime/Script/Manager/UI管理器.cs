using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class UI管理器 : 基础管理器<UI管理器>
{
    private Dictionary<string, 基础UI> UICollection = new Dictionary<string, 基础UI>();
    private List<基础UI> UpdateCollection = new List<基础UI>();
    private Stack<(基础UI,object[])> UIStack = new Stack<(基础UI, object[])>();



    public 基础UI 获取UI(string name)
    {
        if (!UICollection.ContainsKey(name))
        {
            var t = System.Type.GetType(name);
            var ui = (基础UI)System.Activator.CreateInstance(t);
            UICollection.Add(name, ui);

            return ui;
        }

        return UICollection[name];
    }


    public T 获取UI<T>() where T : 基础UI, new()
    {
        var name = typeof(T).Name;
        if(!UICollection.ContainsKey(name))
        {
            初始化UI<T>();
        }

        return UICollection[name] as T;
    }

    public T 获取UI<T>(string name) where T : 基础UI, new()
    {
        if (!UICollection.ContainsKey(name))
        {
            Debug.LogError("该名称UI未创建");
            return null;
        }
        return UICollection[name] as T;
    }


    public void 初始化UI<T>() where T : 基础UI, new()
    {
        var ui = new T();
        var name = ui.GetType().Name;


        UICollection.Add(name, ui);
    }

    public override void 更新()
    {
        foreach (var updater in UpdateCollection)
        {
            updater.更新();
        }
    }

    public bool 导航(string name, params object[] parms)
    {
        if (!UICollection.ContainsKey(name))
            return false;

        if (UICollection[name].打开(parms))
        {
            if (UIStack.Count != 0)
            {
                var ui = UIStack.Peek();
                ui.Item1.关闭();
            }
            UIStack.Push((UICollection[name], parms));
            return true;
        }
        return false;
    }

    public bool 导航<T>(params object[] parms) where T : 基础UI, new()
    {
        var name = typeof(T).Name;

        if (!UICollection.ContainsKey(name))
        {
            初始化UI<T>();
        }

        if (UICollection[name].打开(parms))
        {

            if (UIStack.Count != 0)
            {
                var ui = UIStack.Peek();
                ui.Item1.关闭();
            }
            UIStack.Push((UICollection[name], parms));
            return true;
        }
        return false;
    }

    /// <summary>
    /// 请不要调用
    /// </summary>
    /// <param name="ui"></param>
    public void UIOnOpen(基础UI ui)
    {
        UpdateCollection.Add(ui);        
    }

    /// <summary>
    /// 请不要调用
    /// </summary>
    /// <param name="ui"></param>
    public void UIOnClose(基础UI ui)
    {
        UpdateCollection.Remove(ui);
    }

    /// <summary>
    /// 关闭所有 UI，并清除 UI 栈
    /// </summary>
    public void CloseAllUI()
    {
        UIStack.Clear();
        for (int i = UpdateCollection.Count - 1; i >= 0; i--)
        {
            if (UpdateCollection[i].Name != "Loading")
                UpdateCollection[i].关闭();
        }
    }


    public void Back()
    {
        if (UIStack.Count != 0)
        {
            UIStack.Pop().Item1.关闭();
            if (UIStack.Count != 0)
            {
                var t = UIStack.Peek();
                t.Item1.打开(t.Item2);
            }
        }
    }

    internal void OutUpdate(基础UI ui)
    {
    }
}