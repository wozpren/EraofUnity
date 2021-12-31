using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using System;

public class UI������ : ����������<UI������>
{
    private Dictionary<string, ����ҳ> pageCollection = new Dictionary<string, ����ҳ>();
    private Dictionary<string, ������ͼ> UICollection = new Dictionary<string, ������ͼ>();
    private List<������ͼ> UpdateCollection = new List<������ͼ>();
    private Stack<(������ͼ,object[])> UIStack = new Stack<(������ͼ, object[])>();

    private Canvas root;

    public ������ͼ ��ȡ��ͼ(string name)
    {
        if (!UICollection.ContainsKey(name))
        {
            var t = System.Type.GetType(name);
            var ui = (������ͼ)System.Activator.CreateInstance(t);
            UICollection.Add(name, ui);

            return ui;
        }

        return UICollection[name];
    }
    public T ��ȡ��ͼ<T>() where T : ������ͼ, new()
    {
        var name = typeof(T).Name;
        if(!UICollection.ContainsKey(name))
        {
            ��ʼ����ͼ<T>();
        }

        return UICollection[name] as T;
    }

    public T ��ȡҳ��<T>() where T : ����ҳ
    {
        var name = typeof(T).Name;

        try
        {
            return pageCollection[name] as T;
        }
        catch (KeyNotFoundException ex)
        {
            Debug.LogError("�����ڸ�ҳ��");
            Debug.LogException(ex);
            return null;
        }
    }
    public T ��ȡ��ͼ<T>(string name) where T : ������ͼ, new()
    {
        if (!UICollection.ContainsKey(name))
        {
            Debug.LogError("������UIδ����");
            return null;
        }
        return UICollection[name] as T;
    }

    public override void ��ʼ��()
    {
        root = GameObject.Find("UI").GetComponent<Canvas>();

        Debug.Log("��ȡҳ��Ԥ����");
        var gs = Resources.LoadAll<GameObject>("Page");

        foreach (var g in gs)
        {
            var obj = GameObject.Instantiate(g, root.transform);
            try
            {
                if (obj.TryGetComponent(out ����ҳ ҳ))
                {
                    pageCollection.Add(ҳ.name, ҳ);
                }
            }
            catch (ArgumentException ex)
            {
                Debug.LogError("���ظ��� key: " + g.name);
                Debug.LogException(ex);
                GameObject.Destroy(obj);
            }
        }

        Resources.UnloadUnusedAssets();
    }


    public void ��ʼ����ͼ<T>() where T : ������ͼ, new()
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

    public bool ����(string ����, params object[] ����)
    {
        if (!UICollection.ContainsKey(����))
            return false;

        if (UICollection[����].��(����))
        {
            if (UIStack.Count != 0)
            {
                var ui = UIStack.Peek();
                ui.Item1.�ر�();
            }
            UIStack.Push((UICollection[����], ����));
            return true;
        }
        return false;
    }

    public bool ����<T>(params object[] ����) where T : ������ͼ, new()
    {
        var name = typeof(T).Name;

        if (!UICollection.ContainsKey(name))
        {
            ��ʼ����ͼ<T>();
        }

        if (UICollection[name].��(����))
        {

            if (UIStack.Count != 0)
            {
                var ui = UIStack.Peek();
                ui.Item1.�ر�();
            }
            UIStack.Push((UICollection[name], ����));
            return true;
        }
        return false;
    }

    /// <summary>
    /// �벻Ҫ����
    /// </summary>
    /// <param name="ui"></param>
    public void UIOnOpen(������ͼ ui)
    {
        UpdateCollection.Add(ui);
        pageCollection[ui.page].Open();
    }

    /// <summary>
    /// �벻Ҫ����
    /// </summary>
    /// <param name="ui"></param>
    public void UIOnClose(������ͼ ui)
    {
        UpdateCollection.Remove(ui);
        pageCollection[ui.page].Close();
    }

    /// <summary>
    /// �ر�������ͼ���������ͼջ
    /// </summary>
    public void �ر�������ͼ()
    {
        UIStack.Clear();
        for (int i = UpdateCollection.Count - 1; i >= 0; i--)
        {
            UpdateCollection[i].�ر�();
        }
    }


    public void ����()
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
}