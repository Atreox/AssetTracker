import React from 'react';
import { Link, useSearchParams } from 'react-router-dom';

const Oops = () => {
  const [searchParams] = useSearchParams();
  const status = searchParams.get('status');
  const message = searchParams.get('message');

  return (
    <div className="min-h-screen bg-gradient-to-br from-blue-400 via-cyan-500 to-blue-600 flex items-center justify-center px-4">
      <div className="max-w-2xl w-full text-center">
        {/* 500 Illustration */}
        <div className="mb-8">
          <h1 className="text-9xl font-bold text-white opacity-20">
            {status || '500'}
          </h1>
        </div>

        {/* Server Error Icon */}
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
              d="M5 12h14M5 12a2 2 0 01-2-2V6a2 2 0 012-2h14a2 2 0 012 2v4a2 2 0 01-2 2M5 12a2 2 0 00-2 2v4a2 2 0 002 2h14a2 2 0 002-2v-4a2 2 0 00-2-2m-2-4h.01M17 16h.01"
            />
          </svg>
        </div>

        {/* Message */}
        <h2 className="text-4xl font-bold text-white mb-4">
          Sunucuya Ulaşılamadı
        </h2>
        <p className="text-xl text-white opacity-80 mb-12">
          {message || 'Sunucu şu anda yanıt vermiyor veya beklenmeyen bir hata oluştu. Lütfen daha sonra tekrar deneyin.'}
        </p>

        {/* Ana Sayfa Butonu */}
        <div className="flex justify-center">
          <Link
            to="/dashboard"
            className="bg-white text-blue-600 px-12 py-4 rounded-lg text-lg font-bold hover:bg-gray-100 hover:shadow-2xl transition-all duration-300 transform hover:scale-105 inline-block shadow-xl"
          >
            🏠 Ana Sayfa
          </Link>
        </div>

        {/* Technical Info (Development Only) */}
        {process.env.NODE_ENV === 'development' && (status || message) && (
          <div className="mt-12 bg-white bg-opacity-20 rounded-lg p-4">
            <p className="text-sm text-white font-mono">
              {status && <span>Status: {status}</span>}
              {status && message && <span> | </span>}
              {message && <span>{message}</span>}
            </p>
          </div>
        )}

        {/* Help Text */}
        <div className="mt-12 text-white opacity-60 text-sm">
          <p>Sorun devam ederse lütfen sistem yöneticisi ile iletişime geçin.</p>
        </div>
      </div>
    </div>
  );
};

export default Oops;