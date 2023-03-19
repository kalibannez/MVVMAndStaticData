using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCardItem : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI _title;
    
    [SerializeField]
    private TextMeshProUGUI _description;
    
    [SerializeField]
    private TextMeshProUGUI _damage;

    [SerializeField]
    private Image _bg;
    
    public int Id { get; private set; }

    private Action<int> _onClicked;
    
    public void Init(WeaponStaticData weaponStaticData, Action<int> onClicked) {
        Id = weaponStaticData.Id;
        _onClicked = onClicked;

        _title.text = weaponStaticData.Title;
        _description.text = weaponStaticData.Description;
        _damage.text = $"<color=\"black\">Damage: <color=\"red\">{weaponStaticData.Damage}</color>";
    }

    public void Click() => _onClicked(Id);

    public void SetChosen(bool chosen) {
        if (chosen) {
            _bg.color = Color.green;
        } else {
            _bg.color = Color.yellow;
        }
    }

}
