using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SimpleFileBrowser;

public class FileManager : MonoBehaviour
{
    private event FileBrowser.OnSuccess OnLoadSuccess;
    private event FileBrowser.OnSuccess OnSaveSuccess;

    private ProjectManager projectManager;

    private void Awake()
    {
        ServiceLocator.TryLocate(Strings.ProjectManager, out projectManager);
    }


    public void OnLoad()
    { 
        FileBrowser.ShowLoadDialog(OnLoadSuccess, null, FileBrowser.PickMode.Files);
    }
    
    public void OnSave()
    {
        
        FileBrowser.ShowSaveDialog(OnSaveSuccess, null, FileBrowser.PickMode.Files);
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
        using (StreamWriter writer = new(_paths[0]))
        {
            //writer.WriteLine();
            writer.Close();
            
        }
    }
    
    private void Start()
    {
        FileBrowser.SetFilters(false, new FileBrowser.Filter("", ".mfsp"));
        
        // HideDialog initializes the file browser, so doing this on startup prevents lag when opening the dialog
        FileBrowser.HideDialog();
    }
    
    private void OnEnable()
    {
        OnLoadSuccess += ReadFile;
        OnSaveSuccess += WriteFile;
    }
    
    private void OnDisable()
    {
        OnLoadSuccess -= ReadFile;
        OnSaveSuccess -= WriteFile;
    }
}
