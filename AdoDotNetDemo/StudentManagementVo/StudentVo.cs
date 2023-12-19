namespace StudentManagementVo
{
    public class StudentVo
    {
        public int Id
        {
            get; set;
        }
        public string? Name
        {
            get; set;
        }
        public int Age
        {
            get; set;
        }
        
        public override string ToString()
        {
            return "[StudentVo:" + "Student ID:" + Id + " " + "Student Name:" + Name + " " + "Student Age:" + Age + "]";
        }
    }
}