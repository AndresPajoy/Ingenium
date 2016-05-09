using UnityEngine;
using System.Collections.Generic;

public class TerrainManager : Singleton<TerrainManager>
{
    [SerializeField]
    private GameObject m_Terrain;
    [SerializeField]
    private Transform m_TargeLocation;

    [SerializeField]
    private List<LoopableTerrain> m_TerrainPool;

    private void Awake()
    {
        m_TerrainPool = new List<LoopableTerrain>();
    }

    private LoopableTerrain GetAvailableTerrain()
    {
        foreach ( LoopableTerrain terrain in m_TerrainPool )
        {
            if ( terrain.isActive == false )
            {
                return terrain;
            }
        }

        return null;
    }

    public void SeedTerrain()
    {
        LoopableTerrain terrain = GetAvailableTerrain();
        if ( terrain != null )
        {
            if ( terrain.gameObject.activeInHierarchy == false ) terrain.gameObject.SetActive( true );

            terrain.transform.position = m_TargeLocation.position;
        }
        else
        {
            GameObject newTerrain = GameObject.Instantiate( m_Terrain, m_TargeLocation.position, m_TargeLocation.rotation ) as GameObject;
            newTerrain.transform.name = "terrain_platform";
        }
    }

    public void PreapareForRelocation(GameObject objToRelocate)
    {
        LoopableTerrain terrain = GetAvailableTerrain();
        if ( !m_TerrainPool.Contains( terrain ) )
        {
            m_TerrainPool.Add( objToRelocate.GetComponent<LoopableTerrain>() );
        }
        else
        {
            objToRelocate.SetActive( false );
        }
    }
}
