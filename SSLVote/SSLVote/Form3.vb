Imports System.Text
Imports System.Security.Cryptography
Imports System.Data.OleDb


Public Class Form3

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'dichiaro la variabile password
        Dim passwordconferma As String = TextBox1.Text
        'controllo che la password immessa sia valida
        If String.IsNullOrEmpty(passwordconferma) Or String.IsNullOrWhiteSpace(passwordconferma) Then
            'se non è stata immessa una password valida restituisce un messaggio di errore
            MsgBox("Attenzione! Inserire una password valida")
        Else
            'se la password immessa è valida ottiene il token
            Dim token As String = creatoken(passwordconferma)
            'dichiaro la stringa di connessione
            Dim cs As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\Users\Alessandro Fiori\Desktop\Analisi\Progetto Votazione SourceForge\Database.accdb'")
            'apro la connessione
            cs.Open()
            'dichiaro la query da eseguire
            Dim command As New OleDbCommand("INSERT INTO Voti ( Token, Preferenza ) SELECT " & Chr(34) & token & Chr(34) & " AS Espr1, " & Chr(34) & My.Settings("Preferenza") & Chr(34) & " AS Espr2;", cs)
            'eseguo la query
            command.ExecuteNonQuery()
            'dichiaro la query da eseguire
            Dim command1 As New OleDbCommand("INSERT INTO Votanti ( [Nome Utente] ) SELECT " & Chr(34) & My.Settings("Utente") & Chr(34) & " AS Espr1;", cs)
            'eseguo la query
            command1.ExecuteNonQuery()
            'chiudo la connessione
            cs.Close()
            'salva il token e la preferenza sul desktop per un controllo futuro
            My.Computer.FileSystem.WriteAllText(My.Computer.FileSystem.SpecialDirectories.Desktop & "\Verifica_Voto.txt", token & vbCrLf & My.Settings("Preferenza"), False)
            'resetta le impostazioni
            My.Settings.Reset()
            'chiude il programma
            MsgBox("Grazie per aver espresso il Suo Voto. Può controllare in ogni momento il voto espresso grazie al token salvato sul file Verifica_Voto presente sul Suo Desktop.")
            Me.Close()
        End If
    End Sub

    Public Function creatoken(ByVal password As String)
        'dichiaro la variabile per generare il token
        Dim datitoken As String = My.Settings("Utente") & My.Settings("Preferenza") & password
        'dichiaro quale hash utilizzare
        Dim hashing As New SHA512CryptoServiceProvider
        'dichiaro l'Encoder da utilizzare
        Dim encoder As New System.Text.ASCIIEncoding
        'converto in byte il tutto
        Dim bytefromdatitoken() As Byte = encoder.GetBytes(datitoken)
        'eseguo l'operazione di hash
        Dim hashinbyte() As Byte = hashing.ComputeHash(bytefromdatitoken)
        'ottengo l'hash
        Dim token As String = ""
        For Each byt As Byte In hashinbyte
            token += byt.ToString("x2")
        Next
        Return token
    End Function
End Class