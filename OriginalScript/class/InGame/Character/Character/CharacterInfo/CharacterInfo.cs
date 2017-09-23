using UnityEngine;
using System.Collections;

//用來存放所有幕前人物的相關參數
//包含血量，移動位置(絕對)
//等等
//從這邊可以完整取得腳色所有狀態

public class CharacterInfo : MonoBehaviour {

    //腳色參數//靜態
    public CharacterParameter Parameter;

    //腳色目前狀態//動態
    public CharacterState State;

    //目前隊伍，例如是A 對還是 B隊等等
    //用來判斷目前
    public int TeamIndex;
}
