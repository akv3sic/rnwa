# Napomene
Na ovu zadaću nadograđena je DZ 7.1 HTTP Basic AA.

## Informacije za DZ 7.1

### Klijentska strana

Koristi se Base64 enkodiranje. S klijentske strane potrebno je poslati enkodirani par e-mail i lozinka u formatu email:šifra.

Tako enkodirani e-mail i lozinka stavljeni su u Authorization header HTTP zahtjeva.

```
const response = await axios.get(`${BASE_URL}/Employees`, {
    headers: {
    Authorization: 'Basic YW50ZUB0ZXN0LmJhOnNpZnJhMTIz' 
    }
}
```

### Serverska strana

Napravljena je dodatna tablica u bazi `Users` i ažurirani modeli. U mapi `Handlers` nalazi se nova klasa `BasicAuthenticationHandler`.

Iznad nekih kontrolera/metoda unutar kontrolera dodaj je atribut `[Authorize]` i za njih je potrebna autorizacija. 


