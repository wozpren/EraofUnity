using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class ��Ϸ������ : MonoBehaviour
{
    public static ��Ϸ������ ʵ��;

    private List<����������> �������� = new List<����������>();



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


        ��������.Add(UI������.ʵ��);
        foreach (var manager in ��������)
        {
            manager.��ʼ��();
        }
    }


    protected virtual void Start()
    {
        foreach (var manager in ��������)
        {
            manager.��ʼ();
        }
    }
    protected virtual void Update()
    {
        foreach (var manager in ��������)
        {
            manager.����();
        }
    }
    protected virtual void LateUpdate()
    {
        foreach (var manager in ��������)
        {
            manager.����֮��();
        }
    }
    protected virtual void FixedUpdate()
    {
        foreach (var manager in ��������)
        {
            manager.�̶�����();
        }
    }

    public void ����ť�¼�(string �¼�)
    {


    }
}
