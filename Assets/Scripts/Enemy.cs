using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Image healthBarFill;
    [SerializeField] private int goldToGive;
    [SerializeField] private int curHp;
    [SerializeField] private int maxHp;
    [SerializeField] private Animation anim;

    public void Damage()
    {
        curHp--;
        healthBarFill.fillAmount = (float)curHp / (float)maxHp;

        anim.Stop();
        anim.Play();

        if (curHp <= 0)
        {
            Defeated();
        }
    }

    public void Defeated()
    {
        GameManager.instance.AddGold(goldToGive);
        EnemyManager.instance.DefeatEnemy(gameObject);

        Debug.Log("defeated");
    }
}
