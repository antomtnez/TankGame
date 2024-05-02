using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TankBattleGameView : MonoBehaviour
{
    [SerializeField]
    private Slider playerHealthSlider;
    [SerializeField]
    private Slider enemyHealthSlider;

    public void SetPlayerMaxHealth(int value)
    {
        playerHealthSlider.maxValue = value;
        playerHealthSlider.value = value;
    }

    public void SetEnemyMaxHealth(int value)
    {
        enemyHealthSlider.maxValue = value;
        enemyHealthSlider.value = value;
    }

    public void SetPlayerCurrentHealth(int value)
    {
        playerHealthSlider.value = value;
    }

    public void SetEnemyCurrentHealth(int value)
    {
        enemyHealthSlider.value = value;
    }
}
