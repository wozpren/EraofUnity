using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ״̬�жϽӿ�
{
    bool ִ��();
}

public enum �ȽϷ�
{
    ����, С��, ����, ���ڵ���, С�ڵ���
}



public class ���� : ״̬�жϽӿ�
{
    public string ��ɫ��ʶ;
    public string ��������;
    public int ��ֵ;
    public �ȽϷ� �ȽϷ�;

    public bool ִ��()
    {
        var ��ɫ = ���ݹ�����.ʵ��.��ȡ��ɫ(��ɫ��ʶ);
        if(��ɫ.����.TryGetValue(��������, out int ֵ))
        {
            ����.�ж�(�ȽϷ�, ֵ, ��ֵ);
        }
        return false;
    }
}

public class ���� : ״̬�жϽӿ�
{
    public string ��ɫ��ʶ;
    public string ��������;
    public int ��ֵ;
    public �ȽϷ� �ȽϷ�;

    public bool ִ��()
    {
        var ��ɫ = ���ݹ�����.ʵ��.��ȡ��ɫ(��ɫ��ʶ);
        if (��ɫ.����.TryGetValue(��������, out int ֵ))
        {
            ����.�ж�(�ȽϷ�, ֵ, ��ֵ);
        }
        return false;
    }
}

public class ���� : ״̬�жϽӿ�
{
    public string ��ɫ��ʶ;
    public string ��������;
    public int ��ֵ;
    public �ȽϷ� �ȽϷ�;

    public bool ִ��()
    {
        var ��ɫ = ���ݹ�����.ʵ��.��ȡ��ɫ(��ɫ��ʶ);
        if (��ɫ.����.TryGetValue(��������, out int ֵ))
        {
            ����.�ж�(�ȽϷ�, ֵ, ��ֵ);
        }
        return false;
    }
}

public class ��ӡ : ״̬�жϽӿ�
{
    public string ��ɫ��ʶ;
    public string ��ӡ����;
    public int ��ֵ;
    public �ȽϷ� �ȽϷ�;

    public bool ִ��()
    {
        var ��ɫ = ���ݹ�����.ʵ��.��ȡ��ɫ(��ɫ��ʶ);
        if (��ɫ.��ӡ.TryGetValue(��ӡ����, out int ֵ))
        {
            ����.�ж�(�ȽϷ�, ֵ, ��ֵ);
        }
        return false;
    }
}

public class ���⾭�� : ״̬�жϽӿ�
{
    public string ��ɫ��ʶ;
    public string ��������;

    public bool ִ��()
    {
        var ��ɫ = ���ݹ�����.ʵ��.��ȡ��ɫ(��ɫ��ʶ);
        return ��ɫ.���⾭��.Contains(��������);
    }
}

public class �츳 : ״̬�жϽӿ�
{
    public string ��ɫ��ʶ;
    public string �츳����;

    public bool ִ��()
    {
        var ��ɫ = ���ݹ�����.ʵ��.��ȡ��ɫ(��ɫ��ʶ);
        return ��ɫ.�츳.Contains(�츳����);
    }
}