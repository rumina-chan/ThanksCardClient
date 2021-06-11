using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class UserEditViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region UserProperty
        private User _User;
        public User User
        {
            get { return _User; }
            set { SetProperty(ref _User, value); }
        }
        #endregion

        #region DepartmentChildrensProperty
        private List<DepartmentChildren> _DepartmentChildrens;
        public List<DepartmentChildren> DepartmentChildrens
        {
            get { return _DepartmentChildrens; }
            set { SetProperty(ref _DepartmentChildrens, value); }
        }
        #endregion

        public UserEditViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 画面遷移元から送られる SelectedUser パラメーターを取得。
            this.User = navigationContext.Parameters.GetValue<User>("SelectedUser");

            DepartmentChildren dept = new DepartmentChildren();
            this.DepartmentChildrens = await dept.GetDepartmentChildrensAsync();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #region SubmitCommand
        private DelegateCommand _SubmitCommand;
        public DelegateCommand SubmitCommand =>
            _SubmitCommand ?? (_SubmitCommand = new DelegateCommand(ExecuteSubmitCommand));

        async void ExecuteSubmitCommand()
        {
            User updatedUser = await User.PutUserAsync(this.User);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.UserMst));
        }
        #endregion
    }
}
