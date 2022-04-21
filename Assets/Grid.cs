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
}
