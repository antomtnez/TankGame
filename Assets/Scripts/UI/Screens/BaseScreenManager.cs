using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScreenManager : MonoBehaviour, IScreenManager
{
    protected ApplicationManager.AppStates stateAssociatedToScreen { get; set; }

    public void HidePanel()
    {
        this.gameObject.SetActive(false);
    }

    public void ShowPanel()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void UpdateScreen()
    {
        throw new System.NotImplementedException();
    }

    public virtual void InitializeScreen()
    {
        throw new System.NotImplementedException();
    }

    public ApplicationManager.AppStates GetAssociatedState()
    {
        return stateAssociatedToScreen;
    }
}
