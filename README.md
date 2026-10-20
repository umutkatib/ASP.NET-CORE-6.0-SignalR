# [ASP.NET CORE 6.0 QR Kodlu Sipariş Yönetimi]

ASP.NET Core 6.0 API ve SignalR kullanılarak geliştirilmiş, gerçek zamanlı (real-time) çalışan bir restoran sipariş yönetim uygulaması. Proje; admin paneli, vitrin (kullanıcı) arayüzü ve sipariş/sepet modüllerini içerir.


## 📌 Özellikler

- **Gerçek zamanlı özellikler (SignalR):** anlık istatistikler, bildirimler, mesajlaşma ve sepet güncellemeleri
- **Admin paneli:** kategori, ürün, hakkımızda, rezervasyon, iletişim, indirim, özellik, sosyal medya ve referans yönetimi (CRUD)
- **Vitrin arayüzü:** menü, rezervasyon ve iletişim sayfaları
- **Sipariş ve sepet yönetimi**, kasa (Money Case) takibi
- **Rezervasyon e-postaları:** kullanıcılara mail gönderimi
- **Kimlik doğrulama ve yetkilendirme:** ASP.NET Core Identity, Admin / User rolleri
- **Özel hata sayfaları:** 404, 403 (Access Denied) ve 500

## 🛠️ Kullanılan Teknolojiler

| Backend | ASP.NET Core 6.0 Web API, Swagger |
| Gerçek zamanlı iletişim | SignalR |
| Veri erişimi | Entity Framework Core, LINQ |
| Veritabanı | MS SQL Server |
| Mimari | N-Tier Architecture, DTO, AutoMapper |
| Kimlik yönetimi | ASP.NET Core Identity |
| Frontend | HTML, CSS, Bootstrap, JavaScript, AJAX |

## 🏗️ Mimari

Bu proje katmanlı mimariyle geliştirilmiştir:

SignalR/
├── SignalR.EntityLayer/       # Entity sınıfları
├── SignalR.DataAccessLayer/   # DbContext, repository'ler
├── SignalR.BusinessLayer/     # Servis arayüzleri ve Manager sınıfları
├── SignalR.DtoLayer/          # DTO'lar
├── SignalRApi/                # Web API + SignalR Hub
└── SignalRWebUI/              # MVC arayüzü (admin + vitrin)
