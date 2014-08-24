using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MVCApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            ArrayList list = new ArrayList();
            int length = 5;

            using (var db = new AppContext())
            {
                for (int index = 0; index < length; index++)
                {
                    Paymessage message = new Paymessage();
                    message.id = index + 1;
                    message.error = "None";
                    message.state = "initial";
                    if (index == 0)
                        message.EventId = new Guid("8b265223-dc9e-4789-a6df-69d19f644ad7");
                    else if (index == 1)
                        message.EventId = new Guid("3721ba5d-4733-4d98-a5e2-8e8afa3e61f4");
                    else if (index == 2)
                        message.EventId = new Guid("1ac188ec-4b2e-436c-b989-db88c65db1fa");
                    else if (index == 3)
                        message.EventId = new Guid("9bf180fa-f8f4-4b2b-8fac-cca73a4e2cab");
                    else if (index == 4)
                        message.EventId = new Guid("ee2c56f7-6d42-4314-bce5-4825ed294437");
                    db.Paymessages.Add(message);
                    db.SaveChanges();
                }
            }
        }
    }
}
