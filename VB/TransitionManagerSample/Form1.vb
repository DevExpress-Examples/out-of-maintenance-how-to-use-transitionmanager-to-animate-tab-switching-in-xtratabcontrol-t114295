Imports DevExpress.Utils.Animation
Imports DevExpress.XtraEditors

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate the ImageComboBox with available transition types.
        ImageComboBoxEdit1.Properties.Items.AddEnum(GetType(DevExpress.Utils.Animation.Transitions))
        AddHandler ImageComboBoxEdit1.SelectedIndexChanged, AddressOf ImageComboBoxEdit1_SelectedIndexChanged
        ImageComboBoxEdit1.SelectedIndex = 0

        XtraTabControl1.Transition.AllowTransition = DevExpress.Utils.DefaultBoolean.True
    End Sub

    Private Sub ImageComboBoxEdit1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim imComboBox As ImageComboBoxEdit = TryCast(sender, ImageComboBoxEdit)
        ' Specify the transition type.
        Dim trType As DevExpress.Utils.Animation.Transitions = DirectCast(imComboBox.EditValue, DevExpress.Utils.Animation.Transitions)
        XtraTabControl1.Transition.TransitionType = CreateTransitionInstance(trType)
    End Sub

    Private Function CreateTransitionInstance(transitionType As Transitions) As BaseTransition
        Select Case transitionType
            Case Transitions.Dissolve
                Return New DissolveTransition()
            Case Transitions.Fade
                Return New FadeTransition()
            Case Transitions.Shape
                Return New ShapeTransition()
            Case Transitions.Clock
                Return New ClockTransition()
            Case Transitions.SlideFade
                Return New SlideFadeTransition()
            Case Transitions.Cover
                Return New CoverTransition()
            Case Transitions.Comb
                Return New CombTransition()
            Case Else
                Return New PushTransition()
        End Select
    End Function

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        Threading.Thread.Sleep(500)
    End Sub


End Class
