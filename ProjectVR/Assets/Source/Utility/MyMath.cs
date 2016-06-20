using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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


	/// <summary>
	/// 指定した位置から一番近い座標のインデックスを計算
	/// </summary>
	/// <param name="pos"></param>
	/// <returns></returns>
	public static bool CalcNearPos( ref int index , Vector3 pos , List<Vector3> posList )
	{
		bool is_set = false;
		float dis = 1000000f;
		for( int i = 0 ; i < posList.Count ; i++ ) {
			float temp_dis = Vector3.Distance( posList[i] , pos );
			if( temp_dis < dis ) {
				dis = temp_dis;
				index = i;
				is_set = true;
			}
		}

		return is_set;
	}

	/// <summary>
	/// 指定した位置から一番近い座標のインデックスを計算
	/// </summary>
	/// <param name="pos"></param>
	/// <returns></returns>
	public static bool CalcNearPos( ref int index , Vector3 pos , List<GameObject> objList )
	{
		bool is_set = false;
		float dis = 1000000f;
		for( int i = 0 ; i < objList.Count ; i++ ) {
			float temp_dis = Vector3.Distance( objList[i].transform.position , pos );
			if( temp_dis < dis ) {
				dis = temp_dis;
				index = i;
				is_set = true;
			}
		}

		return is_set;
	}

}
