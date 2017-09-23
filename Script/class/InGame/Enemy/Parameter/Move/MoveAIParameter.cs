using UnityEngine;
using System.Collections;

//AI的相關參數
public class MoveAIParameter : MoveParameter
{

    //靠近玩家的距離
    //如果非常靠近玩家，就會把機率提升，以便容易被選重
    public float _rumToPlayerDistance;
}
