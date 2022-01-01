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
}