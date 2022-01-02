namespace Fifteen;

internal class DijkstraPathFinder
{
    private readonly CaveMap map;
    private readonly Dictionary<Coordinate, int> visitedNodes = new();
    private readonly Dictionary<Coordinate, int> unvisitedNeighbours = new();

    public DijkstraPathFinder(CaveMap map) => this.map = map;

    public int FindShortestPathLength()
    {
        foreach (var node in EnumerateNodesToVisit())
            VisitNode(node);

        if (visitedNodes.TryGetValue(map.End, out var shortestPathLength))
            return shortestPathLength;

        throw new InvalidOperationException("Haven't reached the end yet");
    }

    private void VisitNode(Coordinate node)
    {
        visitedNodes[node] = GetDistanceTo(node);
        UpdateUnvisitedNeighbours(node);
    }

    private void UpdateUnvisitedNeighbours(Coordinate visitedNodoe)
    {
        unvisitedNeighbours.Remove(visitedNodoe);
        foreach (var neighbour in GetUnvisitedNeighbours(visitedNodoe))
        {
            var distance = GetDistanceTo(neighbour);
            unvisitedNeighbours[neighbour] = distance;
        }
    }

    private IEnumerable<Coordinate> GetUnvisitedNeighbours(Coordinate visitedNode)
        => map.GetAdjacentCoordinates(visitedNode).Where(c => !visitedNodes.ContainsKey(c));

    private IEnumerable<Coordinate> EnumerateNodesToVisit()
    {
        int visitCount = 0;
        for (var node = map.Start; ; node = GetNextNodeToVisit())
        {
            if (++visitCount % 100 == 0)
                Console.WriteLine($"Visiting node {node}, count = {visitCount}");

            yield return node;
            if (node == map.End)
                yield break;
        }
    }

    private Coordinate GetNextNodeToVisit() => unvisitedNeighbours.OrderBy(kvp => kvp.Value).First().Key;

    private int GetDistanceTo(Coordinate node)
    {
        //The starting position is never entered, so its risk is not counted
        if (node == map.Start)
            return 0;

        var visitedNeighbourDistances = GetVisitedNeighbourDistances(node);
        if (!visitedNeighbourDistances.Any())
            throw new InvalidOperationException("No visited neighbours");

        return visitedNeighbourDistances.Min() + map.Risk(node);
    }

    private IEnumerable<int> GetVisitedNeighbourDistances(Coordinate node)
    {
        foreach (var neighbour in map.GetAdjacentCoordinates(node))
        {
            if (visitedNodes.TryGetValue(neighbour, out var distanceToNeighbour))
                yield return distanceToNeighbour;
        }
    }
}
