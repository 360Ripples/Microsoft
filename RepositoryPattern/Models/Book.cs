using System;
using System.Collections.Generic;

namespace LibraryManagementSystemApp.Models;

public partial class Book
{
    public int Bookid { get; set; }

    public string? Bookname { get; set; }

    public string? Author { get; set; }

    public int? Libraryid { get; set; }

    public virtual Library? Library { get; set; }
}
