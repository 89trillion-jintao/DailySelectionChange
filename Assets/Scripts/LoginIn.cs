using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 最开始点击按钮切换到主场景
 */
public class LoginIn : MonoBehaviour
{
    [SerializeField] private GameObject loginCanvas;
    [SerializeField] private GameObject mainCanvas;

    //跳转界面
    public void OnClick()
    {
        loginCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
}