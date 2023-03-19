using UnityEngine;
using Zenject;

public class DataInstaller : MonoInstaller {

   [SerializeField]
   private StaticData _staticData;
   
   public override void InstallBindings() {
      Debug.Log("1");
      Container.BindInstance(_staticData);
   }

}
