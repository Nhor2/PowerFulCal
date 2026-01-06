Module MoonPhaseCalculator

    'http://www.voidware.com/moon_phase.htm

    Const PI As Double = 3.1415926535897931
    Const RAD As Double = PI / 180.0
    Const SMALL_FLOAT As Double = 0.000000000001

    Public Function Julian(year As Integer, month As Integer, day As Double) As Double
        Dim a, b, c, e As Integer
        If month < 3 Then
            year -= 1
            month += 12
        End If

        If year > 1582 OrElse (year = 1582 AndAlso month > 10) OrElse (year = 1582 AndAlso month = 10 AndAlso day > 15) Then
            a = year \ 100
            b = 2 - a + (a \ 4)
        Else
            b = 0
        End If

        c = Fix(365.25 * year)
        e = Fix(30.6001 * (month + 1))
        Return b + c + e + day + 1720994.5
    End Function

    Public Function SunPosition(j As Double) As Double
        Dim n, x, e, dl, v, l As Double
        Dim i As Integer

        n = 360 / 365.2422 * j
        i = Fix(n / 360)
        n = n - i * 360.0
        x = n - 3.762863
        If x < 0 Then x += 360
        x *= RAD
        e = x

        Do
            dl = e - 0.016718 * Math.Sin(e) - x
            e -= dl / (1 - 0.016718 * Math.Cos(e))
        Loop While Math.Abs(dl) >= SMALL_FLOAT

        v = 360 / PI * Math.Atan(1.01686011182 * Math.Tan(e / 2))
        l = v + 282.596403
        i = Fix(l / 360)
        l -= i * 360.0
        Return l
    End Function

    Public Function MoonPosition(j As Double, ls As Double) As Double
        Dim ms, l, mm, n, ev, sms, ae, ec, x, lm As Double
        Dim i As Integer

        ms = 0.985647332099 * j - 3.762863
        If ms < 0 Then ms += 360.0

        l = 13.176396 * j + 64.975464
        i = Fix(l / 360)
        l -= i * 360.0
        If l < 0 Then l += 360.0

        mm = l - 0.1114041 * j - 349.383063
        i = Fix(mm / 360)
        mm -= i * 360.0

        n = 151.950429 - 0.0529539 * j
        i = Fix(n / 360)
        n -= i * 360.0

        ev = 1.2739 * Math.Sin((2 * (l - ls) - mm) * RAD)
        sms = Math.Sin(ms * RAD)
        ae = 0.1858 * sms
        mm += ev - ae - 0.37 * sms

        ec = 6.2886 * Math.Sin(mm * RAD)
        l += ev + ec - ae + 0.214 * Math.Sin(2 * mm * RAD)

        lm = l + 0.6583 * Math.Sin(2 * (l - ls) * RAD)
        Return lm
    End Function

    ''' <summary>
    ''' Calcola la fase lunare per una data specifica.
    ''' </summary>
    ''' <param name="year"></param>
    ''' <param name="month"></param>
    ''' <param name="day"></param>
    ''' <param name="hour">Ora decimale (es. 13.5 = 13:30)</param>
    ''' <param name="segment">OUT: indice segmento (0=Nuova, 4=Piena, ecc.)</param>
    ''' <returns>Percentuale visibile (0..1)</returns>
    Public Function MoonPhase(year As Integer, month As Integer, day As Integer, hour As Double, ByRef segment As Integer) As Double
        Dim j As Double = Julian(year, month, day + hour / 24.0) - 2444238.5
        Dim ls As Double = SunPosition(j)
        Dim lm As Double = MoonPosition(j, ls)

        Dim t As Double = lm - ls
        If t < 0 Then t += 360
        segment = CInt((t + 22.5) / 45) And 7

        Return (1.0 - Math.Cos((lm - ls) * RAD)) / 2
    End Function

    ''' <summary>
    ''' Restituisce il nome fase lunare in base al segmento (0-7)
    ''' </summary>
    Public Function MoonPhaseName(segment As Integer) As String
        Select Case segment
            Case 0 : Return "Luna Nuova"
            Case 1 : Return "Luna Crescente"
            Case 2 : Return "Primo Quarto"
            Case 3 : Return "Gibbosa Cresc."
            Case 4 : Return "Luna Piena"
            Case 5 : Return "Gibbosa Calante"
            Case 6 : Return "Ultimo Quarto"
            Case 7 : Return "Luna Calante"
            Case Else : Return "Sconosciuto"
        End Select
    End Function

End Module