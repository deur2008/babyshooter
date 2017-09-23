using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//用來控制一個關卡的開始和結束
//一次遊戲裡面有好幾個關卡
public class StageController : MonoBehaviour {
    //Stage Process Time
    public Animator _animator;
    //狀態控制器
    public StageConditionManager _stageConditionManager;

    //目前關卡難度
    public enum Difficulty { easy, normal, hard, insame };
    public Difficulty _difficulity = StageController.Difficulty.normal; //目前選擇

    //開始的位置
    public GameObject _startPlace;

    //玩家(CameraRig)
    //基本上只要從這邊去取得位置
    //生成_cameraRig 的動作是stageController完成
    public GameObject _cameraRig;

    //玩家(character)
    //裡面會顯示一些相關狀態
    //如果是守塔遊戲，Character就會變成建築物
    public Character _character;
    
    //要掛載在玩家身上的東西
    public WeaponGameObjectSelector _weaponSelector;

    //目前難度管理器
    public DifficultyManager _difficultyManager;

    //開始遊戲
    //包含初始化
    public virtual void StartGame()
    {
        InitialCameraRig();
        //初始化狀態機
        InitialAnimator();
        //設定武器，把武器設定給玩家使用
        AttachWeaponSelectorToPlayer();
        //初始化狀態機
        InitializeStageConditionManager();
        //開始遊戲，初始化難度
        SetDifficulty(_difficulity);
    }

    //設定CameraRig
    void InitialCameraRig()
    {
        //還有把玩家位置指定上去
        _cameraRig.transform.position = _startPlace.transform.position;
        //如果已經有指定的腳色，例如是首塔遊戲
        if (_character != null)
        {
            _cameraRig.GetComponent<SteamVR_CharacterController>()._character = _character;
        }
        else
        {
            _character = _cameraRig.GetComponent<SteamVR_CharacterController>()._character;
        }
        
    }

    //初始化
    void InitialAnimator()
    {
        _animator = GetComponent<Animator>();
    }

    //初始化StageConditionManager
    void InitializeStageConditionManager()
    {
        _stageConditionManager.SetStageController(this);
        _stageConditionManager.Initialize();
    }

    //把目前可以操作的武器套用在玩家身上
    void AttachWeaponSelectorToPlayer()
    {
        _cameraRig.GetComponent<SteamVR_CharacterController>().SetWeaponSelector(_weaponSelector);
    }

   

    //==================public=====================
    //給SceneController控制用

    //通知，如果玩家完成這個關卡
    public delegate void PlayerFinishStage();
    public event PlayerFinishStage _playerFinishStage;

    //通知，如果這個關卡失敗
    public delegate void PlayerStageFall();
    public event PlayerStageFall _playerStageFall;

    //通知，如果玩家離開遊戲
    public delegate void PlayExitGame();
    public event PlayExitGame _playerExitGame;

    //通知，如果玩家重新開始遊戲
    public delegate void PlayerRestartGame();
    public event PlayerRestartGame _playerRestartGame;


    //切換目前狀態
    public void SwitchToState(StageConditionManager.NowState state)
    {
        _stageConditionManager.SwitchToState(state);
    }

    //取得玩家
    public void SetPlayer(GameObject CaneraRig)
    {
        //設定CameraRig
        _cameraRig = CaneraRig;
        //設定Character
        //_character = _cameraRig.GetComponent<SteamVR_CharacterController>()._character;
    }

    //設定難度
    public void SetDifficulty(Difficulty difficulity)
    {
        _difficulity = difficulity;
        //如果是簡單
        if (_difficulity == Difficulty.easy)
        {
            //對本身設定難度
            SetStageDifficulty((StageDifficulty)_difficultyManager.Easy);
        }
        else if (_difficulity == Difficulty.normal)
        {
            SetStageDifficulty((StageDifficulty)_difficultyManager.Normal);
        }
        else if (_difficulity == Difficulty.hard)
        {
            SetStageDifficulty((StageDifficulty)_difficultyManager.Hard);
        }
        else if (_difficulity == Difficulty.insame)
        {
            SetStageDifficulty((StageDifficulty)_difficultyManager.Insame);
        }
        //角色本身也要設定難度
        _character.SetDifficulty(difficulity);
    }

    //遊戲遊玩成功
    public void NotifiedSuccessGame()
    {
        //表示已經達成所有目標
        _playerFinishStage();
    }

    //失敗
    public virtual void NotifiedFallGame()
    {
        _playerStageFall();
    }

    //通知重新開始
    public virtual void NotifiedRestartGame()
    {
        _playerRestartGame();
    }

    //回到主畫面
    public virtual void NotifiedExitGame()
    {
        _playerExitGame();
    }

    //設定難度
    //目前改成WaveEnemyStageCondition 修改好難度後傳下來
    protected virtual void SetStageDifficulty(StageDifficulty difficulty)
    {
        //_stageConditionManager.SetStageDifficulty(difficulty);
    }

}
