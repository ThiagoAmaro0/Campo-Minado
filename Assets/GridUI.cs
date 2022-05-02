using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridUI : MonoBehaviour
{
    private GameObject[,] _gridSlots;
    [SerializeField] private GameObject _gridSlotPrefab;

    private void Start()
    {
        GameManager.instance.updateGridAction?.Invoke();
    }

    private void OnEnable()
    {
        GameManager.instance.updateGridAction += UpdateGrid;    
    }

    private void OnDisable()
    {
        GameManager.instance.updateGridAction -= UpdateGrid;
    }

    public void BuildGridUI()
    {
        Grid _grid = GameManager.instance.GetGrid();
        Vector2Int size = _grid.GetSize();

        _gridSlots = new GameObject[size.x, size.y];

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                _gridSlots[x, y] = Instantiate(_gridSlotPrefab, new Vector3(x, y, 0), Quaternion.identity, transform);
            }
        }

        UpdateGrid();
    }

    private void UpdateGrid()
    {
        if(_gridSlots == null)
        {
            BuildGridUI();
            return;
        }
        Grid _grid = GameManager.instance.GetGrid();
        Vector2Int size = _grid.GetSize();

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {

                _gridSlots[x, y].GetComponentInChildren<TextMeshProUGUI>().text = _grid.GetValue(x, y) == 0 ? "" : _grid.GetValue(x, y) + "";
            }
        }
    }

    public void RevealSlot()
    {
        Vector3 mousePos = Camera.current.ScreenToWorldPoint(Input.mousePosition);
        GameManager.instance.GetGrid().WorldToGrid(mousePos, out int x, out int y);
    }
}
