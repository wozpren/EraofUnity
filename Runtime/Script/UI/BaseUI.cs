using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseUI
{
    public readonly string Name;
    public  bool Single = true;

    public GameObject obj;

    private Canvas canvas;

    public bool IsOpen { get;private set;  }

    public bool IsFonrt;



    public BaseUI()
    {
        Name = this.GetType().Name;
        if(obj.TryGetComponent(out Canvas canvas))
        {
            this.canvas = canvas;
            canvas.enabled = false;
        }
        else
            obj.transform.localPosition = new Vector3(999999, 999999);
    }

    public virtual bool Open(params object[] parms)
    {
        if (IsOpen) return false;

        IsOpen = true;
        if (canvas != null)
            canvas.enabled = true;
        else
            obj.transform.localPosition = Vector3.zero;
        UIManager.Instance.UIOnOpen(this);
        return true;
    }

    public virtual bool Close()
    {
        if (!IsOpen) return false;

        IsOpen = false;
        if (canvas != null)
            canvas.enabled = false;
        else
            obj.transform.localPosition = new Vector3(999999, 999999);

        EventSystem.current.SetSelectedGameObject(null);
        UIManager.Instance.UIOnClose(this);

        return true;
    }

    public virtual void Update()
    {

    }


    public virtual void Destroy()
    {
        GameObject.Destroy(obj);
    }


    public static IEnumerator YieldAniFinish(Animator ani, string aniName, Action action)
    {
        yield return null;
        AnimatorStateInfo stateinfo = ani.GetCurrentAnimatorStateInfo(0);

        if (stateinfo.IsName(aniName) && (stateinfo.normalizedTime >= 1.0f))
        {
            action();
        }
        else
        {
            GameManager.Instance.StartCoroutine(YieldAniFinish(ani, aniName, action));
        }
    }

}
