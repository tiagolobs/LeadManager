using Application.Leads.Querys.GetLeads;
using Domain.Leads;
using Domain.Leads.Contacts;
using Domain.ValueObjects;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Leads.Querys
{
    public class GetLeadsQueryTest
    {
        private readonly Mock<ILeadRepository> _leadRepositoryMock;
        private readonly GetLeadsQueryHandler _handler;

        public GetLeadsQueryTest()
        {
            _leadRepositoryMock = new Mock<ILeadRepository>();

            _handler = new GetLeadsQueryHandler(_leadRepositoryMock.Object);
        }

        [Fact]
        public async Task UpdateLead_AcceptedPriceLessOrEqualPriceLimit_Success()
        {
            // Arrange
            var query = new GetLeadsQuery(LeadStatus.Invited);

            _leadRepositoryMock.Setup(x => x.GetAllAsync(LeadStatus.Invited)).ReturnsAsync(GetLeads());

            //Act
            var response = await _handler.Handle(query, default);

            //Assert
            Assert.Equal(2, response.Count);
            Assert.Equal(1, response[0].Id);
            Assert.Equal("Bill", response[0].ContactFirstName);
            Assert.Equal("Bill Clinton", response[0].ContactFullName);
            Assert.Equal("31998850341", response[0].ContactPhoneNumber);
            Assert.Equal(2, response[1].Id);
        }

        private static List<Lead> GetLeads()
        {
            var contact1 = new Contact
            {
                Name = new Name("Bill", "Clinton"),
                Email = new Email("bill.clinton@gmail.com"),
                Id = 1,
                PhoneNumber = new PhoneNumber("31", "998850341"),
            };

            var lead1 = new Lead
            (
                contact: contact1,
                date: new DateTime(2023, 1, 1),
                suburb: "Yanderra 2547",
                description: "Need to paint 2 windows",
                price: 500M,
                jobCategory: JobCategory.Painters
            );
            lead1.Id = 1;

            var contact2 = new Contact
            {
                Name = new Name("Craig", "Sanderson"),
                Email = new Email("craigsands@gmail.com"),
                Id = 2,
                PhoneNumber = new PhoneNumber("32", "978850351"),
            };

            var lead2 = new Lead
            (
                contact: contact2,
                date: new DateTime(2023, 1, 1),
                suburb: "Wolooware 2230",
                description: "Internal wall",
                price: 601.54M,
                jobCategory: JobCategory.InteriorPainters
            );
            lead2.Id = 2;
            return new List<Lead>
            {
                lead1,lead2
            };
        }
    }
}