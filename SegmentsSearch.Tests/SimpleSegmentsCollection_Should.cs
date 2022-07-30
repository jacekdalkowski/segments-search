using SegmentsSearch;
using System.Linq;
using System.Diagnostics;

namespace SegmentsSearch.Tests;

public class SimpleSegmentsCollection_Should
{
    [Xunit.Fact]
    public void DetectSegmentsOverlappingWithQuerySegment()
    {
        var simpleSegmentsCollection = new SimpleSegmentsCollection();
        simpleSegmentsCollection.Add(new Segment(1, 10));
        simpleSegmentsCollection.Add(new Segment(20, 30));
        simpleSegmentsCollection.Add(new Segment(40, 50));
        simpleSegmentsCollection.Add(new Segment(60, 70));

        var queryResult = simpleSegmentsCollection.FindOverlapping(new Segment(25, 45));

        Xunit.Assert.Equal(2, queryResult.Count());
        Xunit.Assert.True(queryResult.Contains(new Segment(20, 30)));
        Xunit.Assert.True(queryResult.Contains(new Segment(40, 50)));
    }

    [Xunit.Fact]
    public void DetectSegmentsOverlappingWithQuerySegmentUnderLoad()
    {
        var simpleSegmentsCollection = new SimpleSegmentsCollection();
        Enumerable.Range(1, 1_000_000_000).ToList().ForEach(i => simpleSegmentsCollection.Add(new Segment(i, i + 1)));

        Stopwatch sw = new Stopwatch();
        sw.Start();
        var queryResult = simpleSegmentsCollection.FindOverlapping(new Segment(100, 101));
        sw.Stop();
        System.Console.WriteLine("Elapsed={0}", sw.Elapsed.TotalMilliseconds);

        Xunit.Assert.Equal(3, queryResult.Count());
        Xunit.Assert.True(queryResult.Contains(new Segment(99, 100)));
        Xunit.Assert.True(queryResult.Contains(new Segment(100, 101)));
        Xunit.Assert.True(queryResult.Contains(new Segment(101, 102)));
    }
}