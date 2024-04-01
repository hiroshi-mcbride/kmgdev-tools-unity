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

    

    public void OnLoad()
    { 
        FileBrowser.ShowLoadDialog(onLoadSuccess, null, FileBrowser.PickMode.Files);
    }
    
    public void OnSave()
    {
        FileBrowser.ShowSaveDialog(onSaveSuccess, null, FileBrowser.PickMode.Files);
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
    }
    
    private void OnDisable()
    {
        onLoadSuccess -= ReadFile;
        onSaveSuccess -= WriteFile;
    }
}
