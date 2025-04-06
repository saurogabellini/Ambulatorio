# Ambulatorio App - Sistema di Gestione Prenotazioni

Questa applicazione è un sistema completo per la gestione delle prenotazioni di medici in un ambulatorio, sviluppato con .NET Blazor Server e SQLite.

## Funzionalità Principali

- **Gestione Operatori**: Anagrafica completa degli operatori con cognome, nome, codice fiscale, recapiti e specializzazione.
- **Gestione Servizi**: Anagrafica dei servizi offerti dall'ambulatorio.
- **Gestione Disponibilità**: Configurazione degli slot di disponibilità per ogni combinazione operatore/servizio, con durata personalizzabile e gestione della ricorrenza.
- **Gestione Assenze**: Registrazione delle assenze degli operatori con data e ora di inizio e fine.
- **Sistema di Prenotazioni**: Ricerca delle disponibilità per operatore o servizio, con esclusione automatica degli slot dove l'operatore è assente o già prenotati.

## Requisiti Tecnici

- .NET 7.0 o superiore
- SQLite

## Struttura del Progetto

- **Data/Models**: Contiene le classi dei modelli di dati (Operatore, Servizio, SlotDisponibilita, Assenza, Prenotazione).
- **Data/ApplicationDbContext.cs**: Contesto del database Entity Framework Core.
- **Data/DbInitializer.cs**: Inizializzazione del database.
- **Pages**: Contiene le pagine Razor per l'interfaccia utente.

## Modelli di Dati

### Operatore
- Id
- Cognome
- Nome
- CodiceFiscale
- Recapiti
- Specializzazione

### Servizio
- Id
- Nome
- Descrizione

### SlotDisponibilita
- Id
- OperatoreId
- ServizioId
- GiornoSettimana (1-7, dove 1 è Lunedì)
- OraInizio
- OraFine
- DurataMinuti
- Attivo
- DataInizioValidita (opzionale)
- DataFineValidita (opzionale)
- CicloGiorni (opzionale)

### Assenza
- Id
- OperatoreId
- DataOraInizio
- DataOraFine
- Motivo

### Prenotazione
- Id
- OperatoreId
- ServizioId
- SlotDisponibilitaId
- DataPrenotazione
- DataOraInizio
- DataOraFine
- NomeCliente
- CognomeCliente
- TelefonoCliente
- EmailCliente
- Note

## Funzionalità Dettagliate

### Gestione Disponibilità e Turni
Il sistema permette di configurare gli slot di disponibilità su base settimanale (da lunedì a domenica) per ogni combinazione operatore/servizio. È possibile impostare ricorrenze personalizzate specificando:
- Data di inizio validità
- Data di fine validità (opzionale)
- Ciclo di giorni (es. 1 = ogni giorno, 2 = a giorni alterni, 7 = settimanale)

### Gestione Assenze
Il sistema permette di registrare le assenze degli operatori specificando:
- Data e ora di inizio assenza
- Data e ora di fine assenza
- Motivo dell'assenza

### Sistema di Prenotazioni
Il sistema permette di cercare disponibilità per:
- Operatore specifico
- Servizio specifico
- Data specifica

Durante la ricerca, il sistema esclude automaticamente:
- Slot dove l'operatore è assente
- Slot già prenotati

## Avvio dell'Applicazione

1. Assicurarsi di avere .NET 7.0 o superiore installato
2. Clonare il repository
3. Navigare nella directory del progetto
4. Eseguire `dotnet run`
5. Aprire un browser e navigare a `https://localhost:5001` o `http://localhost:5000`

## Note di Sviluppo

- L'applicazione utilizza Entity Framework Core con SQLite come database
- Il database viene creato automaticamente all'avvio dell'applicazione se non esiste
- L'interfaccia utente utilizza Bootstrap per lo stile e la responsività
