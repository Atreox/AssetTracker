import { create } from 'zustand';

const useManagementStore = create((set) => ({
  departments: [],
  employees: [],
  loading: false,
  error: null,

  setDepartments: (departments) => set({ departments }),
  
  setEmployees: (employees) => set({ employees }),
  
  setLoading: (loading) => set({ loading }),
  
  setError: (error) => set({ error }),

  addDepartment: (department) => set((state) => ({
    departments: [...state.departments, department]
  })),

  updateDepartment: (id, updatedDept) => set((state) => ({
    departments: state.departments.map((dept) =>
      dept.id === id ? { ...dept, ...updatedDept } : dept
    )
  })),

  deleteDepartment: (id) => set((state) => ({
    departments: state.departments.filter((dept) => dept.id !== id)
  })),

  addEmployee: (employee) => set((state) => ({
    employees: [...state.employees, employee]
  })),

  updateEmployee: (id, updatedEmp) => set((state) => ({
    employees: state.employees.map((emp) =>
      emp.id === id ? { ...emp, ...updatedEmp } : emp
    )
  })),

  deleteEmployee: (id) => set((state) => ({
    employees: state.employees.filter((emp) => emp.id !== id)
  })),
}));

export default useManagementStore;
