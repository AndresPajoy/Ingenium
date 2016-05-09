using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
    private PlayerController m_Controller;

    private void Awake()
    {
        m_Controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        bool jump;
        bool slide;
#if UNITY_EDITOR
        jump = Input.GetButtonDown( "Jump" );
        slide = Input.GetButtonDown( "Slide" );

#elif ANDROID || IPHONE
        if (Input.touchCount > 0)
	    {
            Touch touch = Input.touches[0];
            if ( touch.phase == TouchPhase.Moved )
            {
                if ( touch.azimuthAngle > Mathf.PI/4 && touch.azimuthAngle < Mathf.PI )
                {
                    jump = true;
                }
                else if ( touch.azimuthAngle > Mathf.PI * 5 / 4 && touch.azimuthAngle < Mathf.PI * 7 / 4 )
                {
                    slide = true;
                }
            }
	    }
#endif
        if ( jump )
        {
            m_Controller.Jump();
            jump = false;
        }
        if ( slide )
        {
            m_Controller.Slide();
            slide = false;
        }
    }
}
