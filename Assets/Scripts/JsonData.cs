using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;

/**
 * 使用simpleJSON解析json文件并将解析的数据提供给其他脚本使用
 */
public class JsonData
{
    //解析json文件，并存入jsonList中供给其他脚本使用
    public static List<CardData> JsonToData()
    {
        //存放解析出的json数据
        List<CardData> jsonList = new List<CardData>();
        //获取文件中的json字符串
        string strJSON = Resources.Load<TextAsset>("json/data").text;
        //使用simpleJSON解析json文件
        var jsonData = JSON.Parse(strJSON);
        for (int i = 0; i < jsonData["dailyProduct"].Count; i++)
        {
            CardData cardData = new CardData();
            cardData.type = jsonData["dailyProduct"][i]["type"];
            cardData.productId = jsonData["dailyProduct"][i]["productId"];
            cardData.subType = jsonData["dailyProduct"][i]["subType"];
            cardData.costGold = jsonData["dailyProduct"][i]["costGold"];
            jsonList.Add(cardData);
        }
        return jsonList;
    }
    //存放卡片数据
    public class CardData
    {
        public int productId;
        public int type;
        public int subType;
        public int costGold;
    }
}