namespace TantaWebAp.ViewModels
{
    public class EmployeeNameWithColorBrchListMsgTempViewModel
    {
        //hidde Some Prepotire - rename property "Web API"
        public string EmpName { get; set; }
        public int EmpId { get; set; }

        //Add Some Extra Inog
        public string Message { get; set; }
        public string Color { get; set; }
        public List<string> Branches { get; set; }
        public int  Temp { get; set; }
    }
}
