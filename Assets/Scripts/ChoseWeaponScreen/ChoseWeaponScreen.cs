using System.Collections.Generic;
using System.Linq;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

interface IChoseWeaponScreen {
    public void Init(IChoseWeaponViewModel weaponViewModel);
}

public class ChoseWeaponScreen : MonoBehaviour, IChoseWeaponScreen {

    [SerializeField]
    private WeaponCardItem _weaponCardPrefab;
    
    [SerializeField]
    private TextMeshProUGUI _chosenWeaponTitle;

    [SerializeField]
    private GameObject _scrollContainerContent;
    
    private IChoseWeaponViewModel _weaponViewModel;

    private List<WeaponCardItem> _weaponCards = new();
    
    public void Init(IChoseWeaponViewModel weaponViewModel) {
        _weaponViewModel = weaponViewModel;

        var weaponsStaticData = weaponViewModel.GetWeaponsStaticData();

        foreach (var weaponStaticData in weaponsStaticData.Datas) {
            var weaponCardItem = Instantiate(_weaponCardPrefab, _scrollContainerContent.transform);
            _weaponCards.Add(weaponCardItem);
            weaponCardItem.Init(weaponStaticData, (weaponId) => { WeaponCardClicked(weaponId); });
        }
        
        _weaponViewModel.ChosenWeapon.Subscribe(weaponId => {
            var weaponStaticData = weaponsStaticData.Datas.FirstOrDefault(item => item.Id == weaponId);

            if (weaponStaticData == null) {
                Debug.LogError($"Weapon {weaponId} not found in static!");
                return;
            }

            _chosenWeaponTitle.text = $"Chosen weapon: <color=green><b>{weaponStaticData.Title}</b></color>";

            foreach (var weaponCardItem in _weaponCards) {
                weaponCardItem.SetChosen(weaponCardItem.Id == weaponId);
            }
        }).AddTo(this);
    }

    private void WeaponCardClicked(int weaponId) {
        _weaponViewModel.SelectWeapon(weaponId);
    }

}
