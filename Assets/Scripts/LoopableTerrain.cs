using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class LoopableTerrain : MonoBehaviour
{
    public bool isActive;

    private void Awake()
    {
        isActive = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( collision.CompareTag( "StartBound" ) )
        {
            TerrainManager.Instance.SeedTerrain();
        }
        if ( collision.CompareTag( "FinishBound" ) )
        {
            isActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag( "StartBound" ) )
        {
            isActive = true;
        }
        if ( collision.CompareTag( "FinishBound" ) )
        {
            TerrainManager.Instance.PreapareForRelocation( this.gameObject );
        }
    }
}
