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
		Text.text = _upgrade.Name + System.Environment.NewLine + System.Environment.NewLine + _upgrade.Description + System.Environment.NewLine + System.Environment.NewLine + "Number of this : " + _upgrade.number;
		TextCost.text = upgrade.Cost + "$";
	}

	public void OnClick()
	{
		if ((maingame._money >= _upgrade.Cost) && _upgrade.number < 10)
		{
			maingame._money -= (int)_upgrade.Cost;
			Maingame.Instance.AddUpgrade(_upgrade);
			_upgrade.number += 1;
			_upgrade.Cost += _upgrade.Cost / 4;
			Text.text = _upgrade.Name + System.Environment.NewLine + System.Environment.NewLine + _upgrade.Description + System.Environment.NewLine + System.Environment.NewLine + "Number of this : " + _upgrade.number;
			TextCost.text = (int)_upgrade.Cost + "$";
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
	public float Cost;
	public int DPS;
}