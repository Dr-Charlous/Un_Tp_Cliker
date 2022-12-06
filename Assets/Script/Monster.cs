using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField]int Life;
    private int _LifeMax;
    public Text TextLife;
    public Image ImageLife;

    public void UpdateLife()
    {
        TextLife.text = $"{Life}/{_LifeMax}";

        float percent = (float)Life / (float)_LifeMax;
        ImageLife.fillAmount = percent;
    }

    public void Awake()
    {
        UpdateLife();
    }

    public void Hit(int damage)
    {
        Life -= damage;
        UpdateLife();
    }
}
