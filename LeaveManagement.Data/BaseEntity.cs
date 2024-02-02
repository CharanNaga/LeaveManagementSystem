namespace LeaveManagement.Data
{
    //Creating Abstract Class to Include Id, DateCreated & DateModified properties to inherit in every entity classes to avoid repetition without creating instance of the same
    public abstract class BaseEntity 
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}