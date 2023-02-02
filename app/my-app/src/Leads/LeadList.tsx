import React, { useEffect, useState } from "react";
import leadService from "../Services/LeadService";
import Card from "./Card/Card";
import { Lead } from "./Types";

const LeadList: React.FC = () => {
  const [leads, setLeads] = useState<Lead[]>([]);

  const fetchLeads = async () => {
    const leads = await leadService.getLeads(0);
    setLeads(leads);
  };
  useEffect(() => {
    fetchLeads();
  }, []);

  const handleUpdate = async (id: number, accepted: boolean) => {
    await leadService.updateLead(id, accepted);
    fetchLeads();
  };

  return (
    <>
      {leads.map((lead) => (
        <Card
          key={lead.id}
          name={lead.contactFirstName}
          date={lead.date}
          location={lead.suburb}
          jobCategory={lead.category}
          leadId={lead.id}
          description={lead.description}
          price={lead.price}
          handleUpdate={handleUpdate}
        />
      ))}
    </>
  );
};
export default LeadList;
