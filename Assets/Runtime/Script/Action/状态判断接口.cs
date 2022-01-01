using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface 状态判断接口
{
    bool 执行();
}

public enum 比较符
{
    大于, 小于, 等于, 大于等于, 小于等于
}



public class 经验 : 状态判断接口
{
    public string 角色标识;
    public string 经验名字;
    public int 数值;
    public 比较符 比较符;

    public bool 执行()
    {
        var 角色 = 数据管理器.实例.获取角色(角色标识);
        if(角色.经验.TryGetValue(经验名字, out int 值))
        {
            工具.判断(比较符, 值, 数值);
        }
        return false;
    }
}

public class 宝珠 : 状态判断接口
{
    public string 角色标识;
    public string 宝珠名字;
    public int 数值;
    public 比较符 比较符;

    public bool 执行()
    {
        var 角色 = 数据管理器.实例.获取角色(角色标识);
        if (角色.宝珠.TryGetValue(宝珠名字, out int 值))
        {
            工具.判断(比较符, 值, 数值);
        }
        return false;
    }
}

public class 能力 : 状态判断接口
{
    public string 角色标识;
    public string 能力名字;
    public int 数值;
    public 比较符 比较符;

    public bool 执行()
    {
        var 角色 = 数据管理器.实例.获取角色(角色标识);
        if (角色.能力.TryGetValue(能力名字, out int 值))
        {
            工具.判断(比较符, 值, 数值);
        }
        return false;
    }
}

public class 刻印 : 状态判断接口
{
    public string 角色标识;
    public string 刻印名字;
    public int 数值;
    public 比较符 比较符;

    public bool 执行()
    {
        var 角色 = 数据管理器.实例.获取角色(角色标识);
        if (角色.刻印.TryGetValue(刻印名字, out int 值))
        {
            工具.判断(比较符, 值, 数值);
        }
        return false;
    }
}

public class 特殊经验 : 状态判断接口
{
    public string 角色标识;
    public string 经验名字;

    public bool 执行()
    {
        var 角色 = 数据管理器.实例.获取角色(角色标识);
        return 角色.特殊经验.Contains(经验名字);
    }
}

public class 天赋 : 状态判断接口
{
    public string 角色标识;
    public string 天赋名字;

    public bool 执行()
    {
        var 角色 = 数据管理器.实例.获取角色(角色标识);
        return 角色.天赋.Contains(天赋名字);
    }
}