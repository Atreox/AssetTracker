import api from './api';

export const employeeService = {
  getAll: async () => {
    const response = await api.get('/employee');
    return response.data;
  },

  getById: async (id) => {
    const response = await api.get(`/employee/${id}`);
    return response.data;
  },

  create: async (empData) => {
    const response = await api.post('/employee', empData);
    return response.data;
  },

  update: async (id, empData) => {
    const response = await api.put(`/employee/${id}`, empData);
    return response.data;
  },

  delete: async (id) => {
    const response = await api.delete(`/employee/${id}`);
    return response.data;
  },
};
