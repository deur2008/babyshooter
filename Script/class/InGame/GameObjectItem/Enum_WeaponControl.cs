using UnityEngine;
using System.Collections;

//用來模擬控制武器
public class Enum_WeaponControl : MonoBehaviour {
    //武器
    public GameObject _weaponGameObject;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            //壓下版雞
           // _weaponGameObject.GetComponent<Weapon>().OnTriggerDown();
        }

        if (Input.GetKey("space"))
        {
            //壓下版雞
            //_weaponGameObject.GetComponent<Weapon>().OnTriggerPress();
        }

        if (Input.GetKeyUp("space"))
        {
            //壓下版雞
            //_weaponGameObject.GetComponent<Weapon>().OnTriggerUp();
        }
    }
}
