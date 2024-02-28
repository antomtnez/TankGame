using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IUIManager
{
    protected Dictionary<ApplicationManager.AppStates, IScreenManager> screenManagers = new Dictionary<ApplicationManager.AppStates, IScreenManager>();
    protected ApplicationManager.AppStates activeScreenKey;

    void Start()
    {
        if(transform.childCount > 0)
        {
            foreach(Transform child in transform){
                IScreenManager childScreenManager = child.gameObject.GetComponent<IScreenManager>();
                childScreenManager.InitializeScreen();
                screenManagers.Add(
                    childScreenManager.GetAssociatedState(), childScreenManager
                );
            }
        }
    }

    public void UpdateUI()
    {
        if(screenManagers.ContainsKey(activeScreenKey))
            screenManagers[activeScreenKey].UpdateScreen();
    }

    public void AddScreen(IScreenManager screenManager, ApplicationManager.AppStates appStateKey)
    {
        screenManagers.Add(appStateKey, screenManager);
    }

    public void RemoveScreen(ApplicationManager.AppStates appStateKey)
    {
        screenManagers.Remove(appStateKey);
    }
    
    public void HidePanel(ApplicationManager.AppStates stateKey)
    {
        if(screenManagers.ContainsKey(stateKey))
            screenManagers[stateKey].HidePanel();
    }

    public void ShowPanel(ApplicationManager.AppStates stateKey)
    {
        if(screenManagers.ContainsKey(stateKey)){
            screenManagers[stateKey].ShowPanel();
            activeScreenKey = stateKey;
        }
    }
}
