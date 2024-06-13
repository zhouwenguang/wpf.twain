using Prism.Mvvm;
using Prism.Navigation;

namespace wpf.twain.demo.Core.Mvvm
{
    public abstract class ViewModelBase : BindableBase, IDestructible
    {
        protected ViewModelBase()
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
