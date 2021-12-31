using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class 基础管理器 
{
    public virtual void 初始化()
    {

    }

    public virtual void 开始()
    {

    }
    public virtual void 开启()
    {

    }
    public virtual void 关闭()
    {

    }
    public virtual void 更新()
    {

    }

    public virtual void 更新之后()
    {

    }

    public virtual void 固定更新()
    {

    }
}


public abstract class 基础管理器<T>: 基础管理器 where T: 基础管理器<T>, new()
{

    private static T 私有实例;
    public static T 实例
    {
        get
        {
            if (私有实例 is null)
                私有实例 = new T();
            return 私有实例;
        }
    }



}
