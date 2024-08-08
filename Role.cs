using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class Role
{
    public string Id { get; set; }
    public string Name { get; set; }
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}