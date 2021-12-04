using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace NaratorDialogue
{
    public class NaratorDialogueLine : NaratorBaseDialogue
    {
        [Header("Text Dialogue")]
        [SerializeField] private string input;
        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont;

        [Header("Time Parameter")]
        [SerializeField] private float delay;
        [SerializeField] private float waitTime;

        [Header("Audio Parameter")]
        [SerializeField] private AudioClip audioSource;
        private Text textHolder;


        private void Awake()
        {
            textHolder = GetComponent<Text>();
        }

        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, textFont, textColor, delay, audioSource, waitTime));
        }
    }

}
