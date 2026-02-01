using UnityEngine;
using System.Collections.Generic;

public class FinalDeductionSystem : MonoBehaviour
{
    public List<EndingsSO> PossibleEndings;

    [TextArea (2, 5)] public string defaultEndingDescription = "Final padrão";

    public void EvaluateEnding()
    {
        var manager = GridManager.Instance;
        if (manager == null)
        {
            return;
        }

        if (manager.OcupiedSlot.IsEmpty || manager.WeaponSlot.IsEmpty || manager.MotivationSlot.IsEmpty)
        {
            Debug.Log("Nem todos os slots estão preenchidos."); //tomar cuidado nessa parte, pq obrigatoriamente o jogador
                                                                //precisa coletar pelo menos um item de cada categoria, se
                                                                //isso nao ocorre no roteiro a gente precisa tirar essa checagem
                                                                //e adaptar ela.
            return;
        }

        //ItemID ocupiedId = manager.OcupiedSlot.CurrentItem.Id;
        //ItemID weaponId = manager.WeaponSlot.CurrentItem.Id;
        //ItemID motivationId = manager.MotivationSlot.CurrentItem.Id;
        Tip ocupiedId = manager.OcupiedSlot.CurrentItem.tipId;
        Tip weaponId = manager.WeaponSlot.CurrentItem.tipId;
        Tip motivationId = manager.MotivationSlot.CurrentItem.tipId;
        
        bool foundEnding = false;

        foreach (EndingsSO ending in PossibleEndings)
        {
            if (ending.Culprit == ocupiedId &&
                ending.Weapon == weaponId &&
                ending.Motivation == motivationId)
            {
                GenerateEnding(ending);
                foundEnding = true;
                return;
            }
        }

        if (!foundEnding)
        {
            Debug.Log(defaultEndingDescription);
        }
    }

    private void GenerateEnding(EndingsSO data)
    {
        Debug.Log($"Final X desbloqueado {data.EndingName}");
        Debug.Log(data.EndingDescription);
        UiManager.instance.CloseUi(UiManager.instance.ui_finalAcusation);
        DialogueManager.instance.SelectDialogue(data.EndingDialogue);
    }
}
