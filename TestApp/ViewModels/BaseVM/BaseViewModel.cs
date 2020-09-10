using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestApp.ViewModels.BaseVM
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Default
        /// </summary>
        /// <param name="prop"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        /// <summary>
        /// extended
        /// </summary>
        /// <param name="prop"></param>
        protected virtual void OnPropertyChanged(params string[] prop)
        {
            if (PropertyChanged != null)
            {
                foreach (var item in prop)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(item));
                }
            }
        }
    }
}
