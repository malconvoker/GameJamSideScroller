using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCheck : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            
            
            Invoke("CompleteLevel", 1f);

        }
    }

    private void CompleteLevel()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}

