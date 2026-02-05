import React from 'react';
import { Link } from 'react-router-dom';

const NotFound = () => {
  return (
    <div className="min-h-screen bg-gradient-to-br from-blue-500 to-purple-600 flex items-center justify-center px-4">
      <div className="max-w-2xl w-full text-center">
        {/* 404 İllustration */}
        <div className="mb-8">
          <h1 className="text-9xl font-bold text-white opacity-20">404</h1>
        </div>

        {/* Icon */}
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
              d="M9.172 16.172a4 4 0 015.656 0M9 10h.01M15 10h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
            />
          </svg>
        </div>

        {/* Message */}
        <h2 className="text-4xl font-bold text-white mb-4">
          Oops! Sayfa Bulunamadı
        </h2>
        <p className="text-xl text-white opacity-80 mb-8">
          Aradığınız sayfa mevcut değil veya taşınmış olabilir.
        </p>

        {/* Buttons */}
        <div className="flex flex-col sm:flex-row gap-4 justify-center">
          <Link
            to="/dashboard"
            className="bg-white text-blue-600 px-8 py-3 rounded-lg font-semibold hover:bg-gray-100 transition shadow-lg"
          >
            Ana Sayfaya Dön
          </Link>
          <button
            onClick={() => window.history.back()}
            className="bg-transparent border-2 border-white text-white px-8 py-3 rounded-lg font-semibold hover:bg-white hover:text-blue-600 transition"
          >
            Geri Git
          </button>
        </div>

        {/* Additional Info */}
        <div className="mt-12 text-white opacity-60 text-sm">
          <p>Yardıma mı ihtiyacınız var?</p>
          <p className="mt-2">
            <Link to="/dashboard" className="underline hover:opacity-100">
              Dashboard
            </Link>
            {' • '}
            <Link to="/management" className="underline hover:opacity-100">
              Yönetim
            </Link>
          </p>
        </div>
      </div>
    </div>
  );
};

export default NotFound;
