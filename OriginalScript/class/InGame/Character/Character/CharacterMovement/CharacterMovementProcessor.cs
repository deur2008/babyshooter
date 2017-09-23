using UnityEngine;
using System.Collections;

//人物移動方式控制
//會取得 CharacterInfo 裡面的東西做移動時加速減素設定
public class CharacterMovementProcessor : MonoBehaviour
{
    //目前要移動到的位置
    GameObject _target = null;

    //目前腳色
    GameObject _character = null;

    //設定參數
    CharacterSpeedParameter _speedParameter;


    //判斷是不是可以執行
    public bool _execute = false;


    //處理用
    ProcessorMove _processRun;
    ProcessorMove _processSlide;

    //初始化
    public CharacterMovementProcessor(CharacterSpeedParameter speedParameter, GameObject character = null)
    {
        _character = character;
        _speedParameter = speedParameter;
        //初始話
        InitialProcessorMove();
        //確認是可以執行的
        _execute = true;

    }

    //設定要移動的方向
    //簡單來說會設定一個墓邊點
    //然後可以移動到那邊
    public void SetTarget(GameObject Target)
    {
        _target = Target;
        //設定目標
        _processRun.SetTarger(_target);
        _processSlide.SetTarger(_target);
    }

    //設定要做參考的參數
    public void SetCharacterSpeedParameter(CharacterSpeedParameter speedParameter)
    {
        _speedParameter = speedParameter;
        //InitialProcessorMove();
        _execute = true;
    }

    //初始化
    void InitialProcessorMove()
    {
        //如果沒有被初始化
        if (_processRun == null)
        {
            _processRun = new ProcessorMove();
            _processSlide = new ProcessorMove();
        }

        //設定加入度Curve
        _processRun.SetStartCurve(_speedParameter._runAccelerattionSpeedCurve);
        _processSlide.SetStartCurve(_speedParameter._slideAccelerattionSpeedCurve);
        //減速Curve
        _processRun.SetStopCurve(_speedParameter._runSlowDownSpeedCurve);
        _processSlide.SetStopCurve(_speedParameter._slideSlowDownSpeedCurve);
        //設定大小值
        _processRun.SetMaxAndMin(_speedParameter._maxRunSpeed, _speedParameter._minRunSpeed);
        _processSlide.SetMaxAndMin(_speedParameter._maxSlideSpeed, _speedParameter._minSlideSpeed);

        //設定腳舍
        _processRun.SetCharacter(_character);
        _processSlide.SetCharacter(_character);

    }



    //開始做處理
    public void Process()
    {
        //new 
        //_processRun.Process();
        //_processSlide.Process();
        float smooth=1.0f;
        _character.transform.position = Vector3.Lerp(_character.transform.position, _target.transform.position, Time.deltaTime * smooth);
    }


    //移動
    public void Run(Vector2 vector)
    {
        //Debug.Log("RUN");
        _processRun.Move(vector);
    }

    //滑動速度，區間為-1~1 相對於搖桿上面的 雙點擊
    //是加取local裡面的計算
    public void FastRun(Vector2 vector)
    {
        _processSlide.Move(vector);
    }


    //面對的方位
    public Vector3 GetFaceDirection()
    {
        return _character.transform.rotation.eulerAngles;
    }

    //計算移動
    class ProcessorMove
    {
        float _ratio = 1;
        //目標
        GameObject _target;
        //腳色本身
        GameObject _character;

        public bool _start = false;//開始
        public bool _stop = false;//停止，如果是沒有按下按鈕，就表示停止惹
        //移動時間
        public float _moveTime;
        float _max = 1;
        float _min = 0;

        //value
        public Vector3 _inputValue;
        //計算出來的return value;
        public Vector3 _targetValue;

        //加速的Animator Curve;
        AnimationCurve _accerateCurve;
        //減速的Aminator Curve;
        AnimationCurve _stopCurve;
        public void SetStartCurve(AnimationCurve accerateCurve)
        {
            _accerateCurve = accerateCurve;
        }
        public void SetStopCurve(AnimationCurve accerateCurve)
        {
            _stopCurve = accerateCurve;
        }

        //設定最大和最小值
        public void SetMaxAndMin(float max, float min)
        {
            _max = max;
            _min = min;
        }

        //開始移動
        public void Move(Vector3 value)
        {
            //Debug.Log("X:" + value.x + " Y:" + value.y);
            _inputValue = value;
            _start = true;
            _stop = false;
            porcessMove();
        }

        //設定腳色
        public void SetCharacter(GameObject character)
        {
            _character = character;
        }

        //設定目標
        public void SetTarger(GameObject target)
        {
            _target = target;
        }

        //沒有按下按鈕，會在Animator exit時提醒
        public void Stop()
        {
            if (_start)
            {
                _start = false;
                _stop = true;
                _moveTime = 0;
            }
        }

        //是否有在移動
        bool isMove() //如果開始停止都沒有，就表示沒有移動
        {
            if (!_start)
                return _stop;
            return true;
        }

        //處理
        //一個frame被呼叫一次
        public void Process()
        {
            /*
            if (_start)//正在移動
            {
                porcessMove();
            }
            else if (_stop)//正在停止
            {
                porcessStop();
            }
            */
            Follow();

        }

