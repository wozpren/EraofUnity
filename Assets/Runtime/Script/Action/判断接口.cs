using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface 判断接口
{
    bool 执行();
}

public enum 比较符
{
    大于, 小于, 等于, 大于等于, 小于等于
}


public struct 数值判断
{
    public string 名字;
    public 比较符 比较符;
    public int 数值;

    public bool 判断(int b)
    {
        return 工具.判断(比较符, b, 数值);
    }
}

public class 角色数值判断 : 判断接口
{
    public string 字典名;
    public string 角色标识;
    public 数值判断[] 判断对列;

    public bool 执行()
    {
        var 角色 = 数据管理器.实例.获取角色(角色标识);
        var 字典 = 角色.获取字典(字典名);
        foreach (var 对 in 判断对列)
        {
            if (字典.TryGetValue(对.名字, out int 值))
            {
                if(!对.判断(值))
                {
                    return false;
                }
            }
            else
            {
                if (!对.判断(0))
                {
                    return false;
                }
            }
        }
        return true;
    }
}

public class 角色状态判断 : 判断接口
{
    public string 角色标识;
    public List<string> 经验名字;

    public bool 执行()
    {
        var 角色 = 数据管理器.实例.获取角色(角色标识);
        foreach (var 经验 in 经验名字)
        {
            if(!角色.特殊经验.Contains(经验))
            {
                return false;
            }
        }
        return true;
    }
}