using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Lesson_2
{
    internal class Name : INotifyPropertyChanged
    {
        private string mFirstName;
        private string mLastName;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Name(string fName, string lName)
        {
            mFirstName = fName; mLastName = lName;
        }

        public string FirstName
        {
            get { return mFirstName; }
            set
            {
                mFirstName = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(FirstName)));
            }
        }

        public string LastName
        {
            get { return mLastName; }
            set
            {
                mLastName = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(LastName)));
            }
        }
    }

    internal class Names : ObservableCollection<Name>
    {
        public Names() => Add(new($"FirstName {Count + 1}", $"LastName {Count + 1}"));
    }
}
