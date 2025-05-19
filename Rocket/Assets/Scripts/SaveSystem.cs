using UnityEngine;
using System.IO;
using UnityEditor;

public class SaveSystem : MonoBehaviour
{
    private static SaveData saveData = new SaveData();

    [System.Serializable]
    public struct SaveData
    {
        public ProfileData RocketProfileData;
    }

    public static string SaveFileName()
    {
        string saveFile = Application.persistentDataPath + "/gameSave.json";
        return saveFile;
    }

    public static void Save()
    {
        HandleSaveData();
        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(saveData, true));
    }

    public static void HandleSaveData()
    {
        RocketStartingProfile.GetInstance().Save(ref saveData.RocketProfileData);
    }

    public static void Load()
    {
        string saveContent = File.ReadAllText(SaveFileName());
        saveData = JsonUtility.FromJson<SaveData>(saveContent);
        HandleLoadData();
    }

    public static void HandleLoadData()
    {
        RocketStartingProfile.GetInstance().Load(saveData.RocketProfileData);
    }

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Load();
        Debug.Log("Loaded");
    }

    public void OnApplicationQuit()
    {
        Save();
    }
}
