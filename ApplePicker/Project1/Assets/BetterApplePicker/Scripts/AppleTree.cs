using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public GameObject badApplePrefab;
    public GameObject mutatedApplePrefab;

    //Chance at which Bad Apples will be instantiated
    public float badAppleChance = 0.2f;

    //Chance at which Mutated Apples will be instantiated
    public float mutatedAppleChance = 0.05f;

    //Speed at which the Apple Tree moves
    public float speed = 1f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    //Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

/*    //Rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 3f;

    //Rate at which Bad Apples will be instantiated
    public float secondsBetweenBadAppleDrops = 5f;*/


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        } 
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }


    void DropApple()
    {
        float secondsBetweenAppleDrops = 1f;
        float random = Random.Range(0f, 1f);
        if (random < .5f)
            secondsBetweenAppleDrops = .5f;

        GameObject apple = Instantiate<GameObject>(GetRandomApple());
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    GameObject GetRandomApple()
    {
        float random = Random.Range(0f, 1f);
        if (random < mutatedAppleChance)
            return mutatedApplePrefab;
        else if (random < badAppleChance)
            return badApplePrefab;
        else
            return applePrefab;
    }
}

/*    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    void DropBadApple()
    {
        GameObject badApple = Instantiate<GameObject>(badApplePrefab);
        badApple.transform.position = transform.position;
        Invoke("DropBadApple", secondsBetweenBadAppleDrops);
    }*/
