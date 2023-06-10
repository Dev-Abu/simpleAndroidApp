using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;



namespace App2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private EditText noteEntryEditText;
        private Button addNoteButton;
        private ListView noteListView;
        private ArrayAdapter<string> noteAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            noteEntryEditText = FindViewById<EditText>(Resource.Id.NoteEntry);
            addNoteButton = FindViewById<Button>(Resource.Id.AddNoteButton);
            noteListView = FindViewById<ListView>(Resource.Id.NoteListView);

            noteAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1);
            noteListView.Adapter = noteAdapter;

            addNoteButton.Click += AddNoteButton_Click;
            LoadInitialNotes();
        }

        private void AddNoteButton_Click(object sender, System.EventArgs e)
        {
            string noteText = noteEntryEditText.Text.Trim();
            if (!string.IsNullOrEmpty(noteText))
            {
                noteAdapter.Add(noteText);
                noteEntryEditText.Text = string.Empty;
            }
        }

        private void LoadInitialNotes()
        {
            noteAdapter.Add("Note 1");
            noteAdapter.Add("Note 2");
            noteAdapter.Add("Note 3");
        }
    }
}
