using System;
using System.Collections.Generic;

namespace LibraryManagementSystemApp.Models;

public partial class Library
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? City { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
