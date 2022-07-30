using System.Linq;

public class SimpleSegmentsCollection : ISegmentsCollection
{

    private ICollection<Segment> Segments { get; init; }

    public SimpleSegmentsCollection()
    {
        Segments = new List<Segment>();
    }

    public void Add(Segment segment)
    {
        Segments.Add(segment);
    }

    public IEnumerable<Segment> FindOverlapping(Segment query)
    {
        return Segments.Where(s => s.IsOverlapping(query));
    }

    public IEnumerable<Segment> FindOverlapping(IEnumerable<Segment> query)
    {
        return Segments.Where(s => query.Any(q => q.IsOverlapping(s)));
    }
}