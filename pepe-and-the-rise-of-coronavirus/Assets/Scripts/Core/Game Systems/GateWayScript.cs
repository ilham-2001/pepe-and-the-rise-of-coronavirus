using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateWayScript : MonoBehaviour
{

    [SerializeField] private string namaScene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        print("Masuk gerbang");
        // Masuk scene baru saat melewati objek ber-tag "Door"
        if (col.tag == "Player")
        {
            MoveScene(namaScene);
        }
    }


    [SerializeField]
    private void MoveScene(string pageName)
    {
        SceneManager.LoadScene(pageName);
    }
}
