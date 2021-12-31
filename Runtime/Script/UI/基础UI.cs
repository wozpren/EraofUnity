using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public abstract class 基础UI<T> where T: 基础页
{
    public T page;

}
public abstract class 基础UI 
{
    public readonly string Name;
    public bool IsOpen { get;private set;  }

    public 基础UI()
    {
        Name = this.GetType().Name;

    }

    public virtual bool 打开(params object[] 参数)
    {
        if (IsOpen) return false;

        IsOpen = true;
        UI管理器.Instance.UIOnOpen(this);
        return true;
    }

    public virtual bool 关闭()
    {
        if (!IsOpen) return false;

        IsOpen = false;

        EventSystem.current.SetSelectedGameObject(null);
        UI管理器.Instance.UIOnClose(this);

        return true;
    }

    public virtual void 更新()
    {

    }
}
