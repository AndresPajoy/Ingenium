using UnityEngine;
using System.Collections;

public class TerrainChecker : MonoBehaviour
{
    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log( "Is exiting from checker" );
        if ( collision.transform.CompareTag("Ground") )
        {
            TerrainManager.Instance.SeedTerrain(); 
        }
    }
}
