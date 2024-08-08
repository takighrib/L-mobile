using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
public class People
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string CompanyId { get; set; }
    public Company Company { get; set; }
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();
}