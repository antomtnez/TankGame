using UnityEngine;
using TMPro;

public class BattleStateView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text storyMessageText;
    [SerializeField]
    private TMP_Text currentMessageText;

    void Start(){
        ApplicationManager.Instance.OnStateChanged += OnStateChanged;
    }

    public void SetConsoleMessageText(string message)
    {
        storyMessageText.text += "\n>" + message;
        currentMessageText.SetText("\n>" + message);
    }

    public void OnStateChanged()
    {
        switch(ApplicationManager.Instance.CurrentState.stateKey)
        {
            case ApplicationManager.AppStates.PlayerMoveTurn:
                SetConsoleMessageText("move ur tank?\n[q-pass turn]");
                break;
            case ApplicationManager.AppStates.PlayerAttackTurn:
                SetConsoleMessageText("attack?\n[q-pass turn]");
                break;
            case ApplicationManager.AppStates.EnemyMoveTurn:
                SetConsoleMessageText("enemy move...");
                break;
            case ApplicationManager.AppStates.EnemyAttackTurn:
                SetConsoleMessageText("enemy attk...");
                break;
            default:
                SetConsoleMessageText("err 034\nnot found");
                break;
        }
    }
}