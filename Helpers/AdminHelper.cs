using BookHub.Models.Derived;

namespace BookHub.Helpers;

public static class AdminHelper
{
    public static void Admin(Admin admin)
    {
        bool IS_RUNNING = true;

        while (IS_RUNNING)
        {
            MenuHelper.ShowAdminMenu();

            Console.ForegroundColor = ConsoleColor.White;
            string c = MenuHelper.Ask();

            switch (c)
            {
                case "1":
                    Console.Clear();
                    SubmenuHelper.CatalogManagement();
                    string catalogChoice = MenuHelper.Ask();
                    SwitchHelper.Catalog(catalogChoice, admin.Id);
                    break;
                case "2":
                    Console.Clear();
                    SubmenuHelper.UserManagement();
                    string userChoice = MenuHelper.Ask();
                    SwitchHelper.User(userChoice, admin.Id);
                    break;
                case "3":
                    Console.Clear();
                    SubmenuHelper.Reports();
                    string reportChoice = MenuHelper.Ask();
                    SwitchHelper.Report(reportChoice, admin.Id);
                    break;
                case "4":
                    Console.Clear();
                    SubmenuHelper.System();
                    string systemChoice = MenuHelper.Ask();
                    SwitchHelper.System(systemChoice, admin);
                    break;
                case "0":
                    Console.Clear();
                    LoggingHelper.WriteLog(Enums.LogLevel.Info, "Admin", admin.Id, "Logged Out");
                    Console.WriteLine("Bye");
                    IS_RUNNING = false;
                    break;
                default:
                    Console.Clear();
                    LoggingHelper.WriteLog(Enums.LogLevel.Warning, "User", admin.Id, "Made A Wrong Choice (Invalid Input)");
                    MenuHelper.ShowInvalidInput();
                    MenuHelper.Wait();
                    break;
            }
        }
    }
}
