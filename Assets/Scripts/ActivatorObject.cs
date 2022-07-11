using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorObject : MonoBehaviour
{
    public GameObject objectToActivate;

    private void Start()
    {

        StartCoroutine(ActivationRoutine());

    }

    private IEnumerator ActivationRoutine()
    {

        //Wait for 12 secs.
        yield return new WaitForSeconds(12);

        //Turn my game object that is set to false(off) to True(on)
        objectToActivate.SetActive(true);

        //Turn my game object back off after 1 sec.
        yield return new WaitForSeconds(1);

        //Game object will turn off
        objectToActivate.SetActive(false);



    }
}
