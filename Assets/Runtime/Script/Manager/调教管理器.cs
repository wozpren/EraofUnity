using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class ���̹����� : ����������<���̹�����>
{
    /*--------------
    ��������
    d


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
