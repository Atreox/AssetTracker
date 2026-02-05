import api from './api';

export const departmentService = {
  getAll: async () => {
    const response = await api.get('/department');
    return response.data;
  },

  getById: async (id) => {
    const response = await api.get(`/department/${id}`);
    return response.data;
  },

  create: async (deptData) => {
    const response = await api.post('/department', deptData);
    return response.data;
  },

  update: async (id, deptData) => {
    const response = await api.put(`/department/${id}`, deptData);
    return response.data;
  },

  delete: async (id) => {
    const response = await api.delete(`/department/${id}`);
    return response.data;
  },
};
