using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
//Input manager实现放置物体位置随鼠标移动
{
    [SerializeField]
    GameObject mouseIndicator, cellIndicator;
    //1、mouseIndicator用于放置的物体
    //2、cellIndicator用于放置网格
    [SerializeField]
    private InputManager inputManager;
    //InputManager输入管理器
    [SerializeField]
    private Grid grid;
    //2、网格对象

    private void Update(){
        Vector3 mousePosition=inputManager.GetSelectedMapPosition();
        //1、鼠标位置由InputManager脚本获取
        Vector3Int gridPosition=grid.WorldToCell(mousePosition);
        //WorldToCell将世界位置转为网格位置
        //2、获取鼠标所在网格位置
        mouseIndicator.transform.position=mousePosition;
        //1、用鼠标位置控制放置物体的位置变化
        cellIndicator.transform.position=grid.CellToWorld(gridPosition);
        //2、将网格位置转为世界位置以存储
    }
}
