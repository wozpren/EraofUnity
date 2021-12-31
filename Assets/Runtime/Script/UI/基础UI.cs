using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public abstract class ����UI<T> where T: ����ҳ
{
    public T Page;

}
public abstract class ����UI 
{
    public bool IsOpen { get;private set;  }
    public string page;


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

    /// <summary>
    /// ÿ֡����
    /// </summary>
    public virtual void ����()
    {

    }

    /// <summary>
    /// �ֶ����ã����ڸ���ҳ��
    /// </summary>
    public virtual void ˢ��()
    {

    }
}
