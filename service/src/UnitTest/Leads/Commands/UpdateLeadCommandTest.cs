using Application.Leads.Commands.UpdateLead;
using Application.Services;
using Domain.Common;
using Domain.Leads;
using Domain.Leads.Contacts;
using Domain.ValueObjects;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Leads.Commands
{
    public class UpdateLeadCommandTest
    {
        private readonly Mock<ILeadRepository> _leadRepositoryMock;
        private readonly Mock<IEmailService> _emailServiceMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly UpdateLeadCommandHandler _handler;

        public UpdateLeadCommandTest()
        {
            _leadRepositoryMock = new Mock<ILeadRepository>();
            _emailServiceMock = new Mock<IEmailService>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new UpdateLeadCommandHandler(_leadRepositoryMock.Object, _unitOfWorkMock.Object, _emailServiceMock.Object);
        }

        [Fact]
        public async Task UpdateLead_AcceptedPriceLessOrEqualPriceLimit_Success()
        {
            // Arrange
            var command = new UpdateLeadCommand(1, new UpdateLeadRequest()
            {
                Accepted = true
            });

            _leadRepositoryMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(GetLead());

            //Act
            var response = await _handler.Handle(command, default);

            //Assert
            Assert.Equal(LeadStatus.Accepted, response.LeadStatus);
            Assert.Equal(500M, response.Price);

            _unitOfWorkMock.Verify(x => x.SaveAsync());
            _emailServiceMock.Verify(x => x.Send("vendas@test.com", "Lead Accepted", $"Hello Bill! Your lead has just been accepted "));
        }

        [Fact]
        public async Task UpdateLead_AcceptedPriceOverPriceLimit_Success()
        {
            // Arrange
            var leadEntity = GetLead();
            leadEntity.Price = 501M;

            var command = new UpdateLeadCommand(1, new UpdateLeadRequest()
            {
                Accepted = true
            });

            _leadRepositoryMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(leadEntity);

            //Act
            var response = await _handler.Handle(command, default);

            //Assert
            Assert.Equal(LeadStatus.Accepted, response.LeadStatus);
            Assert.Equal(450.9M, response.Price);

            _unitOfWorkMock.Verify(x => x.SaveAsync());
            _emailServiceMock.Verify(x => x.Send("vendas@test.com", "Lead Accepted", $"Hello Bill! Your lead has just been accepted "));
        }

        [Fact]
        public async Task UpdateLead_Declined_Success()
        {
            // Arrange

            var command = new UpdateLeadCommand(1, new UpdateLeadRequest()
            {
                Accepted = false
            });

            _leadRepositoryMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(GetLead());

            //Act
            var response = await _handler.Handle(command, default);

            //Assert
            Assert.Equal(LeadStatus.Declined, response.LeadStatus);
            Assert.Equal(500M, response.Price);

            _unitOfWorkMock.Verify(x => x.SaveAsync());
            _emailServiceMock.Verify(x => x.Send(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        private static Lead GetLead()
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
            return lead1;
        }
    }
}