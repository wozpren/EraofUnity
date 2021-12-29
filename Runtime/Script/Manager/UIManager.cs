using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class UIManager : BaseManager<UIManager>
{
    private Dictionary<string, BaseUI> UICollection = new Dictionary<string, BaseUI>();

    private List<BaseUI> UpdateCollection = new List<BaseUI>();

    private Stack<(BaseUI,object[])> UIStack = new Stack<(BaseUI, object[])>();

    public Transform Canvas { get; private set; }
    public Transform BackCanvas { get; private set; }

    private EventSystem eventSystems;
    private Camera uiCamera;
    private GameState LastState;

    public BaseUI GetUI(string name)
    {
        if (!UICollection.ContainsKey(name))
        {
            var t = System.Type.GetType(name);
            var ui = (BaseUI)System.Activator.CreateInstance(t);
            if (!ui.Single)
            {
                name += "_" + ui.obj.GetInstanceID();
            }
            UICollection.Add(name, ui);

            return ui;
        }

        return UICollection[name];
    }


    public T GetUI<T>() where T : BaseUI, new()
    {
        var name = typeof(T).Name;
        if(!UICollection.ContainsKey(name))
        {
            InitUI<T>();
        }

        return UICollection[name] as T;
    }

    public T GetUI<T>(string name) where T : BaseUI, new()
    {
        if (!UICollection.ContainsKey(name))
        {
            Debug.LogError("该名称UI未创建");
            return null;
        }
        return UICollection[name] as T;
    }


    public void InitUI<T>() where T : BaseUI, new()
    {
        var ui = new T();
        var name = ui.GetType().Name;

        if (!ui.Single)
        {
            name += "_" + ui.obj.GetInstanceID();
        }

        UICollection.Add(name, ui);
    }



    public override void Init()
    {
        Canvas = GameObject.Find("Canvas/Front").transform;
        BackCanvas = GameObject.Find("Canvas/Back").transform;
        eventSystems = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        var root = GameObject.Find("Camera");

        Object.DontDestroyOnLoad(Canvas.parent);
        Object.DontDestroyOnLoad(eventSystems);
        Object.DontDestroyOnLoad(root);
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
            if (GameManager.Instance.GameState != GameState.UI)
            {
                LastState = GameManager.Instance.GameState;
                GameManager.Instance.GameState = GameState.UI;
            }

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

    public bool Navigation<T>(params object[] parms) where T : BaseUI, new()
    {
        var name = typeof(T).Name;

        if (!UICollection.ContainsKey(name))
        {
            InitUI<T>();
        }

        if (UICollection[name].Open(parms))
        {
            if (GameManager.Instance.GameState != GameState.UI)
            {
                LastState = GameManager.Instance.GameState;
                GameManager.Instance.GameState = GameState.UI;
            }

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

    public void UIOnOpen(BaseUI ui)
    {
        UpdateCollection.Add(ui);
        
        if(GameManager.Instance.GameState != GameState.UI)
        {
            LastState = GameManager.Instance.GameState;
            GameManager.Instance.GameState = GameState.UI;
        }
    }

    public void UIOnClose(BaseUI ui)
    {
        UpdateCollection.Remove(ui);


        if (UpdateCollection.Count(ui => !ui.IsOpen && ui.IsFonrt) == 0)
        {
            GameManager.Instance.GameState = LastState;
        }
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
            else
            {
                GameManager.Instance.GameState = LastState;
            }
        }
    }

    internal void OutUpdate(BaseUI ui)
    {
    }
}