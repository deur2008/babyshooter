using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

//所有有選單的都要繼承
public class BaseMenuStateMachineBehaviour : BasePanelStateMachineBehaviour
{


    //取得目前選擇的index
    public virtual int GetSelectIndex()
    {
        int selectIndex=0;
        try
        {
            //先取得result 的index
            //selectIndex = ((MenuManager.MenuPanelUIJsonFromat)_object.GetComponent<PanelUI>().GetPanelUIJsonFromat()).SelectIndex;
            //取得結果
            Debug.Log(_roomUIOnSceneObject.GetComponent<PanelUI>().GetValue());

            MenuManager.MenuPanelUIJsonFromat format = (MenuManager.MenuPanelUIJsonFromat)_roomUIOnSceneObject.GetComponent<PanelUI>().GetPanelUIJsonFromat();

            return format.SelectIndex;
        }
        catch(Exception ex)
        {
            Debug.Log("GetSelectIndex error :" + ex.Message);
        }
        return selectIndex;
    }

    //MenuManager 裡面增加選項
    public virtual void LoadRecords(MenuManager manager, PanelUI template, List<RecordItem> item)
    {
        //逐一增加選項
        foreach (RecordItem recordItem in item)
        {
            /*
            PanelUI ui = template.;
            CreatePanelByRecordItem(ui, manager)
            */

        }
    }
}
