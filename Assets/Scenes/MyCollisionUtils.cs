using UnityEngine;
using System.Reflection;

public static class MyCollisionUtils
{
	public static void LogCollider2D(string sender, Collider2D collider)
	{
		Debug.Log($"--- Logging collider 2D: sender={sender}");
		if(collider == null)
		{
			Debug.LogWarning("collision is nullptr");
		}
		else
		{
			Debug.Log($"attachedRigidbody={collider.attachedRigidbody}");
			Debug.Log($"isTrigger={collider.isTrigger}");
			Debug.Log($"offset={collider.offset}");
			// @TODO
		}
	}

	public static void LogCollision2D(string sender, Collision2D collision)
	{
		Debug.Log($"--- Logging collision 2D: sender={sender}");
		if(collision == null)
		{
			Debug.LogWarning("collision is nullptr");
		}
		else
		{
			Debug.Log($"relativeVelocity: {collision.relativeVelocity}");
			Debug.Log($"gameObject: {collision.gameObject}");
			Debug.Log($"enabled: {collision.enabled}");
			Debug.Log($"transform: {collision.transform}");
			Debug.Log($"- rigidbody: {collision.rigidbody}");
			Debug.Log($"collider: {collision.collider}");
			Debug.Log($"- otherRigidbody={collision.otherRigidbody}");
			Debug.Log($"otherCollider: {collision.otherCollider}");
			Debug.Log($"- contactCount: {collision.contactCount}");
			var contacts = new ContactPoint2D[collision.contactCount];
			foreach(ContactPoint2D cp in contacts)
			{
				Debug.Log($"cp: point={cp.point}; normal={cp.normal}; normalImpulse={cp.normalImpulse}; separation={cp.separation}; tangentImpulse={cp.tangentImpulse}");
			}
		}
	}
}
