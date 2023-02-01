using Application.Leads.GetLeads;
using Application.Services;
using Domain.Common;
using Domain.Leads;
using MediatR;

namespace Application.Leads.Commands.UpdateLead
{
    public class UpdateLeadCommandHandler : IRequestHandler<UpdateLeadCommand, LeadDto>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;

        public UpdateLeadCommandHandler(ILeadRepository leadRepository, IUnitOfWork unitOfWork, IEmailService emailService)
        {
            _leadRepository = leadRepository;
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }

        public async Task<LeadDto> Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _leadRepository.GetByIdAsync(request.Id);
            if (lead == null) throw new ArgumentException("Id não existe");
            lead.LeadAccepted += LeadAccepted;

            lead.UpdateInitialStatus(request.Accepted);

            await _unitOfWork.SaveAsync();
            return lead.ToDto();
        }

        private void LeadAccepted(object sender, LeadAcceptedEventArgs e)
        {
            _emailService.Send("vendas@test.com", "Lead Accepted", $"Hello {e.Lead.Contact.Name.FirstName}! Your lead has just been accepted ");
        }
    }
}