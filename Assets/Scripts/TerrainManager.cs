using UnityEngine;
using System.Collections.Generic;

public class TerrainManager : Singleton<TerrainManager>
{
    [SerializeField]
    private GameObject m_Terrain;
    [SerializeField]
    private Transform m_TargetLocation;

    [SerializeField]
    private List<LoopableTerrain> m_TerrainPool;

    [SerializeField]
    private int initialTearrainAmount = 5;

    private void Awake()
    {
        m_TerrainPool = new List<LoopableTerrain>();
    }

    private void Start()
    {
        PrepareInitialTerrain();
    }

    private void PrepareInitialTerrain()
    {
        for ( int i = 0; i < initialTearrainAmount; i++ )
        {
            GameObject terrain = Instantiate( m_Terrain );
            terrain.name = "terrain_platform";
            terrain.transform.parent = gameObject.transform;
            SpriteRenderer renderer = terrain.GetComponent<SpriteRenderer>();
            float initialXPosition = renderer.bounds.extents.x * 2;
            Vector3 newPosition = new Vector3( m_TargetLocation.position.x - initialXPosition * i, m_TargetLocation.position.y, m_TargetLocation.position.z );
            terrain.transform.position = newPosition;
            m_TerrainPool.Add( terrain.GetComponent<LoopableTerrain>() );
        }
    }

    private LoopableTerrain GetAvailableTerrain()
    {
        foreach ( LoopableTerrain terrain in m_TerrainPool )
        {
            if ( terrain.isUsable == true )
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
            terrain.transform.position = m_TargetLocation.position;
            terrain.isUsable = false;
        }
        else
        {
            GameObject newTerrain = Instantiate( m_Terrain, m_TargetLocation.position, m_TargetLocation.rotation ) as GameObject;
            newTerrain.transform.name = "terrain_platform";
            newTerrain.transform.parent = transform;
            LoopableTerrain LoopTerrain = newTerrain.GetComponent<LoopableTerrain>();
            m_TerrainPool.Add( LoopTerrain );
        }
    }
}
