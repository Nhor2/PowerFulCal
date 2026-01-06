<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pbCalendario = New System.Windows.Forms.PictureBox()
        Me.cmbMese = New System.Windows.Forms.ComboBox()
        Me.nudAnno = New System.Windows.Forms.NumericUpDown()
        Me.btnAggiorna = New System.Windows.Forms.Button()
        Me.cmbLingua = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBoxDomeniche = New System.Windows.Forms.CheckBox()
        Me.chkSfondoDomeniche = New System.Windows.Forms.CheckBox()
        Me.btnSfondoDomeniche = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.chkFestivita = New System.Windows.Forms.CheckBox()
        Me.chkSfondoFeste = New System.Windows.Forms.CheckBox()
        Me.btnSfondoFeste = New System.Windows.Forms.Button()
        Me.btnSalva = New System.Windows.Forms.Button()
        Me.chkSfondoCelle = New System.Windows.Forms.CheckBox()
        Me.btnSfondoCelle = New System.Windows.Forms.Button()
        Me.chkSfondoAlternato = New System.Windows.Forms.CheckBox()
        Me.btnSfondoUno = New System.Windows.Forms.Button()
        Me.btnSfondoDue = New System.Windows.Forms.Button()
        Me.chkBackImage = New System.Windows.Forms.CheckBox()
        Me.btnBackImage = New System.Windows.Forms.Button()
        Me.chkColorTitolo = New System.Windows.Forms.CheckBox()
        Me.btnColorTitolo = New System.Windows.Forms.Button()
        Me.btnColorGiorni = New System.Windows.Forms.Button()
        Me.chkColorGiorni = New System.Windows.Forms.CheckBox()
        Me.btnColorGiorniMese = New System.Windows.Forms.Button()
        Me.chkColorGiorniMese = New System.Windows.Forms.CheckBox()
        Me.cmbVista = New System.Windows.Forms.ComboBox()
        Me.btnTiffAnno = New System.Windows.Forms.Button()
        Me.btnStampaPDF = New System.Windows.Forms.Button()
        Me.chkFasiLunari = New System.Windows.Forms.CheckBox()
        Me.chkLunePiene = New System.Windows.Forms.CheckBox()
        CType(Me.pbCalendario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAnno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbCalendario
        '
        Me.pbCalendario.Location = New System.Drawing.Point(654, 88)
        Me.pbCalendario.Name = "pbCalendario"
        Me.pbCalendario.Size = New System.Drawing.Size(300, 400)
        Me.pbCalendario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbCalendario.TabIndex = 1
        Me.pbCalendario.TabStop = False
        '
        'cmbMese
        '
        Me.cmbMese.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMese.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMese.FormattingEnabled = True
        Me.cmbMese.Location = New System.Drawing.Point(29, 92)
        Me.cmbMese.Name = "cmbMese"
        Me.cmbMese.Size = New System.Drawing.Size(230, 32)
        Me.cmbMese.TabIndex = 2
        '
        'nudAnno
        '
        Me.nudAnno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudAnno.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudAnno.Location = New System.Drawing.Point(278, 93)
        Me.nudAnno.Name = "nudAnno"
        Me.nudAnno.Size = New System.Drawing.Size(120, 31)
        Me.nudAnno.TabIndex = 3
        '
        'btnAggiorna
        '
        Me.btnAggiorna.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAggiorna.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAggiorna.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAggiorna.Location = New System.Drawing.Point(419, 88)
        Me.btnAggiorna.Name = "btnAggiorna"
        Me.btnAggiorna.Size = New System.Drawing.Size(137, 38)
        Me.btnAggiorna.TabIndex = 4
        Me.btnAggiorna.Text = "Aggiorna"
        Me.btnAggiorna.UseVisualStyleBackColor = False
        '
        'cmbLingua
        '
        Me.cmbLingua.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbLingua.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLingua.FormattingEnabled = True
        Me.cmbLingua.Items.AddRange(New Object() {"Italiano", "Inglese"})
        Me.cmbLingua.Location = New System.Drawing.Point(29, 157)
        Me.cmbLingua.Name = "cmbLingua"
        Me.cmbLingua.Size = New System.Drawing.Size(230, 28)
        Me.cmbLingua.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(39, 141)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Lingua Mesi e Giorni"
        '
        'CheckBoxDomeniche
        '
        Me.CheckBoxDomeniche.AutoSize = True
        Me.CheckBoxDomeniche.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxDomeniche.ForeColor = System.Drawing.Color.White
        Me.CheckBoxDomeniche.Location = New System.Drawing.Point(42, 215)
        Me.CheckBoxDomeniche.Name = "CheckBoxDomeniche"
        Me.CheckBoxDomeniche.Size = New System.Drawing.Size(151, 20)
        Me.CheckBoxDomeniche.TabIndex = 7
        Me.CheckBoxDomeniche.Text = "Domeniche in Rosso"
        Me.CheckBoxDomeniche.UseVisualStyleBackColor = True
        '
        'chkSfondoDomeniche
        '
        Me.chkSfondoDomeniche.AutoSize = True
        Me.chkSfondoDomeniche.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSfondoDomeniche.ForeColor = System.Drawing.Color.White
        Me.chkSfondoDomeniche.Location = New System.Drawing.Point(213, 215)
        Me.chkSfondoDomeniche.Name = "chkSfondoDomeniche"
        Me.chkSfondoDomeniche.Size = New System.Drawing.Size(146, 20)
        Me.chkSfondoDomeniche.TabIndex = 8
        Me.chkSfondoDomeniche.Text = "Colore Sfondo DOM"
        Me.chkSfondoDomeniche.UseVisualStyleBackColor = True
        '
        'btnSfondoDomeniche
        '
        Me.btnSfondoDomeniche.BackColor = System.Drawing.Color.White
        Me.btnSfondoDomeniche.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSfondoDomeniche.Location = New System.Drawing.Point(388, 200)
        Me.btnSfondoDomeniche.Name = "btnSfondoDomeniche"
        Me.btnSfondoDomeniche.Size = New System.Drawing.Size(38, 35)
        Me.btnSfondoDomeniche.TabIndex = 9
        Me.btnSfondoDomeniche.Text = " "
        Me.btnSfondoDomeniche.UseVisualStyleBackColor = False
        '
        'chkFestivita
        '
        Me.chkFestivita.AutoSize = True
        Me.chkFestivita.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFestivita.ForeColor = System.Drawing.Color.White
        Me.chkFestivita.Location = New System.Drawing.Point(42, 253)
        Me.chkFestivita.Name = "chkFestivita"
        Me.chkFestivita.Size = New System.Drawing.Size(132, 20)
        Me.chkFestivita.TabIndex = 10
        Me.chkFestivita.Text = "Festività in Rosso"
        Me.chkFestivita.UseVisualStyleBackColor = True
        '
        'chkSfondoFeste
        '
        Me.chkSfondoFeste.AutoSize = True
        Me.chkSfondoFeste.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSfondoFeste.ForeColor = System.Drawing.Color.White
        Me.chkSfondoFeste.Location = New System.Drawing.Point(213, 253)
        Me.chkSfondoFeste.Name = "chkSfondoFeste"
        Me.chkSfondoFeste.Size = New System.Drawing.Size(159, 20)
        Me.chkSfondoFeste.TabIndex = 11
        Me.chkSfondoFeste.Text = "Colore Sfondo FESTE"
        Me.chkSfondoFeste.UseVisualStyleBackColor = True
        '
        'btnSfondoFeste
        '
        Me.btnSfondoFeste.BackColor = System.Drawing.Color.White
        Me.btnSfondoFeste.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSfondoFeste.Location = New System.Drawing.Point(388, 241)
        Me.btnSfondoFeste.Name = "btnSfondoFeste"
        Me.btnSfondoFeste.Size = New System.Drawing.Size(38, 35)
        Me.btnSfondoFeste.TabIndex = 12
        Me.btnSfondoFeste.Text = " "
        Me.btnSfondoFeste.UseVisualStyleBackColor = False
        '
        'btnSalva
        '
        Me.btnSalva.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalva.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalva.Location = New System.Drawing.Point(654, 494)
        Me.btnSalva.Name = "btnSalva"
        Me.btnSalva.Size = New System.Drawing.Size(137, 38)
        Me.btnSalva.TabIndex = 13
        Me.btnSalva.Text = "Salva"
        Me.btnSalva.UseVisualStyleBackColor = False
        '
        'chkSfondoCelle
        '
        Me.chkSfondoCelle.AutoSize = True
        Me.chkSfondoCelle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSfondoCelle.ForeColor = System.Drawing.Color.White
        Me.chkSfondoCelle.Location = New System.Drawing.Point(212, 290)
        Me.chkSfondoCelle.Name = "chkSfondoCelle"
        Me.chkSfondoCelle.Size = New System.Drawing.Size(156, 20)
        Me.chkSfondoCelle.TabIndex = 14
        Me.chkSfondoCelle.Text = "Colore Sfondo CELLE"
        Me.chkSfondoCelle.UseVisualStyleBackColor = True
        '
        'btnSfondoCelle
        '
        Me.btnSfondoCelle.BackColor = System.Drawing.Color.White
        Me.btnSfondoCelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSfondoCelle.Location = New System.Drawing.Point(388, 282)
        Me.btnSfondoCelle.Name = "btnSfondoCelle"
        Me.btnSfondoCelle.Size = New System.Drawing.Size(38, 35)
        Me.btnSfondoCelle.TabIndex = 15
        Me.btnSfondoCelle.Text = " "
        Me.btnSfondoCelle.UseVisualStyleBackColor = False
        '
        'chkSfondoAlternato
        '
        Me.chkSfondoAlternato.AutoSize = True
        Me.chkSfondoAlternato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSfondoAlternato.ForeColor = System.Drawing.Color.White
        Me.chkSfondoAlternato.Location = New System.Drawing.Point(42, 336)
        Me.chkSfondoAlternato.Name = "chkSfondoAlternato"
        Me.chkSfondoAlternato.Size = New System.Drawing.Size(212, 20)
        Me.chkSfondoAlternato.TabIndex = 16
        Me.chkSfondoAlternato.Text = "Colore Sfondo CELLE Alternato"
        Me.chkSfondoAlternato.UseVisualStyleBackColor = True
        '
        'btnSfondoUno
        '
        Me.btnSfondoUno.BackColor = System.Drawing.Color.White
        Me.btnSfondoUno.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSfondoUno.Location = New System.Drawing.Point(260, 328)
        Me.btnSfondoUno.Name = "btnSfondoUno"
        Me.btnSfondoUno.Size = New System.Drawing.Size(38, 35)
        Me.btnSfondoUno.TabIndex = 17
        Me.btnSfondoUno.Text = " "
        Me.btnSfondoUno.UseVisualStyleBackColor = False
        '
        'btnSfondoDue
        '
        Me.btnSfondoDue.BackColor = System.Drawing.Color.White
        Me.btnSfondoDue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSfondoDue.Location = New System.Drawing.Point(304, 328)
        Me.btnSfondoDue.Name = "btnSfondoDue"
        Me.btnSfondoDue.Size = New System.Drawing.Size(38, 35)
        Me.btnSfondoDue.TabIndex = 18
        Me.btnSfondoDue.Text = " "
        Me.btnSfondoDue.UseVisualStyleBackColor = False
        '
        'chkBackImage
        '
        Me.chkBackImage.AutoSize = True
        Me.chkBackImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBackImage.ForeColor = System.Drawing.Color.White
        Me.chkBackImage.Location = New System.Drawing.Point(388, 336)
        Me.chkBackImage.Name = "chkBackImage"
        Me.chkBackImage.Size = New System.Drawing.Size(159, 20)
        Me.chkBackImage.TabIndex = 19
        Me.chkBackImage.Text = "Immagine di SFONDO"
        Me.chkBackImage.UseVisualStyleBackColor = True
        '
        'btnBackImage
        '
        Me.btnBackImage.BackColor = System.Drawing.Color.White
        Me.btnBackImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBackImage.Location = New System.Drawing.Point(553, 328)
        Me.btnBackImage.Name = "btnBackImage"
        Me.btnBackImage.Size = New System.Drawing.Size(82, 35)
        Me.btnBackImage.TabIndex = 20
        Me.btnBackImage.Text = " Apri..."
        Me.btnBackImage.UseVisualStyleBackColor = False
        '
        'chkColorTitolo
        '
        Me.chkColorTitolo.AutoSize = True
        Me.chkColorTitolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkColorTitolo.ForeColor = System.Drawing.Color.White
        Me.chkColorTitolo.Location = New System.Drawing.Point(42, 391)
        Me.chkColorTitolo.Name = "chkColorTitolo"
        Me.chkColorTitolo.Size = New System.Drawing.Size(103, 20)
        Me.chkColorTitolo.TabIndex = 21
        Me.chkColorTitolo.Text = "Colore Titolo"
        Me.chkColorTitolo.UseVisualStyleBackColor = True
        '
        'btnColorTitolo
        '
        Me.btnColorTitolo.BackColor = System.Drawing.Color.White
        Me.btnColorTitolo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnColorTitolo.Location = New System.Drawing.Point(155, 383)
        Me.btnColorTitolo.Name = "btnColorTitolo"
        Me.btnColorTitolo.Size = New System.Drawing.Size(38, 35)
        Me.btnColorTitolo.TabIndex = 22
        Me.btnColorTitolo.Text = " "
        Me.btnColorTitolo.UseVisualStyleBackColor = False
        '
        'btnColorGiorni
        '
        Me.btnColorGiorni.BackColor = System.Drawing.Color.White
        Me.btnColorGiorni.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnColorGiorni.Location = New System.Drawing.Point(348, 383)
        Me.btnColorGiorni.Name = "btnColorGiorni"
        Me.btnColorGiorni.Size = New System.Drawing.Size(38, 35)
        Me.btnColorGiorni.TabIndex = 24
        Me.btnColorGiorni.Text = " "
        Me.btnColorGiorni.UseVisualStyleBackColor = False
        '
        'chkColorGiorni
        '
        Me.chkColorGiorni.AutoSize = True
        Me.chkColorGiorni.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkColorGiorni.ForeColor = System.Drawing.Color.White
        Me.chkColorGiorni.Location = New System.Drawing.Point(235, 391)
        Me.chkColorGiorni.Name = "chkColorGiorni"
        Me.chkColorGiorni.Size = New System.Drawing.Size(104, 20)
        Me.chkColorGiorni.TabIndex = 23
        Me.chkColorGiorni.Text = "Colore Giorni"
        Me.chkColorGiorni.UseVisualStyleBackColor = True
        '
        'btnColorGiorniMese
        '
        Me.btnColorGiorniMese.BackColor = System.Drawing.Color.White
        Me.btnColorGiorniMese.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnColorGiorniMese.Location = New System.Drawing.Point(578, 383)
        Me.btnColorGiorniMese.Name = "btnColorGiorniMese"
        Me.btnColorGiorniMese.Size = New System.Drawing.Size(38, 35)
        Me.btnColorGiorniMese.TabIndex = 26
        Me.btnColorGiorniMese.Text = " "
        Me.btnColorGiorniMese.UseVisualStyleBackColor = False
        '
        'chkColorGiorniMese
        '
        Me.chkColorGiorniMese.AutoSize = True
        Me.chkColorGiorniMese.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkColorGiorniMese.ForeColor = System.Drawing.Color.White
        Me.chkColorGiorniMese.Location = New System.Drawing.Point(427, 391)
        Me.chkColorGiorniMese.Name = "chkColorGiorniMese"
        Me.chkColorGiorniMese.Size = New System.Drawing.Size(145, 20)
        Me.chkColorGiorniMese.TabIndex = 25
        Me.chkColorGiorniMese.Text = "Colore Giorni MESE"
        Me.chkColorGiorniMese.UseVisualStyleBackColor = True
        '
        'cmbVista
        '
        Me.cmbVista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbVista.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVista.FormattingEnabled = True
        Me.cmbVista.Items.AddRange(New Object() {"Mensile", "Settimanale", "GiorniConsecutivi"})
        Me.cmbVista.Location = New System.Drawing.Point(694, 54)
        Me.cmbVista.Name = "cmbVista"
        Me.cmbVista.Size = New System.Drawing.Size(230, 28)
        Me.cmbVista.TabIndex = 27
        '
        'btnTiffAnno
        '
        Me.btnTiffAnno.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnTiffAnno.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTiffAnno.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTiffAnno.Location = New System.Drawing.Point(654, 538)
        Me.btnTiffAnno.Name = "btnTiffAnno"
        Me.btnTiffAnno.Size = New System.Drawing.Size(137, 38)
        Me.btnTiffAnno.TabIndex = 28
        Me.btnTiffAnno.Text = "Tutto..."
        Me.btnTiffAnno.UseVisualStyleBackColor = False
        '
        'btnStampaPDF
        '
        Me.btnStampaPDF.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnStampaPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStampaPDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStampaPDF.Location = New System.Drawing.Point(817, 538)
        Me.btnStampaPDF.Name = "btnStampaPDF"
        Me.btnStampaPDF.Size = New System.Drawing.Size(137, 38)
        Me.btnStampaPDF.TabIndex = 29
        Me.btnStampaPDF.Text = "PDF..."
        Me.btnStampaPDF.UseVisualStyleBackColor = False
        '
        'chkFasiLunari
        '
        Me.chkFasiLunari.AutoSize = True
        Me.chkFasiLunari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFasiLunari.ForeColor = System.Drawing.Color.White
        Me.chkFasiLunari.Location = New System.Drawing.Point(39, 444)
        Me.chkFasiLunari.Name = "chkFasiLunari"
        Me.chkFasiLunari.Size = New System.Drawing.Size(91, 20)
        Me.chkFasiLunari.TabIndex = 30
        Me.chkFasiLunari.Text = "Fasi Lunari"
        Me.chkFasiLunari.UseVisualStyleBackColor = True
        '
        'chkLunePiene
        '
        Me.chkLunePiene.AutoSize = True
        Me.chkLunePiene.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLunePiene.ForeColor = System.Drawing.Color.White
        Me.chkLunePiene.Location = New System.Drawing.Point(235, 444)
        Me.chkLunePiene.Name = "chkLunePiene"
        Me.chkLunePiene.Size = New System.Drawing.Size(174, 20)
        Me.chkLunePiene.TabIndex = 31
        Me.chkLunePiene.Text = "Calendario LUNE PIENE"
        Me.chkLunePiene.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(966, 617)
        Me.Controls.Add(Me.chkLunePiene)
        Me.Controls.Add(Me.chkFasiLunari)
        Me.Controls.Add(Me.btnStampaPDF)
        Me.Controls.Add(Me.btnTiffAnno)
        Me.Controls.Add(Me.cmbVista)
        Me.Controls.Add(Me.btnColorGiorniMese)
        Me.Controls.Add(Me.chkColorGiorniMese)
        Me.Controls.Add(Me.btnColorGiorni)
        Me.Controls.Add(Me.chkColorGiorni)
        Me.Controls.Add(Me.btnColorTitolo)
        Me.Controls.Add(Me.chkColorTitolo)
        Me.Controls.Add(Me.btnBackImage)
        Me.Controls.Add(Me.chkBackImage)
        Me.Controls.Add(Me.btnSfondoDue)
        Me.Controls.Add(Me.btnSfondoUno)
        Me.Controls.Add(Me.chkSfondoAlternato)
        Me.Controls.Add(Me.btnSfondoCelle)
        Me.Controls.Add(Me.chkSfondoCelle)
        Me.Controls.Add(Me.btnSalva)
        Me.Controls.Add(Me.btnSfondoFeste)
        Me.Controls.Add(Me.chkSfondoFeste)
        Me.Controls.Add(Me.chkFestivita)
        Me.Controls.Add(Me.btnSfondoDomeniche)
        Me.Controls.Add(Me.chkSfondoDomeniche)
        Me.Controls.Add(Me.CheckBoxDomeniche)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbLingua)
        Me.Controls.Add(Me.btnAggiorna)
        Me.Controls.Add(Me.nudAnno)
        Me.Controls.Add(Me.cmbMese)
        Me.Controls.Add(Me.pbCalendario)
        Me.Name = "Form1"
        Me.Text = "PowerfulCal"
        CType(Me.pbCalendario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAnno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbCalendario As PictureBox
    Friend WithEvents cmbMese As ComboBox
    Friend WithEvents nudAnno As NumericUpDown
    Friend WithEvents btnAggiorna As Button
    Friend WithEvents cmbLingua As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckBoxDomeniche As CheckBox
    Friend WithEvents chkSfondoDomeniche As CheckBox
    Friend WithEvents btnSfondoDomeniche As Button
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents chkFestivita As CheckBox
    Friend WithEvents chkSfondoFeste As CheckBox
    Friend WithEvents btnSfondoFeste As Button
    Friend WithEvents btnSalva As Button
    Friend WithEvents chkSfondoCelle As CheckBox
    Friend WithEvents btnSfondoCelle As Button
    Friend WithEvents chkSfondoAlternato As CheckBox
    Friend WithEvents btnSfondoUno As Button
    Friend WithEvents btnSfondoDue As Button
    Friend WithEvents chkBackImage As CheckBox
    Friend WithEvents btnBackImage As Button
    Friend WithEvents chkColorTitolo As CheckBox
    Friend WithEvents btnColorTitolo As Button
    Friend WithEvents btnColorGiorni As Button
    Friend WithEvents chkColorGiorni As CheckBox
    Friend WithEvents btnColorGiorniMese As Button
    Friend WithEvents chkColorGiorniMese As CheckBox
    Friend WithEvents cmbVista As ComboBox
    Friend WithEvents btnTiffAnno As Button
    Friend WithEvents btnStampaPDF As Button
    Friend WithEvents chkFasiLunari As CheckBox
    Friend WithEvents chkLunePiene As CheckBox
End Class
