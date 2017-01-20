using UnityEngine;  
using System.Collections;  

/// <summary>  
/// 在日出和日落之间动画弧线  
/// 网上看到有人对Vector3.Slerp()的详解，但是经过962f之力将他的思路看明白。  
/// 受到启发，就有了自己对Vector3.Slerp()的理解。tt2()函数是自己的写的，tt3()是别人的。  
/// </summary>  

public class Vector3_Slerp_2 : MonoBehaviour  
{  
	public Transform sunrise;  
	public Transform sunset;  

	/// <summary>  
	/// 插值中心点的影响因素  
	/// </summary>  
	public float m_moveTowardsValue = 1f;  
	/// <summary>  
	/// 插值的个数  
	/// </summary>  
	public int m_lineNum = 10;  

	private Vector3 mStart = Vector3.zero;  
	private Vector3 mEnd = Vector3.zero;  

	void Update()  
	{  
		tt2();  
		//tt3();  
	}  

	/// <summary>  
	/// 官方用例  
	/// </summary>  
	private void tt1()  
	{  
		//弧线的中心  
		Vector3 center = (sunrise.position + sunset.position) * 0.5f;  

		//向下移动中心，垂直于弧线  
		center -= new Vector3(0, 1, 0);  

		//相对于中心在弧线上插值  
		Vector3 riseRelCenter = sunrise.position - center;  
		Vector3 setRelCenter = sunset.position - center;  

		transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, Time.time);  
		transform.position += center;  
	}  

	/// <summary>  
	///  球面插值  
	///  自己的理解  
	///  只在垂直平面上做球面插值。  
	/// </summary>  
	private void tt2()  
	{  
		mStart = sunrise.position;  
		mEnd = sunset.position;  

		/// 绘制世界坐标系  
		Debug.DrawLine(new Vector3(-100, 0, 0), new Vector3(100, 0, 0), Color.green);  
		Debug.DrawLine(new Vector3(0, -100, 0), new Vector3(0, 100, 0), Color.green);  
		Debug.DrawLine(new Vector3(0, 0, -100), new Vector3(0, 0, 100), Color.green);  

		/// 求出起始点与终点的中心点  
		Vector3 center = (mStart + mEnd) * 0.5f;  

		////////////////////////////////////  
		/// 1. center、mStart、mEnd 构成一个平面A  
		////////////////////////////////////  

		Debug.DrawLine(new Vector3(center.x, 0f, center.z), center, Color.white);  

		/// 绘制一个三角形  
		Debug.DrawLine(new Vector3(center.x, 0f, center.z), mStart, Color.white);  
		Debug.DrawLine(new Vector3(center.x, 0f, center.z), mEnd, Color.white);  
		Debug.DrawLine(mStart, mEnd, Color.white);  

		Vector3 normal = mEnd - mStart;  
		///只在垂直平面上做球面插值。  
		Vector3 tangent = new Vector3(center.x, 0f, center.z) - center;  

		/// 两个坐标轴的正交化。  
		Vector3.OrthoNormalize(ref normal, ref tangent);  //normalized 从0.0.0到目标的方向
		//magnitude (Read Only)
		//返回向量的长度，也就是点P(x,y,z)到原点(0,0,0)的距离。 最常用的是用来返回物体的移动速度
		//speed=rigidbody.velocity.magnitude;
		Vector3 center2 = center + tangent * m_moveTowardsValue;  
		////////////////////////////////////  
		/// 2. 两个坐标轴的正交化后 center2、mStart、mEnd 构成一个平面B，  
		/// 3. 平面B与平面A是同一平面。  
		////////////////////////////////////  
		Debug.DrawLine(center2, mStart, Color.blue);  
		Debug.DrawLine(center2, mEnd, Color.blue);  
		Debug.Log(string.Format("{0} : {1}", Vector3.Distance(center2, mStart), Vector3.Distance(center2, mEnd)));  

		for (int i = 1; i < m_lineNum; ++i)  
		{  
			Vector3 drawVec = Vector3.Slerp(mEnd - center2, mStart - center2, 1f / m_lineNum * i);  
			drawVec += center2; 
			Debug.DrawLine(center2, drawVec, Color.yellow);  
		}  

		/// 绘制起始点与终点的中心点到计算出的插值的中心点  
		Debug.DrawLine(center, center2, Color.black);  
	}  

	/// <summary>  
	/// 球面插值  
	/// http://www.manew.com/thread-43314-1-1.html 文章用例  
	/// </summary>  
	private void tt3()  
	{  
		mStart = sunrise.position;  
		mEnd = sunset.position;  

		Debug.DrawLine(new Vector3(-100, 0, 0), new Vector3(100, 0, 0), Color.green);  
		Debug.DrawLine(new Vector3(0, -100, 0), new Vector3(0, 100, 0), Color.green);  
		Debug.DrawLine(new Vector3(0, 0, -100), new Vector3(0, 0, 100), Color.green);  

		Debug.DrawLine(Vector3.zero, mStart, Color.white);  
		Debug.DrawLine(Vector3.zero, mEnd, Color.white);  
		Debug.DrawLine(mStart, mEnd, Color.white);  

		/// 求出起始点与终点的中心点  
		Vector3 centor = (mStart + mEnd) * 0.5f;  
		Debug.DrawLine(Vector3.zero, centor, Color.blue);  

		Vector3 centorProject = Vector3.Project(centor, mStart - mEnd); // 中心点在两点之间的投影  
		centor = Vector3.MoveTowards(centor, centorProject, m_moveTowardsValue);        // 沿着投影方向移动移动距离（距离越大弧度越小）  

		Debug.DrawLine(centor, mStart, Color.blue);  
		Debug.DrawLine(centor, mEnd, Color.blue);  

		Debug.Log(string.Format("{0} : {1}", Vector3.Distance(centor, mStart), Vector3.Distance(centor, mEnd)));  

		for (int i = 1; i < m_lineNum; ++i)  
		{  
			Vector3 drawVec = Vector3.Slerp(mEnd - centor, mStart - centor, 1f / m_lineNum * i);  
			drawVec += centor;  
			Debug.DrawLine(centor, drawVec, Color.yellow);  
			//Debug.DrawLine(centor, drawVec, 5 == i ? Color.blue : Color.yellow);  
		}  
	}  
}  