using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface �жϽӿ�
{
    bool ִ��();
}

public enum �ȽϷ�
{
    ����, С��, ����, ���ڵ���, С�ڵ���
}


public struct ��ֵ�ж�
{
    public string ����;
    public �ȽϷ� �ȽϷ�;
    public int ��ֵ;

    public bool �ж�(int b)
    {
        return ����.�ж�(�ȽϷ�, b, ��ֵ);
    }
}

public class ��ɫ��ֵ�ж� : �жϽӿ�
{
    public string �ֵ���;
    public string ��ɫ��ʶ;
    public ��ֵ�ж�[] �ж϶���;

    public bool ִ��()
    {
        var ��ɫ = ���ݹ�����.ʵ��.��ȡ��ɫ(��ɫ��ʶ);
        var �ֵ� = ��ɫ.��ȡ�ֵ�(�ֵ���);
        foreach (var �� in �ж϶���)
        {
            if (�ֵ�.TryGetValue(��.����, out int ֵ))
            {
                if(!��.�ж�(ֵ))
                {
                    return false;
                }
            }
            else
            {
                if (!��.�ж�(0))
                {
                    return false;
                }
            }
        }
        return true;
    }
}

public class ��ɫ״̬�ж� : �жϽӿ�
{
    public string ��ɫ��ʶ;
    public List<string> ��������;

    public bool ִ��()
    {
        var ��ɫ = ���ݹ�����.ʵ��.��ȡ��ɫ(��ɫ��ʶ);
        foreach (var ���� in ��������)
        {
            if(!��ɫ.���⾭��.Contains(����))
            {
                return false;
            }
        }
        return true;
    }
}