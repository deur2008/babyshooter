using UnityEngine;
using System.Collections;

//這個class完全是用來存放解色的參數
//在遊戲開始前會把有關腳色的參數全部Loading近來
//在Rrecord也會用到

//靜態參數
public class CharacterParameter : MonoBehaviour {

    //最大參數
    public CharacterPower MaxPower;
    //最小參數
    public CharacterPower MinPower;
    //初始參數
    public CharacterPower InitialPower;

    //落地時回復速度
    public CharacterPower AutoRecoveryPower;

    //滑行時消耗
    public CharacterPower SlideConsumePower;

    //跳躍時消耗
    public CharacterPower JumpConsumePower;

    //腳色的初始位置
    public Vector3 InitPosition;

    //腳色移動速度
    public CharacterSpeedParameter SpeedParameter;

    //腳色在EX模式下移動速度
    public CharacterSpeedParameter ExSpeedParameter;

    //目前使用者擁有的武器(Objectt)
    public WeaponGameObjectSelector Selector;
    

   

}
