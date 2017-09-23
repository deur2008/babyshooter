using UnityEngine;
using System.Collections;

//主要是用來控制聲音
public class SteamVR_HandSoundController : MonoBehaviour {

    //播放聲音
    public void PlaySoundEffect(AudioParameter parameter)
    {
        try
        {
            if (this.GetComponent<AudioSource>() != null)
            {
                AudioSource source = this.GetComponent<AudioSource>();
                if (parameter.AudioClip != null)
                {
                    //設定來源和相關參數
                    source.clip = parameter.AudioClip;
                    source.loop = parameter.IsLoop;
                    //然後播放
                    source.Play();
                }
                else
                {
                    source.Stop();
                }
            }
        }
        catch
        {

        }
    }
}
