using UnityEngine;
using System.Collections;

//負責管理系統設定，例如音效之類的
[SerializeField]
public class SystemRecord : MonoBehaviour {

    //音效
    public VolumnRecord SystemVolumnRecord;

    //VR
    public VRRecord SystemVRRecord;

    //動作
    public MotionCapture SystemMotionCaptore;

    //燈光
    public LightSystemRecord SystemLightSystemRecord;

    //語言
    public int Language;

    //顯示
    public Display SystemDisplay;


    //音效紀錄
    [SerializeField]
    public class VolumnRecord
    {
        //0~100
        public int SceneBGMVolumn;
        //0~100
        public int SceneEffectVolumn;
        //0~100
        public int GameBGMVolumn;
        //0~100
        public int GameEffectVolumn;
    }


    //VR記，例如一些視角設定
    [SerializeField]
    public class VRRecord
    {


    }

    //動作校正
    [SerializeField]
    public class MotionCapture
    {

    }

    //燈光
    [SerializeField]
    public class LightSystemRecord
    {
        //COM
        public string COM;
        public int baudRate;
        public bool isOpen;//可以設定要不要打開燈光特效
        //不同情況下的顏色
        public Color StartMenuColor;
        public Color MainMenuColor;
        //遊戲中
        public Color GameEXColor;//EX模式
        public Color GameAttackColor;//攻擊
        public Color GameBeingAttackColor;//被攻擊
    }

    //顯示
    [SerializeField]
    public class Display
    {
        //顯示效果
        public int displayQuality;

        //字型大小
        public int TextSize;
    }
    
}
