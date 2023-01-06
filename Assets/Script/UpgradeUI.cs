using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UpgradeUI : MonoBehaviour
{
	public Image Image;
	public Text Text;
	public Text TextCost;
    private Upgrade _upgrade;
	public Maingame maingame;

	public void Initialize(Upgrade upgrade)
	{
		_upgrade = upgrade;
		Image.sprite = upgrade.Sprite;
		Text.text = upgrade.Name + System.Environment.NewLine + upgrade.Description + System.Environment.NewLine + "Number of this : " + upgrade.number;
		TextCost.text = upgrade.Cost + "$";
	}

	public void OnClick()
	{
		if (maingame._money >= _upgrade.Cost)
		{
			maingame._money -= _upgrade.Cost;
			Maingame.Instance.AddUpgrade(_upgrade);
			_upgrade.number += 1;
			Text.text = _upgrade.Name + System.Environment.NewLine + _upgrade.Description + System.Environment.NewLine + "Number of this : " + _upgrade.number;
		}
	}
}

[Serializable]
public class Upgrade
{
	public int number = 0;
	public string Name;
	public string Description;
	public Sprite Sprite;
	public int Cost;
	public int DPS;
}