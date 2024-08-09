using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class Role
{
    public string Id { get; set; }
    public string Name { get; set; }
     public string UserId { get; set; }
    public User User { get; set; }
   public List<Permission> Permissions { get; set; } = new List<Permission>();

}