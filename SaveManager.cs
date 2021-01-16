using UnityEngine;
using System.Collections;

[System.Serializable]
public class SaveManager {
    static SaveManager _nowSave;
    public static SaveManager nowSave{
        get {
             if(_nowSave == null){
                 _nowSave = new SaveManager();
             }
             return _nowSave;
        }
    }
}