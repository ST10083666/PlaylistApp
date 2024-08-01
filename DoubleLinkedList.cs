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
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
        }

        public void RemoveTrack(string trackName)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.TrackName == trackName)
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        Head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        tail = current.Previous;
                    }
                    break;
                }
                current = current.Next;
            }
        }

        public Node FindTrack(string trackName)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.TrackName == trackName)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public void ShuffleTracks()
        {
            Random rand = new Random();
            List<Node> nodes = new List<Node>();
            Node current = Head;
            while (current != null)
            {
                nodes.Add(current);
                current = current.Next;
            }

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
            while (current != null)
            {
                tracks.Add(current.TrackName);
                current = current.Next;
            }
            return tracks;
        }
    }
}
