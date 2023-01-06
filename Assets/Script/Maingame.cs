using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class Maingame : MonoBehaviour
{

	public static Maingame Instance;

	private void Awake()
	{
		Instance = this;
	}


	public List<MonsterInfos> Monsters;
	public List<Upgrade> Upgrades;
	public List<Upgrade> _unlockedUpgrades = new List<Upgrade>();
	int _currentMonster;
	public Monster Monster;
	public int _money = 0;
	public int ClickPower = 1;
	public Text Score;
	public GameObject PrefabHitPoint;
	public GameObject PrefabHitUpgradeUI;
	public GameObject ParentUpgrades;
	public GameObject MenuPage;
	public GameObject ShopPage;
	private float _timerAutoDamage = 0;


	



    private void Start()
    {
		Monster.SetMonster(Monsters[_currentMonster]);

		foreach (var upgrade in Upgrades)
        {
			GameObject go = GameObject.Instantiate(PrefabHitUpgradeUI, ParentUpgrades.transform, false);
			go.transform.localPosition = Vector3.zero;
			go.GetComponent<UpgradeUI>().Initialize(upgrade);
		}
    }

	public void NextMonster()
	{
		System.Random random = new System.Random();
		_currentMonster = UnityEngine.Random.Range(0, Monsters.Count);
		Monster.SetMonster(Monsters[_currentMonster]);
	}

	

	void Update()
	{
		Score.text = $" Your money : {_money} $";
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(world, Vector2.zero);

            if (hit.collider != null)
            {
                //Debug.Log(hit.collider.name);

				Monster monster = hit.collider.GetComponent<Monster>();
				monster.Hit(ClickPower);
				GameObject go = GameObject.Instantiate(PrefabHitPoint, monster.Canvas.transform, false);
				go.transform.localPosition = UnityEngine.Random.insideUnitCircle * 200;
				go.transform.DOLocalMoveY(150, 0.8f);
				go.GetComponent<Text>().DOFade(0, 0.8f);
				GameObject.Destroy(go, 0.8f);

				if (monster.IsAlive() == false)
				{
					NextMonster();
				}
			}

            

			
		}

		_timerAutoDamage += Time.deltaTime;

		if (_timerAutoDamage >= 1.0f)
        {
			_timerAutoDamage = 0;
			foreach (var upgrade in _unlockedUpgrades)
            {
				Monster.Hit(upgrade.DPS);
            }
        }
	}


	void Hit(int damage,Monster monster)
    {
		monster.Hit(damage);

		GameObject go = GameObject.Instantiate(PrefabHitPoint, monster.Canvas.transform, false);
		go.transform.localPosition = UnityEngine.Random.insideUnitCircle * 100;
		go.transform.DOLocalMoveY(150, 0.8f);
		go.GetComponent<Text>().DOFade(0, 0.8f);
		GameObject.Destroy(go, 0.8f);

		if (monster.IsAlive() == false)
        {
			NextMonster();
        }
    }

	public void AddUpgrade( Upgrade upgrade )
    {
		_unlockedUpgrades.Add(upgrade);
    }

	public void ShopButton()
    {
		ShopPage.SetActive(!ShopPage.activeSelf);
		MenuPage.SetActive(false);
    }

	public void MenuButton()
	{
		MenuPage.SetActive(!MenuPage.activeSelf);
		ShopPage.SetActive(false);
	}
}
