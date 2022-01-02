using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class 工具
{
    public static bool 判断(比较符 比较符, int a, int b)
    {
        switch (比较符)
        {
            case 比较符.大于:
                return a > b;
            case 比较符.小于:
                return a < b;
            case 比较符.等于:
                return a == b;
            case 比较符.大于等于:
                return a >= b;
            case 比较符.小于等于:
                return a <= b;
        }
        return false;
    }
}
