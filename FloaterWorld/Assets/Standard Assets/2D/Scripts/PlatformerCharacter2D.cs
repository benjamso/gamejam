using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
		[SerializeField] private float m_MaxAirSpeed = 6f;
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
		[SerializeField] private float m_SlideForce = 4000f;                // Amount of force added when the player slides.
		[SerializeField] private float m_KnockBackForce = 3000f;            // Amount of force added when player takes damage.
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.
		private Renderer spriteRenderer;
		private List<AudioClip> m_jumpAudioClips = new List<AudioClip>();
		private List<AudioClip> m_dmgAudioClips = new List<AudioClip>();
		private AudioSource m_actionSound;


        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
			spriteRenderer = GetComponent<Renderer> ();
			loadAudioClips ();
			m_actionSound = GetComponent<AudioSource> ();
        }

		private void loadAudioClips(){
			// Load jump clips
			m_jumpAudioClips.Add (Resources.Load ("Sound/jump1", typeof(AudioClip)) as AudioClip);
			m_jumpAudioClips.Add (Resources.Load ("Sound/jump2", typeof(AudioClip)) as AudioClip);
			m_jumpAudioClips.Add (Resources.Load ("Sound/jump3", typeof(AudioClip)) as AudioClip);
			m_jumpAudioClips.Add (Resources.Load ("Sound/jump4", typeof(AudioClip)) as AudioClip);

			// Load dmg clips
			m_dmgAudioClips.Add (Resources.Load ("Sound/dmg1", typeof(AudioClip)) as AudioClip);
			m_dmgAudioClips.Add (Resources.Load ("Sound/dmg2", typeof(AudioClip)) as AudioClip);
			m_dmgAudioClips.Add (Resources.Load ("Sound/dmg3", typeof(AudioClip)) as AudioClip);
			m_dmgAudioClips.Add (Resources.Load ("Sound/dmg4", typeof(AudioClip)) as AudioClip);
		}


        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
        }


        public void Move(float move, bool crouch, bool jump)
        {
            // If crouching, check to see if the character can stand up
            if (!crouch && m_Anim.GetBool("Crouch"))
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                {
                    crouch = true;
                }
            }

            // Set whether or not the character is crouching in the animator
            m_Anim.SetBool("Crouch", crouch);

            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move*m_CrouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
				if(m_Grounded){
                	m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);
				}else{
					m_Rigidbody2D.velocity = new Vector2(move*m_MaxAirSpeed, m_Rigidbody2D.velocity.y);
				}
                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            // If the player should jump...
            if (m_Grounded && jump && !crouch && m_Anim.GetBool("Ground"))
            {
				// Play jumping sound
				m_actionSound.clip = m_jumpAudioClips[UnityEngine.Random.Range(0, m_jumpAudioClips.Count)];
				m_actionSound.Play();


                // Add a vertical force to the player.
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }

			if (m_Grounded && crouch && m_Anim.GetBool ("Crouch")) {
				// Add a vertical force to the player.
				m_Grounded = true;
				m_Anim.SetBool ("crouch", true);
				if (jump) {
					if(m_FacingRight)
						m_Rigidbody2D.AddForce (new Vector2 (m_SlideForce, 0f));
					if(!m_FacingRight)
						m_Rigidbody2D.AddForce (new Vector2 ((-(m_SlideForce)),0f));
				}
			}
        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

		void OnCollisionEnter2D(Collision2D collision) 
		{
			if(collision.gameObject.name == "Mob1")  // or if(gameObject.CompareTag("YourWallTag"))
			{
				playRandomDmgSound();	
				if(m_FacingRight){
					m_Rigidbody2D.AddForce(new Vector2(-(m_KnockBackForce), 1));
				}
				else{
					m_Rigidbody2D.AddForce(new Vector2(m_KnockBackForce, 1));
				}

				
				StartCoroutine( Wait (0.1f));
				
			}
		}
		
		IEnumerator Wait(float seconds)
		{
			Debug.Log ("Wait");
			spriteRenderer.enabled = false;
			yield return new WaitForSeconds(seconds); 
			spriteRenderer.enabled = true;
		}

		// Play random damage sound
		void playRandomDmgSound(){
			// Play jumping sound
			m_actionSound.clip = m_dmgAudioClips[UnityEngine.Random.Range(0, m_jumpAudioClips.Count)];
			m_actionSound.Play();
		}
    }
}
