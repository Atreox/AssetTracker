import axios from 'axios';
import useAuthStore from '../stores/authStore';

const api = axios.create({
  baseURL: '/api',
  headers: {
    'Content-Type': 'application/json',
  },
});

// Request interceptor - Her istekte Authorization header 
api.interceptors.request.use(
  (config) => {
    const credentials = useAuthStore.getState().credentials;
    if (credentials) {
      config.headers.Authorization = `Basic ${credentials}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

// Response interceptor - Hata yönetimi
api.interceptors.response.use(
  (response) => response,
  (error) => {
    const status = error.response?.status;
    const url = error.config?.url || "";

    // Backend kapalı / network error
    if (!status) {
      window.location.href = "/oops";
      return Promise.reject(error);
    }

    // 500+ server errors
    if (status >= 500) {
      window.location.href = `/oops?status=${status}`;
      return Promise.reject(error);
    }

    // 403 forbidden
    if (status === 403) {
      window.location.href = "/unauthorized";
      return Promise.reject(error);
    }

    // 401 unauthorized (login hariç)
    if (status === 401) {
      const isLoginRequest =
        url.includes("/auth/login") || url.includes("/login");

      if (!isLoginRequest) {
        useAuthStore.getState().logout();
        window.location.href = "/login";
      }
      return Promise.reject(error);
    }

    return Promise.reject(error);
  }
);

export default api;
