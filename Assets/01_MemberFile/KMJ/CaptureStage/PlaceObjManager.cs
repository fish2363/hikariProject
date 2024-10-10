using System.IO;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class PlaceObjData
{
    public string spritePath;
    public string name;

    public string prefabPath;

    // PlaceObjSO �����͸� PlaceObjData�� ��ȯ����
    public PlaceObjData(PlaceObjSO placeObj)
    {
        spritePath = AssetDatabase.GetAssetPath(placeObj.sprite);
        name = placeObj.name;
        prefabPath = AssetDatabase.GetAssetPath(placeObj.prefab);
    }
}

public static class PlaceObjManager
{
    private static string filePath = Application.persistentDataPath + "/placeObjData.json";

    public static void SavePlaceObj(PlaceObjSO placeObj)
    {
        PlaceObjData data = new PlaceObjData(placeObj);
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(filePath, json);
        Debug.Log($"���� ���̺�� {filePath}");
    }

    public static PlaceObjSO LoadPlaceObj()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlaceObjData data = JsonUtility.FromJson<PlaceObjData>(json);

            PlaceObjSO loadedPlaceObj = ScriptableObject.CreateInstance<PlaceObjSO>();
            loadedPlaceObj.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(data.spritePath);
            loadedPlaceObj.name = data.name;
            loadedPlaceObj.prefab = AssetDatabase.LoadAssetAtPath<GameObject>(data.prefabPath);

            Debug.Log($"���� �ε�� {filePath}");
            return loadedPlaceObj;
        }
        else
        {
            Debug.LogError("���̺� ������ ã�� �� ����");
            return null;
        }
    }
}
