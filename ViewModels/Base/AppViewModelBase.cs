

namespace JOIN.ViewModels.Base;
    public partial class AppViewModelBase : ViewModelBase
    {
        public INavigation NavigationService { get; set; }
        public Page PageService { get; set; }
        protected IApiService _appApiService { get; set; }

        public AppViewModelBase() : base()
        {
        _appApiService = _appApiService;
        }
    }

