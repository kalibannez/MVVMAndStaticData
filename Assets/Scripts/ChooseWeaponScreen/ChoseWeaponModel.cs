using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ChoseWeaponModel {

    public Action UpdateViewModel;

    public int ChosenWeaponId { get; private set; }

    [Inject]
    private StaticData _staticData;

    public void Init() {
        RestoreSavedData();
    }

    private void RestoreSavedData() {
        ChosenWeaponId = 1000;
    }

    public void ChoseWeapon(int id) {
        var weaponStaticData = _staticData.WeaponsStatic.Datas.FirstOrDefault(item => item.Id == id);
        
        if (weaponStaticData != null) {
            ChosenWeaponId = id;
            UpdateViewModel?.Invoke();
        } else {
            Debug.LogError($"Weapon {id} not exist!");
        }
    }

}
