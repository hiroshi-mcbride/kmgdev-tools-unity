using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SimpleFileBrowser;

public class FileManager : MonoBehaviour
{
    private event FileBrowser.OnSuccess onLoadSuccess;
    private event FileBrowser.OnSuccess onSaveSuccess;

    private event FileBrowser.OnCancel onCancel;
    

    public void OnLoad()
    { 
        FileBrowser.ShowLoadDialog(onLoadSuccess, onCancel, FileBrowser.PickMode.Files);
    }
    
    public void OnSave()
    {
        FileBrowser.ShowSaveDialog(onSaveSuccess, onCancel, FileBrowser.PickMode.Files);
    }

    private void ReadFile(string[] _paths)
    {
        foreach (string path in _paths)
        {
            if (File.Exists(path))
            {
                Debug.Log(File.ReadAllText(path));
            }
        }
    }

    private void WriteFile(string[] _paths)
    {
        
    }

    private void OnLoadCanceled()
    {
        
    }
    
    private void Start()
    {
        FileBrowser.SetFilters(false, new FileBrowser.Filter("", ".mfsp"));
        
        // HideDialog initializes the file browser, preventing lag when opening the dialog
        FileBrowser.HideDialog();
    }
    
    private void OnEnable()
    {
        onLoadSuccess += ReadFile;
        onSaveSuccess += WriteFile;
        onCancel += OnLoadCanceled;
    }
    
    private void OnDisable()
    {
        onLoadSuccess -= ReadFile;
        onSaveSuccess -= WriteFile;
        onCancel -= OnLoadCanceled;
    }
}
