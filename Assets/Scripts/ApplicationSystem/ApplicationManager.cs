using UnityEditor;

public class ApplicationManager : StateManager<ApplicationManager.AppStates>
{
    public enum AppStates { StartGame, EnemyMoveTurn, PlayerMoveTurn, EnemyAttackTurn, PlayerAttackTurn, FinishGame, CloseGame }
    public static ApplicationManager Instance;
    public static IUIManager UIManager { get; private set; }
    public static IGameManager GameManager { get; private set; }

    void Awake()
    {
        if(Instance == null) Instance = this;
        FindComponents(FindObjectOfType<UIManager>(), FindObjectOfType<GameManager>());
        currentState = new StartGame(AppStates.StartGame);
        SetDictionary();
    }

    void Update()
    {
        currentState.UpdateState();
    }

    void FindComponents(IUIManager uIManager, IGameManager gameManager)
    {
        UIManager = uIManager;
        GameManager = gameManager;
    }

    void SetDictionary()
    {
        states.Add(AppStates.StartGame, currentState);
        states.Add(AppStates.EnemyMoveTurn, new EnemyMoveTurn(AppStates.EnemyMoveTurn));
        states.Add(AppStates.PlayerMoveTurn, new PlayerMoveTurn(AppStates.PlayerMoveTurn));
        states.Add(AppStates.EnemyAttackTurn, new EnemyAttackTurn(AppStates.EnemyAttackTurn));
        states.Add(AppStates.PlayerAttackTurn, new PlayerAttackTurn(AppStates.PlayerAttackTurn));
        states.Add(AppStates.FinishGame, new FinishGame(AppStates.FinishGame));
        states.Add(AppStates.CloseGame, new CloseGame(AppStates.CloseGame));
    }
}
