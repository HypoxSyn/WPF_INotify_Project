using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WPF_INotify_Project
{
    public class Sum : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _num1;
        private string _num2;
        private string _result;

        public string Num1 
        {
            get { return _num1;} 
            set {
                    bool res = int.TryParse(value, out int number);
                    if (res)
                    {
                        _num1 = value;
                        OnPropertyChanged("Num1");
                        OnPropertyChanged("Result");
                    }
                }
        }
        public string Num2
        {
            get { return _num2;}
            set {
                    bool res = int.TryParse(value, out int number);
                    if (res)
                    {
                        _num2 = value;
                        OnPropertyChanged("Num2");
                        OnPropertyChanged("Result");
                    }
            }
        }
        public string Result
        {
            get
            {
                int res = int.Parse(Num1) + int.Parse(Num2);
                return res.ToString();
            }
            set
            {
                int res = int.Parse(Num1) + int.Parse(Num2);
                _result = res.ToString();
                OnPropertyChanged("Result");
            }
        }

        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
