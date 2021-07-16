using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;

/**
 * 根据json数据填充和渲染卡片预制件,
 * 购买卡片时切换卡片布局
 */
public class ChangeChildInCard : MonoBehaviour
{
    [SerializeField] private Image coinImage;
    [SerializeField] private Image cardImage;
    [SerializeField] private Text moneyTxt;
    [SerializeField] private Text nameText;
    [SerializeField] private GameObject beforeGo;//卡片框架背景
    [SerializeField] private GameObject afterPrefab;//购买后切换的卡片内容为一个预制件
    //卡片所在路径
    private const string cardPath = "Sprites/cards/";

    public void ChangeChild(JsonData.CardData value) 
    {
        //根据不同的类型对卡片赋予不同的值
        switch (value.type)
        {
            //金币
            case 1:
                coinImage.sprite = Resources.Load<Sprite>(cardPath + "coin_1");
                coinImage.SetNativeSize();
                nameText.text = "Coins";
                break;
            //钻石
            case 2:
                coinImage.sprite = Resources.Load<Sprite>(cardPath + "diamond_2");
                coinImage.SetNativeSize();
                nameText.text ="Diamonds";
                break;
            //普通卡片类型
            case 3:
                moneyTxt.text = value.costGold.ToString();
                cardImage.sprite = Resources.Load<Sprite>(cardPath + value.subType);
                cardImage.SetNativeSize();
                nameText.text = value.productId.ToString();
                break;
        }
    }
    //将卡片所有信息隐藏，将购买后的预制件显示出来
    public void OnBuy()
    {
        //购买后切换卡片布局
        afterPrefab.SetActive(true);
        beforeGo.SetActive(false);
    }
}