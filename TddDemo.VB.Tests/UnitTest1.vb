Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Shouldly
<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()
        Dim pnc As New ProjectNummer("A1234567")

        Dim result As Boolean = pnc.Check()

        Assert.IsTrue(result, "Input is correct project nummer en check zou dus 'true' moeten teruggeven")

    End Sub

    <TestMethod()>
    Public Sub LeegProjectNummerGeeftFalseTerug()
        Dim pnc As New ProjectNummer("")
        Assert.IsFalse(pnc.Check())

        'Shouldly verhoogt de leesbaarheid en produceert een meer gedetailleerde foutmelding.
        pnc.Check().ShouldBeFalse()
    End Sub

    <TestMethod()>
    <ExpectedException(GetType(ArgumentOutOfRangeException))>
    Public Sub LeegProjectNummerGeeftException_ExpectedException()
        Dim pnc As New ProjectNummer(Nothing)
    End Sub

    <TestMethod()>
    Public Sub LeegProjectNummerGeeftException_TryCatch()
        Try
            Dim pnc As New ProjectNummer(Nothing)
            Assert.Fail()
        Catch ex As ArgumentOutOfRangeException
        End Try
    End Sub

    <TestMethod()>
    Public Sub LeegProjectNummerGeeftException_Shoudly()
        Dim pnc As ProjectNummer
        Should.Throw(Of ArgumentOutOfRangeException)(Sub() pnc = New ProjectNummer(Nothing))
    End Sub
End Class