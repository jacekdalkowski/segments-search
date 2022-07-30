
public interface ISegmentsCollection
{
    public void Add(Segment segment);

    public IEnumerable<Segment> FindOverlapping(Segment query);

    public IEnumerable<Segment> FindOverlapping(IEnumerable<Segment> query);
}