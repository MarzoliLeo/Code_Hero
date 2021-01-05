using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Leo.Scripts
{
    public class AnswerController : MonoBehaviour
    {
        private TextMeshProUGUI buttonTextMeshPro;
        private bool isCorrect;
        
        public delegate void OnButtonClickDelegate(bool isCorrect);
        public static event  OnButtonClickDelegate onCheckAnswerEvent;

        public bool IsCorrect
        {
            get => isCorrect;
        }
        
        public TextMeshProUGUI ButtonTextMeshPro
        {
            get => buttonTextMeshPro;
        }

        //Collegamento all'evento
        private void Awake()
        {
            buttonTextMeshPro = this.gameObject.GetComponent<TextMeshProUGUI>();
        }

        //Inizializzatore delle risposte
        public void SetAnswer(string text, bool value)
        {
            this.buttonTextMeshPro.text = text;
            this.isCorrect = value;
        }

        public void CheckAnswer()
        {
            onCheckAnswerEvent?.Invoke(IsCorrect);
        }
        
    }
    
}
