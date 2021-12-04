using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystems
{
    public class DialogueHolder : MonoBehaviour
    {

        private void Awake()
        {
            StartCoroutine(dialogueSequence());
        }
        private IEnumerator dialogueSequence()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Deativate();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finishedLine);
            }

            gameObject.SetActive(false);
        }

        private void Deativate()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

}