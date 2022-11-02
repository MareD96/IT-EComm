using System.ComponentModel.DataAnnotations;

namespace IT_EComm.Models
{
    //Move to Microsoft Authetication this was primary account
    [Obsolete]
    public class LocalUser
    {
        [Key]
        public int Id { get; set; }
        //Email Adress
        public string UserName { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
