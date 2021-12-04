using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DialogueSystems
{
    public class DialogueLine : DialogueBaseClass
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

        [Header("Character Image")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image imageHolder;

        private Text textHolder;


        private void Awake()
        {
            textHolder = GetComponent<Text>();
            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true;
        }

        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, textFont, textColor, delay, audioSource, waitTime));
        }
    }

}
