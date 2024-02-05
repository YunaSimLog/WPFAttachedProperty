using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfBase;

namespace WPFAttachedProperty.ModelViews
{
    public class MainViewModel : ViewModelBase
    {
        private string _inputText;
        private string _outputText;
        private string _inputPassword;
        private string _outputPassword;

        public string InputText
        {
            get => _inputText;
            set
            {
                _inputText = value;
                OnPropertyChanged();
                OutputText = _inputText;
                InputPassword = _inputText;
            }
        }

        public string OutputText
        {
            get => _outputText;
            set
            {
                _outputText = value;
                OnPropertyChanged();
            }
        }

        public string InputPassword
        {
            get => _inputPassword; set
            {
                _inputPassword = value;
                OnPropertyChanged();
                OutputPassword = _inputPassword;
            }
        }

        public string OutputPassword
        {
            get => _outputPassword;
            set
            {
                _outputPassword = value;
                OnPropertyChanged();
            }
        }
    }
}
