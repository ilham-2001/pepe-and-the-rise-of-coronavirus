using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NaratorDialogue
{
    public class NaratorDialogueHolder : MonoBehaviour
    {
        private void Awake()
        {
            StartCoroutine(dialogueSequence());
        }
        private IEnumerator dialogueSequence()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (i == 0)
                {
                    Deativate();

                }
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<NaratorDialogueLine>().finishedLine);
            }

            StartCoroutine(SceneTransition());
        }

        private void Deativate()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        private IEnumerator SceneTransition()
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Cutscene");
        }

    }
}

