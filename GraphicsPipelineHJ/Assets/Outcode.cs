
using UnityEngine;

public class Outcode
{
    public bool up;
    public bool down;
    public bool left;
    public bool right;

    public Outcode(Vector2 point)
    {
        up = (point.y > 1);
        down = (point.y < -1);
        left = (point.x < -1);
        right = (point.x > 1);
    }

    public Outcode()
    {
        up = false;
        down = false;
        left = false;
        right = false;
    }

    public Outcode(bool input_Up, bool input_Dowm, bool input_Left, bool input_Right)
    {
        up = input_Up;
        down = input_Dowm;
        left = input_Left;
        right = input_Right;
    }

    public void Print()
    {
        string outcodeString = (up ? "1" : "0") + (down ? "1" : "0") + (left ? "1" : "0") + (right ? "1" : "0"); 
    }

    public static Outcode operator + (Outcode outcodeA, Outcode outcodeB)
    {
        return new Outcode(outcodeA.up || outcodeB.up, outcodeA.down || outcodeB.down, outcodeA.left || outcodeB.left, outcodeA.right || outcodeB.right);
    }

    public static Outcode operator * (Outcode outcodeA, Outcode outcodeB)
    {
        return new Outcode(outcodeA.up && outcodeB.up, outcodeA.down && outcodeB.down, outcodeA.left && outcodeB.left, outcodeA.right && outcodeB.right);
    }

    public static bool operator ==(Outcode outcodeA, Outcode outcodeB)
    {
        return ((outcodeA.up == outcodeB.up) && (outcodeA.down == outcodeB.down) && (outcodeA.left == outcodeB.left) && (outcodeA.right == outcodeB.right));
    }

    public static bool operator !=(Outcode outcodeA, Outcode outcodeB)
    {
        return !(outcodeA == outcodeB);
    }

}
