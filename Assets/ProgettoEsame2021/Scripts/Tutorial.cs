using System;
using System.Collections;
using System.Collections.Generic;
using ProgettoEsame2021.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    private const float TransitionText = 2.5f;
    public Text tutorialText;

    private void Start()
    {
        if (!GameManager.Instance.TutorialExplained)
        {
            GameManager.Instance.TutorialExplained = true;
            StartCoroutine(ChangeTextRunTime());
        }
        else
        {
            tutorialText.text = "Ben fatto continua così!";
        }
            
    }

    private IEnumerator ChangeTextRunTime()
    {
        tutorialText.fontSize = 80;
        tutorialText.text = "Ciao! Io sono Oliver!";
        yield return new WaitForSeconds(TransitionText);
        tutorialText.fontSize = 80;
        tutorialText.text = "Sono qui per spiegarti brevemente il gioco...";
        yield return new WaitForSeconds(TransitionText);
        tutorialText.fontSize = 80;
        tutorialText.text = "Dovrai superare tutti i livelli per vincere.";
        yield return new WaitForSeconds(TransitionText);
        tutorialText.fontSize = 50;
        tutorialText.text = "Entrato in un livello, ti si porranno delle domande, se non risponderai a tutte correttamente perderai!";
        yield return new WaitForSeconds(TransitionText + 2);
        tutorialText.fontSize = 60;
        tutorialText.text = "Inoltre avrai un tempo per rispondere, se questo scade perdi.";
        yield return new WaitForSeconds(TransitionText + 1);
        tutorialText.fontSize = 80;
        tutorialText.text = "Buona Fortuna! Premi Start per iniziare!";
        yield break;
    }

}
