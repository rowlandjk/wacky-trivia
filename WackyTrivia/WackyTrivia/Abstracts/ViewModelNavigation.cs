using Xamarin.Forms;

namespace WackyTrivia.Abstracts
{
    /*  Class implemented from Xamarin's TodoMvvm example - used to attach page Navigation
     *  logic in between ViewModels (similar to Navigation.Push events)
     *  https://github.com/conceptdev/xamarin-forms-samples/blob/master/TodoMvvm/TodoMvvm/ViewModelNavigation.cs
     */
    class ViewModelNavigation
    {
        readonly Page _implementor;

        public ViewModelNavigation(Page implementor)
        {
            _implementor = implementor;
        }

        public void Push(Page page)
        {
            _implementor.Navigation.PushAsync(page);
        }

        public void Push<TViewModel>()
            where TViewModel : BaseViewModel
        {
            Push(ViewFactory.CreatePage<TViewModel>());
        }

        public void Pop()
        {
            _implementor.Navigation.PopAsync();
        }

        public void PopToRoot()
        {
            _implementor.Navigation.PopToRootAsync();
        }

        public void PushModal(Page page)
        {
            _implementor.Navigation.PushModalAsync(page);
        }

        public void PushModal<TViewModel>()
            where TViewModel : BaseViewModel
        {
            PushModal(ViewFactory.CreatePage<TViewModel>());
        }

        public void PopModal()
        {
            var modalParent = _implementor;
            while (modalParent.Parent is Page)
                modalParent = (Page)modalParent.Parent;
            _implementor.Navigation.PopModalAsync();
        }
    }
}
