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

    public void Initialize(Upgrade upgrade)
	{
		_upgrade = upgrade;
		Image.sprite = upgrade.Sprite;
		Text.text = upgrade.Name + System.Environment.NewLine + upgrade.Description;
		TextCost.text = upgrade.Cost + "$";
	}

	public void OnClick()
	{
		MainGame.Instance.AddUpgrade(_upgrade);
	}
}

[Serializable]
public class Upgrade
{
	public string Name;
	public string Description;
	public Sprite Sprite;
	public int Cost;
	public int DPS;
}