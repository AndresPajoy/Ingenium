using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    #region  Fields
    private Rigidbody2D m_Rigidbody;
    private Animator m_Animator;

    [SerializeField]
    private int m_RunSpeed;
    [SerializeField]
    private int m_JumpForce;
    #endregion

    #region Unity API
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }
    #endregion

    #region Automatic player movement
    private void Run()
    {
        m_Rigidbody.velocity = new Vector2( m_RunSpeed, 0f );
    }

    private void Stop()
    {
        m_Rigidbody.velocity = new Vector2( 0f, 0f );
    }
    #endregion

    #region Public Interface
    public void Jump()
    {
        m_Rigidbody.AddForce( new Vector2( 0f, m_JumpForce ), ForceMode2D.Impulse );
    }

    public void Slide()
    {

    }
    #endregion
}
