Imports System.Drawing.Imaging
Imports System.IO

Public Class Form1


    'PowerFul Calendario
    '2026

    'Crea un calendario

    'Dimensioni
    Private LarghezzaPaginaPixel As Integer = 1180
    Private AltezzaPaginaPixel As Integer = 1660

    Private MargineSX As Integer = 60
    Private MargineTOP As Integer = 60
    Private MargineBottom As Integer = 60 ' margine in basso
    Private altezzaArea As Integer = AltezzaPaginaPixel - MargineTOP - MargineBottom - 80 ' 80 per titolo e giorni della settimana


    'Lista dei mesi in Italiano e Inglese
    Private MesiIT As List(Of String) = New List(Of String)
    Private MesiEN As List(Of String) = New List(Of String)

    ' Giorni settimana in Italiano e Inglese
    Private giorniSettimanaIT() As String = {"Lun", "Mar", "Mer", "Gio", "Ven", "Sab", "Dom"}
    Private giorniSettimanaEN() As String = {"Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"}

    'Sfondo Domeniche
    Private ColoreSfondoDomeniche As Color = Color.LightPink

    ' Festività italiane (giorno, mese)
    Private FestivitaIT As Dictionary(Of Date, String)

    ' Sfondo delle feste
    Private ColoreSfondoFeste As Color = Color.LightCoral

    ' Sfondo generico celle
    Private ColoreSfondoCelle As Color = Color.LightYellow

    ' Sfondo alternato celle
    Private ColoreSfondoCelleAlternato1 As Color = Color.LightYellow
    Private ColoreSfondoCelleAlternato2 As Color = Color.LightGreen

    ' Colore titolo del mese
    Private ColoreTitolo As Color = Color.BlueViolet

    ' Colore dei giorni settimana
    Private ColoreGiorniSettimana As Color = Color.Blue

    ' Colore dei giorni del mese
    Private ColoreGiorniMese As Color = Color.Brown

    ' Sfondo immagine calendario
    Private ImmagineSfondo As Bitmap = Nothing

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pbCalendario.BackColor = Color.White
        pbCalendario.SizeMode = PictureBoxSizeMode.StretchImage
        nudAnno.Minimum = 1900
        nudAnno.Maximum = 2100
        nudAnno.Value = DateTime.Now.Year

        cmbLingua.SelectedIndex = 0 'IT

        InizializzaListe()
        InizializzaFestivita()
        RiempiMesi()

        cmbMese.SelectedIndex = DateTime.Now.Month - 1
        cmbVista.SelectedIndex = 0
    End Sub

    Private Sub RiempiMesi()
        'Aggiunge i mesi in Italiano e Inglese
        cmbMese.Items.Clear()

        If cmbLingua.SelectedIndex = 0 Then
            'Italiano
            For Each mese In MesiIT
                cmbMese.Items.Add(mese)
            Next
        Else
            'Inglese
            For Each mese In MesiEN
                cmbMese.Items.Add(mese)
            Next
        End If
    End Sub

    Private Sub InizializzaListe()
        MesiIT = New List(Of String) From {
        "Gennaio", "Febbraio", "Marzo", "Aprile",
        "Maggio", "Giugno", "Luglio", "Agosto",
        "Settembre", "Ottobre", "Novembre", "Dicembre"
    }

        MesiEN = New List(Of String) From {
        "January", "February", "March", "April",
        "May", "June", "July", "August",
        "September", "October", "November", "December"
    }
    End Sub

    Private Sub InizializzaFestivita()
        FestivitaIT = New Dictionary(Of Date, String)

        ' Festività fisse
        FestivitaIT.Add(New Date(1, 1, 1), "Capodanno")
        FestivitaIT.Add(New Date(1, 1, 6), "Epifania")
        FestivitaIT.Add(New Date(1, 4, 25), "Liberazione")
        FestivitaIT.Add(New Date(1, 5, 1), "Lavoro")
        FestivitaIT.Add(New Date(1, 6, 2), "Repubblica")
        FestivitaIT.Add(New Date(1, 8, 15), "Ferragosto")
        FestivitaIT.Add(New Date(1, 11, 1), "Ognissanti")
        FestivitaIT.Add(New Date(1, 12, 8), "Immacolata")
        FestivitaIT.Add(New Date(1, 12, 25), "Natale")
        FestivitaIT.Add(New Date(1, 12, 26), "Santo Stefano")
    End Sub

    Private Function CalcolaPasqua(anno As Integer) As Date
        Dim a As Integer = anno Mod 19
        Dim b As Integer = anno \ 100
        Dim c As Integer = anno Mod 100
        Dim d As Integer = b \ 4
        Dim e As Integer = b Mod 4
        Dim f As Integer = (b + 8) \ 25
        Dim g As Integer = (b - f + 1) \ 3
        Dim h As Integer = (19 * a + b - d - g + 15) Mod 30
        Dim i As Integer = c \ 4
        Dim k As Integer = c Mod 4
        Dim l As Integer = (32 + 2 * e + 2 * i - h - k) Mod 7
        Dim m As Integer = (a + 11 * h + 22 * l) \ 451
        Dim mese As Integer = (h + l - 7 * m + 114) \ 31
        Dim giorno As Integer = ((h + l - 7 * m + 114) Mod 31) + 1

        Return New Date(anno, mese, giorno)
    End Function

    Private Sub AggiornaVista()
        Select Case VistaAttuale
            Case VistaCalendario.Mensile
                DisegnaCalendario(cmbMese.SelectedIndex + 1, CInt(nudAnno.Value))

            Case VistaCalendario.Settimanale
                DisegnaSettimana(Date.Today)

            Case VistaCalendario.GiorniConsecutivi
                DisegnaGiorniConsecutivi(CInt(nudAnno.Value))
        End Select
        cmbMese.Enabled = (VistaAttuale = VistaCalendario.Mensile)
        cmbLingua.Enabled = (VistaAttuale = VistaCalendario.Mensile)
    End Sub





    'Subs

    Private Sub btnAggiorna_Click(sender As Object, e As EventArgs) Handles btnAggiorna.Click
        AggiornaVista()
        'DisegnaCalendario(cmbMese.SelectedIndex + 1, CInt(nudAnno.Value))
    End Sub


    Private Sub DisegnaCalendario(mese As Integer, anno As Integer)

        ' Bitmap
        Dim bmp As New Bitmap(LarghezzaPaginaPixel, AltezzaPaginaPixel)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.Clear(Color.White)

        ' Immagine di sfondo calendario
        If chkBackImage.Checked Then
            Dim bmpSfondo As Bitmap = New Bitmap(ImmagineSfondo, New Size(LarghezzaPaginaPixel - MargineSX - MargineSX, AltezzaPaginaPixel - MargineTOP - MargineTOP))
            g.DrawImage(bmpSfondo, New Point(MargineSX, MargineTOP))
        End If

        ' Font
        Dim fontTitolo As New Font("Segoe UI", 42, FontStyle.Bold)
        Dim fontGiorni As New Font("Segoe UI", 24, FontStyle.Bold)
        Dim fontNumeri As New Font("Segoe UI", 22)

        ' Titolo
        Dim titolo As String = cmbMese.SelectedItem.ToString() & " " & anno
        Dim sizeTitolo As SizeF = g.MeasureString(titolo, fontTitolo)
        Dim posXTitolo As Single = (LarghezzaPaginaPixel - sizeTitolo.Width) / 2
        If chkColorTitolo.Checked Then
            g.DrawString(titolo, fontTitolo, New SolidBrush(ColoreTitolo), posXTitolo, MargineTOP)
        Else
            g.DrawString(titolo, fontTitolo, Brushes.Black, posXTitolo, MargineTOP)
        End If

        ' Giorni della settimana
        Dim giorniSettimana() As String = If(cmbLingua.SelectedIndex = 0, giorniSettimanaIT, giorniSettimanaEN)
        Dim cellaW As Integer = (LarghezzaPaginaPixel - MargineSX * 2) \ 7
        Dim startY As Integer = MargineTOP + fontTitolo.Height + 20 ' spazio dopo titolo

        For i As Integer = 0 To 6
            If chkColorGiorni.Checked Then
                g.DrawString(giorniSettimana(i), fontGiorni, New SolidBrush(ColoreGiorniSettimana), MargineSX + i * cellaW + 5, startY)
            Else
                g.DrawString(giorniSettimana(i), fontGiorni, Brushes.Black, MargineSX + i * cellaW + 5, startY)
            End If
        Next

        ' Date
        Dim primoGiorno As New DateTime(anno, mese, 1)
        Dim giorniNelMese As Integer = DateTime.DaysInMonth(anno, mese)
        Dim offset As Integer = (CInt(primoGiorno.DayOfWeek) + 6) Mod 7 ' Lunedì = 0

        ' Area verticale disponibile
        Dim MargineBottom As Integer = 40
        Dim altezzaArea As Integer = AltezzaPaginaPixel - startY - fontGiorni.Height - MargineBottom - 20
        Dim numRighe As Integer = Math.Ceiling((giorniNelMese + offset) / 7.0)
        Dim cellaH As Integer = altezzaArea \ numRighe

        ' Fasi lunari
        Dim output As New Text.StringBuilder()
        Dim Luna As Bitmap = Nothing
        If chkFasiLunari.Checked Then
            ' === Riduciamo la cella
            cellaH = CInt(cellaH / 2)

            Dim now As DateTime = DateTime.Now
            Dim segment As Integer
            Dim visibility = MoonPhase(now.Year, now.Month, now.Day, now.Hour + now.Minute / 60.0, segment)

            'Render Luna
            Luna = DrawMoonPhase(visibility)

            Dim year As Integer = anno
            Dim month As Integer = mese
            Dim segmentMese As Integer

            output.AppendLine($"Fasi Lunari per il mese di {MonthName(month)} {year} - Fasi per il 1, 5, 10, 15, 20 e 25 del mese alle 18:00.")
            output.AppendLine("Data  Ora  Visibilità   Fase")
            output.AppendLine("───────────────────────────────────────────────────────────")

            For day = 1 To DateTime.DaysInMonth(year, month)
                Dim visibilityMese As Double = MoonPhase(year, month, day, 16.0, segmentMese)
                Dim perc As String = Math.Round(visibilityMese * 100, 1).ToString("00.0") & "%"
                Dim dataStr As String = $"{day:00}/{month:00}/{year}"
                Dim fase As String = MoonPhaseName(segmentMese)

                'Ogni 2 giorni vai a capo
                If day Mod 2 = 0 Then
                    output.Append($"{dataStr} 16:00   {perc}   {fase}" & vbTab & vbTab & vbTab)
                Else
                    output.AppendLine($"{dataStr} 16:00   {perc}   {fase}")
                End If
            Next
        End If

        ' Solo Lune Piene
        If chkLunePiene.Checked AndAlso Not chkFasiLunari.Checked Then
            ' === Riduciamo la cella
            cellaH = CInt(cellaH / 2)
            'Calendario solo lune piene
            Luna = DisegnaCalendarioLunePiene(mese, anno)
        End If

        ' Pasqua e Pasquetta
        Dim dataPasqua As Date = CalcolaPasqua(anno)
        Dim dataPasquetta As Date = dataPasqua.AddDays(1)

        ' Ciclo giorni
        For giorno As Integer = 1 To giorniNelMese
            Dim giornoSettimana As Integer = (giorno + offset - 1) Mod 7
            Dim x As Integer = MargineSX + giornoSettimana * cellaW
            Dim y As Integer = startY + fontGiorni.Height + 10 + ((giorno + offset - 1) \ 7) * cellaH

            Dim dataFesta As New Date(1, mese, giorno)
            Dim dataCorrente As New Date(anno, mese, giorno)
            Dim isFestivita As Boolean = chkFestivita.Checked AndAlso FestivitaIT.ContainsKey(dataFesta)
            Dim isDomenica As Boolean = giornoSettimana = 6

            ' Festività fisse
            If chkFestivita.Checked AndAlso FestivitaIT.ContainsKey(dataFesta) Then isFestivita = True
            ' Pasqua e Pasquetta
            If chkFestivita.Checked AndAlso (dataCorrente = dataPasqua OrElse dataCorrente = dataPasquetta) Then
                isFestivita = True
            End If

            ' Sfondo generico celle
            If chkSfondoCelle.Checked Then
                Using br As New SolidBrush(ColoreSfondoCelle)
                    g.FillRectangle(br, x, y, cellaW, cellaH)
                End Using
            End If

            ' Sfondo celle alternato a scacchi
            If chkSfondoAlternato.Checked Then
                If giorno Mod 2 = 0 Then
                    Using br As New SolidBrush(ColoreSfondoCelleAlternato1)
                        g.FillRectangle(br, x, y, cellaW, cellaH)
                    End Using
                Else
                    Using br As New SolidBrush(ColoreSfondoCelleAlternato2)
                        g.FillRectangle(br, x, y, cellaW, cellaH)
                    End Using
                End If
            End If

            ' Sfondo festività (priorità)
            If chkSfondoFeste.Checked AndAlso isFestivita Then
                Using br As New SolidBrush(ColoreSfondoFeste)
                    g.FillRectangle(br, x, y, cellaW, cellaH)
                End Using
            End If

            ' Sfondo domenica
            If chkSfondoDomeniche.Checked AndAlso isDomenica Then
                Using br As New SolidBrush(ColoreSfondoDomeniche)
                    g.FillRectangle(br, x, y, cellaW, cellaH)
                End Using
            End If

            ' Bordo cella
            g.DrawRectangle(New Pen(Brushes.LightGray, 2), x, y, cellaW, cellaH)

            ' Numero giorno
            Dim coloreNumero As Brush = Brushes.Black
            If isFestivita OrElse (CheckBoxDomeniche.Checked AndAlso isDomenica) Then
                coloreNumero = Brushes.Red
            Else
                If chkColorGiorniMese.Checked Then
                    coloreNumero = New SolidBrush(ColoreGiorniMese)
                End If
            End If
            g.DrawString(giorno.ToString(), fontNumeri, coloreNumero, x + 5, y + 5)
        Next

        ' Fasi lunari
        If chkFasiLunari.Checked Then
            Dim altezzaTotaleArea As Integer = cellaH * numRighe
            Dim fontlunare As New Font("Segoe UI", 15)
            Dim YLuna As Integer = AltezzaPaginaPixel - altezzaTotaleArea - 20
            Dim sizeLunaString As SizeF = g.MeasureString(output.ToString(), fontlunare)
            g.DrawString(output.ToString(), fontlunare, Brushes.Black, MargineSX + 10, YLuna)
            ' Immagine
            Dim segment As Integer
            Dim visibility1 = MoonPhase(anno, mese, 1, 18 + Now.Minute / 60.0, segment)
            Dim visibility5 = MoonPhase(anno, mese, 5, 18 + Now.Minute / 60.0, segment)
            Dim visibility10 = MoonPhase(anno, mese, 10, 18 + Now.Minute / 60.0, segment)
            Dim visibility15 = MoonPhase(anno, mese, 15, 18 + Now.Minute / 60.0, segment)
            Dim visibility20 = MoonPhase(anno, mese, 20, 18 + Now.Minute / 60.0, segment)
            Dim visibility25 = MoonPhase(anno, mese, 25, 18 + Now.Minute / 60.0, segment)

            'Render Luna
            For Lune As Integer = 0 To 5
                Select Case Lune
                    Case 0
                        Luna = DrawMoonPhase(visibility1)
                    Case 1
                        Luna = DrawMoonPhase(visibility5)
                    Case 2
                        Luna = DrawMoonPhase(visibility10)
                    Case 3
                        Luna = DrawMoonPhase(visibility15)
                    Case 4
                        Luna = DrawMoonPhase(visibility20)
                    Case 5
                        Luna = DrawMoonPhase(visibility25)
                End Select
                If Luna IsNot Nothing Then g.DrawImage(Luna, MargineSX + 10 + (Lune * 160), YLuna + sizeLunaString.Height + 10)
            Next
        End If

        ' Calendario Plus Solo Lune Piene
        If chkLunePiene.Checked AndAlso Not chkFasiLunari.Checked Then
            'Lune Piene
            Dim altezzaTotaleArea As Integer = cellaH * numRighe
            If Luna IsNot Nothing Then
                Dim LunaResized As Bitmap = New Bitmap(Luna, New Size(CInt(Luna.Width * 0.7), CInt(Luna.Height * 0.7)))
                g.DrawImage(LunaResized, New Point(MargineSX + 10, AltezzaPaginaPixel - LunaResized.Height - 20))
            End If
        End If

        ' ---- Nuovo: bordo esterno dell'area calendario ----
        Using penBordo As New Pen(Color.Black, 3)
            ' x e y iniziali dell'area
            Dim xArea As Integer = MargineSX
            Dim yArea As Integer = startY + fontGiorni.Height + 10
            ' larghezza e altezza totali dell'area
            Dim larghezzaArea As Integer = cellaW * 7
            Dim altezzaTotaleArea As Integer = cellaH * numRighe
            g.DrawRectangle(penBordo, xArea, yArea, larghezzaArea, altezzaTotaleArea)
        End Using

        ' Mostra nella picturebox
        pbCalendario.Image = bmp
        g.Dispose()
    End Sub


    Private Sub cmbLingua_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLingua.SelectedIndexChanged
        Dim meseAttuale As Integer = cmbMese.SelectedIndex
        RiempiMesi()
        cmbMese.SelectedIndex = meseAttuale
    End Sub

    Private Sub btnSfondoDomeniche_Click(sender As Object, e As EventArgs) Handles btnSfondoDomeniche.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            ColoreSfondoDomeniche = ColorDialog1.Color
            'DisegnaCalendario(cmbMese.SelectedIndex + 1, CInt(nudAnno.Value))
            btnAggiorna.PerformClick()
            'Sfondo pulsante
            btnSfondoDomeniche.BackColor = ColoreSfondoDomeniche
        End If
    End Sub

    Private Sub btnSfondoFeste_Click(sender As Object, e As EventArgs) Handles btnSfondoFeste.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            ColoreSfondoFeste = ColorDialog1.Color
            btnSfondoFeste.BackColor = ColoreSfondoFeste
            'DisegnaCalendario(cmbMese.SelectedIndex + 1, CInt(nudAnno.Value))
            btnAggiorna.PerformClick()
        End If
    End Sub

    Private Sub btnSalva_Click(sender As Object, e As EventArgs) Handles btnSalva.Click

        If pbCalendario.Image Is Nothing Then Exit Sub

        Dim sfd As New SaveFileDialog
        sfd.Filter = "Immagine Bitmap (*.bmp)|*.bmp|PNG (*.png)|*.png"

        Dim nomeFile As String = ""
        Dim titolo As String = ""

        Select Case VistaAttuale
            Case VistaCalendario.Mensile
                titolo = "Salva calendario mensile..."
                nomeFile = $"Calendario_{cmbMese.SelectedItem}_{nudAnno.Value}" & ".bmp"

            Case VistaCalendario.Settimanale
                titolo = "Salva calendario settimanale..."
                Dim inizioSettimana As Date = Date.Today.AddDays(-(CInt(Date.Today.DayOfWeek) + 6) Mod 7)
                nomeFile = $"Calendario_Settimana_{inizioSettimana:yyyyMMdd}" & ".bmp"

            Case VistaCalendario.GiorniConsecutivi
                titolo = "Salva calendario annuale..."
                nomeFile = $"Calendario_Anno_{nudAnno.Value}" & ".bmp"
        End Select

        sfd.Title = titolo
        sfd.FileName = nomeFile

        If sfd.ShowDialog(Me) = DialogResult.OK Then
            Try
                pbCalendario.Image.Save(sfd.FileName)
            Catch ex As Exception
                MessageBox.Show("Errore nel salvataggio: " & ex.Message)
            End Try
        End If

    End Sub


    Private Sub btnSfondoCelle_Click(sender As Object, e As EventArgs) Handles btnSfondoCelle.Click
        'Sfondo uniforme celle
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            ColoreSfondoCelle = ColorDialog1.Color
            btnSfondoCelle.BackColor = ColoreSfondoCelle
            'DisegnaCalendario(cmbMese.SelectedIndex + 1, CInt(nudAnno.Value))
            btnAggiorna.PerformClick()
        End If
    End Sub

    Private Sub btnSfondoUno_Click(sender As Object, e As EventArgs) Handles btnSfondoUno.Click
        'Colore alternato 1 a Scacchi
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            ColoreSfondoCelleAlternato1 = ColorDialog1.Color
            btnSfondoUno.BackColor = ColoreSfondoCelleAlternato1
            'DisegnaCalendario(cmbMese.SelectedIndex + 1, CInt(nudAnno.Value))
            btnAggiorna.PerformClick()
        End If
    End Sub

    Private Sub btnSfondoDue_Click(sender As Object, e As EventArgs) Handles btnSfondoDue.Click
        'Colore alternato 2 a Scacchi
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            ColoreSfondoCelleAlternato2 = ColorDialog1.Color
            btnSfondoDue.BackColor = ColoreSfondoCelleAlternato2
            'DisegnaCalendario(cmbMese.SelectedIndex + 1, CInt(nudAnno.Value))
            btnAggiorna.PerformClick()
        End If
    End Sub

    Private Sub btnBackImage_Click(sender As Object, e As EventArgs) Handles btnBackImage.Click
        'Immagine di sfondo calendario
        Dim ofd As OpenFileDialog = New OpenFileDialog
        ofd.FileName = ""
        ofd.Title = "Scegli una foto o immagine..."
        ofd.Filter = "Files immagini supportate|*.bmp;*.jpg;*.png;*.tif;*.gif"

        If ofd.ShowDialog(Me) = DialogResult.OK Then
            If File.Exists(ofd.FileName) Then
                If FileLen(ofd.FileName) > 0 Then
                    Dim backimage As Image = Image.FromFile(ofd.FileName)
                    ImmagineSfondo = New Bitmap(backimage)
                    backimage.Dispose()
                End If
            End If
        End If
    End Sub

    Private Sub btnColorTitolo_Click(sender As Object, e As EventArgs) Handles btnColorTitolo.Click
        ' Colore del titolo del mese
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            ColoreTitolo = ColorDialog1.Color
            btnColorTitolo.BackColor = ColoreTitolo
            'DisegnaCalendario(cmbMese.SelectedIndex + 1, CInt(nudAnno.Value))
            btnAggiorna.PerformClick()
        End If
    End Sub

    Private Sub btnColorGiorni_Click(sender As Object, e As EventArgs) Handles btnColorGiorni.Click
        ' Colore giorni della settimana
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            ColoreGiorniSettimana = ColorDialog1.Color
            btnColorGiorni.BackColor = ColoreGiorniSettimana
            'DisegnaCalendario(cmbMese.SelectedIndex + 1, CInt(nudAnno.Value))
            btnAggiorna.PerformClick()
        End If
    End Sub

    Private Sub btnColorGiorniMese_Click(sender As Object, e As EventArgs) Handles btnColorGiorniMese.Click
        ' Colore dei giorni del mese
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            ColoreGiorniMese = ColorDialog1.Color
            btnColorGiorniMese.BackColor = ColoreGiorniMese
            'DisegnaCalendario(cmbMese.SelectedIndex + 1, CInt(nudAnno.Value))
            btnAggiorna.PerformClick()
        End If
    End Sub



    Public Enum VistaCalendario
        Mensile
        Settimanale
        GiorniConsecutivi
    End Enum

    Private VistaAttuale As VistaCalendario = VistaCalendario.Mensile


    Private Sub DisegnaSettimana(dataRiferimento As Date)
        Dim inizioSettimana As Date = dataRiferimento.AddDays(-(CInt(dataRiferimento.DayOfWeek) + 6) Mod 7)

        Dim bmp As New Bitmap(LarghezzaPaginaPixel, AltezzaPaginaPixel)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.Clear(Color.White)

        Dim cellaW As Integer = (LarghezzaPaginaPixel - MargineSX * 2) \ 7
        Dim cellaH As Integer = (AltezzaPaginaPixel - 200) \ 1

        For i As Integer = 0 To 6
            Dim dataGiorno As Date = inizioSettimana.AddDays(i)
            Dim x As Integer = MargineSX + i * cellaW
            Dim y As Integer = 150

            g.DrawRectangle(Pens.Black, x, y, cellaW, cellaH)
            g.DrawString(dataGiorno.ToString("ddd dd"), New Font("Segoe UI", 14, FontStyle.Bold), New SolidBrush(ColoreGiorniMese), x + 5, y + 5)
        Next

        pbCalendario.Image = bmp
        g.Dispose()
    End Sub


    Private Sub DisegnaGiorniConsecutivi(anno As Integer)
        Dim startDate As New Date(anno, 1, 1)
        Dim giorniTotali As Integer = If(Date.IsLeapYear(anno), 366, 365)

        Dim colonne As Integer = 7
        Dim righe As Integer = Math.Ceiling(giorniTotali / colonne)

        Dim cellaW As Integer = (LarghezzaPaginaPixel - MargineSX * 2) \ colonne
        Dim cellaH As Integer = (AltezzaPaginaPixel - MargineTOP * 2) \ righe

        Dim bmp As New Bitmap(LarghezzaPaginaPixel, AltezzaPaginaPixel)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.Clear(Color.White)

        For i As Integer = 0 To giorniTotali - 1
            Dim dataCorrente As Date = startDate.AddDays(i)
            Dim col As Integer = i Mod colonne
            Dim row As Integer = i \ colonne

            Dim x As Integer = MargineSX + col * cellaW
            Dim y As Integer = MargineTOP + row * cellaH

            g.DrawRectangle(Pens.Gray, x, y, cellaW, cellaH)
            g.DrawString(dataCorrente.ToString("dd MMM"), New Font("Segoe UI", 9), New SolidBrush(ColoreGiorniMese), x + 3, y + 3)
        Next

        pbCalendario.Image = bmp
        g.Dispose()
    End Sub

    Private Sub cmbVista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVista.SelectedIndexChanged
        VistaAttuale = CType(cmbVista.SelectedIndex, VistaCalendario)
        AggiornaVista()
    End Sub

    Private Function CreaBitmapMese(mese As Integer, anno As Integer) As Bitmap
        Dim bmp As New Bitmap(LarghezzaPaginaPixel, AltezzaPaginaPixel)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.Clear(Color.White)

        'DPI
        bmp.SetResolution(300, 300)

        ' --- COPIA QUI IL CONTENUTO DI DisegnaCalendario ---
        ' sostituendo pbCalendario.Image = bmp
        ' e rimuovendo g.Dispose() alla fine
        ' Bitmap

        ' Immagine di sfondo calendario
        If chkBackImage.Checked Then
            Dim bmpSfondo As Bitmap = New Bitmap(ImmagineSfondo, New Size(LarghezzaPaginaPixel - MargineSX - MargineSX, AltezzaPaginaPixel - MargineTOP - MargineTOP))
            g.DrawImage(bmpSfondo, New Point(MargineSX, MargineTOP))
        End If

        ' Font
        Dim fontTitolo As New Font("Segoe UI", 42, FontStyle.Bold)
        Dim fontGiorni As New Font("Segoe UI", 24, FontStyle.Bold)
        Dim fontNumeri As New Font("Segoe UI", 22)

        ' Titolo (indipendente dalla UI)
        Dim nomeMese As String

        If cmbLingua.SelectedIndex = 0 Then
            nomeMese = MesiIT(mese - 1)
        Else
            nomeMese = MesiEN(mese - 1)
        End If

        Dim titolo As String = nomeMese & " " & anno
        Dim sizeTitolo As SizeF = g.MeasureString(titolo, fontTitolo)
        Dim posXTitolo As Single = (LarghezzaPaginaPixel - sizeTitolo.Width) / 2

        If chkColorTitolo.Checked Then
            Using brTitolo As New SolidBrush(ColoreTitolo)
                g.DrawString(titolo, fontTitolo, brTitolo, posXTitolo, MargineTOP)
            End Using
        Else
            g.DrawString(titolo, fontTitolo, Brushes.Black, posXTitolo, MargineTOP)
        End If

        ' Giorni della settimana
        Dim giorniSettimana() As String = If(cmbLingua.SelectedIndex = 0, giorniSettimanaIT, giorniSettimanaEN)
        Dim cellaW As Integer = (LarghezzaPaginaPixel - MargineSX * 2) \ 7
        Dim startY As Integer = MargineTOP + fontTitolo.Height + 20 ' spazio dopo titolo

        For i As Integer = 0 To 6
            If chkColorGiorni.Checked Then
                g.DrawString(giorniSettimana(i), fontGiorni, New SolidBrush(ColoreGiorniSettimana), MargineSX + i * cellaW + 5, startY)
            Else
                g.DrawString(giorniSettimana(i), fontGiorni, Brushes.Black, MargineSX + i * cellaW + 5, startY)
            End If
        Next

        ' Date
        Dim primoGiorno As New DateTime(anno, mese, 1)
        Dim giorniNelMese As Integer = DateTime.DaysInMonth(anno, mese)
        Dim offset As Integer = (CInt(primoGiorno.DayOfWeek) + 6) Mod 7 ' Lunedì = 0

        ' Area verticale disponibile
        Dim MargineBottom As Integer = 40
        Dim altezzaArea As Integer = AltezzaPaginaPixel - startY - fontGiorni.Height - MargineBottom - 20
        Dim numRighe As Integer = Math.Ceiling((giorniNelMese + offset) / 7.0)
        Dim cellaH As Integer = altezzaArea \ numRighe

        ' Fasi lunari
        Dim output As New Text.StringBuilder()
        Dim Luna As Bitmap = Nothing
        If chkFasiLunari.Checked Then
            ' === Riduciamo la cella
            cellaH = CInt(cellaH / 2)

            Dim now As DateTime = DateTime.Now
            Dim segment As Integer
            Dim visibility = MoonPhase(now.Year, now.Month, now.Day, now.Hour + now.Minute / 60.0, segment)

            'Render Luna
            Luna = DrawMoonPhase(visibility)

            Dim year As Integer = anno
            Dim month As Integer = mese
            Dim segmentMese As Integer

            output.AppendLine($"Fasi Lunari per il mese di {MonthName(month)} {year} - Fasi per il 1, 5, 10, 15, 20 e 25 del mese alle 18:00.")
            output.AppendLine("Data  Ora  Visibilità   Fase")
            output.AppendLine("───────────────────────────────────────────────────────────")

            For day = 1 To DateTime.DaysInMonth(year, month)
                Dim visibilityMese As Double = MoonPhase(year, month, day, 16.0, segmentMese)
                Dim perc As String = Math.Round(visibilityMese * 100, 1).ToString("00.0") & "%"
                Dim dataStr As String = $"{day:00}/{month:00}/{year}"
                Dim fase As String = MoonPhaseName(segmentMese)

                'Ogni 2 giorni vai a capo
                If day Mod 2 = 0 Then
                    output.Append($"{dataStr} 16:00   {perc}   {fase}" & vbTab & vbTab & vbTab)
                Else
                    output.AppendLine($"{dataStr} 16:00   {perc}   {fase}")
                End If
            Next
        End If

        ' Solo Lune Piene
        If chkLunePiene.Checked AndAlso Not chkFasiLunari.Checked Then
            ' === Riduciamo la cella
            cellaH = CInt(cellaH / 2)
            'Calendario solo lune piene
            Luna = DisegnaCalendarioLunePiene(mese, anno)
        End If

        ' Pasqua e Pasquetta
        Dim dataPasqua As Date = CalcolaPasqua(anno)
        Dim dataPasquetta As Date = dataPasqua.AddDays(1)

        ' Ciclo giorni
        For giorno As Integer = 1 To giorniNelMese
            Dim giornoSettimana As Integer = (giorno + offset - 1) Mod 7
            Dim x As Integer = MargineSX + giornoSettimana * cellaW
            Dim y As Integer = startY + fontGiorni.Height + 10 + ((giorno + offset - 1) \ 7) * cellaH

            Dim dataFesta As New Date(1, mese, giorno)
            Dim dataCorrente As New Date(anno, mese, giorno)
            Dim isFestivita As Boolean = chkFestivita.Checked AndAlso FestivitaIT.ContainsKey(dataFesta)
            Dim isDomenica As Boolean = giornoSettimana = 6

            ' Festività fisse
            If chkFestivita.Checked AndAlso FestivitaIT.ContainsKey(dataFesta) Then isFestivita = True
            ' Pasqua e Pasquetta
            If chkFestivita.Checked AndAlso (dataCorrente = dataPasqua OrElse dataCorrente = dataPasquetta) Then
                isFestivita = True
            End If

            ' Sfondo generico celle
            If chkSfondoCelle.Checked Then
                Using br As New SolidBrush(ColoreSfondoCelle)
                    g.FillRectangle(br, x, y, cellaW, cellaH)
                End Using
            End If

            ' Sfondo celle alternato a scacchi
            If chkSfondoAlternato.Checked Then
                If giorno Mod 2 = 0 Then
                    Using br As New SolidBrush(ColoreSfondoCelleAlternato1)
                        g.FillRectangle(br, x, y, cellaW, cellaH)
                    End Using
                Else
                    Using br As New SolidBrush(ColoreSfondoCelleAlternato2)
                        g.FillRectangle(br, x, y, cellaW, cellaH)
                    End Using
                End If
            End If

            ' Sfondo festività (priorità)
            If chkSfondoFeste.Checked AndAlso isFestivita Then
                Using br As New SolidBrush(ColoreSfondoFeste)
                    g.FillRectangle(br, x, y, cellaW, cellaH)
                End Using
            End If

            ' Sfondo domenica
            If chkSfondoDomeniche.Checked AndAlso isDomenica Then
                Using br As New SolidBrush(ColoreSfondoDomeniche)
                    g.FillRectangle(br, x, y, cellaW, cellaH)
                End Using
            End If

            ' Bordo cella
            g.DrawRectangle(New Pen(Brushes.LightGray, 2), x, y, cellaW, cellaH)

            ' Numero giorno
            Dim coloreNumero As Brush = Brushes.Black
            If isFestivita OrElse (CheckBoxDomeniche.Checked AndAlso isDomenica) Then
                coloreNumero = Brushes.Red
            Else
                If chkColorGiorniMese.Checked Then
                    coloreNumero = New SolidBrush(ColoreGiorniMese)
                End If
            End If
            g.DrawString(giorno.ToString(), fontNumeri, coloreNumero, x + 5, y + 5)
        Next

        ' Fasi lunari
        If chkFasiLunari.Checked Then
            Dim altezzaTotaleArea As Integer = cellaH * numRighe
            Dim fontlunare As New Font("Segoe UI", 15)
            Dim YLuna As Integer = AltezzaPaginaPixel - altezzaTotaleArea - 20
            Dim sizeLunaString As SizeF = g.MeasureString(output.ToString(), fontlunare)
            g.DrawString(output.ToString(), fontlunare, Brushes.Black, MargineSX + 10, YLuna)
            ' Immagine
            Dim segment As Integer
            Dim visibility1 = MoonPhase(anno, mese, 1, 18 + Now.Minute / 60.0, segment)
            Dim visibility5 = MoonPhase(anno, mese, 5, 18 + Now.Minute / 60.0, segment)
            Dim visibility10 = MoonPhase(anno, mese, 10, 18 + Now.Minute / 60.0, segment)
            Dim visibility15 = MoonPhase(anno, mese, 15, 18 + Now.Minute / 60.0, segment)
            Dim visibility20 = MoonPhase(anno, mese, 20, 18 + Now.Minute / 60.0, segment)
            Dim visibility25 = MoonPhase(anno, mese, 25, 18 + Now.Minute / 60.0, segment)

            'Render Luna
            For Lune As Integer = 0 To 5
                Select Case Lune
                    Case 0
                        Luna = DrawMoonPhase(visibility1)
                    Case 1
                        Luna = DrawMoonPhase(visibility5)
                    Case 2
                        Luna = DrawMoonPhase(visibility10)
                    Case 3
                        Luna = DrawMoonPhase(visibility15)
                    Case 4
                        Luna = DrawMoonPhase(visibility20)
                    Case 5
                        Luna = DrawMoonPhase(visibility25)
                End Select
                If Luna IsNot Nothing Then g.DrawImage(Luna, MargineSX + 10 + (Lune * 160), YLuna + sizeLunaString.Height + 10)
            Next
        End If

        ' Calendario Plus Solo Lune Piene
        If chkLunePiene.Checked AndAlso Not chkFasiLunari.Checked Then
            'Lune Piene
            Dim altezzaTotaleArea As Integer = cellaH * numRighe
            If Luna IsNot Nothing Then
                Dim LunaResized As Bitmap = New Bitmap(Luna, New Size(CInt(Luna.Width * 0.7), CInt(Luna.Height * 0.7)))
                g.DrawImage(LunaResized, New Point(MargineSX + 10, AltezzaPaginaPixel - LunaResized.Height - 20))
            End If
        End If

        ' ---- Nuovo: bordo esterno dell'area calendario ----
        Using penBordo As New Pen(Color.Black, 3)
            ' x e y iniziali dell'area
            Dim xArea As Integer = MargineSX
            Dim yArea As Integer = startY + fontGiorni.Height + 10
            ' larghezza e altezza totali dell'area
            Dim larghezzaArea As Integer = cellaW * 7
            Dim altezzaTotaleArea As Integer = cellaH * numRighe
            g.DrawRectangle(penBordo, xArea, yArea, larghezzaArea, altezzaTotaleArea)
        End Using

        ' Mostra nella picturebox
        'pbCalendario.Image = bmp

        g.Dispose()
        Return bmp
    End Function

    Private Sub SalvaAnnoInTiffMultipagina(anno As Integer, filePath As String)

        Dim encoderInfo As ImageCodecInfo =
        ImageCodecInfo.GetImageEncoders().First(Function(c) c.MimeType = "image/tiff")

        Dim encoder As Encoder = encoder.SaveFlag
        Dim encParams As New EncoderParameters(1)

        Dim immagini As New List(Of Bitmap)

        ' Genera tutti i mesi
        For mese As Integer = 1 To 12
            immagini.Add(CreaBitmapMese(mese, anno))
        Next

        ' Prima pagina
        encParams.Param(0) = New EncoderParameter(encoder, CLng(EncoderValue.MultiFrame))
        immagini(0).Save(filePath, encoderInfo, encParams)

        ' Pagine successive
        encParams.Param(0) = New EncoderParameter(encoder, CLng(EncoderValue.FrameDimensionPage))
        For i As Integer = 1 To immagini.Count - 1
            immagini(0).SaveAdd(immagini(i), encParams)
        Next

        ' Chiudi TIFF
        encParams.Param(0) = New EncoderParameter(encoder, CLng(EncoderValue.Flush))
        immagini(0).SaveAdd(encParams)

        ' Cleanup
        For Each bmp In immagini
            bmp.Dispose()
        Next

    End Sub

    Private Sub btnTiffAnno_Click(sender As Object, e As EventArgs) Handles btnTiffAnno.Click

        Dim sfd As New SaveFileDialog
        sfd.Filter = "TIFF multipagina (*.tif)|*.tif"
        sfd.FileName = $"Calendario_{nudAnno.Value}.tif"

        If sfd.ShowDialog() = DialogResult.OK Then
            SalvaAnnoInTiffMultipagina(CInt(nudAnno.Value), sfd.FileName)
            MessageBox.Show("TIFF multipagina creato correttamente!", "Calendario")
        End If
    End Sub

    'PDF
    Private MeseStampaCorrente As Integer
    Private AnnoStampaCorrente As Integer

    Private Sub btnStampaPDF_Click(sender As Object, e As EventArgs) Handles btnStampaPDF.Click
        Dim pd As New Printing.PrintDocument

        pd.PrinterSettings.PrinterName = "Microsoft Print to PDF"

        ' opzionale: orientamento verticale
        pd.DefaultPageSettings.Landscape = False

        AddHandler pd.PrintPage, AddressOf StampaPaginaCalendario

        MeseStampaCorrente = 1
        AnnoStampaCorrente = CInt(nudAnno.Value)

        Try
            pd.Print()
        Catch ex As Exception
            MessageBox.Show("Errore stampa PDF: " & ex.Message)
        End Try
    End Sub

    Private Sub StampaPaginaCalendario_OLD(sender As Object, e As Printing.PrintPageEventArgs)
        ' Crea bitmap del mese corrente
        Using bmp As Bitmap = CreaBitmapMese(MeseStampaCorrente, AnnoStampaCorrente)

            ' Adatta alla pagina
            Dim rect As Rectangle = e.MarginBounds
            e.Graphics.DrawImage(bmp, rect)

        End Using

        ' Passa al mese successivo
        MeseStampaCorrente += 1

        ' Altre pagine?
        e.HasMorePages = (MeseStampaCorrente <= 12)
    End Sub

    Private Sub StampaPaginaCalendario(sender As Object, e As Printing.PrintPageEventArgs)

        Using bmp As Bitmap = CreaBitmapMese(MeseStampaCorrente, AnnoStampaCorrente)

            ' 1. Margini stampante
            Dim marginiStampante As Rectangle = e.MarginBounds

            ' 2. Margini interni della bitmap
            Dim bmpUsableWidth As Integer = LarghezzaPaginaPixel - MargineSX * 2
            Dim bmpUsableHeight As Integer = AltezzaPaginaPixel - MargineTOP - MargineBottom

            ' 3. Scala per adattare la bitmap all'area stampabile
            Dim scalaX As Single = marginiStampante.Width / bmpUsableWidth
            Dim scalaY As Single = marginiStampante.Height / bmpUsableHeight
            Dim scala As Single = Math.Min(scalaX, scalaY) ' mantiene proporzioni

            ' 4. Dimensione finale dell'immagine
            Dim widthFinal As Integer = CInt(LarghezzaPaginaPixel * scala)
            Dim heightFinal As Integer = CInt(AltezzaPaginaPixel * scala)

            ' 5. Centro sull'area stampabile
            Dim posX As Integer = marginiStampante.Left + (marginiStampante.Width - widthFinal) \ 2
            Dim posY As Integer = marginiStampante.Top + (marginiStampante.Height - heightFinal) \ 2

            ' 6. Disegna bitmap scalata e centrata
            e.Graphics.DrawImage(bmp, posX, posY, widthFinal, heightFinal)

        End Using

        ' Pagina successiva?
        MeseStampaCorrente += 1
        e.HasMorePages = (MeseStampaCorrente <= 12)
    End Sub


    ' Fasi lunari
    Private Function DrawMoonPhase(visibility As Double) As Bitmap
        Dim size As Integer = 100
        Dim bmp As New Bitmap(size, size)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.Clear(Color.Black)

        Dim rect As New Rectangle(0, 0, size, size)
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        ' Disegna la luna piena
        g.FillEllipse(Brushes.White, rect)

        ' Determina se la luna è crescente o calante
        Dim isWaxing As Boolean = visibility <= 0.5

        ' Calcola quanto scurire
        Dim darknessRatio As Double = 1 - 2 * Math.Abs(visibility - 0.5)

        ' Maschera scura
        Using blackBrush As New SolidBrush(Color.Black)
            Dim shadowWidth As Integer = CInt(size * darknessRatio)

            If isWaxing Then
                ' Ombra a sinistra (luna crescente)
                Dim shadowRect As New Rectangle(0, 0, shadowWidth, size)
                g.FillEllipse(blackBrush, shadowRect)
            Else
                ' Ombra a destra (luna calante)
                Dim shadowRect As New Rectangle(size - shadowWidth, 0, shadowWidth, size)
                g.FillEllipse(blackBrush, shadowRect)
            End If
        End Using

        Return bmp
    End Function

    Private Function DisegnaCalendarioLunePiene(mese As Integer, anno As Integer) As Bitmap
        Dim giorni = DateTime.DaysInMonth(anno, mese)
        Dim primoGiorno = New DateTime(anno, mese, 1)
        Dim startDay = (CInt(primoGiorno.DayOfWeek) + 6) Mod 7 ' Lunedì = 0, Domenica = 6

        Dim cellSize As Integer = 130
        Dim larghezza = 7 * cellSize
        Dim altezza = 7 * cellSize ' 1 riga per i giorni della settimana
        Dim bmp As New Bitmap(1000, 1000)

        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.White)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            Dim giorniSettimana = {"Lun", "Mar", "Mer", "Gio", "Ven", "Sab", "Dom"}
            Dim fontHeader As New Font("Arial", 18, FontStyle.Bold)
            Dim fontGiorno As New Font("Arial", 14)

            ' Intestazione giorni settimana
            For i = 0 To 6
                g.DrawString(giorniSettimana(i), fontHeader, Brushes.Black, 5 + i * cellSize + 10, 5)
            Next

            ' Griglia
            For r = 0 To 5
                For c = 0 To 6
                    g.DrawRectangle(Pens.Black, 5 + c * cellSize, (r + 1) * cellSize - 50, cellSize, cellSize)
                Next
            Next

            ' Giorni del mese + lune piene
            Dim giornoCorrente = 1
            Dim riga = 0
            Dim colonna = startDay

            While giornoCorrente <= giorni
                Dim x = colonna * cellSize
                Dim y = (riga + 1) * cellSize

                ' Scrivi numero giorno
                g.DrawString(giornoCorrente.ToString(), fontGiorno, Brushes.Black, 5 + x + 4, y + 4 - 50)

                ' Calcola fase lunare
                Dim fase As Integer
                Dim visibilita = MoonPhase(anno, mese, giornoCorrente, 16, fase)

                If fase = 4 Then
                    ' Luna piena
                    Dim raggio = 50
                    Dim cx = x + cellSize \ 2 + 5
                    Dim cy = y + cellSize \ 2 + 10 - 50
                    Dim rect = New Rectangle(cx - raggio \ 2, cy - raggio \ 2, raggio, raggio)
                    g.FillEllipse(Brushes.DarkGray, rect)
                    g.DrawEllipse(Pens.Black, rect)
                End If

                colonna += 1
                If colonna > 6 Then
                    colonna = 0
                    riga += 1
                End If

                giornoCorrente += 1
            End While
        End Using

        Return bmp
    End Function
End Class