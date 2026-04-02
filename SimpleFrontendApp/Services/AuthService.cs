using System;
using System.Collections.Generic;
using System.Linq;

public class AuthService
{
    private List<User> users = new()
    {
        new User { Username = "admin", Password = "1234" }
    };

    public bool IsLoggedIn { get; private set; } = false;
    public string CurrentUser { get; private set; } = null;

    public event Action OnChange; // подія зміни стану

    public bool Login(string username, string password)
    {
        var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            IsLoggedIn = true;
            CurrentUser = username;
            NotifyStateChanged();
            return true;
        }
        return false;
    }

    public bool Register(string username, string password)
    {
        if (users.Any(u => u.Username == username)) return false;
        users.Add(new User { Username = username, Password = password });
        return true;
    }

    public void Logout()
    {
        IsLoggedIn = false;
        CurrentUser = null;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
}