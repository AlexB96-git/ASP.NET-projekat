# ASP.NET-projekat
Projekat ce biti odradjen preko vikenda.
Podaci unutar bilo kog projekta, dakle metode, interfejsi i ostalo su podlozni promenama u zavisnosti od potreba visih slojeva i uocavanja gresaka.
Tema projekta je knjizara, u kojoj se moze obavljati kupovina knjiga.</br></br>
Progress:
1. Domain: 100% - feedback
2. EfDataAccess: 100% - feedback
3. Application: 100% - feedback
4. Implementation: 50% - ongoing
5. Api: 0% - ToStart

Table Of Contents:
1. Baza Podataka
2. Domain
3. EFDataAccess
4. Application
5. Implementation
6. Api

Content:
1. Baza Podataka:</br>
1.1. Baza Podataka je redukovana u smislu tabela koje bi sve mogla da ima (na primer odvojena tabela za jezike ciji bi odnos sa knjigom bio vise prema vise).</br>
Ovo je uradjeno da bi se iole umanjio broj entiteta u projektu, a da se i dalje prikazu sve funkcionalnosti.</br>
1.2. Izgled baze u MSSMS nakon sto se napravi preko migracija.</br></br>
![image](https://github.com/AlexB96-git/ASP.NET-projekat/assets/112824193/4db951ab-f3c4-4368-bd00-da76a2b9d303)
2. Domain:</br>
2.1. Domain obezbedjuje definisanje entiteta kakvi ce se cuvati u bazi podataka.</br>
2.2. Struktura domena: </br></br>
![image](https://github.com/AlexB96-git/ASP.NET-projekat/assets/112824193/6133f456-d86c-49d7-b0c9-4308b4c98a2e)
3. EFDataAccess: </br>
3.1. EfDataAccess obezbedjuje konfiguracije za povezivanje entiteta u Domain-u, i ostale potrebne provere/indekse</br>
3.2. Struktura EFDataAccess-a</br></br>
![image](https://github.com/AlexB96-git/ASP.NET-projekat/assets/112824193/d82d6520-e9b4-4158-83fe-6595dc273287)
4. Application:</br>
4.1. Application obezbedjuje vecinom definisanje interfejsa, a potom i neke najosnovnije funkcionalnosti za obezbedjivanje logike upravljanja komunikacijom izmedju krajnjih resursa.</br>
4.2. Struktura Appplication-a:</br></br>
![image](https://github.com/AlexB96-git/ASP.NET-projekat/assets/112824193/d6c8017f-c8a0-431d-ad38-b212cb501170)


