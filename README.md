# HouseSaller.API

HouseSaller.API, kullanıcıların sahip oldukları evleri daha rahat bir şekilde satabilecekleri bir internet uygulamasıdır.

## Amaç

Bu proje, kullanıcıların evlerini kolayca satışa çıkarabilmelerini sağlamayı hedefler. HouseSaller.API, kullanıcıların ev bilgilerini girmelerine ve potansiyel alıcılarla iletişim kurmalarına olanak tanır.

## Kullanılan Teknolojiler

- .NET Core Framework: Uygulamanın temelini oluşturan güçlü ve esnek bir platformdur.
- Entity Framework: Veritabanı erişimi ve ORM işlemleri için kullanılan bir teknolojidir.
- FluentValidation: Giriş doğrulaması ve veri geçerliliği için kullanılan bir kütüphanedir.
- Json Web Token (JWT): Kullanıcı kimlik doğrulaması ve yetkilendirme için kullanılan bir token tabanlı kimlik doğrulama yöntemidir.
- MSSQL: Veritabanı yönetim sistemi olarak kullanılan bir ilişkisel veritabanıdır.
- AutoMapper: Nesne eşlemesi (object mapping) işlemlerini kolaylaştıran bir kütüphanedir.
- Cloudinary: Bulut tabanlı depolama hizmetiyle resimlerin yüklenmesi ve yönetilmesi için kullanılır.

## Projeyi Geliştirmenin Faydaları

- .NET Core Framework'ü pratik etmek ve güçlü bir web uygulaması geliştirmek.
- Entity Framework kullanımını daha iyi anlamak ve veritabanı işlemlerini kolaylaştırmak.
- FluentValidation teknolojisiyle giriş doğrulama ve veri geçerliliği sağlama becerisi kazanmak.
- JWT kullanarak rol bazlı yetki yapısını öğrenmek ve uygulamaya entegre etmek.
- MSSQL Server teknolojisini pratik etmek ve veritabanı işlemlerini gerçekleştirmek.
- AutoMapper ile nesne eşlemesi yapmayı öğrenmek ve veri dönüşümlerini kolaylaştırmak.
- Cloudinary ile bulut tabanlı depolama konusunda deneyim kazanmak ve resimlerin yönetimini sağlamak.

## Kurulum

1. Bu depoyu yerel makinenize klonlayın.
2. Visual Studio'yu açın ve projeyi içe aktarın.
3. MSSQL veritabanınızı oluşturun ve bağlantı ayarlarını appsettings dosyasında yapılandırın.
4. Gerekli bağımlılıkları yüklemek için NuGet paketlerini geri yükleyin.
5. Uygulamayı başlatın ve API'yi kullanmaya başlayın.

## API Kullanımı

API'yi kullanmak için aşağıdaki adımları takip edin:

1. **Kullanıcı Kaydı:** Kullanıcı kaydı için `/api/auth/register` endpointini kullanın.
2. **Kullanıcı Girişi:** Kullanıcı girişi için `/api/auth/login` endpointini kullanın ve bir JWT token alın.
3. **Ev Listesi:** Tüm evleri listelemek için `/api/houses` endpointini kullanın.
4. **Ev Detayı:** Belirli bir evin detaylarını görmek için `/api/houses/{houseId}` endpointini kullanın.
5. **Ev Ekleme:** Kendi evinizi eklemek için `/api/houses` endpointini kullanın.
6. **Ev Düzenleme:** Var olan bir evi düzenlemek için `/api/houses/{houseId}` endpointini kullanın.
7. **Ev Silme:** Var olan bir evi silmek için `/api/houses/{houseId}` endpointini kullanın.

Daha fazla API endpointi ve kullanımı için lütfen API dokümantasyonuna başvurun.
