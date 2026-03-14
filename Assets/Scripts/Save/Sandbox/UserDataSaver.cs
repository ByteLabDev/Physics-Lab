using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class UserDataSaver
{
    
    public static void SaveUserData(UpdateSaveData dataUpdate){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/sandbox.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        UserSaveData data = new UserSaveData(dataUpdate);

        formatter.Serialize(stream, data);
        stream.Close();
    }


    
    public static UserSaveData LoadPlayer(){
        string path = Application.persistentDataPath + "/sandbox.save";

        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            UserSaveData data = formatter.Deserialize(stream) as UserSaveData;
            stream.Close();

            return data;
        }else{
            Debug.LogError("Save data not found.");
            return null;
        }
    }

    
    
}
