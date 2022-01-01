using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class 调教管理器 : 基础管理器<调教管理器>
{
    /*--------------
    调教流程
    d


    --------------*/

    public List<角色> 参与人员 = new List<角色>();

    public int 调教者;
    public int 助手;
    public int 被调教者;

    public 角色 获取人员(string 标识)
    {
        if(标识 == "行为执行者")
        {
            return 参与人员[调教者];
        }
        else if (标识 == "行为执行者")
        {
            return 参与人员[被调教者];
        }
        else if (标识 == "助手")
        {
            return 参与人员[助手];
        }
        else if(int.TryParse(标识, out int id))
        {
            return 参与人员[id];
        }
        else
        {
            Debug.LogError("不存在\"" + 标识 + "\"的成员");
            return null;
        }
    }
}
