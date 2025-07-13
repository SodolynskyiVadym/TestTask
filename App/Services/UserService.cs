using App.Models;

namespace App.Services;

public class UserService
{
    private List<UserModel> _users = new()
    {
        new UserModel
        {
            Id = 1,
            FullName = "Alice Johnson",
            Email = "alice.johnson@example.com",
            DateOfBirth = new DateTime(1995, 3, 15)
        },
        new UserModel
        {
            Id = 2,
            FullName = "Bob Smith",
            Email = "bob.smith@example.com",
            DateOfBirth = new DateTime(1990, 7, 22)
        },
        new UserModel
        {
            Id = 3,
            FullName = "Charlie Davis",
            Email = "charlie.davis@example.com",
            DateOfBirth = new DateTime(1988, 12, 5)
        },
        new UserModel
        {
            Id = 4,
            FullName = "Diana Miller",
            Email = "diana.miller@example.com",
            DateOfBirth = new DateTime(2000, 6, 10)
        },
        new UserModel
        {
            Id = 5,
            FullName = "Ethan Brown",
            Email = "ethan.brown@example.com",
            DateOfBirth = new DateTime(1992, 1, 30)
        }
    };
    
    private static int nextId = 6;

    
    public List<UserModel> GetUsers()
    {
        return _users;
    }
    
    public void Add(UserModel user)
    {
        user.Id = nextId++;
        _users.Add(user);
    }
    
    public bool Delete(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null) return false;
        _users.Remove(user);
        return true;
    }
}