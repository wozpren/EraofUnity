using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public abstract class ����UI<T> where T: ����ҳ
{
    public T page;

}
public abstract class ����UI 
{
    public readonly string Name;
    public bool IsOpen { get;private set;  }

    public ����UI()
    {
        Name = this.GetType().Name;

    }

    public virtual bool ��(params object[] ����)
    {
        if (IsOpen) return false;

        IsOpen = true;
        UI������.Instance.UIOnOpen(this);
        return true;
    }

    public virtual bool �ر�()
    {
        if (!IsOpen) return false;

        IsOpen = false;

        EventSystem.current.SetSelectedGameObject(null);
        UI������.Instance.UIOnClose(this);

        return true;
    }

    public virtual void ����()
    {

    }
}
