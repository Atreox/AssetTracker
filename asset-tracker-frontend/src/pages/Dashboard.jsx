import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import useAuthStore from '../stores/authStore';
import useAssetStore from '../stores/assetStore';
import { assetService } from '../services/assetService';
import { employeeService } from '../services/employeeService';
import Navbar from '../components/Navbar';
import AssetList from '../components/AssetList';
import AssetModal from '../components/AssetModal';
import AssignModal from '../components/AssignModal';

const Dashboard = () => {
  const navigate = useNavigate();
  const isAuthenticated = useAuthStore((state) => state.isAuthenticated);
  const { assets, setAssets, setLoading, setError } = useAssetStore();
  
  const [showAssetModal, setShowAssetModal] = useState(false);
  const [showAssignModal, setShowAssignModal] = useState(false);
  const [selectedAsset, setSelectedAsset] = useState(null);
  const [employees, setEmployees] = useState([]);

  useEffect(() => {
    if (!isAuthenticated) {
      navigate('/login');
      return;
    }
    loadData();
  }, [isAuthenticated, navigate]);

  const loadData = async () => {
    setLoading(true);
    try {
      const [assetsData, employeesData] = await Promise.all([
        assetService.getList(),
        employeeService.getAll(),
      ]);
      setAssets(assetsData);
      setEmployees(employeesData);
    } catch (error) {
      setError(error.message);
      console.error('Error loading data:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleEdit = (asset) => {
    setSelectedAsset(asset);
    setShowAssetModal(true);
  };

  const handleDelete = async (id) => {
    if (window.confirm('Bu varlığı silmek istediğinizden emin misiniz?')) {
      try {
        await assetService.delete(id);
        await loadData();
      } catch (error) {
        alert('Varlık silinemedi: ' + error.message);
      }
    }
  };

  const handleAssign = (asset) => {
    setSelectedAsset(asset);
    setShowAssignModal(true);
  };

  const handleUnassign = async (id) => {
    if (window.confirm('Bu varlığı zimmetten çıkarmak istediğinizden emin misiniz?')) {
      try {
        await assetService.unassign(id);
        await loadData();
      } catch (error) {
        alert('İşlem başarısız: ' + error.message);
      }
    }
  };

  return (
    <div className="min-h-screen bg-gray-50">
      <Navbar />
      
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        <div className="flex justify-between items-center mb-6">
          <h1 className="text-3xl font-bold text-gray-900">Varlık Yönetimi</h1>
          <button
            onClick={() => {
              setSelectedAsset(null);
              setShowAssetModal(true);
            }}
            className="bg-blue-600 text-white px-6 py-2 rounded-lg hover:bg-blue-700 transition flex items-center gap-2"
          >
            <span className="text-xl">+</span>
            Yeni Varlık
          </button>
        </div>

        <AssetList
          assets={assets}
          onEdit={handleEdit}
          onDelete={handleDelete}
          onAssign={handleAssign}
          onUnassign={handleUnassign}
        />
      </div>

      {showAssetModal && (
        <AssetModal
          asset={selectedAsset}
          onClose={() => {
            setShowAssetModal(false);
            setSelectedAsset(null);
          }}
          onSuccess={loadData}
        />
      )}

      {showAssignModal && (
        <AssignModal
          asset={selectedAsset}
          employees={employees}
          onClose={() => {
            setShowAssignModal(false);
            setSelectedAsset(null);
          }}
          onSuccess={loadData}
        />
      )}
    </div>
  );
};

export default Dashboard;
