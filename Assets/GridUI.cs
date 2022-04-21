using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUI : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.instance.updateGridAction += UpdateGrid;    
    }

    private void OnDisable()
    {
        GameManager.instance.updateGridAction -= UpdateGrid;
    }

    private void UpdateGrid()
    {
        
    }
}
