//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReadEFConfig
{
    using System;
    using System.Collections.Generic;
    
    public partial class UnicastBusConfigDB
    {
        public UnicastBusConfigDB()
        {
            this.MessageEndpointMappingDBs = new HashSet<MessageEndpointMappingDB>();
        }
    
        public int id { get; set; }
        public string DistributorControlAddress { get; set; }
        public string DistributorDataAddress { get; set; }
        public string ForwardReceivedMessagesTo { get; set; }
        public string TimeoutManagerAddress { get; set; }
        public System.TimeSpan TimeToBeReceivedOnForwardedMessages { get; set; }
    
        public virtual ICollection<MessageEndpointMappingDB> MessageEndpointMappingDBs { get; set; }
    }
}