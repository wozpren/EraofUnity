using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public abstract class 基础视图<T> : 基础视图 where T: 基础页
{
    public T 页面;

    public 基础视图()
    {
        page = 页面.GetType().Name;
        页面 = UI管理器.实例.获取页面<T>();
    }
}
public abstract class 基础视图 
{
    public bool 打开的 { get;private set;  }
    public string page;

    public virtual bool 打开(params object[] 参数)
    {
        if (打开的) return false;

        打开的 = true;
        UI管理器.实例.UIOnOpen(this);
        return true;
    }

    public virtual bool 关闭()
    {
        if (!打开的) return false;

        打开的 = false;

        EventSystem.current.SetSelectedGameObject(null);
        UI管理器.实例.UIOnClose(this);

        return true;
    }

    /// <summary>
    /// 每帧调用
    /// </summary>
    public virtual void 更新()
    {

    }

    /// <summary>
    /// 手动调用，用于更新页面
    /// </summary>
    public virtual void 刷新()
    {

    }
}
