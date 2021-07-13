using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 购买后改变卡片的布局
 */
public class ChangeCard : MonoBehaviour
{
    [SerializeField] private GameObject cardBtn;//卡片购买按钮
    [SerializeField] private GameObject cardBG;//卡片框架背景
    [SerializeField] private GameObject cardIma;//卡片图标
    [SerializeField] private GameObject cardTxt;//卡片上的文本
    [SerializeField] private GameObject afterPrefab;//购买后切换的卡片内容为一个预制件

    //将卡片所有信息隐藏，将购买后的预制件显示出来
    public void OnClick()
    {
        //购买后切换卡片布局
        afterPrefab.SetActive(true);
        cardBtn.SetActive(false);
        cardBG.SetActive(false);
        cardTxt.SetActive(false);
        cardIma.SetActive(false);
    }
}