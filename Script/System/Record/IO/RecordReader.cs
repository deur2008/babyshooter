using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

//讀取文件使用

public class RecordReader : MonoBehaviour {

    //Tag和內文中間的分隔器
    char _seperator = ':';
    //儲存記錄的跟目錄的路徑
    string _rootOfRecord = "";
    //檔案名稱
    string _fileName;
    //讀取
    StreamReader _reader;
    //紀錄 

    //建構
    public RecordReader()
    {

    }

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

    //設定檔名
    private void SetFileName(string str)
    {
        _fileName = str;
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

    //載入一堆所有
    public List<RecordItem> LoadAllRecord()
    {
        return ReadAllRecord();
    }

    //關掉讀取器
    public bool CloseReader()
    {
        if (_reader != null)
        {
            _reader.Close();
            return true;
        }
        return false;
    }

    //======================private class=====================

    //把所有資訊讀進List
    private List<RecordItem> ReadAllRecord()
    {
        //List回傳用
        List<RecordItem> itemList = new List<RecordItem>();

        if (RecordFileExist())
        {
            try
            {
                _reader = new StreamReader(GetFullPath());
                string data;

                while ((data = _reader.ReadLine()) != null)
                {
                    itemList.Add(GetRecordItem(data));
                }
            }
            catch (Exception ex)
            {

            }
            CloseReader();
            
        }
      
        return itemList;
    }

    //讀取一行，然後切成Index 跟 Value
    private RecordItem GetRecordItem(string str)
    {
        try
        {
            string[] splitString = str.Split(_seperator);
            RecordItem item = new RecordItem();
            item.Index = splitString[0];
            item.Value = splitString[1];
            return item;
        }
        catch 
        {
            
        }
        RecordItem nullItem = new RecordItem();
        return nullItem;
    }

    //回傳整個路徑
    //路徑 + 檔案名稱
    private string GetFullPath()
    {
        return _rootOfRecord + _fileName;
    }
}
