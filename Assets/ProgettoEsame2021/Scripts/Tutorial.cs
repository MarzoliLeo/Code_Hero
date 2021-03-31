using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ProgettoEsame2021.Scripts
{
    public class Tutorial : MonoBehaviour
    {
        //Costante che definisce l'intervallo per mostrare i messaggi.
        private const float TransitionText = 2.5f;
    
        //Oggetto di gioco da modificare per mostrare il messaggio.
        public Text tutorialText;

        //Funzione che inizilizza le variabili e viene eseguita non appena lo script è caricato.
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

        //Funzione che permette di mostrare a video il tutorial, con i messaggi.
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
            yield return new WaitForSeconds(TransitionText + 2.5f);
            tutorialText.fontSize = 60;
            tutorialText.text = "Inoltre avrai un tempo per rispondere, se questo scade perdi.";
            yield return new WaitForSeconds(TransitionText + 1.5f);
            tutorialText.fontSize = 60;
            tutorialText.text = "Troverai persino dei PowerUp prima di ogni livello, sarai fortunato?";
            yield return new WaitForSeconds(TransitionText + 1.5f);
            tutorialText.fontSize = 80;
            tutorialText.text = "Buona Fortuna! Premi Start per iniziare!";
            yield break;
        }

    }
}
