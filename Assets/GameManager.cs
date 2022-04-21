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
    void Start()
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

        updateGridAction?.Invoke();
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

    // Update is called once per frame
    void Update()
    {

    }
}
