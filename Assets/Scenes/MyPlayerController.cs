using UnityEngine;
using UnityEngine.InputSystem;

using System.Reflection;
using System.Collections.Generic;
using System.Linq;

public class MyPlayerController : MonoBehaviour
{
	#region Unity events
	// Q. Can unit messages be private?
	void FixedUpdate()
	{
		if(pawn)
		{
			PawnMoveUpdate();
		}
	}

	public void Awake()
	{
		_InitializePawns();
	}
	#endregion


	#region input actions
	public void InputAction_Thrust(InputAction.CallbackContext context)
	{
		input.axisThrust = context.ReadValue<float>();
	}
	public void InputAction_Strafe(InputAction.CallbackContext context)
	{
		input.axisStrafe = context.ReadValue<float>();
	}
	public void InputAction_Rotate(InputAction.CallbackContext context)
	{
		input.axisRotate = context.ReadValue<float>();
	}

	public void InputAction_FlipPawn(InputAction.CallbackContext context)
	{
		float axis = context.ReadValue<float>();

		if( ! Mathf.Approximately(axis, 0) )
		{
			if(pawnList.Length != 0)
			{
				int pawnIndex = System.Array.IndexOf(pawnList, pawn);
				Debug.Assert( pawnIndex != (pawnList.GetLowerBound(0) - 1) );
				pawnIndex = (axis > 0) ? (pawnIndex + 1) : (pawnIndex - 1);
				pawnIndex = Mathf.Clamp(pawnIndex, 0, pawnList.Length - 1);
				pawn = pawnList[pawnIndex];
			}
		}
	}
	#endregion // input actions

	#region input
	struct InputState
	{
		public Vector2 moveDirection
		{
			get => new Vector2( axisStrafe, axisThrust ).normalized;
		}

		public float axisThrust;
		public float axisStrafe;
		public float axisRotate;
	};
	InputState input;

	void PawnMoveUpdate()
	{
		Debug.Assert(pawn);
		pawn.SetMoveDirection(input.moveDirection);
		pawn.SetRotationSpeedDegs(MyPawn.DEFAULT_ROTATION_SPEED_DEGS * input.axisRotate);
	}
	#endregion // input

	#region pawn
	MyPawn pawn;
	#endregion // pawn

	#region pawn list
	MyPawn[] pawnList;

	void _InitializePawns()
	{
		const string PLAYER_TAG = "Player";
		pawnList = FindObjectsOfType<MyPawn>().Where( o => o.CompareTag(PLAYER_TAG) ).ToArray();	
		pawn = pawnList.FirstOrDefault();
		Debug.Log($"Posessing pawn named \"{pawn?.name}\" of class \"{pawn?.GetType()}\" \n( Found {pawnList.Length} pawns tagged {PLAYER_TAG}; )");
	}
	#endregion pawn list
}


