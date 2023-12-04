using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
//用于确定鼠标点击平面所在位置
{
    [SerializeField]
    //SerializeField?
    private Camera sceneCamera;
    //Camera 相机屏幕中的坐标是一个二维的，左下为（0,0）,向右上延伸
    //检测的鼠标在相机屏幕的位置
    private Vector3 lastposition;
    //记录鼠标点击平面的位置
    [SerializeField]
    private LayerMask placementLayermask;
    //被检测的平面

    public Vector3 GetSelectedMapPosition(){
        Vector3 mousePos=Input.mousePosition;
        //输入鼠标三维坐标给mousePos
        mousePos.z=sceneCamera.nearClipPlane;//Vector3.z中z要小写
        //将鼠标的z值赋给sceneCamera，防止我们选择到没有被camera渲染到的物体??？
        Ray ray=sceneCamera.ScreenPointToRay(mousePos);
        //ray一条由原点射向某个距离的射线
        //screenPointToRay相机到屏幕上一点的射线
        //得到鼠标与相机的相对位置
        RaycastHit hit;
        //hit就是得到的射线结果,一个数组
    //ray是一条射线，hit是代表这条射线的数组
        if(Physics.Raycast(ray,out hit,80,placementLayermask))
        //Raycast(Vector3 origin, Vector3 direction, float maxDistance, int layerMask)
        //origin 射线的原点在世界坐标中的位置
        //direction射线方向,out hit将数组传递出去
        //maxDistance 射线应该检测碰撞的最大距离（怎么确定数值???）
        //layerMask选中的图层
        //返回bool值，如果和选中的图层发生碰撞,返回true
        {
            lastposition=hit.point;
            //hit.point将射线击中平面的点赋给lastposition
        }
        return lastposition;
    }
}
