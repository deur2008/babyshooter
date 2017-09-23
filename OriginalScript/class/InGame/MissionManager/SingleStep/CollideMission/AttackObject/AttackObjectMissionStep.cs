using UnityEngine;
using System.Collections;

//攻擊物體的腳本
//如果使用正確的武器攻擊，就可以直接去處理下個mission了
public class AttackObjectMissionStep : SingleCollideMissionStep
{
    //如果是要攻擊，該使用哪一種武器，例如刀還是槍
    public int AttackUseWeaponType;

    //那種武器底下的子武器，哪一種槍，之後改成enum，用dropDown的方式
    public int _weaponName;

	
}
