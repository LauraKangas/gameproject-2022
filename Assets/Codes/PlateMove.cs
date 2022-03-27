using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;




namespace FusilliProject
{
    [RequireComponent(typeof(InputProcessor))]
    public class PlateMove : MonoBehaviour
    {
        
#region Statics
		// Staattista fieldiä ei tuhota scenen unloadin myötä (koska se ei ole olion omaisuutta, vaan luokan)
		
		#endregion

		public enum ControlState
		{
			GamePad,
			Touch
		}

		#region Fields
		[SerializeField]
		private float velocity = 1;

		// Oletusarvoa käytetään, jos Unity ei ylikirjoita sitä (arvoa ei ole tallennettu esim. sceneen).
		[SerializeField]
		

		private Animator animator;

		private new SpriteRenderer renderer;

		private new Rigidbody2D rigidbody;

		private Vector2 moveInput;

		private Vector2 touchPosition;

		private Vector2 targetPosition;

		private ControlState controlState = ControlState.GamePad;
		
		#endregion

		private void Awake()
		{
			animator = GetComponent<Animator>();
			if (animator == null)
			{
				Debug.LogError("Character is missing an animator component!");
				Debug.Break();
			}

			renderer = GetComponent<SpriteRenderer>();
			if (renderer == null)
			{
				Debug.LogError("Character is missing an renderer component!");
				Debug.Break();
			}

			rigidbody = GetComponent<Rigidbody2D>();
			if (rigidbody == null)
			{
				Debug.LogError("Character is missing an Rigidbody2D component!");
				Debug.Break();
			}

			
		}

		private void Start()
		{
			
		}

		private void Update()
		{
			
		}

		private void FixedUpdate()
		{
			MoveCharacter();
		}

		

		

		private void MoveCharacter()
		{
			controlState= ControlState.Touch;
					// Koska Vector2:sta ei voi vähentää Vector3:a, pitää suorittaa tyyppimuunnos
					Vector2 travel = targetPosition - (Vector2)transform.position;

					// Normalisointi muuntaa vektorin pituuden yhdeksi
					Vector2 frameMovement = travel.normalized * 5 * Time.fixedDeltaTime;

					// magnitude palauttaa vektorin pituuden. Tässä vektorin pituus kuvaa
					// jäljellä olevaa matkaa
					float distance = travel.magnitude;

					if (frameMovement.magnitude < distance)
					{
						// Matkaa on vielä jäljellä, kuljetaan kohti kohdepistettä
						// transform.Translate(frameMovement);
						rigidbody.MovePosition(rigidbody.position + frameMovement);
					}
					else
					{
						// Päämäärä saavutettu
						rigidbody.MovePosition(targetPosition);
						// transform.position = targetPosition;
						moveInput = Vector2.zero;
					}

					
			
		}

		private void OnMove(InputAction.CallbackContext callbackContext)
		{
			controlState = ControlState.GamePad;
			moveInput = callbackContext.ReadValue<Vector2>();
		}

		private void OnTap(InputAction.CallbackContext context)
		{
			Debug.Log("Tap!");
			Debug.Log(context.phase);
		}

		private void OnTouchPosition(InputAction.CallbackContext context)
		{
			controlState = ControlState.Touch;

			this.touchPosition = context.ReadValue<Vector2>();

			// Muunnetaan 2D koordinaatti 3D-koordinaatistoon
			Vector3 screenCoordinate = new Vector3(touchPosition.x, touchPosition.y, 0);

			// Muunnetaan näytön koordinaatti pelimaailman koordinaatistoon
			Vector3 worldCoordinate = Camera.main.ScreenToWorldPoint(screenCoordinate);

			// Muunnetaan maailman koordinaatti 2D-koordinaatistoon. HUOM! implisiittinen
			// tyyppimuunnos Vector3 -> Vector2
			targetPosition = worldCoordinate;

			// Päivitetään myös moveInput-vektoria, koska animaattorin parametrit asetetaan sen
			// perusteella
			moveInput = (targetPosition - (Vector2)transform.position).normalized;
		}
	}
}