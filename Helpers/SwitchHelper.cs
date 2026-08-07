using BookHub.Models.Derived;
using BookHub.Services.Implementations;

namespace BookHub.Helpers;

public static class SwitchHelper
{
    public static void Search(string choice, string userId)
    {
        switch (choice)
        {
            case "1":
                Console.Clear();
                LibraryItemService.SearchByTitle(userId);
                MenuHelper.Wait();
                break;
            case "2":
                Console.Clear();
                LibraryItemService.SearchByAuthor(userId);
                MenuHelper.Wait();
                break;
            case "3":
                Console.Clear();
                LibraryItemService.SearchByGenre(userId);
                MenuHelper.Wait();
                break;
            case "4":
                Console.Clear();
                LibraryItemService.SearchByPublishYear(userId);
                MenuHelper.Wait();
                break;
            case "0":
                Console.Clear();
                break;
            default:
                Console.Clear();
                LoggingHelper.WriteLog(Enums.LogLevel.Warning, "User", userId, "Made A Wrong Choice (Invalid Input)");
                MenuHelper.ShowInvalidInput();
                MenuHelper.Wait();
                break;
        }
    }
    public static void Sort(string choice, string userId)
    {
        switch (choice)
        {
            case "1":
                Console.Clear();
                LibraryItemService.SortByTitleAsc(userId);
                MenuHelper.Wait();
                break;
            case "2":
                Console.Clear();
                LibraryItemService.SortByTitleDesc(userId);
                MenuHelper.Wait();
                break;
            case "3":
                Console.Clear();
                LibraryItemService.SortByYearAsc(userId);
                MenuHelper.Wait();
                break;
            case "4":
                Console.Clear();
                LibraryItemService.SortByYearDesc(userId);
                MenuHelper.Wait();
                break;
            case "0":
                Console.Clear();
                break;
            default:
                Console.Clear();
                LoggingHelper.WriteLog(Enums.LogLevel.Warning, "User", userId, "Made A Wrong Choice (Invalid Input)");
                MenuHelper.ShowInvalidInput();
                MenuHelper.Wait();
                break;
        }
    }
    public static void Catalog(string choice, string adminId)
    {
        switch (choice)
        {
            case "1":
                Console.Clear();
                AdminService.AddNewBook(adminId);
                MenuHelper.Wait();
                break;
            case "2":
                Console.Clear();
                AdminService.AddNewMagazine(adminId);
                MenuHelper.Wait();
                break;
            case "3":
                Console.Clear();
                AdminService.AddNewEBook(adminId);
                MenuHelper.Wait();
                break;
            case "4":
                Console.Clear();
                AdminService.DeleteItem(adminId);
                MenuHelper.Wait();
                break;
            case "5":
                Console.Clear();
                AdminService.EditItem(adminId);
                MenuHelper.Wait();
                break;
            case "6":
                Console.Clear();
                LibraryItemService.ShowAllItems();
                MenuHelper.Wait();
                break;
            case "7":
                Console.Clear();
                SubmenuHelper.FilterCatalog();
                string filterChoice = MenuHelper.Ask();
                SwitchHelper.Filter(filterChoice, adminId);
                break;
            case "0":
                Console.Clear();
                break;
            default:
                Console.Clear();
                LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, "Made A Wrong Choice (Invalid Input)");
                MenuHelper.ShowInvalidInput();
                MenuHelper.Wait();
                break;
        }
    }
    public static void User(string choice, string adminId)
    {
        switch (choice)
        {
            case "1":
                Console.Clear();
                AdminService.ViewUsers(adminId);
                MenuHelper.Wait();
                break;
            case "2":
                Console.Clear();
                AdminService.UserDetails(adminId);
                MenuHelper.Wait();
                break;
            case "0":
                Console.Clear();
                break;
            default:
                Console.Clear();
                LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, "Made A Wrong Choice (Invalid Input)");
                MenuHelper.ShowInvalidInput();
                MenuHelper.Wait();
                break;
        }
    }
    public static void Report(string choice, string adminId)
    {
        switch (choice)
        {
            case "1":
                Console.Clear();
                AdminService.OverdueBookReport(adminId);
                MenuHelper.Wait();
                break;
            case "2":
                Console.Clear();
                AdminService.ViewFines(adminId);
                MenuHelper.Wait();
                break;
            case "3":
                Console.Clear();
                AdminService.TopReaders(adminId);
                MenuHelper.Wait();
                break;
            case "0":
                Console.Clear();
                break;
            default:
                Console.Clear();
                LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, "Made A Wrong Choice (Invalid Input)");
                MenuHelper.ShowInvalidInput();
                MenuHelper.Wait();
                break;
        }
    }
    public static void System(string choice, Admin admin)
    {
        switch (choice)
        {
            case "1":
                Console.Clear();
                AdminService.SendReminders(admin.Id);
                MenuHelper.Wait();
                break;
            case "2":
                Console.Clear();
                AdminService.LogHistory(admin.Id);
                MenuHelper.Wait();
                break;
            case "3":
                Console.Clear();
                AdminService.AddNewAdmin(admin.Id);
                MenuHelper.Wait();
                break;
            case "4":
                Console.Clear();
                AdminService.ChangePassword(admin);
                MenuHelper.Wait();
                break;
            case "0":
                Console.Clear();
                break;
            default:
                Console.Clear();
                LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", admin.Id, "Made A Wrong Choice (Invalid Input)");
                MenuHelper.ShowInvalidInput();
                MenuHelper.Wait();
                break;
        }
    }
    public static void Filter(string choice, string adminId)
    {
        switch (choice)
        {
            case "1":
                Console.Clear();
                LibraryItemService.FilterByTitle(adminId);
                MenuHelper.Wait();
                break;
            case "2":
                Console.Clear();
                LibraryItemService.FilterByAuthor(adminId);
                MenuHelper.Wait();
                break;
            case "3":
                Console.Clear();
                LibraryItemService.FilterByGenre(adminId);
                MenuHelper.Wait();
                break;
            case "4":
                Console.Clear();
                LibraryItemService.FilterByYear(adminId);
                MenuHelper.Wait();
                break;
            case "5":
                Console.Clear();
                LibraryItemService.ShowAvailableItems();
                MenuHelper.Wait();
                break;
            case "6":
                Console.Clear();
                LibraryItemService.OnlyBooks(adminId);
                MenuHelper.Wait();
                break;
            case "7":
                Console.Clear();
                LibraryItemService.OnlyMagazines(adminId);
                MenuHelper.Wait();
                break;
            case "8":
                Console.Clear();
                LibraryItemService.OnlyEBooks(adminId);
                MenuHelper.Wait();
                break;
            case "0":
                Console.Clear();
                break;
            default:
                Console.Clear();
                LoggingHelper.WriteLog(Enums.LogLevel.Warning, "Admin", adminId, "Made A Wrong Choice (Invalid Input)");
                MenuHelper.ShowInvalidInput();
                MenuHelper.Wait();
                break;
        }
    }
}
