using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//map 的UI
public class MapUI : GameComponentUI
{

    //所有敵人

    //顯示玩家座標的標記
    public Image _chatacterMark;
    //根據不同隊伍去編排出不同顏色的mark;
    public List<Color> _markColorList;

    //listMark
    public List<GameObject> _listMark;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    //更新list 的Character到 Map上面
    public void SetCharacterList(List<GameObject> listCharacter)
    {
        //一個一個去抓取座標
        //還有旋轉
        //然後用目前控制的腳色去做加減
        foreach (GameObject Character in listCharacter)
        {
            try
            {

            }
            catch
            {

            }
        }
    }

    /*
    //從Camera上面把影像Render 到一個物體上面
    Texture2D RTImage(Camera cam)
    {
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = cam.targetTexture;
        cam.Render();
        Texture2D image = new Texture2D(cam.targetTexture.width, cam.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, cam.targetTexture.width, cam.targetTexture.height), 0, 0);
        image.Apply();
        RenderTexture.active = currentRT;
        return image;
    }
    */
}
