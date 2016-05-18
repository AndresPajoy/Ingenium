using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{   
    private GameObject m_Player;

    private Vector3 lastPlayerPosition;

    [SerializeField]
    private int distanceFromPlayer;

    private void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag( "Player" ) as GameObject;
        lastPlayerPosition = m_Player.transform.position;
        MoveAwayFromPlayer();
    }

    private void Update()
    {
        Vector3 deltaPosition = m_Player.transform.position - lastPlayerPosition;
        transform.Translate( deltaPosition.x, 0, 0 );
        lastPlayerPosition = m_Player.transform.position;
    }

    private void MoveAwayFromPlayer()
    {
        Vector3 newPosition = new Vector3( distanceFromPlayer + m_Player.transform.position.x, transform.position.y, transform.position.z );
        transform.transform.position = newPosition;
    }
}
