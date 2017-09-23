using UnityEngine;
using System.Collections;

//在場景之間傳遞一定都會有的參數
public class ScenePassData : MonoBehaviour {

    //目前場景 的 index
    public static int SendSceneIndex;
    //預估要傳遞的Scene index
    public static int ReceiveSceneIndex;
    //目前讀取的紀錄
    public static int recordIndex;

    //目前暫存
    //要透過多型去轉型
    public static SceneManager.SceneManagerJsonFormat passData;
}
