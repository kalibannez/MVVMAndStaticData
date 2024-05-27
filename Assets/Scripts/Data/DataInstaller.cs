using UnityEngine;
using Zenject;

public class DataInstaller : MonoInstaller {

   [SerializeField]
   private StaticData _staticData;
   
   public override void InstallBindings() {
      Container.BindInstance(_staticData);
   }

}
