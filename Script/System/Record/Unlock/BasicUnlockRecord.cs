using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

//解鎖的紀錄
[SerializeField]
public class BasicUnlockRecord : MonoBehaviour {

    //index
    public int Index;

    //名稱
    public string Name;

    //描述
    public string Description;

    //是否完成
    public bool isFinish
    {
        get
        {
            try
            {
                foreach (SingleUnlockItem item in Stage)
                {
                    if (item.isFinish == false)
                    {
                        //如果有一個沒完成
                        return false;
                    }
                }
                //全都完成
                return true;
            }
            catch
            {

            }
            return false;
        }
    }

    //完成時間
    public DateTime FinishTime;

    public List<SingleUnlockItem> Stage;

    //單一一筆紀綠
    [SerializeField]
    public class SingleUnlockItem
    {
        //index
        public int StageIndex;
        //名稱
        public string Name;
        //描述
        public string Description;
        //是否完成
        public bool isFinish;
        //完成時間
        public DateTime FinishTime;
    }
}
