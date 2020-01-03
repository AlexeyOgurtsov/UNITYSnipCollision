using UnityEngine;

using System.Reflection;
using System.Linq;

public enum EMyMoveMethod
{
	Transform,
	RigidbodyMove,
	RigidbodyVelocity
}

// Base class of all game objects,
// controllable by my player controller.
public class MyPawn : MonoBehaviour
{
	#region constants
	public const float DEFAULT_MOVE_SPEED = 3.0F;
	public const float DEFAULT_ROTATION_SPEED_DEGS = 45.0F;
	#endregion // constants

	#region movement
	public bool bUseRigidbodyMove = true;
	public EMyMoveMethod myMoveMethod = EMyMoveMethod.RigidbodyMove;
	void MyMoveAndRotate(Vector2 vel, float angularVelocityDegs)
	{
		Vector2 deltaPosition = vel * Time.deltaTime;
		float deltaRotationDegs = rotationSpeedDegs * Time.deltaTime;
		switch(myMoveMethod)
		{
		case EMyMoveMethod.Transform:
			transform.Rotate(0, 0, deltaRotationDegs);
			transform.Translate(deltaPosition);
			return;

		case EMyMoveMethod.RigidbodyMove:
			if(myRigidbody)
			{
				myRigidbody.MovePosition(myRigidbody.position + deltaPosition);
				myRigidbody.MoveRotation(myRigidbody.rotation + deltaRotationDegs);
			}
			return;

		case EMyMoveMethod.RigidbodyVelocity:
			if(myRigidbody)
			{
				myRigidbody.velocity = vel;
				myRigidbody.angularVelocity = angularVelocityDegs;
			}
			return;

		default:
			break;
		}
	}
	#endregion

	#region collision
	public void OnCollisionEnter2D(Collision2D collision)
	{
		MyCollisionUtils.LogCollision2D(MethodBase.GetCurrentMethod().Name, collision);
	}
	public void OnCollisionExit2D(Collision2D collision)
	{
		MyCollisionUtils.LogCollision2D(MethodBase.GetCurrentMethod().Name, collision);
	}
	public void OnCollisionStay2D(Collision2D collision)
	{
		MyCollisionUtils.LogCollision2D(MethodBase.GetCurrentMethod().Name, collision);
	}
	public void OnTriggerEnter2D(Collider2D collider)
	{
		MyCollisionUtils.LogCollider2D(MethodBase.GetCurrentMethod().Name, collider);
	}
	public void OnTriggerExit2D(Collider2D collider)
	{
		MyCollisionUtils.LogCollider2D(MethodBase.GetCurrentMethod().Name, collider);
	}
	public void OnTriggerStay2D(Collider2D collider)
	{
		MyCollisionUtils.LogCollider2D(MethodBase.GetCurrentMethod().Name, collider);
	}
	Rigidbody2D myRigidbody;
	#endregion // collision

	#region move methods
	public void SetMoveDirection(Vector2 direction)
	{
		this.moveDirection = direction;
	}

	public void SetRotationSpeedDegs(float rotationSpeedDegs)
	{
		this.rotationSpeedDegs = rotationSpeedDegs;
	}
	#endregion move methods

	#region unity messages
	public void FixedUpdate()
	{
		Vector2 vel = this.moveDirection * DEFAULT_MOVE_SPEED;
		MyMoveAndRotate(vel, rotationSpeedDegs);
	}

	public void Awake()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
	}
	#endregion // unity messages

	Vector2 moveDirection;
	float rotationSpeedDegs;
}
