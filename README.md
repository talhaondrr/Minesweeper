# Minesweeper (Mayın Tarlası)

C# ile yazılmış bir konsol oyunu. Amaç 6 × 6 tahtadaki 31 güvenli kareyi mayına basmadan açmak.

## Nasıl oynanır?

- Oyun başında 5 mayın rastgele yerleştirilir. Her satır ve sütunda en fazla bir mayın bulunur.
- Kare açmak için önce satırı, sonra sütunu gir. İkisi de 1 ile 6 arasında olmalı.
- `#` kapalı kareyi gösterir. Açılan güvenli karedeki sayı, çaprazlar dahil komşu karelerde kaç mayın olduğunu gösterir.
- Açılmış bir kareyi tekrar seçersen oyun başka bir seçim ister.
- Mayına basarsan kaybedersin. 31 güvenli karenin tamamını açarsan kazanırsın. Oyun bittiğinde mayınlar `*` ile gösterilir.

## Çalıştırma

.NET 8 SDK gerekir. Repo klasöründe aşağıdaki komutu çalıştır veya `03_MayinTarlasi.csproj` dosyasını Visual Studio’da açıp F5’e bas.

```sh
dotnet run --project 03_MayinTarlasi.csproj
```
