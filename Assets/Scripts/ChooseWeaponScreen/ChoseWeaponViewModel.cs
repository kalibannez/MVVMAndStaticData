using UniRx;

public interface IChoseWeaponViewModel {
    public void Init(ChoseWeaponModel model);

    public ReactiveProperty<int> ChosenWeapon { get; }

    public void SelectWeapon(int id);
}

public class ChoseWeaponViewModel : IChoseWeaponViewModel {
    private ChoseWeaponModel _model;
    
    public ReactiveProperty<int> ChosenWeapon { get; } = new();

    public void Init(ChoseWeaponModel model) {
        _model = model;
        _model.UpdateViewModel = UpdateViewModel;
        UpdateViewModel();
    }

    public void SelectWeapon(int id) {
        _model.ChoseWeapon(id);
    }

    private void UpdateViewModel() {
        ChosenWeapon.SetValueAndForceNotify(_model.ChosenWeaponId);
    }

}
