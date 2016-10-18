public class Node {
    public Node[] neighbours;
    public List<Node> history;
	
    public float f, g;

    void OnDrawGizmos() {
        Gizmos.color = Color.green;

        for (int i = 0; i < neighbours.Length; i++) {
            Gizmos.DrawLine (transform.position, neighbours [i]
                        .transform.position);
        }
    }
}
