using BlazorCrudPractice.Shared.Model;

namespace BlazorCrudPractice.Client.State
{
    public class UserInfoState
    {
        private UserInfo changeUserInfo;
        public UserInfo ChangeUserInfo
        {
            get => this.changeUserInfo;
            set
            {
                if (value != null)
                {
                    this.changeUserInfo = value;
                    OnChangeUserInfo?.Invoke(this, value);
                }
            }
        }

        public event EventHandler<UserInfo> OnChangeUserInfo;
    }
}
