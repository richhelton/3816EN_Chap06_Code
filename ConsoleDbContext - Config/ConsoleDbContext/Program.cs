using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus.Config;

namespace ConsoleDbContext
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {

                /*********************************
                 *  <UnicastBusConfig ForwardReceivedMessagesTo="MyAudits">
                        <MessageEndpointMappings>
                         <add Endpoint="MySFTPClient" Messages="MyMessages.SendCommand, MyMessages" />
                        </MessageEndpointMappings>
                    </UnicastBusConfig>
                 * ***********************/
                MessageEndpointMappingDB mapping = new MessageEndpointMappingDB();
                mapping.Endpoint = "MySFTPClient";
                mapping.Messages = "MyMessages.SendCommand, MyMessages";
                UnicastBusConfigDB unicastBusCfgDB = new UnicastBusConfigDB();
                unicastBusCfgDB.ForwardReceivedMessagesTo = "MyAudits";
                unicastBusCfgDB.messageMaps.Add(mapping);
                db.unicastBusConfigs.Add(unicastBusCfgDB);
                db.SaveChanges();

            }
        }
    }
}
