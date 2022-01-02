using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum 性别
{
    男 = 1, 女 = 2, 中性 = 3,
}

public class 角色
{
    public virtual string 名字 { get; set; }
    public virtual string 口上 { get; set; }
    public virtual int 年龄 { get; set; }
    public virtual 性别 性别 { get; set; }

    public List<string> 天赋 = new List<string>();
    public List<string> 特殊经验 = new List<string>();
    public Dictionary<string, int> 经验 = new Dictionary<string, int>();
    public Dictionary<string, int> 能力 = new Dictionary<string, int>();
    public Dictionary<string, int> 宝珠 = new Dictionary<string, int>();
    public Dictionary<string, int> 刻印 = new Dictionary<string, int>();

    public Dictionary<string, 性器官> 性器官集合 = new Dictionary<string, 性器官>();

    /// <summary>
    /// 获取经验, 能力, 宝珠, 刻印中的一种。
    /// </summary>
    /// <param name="名字"></param>
    /// <returns></returns>
    public virtual Dictionary<string, int> 获取字典(string 名字)
    {
        switch (名字)
        {
            case "经验":
                return 经验;
            case "能力":
                return 能力;
            case "宝珠":
                return 宝珠;
            case "刻印":
                return 刻印;
        }
        Debug.LogError($"不存在{名字}的字典");
        return null;
    }
}