using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform characterObject;

    private void LateUpdate() //work after update, real time camera and movement codes
    {
        characterObject.transform.position += Vector3.forward * Time.deltaTime * 1f;  //character moves all time
    }
}
