import { create } from 'zustand';
import { persist } from 'zustand/middleware';

const useAuthStore = create(
  persist(
    (set) => ({
      user: null,
      credentials: null,
      isAuthenticated: false,

      login: (username, password) => {
        const credentials = btoa(`${username}:${password}`);
        set({
          user: { username },
          credentials,
          isAuthenticated: true,
        });
      },

      logout: () => {
        set({
          user: null,
          credentials: null,
          isAuthenticated: false,
        });
      },

      getAuthHeader: (state) => {
        if (state.credentials) {
          return `Basic ${state.credentials}`;
        }
        return null;
      },
    }),
    {
      name: 'auth-storage',
    }
  )
);

export default useAuthStore;
