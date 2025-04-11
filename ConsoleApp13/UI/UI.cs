
namespace ConsoleApp13.UI;

internal class MainUI
{
    private AdminUI _adminUI;
    private UserUI _userUI;

    public MainUI(AdminUI adminUI, UserUI userUI)
    {
        _adminUI = adminUI;
        _userUI = userUI;
    }

    public async Task MainMenuShow()
    {
        while (true)
        {
            int op = "1. Admin | 2. User | 0. Exit".TryConvertWithMessage<int>(true, ConsoleColor.Blue);

            switch (op)
            {
                case 1:
                   await _adminUI.ShowAdminPanel();
                    break;
                case 2:
                   await _userUI.UserPanelShow();
                    break;
                case 0:
                    return;
            }
        }
    }
}
