using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

/**
 * 在进入主视图的时候，为scrollView根据json数据创建预制件，然后调用其他的脚本对预制件进行填充的渲染
 */
public class CreateCards : MonoBehaviour
{
    //获取Content的RectTransform
    [SerializeField] private RectTransform contentTransform;
    private ChangeChildInCard changeChildInCard;

    void Start()
    {
        //执行创建商品的函数
        CreateCardFromJson();
    }

    //给scrollView中创建预制件
    private ChangeChildInCard CreateItemForSV(string path)
    {
        var itemForSv = Instantiate(Resources.Load<ChangeChildInCard>(path), contentTransform);
        return itemForSv;
    }

    // 根据不同的json创建不同的商品类型
    private void CreateCardFromJson()
    {
        //从解析json的脚本中获取数据
        List<JSONNode> list = JsonData.JsonToData();
        foreach (JSONNode value in list)
        {
            ChangeChildInCard temp;
            switch (int.Parse(value["type"]))
            {
                case 1:
                    temp = CreateItemForSV("prefabs/CoinCardPrefab");
                    temp.ChangeChild(value);
                    break;
                case 2:
                    temp = CreateItemForSV("prefabs/CoinCardPrefab");
                    temp.ChangeChild(value);
                    break;
                case 3:
                    temp = CreateItemForSV("prefabs/PurpleCardPrefab");
                    temp.ChangeChild(value);
                    break;
            }
        }

        //不足3的倍数的商品用lock补全
        if (list.Count % 3 == 0) return;
        for (int i = 0; i < 3 - list.Count % 3; i++)
        {
            Instantiate(Resources.Load("prefabs/LockPrefab"), contentTransform);
        }
    }
}