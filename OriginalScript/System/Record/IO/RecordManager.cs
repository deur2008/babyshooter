using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//負責寫入跟讀取
// 重要 : 使用 RecordManager 需要用建立(new)的方式，不是用引入

public class RecordManager : MonoBehaviour {

    //儲存紀錄用的List
    List<RecordItem> _recordList = new List<RecordItem>();
    //儲存記錄的跟目錄的路徑
    string _rootDirectoryOfRecord = "";
    //目前記錄檔名，使用 RecordManager 需要用建立的方式，不是用引入
    string _recordFileName;
    //讀取
    RecordReader _reader;
    //寫入
    RecordWriter _writer;
    //Tag和內文中間的分隔器
    char _seperator=':';

    //建構
    public RecordManager()
    {
        InitialReaderAndWriter();
    }

    //初始化讀寫器
    private void InitialReaderAndWriter()
    {
        _reader = new RecordReader();
        _writer = new RecordWriter();
        SetSeperator(_seperator);
        SetRootDirectory(_rootDirectoryOfRecord);
    }

    //設定分隔方式
    private void SetSeperator(char splitChar)
    {
        _reader.SetSeperator(splitChar);
        _writer.SetSeperator(splitChar);
    }

    //設定跟目錄
    private void SetRootDirectory(string str)
    {
        _reader.SetCurrentDirection(str);
        _writer.SetCurrentDirection(str);
    }

    //===================public class====================

    //記錄檔是否存在
    public bool RecordFileExist(string recordName)
    {
        return false;
    }

    //指定開啟某個檔案
    public bool OpenRecordFile()
    {
        return false;
    }

    //建立一個檔案紀錄
    public bool CreateRecordFile()
    {
        return false;
    }

    //寫入全部List到一個檔案
    public bool SaveToRecordFile()
    {
        return false;
    }

    //讀取全部List
    public List<RecordItem> GetAllRecordList()
    {
        
        return _recordList;
    }


    //保存一筆紀錄
    public bool SaveARecord(string tag, string context)
    {
        RecordItem item = new RecordItem();
        item.Index = tag;
        item.Value = context;
        _recordList.Add(item);
        return true;
    }

    public bool SaveARecordList(List<RecordItem> recordList)
    {
        _recordList = recordList;
        return true;
    }

    //載入一筆清單
    public bool LoadARecord(string tag)
    {
        return true;
    }

    //載入一堆所有
    public List<RecordItem> LoadAllRecord()
    {
        List<RecordItem> record = new List<RecordItem>();
        return record;
    }

    //如果有重複的，就複寫掉
    public bool ReplaceRecordWithSameRecordTag()
    {
        return true;
    }

    //把記錄清掉
    public bool EreaseRecord()
    {
        return false;
    }

    //把文件Release掉
    //如果失敗就return false;
    public bool CloseFile()
    {
        return false;
    }

    //===============private=============
    //從reader那邊讀取資料
    private void LoadAllDataFromReader()
    {
        _recordList = _reader.LoadAllRecord();
    }

    //寫入資料到 Writer;
    private void WriteAllDataToWriter()
    {
        _writer.SaveAllRecord(_recordList);
    }
}
