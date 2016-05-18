using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class LoopableTerrain : MonoBehaviour
{
    public bool isUsable;

    private void Start()
    {
        isUsable = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( collision.CompareTag( "FinishBound" ) )
        {
            isUsable = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag( "StartBound" ) )
        {
            isUsable = false;
        }
    }
}
