using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class BorderControl
{
    [SerializeField] private float _top;
    [SerializeField] private float _bottom;
    [SerializeField] private float _left;
    [SerializeField] private float _right;

    public float Top { get => _top; }
    public float Bottom { get => _bottom; }
    public float Left { get => _left; }
    public float Right { get => _right; }

    public void Set(float up, float down, float left, float right)
    {
        this._top = up;
        this._bottom = down;
        this._left = left;
        this._right = right;
    }

    public bool CheckBorder(ref Vector2 position)
    {
        if (position.x > Right)
        {
            position.x = Left;
            return true;
        }
        if (position.x < Left)
        {
            position.x = Right;
            return true;
        }
        if (position.y > Top)
        {
            position.y = Bottom;
            return true;
        }
        if (position.y < Bottom)
        {
            position.y = Top;
            return true;
        }

        return false;
    }
}