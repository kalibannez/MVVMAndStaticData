using System.Collections.Generic;
using System.Linq;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class ChoseWeaponScreen : MonoBehaviour {

    [SerializeField]
    private WeaponCardItem _weaponCardPrefab;
    
    [SerializeField]
    private TextMeshProUGUI _chosenWeaponTitle;

    [SerializeField]
    private GameObject _scrollContainerContent;
    
    private IChoseWeaponViewModel _weaponViewModel;

    private List<WeaponCardItem> _weaponCards = new();
    
    [Inject]
    private StaticData _staticData;
    
    public void Init(IChoseWeaponViewModel weaponViewModel) {
        _weaponViewModel = weaponViewModel;

        foreach (var weaponStaticData in _staticData.WeaponsStatic.Datas) {
            var weaponCardItem = Instantiate(_weaponCardPrefab, _scrollContainerContent.transform);
            _weaponCards.Add(weaponCardItem);
            weaponCardItem.Init(weaponStaticData, (weaponId) => { WeaponCardClicked(weaponId); });
        }
        
        _weaponViewModel.ChosenWeapon.Subscribe(weaponId => {
            var weaponStaticData = _staticData.WeaponsStatic.Datas.FirstOrDefault(item => item.Id == weaponId);

            if (weaponStaticData == null) {
                Debug.LogError($"Weapon {weaponId} not found in static!");
                return;
            }

            _chosenWeaponTitle.text = $"Chosen weapon is {weaponStaticData.Title}";

            foreach (var weaponCardItem in _weaponCards) {
                weaponCardItem.SetChosen(weaponCardItem.Id == weaponId);
            }
        }).AddTo(this);
    }

    private void WeaponCardClicked(int weaponId) {
        _weaponViewModel.SelectWeapon(weaponId);
    }

}
