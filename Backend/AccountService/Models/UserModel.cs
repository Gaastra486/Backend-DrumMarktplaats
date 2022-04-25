namespace AccountService.Models
{
    public class UserModel
    {
        public string username { get; set; }

        public string password { get; set; }
        
        public string email { get; set; }

        public string postalcode { get; set; }  

        public int Id { get; }


    }
}
