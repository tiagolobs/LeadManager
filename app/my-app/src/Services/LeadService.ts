import axios from 'axios';
import { LeadStatus } from '../Leads/Enums';
import { Lead } from '../Leads/Types';

const baseUrl = 'https://localhost:7071';



 const getLeads = async (status: LeadStatus): Promise<Lead[]> => {
    const response = await axios.get<Lead[]>(`${baseUrl}/Leads?status=${status}`);
    return response.data;
 
};

 const updateLead = async (leadId: number, accepted: boolean) => {
  try {
    await axios.patch(`${baseUrl}/Leads/${leadId}`, {
      accepted,
    });
  } catch (error) {
    console.error(error);
  }
};

const leadService = {
    getLeads,
    updateLead,
};

export default leadService;
