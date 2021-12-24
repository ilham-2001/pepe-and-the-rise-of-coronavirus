using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{


    private void Start()
    {
        StartCoroutine(MoveScene());
    }


    private IEnumerator MoveScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Stage 1");
    }
}
