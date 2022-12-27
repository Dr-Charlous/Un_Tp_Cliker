using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UpgradeUI : MonoBehaviour
{
	public class Upgrade_UI : MonoBehaviour
	{
		public Image Image;
		public Text Text;
		public Text TextCost;
	}

	public class Upgrade
	{
		public string Name;
		public string Description;
		public Sprite Sprite;
		public int Cost;
		public int DPS;
	}
}
