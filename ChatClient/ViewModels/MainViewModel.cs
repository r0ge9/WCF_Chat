using ChatClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatClient.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public  MainViewModel() 
        {
            var result = new DataManager().GetDialogs().Result;
            Console.WriteLine();
        }

        private DataManager dataManager;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Dialog> Dialogs { get; set; }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
