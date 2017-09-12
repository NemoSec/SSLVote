Imports System.Data.OleDb

Public Class Form2

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'dichiaro la stringa di connessione
        Dim cs As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\Users\Alessandro Fiori\Desktop\Analisi\Progetto Votazione SourceForge\Database.accdb'")
        'apro la connessione
        cs.Open()
        'dichiaro la query da eseguire
        Dim command As New OleDbCommand("SELECT Preferenze.Preferenza FROM Preferenze;", cs)
        'dichiaro il data reader ed eseguo la query
        Dim dr As OleDbDataReader = command.ExecuteReader
        'controlla che siano presenti effettivamente delle preferenze
        If dr.Read = False Then
            'se non sono presenti preferenze (es. Votazione chiusa), restituisce un messaggio di errore
            MsgBox("Attenzione! Nessuna preferenza selezionabile. Il programma verrà chiuso")
            Me.Close()
        Else
            'legge la prima preferenza e la inserisce in lista
            ListBox1.Items.Add(dr(0))
            'legge le preferenze e le inserisce nella lista
            Do While dr.Read
                ListBox1.Items.Add(dr(0))
            Loop
        End If
        'chiude la connessione una volta terminata l'operazione
        cs.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'controlla che il cittadino abbia selezionato una preferenza valida
        If ListBox1.SelectedIndex = -1 Then
            'se il cittadino non ha selezionato una preferenza, restituisce un messaggio di errore
            MsgBox("Attenzione! Selezionare una preferenza valida")
        Else
            'dichiaro la preferenza selezionata
            Dim preferenzaselezionata As String = ListBox1.GetItemText(ListBox1.SelectedItem)
            'salvo la preferenza nelle impostazioni per utilizzo futuro
            My.Settings("Preferenza") = preferenzaselezionata
            'apro la maschera di salvataggio voto
            Form3.Activate()
            Form3.Show()
            Me.Close()
        End If
    End Sub
End Class