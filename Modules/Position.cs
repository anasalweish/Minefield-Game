public class Position
{
    public int Row { get; set; }
    public int Col { get; set; }

    public Position(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public override bool Equals(object obj)
    {
        return obj is Position position &&
               Row == position.Row &&
               Col == position.Col;
    }
}

