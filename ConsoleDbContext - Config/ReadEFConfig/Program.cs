using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus.Config;

namespace ReadEFConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            /**************
             * Read the database fields
             * ************/
            using (var db = new nservicebusEntities())
            {
                var unicasts = db.UnicastBusConfigDBs;
                // Get the first UnicastConfig record for now
                var unicastBusCfgDB = unicasts.FirstOrDefault();
                /*****
                 * Get the message endpoints per unicast
                 * ****/
                var messageEndpoints = db.MessageEndpointMappingDBs;
                foreach (var endpoint in messageEndpoints)
                {
                    if (unicastBusCfgDB.id == endpoint.UnicastBusConfigDBId)
                    {
                        unicastBusCfgDB.MessageEndpointMappingDBs.Add(endpoint);
                    }
                }
                /****
                 * Fill in normal unicast config from DB
                 * *****/
                UnicastBusConfig unicastBusCfg = new UnicastBusConfig();
                unicastBusCfg.DistributorControlAddress = unicastBusCfgDB.DistributorControlAddress;
                unicastBusCfg.DistributorDataAddress = unicastBusCfgDB.DistributorDataAddress;
                unicastBusCfg.ForwardReceivedMessagesTo = unicastBusCfgDB.ForwardReceivedMessagesTo;
                unicastBusCfg.TimeoutManagerAddress = unicastBusCfgDB.TimeoutManagerAddress;
                unicastBusCfg.TimeToBeReceivedOnForwardedMessages = unicastBusCfgDB.TimeToBeReceivedOnForwardedMessages;
                Console.WriteLine(unicastBusCfg);
                /**
                 * Add Message Endpoint Mappings
                 * ***/
                unicastBusCfg.MessageEndpointMappings = new MessageEndpointMappingCollection(); 
                foreach (var endpointDB in unicastBusCfgDB.MessageEndpointMappingDBs)
                {
                    MessageEndpointMapping endpoint =  new MessageEndpointMapping();
                    endpoint.AssemblyName = endpointDB.AssemblyName;
                    endpoint.Endpoint = endpointDB.Endpoint;
                    endpoint.Messages = endpointDB.Messages;
                    endpoint.Namespace = endpointDB.Namespace;
                    endpoint.TypeFullName = endpointDB.TypeFullName;
                    unicastBusCfg.MessageEndpointMappings.Add(endpoint);
                    Console.WriteLine(endpoint);
                }
            }

        }
    }
}
