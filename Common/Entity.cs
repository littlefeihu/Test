using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class Entity
    {

        [DataMember]
        [Key]
        public int Id { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public DateTime CreateOn { get; set; }
        [DataMember]
        public string CreateBy { get; set; }
        [DataMember]
        public DateTime UpdateOn { get; set; }
        [DataMember]
        public string UpdateBy { get; set; }

    }
}
