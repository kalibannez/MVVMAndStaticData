using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponsData", menuName = "ScriptableObjects/Data/WeaponsData")]
public class WeaponsStaticData : ScriptableObject {
    public WeaponStaticData[] Datas;
}

[Serializable]
public class WeaponStaticData {
    public int Id;
    public int Damage;
    public float Calibre;
    public string Title;
    public string Description;
}
