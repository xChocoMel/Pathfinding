public static List<Node> DepthwiseSearch(Node start, Node end) {
	List<Node> visited = new List<Node>();
	Stack<Node> working = new Stack<Node>();
			
	visited.Add(start);
	working.Push(start);
	working.history = new List<Node>();

	while (working.Count > 0) {
		Node currentNode = working.Pop();

		if (currentNode == end) {
			//Found the final node
			List<Node> result = currentNode.history;
			result.Add(currentNode);
			return result;
		} else {
			//Not the final node
			//Loop through neigbours
			for (int i = 0; i < currentNode.neighbours.Length; i++) {
				Node currentNeighbour = currentNode.neighbours[i];
				
				if (!visited.Contains(currentNeighbour)) {
					visited.Add(currentNeighbour);
					working.Push(currentNeighbour);

					currentNeighbour.history = new List<Node>(currentNode.history);
					currentNeighbour.history.Add(currentNode);
				}
			}
		}
	}

	return null;
}