using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct ��Ϊ��
{
    public int ����;
    public int �ؿ��;
    //������������ʱ����Ϊ�������
    public int ���ٿ��;
    public int СѨ���;
    public int ֱ�����;
    public int ������;
    public int �鰮;
    public int ����Ϊ;
    public int �ɾ͸�;
    public int ��ʹ;
    public int ����;
    public int ����;
    public int ¶��;
    public int ����;
    public int ����;
    public int �־�;
}

public struct �о���
{
    public int ��˳;
    public int ����;
    public int ����;
    public int ϰ��;
    public int �߳�;
    public int ʹ��;
    public int �ֲ�;
    public int ����;
    public int ����;
    public int �ؿ��;
    //������������ʱ����Ϊ�������
    public int ���ٿ��;
    public int СѨ���;
    public int ֱ�����;
    public int ������;

    public int СѨ��;
    public int ֱ����;
}



public class ���̹����� : ����������<���̹�����>
{
    /*--------------
    ��������
    


    --------------*/

    public List<��ɫ> ������Ա = new List<��ɫ>();

    public int ������;
    public int ����;
    public int ��������;

    public ��ɫ ��ȡ��Ա(string ��ʶ)
    {
        if(��ʶ == "��Ϊִ����")
        {
            return ������Ա[������];
        }
        else if (��ʶ == "��Ϊִ����")
        {
            return ������Ա[��������];
        }
        else if (��ʶ == "����")
        {
            return ������Ա[����];
        }
        else if(int.TryParse(��ʶ, out int id))
        {
            return ������Ա[id];
        }
        else
        {
            Debug.LogError("������\"" + ��ʶ + "\"�ĳ�Ա");
            return null;
        }
    }
}