        //跟隨指定到的地點
        void Follow()
        {
            if (_target == null)
            {
                //算出要移動的距離
                Vector3 smooth = new Vector3();
                //Vector3 origPositoin = new Vector3(_character.transform.localPosition.x, _character.transform.localPosition.y, _character.transform.localPosition.z);
                Vector3 origPositoin = new Vector3(0, 0, 0);
                smooth.x = Mathf.Lerp(origPositoin.x, _targetValue.x, 1.1f * Time.deltaTime);
                smooth.y = Mathf.Lerp(origPositoin.y, _targetValue.y, 1.1f * Time.deltaTime);
                smooth.z = Mathf.Lerp(origPositoin.z, _targetValue.z, 1.1f * Time.deltaTime);

                _character.transform.Translate(smooth);
                _targetValue = _targetValue - smooth;
            }
            else
            {
                //算出要移動的距離
                Vector3 smooth = new Vector3();
                //Vector3 origPositoin = new Vector3(_character.transform.localPosition.x, _character.transform.localPosition.y, _character.transform.localPosition.z);
                Vector3 origPositoin = new Vector3(0, 0, 0);
                smooth.x = Mathf.Lerp(origPositoin.x, _targetValue.x, 1.1f * Time.deltaTime);
                smooth.y = Mathf.Lerp(origPositoin.y, _targetValue.y, 1.1f * Time.deltaTime);
                smooth.z = Mathf.Lerp(origPositoin.z, _targetValue.z, 1.1f * Time.deltaTime);
                //Debug.Log("X:" + smooth.x + " Y:" + smooth.y);

                //旋轉
                //_character.transform.RotateAround(_target.transform.position, new Vector3(0, 1, 0), _targetValue.x);

                //面對目標
                FaceTarget();
                //由直線移動，移動方向
                _character.transform.Translate(smooth);
                _targetValue = _targetValue - smooth;
            }

        }

        //開始
        void porcessMove()
        {
            if (_target == null)
            {
                // Debug.Log("Process Move");
                Move();

            }
            else// 沒有 _target
            {
                //Debug.Log("Process MoveAroundTarget");
                MoveAroundTarget();
            }
            _moveTime = _moveTime + Time.deltaTime;
        }

        //沿著目標移動
        void MoveAroundTarget()
        {
            //取得倍率
            float curveValue = GetAnimationCurveValueByTime(_accerateCurve, _moveTime * 3);

            //X軸對著物體移動
            _targetValue.x = _targetValue.x + GetAverage(_min, _max, curveValue * _inputValue.x) * _ratio * Time.deltaTime;
            _targetValue.y = _targetValue.y + GetAverage(_min, _max, curveValue * _inputValue.z) * _ratio * Time.deltaTime * 5;
            _targetValue.z = _targetValue.z + GetAverage(_min, _max, curveValue * _inputValue.y) * _ratio * Time.deltaTime;

        }

        //普通移動
        void Move()
        {
            //取得倍率
            float curveValue = GetAnimationCurveValueByTime(_accerateCurve, _moveTime * 3);

            //X軸對著物體移動
            _targetValue.x = _targetValue.x + GetAverage(_min, _max, curveValue * _inputValue.x) * _ratio * Time.deltaTime;
            _targetValue.y = _targetValue.y + GetAverage(_min, _max, curveValue * _inputValue.z) * _ratio * Time.deltaTime;
            _targetValue.z = _targetValue.z + GetAverage(_min, _max, curveValue * _inputValue.y) * _ratio * Time.deltaTime;
        }

        //處理停止
        void porcessStop()
        {
            //取得倍率，減
            float curveValue = GetAnimationCurveValueByTime(_stopCurve, _moveTime);
            curveValue = 1 - curveValue;
            //Debug.Log("Value" + curveValue);

            //X軸對著物體移動
            _targetValue.x = _targetValue.x + GetAverage(_min, _max, curveValue * _inputValue.x) * _ratio * Time.deltaTime;
            _targetValue.y = _targetValue.y + GetAverage(_min, _max, curveValue * _inputValue.y) * _ratio * Time.deltaTime;
            _targetValue.z = _targetValue.z + GetAverage(_min, _max, curveValue * _inputValue.z) * _ratio * Time.deltaTime;


            Vector3 smooth = new Vector3();
            smooth.x = Mathf.Lerp(_character.transform.position.x, _targetValue.x, 0.3f * Time.deltaTime);
            smooth.z = Mathf.Lerp(_character.transform.position.y, _targetValue.y, 0.3f * Time.deltaTime);
            smooth.y = Mathf.Lerp(_character.transform.position.z, _targetValue.z, 0.3f * Time.deltaTime);
            _character.transform.position = smooth;

            if (curveValue == 0)
            {
                _start = false;
                _stop = false;
                _moveTime = 0;
            }

            //0.3秒停止
            _moveTime = _moveTime + Time.deltaTime * 3;
        }

        //從最大和最小間取得值
        //value : 0~1
        float GetAverage(float min, float max, float value)
        {
            if (value > 0)
            {
                return min + (max - min) * value;
            }
            if (value < 0)
            {
                return -min + (max - min) * value;
            }
            return 0;
        }

        //取得值
        float GetAnimationCurveValueByTime(AnimationCurve curve, float time)
        {
            return curve.Evaluate(time);
        }


        public float moveSpeed = 2f;
        public float rotateSpeed = 2f;
        //http://www.unity.5helpyou.com/3206.html

        //让物体朝摄像机Camera
        void FaceTarget()
        {
            //觀看某個物件
            _character.transform.LookAt(_target.transform);
            float value = _character.transform.localRotation.eulerAngles.y;
            //Debug.Log("value" + value);
            _character.transform.localRotation = Quaternion.Euler(0, value, 0);//_character.transform.localRotation.
        }
    }
}