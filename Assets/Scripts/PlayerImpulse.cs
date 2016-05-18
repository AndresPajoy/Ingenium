using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
public class PlayerImpulse : MonoBehaviour
{
    private PlayerController m_Controller;

    private void Awake()
    {
        m_Controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        m_Controller.Run();
    }
}
