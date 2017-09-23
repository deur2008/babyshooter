using UnityEngine;
using System.Collections;

//一些 處理 RectTransform 常用到的Function
public class RectTransformManager : MonoBehaviour {

    //取得Contect 左上角位置
    public static Vector2 GetContextLeftUpPosition(GameObject contect)
    {
        Vector2 returnValue = new Vector2();
        returnValue.x = - contect.GetComponent<RectTransform>().sizeDelta.x / 2;
        returnValue.y = - contect.GetComponent<RectTransform>().sizeDelta.y / 2;
        return returnValue;
    }

    //設定RectTransform 長寬
    //會根據算出的totall改變
    public static void SetRectTransformWidthAndHeight(GameObject viewContect, float width, float height)
    {
        viewContect.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
    }
}
