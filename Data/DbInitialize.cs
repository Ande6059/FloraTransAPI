using FloraTransAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloraTransAPI.Data
{
    public class DbInitializer
    {
        public void DbInitialize(FloraTransAPIContext context)
        {
            if (context.Client.Any() && context.Contact.Any() && context.Container.Any() && context.Warehouse.Any())
            {
                return; // DB has been seeded
            }

            var contacts = new Contact[]
            {
                new Contact {Name = "Karl Loanman", JobTitle = "Liason", Email = "Loanman3000@gmail.com", PhoneNumber = "11111111"},
                new Contact {Name = "Carlene Loanwoman", JobTitle = "Liason", Email = "Loanwoman3000@gmail.com", PhoneNumber = "22222222"},
                new Contact {Name = "Ron Swanson", JobTitle = "Liason", Email = "Legend@gmail.com", PhoneNumber = "33333333"}
            };

            var Warehouse = new Warehouse
            {
                RentedContainersCC = 10
            };

            var containers = new Container[]
            {
                new Container {Rented = new DateTime(2021, 1, 1), Returned = new DateTime(2021, 2, 2), Available = true, Lost = false, CurrentClient = 1},
                new Container {Rented = new DateTime(2021, 3, 3), Returned = null, Available = false, Lost = false, CurrentClient = 2},
                new Container {Rented = new DateTime(2021, 4, 4), Returned = null, Available = false, Lost = true, CurrentClient = 2},
                new Container {Rented = new DateTime(2021, 5, 5), Returned = new DateTime(2021, 6, 6), Available = true, Lost = false, CurrentClient = 3},
                new Container {Rented = new DateTime(2021, 7, 7), Returned = new DateTime(2021, 8, 8), Available = true, Lost = false, CurrentClient = 3},
                new Container {Rented = new DateTime(2021, 1, 1), Returned = null, Available = false, Lost = true, CurrentClient = 1},
                new Container {Rented = null, Returned = null, Available = true, Lost = false, CurrentClient = 0},
                new Container {Rented = null, Returned = null, Available = true, Lost = false, CurrentClient = 0},
                new Container {Rented = null, Returned = null, Available = true, Lost = false, CurrentClient = 0},
                new Container {Rented = null, Returned = null, Available = true, Lost = false, CurrentClient = 0},
            };

            List<Container> cvr1Rented = new List<Container>();
            cvr1Rented.Add(containers[0]);
            cvr1Rented.Add(containers[5]);
            List<Container> cvr2Rented = new List<Container>();
            cvr2Rented.Add(containers[1]);
            cvr2Rented.Add(containers[2]);

            List<Container> cvr3Rented = new List<Container>();
            cvr3Rented.Add(containers[3]);
            cvr3Rented.Add(containers[4]);

            var clients = new Client[]
            {
            new Client {CVR = 1, Address = "Seebladsgade 1", Contact = contacts[0], RentedContainer = cvr1Rented},
            new Client {CVR = 2, Address = "Odensestreet 5", Contact = contacts[1], RentedContainer = cvr2Rented},
            new Client {CVR = 3, Address = "Odensestreet 6", Contact = contacts[2], RentedContainer = cvr3Rented},
            };

            //var containerAssignment = new ContainerAssignment[]
            //{
            //    new ContainerAssignment {ContainerID = containers.Single(c => c.CCTag == 1).CCTag, ClientID = clients.Single(c => c.ID == 1).ID},
            //    new ContainerAssignment {ContainerID = containers.Single(c => c.CCTag == 2).CCTag, ClientID = clients.Single(c => c.ID == 1).ID},
            //    new ContainerAssignment {ContainerID = containers.Single(c => c.CCTag == 3).CCTag, ClientID = clients.Single(c => c.ID == 2).ID},
            //    new ContainerAssignment {ContainerID = containers.Single(c => c.CCTag == 4).CCTag, ClientID = clients.Single(c => c.ID == 2).ID},
            //    new ContainerAssignment {ContainerID = containers.Single(c => c.CCTag == 5).CCTag, ClientID = clients.Single(c => c.ID == 3).ID},
            //    new ContainerAssignment {ContainerID = containers.Single(c => c.CCTag == 6).CCTag, ClientID = clients.Single(c => c.ID == 3).ID}
              
            //};

            context.AddRange(clients);
            context.AddRange(Warehouse);
            context.AddRange(containers);
            context.AddRange(contacts);
           // context.AddRange(containerAssignment);

            context.SaveChanges();
        }
    }
}
