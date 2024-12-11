using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int gold;
    [SerializeField] private TextMeshProUGUI goldText;

    [SerializeField] private Sprite[] backgrounds;
    [SerializeField] private int curBackground;
    [SerializeField] private int enemiesTillBackgroundChange;
    [SerializeField] private Image backgroundImage;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        enemiesTillBackgroundChange = 5;
    }

    public void AddGold(int amount)
    {
        gold += amount;
        goldText.text = "Gold: " + gold.ToString();
    }

    public void TakeGold(int amount)
    {
        gold -= amount;
        goldText.text = "Gold: " + gold.ToString();
    }

    public void BackgroundCheck()
    {
        enemiesTillBackgroundChange--;

        if (enemiesTillBackgroundChange == 0)
        {
            enemiesTillBackgroundChange = 5;

            curBackground++;

            if (curBackground == backgrounds.Length)
            {
                curBackground = 0;
            }

            backgroundImage.sprite = backgrounds[curBackground];
        }
    }
}
