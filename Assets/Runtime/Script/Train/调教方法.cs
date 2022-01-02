using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class 调教方法
{


    /// <summary>
    /// 判断方法是否能显示
    /// </summary>
    public abstract bool 显示判断();

    /// <summary>
    /// 判断角色需求是否达标
    /// </summary>
    public abstract bool 需求判断();

    /// <summary>
    /// 调教方法主要内容
    /// </summary>
    public abstract void 生成行为包();

    /// <summary>
    /// 执行方法显示的通用短语
    /// </summary>
    public abstract void 地文();
}
