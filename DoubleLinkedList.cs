namespace PlaylistApp
{
    public class DoubleLinkedList
    {
        public Node Head { get; private set; }
        private Node tail;

        public DoubleLinkedList()
        {
            Head = null;
            tail = null;
        }

        public void AddTrack(string trackName)
        {
            Node newNode = new Node(trackName);
            if (Head == null)
            {
                Head = newNode;
                tail = newNode;
                Head.Next = tail;
                Head.Previous = tail;
                tail.Next = Head;
                tail.Previous = Head;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                newNode.Next = Head;
                Head.Previous = newNode;
                tail = newNode;
            }
        }

        public void RemoveTrack(string trackName)
        {
            Node current = Head;
            if (current == null) return;

            do
            {
                if (current.TrackName == trackName)
                {
                    if (current == Head && current == tail)
                    {
                        Head = null;
                        tail = null;
                    }
                    else
                    {
                        if (current == Head)
                        {
                            Head = Head.Next;
                        }

                        if (current == tail)
                        {
                            tail = tail.Previous;
                        }

                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }
                    break;
                }
                current = current.Next;
            } while (current != Head);
        }

        public Node FindTrack(string trackName)
        {
            Node current = Head;
            if (current == null) return null;

            do
            {
                if (current.TrackName == trackName)
                {
                    return current;
                }
                current = current.Next;
            } while (current != Head);

            return null;
        }

        public void ShuffleTracks()
        {
            if (Head == null) return;

            Random rand = new Random();
            List<Node> nodes = new List<Node>();
            Node current = Head;
            do
            {
                nodes.Add(current);
                current = current.Next;
            } while (current != Head);

            for (int i = nodes.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                var temp = nodes[i].TrackName;
                nodes[i].TrackName = nodes[j].TrackName;
                nodes[j].TrackName = temp;
            }
        }

        public List<string> GetAllTracks()
        {
            List<string> tracks = new List<string>();
            Node current = Head;
            if (current == null) return tracks;

            do
            {
                tracks.Add(current.TrackName);
                current = current.Next;
            } while (current != Head);

            return tracks;
        }
    }
}
