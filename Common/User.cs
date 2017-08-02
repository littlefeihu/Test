using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{

    [DataContract]
    [Table("Users")]
    public class User : Entity
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int RoleId { get; set; }
    }
}
