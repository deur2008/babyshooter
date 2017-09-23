using UnityEngine;
using System.Collections;


//聲音的相關設定檔
public class AudioParameter : MonoBehaviour {

    //那個Action對應的音效
    public AudioClip AudioClip;

    //是否要重複
    public bool IsLoop=false;

    //播放次數
    public int PlayTime = 1;


}
