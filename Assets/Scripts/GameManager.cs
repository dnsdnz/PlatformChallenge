using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform characterObject;

    private void LateUpdate() //for continuous physics codes 
    {
        characterObject.transform.position += Vector3.forward * Time.deltaTime * 1f;  //character moves all time
    }
}
