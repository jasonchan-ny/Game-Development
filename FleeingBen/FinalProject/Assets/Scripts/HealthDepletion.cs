using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthDepletion : MonoBehaviour
{
    public string scenename;
    public float lives = 3;
    private bool istriggered = false;

    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        {
            AudioManager.Instance.PlayBenYesAudio();
            SceneManager.LoadScene(scenename);
            Debug.Log("DIED");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fireball"))
        {
            AudioManager.Instance.PlayBenLaughAudio();

            if (istriggered == false)
            {
                lives--;
                Debug.Log(lives);
                istriggered = true;
            }
        }
    }
    
    void OnTriggerExit(Collider coll)
    {
        istriggered = false;
    }

}
