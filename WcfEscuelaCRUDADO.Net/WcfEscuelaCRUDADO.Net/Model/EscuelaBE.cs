using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfEscuelaCRUDADO.Net.Model
{
    [DataContract]
    public class EscuelaBE
    {
        [DataMember]
        public int idMaestro { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [DataMember]
        public DateTime FechaNacimiento { get; set; }
        [DataMember]
        public DateTime FechaIngreso { get; set; }

    }
}