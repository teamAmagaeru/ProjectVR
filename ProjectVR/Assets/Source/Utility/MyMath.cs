using UnityEngine;
using System.Collections;

public static class MyMath
{
	public static bool CollisionBoxToPoint( Vector3 boxPos , Vector3 boxScale , Vector3 pointPos )
	{
		boxScale = boxScale / 2;
		bool chkX = ((boxPos.x + boxScale.x) >= pointPos.x) || ((boxPos.x - boxScale.x) <= pointPos.x);
		bool chkY = ((boxPos.y + boxScale.y) >= pointPos.y) || ((boxPos.y - boxScale.y) <= pointPos.y);
		bool chkZ = ((boxPos.z + boxScale.z) >= pointPos.z) || ((boxPos.z - boxScale.z) <= pointPos.z);

		if( chkX && chkY && chkZ ) {
			return true;
		}
		return false;
	}

	public static bool CollisionBoxToPoint( Vector3 boxPos , float rad , Vector3 pointPos )
	{
		bool chkX = ((boxPos.x + rad) >= pointPos.x) && ((boxPos.x - rad) <= pointPos.x);
		bool chkY = ((boxPos.y + rad) >= pointPos.y) && ((boxPos.y - rad) <= pointPos.y);
		bool chkZ = ((boxPos.z + rad) >= pointPos.z) && ((boxPos.z - rad) <= pointPos.z);

		if( chkX && chkY && chkZ ) {
			return true;
		}
		return false;
	}
}
