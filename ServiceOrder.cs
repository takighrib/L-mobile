using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
public class ServiceOrder
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CompanyId { get; set; }
    public Company Company { get; set; }
    public string PeopleId { get; set; }
    public People People { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public ICollection<Article> Articles { get; set; } = new List<Article>();
}