using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class ��Ϸ������ : MonoBehaviour
{
    public static ��Ϸ������ ʵ��;

    private List<����������> managerPool = new List<����������>();



    /// <summary>
    /// ��ϷΨһ���������
    /// </summary>
    protected virtual void Awake()
    {
        ʵ�� = this;
        DontDestroyOnLoad(gameObject);

        ��ʼ���¼�();
        ��ʼ��������();
    }


    protected virtual void ��ʼ���¼�()
    {


    }
    protected virtual void ��ʼ��������()
    {
        �ı�������.camera = Camera.main;


        managerPool.Add(UI������.Instance);
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

    public void ����ť�¼�(string �¼�)
    {


    }
}
