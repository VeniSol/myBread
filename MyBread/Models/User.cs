﻿namespace MyBread.Models;

public class User
{    
    public User(string login, string password)
     {
         this.login = login;
         this.password = password;
     }

    public User(int id, string login, string password)
    {
        this.id = id;
        this.login = login;
        this.password = password;
    }

    public User()
    {
    }

    private int id;
    private string login;
    private string password;
    
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Login
    {
        get { return login; }
        set { login = value; }
    }

    public string Password
    {
        get { return password; }
        set { password = value; }
    }
    
    
}