using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text levelText;
    public GameObject buttonStartLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        SetActiveButton(false);
    }
    
    //Imposta nell' UI il testo secondo il livello di dove sei.
    public void SetLevelText(string text)
    {
        levelText.text = text; 
    }

    //Metodo per accendere e spegnere il bottone
    public void SetActiveButton(bool isActive)
    {
        buttonStartLevel.SetActive(isActive);
    }
}
