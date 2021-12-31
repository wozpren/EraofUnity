using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class 基础管理器 
{
    public virtual void Init()
    {

    }

    public virtual void Start()
    {

    }
    public virtual void OnEnable()
    {

    }
    public virtual void OnDisable()
    {

    }
    public virtual void 更新()
    {

    }

    public virtual void LateUpdate()
    {

    }
    public virtual void FixedUpdate()
    {

    }
}


public abstract class 基础管理器<T>: 基础管理器 where T: 基础管理器<T>, new()
{

    private static T 私有实例;
    public static T Instance
    {
        get
        {
            if (私有实例 is null)
                私有实例 = new T();
            return 私有实例;
        }
    }



}
