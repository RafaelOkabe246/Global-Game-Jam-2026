using UnityEngine;
using UnityEngine.Events;

public class ActionsManager : MonoBehaviour
{
    public static ActionsManager instance;

    public int actions = 10;
    public bool gameEnded;
    public UnityEvent OnEndGame;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameEnded = false;
    }

    public void SpendAction()
    {
        actions -= 1;
        
        if(actions <= 0 && !gameEnded)
        {
            gameEnded = true;
            Debug.Log("Disable interactions and open deduction screen");
            OnEndGame?.Invoke();
        }
    }

}
