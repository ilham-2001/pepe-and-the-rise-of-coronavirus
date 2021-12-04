using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DialogueSystems
{
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finishedLine { get; private set; }
        protected IEnumerator WriteText(string input, Text textHolder, Font textFont, Color textColor, float delay, AudioClip audio)
        {
            textHolder.color = textColor;
            textHolder.font = textFont;
            textHolder.text = "";

            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                SoundManager.instance.PlaySound(audio);
                yield return new WaitForSeconds(delay);
            }

            yield return new WaitUntil(() => Input.GetMouseButton(0));
            finishedLine = true;
        }
    }


}

