using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinePractice : MonoBehaviour
{
    private void Start()
    {
        var queue = new CoroutineQueue(6, StartCoroutine);
        for (var i = 0; i < 6; i++)
        {
            queue.Run(TestCoroutine(i, 2));
        }



    }


    IEnumerator TestCoroutine(int id, uint numYields)
    {
        Debug.Log("frame" + Time.frameCount + " : Start " + id);
        for (var i = 0; i < numYields; ++i)
        {
            Debug.Log("frame " + Time.frameCount + " : yield! " + id);
            yield return null;
        }
        Debug.Log("frame " + Time.frameCount + " : end " + id);
    }
}
