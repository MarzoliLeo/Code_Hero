using TMPro;
using UnityEngine;

namespace ProgettoEsame2021.Scripts
{
    public class AnswerController : MonoBehaviour
    {
        private TextMeshProUGUI buttonTextMeshPro;
        private bool isCorrect;
        
        //Definisco un delegato per associare un evento.
        public delegate void OnButtonClickDelegate(bool isCorrect);
        //Definisco un evento che si attiverà al momento di valutare la risposta premuta.
        public static event  OnButtonClickDelegate onCheckAnswerEvent;
    
        //Propietà
        public bool IsCorrect
        {
            get => isCorrect;
        }
        
        public TextMeshProUGUI ButtonTextMeshPro
        {
            get => buttonTextMeshPro;
        }

        //La funzione Awake verra' chiamata prima di qualsiasi altro metodo. (anche prima di Start)
        //Funzione per l'associazione delle variabili. (Paragonabile al construct)
        private void Awake()
        {
            buttonTextMeshPro = GetComponent<TextMeshProUGUI>();
        }

        //Funzione per assegnare valori alle risposte.
        public void SetAnswer(string text, bool value)
        {
            this.buttonTextMeshPro.text = text;
            this.isCorrect = value;
        }
        
        //Funzione per valutare la risposta attivando l'evento.
        public void CheckAnswer()
        {
            onCheckAnswerEvent?.Invoke(IsCorrect);
        }
        
    }
    
}
