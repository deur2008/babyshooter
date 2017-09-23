using UnityEngine;
using System.Collections;


//如果之後要Debug，通通貼在這邊
public class DebugLog {

    //主要是用來輸出 錯誤 訊息到 Console 上面
    public static void Print(Object title, string context)
    {
        Debug.Log(title.GetType().Name + " : " + context);
    }
	
}
