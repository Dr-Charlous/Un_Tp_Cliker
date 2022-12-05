using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maingame : MonoBehaviour
{
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
		}
	}
}
