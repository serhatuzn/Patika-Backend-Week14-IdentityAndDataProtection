# Patika Backend Week14: Identity and Data Protection

## Proje Açıklaması
Bu proje, kimlik doğrulama ve veri koruma konularını ele almak için geliştirilmiştir. ASP.NET Core Identity kullanılarak kullanıcı kayıt ve giriş işlemleri güvenli bir şekilde gerçekleştirilmiştir.

## Kullanılan Teknolojiler
- **ASP.NET Core Identity**: Kullanıcı kimlik doğrulama ve yetkilendirme.
- **Entity Framework Core**: Veritabanı işlemleri için.
- **C#**: Backend geliştirme dili.

## Proje Özellikleri
1. **Kullanıcı Kayıt ve Giriş İşlemleri**:
   - Kullanıcıların güvenli bir şekilde kayıt olmasını sağlar.
   - Giriş işlemi sırasında şifre hashlenmesi ve doğrulama yapılır.
2. **Hata Yönetimi**:
   - Doğru ve anlaşılır hata mesajları döndürülür.
3. **Model Validasyon**:
   - Model doğrulama ile eksik veya hatalı girişler engellenir.

## Kurulum Talimatları
1. Bu projeyi klonlayın veya indirin.
2. Gerekli bağımlılıkları yüklemek için aşağıdaki komutu çalıştırın:
   ```bash
   dotnet restore
   ```
3. Projeyi çalıştırın:
   ```bash
   dotnet run
   ```
