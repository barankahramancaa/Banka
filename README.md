# 🏦 Banka Sistemi

C# ile yazılmış, nesne yönelimli programlamanın (OOP) dört temel prensibini kullanan bir konsol banka uygulaması.

## Özellikler
- Üç farklı hesap türü açma: Normal, Vadeli, Vadesiz
- Para yatırma ve çekme
- Vadesiz hesapta 1000 TL'ye kadar ek hesap (eksi bakiye)
- Vadeli hesapta faiz hesaplama
- Tüm hesapları listeleme
- Her hesap için işlem geçmişi

## Kullanılan OOP prensipleri

| Prensip | Projede nerede? |
|---|---|
| **Encapsulation** | `Balance` dışarıdan değiştirilemez (`protected set`), sadece `Deposit` ve `Withdraw` ile değişir |
| **Inheritance** | `SavingsAccount` ve `CheckingAccount`, `Account` class'ından miras alır |
| **Polymorphism** | `Withdraw` metodu `virtual`, `CheckingAccount`'ta `override` edilerek eksi bakiyeye izin verir |
| **Abstraction** | `IInterest` interface'i faiz kazanabilen hesaplar için bir sözleşme tanımlar |

## Kullanılan konular
- Class, constructor, property (`get` / `protected set`)
- `List<Account>` ile farklı hesap türlerini tek listede tutma
- `List<string>` ile işlem geçmişi
- `while` menü döngüsü, `for` ve `foreach`

## Nasıl çalıştırılır
1. Projeyi Visual Studio ile aç
2. `Ctrl + F5` ile çalıştır
3. Menüden 1-5 arası bir seçim yap, çıkmak için 0

## Geliştirme planı
- Hatalı girişlerde programın çökmesini engelleme (`try-catch`)
- Hesaplar arası para transferi
- Verileri veritabanında (SQL) saklama
