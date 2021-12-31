using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class 游戏管理器 : MonoBehaviour
{
    public static 游戏管理器 实例;

    private List<基础管理器> managerPool = new List<基础管理器>();



    /// <summary>
    /// 游戏唯一的启动入口
    /// </summary>
    protected virtual void Awake()
    {
        实例 = this;
        DontDestroyOnLoad(gameObject);

        初始化事件();
        初始化管理器();
    }


    protected virtual void 初始化事件()
    {


    }
    protected virtual void 初始化管理器()
    {
        文本管理器.camera = Camera.main;


        managerPool.Add(UI管理器.Instance);
        foreach (var manager in managerPool)
        {
            manager.Init();
        }
    }


    protected virtual void Start()
    {
        foreach (var manager in managerPool)
        {
            manager.Start();
        }
    }
    protected virtual void Update()
    {
        foreach (var manager in managerPool)
        {
            manager.Update();
        }
    }
    protected virtual void LateUpdate()
    {
        foreach (var manager in managerPool)
        {
            manager.LateUpdate();
        }
    }
    protected virtual void FixedUpdate()
    {
        foreach (var manager in managerPool)
        {
            manager.FixedUpdate();
        }
    }

    public void 处理按钮事件(string 事件)
    {


    }
}
