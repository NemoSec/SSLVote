# SSLVote
Version 1.0

Piattaforma di Voto online
Autore: NemoSec
Data di pubblicazione: 12/09/2017
_______
NOTA: SE SI VUOLE TESTARE IL PROGRAMMA, CAMBIARE LE STRINGHE DI CONNESSIONE NEL CODICE
Questo progetto mira a presentare un sistema di voto elettronico.
Lo scopo di questo progetto è presentare una piattaforma di voto che sia Sicura, Segreta e Libera, per questo è stato scelto un modello a codice aperto.
Il codice aperto permette a chiunque di poter verificare cosa fa il programma e, per garantire la sicurezza e la segretezza, si è scelto per operare tramite programma scollegato dal server centrale.
Vediamo, quindi, in cosa consiste questo software e cosa fa, partendo dal Database.
Il Database è un Access, pur sapendo che non è adatto per situazioni mission critical.
Questo perché, in caso si voglia utilizzare la piattaforma, si deve semplicemente cambiare il DB a cui punta il software, quindi questa versione è completa, ma OVVIAMENTE è un esempio di come funziona, e in caso modificarlo secondo le esigenze.
Il linguaggio di programmazione scelto per lo sviluppo è VB.NET, in futuro saranno disponibili esempi  in molteplici linguaggi.

E' disponibile una versione PDF e Word, completa di schermate e spiegazioni.
 
In sintesi:
Il programma simula a tutti gli effetti il funzionamento di una cabina elettorale.
Nome utente e password iniziale – L’Utente virtualmente si presenta al seggio, se ha già votato non può rivotare, altrimenti gli viene “consegnata” la scheda elettorale (la lista delle preferenze).
Una volta selezionata la preferenza è come se l’utente avesse segnato con la matita la propria preferenza, la password che genera il token rappresenta la scheda elettorale chiusa.
Il database registra il token+preferenza e il nome utente in due tabelle separate, senza registrare nessun altro dato, questo impedisce la profilazione dell’utente e quindi capire cosa ha votato.
Il token serve all’utente per verificare in qualunque momento, su eventuale sito web (questa funzione arriverà direttamente su programma in versioni future o verrà rilasciato un sito web di prova) o su programma la propria selezione, quindi può controllare la propria votazione, funzione impossibile attualmente con le cabine elettorali fisiche.
Le connessioni effettuate sono le seguenti:
Verifica le credenziali (Lettura – Attualmente le credenziali non hanno hash, è solo per prova)
Verifica voto (Lettura)
Lettura preferenze (Lettura)
Scrittura Voto (Scrittura)
Scrittura nome utente votante (Scrittura)
Tutte le operazioni di hash, operazioni interne ecc. (come anche evincibile da codice) sono operate internamente al programma, quindi sul PC dell’utente, questo per garantire il massimo della trasparenza e segretezza.
E’ attualmente in sviluppo un software anche per effettuare controlli incrociati e certificare le attività di Voto.
Contatti, suggerimenti, segnalazioni bug ecc.:
Alessandro Fiori – a.fiori@nemosec.com
Alessandro La Malfa - a.lamalfa@nemosec.com
NemoSec
