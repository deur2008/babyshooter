using UnityEngine;
using System.Collections;

//單一點點的參數
public class SingleWeakPointParameter : EnemyDifficulty
{

    //HP多少，如果恢復HP最多只會恢復到這個數量
    public float HP;

    //打中一次分數
    public int singleShootScore=1;

    //DefeatScore
    public int DefeatScore=30;

    //Combo
    public int ComboIncreaseRate=1;

    //防禦，可能會抵擋掉多少0~100
    public float _defenseRate;

    //抵擋機率
    public float _defenseRatio;

    //要不要顯示
    public bool _showAimmer=false;

    //要不要顯示血量
    //只有被打到後才會顯示出來?
    public bool _showHPBar=true;

    //要不要顯示是特殊攻擊點
    public bool _showSpecialPoint=false;

}
