using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public abstract class ������ͼ<T> : ������ͼ where T: ����ҳ
{
    public T ҳ��;

    public ������ͼ()
    {
        page = ҳ��.GetType().Name;
        ҳ�� = UI������.ʵ��.��ȡҳ��<T>();
    }
}
public abstract class ������ͼ 
{
    public bool �򿪵� { get;private set;  }
    public string page;

    public virtual bool ��(params object[] ����)
    {
        if (�򿪵�) return false;

        �򿪵� = true;
        UI������.ʵ��.UIOnOpen(this);
        return true;
    }

    public virtual bool �ر�()
    {
        if (!�򿪵�) return false;

        �򿪵� = false;

        EventSystem.current.SetSelectedGameObject(null);
        UI������.ʵ��.UIOnClose(this);

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
