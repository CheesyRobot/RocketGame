using UnityEngine;
using System.IO;
using UnityEditor;
using Unity.VisualScripting;

public class SaveSystem : MonoBehaviour
{
    private static SaveData saveData = new SaveData();

    private static SaveSystem instance;
    public static SaveSystem Instance
    {
        get
        {
            if (!instance)
            {
                instance = new GameObject().AddComponent<SaveSystem>();
                instance.name = instance.GetType().ToString();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnApplicationQuit()
    {
        Debug.Log("saved");
        Save();
    }

    [System.Serializable]
    public struct SaveData
    {
        public ProfileData RocketProfileData;
        public SessionsData SessionsData;
    }

    public static string SaveFileName()
    {
        string saveFile = Application.persistentDataPath + "/gameSave.json";
        return saveFile;
    }

    public static void Save()
    {
        Debug.Log("saving...");
        HandleSaveData();
        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(saveData, true));
    }

    public static void HandleSaveData()
    {
        RocketStartingProfile.Instance.Save(ref saveData.RocketProfileData);
        SessionsProfile.Instance.Save(ref saveData.SessionsData);
    }

    public static void Load()
    {
        Debug.Log("loading...");
        string saveContent = null;
        if (!File.Exists(SaveFileName()))
        {
            Save();
        }
        saveContent = File.ReadAllText(SaveFileName());
        saveContent.NullIfEmpty();
        if (saveContent != null)
        {
            saveData = JsonUtility.FromJson<SaveData>(saveContent);
            HandleLoadData();
        }
    }

    public static void HandleLoadData()
    {
        RocketStartingProfile.Instance.Load(saveData.RocketProfileData);
        SessionsProfile.Instance.Load(saveData.SessionsData);
    }
}
