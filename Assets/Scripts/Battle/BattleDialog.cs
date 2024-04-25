using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleDialog : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogText;
    // letters per secoend
    [SerializeField] int typeSpeed;
    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetails;

    [SerializeField] List<TextMeshProUGUI> actions;
    [SerializeField] List<TextMeshProUGUI> moves;


    [SerializeField] TextMeshProUGUI ppText;
    [SerializeField] TextMeshProUGUI TypeText;



    public void SetDialog(string dialog)
    {
        Debug.Log("dialog");
        dialogText.text = dialog;
    }
    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach(char letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds (1f/typeSpeed);

        }
    }

    public void EnableDialogText(bool enabled) => dialogText.enabled = enabled;
    public void EnableActionSelector(bool enabled) => actionSelector.SetActive(enabled);
    public void EnableMovesSelector(bool enabled)
    {
        moveSelector.SetActive(enabled);
        moveDetails.SetActive(enabled);
    }
}
