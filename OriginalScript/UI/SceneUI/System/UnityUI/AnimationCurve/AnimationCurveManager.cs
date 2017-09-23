using UnityEngine;
using System.Collections;

//主要是用來管理AnimtionCurve用的
//可以取一些常用的 AnimtionCurve 資料
public class AnimationCurveManager : MonoBehaviour{

    //建構
    public AnimationCurveManager()
    {

    }

    //取得某點時間時應該要移動的距離
    //在某個寬度位置時，對應的高度位置
    public static float GetValueBetweenTwoParameter(float startDistance, float endDistance, AnimationCurve curve, float time)
    {
        //如果是在時間內
        if (time < GetDifferenceTime(curve))
        {
            float range = endDistance - startDistance;
            return startDistance = startDistance + (range * curve.Evaluate(time)) / GetDifferenceValue(curve);
        }
        return endDistance;
    }

    //取得差距時間(寬度差距)，做動畫時間參考
    public static float GetDifferenceTime(AnimationCurve curve)
    {
        if (curve.length > 1)
        {
            return curve.keys[curve.length - 1].time - curve.keys[0].time;
        }
        return 0;
    }

    //取得差距距離 (高度差距)
    //正常來說頭(0)到尾(1)的差距是 1
    //但也可能為0.9
    //目前先暫時不考慮富負數的情況?
    public static float GetDifferenceValue(AnimationCurve curve)
    {
        if (curve.length > 1)
        {
            return curve.Evaluate(curve.keys[curve.length - 1].time) - curve.Evaluate(curve.keys[0].time);
        }
        return 0;
    }

    //取得總面積，作為其他需要
    public static float GetTotalAnimationCurveArea(float startTime,float endTime,AnimationCurve curve)
    {
        float nowTime = startTime;
        float totalArea = 0; ;
        while (nowTime < endTime)
        {
            totalArea= totalArea + curve.Evaluate(curve.keys[curve.length - 1].time) * Time.deltaTime;
            nowTime = nowTime + Time.deltaTime;
        }
        return totalArea;
    }

    //取德頭頭的那個點
    public static float GetAnimtionCurveStartTime(AnimationCurve curve)
    {
        return curve.Evaluate(curve.keys[0].time);
    }

    //取德頭頭的那個點
    public static float GetAnimtionCurveEndTime(AnimationCurve curve)
    {
        return curve.Evaluate(curve.keys[curve.length - 1].time);
    }
}
