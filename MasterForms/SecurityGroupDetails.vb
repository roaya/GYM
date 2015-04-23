Public Class SecurityGroupDetails

    Dim Gid As Integer
    Dim BSourceSecDtls As New BindingSource
    Dim cmdb As New SqlClient.SqlCommandBuilder

    Private Sub SecurityGroupDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cmd.CommandText = "select Group_Name from Security_Group_Header"
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                CmbSecGroup.ComboBox.Items.Add(dr("Group_Name"))
            Loop
            dr.Close()



            
            BSourceSecDtls.DataSource = MyDs
            BSourceSecDtls.DataMember = "Security_Group_Details"

            DataGridView1.DataSource = BSourceSecDtls
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).HeaderText = "متاحة / غير متاحة"
            DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(4).Visible = False
        Catch ex As Exception
            cls.WriteError(ex.Message, "Sec Grp Dtls")
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click

        Try
            If CmbSecGroup.Text = "" Then
                cls.MsgExclamation("اختر اسم المجموعة", "please select security group")
            Else
                cmd.CommandText = "select group_id from Security_Group_Header where Group_name = N'" & CmbSecGroup.ComboBox.Text & "'"
                Gid = cmd.ExecuteScalar

                '-------------------------------------------------------------
                SecurityTree.Nodes(0).Nodes.Clear()
                SecurityTree.Nodes(1).Nodes.Clear()
                SecurityTree.Nodes(2).Nodes.Clear()
                SecurityTree.Nodes(3).Nodes.Clear()

                cmd.CommandText = "select Privilege_Name,Grant_Type from Security_Group_Details where group_id = " & Gid
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    Select Case dr("Grant_Type")
                        Case 1
                            SecurityTree.Nodes(0).Nodes.Add(dr("Privilege_Name"))
                            SecurityTree.Nodes(0).LastNode.ImageIndex = 0
                        Case 2
                            SecurityTree.Nodes(2).Nodes.Add(dr("Privilege_Name"))
                            SecurityTree.Nodes(2).LastNode.ImageIndex = 2
                        Case 3
                            SecurityTree.Nodes(1).Nodes.Add(dr("Privilege_Name"))
                            SecurityTree.Nodes(1).LastNode.ImageIndex = 3
                        Case 4
                            SecurityTree.Nodes(3).Nodes.Add(dr("Privilege_Name"))
                            SecurityTree.Nodes(3).LastNode.ImageIndex = 1
                    End Select
                Loop
                dr.Close()
                '-------------------------------------------------------------

                MyDs.Tables("Security_Group_Details").Rows.Clear()
                cmd.CommandText = "select * from Security_Group_Details where group_id = " & Gid
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Security_Group_Details"))
                BSourceSecDtls.Filter = "Privilege_id=0"
                SecurityTree.Enabled = True
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Sec Grp Dtls")
        End Try
    End Sub

    Private Sub SecurityTree_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles SecurityTree.AfterSelect
        BSourceSecDtls.Filter = "Privilege_Name = '" & SecurityTree.SelectedNode.Text & "'"

    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            BSourceSecDtls.EndEdit()
            cmd.CommandText = "select * from Security_Group_Details"
            cmdb.DataAdapter = da
            da.Update(MyDs.Tables("Security_Group_Details"))
            'If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
            '    cls.MsgInfo("تم حفظ التغييرات بنجاح", "data saved successfully")
            'End If
            SecurityTree.Enabled = False
        Catch ex As Exception
            cls.WriteError(ex.Message, "Sec Grp Dtls")
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        MyDs.Tables("Security_Group_Details").RejectChanges()
        Me.Close()
    End Sub
End Class