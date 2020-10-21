 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
	public GameObject turret;
	public Vector3 positionOffset;
	public Color hoverColor;
	private Color startColor;
	public Color notEnoughMoneyColor;

	private Renderer rend;
	BuilderManager builderManager;
	public TurretBluePrint turretBluePrint;
	
	 void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
		builderManager = BuilderManager.instance;
	}

	public Vector3 GetBuildPosition()
	{
		return transform.position + positionOffset;  
	}

	 void OnMouseDown()
	{
		if (!builderManager.canBuild)
			return;

		if (turret != null)
		{
			builderManager.SelectedNode(this);
				return;
		}

		builderManager.BuildTurretOn(this);
	}

	public void SellTurret()
	{
		PlayerStats.Money += turretBluePrint.GetSellAmount();

		Destroy(turret);
		turretBluePrint = null;
	}

	void OnMouseEnter()
	{

		if (!builderManager.canBuild) 
			return;

		if (builderManager.HasMoney)
		{
			rend.material.color = hoverColor;
		}
		else
		{
			rend.material.color = notEnoughMoneyColor;
		}
		
	}

	 void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
