using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    public int weaponIndex = -1;
    private bool isPlayer;
    private int count_colored;
    private int max_colored = 5;
    public Material material_;
    private GameObject[] levels_ = new GameObject[5];

    void Start()
    {

        Debug.Log("Set color of " + gameObject.tag);
        switch(gameObject.tag)
        {
            case "Armor":
                count_colored = SaveGame.item.armorLevel;
                SetPlayerLevel();
                break;
            case "SpeedBoost":
                count_colored = SaveGame.item.speedBoostLevel;
                SetPlayerLevel();
                break;
            case "DodgeChance":
                count_colored = SaveGame.item.dodgeChanceLevel;
                SetPlayerLevel();
                break;
            case "CriticalChance":
                count_colored = SaveGame.item.criticalChanceLevel;
                SetPlayerLevel();
                break;
            case "HealthRecovery":
                count_colored = SaveGame.item.healthRecoveryLevel;
                SetPlayerLevel();
                break;
            case "Damage":
                count_colored = SaveGame.item.guns[weaponIndex].damageLevel;
                SetWeaponLevel();
                break;
            case "MagazineSize":
                count_colored = SaveGame.item.guns[weaponIndex].magazineSizeLevel;
                SetWeaponLevel();
                break;
            case "ReloadTime":
                count_colored = SaveGame.item.guns[weaponIndex].reloadTimeLevel;
                SetWeaponLevel();
                break;
            case "ShotTime":
                count_colored = SaveGame.item.guns[weaponIndex].shotTimeLevel;
                SetWeaponLevel();
                break;
            default:
                Debug.Log("Wrong tag in SetColor");
                break;
        }

        for (int index = 0; index < count_colored; ++index)
        {
            levels_[index].GetComponent<Renderer>().material = material_;
        }
    }

    private void SetPlayerLevel()
    {
        isPlayer = true;

        levels_[0] = GameObject.Find(gameObject.tag + "/Levels/Level1");
        levels_[1] = GameObject.Find(gameObject.tag + "/Levels/Level2");
        levels_[2] = GameObject.Find(gameObject.tag + "/Levels/Level3");
        levels_[3] = GameObject.Find(gameObject.tag + "/Levels/Level4");
        levels_[4] = GameObject.Find(gameObject.tag + "/Levels/Level5");
    }

    private void SetWeaponLevel()
    {
        isPlayer = false;

        string prefix = "Weapon" + weaponIndex + "/Characteristics/";
        levels_[0] = GameObject.Find(prefix + gameObject.tag + "/Levels/Level1");
        levels_[1] = GameObject.Find(prefix + gameObject.tag + "/Levels/Level2");
        levels_[2] = GameObject.Find(prefix + gameObject.tag + "/Levels/Level3");
        levels_[3] = GameObject.Find(prefix + gameObject.tag + "/Levels/Level4");
        levels_[4] = GameObject.Find(prefix + gameObject.tag + "/Levels/Level5");
    }

    public void OnMouseUpAsButton()
    {
        if (isPlayer && count_colored < max_colored && SaveGame.item.xp > 0)
        {
            levels_[count_colored].GetComponent<Renderer>().material = material_;
            ++count_colored;
        }

        if (!isPlayer && count_colored < max_colored && SaveGame.item.crystals > 0)
        {
            levels_[count_colored].GetComponent<Renderer>().material = material_;
            ++count_colored;
        }
    }
}
