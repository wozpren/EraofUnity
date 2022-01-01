using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class 数据管理器 : 基础管理器<数据管理器>
{
    public 玩家数据 当前玩家数据;



    public 角色 获取角色(string 标识)
    {
        角色 角色;
        if (标识 == "行为被执行者")
        {
            角色 = 调教管理器.实例.获取人员(标识);
        }
        else if(标识 == "行为执行者")
        {
            角色 = 调教管理器.实例.获取人员(标识);
        }
        else if (标识 == "助手")
        {
            角色 = 调教管理器.实例.获取人员(标识);
        }
        else
        {
            角色 = 当前玩家数据.拥有角色.First(c => c.名字 == 标识);
        }

        if(角色 == null)
        {
            Debug.LogError("不存在标识为\"" + 标识 + "\"的角色");
            return null;
        }
        else
        {
            return 角色;
        }
    }


}


public class 玩家数据
{
    public List<角色> 拥有角色 = new List<角色>();



}