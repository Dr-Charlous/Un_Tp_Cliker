using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

[Serializable]
public class MonsterInfos
{
    public string Name;
    public int Life;
    public Sprite Sprite;
}

public class Monster : MonoBehaviour
{
    public bool IsAlive()
    {
        return _life > 0;
    }

    [SerializeField]int _life;
    [SerializeField]private int _lifeMax;
    public Text TextLife;
    public Image ImageLife;
    public Sprite Sprite;
    public GameObject Visual;
    public Maingame maingame;
    public Canvas Canvas;

    public void SetMonster(MonsterInfos infos )
    {
        _lifeMax = infos.Life;
        _life = _lifeMax;

        Visual.GetComponent<SpriteRenderer>().sprite = infos.Sprite;
    }
    void Update()
    {
        TextLife.text = $"{_life}/{_lifeMax}";

        float percent = (float)_life / (float)_lifeMax;
        ImageLife.fillAmount = percent;

        if (_life <= 0)
        {
            maingame.NextMonster();
        }
    }

    public void Hit(int damage)
    {
        maingame._money += maingame.ClickPower;
        _life -= damage;
        Visual.transform.DOComplete();
        Visual.transform.DOPunchScale(new Vector3(0.001f, 0, 0), 0.3f);
    }
}
