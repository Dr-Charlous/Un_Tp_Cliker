using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
	public class UpgradeUI : MonoBehaviour
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
