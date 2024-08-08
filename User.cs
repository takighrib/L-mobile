using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class User
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string RoleId { get; set; }
    public Role Role { get; set; }
    public string CompanyId { get; set; } // Add this property
    public Company Company { get; set; } // Add this navigation property
    public ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();
    public ICollection<Article> CreatedArticles { get; set; } = new List<Article>();
    public ICollection<People> InteractedPeople { get; set; } = new List<People>();
}