using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum �Ա�
{
    �� = 1, Ů = 2, ���� = 3,
}

public class ��ɫ
{
    public virtual string ���� { get; set; }
    public virtual string ���� { get; set; }
    public virtual int ���� { get; set; }
    public virtual �Ա� �Ա� { get; set; }

    public List<string> �츳 = new List<string>();
    public List<string> ���⾭�� = new List<string>();
    public Dictionary<string, int> ���� = new Dictionary<string, int>();
    public Dictionary<string, int> ���� = new Dictionary<string, int>();
    public Dictionary<string, int> ���� = new Dictionary<string, int>();
    public Dictionary<string, int> ��ӡ = new Dictionary<string, int>();

    public Dictionary<string, ������> �����ټ��� = new Dictionary<string, ������>();
}