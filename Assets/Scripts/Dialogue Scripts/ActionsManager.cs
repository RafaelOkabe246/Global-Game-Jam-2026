using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class ActionsManager : MonoBehaviour
{
    public static ActionsManager instance;

    public int actions = 10;
    public bool gameEnded;
    public UnityEvent OnEndGame;

    public TextMeshProUGUI horasText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameEnded = false;
        UpdateHoras();
    }

    private void UpdateHoras()
    {
        switch (actions)
        {
            case (10):
                horasText.text = $"14:00";
                break;
            case (9):
                horasText.text = $"15:00";
                break;
            case (8):
                horasText.text = $"16:00";
                break;
            case (7):
                horasText.text = $"17:00";

                break;
            case (6):
                horasText.text = $"18:00";

                break;
            case (5):
                horasText.text = $"19:00";

                break;
            case (4):
                horasText.text = $"20:00";

                break;
            case (3):
                horasText.text = $"21:00";

                break;
            case (2):
                horasText.text = $"22:00";

                break;
            case (1):
                horasText.text = $"23:00";

                break;
        }
    }

    public void SpendAction()
    {
        actions -= 1;
        UpdateHoras();
        
        if(actions <= 0 && !gameEnded)
        {
            gameEnded = true;
            Debug.Log("Disable interactions and open deduction screen");
            OnEndGame?.Invoke();
        }
    }

}
