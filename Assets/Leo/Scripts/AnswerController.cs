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

        public bool IsCorrect
        {
            get => isCorrect;
        }
        
        public TextMeshProUGUI ButtonTextMeshPro
        {
            get => buttonTextMeshPro;
        }

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
    }
    
}
