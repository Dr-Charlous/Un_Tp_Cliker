using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class Maingame : MonoBehaviour
{
	public List<MonsterInfos> Monsters;
	int _currentMonster;
	public Monster Monster;
	public GameObject PrefabHitPoint;

    private void Start()
    {
		Monster.SetMonster(Monsters[_currentMonster]);
    }

	private void NextMonster()
	{
		_currentMonster++;
		Monster.SetMonster(Monsters[_currentMonster]);
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(world, Vector2.zero);

			if (hit.collider != null)
			{
				Debug.Log(hit.collider.name);
			}

			Monster monster = hit.collider.GetComponent<Monster>();
			monster.Hit(1);
			GameObject go = GameObject.Instantiate(PrefabHitPoint, monster.Canvas.transform, false);
			go.transform.localPosition = UnityEngine.Random.insideUnitCircle * 100;
			go.transform.DOLocalMoveY(150, 0.8f);
			go.GetComponent<Text>().DOFade(0, 0.8f);
			GameObject.Destroy(go, 0.8f);

			if ( monster.IsAlive() == false)
            {
				NextMonster();
            }
		}
	}
}
