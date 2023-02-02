import React, { useEffect, useState } from "react";
import leadService from "../Services/LeadService";
import CardAccepted from "./Card/CardAccepted";
import { Lead } from "./Types";

const LeadAcceptedList: React.FC = () => {
  const [leads, setLeads] = useState<Lead[]>([]);

  const fetchLeads = async () => {
    const leads = await leadService.getLeads(1);
    setLeads(leads);
  };
  useEffect(() => {
    fetchLeads();
  }, []);

  return (
    <>
      {leads.map((lead) => (
        <CardAccepted
          key={lead.id}
          name={lead.contactFullName}
          date={lead.date}
          location={lead.suburb}
          jobCategory={lead.category}
          leadId={lead.id}
          description={lead.description}
          price={lead.price}
          email={lead.contactEmail}
          phoneNumber={lead.contactPhoneNumber}
        />
      ))}
    </>
  );
};
export default LeadAcceptedList;
