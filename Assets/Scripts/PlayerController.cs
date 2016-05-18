using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Rigidbody2D ), typeof( Animator ) )]
public class PlayerController : MonoBehaviour
{
    #region  Fields
    private Rigidbody2D m_Rigidbody;
    private Animator m_Animator;

    [SerializeField]
    private int m_RunSpeed;
    [SerializeField]
    private int m_JumpForce;

    [SerializeField]
    private bool m_IsGrounded;
    #endregion

    #region Unity API
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.transform.CompareTag("Ground") )
        {
            m_IsGrounded = true;
        }
    }


    #endregion

    #region Automatic player movement
    public void Run()
    {
        m_Rigidbody.velocity = new Vector2( m_RunSpeed, m_Rigidbody.velocity.y );
    }

    public void Stop()
    {
        m_Rigidbody.velocity = new Vector2( 0f, 0f );
    }
    #endregion

    #region Public Interface
    public void Jump()
    {
        if ( m_IsGrounded )
        {
            m_Rigidbody.AddForce( new Vector2( 0f, m_JumpForce ), ForceMode2D.Impulse );
            m_IsGrounded = false;
        }
    }

    public void Slide()
    {

    }
    #endregion
}
