using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
		public bool hasMagneticArm = false;

        private PlatformerCharacter2D m_Character;
        private bool m_Jump;

		private bool trykker;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
			if (hasMagneticArm) {
				if (Input.GetKeyDown (KeyCode.X)) {
					trykker = true;
				}
				if (Input.GetKeyUp (KeyCode.X)) {
					trykker = false;
				}
				if (trykker) {
					foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position,1f)) {
						if (collider.tag == "Magnet") {
							Debug.Log ("Fant " + collider.gameObject.name);
							var rigbod = GetComponent<Rigidbody2D> ();
							rigbod.AddForce ((collider.transform.position - transform.position).normalized * 60f);
							break;
						}
					}
				}
			}
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }

    }
}
