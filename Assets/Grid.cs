using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid 
{
    private int[,] _grid;

    public Grid(int _width, int _height)
    {
        _grid = new int[_width, _height];
    }

    public void SetCell(int _x, int _y, int value)
    {
        _grid[_x, _y] = value;
    }

    public int GetValue(int _x, int _y)
    {
        return _grid[_x, _y];
    }

    public void WorldToGrid(Vector3 pos, out int x, out int y)
    {
        x = Mathf.FloorToInt(pos.x);
        y = Mathf.FloorToInt(pos.y);
    }

    public Vector2Int GetSize()
    {
        return new Vector2Int(_grid.GetLength(0), _grid.GetLength(1));
    }
}
