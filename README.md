# 🏢 AssetTracker - Full Stack Varlık Yönetim Sistemi

Modern, ölçeklenebilir ve kullanıcı dostu bir kurumsal varlık takip sistemi. Clean Architecture ile geliştirilmiş **ASP.NET Core 9 Web API** backend ve **React 18 + Vite** ile oluşturulmuş modern bir frontend uygulaması.

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat&logo=dotnet)](https://dotnet.microsoft.com/)
[![React](https://img.shields.io/badge/React-18-61DAFB?style=flat&logo=react)](https://reactjs.org/)
[![Tailwind CSS](https://img.shields.io/badge/Tailwind-3.0-38B2AC?style=flat&logo=tailwind-css)](https://tailwindcss.com/)
[![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat&logo=microsoft-sql-server)](https://www.microsoft.com/sql-server)

---

## 📋 İçindekiler

- [Özellikler](#-özellikler)
- [Teknoloji Stack](#-teknoloji-stack)
- [Proje Yapısı](#-proje-yapısı)
- [Kurulum](#-kurulum)
- [API Dokümantasyonu](#-api-dokümantasyonu)
- [Frontend Kullanımı](#-frontend-kullanımı)
- [Ekran Görüntüleri](#-ekran-görüntüleri)
- [Mimari](#-mimari)


---

## ✨ Özellikler

### 🎯 Backend API
- ✅ **RESTful API** - Clean Architecture prensiplerine uygun
- ✅ **Entity Framework Core** - Code-first yaklaşım
- ✅ **Basic Authentication** - Güvenli API erişimi
- ✅ **Global Exception Handling** - Merkezi hata yönetimi
- ✅ **Swagger/OpenAPI** - Otomatik API dokümantasyonu
- ✅ **Repository Pattern** - Veri erişim katmanı soyutlaması
- ✅ **DTO Mapping** - Katmanlar arası veri transferi

### 🎨 Frontend
- ✅ **Modern UI/UX** - Tailwind CSS ile responsive tasarım
- ✅ **State Management** - Zustand ile merkezi state yönetimi
- ✅ **SPA Navigation** - React Router ile sayfa geçişleri
- ✅ **Real-time Filtering** - Anlık arama ve filtreleme
- ✅ **CRUD Operations** - Varlık, personel, departman yönetimi
- ✅ **Zimmet Sistemi** - Varlık atama ve geri alma
- ✅ **Protected Routes** - Kimlik doğrulama koruması

---

## 🛠 Teknoloji Stack

### Backend
| Teknoloji | Versiyon | Açıklama |
|-----------|----------|----------|
| .NET | 9.0 | Backend framework |
| C# | 13 | Programlama dili |
| Entity Framework Core | 9.x | ORM |
| SQL Server | 2019+ | Veritabanı |
| Swagger | 6.x | API dokümantasyonu |

### Frontend
| Teknoloji | Versiyon | Açıklama |
|-----------|----------|----------|
| React | 18.x | UI kütüphanesi |
| Vite | 5.x | Build tool |
| React Router | 6.x | Routing |
| Zustand | 4.x | State management |
| Axios | 1.x | HTTP client |
| Tailwind CSS | 3.x | CSS framework |

---

## 📁 Proje Yapısı

```
AssetTracker/
│
├── backend/                           # ASP.NET Core API
│   ├── AssetTracker.Api/              # HTTP katmanı
│   │   ├── Controllers/               # API endpoint'leri
│   │   ├── Middlewares/               # Custom middleware'ler
│   │   └── Program.cs                 # Uygulama giriş noktası
│   │
│   ├── AssetTracker.Application/      # İş mantığı katmanı
│   │   ├── DTO/                       # Data Transfer Objects
│   │   ├── Interfaces/                # Service ve Repository interfaceleri
│   │   └── Services/                  # Business logic
│   │
│   ├── AssetTracker.Domain/           # Domain katmanı
│   │   ├── Entities/                  # Entity'ler (Asset, Employee, vb.)
│   │   └── Enums/                     # Enum tanımları
│   │
│   └── AssetTracker.Infrastructure/   # Altyapı katmanı
│       ├── Data/                      # DbContext ve Configurations
│       ├── Repositories/              # Repository implementasyonları
│       └── Services/                  # External service'ler
│
└── frontend/                          # React Uygulaması
    ├── src/
    │   ├── components/                # React bileşenleri
    │   ├── pages/                     # Sayfa bileşenleri
    │   ├── services/                  # API servisleri
    │   ├── stores/                    # Zustand store'ları
    │   └── App.jsx                    # Ana component
    │
    ├── public/                        # Statik dosyalar
    ├── vite.config.js                 # Vite yapılandırması
    └── package.json                   # NPM bağımlılıkları
```

---

## 🚀 Kurulum

### Gereksinimler

#### Backend
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/sql-server) (LocalDB, Express veya tam sürüm)
- [Visual Studio 2022 (17.10 veya üzeri — .NET 9 desteği için)](https://visualstudio.microsoft.com/) 

#### Frontend
- [Node.js](https://nodejs.org/) 18+ veya üzeri
- npm veya yarn

---

### 📦 Adım 1: Projeyi Klonlayın

```bash
git clone https://github.com/Atreox/AssetTracker.git
cd AssetTracker
```

---

### 🔧 Adım 2: Backend Kurulumu

#### 2.1. Backend klasörüne gidin

```bash
cd asset-tracker-backend
```

#### 2.2. Connection String'i ayarlayın

`AssetTracker.Api/appsettings.json` dosyasını açın:

```json
{
  "ConnectionStrings": {
    "Default": "Server=(localdb)\\mssqllocaldb;Database=AssetTrackerDb;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

**Not**: Kendi SQL Server instance'ınıza göre güncelleyin.

#### 2.3. Migration'ları uygulayın

```bash
cd AssetTracker.Api
dotnet ef database update --project AssetTracker.Infrastructure --startup-project AssetTracker.Api
```

veya Package Manager Console'da:

```powershell
Update-Database
```

#### 2.4. Backend'i çalıştırın

```bash
dotnet run
```

✅ Backend başarıyla ayağa kalktı!  
📍 Swagger UI: `https://localhost:{PORT}/swagger`  
📍 API Base URL: `https://localhost:{PORT}/api`

**Konsol çıktısından backend'in çalıştığı portu not edin!**

---

Seed Data

Uygulama ilk çalıştırmada otomatik seed data oluşturur:

2 Department

3 Employee

4 Asset

1 Test User (admin / 123456)

---

### 🎨 Adım 3: Frontend Kurulumu

#### 3.1. Yeni bir terminal açın ve frontend klasörüne gidin

```bash
cd asset-tracker-frontend
```

#### 3.2. Bağımlılıkları yükleyin

```bash
npm install
```

veya yarn kullanıyorsanız:

```bash
yarn install
```

#### 3.3. Backend URL'ini ayarlayın (gerekirse)

`vite.config.js` dosyasında backend URL'ini kontrol edin:

```javascript
export default defineConfig({
  server: {
    proxy: {
      '/api': {
        target: 'https://localhost:5001', // Backend portunu buraya yazın
        changeOrigin: true,
        secure: false
      }
    }
  }
})
```

#### 3.4. Frontend'i çalıştırın

```bash
npm run dev
```

✅ Frontend başarıyla ayağa kalktı!  
📍 Frontend URL: `http://localhost:5173` (veya konsol çıktısındaki port)

---

### 🎉 Adım 4: Uygulamayı Kullanın

1. Tarayıcınızda `http://localhost:5173` adresine gidin
2. Giriş bilgileri:
   - **Username**: `admin`
   - **Password**: `123456`
3. Dashboard'da varlıkları yönetmeye başlayın! 🚀

---

## 📡 API Dokümantasyonu

### Base URL
```
https://localhost:{PORT}/api
```

### Authentication
Auth dışındaki endpoint'ler **Basic Authentication** gerektirir.
/Auth/login ve /Auth/register endpoint'leri AllowAnonymous'tir.


**Header:**
```
Authorization: Basic {base64(username:password)}
```

### Endpoint'ler

#### 🔐 Authentication

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| POST | `/Auth/login` | Kullanıcı girişi |
| POST | `/Auth/register` | Yeni kullanıcı kaydı |

#### 💼 Assets (Varlıklar)

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/Asset` | Tüm varlıklar |
| GET | `/Asset/{id}` | Tek varlık |
| GET | `/Asset/List` | Detaylı liste (Employee + Dept) |
| POST | `/Asset` | Yeni varlık oluştur |
| PUT | `/Asset/{id}` | Varlık güncelle |
| DELETE | `/Asset/{id}` | Varlık sil |
| PATCH | `/Asset/{id}/assign` | Varlık zimmetle |
| PATCH | `/Asset/{id}/unassign` | Zimmetten çıkar |

#### 👤 Employees (Personel)

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/Employee` | Tüm personeller |
| GET | `/Employee/{id}` | Tek personel |
| POST | `/Employee` | Yeni personel |
| PUT | `/Employee/{id}` | Personel güncelle |
| DELETE | `/Employee/{id}` | Personel sil |

#### 🏢 Departments (Departmanlar)

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/Department` | Tüm departmanlar |
| GET | `/Department/{id}` | Tek departman |
| POST | `/Department` | Yeni departman |
| PUT | `/Department/{id}` | Departman güncelle |
| DELETE | `/Department/{id}` | Departman sil |

### 📝 Örnek Request/Response

#### Yeni Varlık Oluşturma

**Request:**
```http
POST /api/Asset
Content-Type: application/json
Authorization: Basic YWRtaW46QWRtaW4xMjMh

{
  "assetName": "Dell Latitude 5520",
  "serialNumber": "DL5520-2024-001",
  "assetType": "Laptop",
  "purchaseDate": "2024-01-15"
}
```

**Response:**
```http
HTTP/1.1 201 Created
Location: /api/Asset/1
```

#### Varlık Zimmetleme

**Request:**
```http
PATCH /api/Asset/1/assign
Content-Type: application/json
Authorization: Basic YWRtaW46QWRtaW4xMjMh

{
  "employeeId": 5
}
```

**Response:**
```http
HTTP/1.1 204 No Content
```

---

## 🖥 Frontend Kullanımı

### 🔐 Giriş Sayfası
- Kullanıcı adı ve şifre ile giriş
- Hatalı giriş durumunda uyarı mesajı
- Başarılı girişte Dashboard'a yönlendirme

### 📊 Dashboard (Ana Sayfa)
**Varlık Listesi:**
- Tüm varlıkları tabloda görüntüleme
- Seri numarası, tip, satın alma tarihi bilgileri
- Zimmetli varlıklar için personel ve departman bilgisi

**Filtreleme:**
- Arama kutusu: Varlık adı, seri no, personel, departman
- Tip filtresi: Dropdown ile belirli varlık tipini seçme

**İşlemler:**
- ➕ **Yeni Varlık**: Modal ile yeni varlık ekleme
- ✏️ **Düzenle**: Mevcut varlık bilgilerini güncelleme
- 🗑️ **Sil**: Varlık silme (onay ile)
- 📌 **Zimmetle**: Boş varlığı personele atama
- ↩️ **Zimmetten Çıkar**: Zimmetli varlığı geri alma

### 👥 Yönetim Sayfası

**Departmanlar Sekmesi:**
- Departman listesi
- Yeni departman ekleme
- Departman düzenleme ve silme

**Personel Sekmesi:**
- Personel listesi (departman bilgisi ile)
- Yeni personel ekleme
- Personel düzenleme ve silme

---

## 🎬 Ekran Görüntüleri

### Login Sayfası
```
┌─────────────────────────────┐
│   🔐 AssetTracker Login    │
│                             │
│   Username: [________]      │
│   Password: [________]      │
│                             │
│        [  Giriş Yap  ]      │
└─────────────────────────────┘
```

### Dashboard
```
┌──────────────────────────────────────────────────────────┐
│ 🏠 Dashboard  |  👥 Yönetim  |  🚪 Çıkış                  │
├──────────────────────────────────────────────────────────┤
│                                                           │
│  Arama: [____________]  Tip: [Tümü ▼]  [+ Yeni Varlık]  │
│                                                           │
│  ┌────────────────────────────────────────────────────┐  │
│  │ Varlık Adı    │ Seri No  │ Tip    │ Personel  │...│  │
│  ├────────────────────────────────────────────────────┤  │
│  │ Dell Laptop   │ DL-001   │ Laptop │ Ahmet Y.  │...│  │
│  │ iPhone 14     │ IP-002   │ Phone  │ -         │...│  │
│  └────────────────────────────────────────────────────┘  │
└──────────────────────────────────────────────────────────┘
```

---

## 🏗 Mimari

### Backend - Clean Architecture

```
       API (Controllers)
           ↓
    Application (Services)
           ↓
  Infrastructure (Repositories)
           ↓
      Domain (Entities)
```

**Katman Sorumlulukları:**

- **Domain**: İş kuralları ve entity'ler (hiçbir bağımlılık yok)
- **Application**: İş mantığı, DTO'lar, interface'ler
- **Infrastructure**: Veritabanı, external service'ler
- **API**: HTTP endpoint'leri, middleware'ler, DI konfigürasyonu

### Frontend - Component Architecture

```
App
├── Router
│   ├── Login (Public)
│   └── PrivateRoute
│       ├── Dashboard
│       └── Management
│           ├── Departments
│           └── Employees
└── Services
    └── Zustand Stores
```

---

## 🗄 Veritabanı Şeması

### Entity İlişkileri

```
Departments (1) ──→ (N) Employees (1) ──→ (N) Assets
```

### Tablolar

#### Assets
```sql
CREATE TABLE Assets (
    Id INT PRIMARY KEY IDENTITY,
    AssetName NVARCHAR(60) NOT NULL,
    SerialNumber NVARCHAR(20) NOT NULL UNIQUE,
    AssetType NVARCHAR(50) NOT NULL,
    PurchaseDate DATETIME2 NOT NULL,
    EmployeeId INT NULL,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id) ON DELETE SET NULL
);
```

#### Employees
```sql
CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    DepartmentId INT NOT NULL,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
);
```

#### Departments
```sql
CREATE TABLE Departments (
    Id INT PRIMARY KEY IDENTITY,
    DeptName NVARCHAR(100) NOT NULL,
    Location NVARCHAR(50) NOT NULL,
    Description NVARCHAR(500)
);
```

#### Users
```sql
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(500) NOT NULL,
);
```

## 🙏 Teşekkürler

