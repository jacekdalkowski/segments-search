
public record class Segment(int A, int B)
{
    public bool IsOverlapping(Segment another)
    {
        return this.A <= another.B && another.A <= this.B;
    }
}
