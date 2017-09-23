using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//儲存所有的場景
//會弄成prefab
//之後由SceneManager載入
public class StageGameObjectManager : MonoBehaviour {

    //主要是用來管理所有的Scene
    public List<StageGameObjectSingleItem> Item;

}
