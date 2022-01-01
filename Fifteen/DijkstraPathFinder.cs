namespace Fifteen;

internal class DijkstraPathFinder
{
    private readonly CaveMap map;
    private readonly Dictionary<Coordinate, NodeState> nodeStates;

    public DijkstraPathFinder(CaveMap map)
    {
        this.map = map;
        nodeStates = map.AllCoordinates.ToDictionary(c => c, _ => NodeState.Unvisited);
    }

    public int FindShortestPathLength()
    {
        foreach (var node in EnumerateNodesToVisit())
            VisitNode(node);

        var endNodeState = nodeStates[map.End];
        return endNodeState.Distance ?? throw new InvalidOperationException("Haven't reached the end yet");
    }

    private void VisitNode(Coordinate node) => nodeStates[node] = new(GetDistanceTo(node));

    private IEnumerable<Coordinate> EnumerateNodesToVisit()
    {
        for (var node = map.Start; ; node = GetNextNodeToVisit())
        {
            Console.WriteLine($"Visiting node {node}");
            yield return node;
            if (node == map.End)
                yield break;
        }
    }

    private Coordinate GetNextNodeToVisit()
    {
        var unvisitedNodeDistances = GetPossibleNextNodes().ToDictionary(c => c, GetDistanceTo);
        return unvisitedNodeDistances.OrderBy(kvp => kvp.Value).First().Key;
    }

    private IEnumerable<Coordinate> GetPossibleNextNodes()
        => nodeStates
            .Where(kvp => kvp.Value.Visited)
            .Select(kvp => kvp.Key)
            .SelectMany(map.GetAdjacentCoordinates)
            .Where(c => !nodeStates[c].Visited)
            .Distinct();

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
            var nodeState = nodeStates[neighbour];
            if (nodeState.Distance.HasValue)
                yield return nodeState.Distance.Value;
        }
    }

    private record NodeState(int? Distance)
    {
        public static NodeState Unvisited = new((int?)null);
        public bool Visited => Distance.HasValue;
    }
}
