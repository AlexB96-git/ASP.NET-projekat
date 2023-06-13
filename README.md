# ASP.NET-projekat
<blockquote>Aleksa Berisavac 32/18</blockquote>

<blockquote>Akademija tehničko-umetničkih strukovnih studija Beograd odsek visoka škola za informacione i komunikacione tehnologije</blockquote>

<hr></hr>

Projekat je u izradi. Ispod se vodi evidencija onoga sto je trenutno uradjeno.
Podaci unutar bilo kog projekta, dakle metode, interfejsi i ostalo su podlozni promenama u zavisnosti od potreba visih slojeva i uocavanja gresaka.
Tema projekta je knjizara, u kojoj se moze obavljati kupovina knjiga. Korpa ne postoji na backendu u vidu tabele i entiteta, vec samo narudzbine. </br></br>
Progress:
1. Domain: 100% - Done
2. EfDataAccess: 100% - Done
3. Application: 100% - Done
4. Implementation: 85% - ongoing
5. Api: 65% - ongoing - operable

<hr></hr>

Table Of Contents:
1. Baza Podataka
2. Domain
3. EFDataAccess
4. Application
5. Implementation
6. Api
7. Behind The Scenes
8. References

<hr></hr>

Uputstvo za pregledaca: </br>
1. Nakon povezivanja na bazu podataka (BerixKnjizara) pomocu odgovarajuceg konekcionog stringa i migriranja šeme (Fokusira se na EfDataAccess projekat u nugget konzoli, pozove se update-database), <b>Pokrenuti aplikaciju i pozvati InitialiseDatabase api</b>, metod post. Ovo ce postaviti pocetno stanje aplikacije, odnosno baze podataka, i vise nece biti potrebe pozivati ovaj metod osim u slucaju promene baze podataka. Ovaj poziv se ne autentifikuje.
2. Login se obavlja tako sto se pozove Token kontroler i prosledi se objekat sa kredencijalima: {email: [email], password: [password]}. Zatim se taj token iskopira i nalepi se u Authorization formi u swaggeru. Voditi racuna da je forma unosa u tekstualno polje: "Bearer [token]". Detaljan flow koraka se nalazi na slici ispod. Kredencijali: </br></br>Obican user: user@user.com, user123 - za sada nijedna privilegija </br>Admin: admin@admin.com, admin123 - sve privilegije</br></br>
![image](https://github.com/AlexB96-git/ASP.NET-projekat/assets/112824193/b1ea152e-4ced-4947-aff0-86846bd5ab34)</br></br>
3. Registracija ce se vrsiti tako sto ce se neautentifikovanom korisniku dodati privilegija da moze da doda user-a. -- not implemented, next to be implemented</br>
4. Sto se tice manipulacije entitetima, zbog pojednostavljivanja samog projekta:</br>
4.1. get ce ujedno dohvatati i pretrazivati entitete dok je termin za pretragu opcion,</br>
4.2. get/{id} ce dohvatati specifican entitet,</br>
4.3. post ce ubacivati novi element bez pratecih kolekcija gde god je to moguce za entitete,</br>
4.5. put ce editovati po minimalnim poljima, nece se raditi edit kolekcija referišućih tabela jer bi to bilo previse pisanja u json-u.</br>
4.6. delete ce raditi kao sto je i namenjeno.</br>
5. Trenutno je odradjeno 3/9 entiteta, sa sve validacijama i proverama i 5 endpoint-eva. Danas 13/6/2023 cu odraditi jos Entiteta, sve komande su napravljene samo su kontroleri ostali.

<hr></hr>

Content:
1. Baza Podataka:</br>
1.1. Baza Podataka je redukovana u smislu tabela koje bi sve mogla da ima (na primer odvojena tabela za jezike ciji bi odnos sa knjigom bio vise prema vise). Takodje zbog jednostavnosti: umesto uvodjenja vezivne tabele izmedju korisnika i uloga sto bi omogucilo da jedan korisnik ima istovremeno vise uloga, samim tim i privilegija, jedan korisnik moze imati samo jednu ulogu.</br>
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
5. Implementation:</br>
5.1. Implementation obezbedjuje implementaciju metoda koji implementiraju interfejse iz Application-a, validatore, profile za mapper i jos neke funkcionalnosti.</br>
5.2. Struktura Implementation-a:</br></br>
![image](https://github.com/AlexB96-git/ASP.NET-projekat/assets/112824193/8b73a6b8-6bc2-460d-a998-f7a26e6316e2)
6. Api:</br>
6.1. Api obezbedjuje komunikaciju i manipulaciju sa svim prethodnim slojevima.</br>
6.2. Struuktura Api-ja ce biti kasnije postavljena.</br></br>
7. Behind The Scenes:</br></br>
7.1. Vibe</br>
![IMG_20230612_020608](https://github.com/AlexB96-git/ASP.NET-projekat/assets/112824193/38c99344-84f3-4f9b-9504-c4b9ba9a4cf5)</br></br>
7.2. Aplication, Implementation, Data initialisation</br>
![IMG_20230612_204948](https://github.com/AlexB96-git/ASP.NET-projekat/assets/112824193/191a045c-9745-4e7d-b4ca-192c760f5024)</br></br>
7.3. Entities</br>
![IMG_20230612_204956](https://github.com/AlexB96-git/ASP.NET-projekat/assets/112824193/f6727ccf-bd2f-462d-b9a2-43377e28a891)</br></br>
7.4. UseCases</br>
![IMG_20230612_204939](https://github.com/AlexB96-git/ASP.NET-projekat/assets/112824193/b0390af9-f4ef-4470-a1eb-47754e58932c)</br></br>
7.5. Finish is so close</br>
![IMG_20230612_205005](https://github.com/AlexB96-git/ASP.NET-projekat/assets/112824193/c4d56a79-2383-4fba-95a4-f2a16fc6b83a)</br></br>
8. References
8.1. Kod sa vezbi iz ASP-a iz prethodnih godina.

