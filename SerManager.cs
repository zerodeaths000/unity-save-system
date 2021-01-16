using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Other Imports
using System.Runtime.Serialization.Formatters.Binary; //Import Binary
using System.IO; //Import FileStream

public class SerManager : MonoBehaviour
{
    //Saving
    public static bool Saving(string name, object data){
        BinaryFormatter bFromatter = GetBinaryFormatter();

        //Check if dir exists, if not, create it
        if(!Directory.Exists(Application.persistentDataPath + "/mentes")){
            Directory.CreateDirectory(Application.persistentDataPath + "/mentes");
        }

        //Opening file stream
        string savePath = Application.persistentDataPath + "/mentes" + name + ".bazdmeg";
        FileStream file = File.Create(savePath);
        bFromatter.Serialize(file, data);
        file.Close();
        //Opening file stream

        return true;
    }
    //Saving

    //Loading
    public static object LoadingHandler(string path){
        if(!File.Exists(path)){
            return null;
        }

        BinaryFormatter bFormatter = GetBinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);

        //Seek errors
        try{
            object saveLoad = bFormatter.Deserialize(file);
            file.Close();
            return saveLoad;
        } catch {
            return null;
        }
        //Seek errors
    }
    //Loading

    //Serializing, formatting
    public static BinaryFormatter GetBinaryFormatter(){
        BinaryFormatter bFormatter = new BinaryFormatter();
        return bFormatter;
    }
    //Serializing, formatting
}
