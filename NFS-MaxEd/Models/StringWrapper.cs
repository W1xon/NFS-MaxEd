using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFSMaxEd.Models;

public class StringWrapper : INotifyPropertyChanged
    {
        private string _value;

        public string Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged();
                }
            }
        }

        public StringWrapper(string value = "")
        {
            _value = value;
        }

        public static implicit operator StringWrapper(string value)
        {
            return new StringWrapper(value);
        }

        public static implicit operator string(StringWrapper wrapper)
        {
            return wrapper?._value;
        }

        public override string ToString()
        {
            return _value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }