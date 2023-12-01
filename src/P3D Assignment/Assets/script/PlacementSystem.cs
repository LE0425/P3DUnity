using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField]
    GameObject mouseIndicator;
    [SerializeField]
    private InputManager inputManager;
    //InputManager输入管理器

    private void Update(){
        Vector3 mousePosition=inputManager.GetSelectedMapPosition();
        //
        mouseIndicator.transform.position=mousePosition;
        //
    }
}
