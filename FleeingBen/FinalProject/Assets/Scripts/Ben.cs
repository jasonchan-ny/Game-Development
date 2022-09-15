using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ben : MonoBehaviour
{
    public string scenename;
    public float health = 100;
    private bool istriggered = false;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            AudioManager.Instance.PlayBenNoAudio();
            Destroy(gameObject);
            SceneManager.LoadScene("Victory");
            Debug.Log("VICTORY");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Waterball"))
        {
            if (istriggered == false)
            {
                health--;
                Debug.Log(health);
                istriggered = true;
            }
        }
    }

    void OnTriggerExit(Collider coll)
    {
        istriggered = false;
    }
}
