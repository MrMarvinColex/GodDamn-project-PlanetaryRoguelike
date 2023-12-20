using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveGame : MonoBehaviour
{
    public static Item item;
    private string jsonPath = Application.dataPath + "/funtalex-developing/SaveJson/data.json";

    private void OnMouseUpAsButton()
    {
        SaveData();
    }

    public void Awake()
    {
        LoadData();
    }

    private void LoadData()
    {
        Debug.Log("Load Data\n");
        item = JsonUtility.FromJson<Item>(File.ReadAllText(jsonPath));
    }

    private void SaveData()
    {
        Debug.Log("Save Data\n");
        
        File.WriteAllText(jsonPath, JsonUtility.ToJson(item));
    }

    [System.Serializable]
    public class Item
    {
        public GunData[] guns;
        public int enabled_gun;
        public int armor;
        public float speedBoost;
        public float dodgeChance;
        public float criticalChance;
        public float healthRecovery;
        public int armorLevel;
        public int speedBoostLevel;
        public int dodgeChanceLevel;
        public int criticalChanceLevel;
        public int healthRecoveryLevel;
        public int crystals;
        public int xp;
    }

    [System.Serializable]
    public class GunData
    {
        public string name;
        public string is_shooting;
        public bool is_available;
        public int damage;
        public int magazineSize;
        public float reloadTime;
        public float shotTime;
        public int damageLevel;
        public int magazineSizeLevel;
        public int reloadTimeLevel;
        public int shotTimeLevel;
    }
}
