using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _bombCount;
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    private Grid _grid;

    public static GameManager instance;

    public Action updateGridAction;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        _grid = new Grid(_width, _height);
        SetupBombs();
    }

    private void SetupBombs()
    {
        int _bombs = 0;

        while (_bombs != _bombCount)
        {
            if (PlaceBomb())
                _bombs++;
        }

        for (int x = 0; x < _grid.GetSize().x; x++)
        {
            for (int y = 0; y < _grid.GetSize().y; y++)
            {
                CheckBombs(x, y);
            }
        }

        updateGridAction?.Invoke();
    }

    private void CheckBombs(int x, int y)
    {
        if (_grid.GetValue(x, y) != -1)
        {
            int value = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (x + i > 0 && x + i < _grid.GetSize().x && y + j > 0 && y + j < _grid.GetSize().y)
                        if (_grid.GetValue(x + i, y + j) == -1)
                            value++;
                }
            }
            _grid.SetCell(x, y, value);
        }
    }

    private bool PlaceBomb()
    {
        int _x = Random.Range(0, _width);
        int _y = Random.Range(0, _height);

        if (_grid.GetValue(_x, _y) == 0)
        {
            _grid.SetCell(_x, _y, -1);
            return true;
        }
        else
        {
            return false;
        }
    }

    public Grid GetGrid()
    {
        return _grid;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
