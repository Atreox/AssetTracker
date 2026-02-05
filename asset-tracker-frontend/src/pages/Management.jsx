import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import useAuthStore from '../stores/authStore';
import useManagementStore from '../stores/managementStore';
import { departmentService } from '../services/departmentService';
import { employeeService } from '../services/employeeService';
import { userService } from '../services/userService';
import Navbar from '../components/Navbar';
import DepartmentList from '../components/DepartmentList';
import EmployeeList from '../components/EmployeeList';
import UserList from '../components/UserList';
import DepartmentModal from '../components/DepartmentModal';
import EmployeeModal from '../components/EmployeeModal';
import UserModal from '../components/UserModal';

const Management = () => {
  const navigate = useNavigate();
  const isAuthenticated = useAuthStore((state) => state.isAuthenticated);
  const { departments, employees, setDepartments, setEmployees, setLoading } = useManagementStore();
  
  const [activeTab, setActiveTab] = useState('departments');
  const [showDeptModal, setShowDeptModal] = useState(false);
  const [showEmpModal, setShowEmpModal] = useState(false);
  const [showUserModal, setShowUserModal] = useState(false);
  const [selectedDepartment, setSelectedDepartment] = useState(null);
  const [selectedEmployee, setSelectedEmployee] = useState(null);
  const [selectedUser, setSelectedUser] = useState(null);
  const [users, setUsers] = useState([]);

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
      const [deptsData, empsData, usersData] = await Promise.all([
        departmentService.getAll(),
        employeeService.getAll(),
        userService.getAll(),
      ]);
      
      setDepartments(deptsData);
      setEmployees(empsData);
      setUsers(usersData);
    } catch (error) {
      console.error('Error loading data:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleDeleteDept = async (id) => {
    if (window.confirm('Bu departmanı silmek istediğinizden emin misiniz? İlişkili çalışanlar da silinecektir.')) {
      try {
        await departmentService.delete(id);
        await loadData();
      } catch (error) {
        alert('Departman silinemedi: ' + error.message);
      }
    }
  };

  const handleDeleteEmp = async (id) => {
    if (window.confirm('Bu çalışanı silmek istediğinizden emin misiniz?')) {
      try {
        await employeeService.delete(id);
        await loadData();
      } catch (error) {
        alert('Çalışan silinemedi: ' + error.message);
      }
    }
  };

  const handleDeleteUser = async (id) => {
    if (window.confirm('Bu kullanıcıyı silmek istediğinizden emin misiniz?')) {
      try {
        await userService.delete(id);
        await loadData();
      } catch (error) {
        alert('Kullanıcı silinemedi: ' + error.message);
      }
    }
  };

  return (
    <div className="min-h-screen bg-gray-50">
      <Navbar />
      
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        <h1 className="text-3xl font-bold text-gray-900 mb-6">Yönetim Paneli</h1>

        <div className="bg-white rounded-lg shadow mb-6">
          <div className="border-b border-gray-200">
            <nav className="flex -mb-px">
              <button
                onClick={() => setActiveTab('departments')}
                className={`py-4 px-6 text-sm font-medium border-b-2 transition ${
                  activeTab === 'departments'
                    ? 'border-blue-500 text-blue-600'
                    : 'border-transparent text-gray-500 hover:text-gray-700 hover:border-gray-300'
                }`}
              >
                Departmanlar
              </button>
              <button
                onClick={() => setActiveTab('employees')}
                className={`py-4 px-6 text-sm font-medium border-b-2 transition ${
                  activeTab === 'employees'
                    ? 'border-blue-500 text-blue-600'
                    : 'border-transparent text-gray-500 hover:text-gray-700 hover:border-gray-300'
                }`}
              >
                Personel
              </button>
              <button
                onClick={() => setActiveTab('users')}
                className={`py-4 px-6 text-sm font-medium border-b-2 transition ${
                  activeTab === 'users'
                    ? 'border-blue-500 text-blue-600'
                    : 'border-transparent text-gray-500 hover:text-gray-700 hover:border-gray-300'
                }`}
              >
                Kullanıcılar
              </button>
            </nav>
          </div>

          <div className="p-6">
            {activeTab === 'departments' && (
              <>
                <div className="flex justify-end mb-4">
                  <button
                    onClick={() => {
                      setSelectedDepartment(null);
                      setShowDeptModal(true);
                    }}
                    className="bg-blue-600 text-white px-6 py-2 rounded-lg hover:bg-blue-700 transition flex items-center gap-2"
                  >
                    <span className="text-xl">+</span>
                    Yeni Departman
                  </button>
                </div>
                <DepartmentList
                  departments={departments}
                  onEdit={(dept) => {
                    setSelectedDepartment(dept);
                    setShowDeptModal(true);
                  }}
                  onDelete={handleDeleteDept}
                />
              </>
            )}

            {activeTab === 'employees' && (
              <>
                <div className="flex justify-end mb-4">
                  <button
                    onClick={() => {
                      setSelectedEmployee(null);
                      setShowEmpModal(true);
                    }}
                    className="bg-blue-600 text-white px-6 py-2 rounded-lg hover:bg-blue-700 transition flex items-center gap-2"
                  >
                    <span className="text-xl">+</span>
                    Yeni Personel
                  </button>
                </div>
                <EmployeeList
                  employees={employees}
                  departments={departments}
                  onEdit={(emp) => {
                    setSelectedEmployee(emp);
                    setShowEmpModal(true);
                  }}
                  onDelete={handleDeleteEmp}
                />
              </>
            )}

            {activeTab === 'users' && (
              <>
                <div className="flex justify-end mb-4">
                  <button
                    onClick={() => {
                      setSelectedUser(null);
                      setShowUserModal(true);
                    }}
                    className="bg-blue-600 text-white px-6 py-2 rounded-lg hover:bg-blue-700 transition flex items-center gap-2"
                  >
                    <span className="text-xl">+</span>
                    Yeni Kullanıcı
                  </button>
                </div>
                <UserList
                  users={users}
                  onEdit={(user) => {
                    setSelectedUser(user);
                    setShowUserModal(true);
                  }}
                  onDelete={handleDeleteUser}
                />
              </>
            )}
          </div>
        </div>
      </div>

      {showDeptModal && (
        <DepartmentModal
          department={selectedDepartment}
          onClose={() => {
            setShowDeptModal(false);
            setSelectedDepartment(null);
          }}
          onSuccess={loadData}
        />
      )}

      {showEmpModal && (
        <EmployeeModal
          employee={selectedEmployee}
          departments={departments}
          onClose={() => {
            setShowEmpModal(false);
            setSelectedEmployee(null);
          }}
          onSuccess={loadData}
        />
      )}

      {showUserModal && (
        <UserModal
          user={selectedUser}
          onClose={() => {
            setShowUserModal(false);
            setSelectedUser(null);
          }}
          onSuccess={loadData}
        />
      )}
    </div>
  );
};

export default Management;
