using Application.Leads.GetLeads;
using Domain.Leads;
using MediatR;

namespace Application.Leads.Querys.GetLeads
{
    public class GetLeadsQuery : IRequest<List<LeadDto>>
    {
        public GetLeadsQuery(LeadStatus? status)
        {
            Status = status;
        }

        public LeadStatus? Status { get; }
    }
}