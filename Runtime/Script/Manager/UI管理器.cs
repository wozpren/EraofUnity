using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class UI������ : ����������<UI������>
{
    private Dictionary<string, ����UI> UICollection = new Dictionary<string, ����UI>();
    private List<����UI> UpdateCollection = new List<����UI>();
    private Stack<(����UI,object[])> UIStack = new Stack<(����UI, object[])>();



    public ����UI ��ȡUI(string name)
    {
        if (!UICollection.ContainsKey(name))
        {
            var t = System.Type.GetType(name);
            var ui = (����UI)System.Activator.CreateInstance(t);
            UICollection.Add(name, ui);

            return ui;
        }

        return UICollection[name];
    }


    public T ��ȡUI<T>() where T : ����UI, new()
    {
        var name = typeof(T).Name;
        if(!UICollection.ContainsKey(name))
        {
            ��ʼ��UI<T>();
        }

        return UICollection[name] as T;
    }

    public T ��ȡUI<T>(string name) where T : ����UI, new()
    {
        if (!UICollection.ContainsKey(name))
        {
            Debug.LogError("������UIδ����");
            return null;
        }
        return UICollection[name] as T;
    }


    public void ��ʼ��UI<T>() where T : ����UI, new()
    {
        var ui = new T();
        var name = ui.GetType().Name;


        UICollection.Add(name, ui);
    }

    public override void ����()
    {
        foreach (var updater in UpdateCollection)
        {
            updater.����();
        }
    }

    public bool ����(string name, params object[] parms)
    {
        if (!UICollection.ContainsKey(name))
            return false;

        if (UICollection[name].��(parms))
        {
            if (UIStack.Count != 0)
            {
                var ui = UIStack.Peek();
                ui.Item1.�ر�();
            }
            UIStack.Push((UICollection[name], parms));
            return true;
        }
        return false;
    }

    public bool ����<T>(params object[] parms) where T : ����UI, new()
    {
        var name = typeof(T).Name;

        if (!UICollection.ContainsKey(name))
        {
            ��ʼ��UI<T>();
        }

        if (UICollection[name].��(parms))
        {

            if (UIStack.Count != 0)
            {
                var ui = UIStack.Peek();
                ui.Item1.�ر�();
            }
            UIStack.Push((UICollection[name], parms));
            return true;
        }
        return false;
    }

    /// <summary>
    /// �벻Ҫ����
    /// </summary>
    /// <param name="ui"></param>
    public void UIOnOpen(����UI ui)
    {
        UpdateCollection.Add(ui);        
    }

    /// <summary>
    /// �벻Ҫ����
    /// </summary>
    /// <param name="ui"></param>
    public void UIOnClose(����UI ui)
    {
        UpdateCollection.Remove(ui);
    }

    /// <summary>
    /// �ر����� UI������� UI ջ
    /// </summary>
    public void CloseAllUI()
    {
        UIStack.Clear();
        for (int i = UpdateCollection.Count - 1; i >= 0; i--)
        {
            if (UpdateCollection[i].Name != "Loading")
                UpdateCollection[i].�ر�();
        }
    }


    public void Back()
    {
        if (UIStack.Count != 0)
        {
            UIStack.Pop().Item1.�ر�();
            if (UIStack.Count != 0)
            {
                var t = UIStack.Peek();
                t.Item1.��(t.Item2);
            }
        }
    }

    internal void OutUpdate(����UI ui)
    {
    }
}