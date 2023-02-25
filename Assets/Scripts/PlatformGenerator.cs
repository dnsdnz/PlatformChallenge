using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformRoot; //parent of platforms
    
    public GameObject platformPrefab; //prefab object of platforms

    public List<GameObject> platformList = new List<GameObject>();
 
    private Coroutine nextPLatform; //coroutine for continuos creation of platfroms

    private void Start()
    {
        GameObject tempPlatform = GameObject.Instantiate(platformPrefab,  //create a temp platform at start in root
            platformRoot.transform.position,
            platformRoot.transform.rotation, platformRoot.transform);
        
        platformList.Add(tempPlatform); //add to platform list

        nextPLatform = StartCoroutine(NextPlatform()); //repeat creation
    }

    private GameObject tempPlatform;

    IEnumerator NextPlatform() //coroutine 
    {
        yield return new WaitForSeconds(2);  //create new in every 2 seconds
        
        tempPlatform = GameObject.Instantiate(platformPrefab,platformRoot.transform.position,platformRoot.transform.rotation, platformRoot.transform);

        if (platformList.Count % 2 == 0)
        {
            tempPlatform.transform.position += new Vector3(4, 0, 3 * platformList.Count); //create from left
        }
        else
        {
            tempPlatform.transform.position += new Vector3(-4, 0, 3 * platformList.Count); //create from right
        }
      
        platformList.Add(tempPlatform);
        
        nextPLatform = StartCoroutine(NextPlatform()); //repeat creation
    }

    private void LateUpdate() //move each creation
    {
        if (tempPlatform != null)
        {
            if (platformList.Count % 2 == 0) //left 
            {
                tempPlatform.transform.position += tempPlatform.transform.right * Time.deltaTime * 3f; //set speed related to time(get faster) 
            }
            else //right
            {
                tempPlatform.transform.position -= tempPlatform.transform.right * Time.deltaTime * 3f;
            }   
        }

        if (Input.GetMouseButtonDown(0)) //screen tap
        { 
            StopCoroutine(nextPLatform); //stop creation and movement
            tempPlatform = null;

            nextPLatform = StartCoroutine(NextPlatform()); //start again after 2 seconds(WaitForSeconds in coroutine)
        }
    }
}