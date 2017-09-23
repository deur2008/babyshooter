using UnityEngine;
using System.Collections;
using System;

//所有SceneManager 的base class
//也是根據狀態機的位置，然後在對這邊的函數做呼叫
public class SceneManager : StateMachineManager
{
    //用來判斷目前在哪個場景
    public SceneIndex.SceneTypes _sceneIndexType;

    //VR區塊，方便存取用 : )
    public GameObject _cameraRigGameObject;

    //已經載入場景的CameraRig
    public GameObject _player;

    int _nowSceneIndex;
    //每一個 SceneManager 裡面都要有一個 SceneManagerJsonFormat，用來管理 SceneManager 裡面的一些傳遞參數
    public class SceneManagerJsonFormat : StateMachineJsonFormat
    {

    }

    public void SetNowSceneIndex(int index)
    {
        _nowSceneIndex = index;
    }

    //把[CameraRig]Loadint到場景上面?
    public virtual void LoadCameraRigToScene(Vector3 positino=new Vector3())
    {
        try
        {
            if (_player == null)
            {
                //把物件Loa近來
                _player = (GameObject)Instantiate(_cameraRigGameObject);
                _player.transform.position = positino;
            }
            Debug.Log("Create Success");
        }
        catch(Exception ex)
        {
            Debug.Log("Error : " + ex.Message);
        }
    }

    //虛擬繼承，可以被修改掉
    //取得上一個場景傳過來的參數
    public virtual SceneManagerJsonFormat GetlastScenePassData()
    {
        return ScenePassData.passData;
    }

    //到下一個場景要pass的Data
    public virtual void GoToNextScenePassData(int nextLevel, SceneManagerJsonFormat passObject)
    {
        ScenePassData.ReceiveSceneIndex = nextLevel;
        ScenePassData.SendSceneIndex = _nowSceneIndex;
        ScenePassData.passData = passObject;
    }

    //切回到上一個場景
    public int GetPreviousSceneIndex()
    {
        //回傳送資料那一方的index
        return ScenePassData.SendSceneIndex;
    }

    //要返回到上一個場景
    public virtual void BackToPreviousScene()
    {
        LoadScene(GetPreviousSceneIndex());
    }

    //把資料透過序列化存起來
    public void SaveUserData()
    {
        SerializeDataManager.SaveRecord();
    }
}



