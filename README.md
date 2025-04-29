# MVC Online Ticari Otomasyon
<br>
Bu MVC tabanlı Online Ticaret Otomasyonu projem,bir mağazanın vitrin,admin ve kullanıcı (personel/ cari) olmak üzere 3 temel panelinden oluşuyor. Özellikle admin panelinin dashboard kısmı,güçlü bir arayüze sahip olmasının yanı sıra CRUD işlemlerinin ötesinde, Entity Framework ve LINQ sorguları üzerinden SQL yapıları (Trigger, Prosedür gibi) kullanılarak işlemler yapılabiliyor. MVC5 ile sıfırdan dinamik bir web projesi geliştirdim ve Code First yaklaşımıyla veritabanı yönetimini sağladım. Bu sayede hem yazılım hem de veritabanı yönetimi açısından güçlü bir altyapı oluşturmuş oldum. Ayrıca, Chart ve Widget Card kullanımları,Sweet Alert, QR Code, Pop Up,File Upload, Authentication, Session ile Mail Taşıma gibi çeşitli araçları da projemde kullandım. Route Config ayarları ve diğer yapılandırmalarla projeyi daha işlevsel ve kullanıcı dostu hale getirdim.<br> <br>

<b>İçindekiler<b> <br>
#ASP.Net Model View Controller Mimarisi<br>
#Entity Framework <br>
#Code First <br>
#Kısıtlamalar ve Veri Türleri <br>
#HttpGet, HttpPost, HtmlHelper Kaydetme İşlemi <br>
#CRUD İşlemleri<br>
#Linq Sorguları, Group By, Alt Sorgular <br>
#Trigger ile Stok Düşürme
#Bir Viewde Birden Fazla Tablo Listeleme IEnumarable <br>
#Partial View <br>
#Displayname Kullanımı<br>
#Popup Kullanımı, Authentication, Authorize İşlemleri <br>
#Session ile Mail Taşıma<br>
#File Upload ile Personellere Resim Ekleme<br>
#Alert ve Sweet Alert Kullanımı <br>
#QR Code İşlemleri<br>
#Pie,Line, Column Chart, Widget Card kullanımları <br>
#Hata Sayfaları <br>
#LogOut 
# Projemden Kesitler<br>
#Giriş Sayfası
![Image](https://github.com/user-attachments/assets/355a11fd-5205-42b7-978b-559418d10377)
#Admin Tarafı<br>
![Image](https://github.com/user-attachments/assets/41c95bdb-0437-4968-830d-94a2e393883d)
![Image](https://github.com/user-attachments/assets/39b685d1-6ab1-4f6e-9b17-f0a138132c82)
![Image](https://github.com/user-attachments/assets/8b0d16ec-46f0-4f4b-81da-042aebca7ac0)
![Image](https://github.com/user-attachments/assets/c15c7f00-750a-4f51-bfaf-e1c4ab57c200)
![Image](https://github.com/user-attachments/assets/ea81f4da-c342-489c-bac3-23ec816fdcf2)
![Image](https://github.com/user-attachments/assets/3af59edf-b637-4ca4-9660-88159e4e05d6)
![Image](https://github.com/user-attachments/assets/885dc533-9d75-4735-b3cf-13d7364c0eda)
![Image](https://github.com/user-attachments/assets/afca2db1-c696-45d5-94e3-9a0b841e5da9)
![Image](https://github.com/user-attachments/assets/a3abc322-082d-400a-85d7-af5e528942b6)
![Image](https://github.com/user-attachments/assets/8004d4a2-593a-46c7-8b8c-4a4f2750c6a2)
![Image](https://github.com/user-attachments/assets/bc748727-0b4d-423d-9147-cc1ed456e434)
![Image](https://github.com/user-attachments/assets/3e93f4c6-ac2f-4883-9cfd-655351247048)
![Image](https://github.com/user-attachments/assets/8671a1dd-5e5d-473a-81e8-84c88350e60b)
![Image](https://github.com/user-attachments/assets/1d943566-473a-42ca-803a-74d2cbbd2256)
![Image](https://github.com/user-attachments/assets/27ce48d7-529a-4f14-954f-41923926d27c)
![Image](https://github.com/user-attachments/assets/0ad86321-13b1-463c-99e6-dfa307c2d35f)
![Image](https://github.com/user-attachments/assets/daeb01f0-6f77-4c3d-a572-434d1c82234b)
![Image](https://github.com/user-attachments/assets/77f9f428-67b5-424f-8191-e093248d6131)
![Image](https://github.com/user-attachments/assets/95d63a7d-1e24-4b85-ae2e-9b8c78cdd889)
![Image](https://github.com/user-attachments/assets/e011f16f-d645-422e-b890-c4a18d14e7f7)
![Image](https://github.com/user-attachments/assets/01fc4e0d-d213-4f69-aff8-f7f4ae91f83e)
![Image](https://github.com/user-attachments/assets/8c1084db-3106-4aa2-ac9e-2effb933153c)
![Image](https://github.com/user-attachments/assets/9267c2ae-46c8-4afa-babd-3795d1770cfa)
![Image](https://github.com/user-attachments/assets/4d5c5759-6173-449f-b6c6-5faadd175b69)
![Image](https://github.com/user-attachments/assets/01d3feb4-dabe-4e27-b986-d5a5c0f966e6)
![Image](https://github.com/user-attachments/assets/b2f72ca3-9fcd-480f-8b2e-ea061620c46e)
![Image](https://github.com/user-attachments/assets/95000174-273b-42b8-a05e-c4d3b5fafc9e)
![Image](https://github.com/user-attachments/assets/500a335c-7f5c-487e-8f2e-e12d0e80f395)
![Image](https://github.com/user-attachments/assets/ce1aabdd-c804-4c50-b85d-a5b0d70c263a)
![Image](https://github.com/user-attachments/assets/94a906a4-0d08-48e3-a21b-5207cfe791b2)
![Image](https://github.com/user-attachments/assets/d49314a0-ab2c-42a9-9ab2-f3fa34b53717)
![Image](https://github.com/user-attachments/assets/1b49d4b3-121a-40c7-8103-a83974da3109)
![Image](https://github.com/user-attachments/assets/3e71a73b-6b45-44a7-bb12-f7eec5941a40)
![Image](https://github.com/user-attachments/assets/cdc96340-d412-48b1-b13b-5f0561904d90)
![Image](https://github.com/user-attachments/assets/7958a777-4e60-4c34-8f31-c55760515397)
![Image](https://github.com/user-attachments/assets/2aae52b1-d154-4a1c-a3f7-d672453ce657)
![Image](https://github.com/user-attachments/assets/e5df56b1-0f5e-4fce-9975-33fb7648b2de)
![Image](https://github.com/user-attachments/assets/4cc9f837-0aec-4aa0-8315-1268929ea206)
![Image](https://github.com/user-attachments/assets/69d31fc1-22d6-462a-838c-7819305befee)
![Image](https://github.com/user-attachments/assets/5d9f255d-69c4-495e-8779-f2fe3db0ed06)
![Image](https://github.com/user-attachments/assets/63c0967a-5b5f-4869-8309-7a304ed1fd2c)
![Image](https://github.com/user-attachments/assets/34d981d0-8f8d-4e41-84f2-ed94118d47bb)
![Image](https://github.com/user-attachments/assets/32716ed6-86b9-40d1-a720-f7e382d90eba)
![Image](https://github.com/user-attachments/assets/1f0b1a62-b447-4950-986c-fc4ba9e793a4)
![Image](https://github.com/user-attachments/assets/432b395e-6926-4368-8e57-8c0f986b69a3)
![Image](https://github.com/user-attachments/assets/67de48e1-ca1a-4637-8b12-c612b8d925fa)
# Cari<br>
#Cari Kayıt
![Image](https://github.com/user-attachments/assets/24c55db5-07ac-4846-b081-870f50f804b3)
#Cari Giriş
![Image](https://github.com/user-attachments/assets/f077d779-bde6-4cae-acf2-c4a4032189e8)
#Cari Paneli
![Image](https://github.com/user-attachments/assets/0c9bef36-3991-463a-9653-8cf545b23ca3)
![Image](https://github.com/user-attachments/assets/fa8de393-7d31-4f82-a6bf-07a3d9b1479a)
![Image](https://github.com/user-attachments/assets/7659cca0-607f-4350-832a-3c47dc9ce667)
![Image](https://github.com/user-attachments/assets/76cf4897-aa8c-455b-a913-5861c6be437c)
![Image](https://github.com/user-attachments/assets/c232ecde-b29b-41fc-a450-91d0c17124f7)
![Image](https://github.com/user-attachments/assets/789bf1cf-5a3c-4a28-afb3-c78585b3ffeb)
![Image](https://github.com/user-attachments/assets/2ef3e0cb-a384-4dc8-9679-d5246f01d04a)
#Personel Giriş
![Image](https://github.com/user-attachments/assets/f33b7c4c-b5b2-409f-8827-708ea802e3ca)
![Image](https://github.com/user-attachments/assets/d2c379d6-6c2c-4cd3-918c-447b1e397709)







