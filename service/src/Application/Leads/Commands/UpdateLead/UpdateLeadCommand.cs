using Application.Leads.GetLeads;
using MediatR;

namespace Application.Leads.Commands.UpdateLead
{
    public class UpdateLeadCommand : IRequest<LeadDto>
    {
        public UpdateLeadCommand(int id, UpdateLeadRequest request)
        {
            Id = id;
            Accepted = request.Accepted;
        }

        public bool Accepted { get; }

        public int Id { get; }
    }
}