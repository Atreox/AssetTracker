import api from './api';

export const userService = {
  getAll: async () => {
    const response = await api.get('/user');
    return response.data;
  },

  getById: async (id) => {
    const response = await api.get(`/user/${id}`);
    return response.data;
  },

  // Kullanıcı oluşturma için register endpoint'ini kullan
  // create: async (userData) => {
  //   const response = await api.post('/auth/register', userData);
  //   return response.data;
  // },

  update: async (id, userData) => {
    const response = await api.put(`/user/${id}`, userData);
    return response.data;
  },

  // Not: UserController'da Delete yorum satırı ise, aktif edin
  delete: async (id) => {
    const response = await api.delete(`/user/${id}`);
    return response.data;
  },
};
