using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ���ݹ����� : ����������<���ݹ�����>
{
    public ������� ��ǰ�������;



    public ��ɫ ��ȡ��ɫ(string ��ʶ)
    {
        ��ɫ ��ɫ;
        if (��ʶ == "��Ϊ��ִ����")
        {
            ��ɫ = ���̹�����.ʵ��.��ȡ��Ա(��ʶ);
        }
        else if(��ʶ == "��Ϊִ����")
        {
            ��ɫ = ���̹�����.ʵ��.��ȡ��Ա(��ʶ);
        }
        else if (��ʶ == "����")
        {
            ��ɫ = ���̹�����.ʵ��.��ȡ��Ա(��ʶ);
        }
        else
        {
            ��ɫ = ��ǰ�������.ӵ�н�ɫ.First(c => c.���� == ��ʶ);
        }

        if(��ɫ == null)
        {
            Debug.LogError("�����ڱ�ʶΪ\"" + ��ʶ + "\"�Ľ�ɫ");
            return null;
        }
        else
        {
            return ��ɫ;
        }
    }


}


public class �������
{
    public List<��ɫ> ӵ�н�ɫ = new List<��ɫ>();



}