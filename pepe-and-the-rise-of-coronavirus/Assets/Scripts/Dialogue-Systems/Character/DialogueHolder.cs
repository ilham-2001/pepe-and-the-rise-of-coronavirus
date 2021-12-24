using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            // gameObject.SetActive(false); 
            StartCoroutine(SceneTransition());

        }


        private IEnumerator SceneTransition()
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Intro Stage 1");
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