Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()
        Dim pnc As New ProjectNummer("A1234567")

        Dim result As Boolean = pnc.Check()

        Assert.IsTrue(result, "Input is correct project nummer en check zou dus 'true' moeten teruggeven")

    End Sub

    <TestMethod()>
    Public Sub LeegProjectNummerGeeftFalseTerug()
        Assert.IsFalse(New ProjectNummer(Nothing).Check())
    End Sub

End Class