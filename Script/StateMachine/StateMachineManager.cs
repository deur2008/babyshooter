using UnityEngine;
using System.Collections;

//用來管理狀態機
//所有底下有 Animator 的class 都會繼承
public class StateMachineManager : MonoBehaviour {

    //狀態機
    public Animator _animator;
    //StateMachineJsonFormat
    StateMachineJsonFormat _format;

    //初始化場景
    public virtual void Initialize()
    {

    }

    //初始化
    public virtual void InitializeAnimator()
    {
        _animator = GetComponent<Animator>();
    }

    //切換場景
    public virtual void LoadScene(int level)
    {
        //example
        if (level == SceneIndex.AdjustVR)
        {
            //do something

            //最後是切換場景
            FinishPassDataAndSwitchLavel(level);
        }
    }

    //把目前的紀錄存到檔案中
    public virtual void SaveToRecordFile()
    {

    }

    //從記錄置中讀取
    public virtual void LoadDataFromRecord()
    {

    }

    protected virtual void FinishPassDataAndSwitchLavel(int level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }

    //處理傳遞過來的物件
    public virtual void ProcessPassData(StateMachineJsonFormat Format)
    {

    }

    //如果要結束這個場景，要把物件整理好傳遞給下一個場景
    public virtual StateMachineJsonFormat PreparePassData()
    {
        return new StateMachineJsonFormat();
    }

    //每一個 SceneManager 裡面都要有一個 SceneManagerJsonFormat，用來管理 SceneManager 裡面的一些傳遞參數
    public class StateMachineJsonFormat : ScenePassData
    {
       
    }

    //傳遞資料
    public void PassData(StateMachineJsonFormat format)
    {

    }

    //接收參數
    public void GetData()
    {

    }

    //製造假資料
    //如果在GetData沒有取得資料，可以改用假資料
    public virtual void MakeFakeData()
    {

    }

    //取得DeltaTime;
    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }
}
