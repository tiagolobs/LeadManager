using Application.Leads.GetLeads;
using Domain.Leads;
using MediatR;

namespace Application.Leads.Querys.GetLeads
{
    public class GetLeadsQueryHandler : IRequestHandler<GetLeadsQuery, List<LeadDto>>
    {
        private readonly ILeadRepository _leadRepository;

        public GetLeadsQueryHandler(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<List<LeadDto>> Handle(GetLeadsQuery request, CancellationToken cancellationToken)
        {
            var leads = await _leadRepository.GetAllAsync(request.Status);
            return leads.Select(x => x.ToDto()).ToList();
        }
    }
}