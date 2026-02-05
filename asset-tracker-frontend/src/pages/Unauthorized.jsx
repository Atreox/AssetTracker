import React from 'react';
import { Link } from 'react-router-dom';
import useAuthStore from '../stores/authStore';

const Unauthorized = () => {
  const logout = useAuthStore((state) => state.logout);

  const handleLogout = () => {
    logout();
    window.location.href = '/login';
  };

  return (
    <div className="min-h-screen bg-gradient-to-br from-orange-500 to-red-600 flex items-center justify-center px-4">
      <div className="max-w-2xl w-full text-center">
        {/* 403 Illustration */}
        <div className="mb-8">
          <h1 className="text-9xl font-bold text-white opacity-20">403</h1>
        </div>

        {/* Lock Icon */}
        <div className="mb-6">
          <svg
            className="mx-auto h-32 w-32 text-white opacity-90"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path
              strokeLinecap="round"
              strokeLinejoin="round"
              strokeWidth={1}
              d="M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z"
            />
          </svg>
        </div>

        {/* Message */}
        <h2 className="text-4xl font-bold text-white mb-4">
          Erişim Engellendi
        </h2>
        <p className="text-xl text-white opacity-80 mb-8">
          Bu sayfaya erişim yetkiniz bulunmamaktadır. Lütfen giriş yapın veya yetkili bir hesap kullanın.
        </p>

        {/* Buttons */}
        <div className="flex flex-col sm:flex-row gap-4 justify-center">
          <Link
            to="/dashboard"
            className="bg-white text-orange-600 px-8 py-3 rounded-lg font-semibold hover:bg-gray-100 transition shadow-lg"
          >
            Ana Sayfaya Dön
          </Link>
          <button
            onClick={handleLogout}
            className="bg-transparent border-2 border-white text-white px-8 py-3 rounded-lg font-semibold hover:bg-white hover:text-orange-600 transition"
          >
            Çıkış Yap
          </button>
        </div>
      </div>
    </div>
  );
};

export default Unauthorized;
