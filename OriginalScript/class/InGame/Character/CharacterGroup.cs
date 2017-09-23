using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//用來分配目前腳色
//是A隊 還是 B 隊

//在想要不要用Static
public class CharacterGroup : MonoBehaviour {

    //從這邊去設定在遊戲上面的腳色
    //由系統生成腳色後榜上去
    //AI 和 玩家才有辦法控制分別腳色
    public static List<GameObject> _character = new List<GameObject>();

    //取得腳色
    public static List<GameObject> Character
    {
        get
        {
            return _character;
        }
        set
        {
            _character = value;
        }
    }
}
