using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
public class Article
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public string CreatedById { get; set; }
    public User CreatedBy { get; set; }
    public ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();
}