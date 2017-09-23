using UnityEngine;
using System.Collections;

//速度雌素
public class CharacterSpeedParameter : MonoBehaviour{

    //固定資訊(參數)
    public float _maxRunSpeed=5;
    public float _maxSlideSpeed=10;

    //固定資訊(參數)
    public float _minRunSpeed=3;
    public float _minSlideSpeed=5;

    //加速表示 : 
    //X : 加速時間 : Y 0~100%(1)
    public AnimationCurve _runAccelerattionSpeedCurve;
    public AnimationCurve _slideAccelerattionSpeedCurve;

    //減速
    public AnimationCurve _runSlowDownSpeedCurve;
    public AnimationCurve _slideSlowDownSpeedCurve;
}
