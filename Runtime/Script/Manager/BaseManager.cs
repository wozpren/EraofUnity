using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class BaseManager 
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
    public virtual void Update()
    {

    }

    public virtual void LateUpdate()
    {

    }
    public virtual void FixedUpdate()
    {

    }
}


public abstract class BaseManager<T>: BaseManager where T: BaseManager<T>, new()
{

    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance is null)
                instance = new T();
            return instance;
        }
    }



}
