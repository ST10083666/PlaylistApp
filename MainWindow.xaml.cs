using System.Windows;
using System.Collections.Generic;

namespace PlaylistApp
{
    public partial class MainWindow : Window
    {
        private DoubleLinkedList playlist;
        private Node currentTrack;

        public MainWindow()
        {
            InitializeComponent();
            playlist = new DoubleLinkedList();

          
            playlist.AddTrack("Track 1");
            playlist.AddTrack("Track 2");
            playlist.AddTrack("Track 3");
            playlist.AddTrack("Track 4");

            UpdateTrackList();
        }

        private void AddTrack_Click(object sender, RoutedEventArgs e)
        {
            string trackName = TrackNameTextBox.Text;
            if (!string.IsNullOrEmpty(trackName))
            {
                playlist.AddTrack(trackName);
                UpdateTrackList();
                TrackNameTextBox.Clear();
            }
        }

        private void PrevTrack_Click(object sender, RoutedEventArgs e)
        {
            if (currentTrack != null && currentTrack.Previous != null)
            {
                currentTrack = currentTrack.Previous;
                CurrentTrackLabel.Content = currentTrack.TrackName;
            }
        }

        private void NextTrack_Click(object sender, RoutedEventArgs e)
        {
            if (currentTrack != null && currentTrack.Next != null)
            {
                currentTrack = currentTrack.Next;
                CurrentTrackLabel.Content = currentTrack.TrackName;
            }
        }

        private void DeleteCurrentTrack_Click(object sender, RoutedEventArgs e)
        {
            if (currentTrack != null)
            {
                string trackName = currentTrack.TrackName;
                Node nextTrack = currentTrack.Next ?? currentTrack.Previous;
                playlist.RemoveTrack(trackName);
                currentTrack = nextTrack;
                CurrentTrackLabel.Content = currentTrack?.TrackName ?? string.Empty;
                UpdateTrackList();
            }
        }

        private void UpdateTrackList()
        {
            List<string> tracks = playlist.GetAllTracks();
            TracksListBox.ItemsSource = null;
            TracksListBox.ItemsSource = tracks;
            currentTrack = playlist.Head;
            CurrentTrackLabel.Content = currentTrack?.TrackName ?? string.Empty;
        }
    }
}
