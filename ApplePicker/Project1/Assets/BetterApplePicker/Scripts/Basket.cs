using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{

    [Header("Set Dynamically")]
    public Text scoreGT;

    // Start is called before the first frame update
    void Start()
    {
        //Find a reference to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter"); //Note: Weir feels uncomfortable by this
        //Get the Text Component of that Game Object
        scoreGT = scoreGO.GetComponent<Text>();
        //Set the starting number of points to 0
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        //The Camera's position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;

        //Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Find out what hit this basket
        GameObject collidedWith = collision.gameObject;

        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
            //Parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);
            //Add points for catching the apple
            score += 100;
            //Convert the score back to a string and display it
            scoreGT.text = score.ToString();

            //Track the High Score
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }

        else if (collidedWith.tag == "Bad Apple")
        {
            Destroy(collidedWith);
            //Parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);
            //Subtract points for catching the bad apple
            score -= 200;
            //Convert the score back to a string and display it
            scoreGT.text = score.ToString();

            //Track the High Score
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }

        else if (collidedWith.tag == "Mutated Apple")
        {
            Destroy(collidedWith);

            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            //Call the public AppleDestroyed() method of apScript
            apScript.CaughtMutatedApple();

            //Parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);
            //Subtract points for catching the mutated apple
            score -= 1000;
            //Convert the score back to a string and display it
            scoreGT.text = score.ToString();

            //Track the High Score
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
