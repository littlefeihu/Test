﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    [DataContract(Namespace = "http://www.dqinfo.net/2017/dqinfo")]
    public class CRUDCmd : ServerCommand
    {
        [DataMember]

        public string IP { get; set; }


    }
}