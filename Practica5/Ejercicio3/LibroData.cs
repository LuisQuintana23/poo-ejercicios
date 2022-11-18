
public class LibroData{
    public string key { get; set; }
    public string name { get; set; }
    public string subject_type { get; set; }
    public int work_count { get; set; }
    public List<Work> works { get; set; }
}

public class Author
{
    public string key { get; set; }
    public string name { get; set; }
}

public class Availability
{
    public string status { get; set; }
    public bool available_to_browse { get; set; }
    public bool available_to_borrow { get; set; }
    public bool available_to_waitlist { get; set; }
    public bool is_printdisabled { get; set; }
    public bool is_readable { get; set; }
    public bool is_lendable { get; set; }
    public bool is_previewable { get; set; }
    public string identifier { get; set; }
    public string isbn { get; set; }
    public object oclc { get; set; }
    public string openlibrary_work { get; set; }
    public string openlibrary_edition { get; set; }
    public DateTime? last_loan_date { get; set; }
    public string num_waitlist { get; set; }
    public DateTime? last_waitlist_date { get; set; }
    public bool is_restricted { get; set; }
    public bool is_browseable { get; set; }
    public string __src__ { get; set; }
}


public class Work
{
    public string key { get; set; }
    public string title { get; set; }
    public int edition_count { get; set; }
    public int cover_id { get; set; }
    public string cover_edition_key { get; set; }
    public List<string> subject { get; set; }
    public List<string> ia_collection { get; set; }
    public bool lendinglibrary { get; set; }
    public bool printdisabled { get; set; }
    public string lending_edition { get; set; }
    public string lending_identifier { get; set; }
    public List<Author> authors { get; set; }
    public int first_publish_year { get; set; }
    public string ia { get; set; }
    public bool public_scan { get; set; }
    public bool has_fulltext { get; set; }
    public Availability availability { get; set; }
}

