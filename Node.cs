namespace PlaylistApp
{
    public class Node
    {
        public string TrackName { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(string trackName)
        {
            TrackName = trackName;
            Next = null;
            Previous = null;
        }
    }
}
