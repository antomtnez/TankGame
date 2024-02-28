using TMPro;
using UnityEngine;

public class BattleFinishView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text finishMessageText;

    public void SetPlayerWinMessage()
    {
        finishMessageText.text = "You win!";
    }

    public void SetEnemyWinMessage()
    {
        finishMessageText.text = "You lose!";
    }
}
