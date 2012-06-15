using MvvmExample.ViewModel;

namespace MvvmExample.Infrastrucutre
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel
        {
            get
            {
                return App.Container.Resolve<MainViewModel>();
            }
        }
        public  DetailViewModel DetailViewModel
        {
            get
            {
                return App.Container.Resolve<DetailViewModel>();
            }
        }

    }
}