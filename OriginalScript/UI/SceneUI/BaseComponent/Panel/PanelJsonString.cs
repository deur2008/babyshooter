using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

//從這邊去把json string 包裝好
public class PanelJsonString : MonoBehaviour {

    //Panel的序號
    public static string Index = "Index";

    //panel屬性
    public static string Type = "Type";

    //值
    public static string Value = "Value";

    //設定子物件
    public static string ChildObject = "ChildObject";

    //如果是選單的話裡面會有陣列的Panel
    public static string MenuObject = "MenuObject";

    //格式

    /*[
    {
    "Index":"0",
    "Type":"PanelUI",//可以根據 PanelUI 去推論 Value 的型態
    "Value":"10",
    "ChildObject":[{}],//如果底下沒有childObject就不用傳了
    "MenuObject":[
    {
        //重複剛剛的東西 panel.getValue();
        //如果不是Menu型態就不用船
    }
    ]
    */
    //如果是PanelUI，就直接傳ChildObject的參數

   
}




