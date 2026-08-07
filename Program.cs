using BookHub.Helpers;
using BookHub.Models.Base;
using BookHub.Models.Derived;
using BookHub.Services.Implementations;

Person person = null;

while (person == null)
{
    MenuHelper.Menu();
    string choice = MenuHelper.Ask();
    Console.Clear();

    if (choice == "1")
    {
        person = AuthorizationService.Login();
    }
    else if (choice == "2")
    {
        person = AuthorizationService.Register();
    }
    else if (choice == "0")
    {
        Console.WriteLine("Bye");
        return;
    }
    else
    {
        MenuHelper.ShowInvalidInput();
        MenuHelper.Wait();
    }
}


if (person is User user)
{
    UserHelper.User(user);
}
else if (person is Admin admin)
{
    AdminHelper.Admin(admin);
}