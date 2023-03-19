using UnityEngine;

[CreateAssetMenu(fileName = "StaticData", menuName = "ScriptableObjects/Data/StaticData")]
public class StaticData : SettingsStaticData {
    public WeaponsStaticData WeaponsStatic;
    public SettingsStaticData SettingsStatic;
}
