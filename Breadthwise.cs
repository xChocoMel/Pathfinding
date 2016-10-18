public static List<Node> BreadthwiseSearch(Node start, Node end) {
	Queue<Node> working = new Queue<Node> ();
	List<Node> visited = new List<Node> ();
	
	working.Enqueue (start);
	visited.Add (start);
	start.history = new List<Node>();

	while (working.Count > 0) {
		Node currentNode = working.Dequeue ();

		if (currentNode == end) {
			//Found the final node
			List<Node> result = currentNode.history;
			result.Add (currentNode);
			return result;
		} else {			
			for (int i = 0; i < currentNode.neighbours.Length; i++) {				
				Node currentChild = currentNode.neighbours[i];
				
				//Check if it hasn't been visited
				if(!visited.Contains(currentChild)){
					working.Enqueue(currentChild);
					visited.Add(currentChild);

					//Update history
					currentChild.history = new List<Node>(currentNode.history);
					currentChild.history.Add (currentNode);						
				}
			}
		}
	}

	return null;
}