import { create } from 'zustand';

const useAssetStore = create((set) => ({
  assets: [],
  loading: false,
  error: null,
  searchQuery: '',
  filterType: 'all',

  setAssets: (assets) => set({ assets }),
  
  setLoading: (loading) => set({ loading }),
  
  setError: (error) => set({ error }),
  
  setSearchQuery: (query) => set({ searchQuery: query }),
  
  setFilterType: (type) => set({ filterType: type }),

  addAsset: (asset) => set((state) => ({
    assets: [...state.assets, asset]
  })),

  updateAsset: (id, updatedAsset) => set((state) => ({
    assets: state.assets.map((asset) =>
      asset.id === id ? { ...asset, ...updatedAsset } : asset
    )
  })),

  deleteAsset: (id) => set((state) => ({
    assets: state.assets.filter((asset) => asset.id !== id)
  })),

  getFilteredAssets: (state) => {
    let filtered = state.assets;

    if (state.searchQuery) {
      const query = state.searchQuery.toLowerCase();
      filtered = filtered.filter(
        (asset) =>
          asset.assetName?.toLowerCase().includes(query) ||
          asset.serialNumber?.toLowerCase().includes(query) ||
          asset.employeeName?.toLowerCase().includes(query) ||
          asset.departmentName?.toLowerCase().includes(query)
      );
    }

    if (state.filterType !== 'all') {
      filtered = filtered.filter((asset) => asset.assetType === state.filterType);
    }

    return filtered;
  },
}));

export default useAssetStore;
