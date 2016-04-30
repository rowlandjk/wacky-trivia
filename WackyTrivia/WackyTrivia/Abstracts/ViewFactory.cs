using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace WackyTrivia.Abstracts
{
    /*
     * View Factory implemented from Xamarin's TodoMvvm example - Called to create all views
     * and bind ViewModels to those views.
     * https://github.com/conceptdev/xamarin-forms-samples/blob/master/TodoMvvm/TodoMvvm/ViewFactory.cs
     */

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ViewTypeAttribute : Attribute
    {
        public Type ViewType { get; private set; }

        public ViewTypeAttribute(Type viewType)
        {
            ViewType = viewType;
        }
    }

    static class ViewFactory
    {
        static Dictionary<Type, Type> typeDictionary = new Dictionary<Type, Type>();
        public static void Register<TView, TViewModel>()
            where TView : Page
            where TViewModel : BaseViewModel
        {
            typeDictionary[typeof(TViewModel)] = typeof(TView);
        }

        public static Page CreatePage(Type viewModelType)
        {
            Type viewType = null;

            if (typeDictionary.ContainsKey(viewModelType))
            {
                viewType = typeDictionary[viewModelType];
            }
            else
            {
                throw new InvalidOperationException("Unknown View for ViewModelType");
            }

            var page = (Page)Activator.CreateInstance(viewType);
            var viewModel = (BaseViewModel)Activator.CreateInstance(viewModelType);

            viewModel.Navigation = new ViewModelNavigation(page);
            page.BindingContext = viewModel;

            return page;
        }

        public static Page CreatePage(BaseViewModel viewModel)
        {
            Type viewType = null;
            if (typeDictionary.ContainsKey(viewModel.GetType()))
            {
                viewType = typeDictionary[viewModel.GetType()];
            }
            else
            {
                throw new InvalidOperationException("Unknown View for ViewModel object");
            }

            var page = (Page)Activator.CreateInstance(viewType);

            viewModel.Navigation = new ViewModelNavigation(page);
            page.BindingContext = viewModel;

            return page;
        }


        public static Page CreatePage<TViewModel>()
            where TViewModel : BaseViewModel
        {
            var viewModelType = typeof(TViewModel);
            return CreatePage(viewModelType);
        }
    }
}
