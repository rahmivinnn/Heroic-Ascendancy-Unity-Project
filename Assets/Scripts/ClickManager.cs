using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private List<float> autoClickerLastTime = new List<float>();
    [SerializeField] private int autoClickerCost;
    [SerializeField] private TextMeshProUGUI amountAutoClickersText;

    private void Update()
    {
        for (int i = 0; i < autoClickerLastTime.Count; i++)
        {
            if (Time.time - autoClickerLastTime[i] >= 1.0f)
            {
                {
                    autoClickerLastTime[i] = Time.time;
                    EnemyManager.instance.curEnemy.Damage();
                }
            }
        }
    }

    public void OnBuyAutoClicker()
    {
        if (GameManager.instance.gold >= autoClickerCost)
        {
            GameManager.instance.TakeGold(autoClickerCost);
            autoClickerLastTime.Add(Time.time);

            amountAutoClickersText.text = "X " + autoClickerLastTime.Count.ToString();
        }
    }
}
