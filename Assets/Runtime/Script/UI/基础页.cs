using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class 基础页 : MonoBehaviour
{
    public Canvas canvas;

    protected virtual void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public virtual void Open()
    {

    }

    public virtual void Close()
    {

    }

}
