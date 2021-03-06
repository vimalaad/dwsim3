﻿'    DWSIM Excel Interface Shared Methods
'    Copyright 2011 Daniel Wagner O. de Medeiros
'
'    This file is part of DWSIM.
'
'    DWSIM is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    DWSIM is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with DWSIM.  If not, see <http://www.gnu.org/licenses/>.

'    Using ExcelDNA library
'    Copyright (C) 2005-2011 Govert van Drimmelen

Imports ExcelDna.Integration
Imports DWSIM.DWSIM.SimulationObjects
Imports DWSIM.DWSIM.SimulationObjects.PropertyPackages
Imports DWSIM.DWSIM.ClassesBasicasTermodinamica

Namespace Interfaces

    Public Class ExcelIntegration

        Public Shared Sub SetIP(ByVal proppack As String, ByVal pp As PropertyPackage, ByVal compounds As Object, ByVal ip1 As Object, ByVal ip2 As Object,
                                ByVal ip3 As Object, ByVal ip4 As Object, ByVal ip5 As Object, ByVal ip6 As Object,
                                ByVal ip7 As Object, ByVal ip8 As Object)

            Dim i, j As Integer

            Select Case proppack
                Case "PC-SAFT"
                    With CType(pp, PCSAFTPropertyPackage).m_pr.InteractionParameters
                        If Not TypeOf ip1 Is ExcelMissing And Not ip1 Is Nothing Then
                            .Clear()
                            i = 0
                            For Each c1 As String In compounds
                                If Not .ContainsKey(pp._availablecomps(c1).CAS_Number) Then .Add(pp._availablecomps(c1).CAS_Number, New Dictionary(Of String, Auxiliary.PCSIP))
                                j = 0
                                For Each c2 As String In compounds
                                    If Not .Item(pp._availablecomps(c1).CAS_Number).ContainsKey(pp._availablecomps(c2).CAS_Number) Then .Item(pp._availablecomps(c1).CAS_Number).Add(pp._availablecomps(c2).CAS_Number, New Auxiliary.PCSIP())
                                    With .Item(pp._availablecomps(c1).CAS_Number).Item(pp._availablecomps(c2).CAS_Number)
                                        .casno1 = pp._availablecomps(c1).CAS_Number
                                        .casno2 = pp._availablecomps(c2).CAS_Number
                                        .compound1 = c1
                                        .compound2 = c2
                                        .kij = ip1(i, j)
                                    End With
                                    j += 1
                                Next
                                i += 1
                            Next
                        End If
                    End With
                Case "Peng-Robinson (PR)"
                    With CType(pp, PengRobinsonPropertyPackage).m_pr.InteractionParameters
                        If Not TypeOf ip1 Is ExcelMissing And Not ip1 Is Nothing Then
                            .Clear()
                            i = 0
                            For Each c1 As String In compounds
                                If Not .ContainsKey(c1) Then .Add(c1, New Dictionary(Of String, Auxiliary.PR_IPData))
                                j = 0
                                For Each c2 As String In compounds
                                    If Not .Item(c1).ContainsKey(c2) Then .Item(c1).Add(c2, New Auxiliary.PR_IPData())
                                    With .Item(c1).Item(c2)
                                        .kij = ip1(i, j)
                                    End With
                                    j += 1
                                Next
                                i += 1
                            Next
                        End If
                    End With
                Case "Peng-Robinson-Stryjek-Vera 2 (PRSV2)", "Peng-Robinson-Stryjek-Vera 2 (PRSV2-M)"
                    With CType(pp, PRSV2PropertyPackage).m_pr.InteractionParameters
                        If Not TypeOf ip1 Is ExcelMissing And Not ip1 Is Nothing Then
                            .Clear()
                            i = 0
                            For Each c1 As String In compounds
                                If Not .ContainsKey(c1.ToLower) Then .Add(c1.ToLower, New Dictionary(Of String, Auxiliary.PRSV2_IPData))
                                j = 0
                                For Each c2 As String In compounds
                                    If Not .Item(c1.ToLower).ContainsKey(c2.ToLower) Then .Item(c1.ToLower).Add(c2.ToLower, New Auxiliary.PRSV2_IPData())
                                    With .Item(c1.ToLower).Item(c2.ToLower)
                                        .kij = ip1(i, j)
                                        .kji = ip2(i, j)
                                    End With
                                    j += 1
                                Next
                                i += 1
                            Next
                        End If
                    End With
                Case "Peng-Robinson-Stryjek-Vera 2 (PRSV2-VL)"
                    With CType(pp, PRSV2VLPropertyPackage).m_pr.InteractionParameters
                        If Not TypeOf ip1 Is ExcelMissing And Not ip1 Is Nothing Then
                            .Clear()
                            i = 0
                            For Each c1 As String In compounds
                                If Not .ContainsKey(c1.ToLower) Then .Add(c1.ToLower, New Dictionary(Of String, Auxiliary.PRSV2_IPData))
                                j = 0
                                For Each c2 As String In compounds
                                    If Not .Item(c1.ToLower).ContainsKey(c2.ToLower) Then .Item(c1.ToLower).Add(c2.ToLower, New Auxiliary.PRSV2_IPData())
                                    With .Item(c1.ToLower).Item(c2.ToLower)
                                        .kij = ip1(i, j)
                                        .kji = ip2(i, j)
                                    End With
                                    j += 1
                                Next
                                i += 1
                            Next
                        End If
                    End With
                Case "Soave-Redlich-Kwong (SRK)"
                    With CType(pp, SRKPropertyPackage).m_pr.InteractionParameters
                        If Not TypeOf ip1 Is ExcelMissing And Not ip1 Is Nothing Then
                            .Clear()
                            i = 0
                            For Each c1 As String In compounds
                                If Not .ContainsKey(c1) Then .Add(c1, New Dictionary(Of String, Auxiliary.PR_IPData))
                                j = 0
                                For Each c2 As String In compounds
                                    If Not .Item(c1).ContainsKey(c2) Then .Item(c1).Add(c2, New Auxiliary.PR_IPData())
                                    With .Item(c1).Item(c2)
                                        .kij = ip1(i, j)
                                    End With
                                    j += 1
                                Next
                                i += 1
                            Next
                        End If
                    End With
                Case "Peng-Robinson / Lee-Kesler (PR/LK)"
                    With CType(pp, PengRobinsonLKPropertyPackage).m_pr.InteractionParameters
                        If Not TypeOf ip1 Is ExcelMissing And Not ip1 Is Nothing Then
                            .Clear()
                            i = 0
                            For Each c1 As String In compounds
                                If Not .ContainsKey(c1) Then .Add(c1, New Dictionary(Of String, Auxiliary.PR_IPData))
                                j = 0
                                For Each c2 As String In compounds
                                    If Not .Item(c1).ContainsKey(c2) Then .Item(c1).Add(c2, New Auxiliary.PR_IPData())
                                    With .Item(c1).Item(c2)
                                        .kij = ip1(i, j)
                                    End With
                                    j += 1
                                Next
                                i += 1
                            Next
                        End If
                    End With
                Case "UNIFAC"
                    With CType(pp, UNIFACPropertyPackage).m_pr.InteractionParameters
                        If Not TypeOf ip1 Is ExcelMissing And Not ip1 Is Nothing Then
                            .Clear()
                            i = 0
                            For Each c1 As String In compounds
                                If Not .ContainsKey(c1) Then .Add(c1, New Dictionary(Of String, Auxiliary.PR_IPData))
                                j = 0
                                For Each c2 As String In compounds
                                    If Not .Item(c1).ContainsKey(c2) Then .Item(c1).Add(c2, New Auxiliary.PR_IPData())
                                    With .Item(c1).Item(c2)
                                        .kij = ip1(i, j)
                                    End With
                                    j += 1
                                Next
                                i += 1
                            Next
                        End If
                    End With
                Case "UNIFAC-LL"
                    With CType(pp, UNIFACLLPropertyPackage).m_pr.InteractionParameters
                        If Not TypeOf ip1 Is ExcelMissing And Not ip1 Is Nothing Then
                            .Clear()
                            i = 0
                            For Each c1 As String In compounds
                                If Not .ContainsKey(c1) Then .Add(c1, New Dictionary(Of String, Auxiliary.PR_IPData))
                                j = 0
                                For Each c2 As String In compounds
                                    If Not .Item(c1).ContainsKey(c2) Then .Item(c1).Add(c2, New Auxiliary.PR_IPData())
                                    With .Item(c1).Item(c2)
                                        .kij = ip1(i, j)
                                    End With
                                    j += 1
                                Next
                                i += 1
                            Next
                        End If
                    End With
                Case "NRTL"
                    With CType(pp, NRTLPropertyPackage).m_pr.InteractionParameters
                        If Not TypeOf ip1 Is ExcelMissing And Not ip1 Is Nothing Then
                            .Clear()
                            i = 0
                            For Each c1 As String In compounds
                                If Not .ContainsKey(c1) Then .Add(c1, New Dictionary(Of String, Auxiliary.PR_IPData))
                                j = 0
                                For Each c2 As String In compounds
                                    If Not .Item(c1).ContainsKey(c2) Then .Item(c1).Add(c2, New Auxiliary.PR_IPData())
                                    With .Item(c1).Item(c2)
                                        .kij = ip1(i, j)
                                    End With
                                    j += 1
                                Next
                                i += 1
                            Next
                        End If
                    End With
                    With CType(pp, NRTLPropertyPackage).m_uni.InteractionParameters
                        If Not TypeOf ip2 Is ExcelMissing And Not ip2 Is Nothing Then
                            .Clear()
                            i = 0
                            For Each c1 As String In compounds
                                If Not .ContainsKey(c1) Then .Add(c1, New Dictionary(Of String, Auxiliary.NRTL_IPData))
                                j = 0
                                For Each c2 As String In compounds
                                    If Not .Item(c1).ContainsKey(c2) Then .Item(c1).Add(c2, New Auxiliary.NRTL_IPData())
                                    With .Item(c1).Item(c2)
                                        .A12 = ip2(i, j)
                                        .A21 = ip3(i, j)
                                        .alpha12 = ip4(i, j)
                                        If Not TypeOf ip5 Is ExcelMissing And Not ip5 Is Nothing Then
                                            .B12 = ip5(i, j)
                                            .B21 = ip6(i, j)
                                            .C12 = ip7(i, j)
                                            .C21 = ip8(i, j)
                                        End If
                                    End With
                                    j += 1
                                Next
                                i += 1
                            Next
                        End If
                    End With
                Case "UNIQUAC"
                    With CType(pp, UNIQUACPropertyPackage).m_pr.InteractionParameters
                        If Not TypeOf ip1 Is ExcelMissing And Not ip1 Is Nothing Then
                            .Clear()
                            i = 0
                            For Each c1 As String In compounds
                                If Not .ContainsKey(c1) Then .Add(c1, New Dictionary(Of String, Auxiliary.PR_IPData))
                                j = 0
                                For Each c2 As String In compounds
                                    If Not .Item(c1).ContainsKey(c2) Then .Item(c1).Add(c2, New Auxiliary.PR_IPData())
                                    With .Item(c1).Item(c2)
                                        .kij = ip1(i, j)
                                    End With
                                    j += 1
                                Next
                                i += 1
                            Next
                        End If
                    End With
                    With CType(pp, UNIQUACPropertyPackage).m_uni.InteractionParameters
                        If Not TypeOf ip2 Is ExcelMissing And Not ip2 Is Nothing Then
                            .Clear()
                            i = 0
                            For Each c1 As String In compounds
                                If Not .ContainsKey(c1) Then .Add(c1, New Dictionary(Of String, Auxiliary.UNIQUAC_IPData))
                                j = 0
                                For Each c2 As String In compounds
                                    If Not .Item(c1).ContainsKey(c2) Then .Item(c1).Add(c2, New Auxiliary.UNIQUAC_IPData())
                                    With .Item(c1).Item(c2)
                                        .A12 = ip2(i, j)
                                        .A21 = ip3(i, j)
                                        If Not TypeOf ip5 Is ExcelMissing And Not ip5 Is Nothing Then
                                            .B12 = ip4(i, j)
                                            .B21 = ip5(i, j)
                                            .C12 = ip6(i, j)
                                            .C21 = ip7(i, j)
                                        End If
                                    End With
                                    j += 1
                                Next
                                i += 1
                            Next
                        End If
                    End With
                Case "Modified UNIFAC (Dortmund)"
                    With CType(pp, MODFACPropertyPackage).m_pr.InteractionParameters
                        If Not TypeOf ip1 Is ExcelMissing And Not ip1 Is Nothing Then
                            .Clear()
                            i = 0
                            For Each c1 As String In compounds
                                If Not .ContainsKey(c1) Then .Add(c1, New Dictionary(Of String, Auxiliary.PR_IPData))
                                j = 0
                                For Each c2 As String In compounds
                                    If Not .Item(c1).ContainsKey(c2) Then .Item(c1).Add(c2, New Auxiliary.PR_IPData())
                                    With .Item(c1).Item(c2)
                                        .kij = ip1(i, j)
                                    End With
                                    j += 1
                                Next
                                i += 1
                            Next
                        End If
                    End With
                Case "Lee-Kesler-Plöcker"
                    With CType(pp, LKPPropertyPackage).m_lk.InteractionParameters
                        If Not TypeOf ip1 Is ExcelMissing And Not ip1 Is Nothing Then
                            .Clear()
                            i = 0
                            For Each c1 As String In compounds
                                If Not .ContainsKey(c1) Then .Add(c1, New Dictionary(Of String, Auxiliary.LKP_IPData))
                                j = 0
                                For Each c2 As String In compounds
                                    If Not .Item(c1).ContainsKey(c2) Then .Item(c1).Add(c2, New Auxiliary.LKP_IPData())
                                    With .Item(c1).Item(c2)
                                        .ID1 = c1
                                        .ID2 = c2
                                        .kij = ip1(i, j)
                                    End With
                                    j += 1
                                Next
                                i += 1
                            Next
                        End If
                    End With
                Case "COSMO-SAC (JCOSMO)"
                    With CType(pp, COSMOSACPropertyPackage).m_pr.InteractionParameters
                        If Not TypeOf ip1 Is ExcelMissing And Not ip1 Is Nothing Then
                            .Clear()
                            i = 0
                            For Each c1 As String In compounds
                                If Not .ContainsKey(c1) Then .Add(c1, New Dictionary(Of String, Auxiliary.PR_IPData))
                                j = 0
                                For Each c2 As String In compounds
                                    If Not .Item(c1).ContainsKey(c2) Then .Item(c1).Add(c2, New Auxiliary.PR_IPData())
                                    With .Item(c1).Item(c2)
                                        .kij = ip1(i, j)
                                    End With
                                    j += 1
                                Next
                                i += 1
                            Next
                        End If
                    End With
                Case "Chao-Seader"
                Case "Grayson-Streed"
                Case "IAPWS-IF97 Steam Tables"
                Case "Raoult's Law"
            End Select

        End Sub

        <ExcelFunction("Returns a single property value for a compound.")> _
        Public Shared Function GetCompoundProp( _
            <ExcelArgument("Compound name.")> ByVal compound As String, _
            <ExcelArgument("Property identifier.")> ByVal prop As String, _
            <ExcelArgument("Temperature in K, if needed.")> ByVal temperature As Double, _
            <ExcelArgument("Pressure in Pa, if needed.")> ByVal pressure As Double) As Double

            Try

                Dim pp As New RaoultPropertyPackage(True)

                Dim ms As New Streams.MaterialStream("", "")

                For Each phase As DWSIM.ClassesBasicasTermodinamica.Fase In ms.Fases.Values
                    phase.Componentes.Add(compound, New DWSIM.ClassesBasicasTermodinamica.Substancia(compound, ""))
                    phase.Componentes(compound).ConstantProperties = pp._availablecomps(compound)
                Next

                Dim tmpcomp As ConstantProperties = pp._availablecomps(compound)
                pp._selectedcomps.Add(compound, tmpcomp)
                pp._availablecomps.Remove(compound)

                ms._pp = pp
                pp.SetMaterial(ms)

                Dim results As Object = Nothing

                If pressure <> 0.0# And temperature = 0.0# Then
                    ms.GetPDependentProperty(New Object() {prop}, pressure, New Object() {compound}, results)
                ElseIf pressure = 0.0# And temperature <> 0.0# Then
                    ms.GetTDependentProperty(New Object() {prop}, temperature, New Object() {compound}, results)
                Else
                    results = ms.GetCompoundConstant(New Object() {prop}, New Object() {compound})
                End If

                Return results(0)

                pp.Dispose()
                pp = Nothing

                ms.Dispose()
                ms = Nothing

            Catch ex As Exception

                Return Double.NegativeInfinity

            End Try
        End Function

        <ExcelFunction("Returns a list of the available single compound properties.")> _
        Public Shared Function GetCompoundPropList() As Object(,)

            Dim pp As New RaoultPropertyPackage(True)

            Dim props As New ArrayList

            props.AddRange(pp.GetConstPropList())
            props.AddRange(pp.GetPDependentPropList())
            props.AddRange(pp.GetTDependentPropList())

            pp.Dispose()
            pp = Nothing

            Dim values As Object() = props.ToArray

            Dim results2(values.Length - 1, 0) As Object
            Dim i As Integer

            For i = 0 To values.Length - 1
                results2(i, 0) = values(i)
            Next

            Return results2

        End Function

        <ExcelFunction("Calculates properties using the selected Property Package.")> _
        Public Shared Function CalcProp( _
        <ExcelArgument("The name of the Property Package to use.")> ByVal proppack As String, _
        <ExcelArgument("The property to calculate.")> ByVal prop As String, _
        <ExcelArgument("The returning basis of the properties: Mole, Mass or UNDEFINED.")> ByVal basis As String, _
        <ExcelArgument("The name of the phase to calculate properties from.")> ByVal phaselabel As String, _
        <ExcelArgument("The list of compounds to include.")> ByVal compounds As Object(), _
        <ExcelArgument("Temperature in K.")> ByVal temperature As Double, _
        <ExcelArgument("Pressure in Pa.")> ByVal pressure As Double, _
        <ExcelArgument("*Normalized* mole fractions of the compounds in the mixture.")> ByVal molefractions As Double(), _
        <ExcelArgument("Interaction Parameters Set #1.")> ByVal ip1 As Object, _
        <ExcelArgument("Interaction Parameters Set #2.")> ByVal ip2 As Object, _
        <ExcelArgument("Interaction Parameters Set #3.")> ByVal ip3 As Object, _
        <ExcelArgument("Interaction Parameters Set #4.")> ByVal ip4 As Object, _
        <ExcelArgument("Interaction Parameters Set #5.")> ByVal ip5 As Object, _
        <ExcelArgument("Interaction Parameters Set #6.")> ByVal ip6 As Object, _
        <ExcelArgument("Interaction Parameters Set #7.")> ByVal ip7 As Object, _
        <ExcelArgument("Interaction Parameters Set #8.")> ByVal ip8 As Object) As Object(,)

            Try

                Dim ppm As New CAPEOPENPropertyPackageManager()

                Dim pp As PropertyPackages.PropertyPackage = ppm.GetPropertyPackage(proppack)

                SetIP(proppack, pp, compounds, ip1, ip2, ip3, ip4, ip5, ip6, ip7, ip8)

                ppm.Dispose()
                ppm = Nothing

                Dim ms As New Streams.MaterialStream("", "")

                For Each phase As DWSIM.ClassesBasicasTermodinamica.Fase In ms.Fases.Values
                    For Each c As String In compounds
                        phase.Componentes.Add(c, New DWSIM.ClassesBasicasTermodinamica.Substancia(c, ""))
                        phase.Componentes(c).ConstantProperties = pp._availablecomps(c)
                    Next
                Next

                For Each c As String In compounds
                    Dim tmpcomp As ConstantProperties = pp._availablecomps(c)
                    pp._selectedcomps.Add(c, tmpcomp)
                    pp._availablecomps.Remove(c)
                Next

                Dim dwp As PropertyPackages.Fase = PropertyPackages.Fase.Mixture
                For Each pi As PropertyPackages.PhaseInfo In pp.PhaseMappings.Values
                    If pi.PhaseLabel = phaselabel Then dwp = pi.DWPhaseID
                Next

                ms.SetPhaseComposition(molefractions, dwp)
                ms.Fases(0).SPMProperties.temperature = temperature
                ms.Fases(0).SPMProperties.pressure = pressure

                ms._pp = pp
                pp.SetMaterial(ms)

                If prop.ToLower <> "molecularweight" Then
                    pp.CalcSinglePhaseProp(New Object() {prop}, phaselabel)
                End If

                Dim results As Double() = Nothing
                Dim allres As New ArrayList
                Dim i As Integer

                results = Nothing
                If prop.ToLower <> "molecularweight" Then
                    ms.GetSinglePhaseProp(prop, phaselabel, basis, results)
                Else
                    results = New Double() {pp.AUX_MMM(dwp)}
                End If
                For i = 0 To results.Length - 1
                    allres.Add(results(i))
                Next

                pp.Dispose()
                pp = Nothing

                ms.Dispose()
                ms = Nothing

                Dim values As Object() = allres.ToArray()

                Dim results2(values.Length - 1, 0) As Object

                For i = 0 To values.Length - 1
                    results2(i, 0) = values(i)
                Next

                Return results2

            Catch ex As Exception

                Return New Object(,) {{ex.GetType.ToString}, {ex.ToString}}

            End Try


        End Function

        <ExcelFunction("Returns a list of the available Property Packages.")> _
        Public Shared Function GetPropPackList() As Object(,)

            Dim ppm As New CAPEOPENPropertyPackageManager()

            Dim values As Object() = ppm.GetPropertyPackageList()

            Dim results2(values.Length - 1, 0) As Object
            Dim i As Integer

            For i = 0 To values.Length - 1
                results2(i, 0) = values(i)
            Next

            Return results2

            ppm.Dispose()
            ppm = Nothing

        End Function

        <ExcelFunction("Returns a list of the available properties.")> _
        Public Shared Function GetPropList( _
        <ExcelArgument("The name of the Property Package to use.")> ByVal proppack As String) As Object(,)

            Dim ppm As New CAPEOPENPropertyPackageManager()

            Dim pp As PropertyPackages.PropertyPackage = ppm.GetPropertyPackage(proppack)

            ppm.Dispose()
            ppm = Nothing

            Dim values As Object() = pp.GetSinglePhasePropList()

            Dim results2(values.Length - 1, 0) As Object
            Dim i As Integer

            For i = 0 To values.Length - 1
                results2(i, 0) = values(i)
            Next

            Return results2

            pp.Dispose()
            pp = Nothing

        End Function

        <ExcelFunction("Returns a list of the available phases.")> _
        Public Shared Function GetPhaseList( _
        <ExcelArgument("The name of the Property Package to use.")> ByVal proppack As String) As Object(,)

            Dim ppm As New CAPEOPENPropertyPackageManager()

            Dim pp As PropertyPackages.PropertyPackage = ppm.GetPropertyPackage(proppack)

            ppm.Dispose()
            ppm = Nothing

            Dim values As Object() = pp.GetPhaseList()

            Dim results2(values.Length - 1, 0) As Object
            Dim i As Integer

            For i = 0 To values.Length - 1
                results2(i, 0) = values(i)
            Next

            Return results2

            pp.Dispose()
            pp = Nothing

        End Function

        <ExcelFunction("Returns a list of the available compounds.")> _
        Public Shared Function GetCompoundList( _
        <ExcelArgument("The name of the Property Package to use.")> ByVal proppack As String) As Object(,)

            Dim ppm As New CAPEOPENPropertyPackageManager()

            Dim pp As PropertyPackages.PropertyPackage = ppm.GetPropertyPackage(proppack)

            ppm.Dispose()
            ppm = Nothing

            Dim comps As New ArrayList

            For Each c As ConstantProperties In pp._availablecomps.Values
                comps.Add(c.Name)
            Next

            pp.Dispose()
            pp = Nothing

            Dim values As Object() = comps.ToArray

            Dim results2(values.Length - 1, 0) As Object
            Dim i As Integer

            For i = 0 To values.Length - 1
                results2(i, 0) = values(i)
            Next

            Return results2

        End Function

        <ExcelFunction("Calculates a PT Flash using the selected Property Package.")> _
        Public Shared Function PTFlash( _
        <ExcelArgument("The name of the Property Package to use.")> ByVal proppack As String, _
        <ExcelArgument("The Flash Algorithm to use: 1 - Nested Loops, 2 - Inside Out, 3 - Three-Phase Inside Out")> ByVal flashalg As Integer, _
        <ExcelArgument("Pressure in Pa.")> ByVal P As Double, _
        <ExcelArgument("Temperature in K.")> ByVal T As Double, _
        <ExcelArgument("Compound names.")> ByVal compounds As Object(), _
        <ExcelArgument("Compound mole fractions.")> ByVal molefractions As Double(), _
        <ExcelArgument("Interaction Parameters Set #1.")> ByVal ip1 As Object, _
        <ExcelArgument("Interaction Parameters Set #2.")> ByVal ip2 As Object, _
        <ExcelArgument("Interaction Parameters Set #3.")> ByVal ip3 As Object, _
        <ExcelArgument("Interaction Parameters Set #4.")> ByVal ip4 As Object, _
        <ExcelArgument("Interaction Parameters Set #5.")> ByVal ip5 As Object, _
        <ExcelArgument("Interaction Parameters Set #6.")> ByVal ip6 As Object, _
        <ExcelArgument("Interaction Parameters Set #7.")> ByVal ip7 As Object, _
        <ExcelArgument("Interaction Parameters Set #8.")> ByVal ip8 As Object) As Object(,)

            Try

                Dim ppm As New CAPEOPENPropertyPackageManager()

                Dim pp As PropertyPackages.PropertyPackage

                pp = ppm.GetPropertyPackage(proppack)
                SetIP(proppack, pp, compounds, ip1, ip2, ip3, ip4, ip5, ip6, ip7, ip8)

                ppm.Dispose()
                ppm = Nothing

                Dim ms As New Streams.MaterialStream("", "")

                For Each phase As DWSIM.ClassesBasicasTermodinamica.Fase In ms.Fases.Values
                    For Each c As String In compounds
                        phase.Componentes.Add(c, New DWSIM.ClassesBasicasTermodinamica.Substancia(c, ""))
                        phase.Componentes(c).ConstantProperties = pp._availablecomps(c)
                    Next
                Next

                For Each c As String In compounds
                    Dim tmpcomp As ConstantProperties = pp._availablecomps(c)
                    If Not pp._selectedcomps.ContainsKey(c) Then pp._selectedcomps.Add(c, tmpcomp)
                    'pp._availablecomps.Remove(c)
                Next

                ms.SetOverallComposition(molefractions)
                ms.Fases(0).SPMProperties.temperature = T
                ms.Fases(0).SPMProperties.pressure = P

                ms._pp = pp
                pp.SetMaterial(ms)

                Select Case flashalg
                    Case 1
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.DWSIMDefault
                    Case 2
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut
                    Case 3
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut3P
                End Select

                pp._ioquick = False
                pp._tpseverity = 2
                Dim comps(compounds.Length - 1) As String
                Dim k As Integer
                For Each c As String In compounds
                    comps(k) = c
                    k += 1
                Next
                pp._tpcompids = comps

                pp.CalcEquilibrium(ms, "TP", "UNDEFINED")

                Dim labels As String() = Nothing
                Dim statuses As CapeOpen.CapePhaseStatus() = Nothing

                ms.GetPresentPhases(labels, statuses)

                Dim fractions(compounds.Length + 1, labels.Length - 1) As Object

                Dim res As Object = Nothing

                Dim i, j As Integer
                i = 0
                For Each l As String In labels
                    If statuses(i) = CapeOpen.CapePhaseStatus.CAPE_ATEQUILIBRIUM Then
                        fractions(0, i) = labels(i)
                        ms.GetSinglePhaseProp("phasefraction", labels(i), "Mole", res)
                        fractions(1, i) = res(0)
                        ms.GetSinglePhaseProp("fraction", labels(i), "Mole", res)
                        For j = 0 To compounds.Length - 1
                            fractions(2 + j, i) = res(j)
                        Next
                    End If
                    i += 1
                Next

                If TypeOf proppack Is String Then
                    pp.Dispose()
                    pp = Nothing
                End If

                ms.Dispose()
                ms = Nothing

                Return fractions

            Catch ex As Exception

                Return New Object(,) {{ex.GetType.ToString}, {ex.ToString}}

            End Try

        End Function

        <ExcelFunction("Calculates a PH Flash using the selected Property Package.")> _
        Public Shared Function PHFlash( _
        <ExcelArgument("The name of the Property Package to use.")> ByVal proppack As String, _
        <ExcelArgument("The Flash Algorithm to use: 1 - Nested Loops, 2 - Inside Out, 3 - Three-Phase Inside Out")> ByVal flashalg As Integer, _
        <ExcelArgument("Pressure in Pa.")> ByVal P As Double, _
        <ExcelArgument("Mixture Mass Enthalpy in kJ/kg.")> ByVal H As Double, _
        <ExcelArgument("Compound names.")> ByVal compounds As Object(), _
        <ExcelArgument("Compound mole fractions.")> ByVal molefractions As Double(), _
        <ExcelArgument("Interaction Parameters Set #1.")> ByVal ip1 As Object, _
        <ExcelArgument("Interaction Parameters Set #2.")> ByVal ip2 As Object, _
        <ExcelArgument("Interaction Parameters Set #3.")> ByVal ip3 As Object, _
        <ExcelArgument("Interaction Parameters Set #4.")> ByVal ip4 As Object, _
        <ExcelArgument("Interaction Parameters Set #5.")> ByVal ip5 As Object, _
        <ExcelArgument("Interaction Parameters Set #6.")> ByVal ip6 As Object, _
        <ExcelArgument("Interaction Parameters Set #7.")> ByVal ip7 As Object, _
        <ExcelArgument("Interaction Parameters Set #8.")> ByVal ip8 As Object) As Object(,)

            Try

                Dim ppm As New CAPEOPENPropertyPackageManager()

                Dim pp As PropertyPackages.PropertyPackage

                pp = ppm.GetPropertyPackage(proppack)
                SetIP(proppack, pp, compounds, ip1, ip2, ip3, ip4, ip5, ip6, ip7, ip8)

                ppm.Dispose()
                ppm = Nothing

                Dim ms As New Streams.MaterialStream("", "")

                For Each phase As DWSIM.ClassesBasicasTermodinamica.Fase In ms.Fases.Values
                    For Each c As String In compounds
                        phase.Componentes.Add(c, New DWSIM.ClassesBasicasTermodinamica.Substancia(c, ""))
                        phase.Componentes(c).ConstantProperties = pp._availablecomps(c)
                    Next
                Next

                For Each c As String In compounds
                    Dim tmpcomp As ConstantProperties = pp._availablecomps(c)
                    If Not pp._selectedcomps.ContainsKey(c) Then pp._selectedcomps.Add(c, tmpcomp)
                    'pp._availablecomps.Remove(c)
                Next

                ms.SetOverallComposition(molefractions)
                ms.Fases(0).SPMProperties.enthalpy = H
                ms.Fases(0).SPMProperties.pressure = P

                ms._pp = pp
                pp.SetMaterial(ms)

                Select Case flashalg
                    Case 1
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.DWSIMDefault
                    Case 2
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut
                    Case 3
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut3P
                End Select

                pp._ioquick = False
                pp._tpseverity = 2
                Dim comps(compounds.Length - 1) As String
                Dim k As Integer
                For Each c As String In compounds
                    comps(k) = c
                    k += 1
                Next
                pp._tpcompids = comps

                pp.CalcEquilibrium(ms, "PH", "UNDEFINED")

                Dim labels As String() = Nothing
                Dim statuses As CapeOpen.CapePhaseStatus() = Nothing

                ms.GetPresentPhases(labels, statuses)

                Dim fractions(compounds.Length + 2, labels.Length - 1) As Object

                Dim res As Object = Nothing

                Dim i, j As Integer
                i = 0
                For Each l As String In labels
                    If statuses(i) = CapeOpen.CapePhaseStatus.CAPE_ATEQUILIBRIUM Then
                        fractions(0, i) = labels(i)
                        ms.GetSinglePhaseProp("phasefraction", labels(i), "Mole", res)
                        fractions(1, i) = res(0)
                        ms.GetSinglePhaseProp("fraction", labels(i), "Mole", res)
                        For j = 0 To compounds.Length - 1
                            fractions(2 + j, i) = res(j)
                        Next
                    End If
                    i += 1
                Next

                fractions(compounds.Length + 2, 0) = ms.Fases(0).SPMProperties.temperature.GetValueOrDefault

                If TypeOf proppack Is String Then
                    pp.Dispose()
                    pp = Nothing
                End If

                ms.Dispose()
                ms = Nothing

                Return fractions

            Catch ex As Exception

                Return New Object(,) {{ex.GetType.ToString}, {ex.ToString}}

            End Try

        End Function

        <ExcelFunction("Calculates a PS Flash using the selected Property Package.")> _
        Public Shared Function PSFlash( _
        <ExcelArgument("The name of the Property Package to use.")> ByVal proppack As String, _
        <ExcelArgument("The Flash Algorithm to use: 1 - Nested Loops, 2 - Inside Out, 3 - Three-Phase Inside Out")> ByVal flashalg As Integer, _
        <ExcelArgument("Pressure in Pa.")> ByVal P As Double, _
        <ExcelArgument("Mixture Mass Entropy in kJ/[kg.K].")> ByVal S As Double, _
        <ExcelArgument("Compound names.")> ByVal compounds As Object(), _
        <ExcelArgument("Compound mole fractions.")> ByVal molefractions As Double(), _
        <ExcelArgument("Interaction Parameters Set #1.")> ByVal ip1 As Object, _
        <ExcelArgument("Interaction Parameters Set #2.")> ByVal ip2 As Object, _
        <ExcelArgument("Interaction Parameters Set #3.")> ByVal ip3 As Object, _
        <ExcelArgument("Interaction Parameters Set #4.")> ByVal ip4 As Object, _
        <ExcelArgument("Interaction Parameters Set #5.")> ByVal ip5 As Object, _
        <ExcelArgument("Interaction Parameters Set #6.")> ByVal ip6 As Object, _
        <ExcelArgument("Interaction Parameters Set #7.")> ByVal ip7 As Object, _
        <ExcelArgument("Interaction Parameters Set #8.")> ByVal ip8 As Object) As Object(,)

            Try

                Dim ppm As New CAPEOPENPropertyPackageManager()

                Dim pp As PropertyPackages.PropertyPackage

                pp = ppm.GetPropertyPackage(proppack)
                SetIP(proppack, pp, compounds, ip1, ip2, ip3, ip4, ip5, ip6, ip7, ip8)

                ppm.Dispose()
                ppm = Nothing

                Dim ms As New Streams.MaterialStream("", "")

                For Each phase As DWSIM.ClassesBasicasTermodinamica.Fase In ms.Fases.Values
                    For Each c As String In compounds
                        phase.Componentes.Add(c, New DWSIM.ClassesBasicasTermodinamica.Substancia(c, ""))
                        phase.Componentes(c).ConstantProperties = pp._availablecomps(c)
                    Next
                Next

                For Each c As String In compounds
                    Dim tmpcomp As ConstantProperties = pp._availablecomps(c)
                    If Not pp._selectedcomps.ContainsKey(c) Then pp._selectedcomps.Add(c, tmpcomp)
                    'pp._availablecomps.Remove(c)
                Next

                ms.SetOverallComposition(molefractions)
                ms.Fases(0).SPMProperties.entropy = S
                ms.Fases(0).SPMProperties.pressure = P

                ms._pp = pp
                pp.SetMaterial(ms)

                Select Case flashalg
                    Case 1
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.DWSIMDefault
                    Case 2
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut
                    Case 3
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut3P
                End Select

                pp._ioquick = False
                pp._tpseverity = 2
                Dim comps(compounds.Length - 1) As String
                Dim k As Integer
                For Each c As String In compounds
                    comps(k) = c
                    k += 1
                Next
                pp._tpcompids = comps

                pp.CalcEquilibrium(ms, "PS", "UNDEFINED")

                Dim labels As String() = Nothing
                Dim statuses As CapeOpen.CapePhaseStatus() = Nothing

                ms.GetPresentPhases(labels, statuses)

                Dim fractions(compounds.Length + 2, labels.Length - 1) As Object

                Dim res As Object = Nothing

                Dim i, j As Integer
                i = 0
                For Each l As String In labels
                    If statuses(i) = CapeOpen.CapePhaseStatus.CAPE_ATEQUILIBRIUM Then
                        fractions(0, i) = labels(i)
                        ms.GetSinglePhaseProp("phasefraction", labels(i), "Mole", res)
                        fractions(1, i) = res(0)
                        ms.GetSinglePhaseProp("fraction", labels(i), "Mole", res)
                        For j = 0 To compounds.Length - 1
                            fractions(2 + j, i) = res(j)
                        Next
                    End If
                    i += 1
                Next

                fractions(compounds.Length + 2, 0) = ms.Fases(0).SPMProperties.temperature.GetValueOrDefault

                If TypeOf proppack Is String Then
                    pp.Dispose()
                    pp = Nothing
                End If

                ms.Dispose()
                ms = Nothing

                Return fractions

            Catch ex As Exception

                Return New Object(,) {{ex.GetType.ToString}, {ex.ToString}}

            End Try

        End Function

        <ExcelFunction("Calculates a PVF Flash using the selected Property Package.")> _
        Public Shared Function PVFFlash( _
        <ExcelArgument("The name of the Property Package to use.")> ByVal proppack As String, _
        <ExcelArgument("The Flash Algorithm to use: 1 - Nested Loops, 2 - Inside Out, 3 - Three-Phase Inside Out")> ByVal flashalg As Integer, _
        <ExcelArgument("Pressure in Pa.")> ByVal P As Double, _
        <ExcelArgument("Mixture Mole Vapor Fraction.")> ByVal VF As Double, _
        <ExcelArgument("Compound names.")> ByVal compounds As Object(), _
        <ExcelArgument("Compound mole fractions.")> ByVal molefractions As Double(), _
        <ExcelArgument("Interaction Parameters Set #1.")> ByVal ip1 As Object, _
        <ExcelArgument("Interaction Parameters Set #2.")> ByVal ip2 As Object, _
        <ExcelArgument("Interaction Parameters Set #3.")> ByVal ip3 As Object, _
        <ExcelArgument("Interaction Parameters Set #4.")> ByVal ip4 As Object, _
        <ExcelArgument("Interaction Parameters Set #5.")> ByVal ip5 As Object, _
        <ExcelArgument("Interaction Parameters Set #6.")> ByVal ip6 As Object, _
        <ExcelArgument("Interaction Parameters Set #7.")> ByVal ip7 As Object, _
        <ExcelArgument("Interaction Parameters Set #8.")> ByVal ip8 As Object) As Object(,)

            Try

                Dim ppm As New CAPEOPENPropertyPackageManager()

                Dim pp As PropertyPackages.PropertyPackage

                pp = ppm.GetPropertyPackage(proppack)
                SetIP(proppack, pp, compounds, ip1, ip2, ip3, ip4, ip5, ip6, ip7, ip8)

                ppm.Dispose()
                ppm = Nothing

                Dim ms As New Streams.MaterialStream("", "")

                For Each phase As DWSIM.ClassesBasicasTermodinamica.Fase In ms.Fases.Values
                    For Each c As String In compounds
                        phase.Componentes.Add(c, New DWSIM.ClassesBasicasTermodinamica.Substancia(c, ""))
                        phase.Componentes(c).ConstantProperties = pp._availablecomps(c)
                    Next
                Next

                For Each c As String In compounds
                    Dim tmpcomp As ConstantProperties = pp._availablecomps(c)
                    If Not pp._selectedcomps.ContainsKey(c) Then pp._selectedcomps.Add(c, tmpcomp)
                    'pp._availablecomps.Remove(c)
                Next

                ms.SetOverallComposition(molefractions)
                ms.Fases(2).SPMProperties.molarfraction = VF
                ms.Fases(0).SPMProperties.pressure = P

                ms._pp = pp
                pp.SetMaterial(ms)

                Select Case flashalg
                    Case 1
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.DWSIMDefault
                    Case 2
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut
                    Case 3
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut3P
                End Select

                pp._ioquick = False
                pp._tpseverity = 2
                Dim comps(compounds.Length - 1) As String
                Dim k As Integer
                For Each c As String In compounds
                    comps(k) = c
                    k += 1
                Next
                pp._tpcompids = comps

                pp.CalcEquilibrium(ms, "PVF", "UNDEFINED")

                Dim labels As String() = Nothing
                Dim statuses As CapeOpen.CapePhaseStatus() = Nothing

                ms.GetPresentPhases(labels, statuses)

                Dim fractions(compounds.Length + 2, labels.Length - 1) As Object

                Dim res As Object = Nothing

                Dim i, j As Integer
                i = 0
                For Each l As String In labels
                    If statuses(i) = CapeOpen.CapePhaseStatus.CAPE_ATEQUILIBRIUM Then
                        fractions(0, i) = labels(i)
                        ms.GetSinglePhaseProp("phasefraction", labels(i), "Mole", res)
                        fractions(1, i) = res(0)
                        ms.GetSinglePhaseProp("fraction", labels(i), "Mole", res)
                        For j = 0 To compounds.Length - 1
                            fractions(2 + j, i) = res(j)
                        Next
                    End If
                    i += 1
                Next

                fractions(compounds.Length + 2, 0) = ms.Fases(0).SPMProperties.temperature.GetValueOrDefault

                If TypeOf proppack Is String Then
                    pp.Dispose()
                    pp = Nothing
                End If

                ms.Dispose()
                ms = Nothing

                Return fractions

            Catch ex As Exception

                Return New Object(,) {{ex.GetType.ToString}, {ex.ToString}}

            End Try

        End Function

        <ExcelFunction("Calculates a TVF Flash using the selected Property Package.")> _
        Public Shared Function TVFFlash( _
        <ExcelArgument("The name of the Property Package to use.")> ByVal proppack As String, _
        <ExcelArgument("The Flash Algorithm to use: 1 - Nested Loops, 2 - Inside Out, 3 - Three-Phase Inside Out")> ByVal flashalg As Integer, _
        <ExcelArgument("Temperature in K.")> ByVal T As Double, _
        <ExcelArgument("Mixture Mole Vapor Fraction.")> ByVal VF As Double, _
        <ExcelArgument("Compound names.")> ByVal compounds As Object(), _
        <ExcelArgument("Compound mole fractions.")> ByVal molefractions As Double(), _
        <ExcelArgument("Interaction Parameters Set #1.")> ByVal ip1 As Object, _
        <ExcelArgument("Interaction Parameters Set #2.")> ByVal ip2 As Object, _
        <ExcelArgument("Interaction Parameters Set #3.")> ByVal ip3 As Object, _
        <ExcelArgument("Interaction Parameters Set #4.")> ByVal ip4 As Object, _
        <ExcelArgument("Interaction Parameters Set #5.")> ByVal ip5 As Object, _
        <ExcelArgument("Interaction Parameters Set #6.")> ByVal ip6 As Object, _
        <ExcelArgument("Interaction Parameters Set #7.")> ByVal ip7 As Object, _
        <ExcelArgument("Interaction Parameters Set #8.")> ByVal ip8 As Object) As Object(,)

            Try

                Dim ppm As New CAPEOPENPropertyPackageManager()

                Dim pp As PropertyPackages.PropertyPackage

                pp = ppm.GetPropertyPackage(proppack)
                SetIP(proppack, pp, compounds, ip1, ip2, ip3, ip4, ip5, ip6, ip7, ip8)

                ppm.Dispose()
                ppm = Nothing

                Dim ms As New Streams.MaterialStream("", "")

                For Each phase As DWSIM.ClassesBasicasTermodinamica.Fase In ms.Fases.Values
                    For Each c As String In compounds
                        phase.Componentes.Add(c, New DWSIM.ClassesBasicasTermodinamica.Substancia(c, ""))
                        phase.Componentes(c).ConstantProperties = pp._availablecomps(c)
                    Next
                Next

                For Each c As String In compounds
                    Dim tmpcomp As ConstantProperties = pp._availablecomps(c)
                    If Not pp._selectedcomps.ContainsKey(c) Then pp._selectedcomps.Add(c, tmpcomp)
                    'pp._availablecomps.Remove(c)
                Next

                ms.SetOverallComposition(molefractions)
                ms.Fases(2).SPMProperties.molarfraction = VF
                ms.Fases(0).SPMProperties.temperature = T

                ms._pp = pp
                pp.SetMaterial(ms)

                Select Case flashalg
                    Case 1
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.DWSIMDefault
                    Case 2
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut
                    Case 3
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut3P
                End Select

                pp._ioquick = False
                pp._tpseverity = 2
                Dim comps(compounds.Length - 1) As String
                Dim k As Integer
                For Each c As String In compounds
                    comps(k) = c
                    k += 1
                Next
                pp._tpcompids = comps

                pp.CalcEquilibrium(ms, "TVF", "UNDEFINED")

                Dim labels As String() = Nothing
                Dim statuses As CapeOpen.CapePhaseStatus() = Nothing

                ms.GetPresentPhases(labels, statuses)

                Dim fractions(compounds.Length + 2, labels.Length - 1) As Object

                Dim res As Object = Nothing

                Dim i, j As Integer
                i = 0
                For Each l As String In labels
                    If statuses(i) = CapeOpen.CapePhaseStatus.CAPE_ATEQUILIBRIUM Then
                        fractions(0, i) = labels(i)
                        ms.GetSinglePhaseProp("phasefraction", labels(i), "Mole", res)
                        fractions(1, i) = res(0)
                        ms.GetSinglePhaseProp("fraction", labels(i), "Mole", res)
                        For j = 0 To compounds.Length - 1
                            fractions(2 + j, i) = res(j)
                        Next
                    End If
                    i += 1
                Next

                fractions(compounds.Length + 2, 0) = ms.Fases(0).SPMProperties.pressure.GetValueOrDefault

                If TypeOf proppack Is String Then
                    pp.Dispose()
                    pp = Nothing
                End If

                ms.Dispose()
                ms = Nothing

                Return fractions

            Catch ex As Exception

                Return New Object(,) {{ex.GetType.ToString}, {ex.ToString}}

            End Try

        End Function

        Public Shared Sub AddCompounds(ByVal proppack As PropertyPackage, ByVal compounds As Object())

            Dim ms As New Streams.MaterialStream("", "")

            For Each phase As DWSIM.ClassesBasicasTermodinamica.Fase In ms.Fases.Values
                For Each c As String In compounds
                    phase.Componentes.Add(c, New DWSIM.ClassesBasicasTermodinamica.Substancia(c, ""))
                    phase.Componentes(c).ConstantProperties = proppack._availablecomps(c)
                Next
            Next

            For Each c As String In compounds
                Dim tmpcomp As ConstantProperties = proppack._availablecomps(c)
                If Not proppack._selectedcomps.ContainsKey(c) Then proppack._selectedcomps.Add(c, tmpcomp)
            Next

            ms._pp = proppack
            proppack.SetMaterial(ms)

        End Sub

        <ExcelFunction("Calculates a PT Flash using the selected Property Package.")> _
        Public Shared Function PTFlash( _
       <ExcelArgument("The name of the Property Package to use.")> ByVal proppack As PropertyPackage, _
       <ExcelArgument("The Flash Algorithm to use: 1 - Nested Loops, 2 - Inside Out, 3 - Three-Phase Inside Out")> ByVal flashalg As Integer, _
       <ExcelArgument("Pressure in Pa.")> ByVal P As Double, _
       <ExcelArgument("Temperature in K.")> ByVal T As Double, _
       <ExcelArgument("Compound names.")> ByVal compounds As Object(), _
       <ExcelArgument("Compound mole fractions.")> ByVal molefractions As Double(), _
       <ExcelArgument("Interaction Parameters Set #1.")> ByVal ip1 As Object, _
       <ExcelArgument("Interaction Parameters Set #2.")> ByVal ip2 As Object, _
       <ExcelArgument("Interaction Parameters Set #3.")> ByVal ip3 As Object, _
       <ExcelArgument("Interaction Parameters Set #4.")> ByVal ip4 As Object, _
        <ExcelArgument("Interaction Parameters Set #5.")> ByVal ip5 As Object, _
        <ExcelArgument("Interaction Parameters Set #6.")> ByVal ip6 As Object, _
        <ExcelArgument("Interaction Parameters Set #7.")> ByVal ip7 As Object, _
        <ExcelArgument("Interaction Parameters Set #8.")> ByVal ip8 As Object) As Object(,)

            Try

                Dim ppm As New CAPEOPENPropertyPackageManager()

                Dim pp As PropertyPackages.PropertyPackage

                pp = proppack
                SetIP(pp.ComponentName, pp, compounds, ip1, ip2, ip3, ip4, ip5, ip6, ip7, ip8)

                ppm.Dispose()
                ppm = Nothing

                Dim ms As New Streams.MaterialStream("", "")

                For Each phase As DWSIM.ClassesBasicasTermodinamica.Fase In ms.Fases.Values
                    For Each c As String In compounds
                        phase.Componentes.Add(c, New DWSIM.ClassesBasicasTermodinamica.Substancia(c, ""))
                        phase.Componentes(c).ConstantProperties = pp._availablecomps(c)
                    Next
                Next

                For Each c As String In compounds
                    Dim tmpcomp As ConstantProperties = pp._availablecomps(c)
                    If Not pp._selectedcomps.ContainsKey(c) Then pp._selectedcomps.Add(c, tmpcomp)
                    'pp._availablecomps.Remove(c)
                Next

                ms.SetOverallComposition(molefractions)
                ms.Fases(0).SPMProperties.temperature = T
                ms.Fases(0).SPMProperties.pressure = P

                ms._pp = pp
                pp.SetMaterial(ms)

                Select Case flashalg
                    Case 1
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.DWSIMDefault
                    Case 2
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut
                    Case 3
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut3P
                End Select

                pp._ioquick = False
                pp._tpseverity = 2
                Dim comps(compounds.Length - 1) As String
                Dim k As Integer
                For Each c As String In compounds
                    comps(k) = c
                    k += 1
                Next
                pp._tpcompids = comps

                pp.CalcEquilibrium(ms, "TP", "UNDEFINED")

                Dim labels As String() = Nothing
                Dim statuses As CapeOpen.CapePhaseStatus() = Nothing

                ms.GetPresentPhases(labels, statuses)

                Dim fractions(compounds.Length + 1, labels.Length - 1) As Object

                Dim res As Object = Nothing

                Dim i, j As Integer
                i = 0
                For Each l As String In labels
                    If statuses(i) = CapeOpen.CapePhaseStatus.CAPE_ATEQUILIBRIUM Then
                        fractions(0, i) = labels(i)
                        ms.GetSinglePhaseProp("phasefraction", labels(i), "Mole", res)
                        fractions(1, i) = res(0)
                        ms.GetSinglePhaseProp("fraction", labels(i), "Mole", res)
                        For j = 0 To compounds.Length - 1
                            fractions(2 + j, i) = res(j)
                        Next
                    End If
                    i += 1
                Next

                ms.Dispose()
                ms = Nothing

                Return fractions

            Catch ex As Exception

                Return New Object(,) {{ex.GetType.ToString}, {ex.ToString}}

            End Try

        End Function

        <ExcelFunction("Calculates a PH Flash using the selected Property Package.")> _
        Public Shared Function PHFlash( _
        <ExcelArgument("The name of the Property Package to use.")> ByVal proppack As PropertyPackage, _
        <ExcelArgument("The Flash Algorithm to use: 1 - Nested Loops, 2 - Inside Out, 3 - Three-Phase Inside Out")> ByVal flashalg As Integer, _
        <ExcelArgument("Pressure in Pa.")> ByVal P As Double, _
        <ExcelArgument("Mixture Mass Enthalpy in kJ/kg.")> ByVal H As Double, _
        <ExcelArgument("Compound names.")> ByVal compounds As Object(), _
        <ExcelArgument("Compound mole fractions.")> ByVal molefractions As Double(), _
        <ExcelArgument("Interaction Parameters Set #1.")> ByVal ip1 As Object, _
        <ExcelArgument("Interaction Parameters Set #2.")> ByVal ip2 As Object, _
        <ExcelArgument("Interaction Parameters Set #3.")> ByVal ip3 As Object, _
        <ExcelArgument("Interaction Parameters Set #4.")> ByVal ip4 As Object, _
        <ExcelArgument("Interaction Parameters Set #5.")> ByVal ip5 As Object, _
        <ExcelArgument("Interaction Parameters Set #6.")> ByVal ip6 As Object, _
        <ExcelArgument("Interaction Parameters Set #7.")> ByVal ip7 As Object, _
        <ExcelArgument("Interaction Parameters Set #8.")> ByVal ip8 As Object) As Object(,)

            Try

                Dim ppm As New CAPEOPENPropertyPackageManager()

                Dim pp As PropertyPackages.PropertyPackage

                pp = proppack
                SetIP(pp.ComponentName, pp, compounds, ip1, ip2, ip3, ip4, ip5, ip6, ip7, ip8)

                ppm.Dispose()
                ppm = Nothing

                Dim ms As New Streams.MaterialStream("", "")

                For Each phase As DWSIM.ClassesBasicasTermodinamica.Fase In ms.Fases.Values
                    For Each c As String In compounds
                        phase.Componentes.Add(c, New DWSIM.ClassesBasicasTermodinamica.Substancia(c, ""))
                        phase.Componentes(c).ConstantProperties = pp._availablecomps(c)
                    Next
                Next

                For Each c As String In compounds
                    Dim tmpcomp As ConstantProperties = pp._availablecomps(c)
                    If Not pp._selectedcomps.ContainsKey(c) Then pp._selectedcomps.Add(c, tmpcomp)
                    'pp._availablecomps.Remove(c)
                Next

                ms.SetOverallComposition(molefractions)
                ms.Fases(0).SPMProperties.enthalpy = H
                ms.Fases(0).SPMProperties.pressure = P

                ms._pp = pp
                pp.SetMaterial(ms)

                Select Case flashalg
                    Case 1
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.DWSIMDefault
                    Case 2
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut
                    Case 3
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut3P
                End Select

                pp._ioquick = False
                pp._tpseverity = 2
                Dim comps(compounds.Length - 1) As String
                Dim k As Integer
                For Each c As String In compounds
                    comps(k) = c
                    k += 1
                Next
                pp._tpcompids = comps

                pp.CalcEquilibrium(ms, "PH", "UNDEFINED")

                Dim labels As String() = Nothing
                Dim statuses As CapeOpen.CapePhaseStatus() = Nothing

                ms.GetPresentPhases(labels, statuses)

                Dim fractions(compounds.Length + 2, labels.Length - 1) As Object

                Dim res As Object = Nothing

                Dim i, j As Integer
                i = 0
                For Each l As String In labels
                    If statuses(i) = CapeOpen.CapePhaseStatus.CAPE_ATEQUILIBRIUM Then
                        fractions(0, i) = labels(i)
                        ms.GetSinglePhaseProp("phasefraction", labels(i), "Mole", res)
                        fractions(1, i) = res(0)
                        ms.GetSinglePhaseProp("fraction", labels(i), "Mole", res)
                        For j = 0 To compounds.Length - 1
                            fractions(2 + j, i) = res(j)
                        Next
                    End If
                    i += 1
                Next

                fractions(compounds.Length + 2, 0) = ms.Fases(0).SPMProperties.temperature.GetValueOrDefault

                ms.Dispose()
                ms = Nothing

                Return fractions

            Catch ex As Exception

                Return New Object(,) {{ex.GetType.ToString}, {ex.ToString}}

            End Try

        End Function

        <ExcelFunction("Calculates a PS Flash using the selected Property Package.")> _
        Public Shared Function PSFlash( _
        <ExcelArgument("The name of the Property Package to use.")> ByVal proppack As PropertyPackage, _
        <ExcelArgument("The Flash Algorithm to use: 1 - Nested Loops, 2 - Inside Out, 3 - Three-Phase Inside Out")> ByVal flashalg As Integer, _
        <ExcelArgument("Pressure in Pa.")> ByVal P As Double, _
        <ExcelArgument("Mixture Mass Entropy in kJ/[kg.K].")> ByVal S As Double, _
        <ExcelArgument("Compound names.")> ByVal compounds As Object(), _
        <ExcelArgument("Compound mole fractions.")> ByVal molefractions As Double(), _
        <ExcelArgument("Interaction Parameters Set #1.")> ByVal ip1 As Object, _
        <ExcelArgument("Interaction Parameters Set #2.")> ByVal ip2 As Object, _
        <ExcelArgument("Interaction Parameters Set #3.")> ByVal ip3 As Object, _
        <ExcelArgument("Interaction Parameters Set #4.")> ByVal ip4 As Object, _
        <ExcelArgument("Interaction Parameters Set #5.")> ByVal ip5 As Object, _
        <ExcelArgument("Interaction Parameters Set #6.")> ByVal ip6 As Object, _
        <ExcelArgument("Interaction Parameters Set #7.")> ByVal ip7 As Object, _
        <ExcelArgument("Interaction Parameters Set #8.")> ByVal ip8 As Object) As Object(,)

            Try

                Dim ppm As New CAPEOPENPropertyPackageManager()

                Dim pp As PropertyPackages.PropertyPackage

                pp = proppack
                SetIP(pp.ComponentName, pp, compounds, ip1, ip2, ip3, ip4, ip5, ip6, ip7, ip8)

                ppm.Dispose()
                ppm = Nothing

                Dim ms As New Streams.MaterialStream("", "")

                For Each phase As DWSIM.ClassesBasicasTermodinamica.Fase In ms.Fases.Values
                    For Each c As String In compounds
                        phase.Componentes.Add(c, New DWSIM.ClassesBasicasTermodinamica.Substancia(c, ""))
                        phase.Componentes(c).ConstantProperties = pp._availablecomps(c)
                    Next
                Next

                For Each c As String In compounds
                    Dim tmpcomp As ConstantProperties = pp._availablecomps(c)
                    If Not pp._selectedcomps.ContainsKey(c) Then pp._selectedcomps.Add(c, tmpcomp)
                    'pp._availablecomps.Remove(c)
                Next

                ms.SetOverallComposition(molefractions)
                ms.Fases(0).SPMProperties.entropy = S
                ms.Fases(0).SPMProperties.pressure = P

                ms._pp = pp
                pp.SetMaterial(ms)

                Select Case flashalg
                    Case 1
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.DWSIMDefault
                    Case 2
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut
                    Case 3
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut3P
                End Select

                pp._ioquick = False
                pp._tpseverity = 2
                Dim comps(compounds.Length - 1) As String
                Dim k As Integer
                For Each c As String In compounds
                    comps(k) = c
                    k += 1
                Next
                pp._tpcompids = comps

                pp.CalcEquilibrium(ms, "PS", "UNDEFINED")

                Dim labels As String() = Nothing
                Dim statuses As CapeOpen.CapePhaseStatus() = Nothing

                ms.GetPresentPhases(labels, statuses)

                Dim fractions(compounds.Length + 2, labels.Length - 1) As Object

                Dim res As Object = Nothing

                Dim i, j As Integer
                i = 0
                For Each l As String In labels
                    If statuses(i) = CapeOpen.CapePhaseStatus.CAPE_ATEQUILIBRIUM Then
                        fractions(0, i) = labels(i)
                        ms.GetSinglePhaseProp("phasefraction", labels(i), "Mole", res)
                        fractions(1, i) = res(0)
                        ms.GetSinglePhaseProp("fraction", labels(i), "Mole", res)
                        For j = 0 To compounds.Length - 1
                            fractions(2 + j, i) = res(j)
                        Next
                    End If
                    i += 1
                Next

                fractions(compounds.Length + 2, 0) = ms.Fases(0).SPMProperties.temperature.GetValueOrDefault

                ms.Dispose()
                ms = Nothing

                Return fractions

            Catch ex As Exception

                Return New Object(,) {{ex.GetType.ToString}, {ex.ToString}}

            End Try

        End Function

        <ExcelFunction("Calculates a PVF Flash using the selected Property Package.")> _
        Public Shared Function PVFFlash( _
        <ExcelArgument("The name of the Property Package to use.")> ByVal proppack As PropertyPackage, _
        <ExcelArgument("The Flash Algorithm to use: 1 - Nested Loops, 2 - Inside Out, 3 - Three-Phase Inside Out")> ByVal flashalg As Integer, _
        <ExcelArgument("Pressure in Pa.")> ByVal P As Double, _
        <ExcelArgument("Mixture Mole Vapor Fraction.")> ByVal VF As Double, _
        <ExcelArgument("Compound names.")> ByVal compounds As Object(), _
        <ExcelArgument("Compound mole fractions.")> ByVal molefractions As Double(), _
        <ExcelArgument("Interaction Parameters Set #1.")> ByVal ip1 As Object, _
        <ExcelArgument("Interaction Parameters Set #2.")> ByVal ip2 As Object, _
        <ExcelArgument("Interaction Parameters Set #3.")> ByVal ip3 As Object, _
        <ExcelArgument("Interaction Parameters Set #4.")> ByVal ip4 As Object, _
        <ExcelArgument("Interaction Parameters Set #5.")> ByVal ip5 As Object, _
        <ExcelArgument("Interaction Parameters Set #6.")> ByVal ip6 As Object, _
        <ExcelArgument("Interaction Parameters Set #7.")> ByVal ip7 As Object, _
        <ExcelArgument("Interaction Parameters Set #8.")> ByVal ip8 As Object) As Object(,)

            Try

                Dim ppm As New CAPEOPENPropertyPackageManager()

                Dim pp As PropertyPackages.PropertyPackage

                pp = proppack
                SetIP(pp.ComponentName, pp, compounds, ip1, ip2, ip3, ip4, ip5, ip6, ip7, ip8)

                ppm.Dispose()
                ppm = Nothing

                Dim ms As New Streams.MaterialStream("", "")

                For Each phase As DWSIM.ClassesBasicasTermodinamica.Fase In ms.Fases.Values
                    For Each c As String In compounds
                        phase.Componentes.Add(c, New DWSIM.ClassesBasicasTermodinamica.Substancia(c, ""))
                        phase.Componentes(c).ConstantProperties = pp._availablecomps(c)
                    Next
                Next

                For Each c As String In compounds
                    Dim tmpcomp As ConstantProperties = pp._availablecomps(c)
                    If Not pp._selectedcomps.ContainsKey(c) Then pp._selectedcomps.Add(c, tmpcomp)
                    'pp._availablecomps.Remove(c)
                Next

                ms.SetOverallComposition(molefractions)
                ms.Fases(2).SPMProperties.molarfraction = VF
                ms.Fases(0).SPMProperties.pressure = P

                ms._pp = pp
                pp.SetMaterial(ms)

                Select Case flashalg
                    Case 1
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.DWSIMDefault
                    Case 2
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut
                    Case 3
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut3P
                End Select

                pp._ioquick = False
                pp._tpseverity = 2
                Dim comps(compounds.Length - 1) As String
                Dim k As Integer
                For Each c As String In compounds
                    comps(k) = c
                    k += 1
                Next
                pp._tpcompids = comps

                pp.CalcEquilibrium(ms, "PVF", "UNDEFINED")

                Dim labels As String() = Nothing
                Dim statuses As CapeOpen.CapePhaseStatus() = Nothing

                ms.GetPresentPhases(labels, statuses)

                Dim fractions(compounds.Length + 2, labels.Length - 1) As Object

                Dim res As Object = Nothing

                Dim i, j As Integer
                i = 0
                For Each l As String In labels
                    If statuses(i) = CapeOpen.CapePhaseStatus.CAPE_ATEQUILIBRIUM Then
                        fractions(0, i) = labels(i)
                        ms.GetSinglePhaseProp("phasefraction", labels(i), "Mole", res)
                        fractions(1, i) = res(0)
                        ms.GetSinglePhaseProp("fraction", labels(i), "Mole", res)
                        For j = 0 To compounds.Length - 1
                            fractions(2 + j, i) = res(j)
                        Next
                    End If
                    i += 1
                Next

                fractions(compounds.Length + 2, 0) = ms.Fases(0).SPMProperties.temperature.GetValueOrDefault

                ms.Dispose()
                ms = Nothing

                Return fractions

            Catch ex As Exception

                Return New Object(,) {{ex.GetType.ToString}, {ex.ToString}}

            End Try

        End Function

        <ExcelFunction("Calculates a TVF Flash using the selected Property Package.")> _
        Public Shared Function TVFFlash( _
        <ExcelArgument("The name of the Property Package to use.")> ByVal proppack As PropertyPackage, _
        <ExcelArgument("The Flash Algorithm to use: 1 - Nested Loops, 2 - Inside Out, 3 - Three-Phase Inside Out")> ByVal flashalg As Integer, _
        <ExcelArgument("Temperature in K.")> ByVal T As Double, _
        <ExcelArgument("Mixture Mole Vapor Fraction.")> ByVal VF As Double, _
        <ExcelArgument("Compound names.")> ByVal compounds As Object(), _
        <ExcelArgument("Compound mole fractions.")> ByVal molefractions As Double(), _
        <ExcelArgument("Interaction Parameters Set #1.")> ByVal ip1 As Object, _
        <ExcelArgument("Interaction Parameters Set #2.")> ByVal ip2 As Object, _
        <ExcelArgument("Interaction Parameters Set #3.")> ByVal ip3 As Object, _
        <ExcelArgument("Interaction Parameters Set #4.")> ByVal ip4 As Object, _
        <ExcelArgument("Interaction Parameters Set #5.")> ByVal ip5 As Object, _
        <ExcelArgument("Interaction Parameters Set #6.")> ByVal ip6 As Object, _
        <ExcelArgument("Interaction Parameters Set #7.")> ByVal ip7 As Object, _
        <ExcelArgument("Interaction Parameters Set #8.")> ByVal ip8 As Object) As Object(,)

            Try

                Dim ppm As New CAPEOPENPropertyPackageManager()

                Dim pp As PropertyPackages.PropertyPackage

                pp = proppack
                SetIP(pp.ComponentName, pp, compounds, ip1, ip2, ip3, ip4, ip5, ip6, ip7, ip8)

                ppm.Dispose()
                ppm = Nothing

                Dim ms As New Streams.MaterialStream("", "")

                For Each phase As DWSIM.ClassesBasicasTermodinamica.Fase In ms.Fases.Values
                    For Each c As String In compounds
                        phase.Componentes.Add(c, New DWSIM.ClassesBasicasTermodinamica.Substancia(c, ""))
                        phase.Componentes(c).ConstantProperties = pp._availablecomps(c)
                    Next
                Next

                For Each c As String In compounds
                    Dim tmpcomp As ConstantProperties = pp._availablecomps(c)
                    If Not pp._selectedcomps.ContainsKey(c) Then pp._selectedcomps.Add(c, tmpcomp)
                    'pp._availablecomps.Remove(c)
                Next

                ms.SetOverallComposition(molefractions)
                ms.Fases(2).SPMProperties.molarfraction = VF
                ms.Fases(0).SPMProperties.temperature = T

                ms._pp = pp
                pp.SetMaterial(ms)

                Select Case flashalg
                    Case 1
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.DWSIMDefault
                    Case 2
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut
                    Case 3
                        pp.FlashAlgorithm = PropertyPackages.FlashMethod.InsideOut3P
                End Select

                pp._ioquick = False
                pp._tpseverity = 2
                Dim comps(compounds.Length - 1) As String
                Dim k As Integer
                For Each c As String In compounds
                    comps(k) = c
                    k += 1
                Next
                pp._tpcompids = comps

                pp.CalcEquilibrium(ms, "TVF", "UNDEFINED")

                Dim labels As String() = Nothing
                Dim statuses As CapeOpen.CapePhaseStatus() = Nothing

                ms.GetPresentPhases(labels, statuses)

                Dim fractions(compounds.Length + 2, labels.Length - 1) As Object

                Dim res As Object = Nothing

                Dim i, j As Integer
                i = 0
                For Each l As String In labels
                    If statuses(i) = CapeOpen.CapePhaseStatus.CAPE_ATEQUILIBRIUM Then
                        fractions(0, i) = labels(i)
                        ms.GetSinglePhaseProp("phasefraction", labels(i), "Mole", res)
                        fractions(1, i) = res(0)
                        ms.GetSinglePhaseProp("fraction", labels(i), "Mole", res)
                        For j = 0 To compounds.Length - 1
                            fractions(2 + j, i) = res(j)
                        Next
                    End If
                    i += 1
                Next

                fractions(compounds.Length + 2, 0) = ms.Fases(0).SPMProperties.pressure.GetValueOrDefault

                ms.Dispose()
                ms = Nothing

                Return fractions

            Catch ex As Exception

                Return New Object(,) {{ex.GetType.ToString}, {ex.ToString}}

            End Try

        End Function

    End Class

End Namespace