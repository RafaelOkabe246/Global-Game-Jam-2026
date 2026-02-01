using UnityEngine;
using UnityEngine.Events;

public class ActionsManager : MonoBehaviour
{
    public static ActionsManager instance;

    public int actions = 10;

    public UnityEvent OnEndGame;

    private void Awake()
    {
        instance = this;
    }

    public void SpendAction()
    {
        actions -= 1;
        
        if(actions <= 0)
        {
            Debug.Log("Disable interactions and open deduction screen");
            OnEndGame?.Invoke();
        }
    }

}
