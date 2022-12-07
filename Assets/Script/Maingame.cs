using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maingame : MonoBehaviour
{
	public List<MonsterInfos> Monsters;
	int _currentMonster;
	public Monster Monster;

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
			
			if ( monster.IsAlive() == false)
            {
				NextMonster();
            }
		}
	}
}
