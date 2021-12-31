using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using System;

public class UI管理器 : 基础管理器<UI管理器>
{
    private Dictionary<string, 基础页> pageCollection = new Dictionary<string, 基础页>();
    private Dictionary<string, 基础视图> UICollection = new Dictionary<string, 基础视图>();
    private List<基础视图> UpdateCollection = new List<基础视图>();
    private Stack<(基础视图,object[])> UIStack = new Stack<(基础视图, object[])>();

    private Canvas root;

    public 基础视图 获取视图(string name)
    {
        if (!UICollection.ContainsKey(name))
        {
            var t = System.Type.GetType(name);
            var ui = (基础视图)System.Activator.CreateInstance(t);
            UICollection.Add(name, ui);

            return ui;
        }

        return UICollection[name];
    }
    public T 获取视图<T>() where T : 基础视图, new()
    {
        var name = typeof(T).Name;
        if(!UICollection.ContainsKey(name))
        {
            初始化视图<T>();
        }

        return UICollection[name] as T;
    }

    public T 获取页面<T>() where T : 基础页
    {
        var name = typeof(T).Name;

        try
        {
            return pageCollection[name] as T;
        }
        catch (KeyNotFoundException ex)
        {
            Debug.LogError("不存在该页面");
            Debug.LogException(ex);
            return null;
        }
    }
    public T 获取视图<T>(string name) where T : 基础视图, new()
    {
        if (!UICollection.ContainsKey(name))
        {
            Debug.LogError("该名称UI未创建");
            return null;
        }
        return UICollection[name] as T;
    }

    public override void 初始化()
    {
        root = GameObject.Find("UI").GetComponent<Canvas>();

        Debug.Log("读取页面预制体");
        var gs = Resources.LoadAll<GameObject>("Page");

        foreach (var g in gs)
        {
            var obj = GameObject.Instantiate(g, root.transform);
            try
            {
                if (obj.TryGetComponent(out 基础页 页))
                {
                    pageCollection.Add(页.name, 页);
                }
            }
            catch (ArgumentException ex)
            {
                Debug.LogError("有重复的 key: " + g.name);
                Debug.LogException(ex);
                GameObject.Destroy(obj);
            }
        }

        Resources.UnloadUnusedAssets();
    }


    public void 初始化视图<T>() where T : 基础视图, new()
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

    public bool 导航(string 名字, params object[] 参数)
    {
        if (!UICollection.ContainsKey(名字))
            return false;

        if (UICollection[名字].打开(参数))
        {
            if (UIStack.Count != 0)
            {
                var ui = UIStack.Peek();
                ui.Item1.关闭();
            }
            UIStack.Push((UICollection[名字], 参数));
            return true;
        }
        return false;
    }

    public bool 导航<T>(params object[] 参数) where T : 基础视图, new()
    {
        var name = typeof(T).Name;

        if (!UICollection.ContainsKey(name))
        {
            初始化视图<T>();
        }

        if (UICollection[name].打开(参数))
        {

            if (UIStack.Count != 0)
            {
                var ui = UIStack.Peek();
                ui.Item1.关闭();
            }
            UIStack.Push((UICollection[name], 参数));
            return true;
        }
        return false;
    }

    /// <summary>
    /// 请不要调用
    /// </summary>
    /// <param name="ui"></param>
    public void UIOnOpen(基础视图 ui)
    {
        UpdateCollection.Add(ui);
        pageCollection[ui.page].Open();
    }

    /// <summary>
    /// 请不要调用
    /// </summary>
    /// <param name="ui"></param>
    public void UIOnClose(基础视图 ui)
    {
        UpdateCollection.Remove(ui);
        pageCollection[ui.page].Close();
    }

    /// <summary>
    /// 关闭所有视图，并清除视图栈
    /// </summary>
    public void 关闭所有视图()
    {
        UIStack.Clear();
        for (int i = UpdateCollection.Count - 1; i >= 0; i--)
        {
            UpdateCollection[i].关闭();
        }
    }


    public void 返回()
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
}