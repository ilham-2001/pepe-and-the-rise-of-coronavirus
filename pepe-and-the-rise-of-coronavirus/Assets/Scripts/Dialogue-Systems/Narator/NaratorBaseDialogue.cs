using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace NaratorDialogue
{
    public class NaratorBaseDialogue : MonoBehaviour
    {

        public bool finishedLine { get; private set; }
        protected IEnumerator WriteText(string input, Text textHolder, Font textFont, Color textColor, float delay, AudioClip audio, float waitTime)
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

            yield return new WaitForSeconds(waitTime);
            finishedLine = true;
        }

    }
}
