using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;

/**
 * 根据json数据填充和渲染卡片预制件
 */
public class ChangeChildInCard : MonoBehaviour
{
    [SerializeField] private Image coinImage;
    [SerializeField] private Image cardImage;
    [SerializeField] private Text moneyTxt;
    [SerializeField] private Text nameText;
    //卡片所在路径
    private const string cardPath = "Sprites/cards/";

    public void ChangeChild(JSONNode value)
    {
        //根据不同的类型对卡片赋予不同的值
        switch (int.Parse(value["type"]))
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
                moneyTxt.text = value["costGold"].ToString();
                cardImage.sprite = Resources.Load<Sprite>(cardPath + value["subType"]);
                cardImage.SetNativeSize();
                nameText.text = value["productId"].ToString();
                break;
        }
    }
}