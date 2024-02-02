namespace VineforceShivamPratapSinghDb.Dto
{
    public class StateDto
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int? CountryId { get; set; }
        public string CountryName { get; set; }
    }

    public class StatePostData
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int? CountryId { get; set; }
    }
}
