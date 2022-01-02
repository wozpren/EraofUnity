using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct 行为包
{
    public int 嘴快感;
    public int 胸快感;
    //当对象有阴茎时，则为阴茎快感
    public int 阴蒂快感;
    public int 小穴快感;
    public int 直肠快感;
    public int 尿道快感;
    public int 情爱;
    public int 性行为;
    public int 成就感;
    public int 疼痛;
    public int 充足;
    public int 不洁;
    public int 露出;
    public int 屈从;
    public int 逃脱;
    public int 恐惧;
}

public struct 感觉包
{
    public int 恭顺;
    public int 欲情;
    public int 屈服;
    public int 习得;
    public int 羞耻;
    public int 痛苦;
    public int 恐怖;
    public int 反感;
    public int 嘴快感;
    public int 胸快感;
    //当对象有阴茎时，则为阴茎快感
    public int 阴蒂快感;
    public int 小穴快感;
    public int 直肠快感;
    public int 尿道快感;

    public int 小穴润滑;
    public int 直肠润滑;
}



public class 调教管理器 : 基础管理器<调教管理器>
{
    /*--------------
    调教流程
    


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
