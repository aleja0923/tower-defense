using UnityEngine;

public class Shop : MonoBehaviour
{
	BuilderManager builderManager;
	public TurretBluePrint standardTurret;
	//public TurretBluePrint misilLauncher;

	 void Start()
	{
		builderManager = BuilderManager.instance;
	}

	public void SelectStandardTurret()
	{
		Debug.Log("compre");
		builderManager.SelectTurretToBuild(standardTurret);
	}
}
