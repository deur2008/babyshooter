using UnityEngine;
using System.Collections;

//跟 CharacterController 功能一樣，都是藉由參數去控制腳色
public class AIController : SteamVR_CharacterController {

    //AI Adapter
    //public AIMainProcessor _processor;

    //目前控制的目標，還有要攻擊的目標
    //都會在裡面
    public CharacterGroup _targetCharacter;

    //指定要控制的腳色，ID跟list位置有關
    public int _controlCharacterID;

    //確定要不要執行，如果物件有一個是null就不要執行
    private bool _execute;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //然後根據一些
}
