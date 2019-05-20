using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindingSecondPart.Models
{
    public class Item : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                UpdateProperty("Name");
            }
        }
        public string Description { get; set; }
        public int Price { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void UpdateProperty([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
