using System;

class FoodAndRocks
{
    // fields
    private int x;
    private int y;
    private string s;
    public ConsoleColor color;

    // properties
    public int X
    {
        get
        {
            return x;
        }
        set
        {
            x = value;
        }
    }
    public int Y
    {
        get
        {
            return y;
        }
        set
        {
            y = value;
        }
    }
    public string S
    {
        get
        {
            return s;
        }
        set
        {
            s = value;
        }
    }

    public ConsoleColor Color
    {
        get
        {
            return color;
        }
        set
        {
            color = value;
        }
    }

    // constructor
    public FoodAndRocks(int x, int y, string s, ConsoleColor color)
    {
        this.X = x;
        this.Y = y;
        this.S = s;
        this.Color = color;
    }
}



