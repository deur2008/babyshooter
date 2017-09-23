using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//閃爍，讓一個圖層可以閃爍
//可以設定定時，速度，漸層
//或是被Call到後只閃一次，多久後消失
public class SparkleUI : MonoBehaviour {
    //設定閃爍間格時間(例如一秒閃一次)
    public float _sparkleTime = 0.1f;
    //設定光亮時間
    //會把時間/2，中間是最亮的時間
    public float _lightTime = 0.05f;

    //閃爍曲線圖
    public AnimationCurve _curve;
    //要不要使用閃爍取先
    public bool _useAnimationCurve = false;

    //計時目前閃爍
    float _nowSparkleTime = 0;
    //目前有沒有需要閃爍
    bool _needSparkle;

    void start()
    {
        if (_lightTime > _sparkleTime)
        {
            _lightTime = _sparkleTime;
        }
    }
    // Update is called once per frame
    void Update () {

        if (_useAnimationCurve==false)
        {
            ShortSparkle();
        }
        else
        {
            LongSparkle();
        }
        
        
	}

    //短時間閃爍
    void ShortSparkle()
    {
        //如果需要閃爍
        if (_needSparkle == true)
        {
            _nowSparkleTime = _nowSparkleTime + Time.deltaTime;
            
            
            if (_nowSparkleTime < _lightTime / 2)//表示從暗到亮
            {
                Sparkle(1);
            }
            else if (_nowSparkleTime > (_lightTime / 2) && _nowSparkleTime < _lightTime)//表示從亮到暗
            {
                Sparkle(0);
            }
            //表示閃爍結束
            if (_nowSparkleTime > _sparkleTime)
            {
                Sparkle(0);
                _needSparkle = false;
                _nowSparkleTime = 0;
            }
        }
    }

    //長時間閃爍
    void LongSparkle()
    {
        //如果需要閃爍
        if (_needSparkle == true)
        {
            _nowSparkleTime = _nowSparkleTime + Time.deltaTime;

            if (_nowSparkleTime < _lightTime / 2)//表示從暗到亮
            {
                //_curve 時間的百分比
                float getAnimationTime = GetDifferenceTime(_curve) * (_nowSparkleTime / (_lightTime / 2));
                //讀取百分比後對應亮度
                float bright = GetValueBetweenTwoParameter(0, 1, _curve, getAnimationTime);
                Sparkle(bright);
            }
            else if (_nowSparkleTime > (_lightTime / 2) && _nowSparkleTime < _lightTime)//表示從亮到暗
            {
                //_curve 時間的百分比
                float getAnimationTime = GetDifferenceTime(_curve) *(2- (_nowSparkleTime / (_lightTime / 2)));
                //讀取百分比後對應亮度
                float bright = GetValueBetweenTwoParameter(0, 1, _curve, getAnimationTime);
                Sparkle(bright);
            }
            //表示閃爍結束
            else if (_nowSparkleTime > _sparkleTime)
            {
                _needSparkle = false;
                Sparkle(0);
                _nowSparkleTime = 0;
            }

        }
    }

    //==============public============
    //呼叫閃爍
    public void SparkleTime(float time)
    {
        _needSparkle = true;
    }

    //呼叫然後閃爍一下
    public void Sparkle()
    {

    }
    //==============private=============

    //取得某點時間時應該要移動的距離
    float GetValueBetweenTwoParameter(float startDistance, float endDistance, AnimationCurve curve, float time)
    {
        //如果是在時間內
        if (time < GetDifferenceTime(curve))
        {
            float range = endDistance - startDistance;
            return startDistance = startDistance + (range * curve.Evaluate(time)) / GetDifferenceValue(curve);
        }
        return endDistance;
    }

    //取得AnimationCurve兩端的 值 差異
    float GetDifferenceValue(AnimationCurve curve)
    {
        if (curve.length > 1)
        {
            return curve.Evaluate(curve.keys[curve.length - 1].time) - curve.Evaluate(curve.keys[0].time);
        }
        return 0;
    }

    //取得差距時間，做動畫時間參考
    float GetDifferenceTime(AnimationCurve curve)
    {
        if (curve.length > 1)
        {
            return curve.keys[curve.length - 1].time - curve.keys[0].time;
        }
        return 0;
    }

    //介於0~1
    void Sparkle(float bright)
    {
        Color c = this.GetComponent<Image>().color;
        c.a = bright;
        this.GetComponent<Image>().color = c;
    }

}
