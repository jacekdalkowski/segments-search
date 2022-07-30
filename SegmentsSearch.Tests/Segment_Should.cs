using SegmentsSearch;

namespace SegmentsSearch.Tests;

public class Segment_Should
{
    [Xunit.Fact]
    public void DetectOverlappingSegment()
    {
        var leftSegment = new Segment(2, 4);
        var rightSegment = new Segment(3, 10);

        Xunit.Assert.True(leftSegment.IsOverlapping(rightSegment));
        Xunit.Assert.True(rightSegment.IsOverlapping(leftSegment));
    }

    [Xunit.Fact]
    public void DetectNotOverlappingSegment()
    {
        var leftSegment = new Segment(2, 4);
        var rightSegment = new Segment(6, 10);

        Xunit.Assert.False(leftSegment.IsOverlapping(rightSegment));
        Xunit.Assert.False(rightSegment.IsOverlapping(leftSegment));
    }
}