import api from './api';

export const authService = {
  login: async (username, password) => {
    try {
      const credentials = btoa(`${username}:${password}`);
      const response = await api.post('/auth/login', {
        username,
        password
      }, {
        headers: {
          Authorization: `Basic ${credentials}`
        }
      });
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  register: async (userData) => {
    const response = await api.post('/auth/register', userData);
    return response.data;
  },

  changePassword: async (id, passwordData) => {
    const response = await api.put(`/auth/${id}/password`, passwordData);
    return response.data;
  },
};
