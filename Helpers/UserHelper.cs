using BookHub.Models;
using BookHub.Models.Derived;
using BookHub.Services.Implementations;

namespace BookHub.Helpers;

public static class UserHelper
{
    public static void User(User user)
    {
        bool IS_RUNNING = true;

        while (IS_RUNNING)
        {
            MenuHelper.ShowUserMenu();

            Console.ForegroundColor = ConsoleColor.White;
            string choice = MenuHelper.Ask();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    LibraryItemService.ShowAllItems();
                    MenuHelper.Wait();
                    break;
                case "2":
                    Console.Clear();
                    SubmenuHelper.SearchSubmenu();
                    string searchChoice = MenuHelper.Ask();
                    SwitchHelper.Search(searchChoice, user.Id);
                    break;
                case "3":
                    Console.Clear();
                    LibraryItemService.ShowAvailableItems();
                    MenuHelper.Wait();
                    break;
                case "4":
                    Console.Clear();
                    SubmenuHelper.SortSubmenu();
                    string sortChoice = MenuHelper.Ask();
                    SwitchHelper.Sort(sortChoice, user.Id);
                    break;
                case "5":
                    Console.Clear();
                    BorrowService.Borrow(user);
                    MenuHelper.Wait();
                    break;
                case "6":
                    Console.Clear();
                    ReturnService.Return(user);
                    MenuHelper.Wait();
                    break;
                case "7":
                    Console.Clear();
                    UserService.CurrentlyBorrowedItems(user);
                    MenuHelper.Wait();
                    break;
                case "8":
                    Console.Clear();
                    UserService.BorrowHistory(user);
                    MenuHelper.Wait();
                    break;
                case "9":
                    Console.Clear();
                    UserService.OverdueItemsAndFines(user);
                    MenuHelper.Wait();
                    break;
                case "10":
                    Console.Clear();
                    UserService.ViewProfile(user);
                    MenuHelper.Wait();
                    break;
                case "11":
                    Console.Clear();
                    UserService.ChangePassword(user);
                    MenuHelper.Wait();
                    break;
                case "0":
                    Console.Clear();
                    LoggingHelper.WriteLog(Enums.LogLevel.Info, "User", user.Id, "Logged Out");
                    Console.WriteLine("Bye");
                    IS_RUNNING = false;
                    break;
                default:
                    Console.Clear();
                    LoggingHelper.WriteLog(Enums.LogLevel.Warning, "User", user.Id, "Made A Wrong Choice (Invalid Input)");
                    MenuHelper.ShowInvalidInput();
                    MenuHelper.Wait();
                    break;
            }
        }
    }
}