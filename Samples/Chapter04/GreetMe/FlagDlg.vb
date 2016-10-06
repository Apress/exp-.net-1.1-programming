Option Strict

Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Resources
Imports System.Globalization
Imports System.Threading

Namespace Apress.ExpertDotNet.GreetMeSample
	Public Class FlagDlg 
            Inherits Form
		Private FlagCtrl As PictureBox = New PictureBox()

		Public Sub New()
			Dim resManager As ResourceManager = New ResourceManager("Strings", [Assembly].GetExecutingAssembly())
			Me.Text = String.Format(resManager.GetString("DialogFormatString"), _
                resManager.GetString("DialogCaption"), _
                Thread.CurrentThread.CurrentUICulture.ToString())
			resManager = New ResourceManager("Flags", [Assembly].GetExecutingAssembly())
			Me.ClientSize = New Size(150,100)
			FlagCtrl.Image = DirectCast(resManager.GetObject("Flag"), Image)
			FlagCtrl.Location = New Point(20,20)
			FlagCtrl.Parent = Me
        End Sub
	End Class
End Namespace