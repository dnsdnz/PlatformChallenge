using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackPrefab : MonoBehaviour
{
    public List<GameObject> sliceObjects = new List<GameObject>();
  
    public void Slicer()
    {
        StartCoroutine(SlicerCor()); 
    }
   
    IEnumerator SlicerCor()
    { 
        foreach (var sliceItem in sliceObjects)
        {
            yield return new WaitForFixedUpdate();
            sliceItem.SetActive(false);

            yield return new WaitForFixedUpdate();
            sliceItem.SetActive(true); 
            
            //enabled = false;
        } 
    }
}