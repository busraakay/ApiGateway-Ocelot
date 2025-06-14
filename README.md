# 🛡️ ApiGateway-Ocelot

Bu proje, .NET 8 tabanlı bir mikroservis mimarisi içinde **Ocelot** kullanarak geliştirilen bir **API Gateway** çözümüdür. Servisler arası yönlendirme, merkezi erişim ve servis keşfi gibi görevleri yerine getirir.

---

## 🧰 Kullanılan Teknolojiler

- .NET 8
- Ocelot
- ASP.NET Core Web API
- RESTful mimari
- Clean Architecture

---

## 📁 Proje Yapısı

ApiGateway-Ocelot/
- **ApiGateway/**  
  Ocelot yapılandırmasını barındıran API Gateway projesi.

- **Services/**  
  Mikroservis projelerini içerir.

  - **ContactAPI/**  
    - `ContactAPI` ana Web API projesi (controllerlar burada).  
    - `ContactAPI.Infrastructure` (veri erişim, repositoryler vb.).  
    - `ContactAPI.Models` (domain modeller, DTO'lar).  
    - `ContactAPI.Services` (iş mantığı ve servisler).

  - **ResAPI/**  
    - `Reservation.API` ana Web API projesi (controllerlar burada).  
    - `Reservation.API.Infrastructure` (veri erişim katmanı).  
    - `Reservation.API.Models` (domain modeller ve DTO'lar).  
    - `Reservation.API.Services` (iş mantığı katmanı).

---

Bu yapı ile:

- API Gateway, mikroservislere gelen istekleri yönlendirir.  
- Her mikroservis, kendi içinde katmanlı mimari prensiplerine göre organize edilmiştir; bu da kodun modüler, sürdürülebilir ve test edilebilir olmasını sağlar.

---






## ⚙️ Ocelot Konfigürasyonu

`ApiGateway/ocelot.json` dosyasında istek yönlendirme kuralları tanımlanır:

```json
{
  "Routes": [
    {
      "DownstreamPathTemplate": "/api/res/{id}",
      "DownstreamScheme": "https",
      "DownstreamHostAndPorts": [
        {
          "Host": "c_res_api",
          "Port": 44370
        }
      ],

      "UpstreamPathTemplate": "/r/{id}",
      "UpstreamHttpMethod": [ "Get" ]
    },
    {
      "DownstreamPathTemplate": "/api/contact/{id}",
      "DownstreamScheme": "https",
      "DownstreamHostAndPorts": [
        {
          "Host": "c_contact_api",
          "Port": 44360
        }
      ],

      "UpstreamPathTemplate": "/c/{id}",
      "UpstreamHttpMethod": [ "Get" ]
    }
  ]  
}
````

### 🚀 Kullanım Örnekleri

| API Gateway İsteği                     | Yönlendirilen Servis Adresi                     |
|---------------------------------------|-------------------------------------------------|
| `GET https://localhost:8000/r/123`    | `GET https://c_res_api:44370/api/res/123`       |
| `GET https://localhost:8000/c/456`    | `GET https://c_contact_api:44360/api/contact/456` |

---





