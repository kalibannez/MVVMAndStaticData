using System;
using System.Linq;
using UnityEngine;
using Zenject;

public interface IChoseWeaponModel
{
    public void BindUpdater(Action updateViewModel);

    public void ChoseWeapon(int id);
    public WeaponsStaticData GetWeaponsStaticData();
    public int ChosenWeaponId { get; }
    void Init();
}

public class ChoseWeaponModel: IChoseWeaponModel {
    public int ChosenWeaponId { get; private set; }

    private Action _updateViewModel;
    
    [Inject]
    private StaticData _staticData;

    public void Init() {
        RestoreSavedData();
    }

    private void RestoreSavedData() {
        ChoseWeapon(1001);
    }

    public void BindUpdater(Action updateViewModel) => _updateViewModel = updateViewModel;

    public void ChoseWeapon(int id) {
        var weaponStaticData = _staticData.WeaponsStatic.Datas.FirstOrDefault(item => item.Id == id);
        
        if (weaponStaticData != null) {
            ChosenWeaponId = id;
            _updateViewModel?.Invoke();
        } else {
            Debug.LogError($"Weapon {id} not exist!");
        }
    }

    public WeaponsStaticData GetWeaponsStaticData() => _staticData.WeaponsStatic;

}
