using UnityEngine;

using System.Reflection;
using System.Linq;

// Base class of all game objects,
// controllable by my player controller.
public class MyPawn : MonoBehaviour
{
	#region constants
	public const float DEFAULT_MOVE_SPEED = 3.0F;
	public const float DEFAULT_ROTATION_SPEED_DEGS = 45.0F;
	#endregion // constants

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
		transform.Rotate(0, 0, rotationSpeedDegs * Time.deltaTime);
		transform.Translate(this.moveDirection * Time.deltaTime * DEFAULT_MOVE_SPEED);
	}
	#endregion // unity messages

	Vector2 moveDirection;
	float rotationSpeedDegs;
}
