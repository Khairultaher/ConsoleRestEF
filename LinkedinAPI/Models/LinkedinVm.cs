namespace LinkedinAPI.Models
{
    public class LinkedINVM
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }


    public class LinkedINResVM
    {
        public string firstName { get; set; }
        public string headline { get; set; }
        public string id { get; set; }
        public string lastName { get; set; }
        public Sitestandardprofilerequest siteStandardProfileRequest { get; set; }
    }

    public class Sitestandardprofilerequest
    {
        public string url { get; set; }
    }
}
