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



    public ����UI GetUI(string name)
    {
        if (!UICollection.ContainsKey(name))
        {
            var t = System.Type.GetType(name);
            var ui = (����UI)System.Activator.CreateInstance(t);
            if (!ui.Single)
            {
                name += "_" + ui.obj.GetInstanceID();
            }
            UICollection.Add(name, ui);

            return ui;
        }

        return UICollection[name];
    }


    public T GetUI<T>() where T : ����UI, new()
    {
        var name = typeof(T).Name;
        if(!UICollection.ContainsKey(name))
        {
            InitUI<T>();
        }

        return UICollection[name] as T;
    }

    public T GetUI<T>(string name) where T : ����UI, new()
    {
        if (!UICollection.ContainsKey(name))
        {
            Debug.LogError("������UIδ����");
            return null;
        }
        return UICollection[name] as T;
    }


    public void InitUI<T>() where T : ����UI, new()
    {
        var ui = new T();
        var name = ui.GetType().Name;

        if (!ui.Single)
        {
            name += "_" + ui.obj.GetInstanceID();
        }

        UICollection.Add(name, ui);
    }

    public override void Update()
    {
        foreach (var updater in UpdateCollection)
        {
            updater.Update();
        }
    }

    public bool Navigation(string name, params object[] parms)
    {
        if (!UICollection.ContainsKey(name))
            return false;

        if (UICollection[name].Open(parms))
        {
            if (UIStack.Count != 0)
            {
                var ui = UIStack.Peek();
                ui.Item1.Close();
            }
            UIStack.Push((UICollection[name], parms));
            return true;
        }
        return false;
    }

    public bool Navigation<T>(params object[] parms) where T : ����UI, new()
    {
        var name = typeof(T).Name;

        if (!UICollection.ContainsKey(name))
        {
            InitUI<T>();
        }

        if (UICollection[name].Open(parms))
        {

            if (UIStack.Count != 0)
            {
                var ui = UIStack.Peek();
                ui.Item1.Close();
            }
            UIStack.Push((UICollection[name], parms));
            return true;
        }
        return false;
    }

    public void UIOnOpen(����UI ui)
    {
        UpdateCollection.Add(ui);        
    }

    public void UIOnClose(����UI ui)
    {
        UpdateCollection.Remove(ui);
    }


    public void CloseAllUI()
    {
        UIStack.Clear();
        for (int i = UpdateCollection.Count - 1; i >= 0; i--)
        {
            if (UpdateCollection[i].Name != "Loading")
                UpdateCollection[i].Close();
        }
    }


    public void Back()
    {
        if (UIStack.Count != 0)
        {
            UIStack.Pop().Item1.Close();
            if (UIStack.Count != 0)
            {
                var t = UIStack.Peek();
                t.Item1.Open(t.Item2);
            }
        }
    }

    internal void OutUpdate(����UI ui)
    {
    }
}