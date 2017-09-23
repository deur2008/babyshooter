using UnityEngine;
using System.Collections;

//負責切換控制模式
public class SetCameraRigControlModeAction : StageAction {

    //控制模式
    public SteamVR_CharacterController.ControlMode _controllerMode;

    //初始化
    public override void Initialize()
    {

    }

    //開始動作，把模式設定到 SteamVR_CharacterController 上面
    public override void StartAction()
    {
        //切換目前模式
        _stageCondition._stageController._cameraRig.GetComponent<SteamVR_CharacterController>().SetMode(_controllerMode);
    }
}
