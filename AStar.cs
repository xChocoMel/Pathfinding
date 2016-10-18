public static List<Node> AStar(Node start, Node end) {
	List<Node> visited = new List<Node>();
	List<Node> working = new List<Node>();

	visited.Add(start);
	working.Add(start);
	start.history = new List<Node>();

	//Distance from start to current Node
	start.g = 0;
	
	//Distance from current Node to end
	start.f = start.g + Vector3.Distance(start.transform.position, end.transform.position);

	while (working.Count > 0) {
		//Get the best one (the smallest f)
		int smallest = 0;

		for (int i = 0; i < working.Count; i ++) {
			if (working[i].f < working[smallest].f) {
				smallest = i;
			}
		}

		Node smallestNode = working[smallest];
		
		//Remove from working list
		working.Remove(smallestNode);

		if (smallestNode == end) {
			//Found the final node
			List<Node> result = new List<Node>(smallestNode.history);
			result.Add(smallestNode);
			return result;
		} else {
			//Not the final node
			for (int i = 0; i < smallestNode.neighbours.Length; i ++) {
				Node currentChild = smallestNode.neighbours[i];

				if (!visited.Contains(currentChild)) {
					visited.Add(currentChild);
					working.Add(currentChild);

					//f, g, h
					currentChild.g = smallestNode.g + Vector3.Distance(currentChild.transform.position, smallestNode.transform.position);
					float h = Vector3.Distance(currentChild.transform.position, end.transform.position);
					currentChild.f = currentChild.g + h;

					//Update history
					currentChild.history = new List<Node>(smallestNode.history);
					currentChild.history.Add(smallestNode);
				}
			}
		}
	}

	return null;
}
