using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;
    public int lives = 3;
    public Text livesText;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            AudioManager.Instance.PlayDyingAudio();
            //Debug.Log("Hey Gabe");
            player.transform.position = spawnPoint.position;
            lives--;
            livesText.text = "Lives: " + lives;

            if (lives == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            //player.gameObject.SetActive(false);


            //Debug.Log("Hey Gabe");
            //player.transform.position = spawnPoint.transform.position; //new Vector3(-20, 1, 9);
            //col.gameObject.GetComponent<CharacterControls>().LoadCheckPoint();
        }

    }

    void Update()
    {
        if (player.gameObject.activeInHierarchy == false)
        {
            player.transform.position = spawnPoint.transform.position;
            player.SetActive(true);
        }

    }
/*    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
           // col.gameObject.GetComponent<CharacterControls>().LoadCheckPoint();
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<CharacterControls>().LoadCheckPoint();
        }
    }*/

    //void OnTriggerEnter(Collider col)
   // {
      //  if (col.gameObject.tag == "Player")
     //   {
            //col.gameObject.GetComponent<CharacterControls>().LoadCheckPoint();
    //    }
   // }
}
