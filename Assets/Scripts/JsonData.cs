using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SimpleJSON;
using UnityEngine;

/**
 * 使用simpleJSON解析json文件并将解析的数据提供给其他脚本使用
 */
public class JsonData
{
    //解析json文件，并存入jsonList中供给其他脚本使用
    public static List<JSONNode> JsonToData()
    {
        //存放解析出的json数据
        List<JSONNode> jsonList = new List<JSONNode>();
        //获取文件中的json字符串
        StreamReader streamReader = new StreamReader(Application.dataPath + "/Resources/json/data.json");
        string strJSON = streamReader.ReadToEnd();
        //使用simpleJSON解析json文件
        var jsonData = JSON.Parse(strJSON);
        for (int i = 0; i < jsonData["dailyProduct"].Count; i++)
        {
            jsonList.Add(jsonData["dailyProduct"][i]);
        }
        return jsonList;
    }
}