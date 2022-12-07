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

    public void SetMonster(MonsterInfos infos )
    {
        _lifeMax = infos.Life;
        _life = _lifeMax;

        Visual.GetComponent<SpriteRenderer>().sprite = infos.Sprite;
    }
    public void UpdateLife()
    {
        TextLife.text = $"{_life}/{_lifeMax}";

        float percent = (float)_life / (float)_lifeMax;
        ImageLife.fillAmount = percent;
    }

    public void Awake()
    {
        UpdateLife();
    }

    public void Hit(int damage)
    {
        _life -= damage;
        UpdateLife();
        Visual.transform.DOComplete();
        Visual.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 0.3f);
    }
}
