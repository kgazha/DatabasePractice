using System.ComponentModel.DataAnnotations.Schema;

namespace DatabasePractice.Models;

[Table("employee")]
public class Employee
{
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("salary")]
    public long Salary { get; set; }

    [Column("gender")]
    public bool Gender { get; set; }

    [Column("age")]
    public int Age { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}