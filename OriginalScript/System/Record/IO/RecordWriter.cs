using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

//寫入文件使用
//格式是"Tag" : "內容"，然後要指定是哪份文件
public class RecordWriter : MonoBehaviour {

    //Tag和內文中間的分隔器
    char _seperator = ':';
    //儲存記錄的跟目錄的路徑
    string _rootOfRecord = "";
    //儲存名稱
    string _saveFileName="";
    //寫入器
    StreamWriter _writer;

    //設定分隔字元
    public void SetSeperator(char seperator)
    {
        _seperator = seperator;
    }

    //設定當前目錄
    public void SetCurrentDirection(string str)
    {
        _rootOfRecord = str;
    }

    //指定存檔名稱
    public bool SaveFileName(string str)
    {
        _saveFileName = str;
        return false;
    }

    //記錄檔是否存在
    public bool RecordFileExist()
    {
        //完整路徑
        if (File.Exists(GetFullPath()))
        {
            return true;
        }
        return false;
    }

    //把所有檔寫回去
    public bool SaveAllRecord(List<RecordItem> itemList)
    {
        return false;
    }

    //建立一筆紀錄
    public bool CreateAFile()
    {
        return false;
    }

    //把文件Release掉
    //如果失敗就return false;
    public bool CloseFile()
    {
        return false;
    }
    //================private===============

    //把所有List資訊寫進文件裡面
    private bool SaveRecordItemToString(List<RecordItem> itemList)
    {
        if (RecordFileExist())
        {
            try
            {
                _writer = new StreamWriter(GetFullPath());
                foreach (RecordItem singleRecord in itemList)
                {
                    //寫入一行
                    _writer.WriteLine(RecordItemToString(singleRecord));
                }
                //表示存檔成功
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        return false;
    }

    //單行
    private string RecordItemToString(RecordItem item)
    {
        return item.tag + _seperator + item.Value;
    }

    //回傳整個路徑
    //路徑 + 檔案名稱
    private string GetFullPath()
    {
        return _rootOfRecord + _saveFileName;
    }

}
