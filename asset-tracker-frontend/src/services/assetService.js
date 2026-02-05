import api from './api';

export const assetService = {
  getAll: async () => {
    const response = await api.get('/asset');
    return response.data;
  },

  getList: async () => {
    const response = await api.get('/asset/list');
    return response.data;
  },

  getById: async (id) => {
    const response = await api.get(`/asset/${id}`);
    return response.data;
  },

  create: async (assetData) => {
    const response = await api.post('/asset', assetData);
    return response.data;
  },

  update: async (id, assetData) => {
    const response = await api.put(`/asset/${id}`, assetData);
    return response.data;
  },

  delete: async (id) => {
    const response = await api.delete(`/asset/${id}`);
    return response.data;
  },

  assign: async (id, employeeId) => {
    const response = await api.patch(`/asset/${id}/assign`, { employeeId });
    return response.data;
  },

  unassign: async (id) => {
    const response = await api.patch(`/asset/${id}/unassign`);
    return response.data;
  },
};
