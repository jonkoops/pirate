<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataSourceColumnBinder1 As XPTable.Models.DataSourceColumnBinder = New XPTable.Models.DataSourceColumnBinder
        Dim DragDropRenderer1 As XPTable.Renderers.DragDropRenderer = New XPTable.Renderers.DragDropRenderer
        Dim DataSourceColumnBinder2 As XPTable.Models.DataSourceColumnBinder = New XPTable.Models.DataSourceColumnBinder
        Dim DragDropRenderer2 As XPTable.Renderers.DragDropRenderer = New XPTable.Renderers.DragDropRenderer
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.sfdDialog = New System.Windows.Forms.SaveFileDialog
        Me.btnSettings = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.tblSearch = New XPTable.Models.Table
        Me.cmSearch = New XPTable.Models.ColumnModel
        Me.NumberColumn1 = New XPTable.Models.NumberColumn
        Me.NumberColumn5 = New XPTable.Models.NumberColumn
        Me.TextColumn2 = New XPTable.Models.TextColumn
        Me.TextColumn3 = New XPTable.Models.TextColumn
        Me.TextColumn4 = New XPTable.Models.TextColumn
        Me.NumberColumn3 = New XPTable.Models.NumberColumn
        Me.NumberColumn4 = New XPTable.Models.NumberColumn
        Me.ButtonColumn1 = New XPTable.Models.ButtonColumn
        Me.tmSearch = New XPTable.Models.TableModel
        Me.tblDownload = New XPTable.Models.Table
        Me.cmDownload = New XPTable.Models.ColumnModel
        Me.NumberColumn2 = New XPTable.Models.NumberColumn
        Me.TextColumn7 = New XPTable.Models.TextColumn
        Me.ProgressBarColumn1 = New XPTable.Models.ProgressBarColumn
        Me.TextColumn8 = New XPTable.Models.TextColumn
        Me.tmDownload = New XPTable.Models.TableModel
        Me.pbProgress = New System.Windows.Forms.ProgressBar
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.tblSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblDownload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(2, 2)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(550, 26)
        Me.txtSearch.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(555, 2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 26)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'sfdDialog
        '
        Me.sfdDialog.DefaultExt = "mp3"
        Me.sfdDialog.Filter = "MP3 File|*.mp3"
        Me.sfdDialog.Title = "Save file"
        '
        'btnSettings
        '
        Me.btnSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSettings.Image = Global.Pirate.My.Resources.Resources.Settings
        Me.btnSettings.Location = New System.Drawing.Point(656, 2)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(26, 26)
        Me.btnSettings.TabIndex = 5
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 30)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tblSearch)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tblDownload)
        Me.SplitContainer1.Size = New System.Drawing.Size(680, 381)
        Me.SplitContainer1.SplitterDistance = 246
        Me.SplitContainer1.SplitterWidth = 19
        Me.SplitContainer1.TabIndex = 6
        '
        'tblSearch
        '
        Me.tblSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblSearch.BorderColor = System.Drawing.Color.Black
        Me.tblSearch.ColumnModel = Me.cmSearch
        Me.tblSearch.DataMember = Nothing
        Me.tblSearch.DataSourceColumnBinder = DataSourceColumnBinder1
        DragDropRenderer1.ForeColor = System.Drawing.Color.Red
        Me.tblSearch.DragDropRenderer = DragDropRenderer1
        Me.tblSearch.EnableHeaderContextMenu = False
        Me.tblSearch.FullRowSelect = True
        Me.tblSearch.GridLines = XPTable.Models.GridLines.Both
        Me.tblSearch.Location = New System.Drawing.Point(0, 0)
        Me.tblSearch.Name = "tblSearch"
        Me.tblSearch.NoItemsText = ""
        Me.tblSearch.ShowSelectionRectangle = False
        Me.tblSearch.Size = New System.Drawing.Size(680, 244)
        Me.tblSearch.TabIndex = 2
        Me.tblSearch.TableModel = Me.tmSearch
        Me.tblSearch.Text = "Table1"
        Me.tblSearch.UnfocusedBorderColor = System.Drawing.Color.Black
        '
        'cmSearch
        '
        Me.cmSearch.Columns.AddRange(New XPTable.Models.Column() {Me.NumberColumn1, Me.NumberColumn5, Me.TextColumn2, Me.TextColumn3, Me.TextColumn4, Me.NumberColumn3, Me.NumberColumn4, Me.ButtonColumn1})
        '
        'NumberColumn1
        '
        Me.NumberColumn1.Enabled = False
        Me.NumberColumn1.IsTextTrimmed = False
        Me.NumberColumn1.Selectable = False
        Me.NumberColumn1.Sortable = False
        Me.NumberColumn1.Visible = False
        '
        'NumberColumn5
        '
        Me.NumberColumn5.IsTextTrimmed = False
        Me.NumberColumn5.Text = "Qty"
        Me.NumberColumn5.Width = 40
        '
        'TextColumn2
        '
        Me.TextColumn2.IsTextTrimmed = False
        Me.TextColumn2.Text = "Artist"
        Me.TextColumn2.Width = 183
        '
        'TextColumn3
        '
        Me.TextColumn3.IsTextTrimmed = False
        Me.TextColumn3.Text = "Title"
        Me.TextColumn3.Width = 183
        '
        'TextColumn4
        '
        Me.TextColumn4.IsTextTrimmed = False
        Me.TextColumn4.Text = "Length"
        Me.TextColumn4.Width = 55
        '
        'NumberColumn3
        '
        Me.NumberColumn3.IsTextTrimmed = False
        Me.NumberColumn3.Text = "Bitrate"
        Me.NumberColumn3.Width = 55
        '
        'NumberColumn4
        '
        Me.NumberColumn4.IsTextTrimmed = False
        Me.NumberColumn4.Text = "Size (MB)"
        Me.NumberColumn4.Width = 71
        '
        'ButtonColumn1
        '
        Me.ButtonColumn1.IsTextTrimmed = False
        Me.ButtonColumn1.Text = "Get file"
        Me.ButtonColumn1.Width = 70
        '
        'tmSearch
        '
        Me.tmSearch.RowHeight = 24
        '
        'tblDownload
        '
        Me.tblDownload.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblDownload.BorderColor = System.Drawing.Color.Black
        Me.tblDownload.ColumnModel = Me.cmDownload
        Me.tblDownload.DataMember = Nothing
        Me.tblDownload.DataSourceColumnBinder = DataSourceColumnBinder2
        DragDropRenderer2.ForeColor = System.Drawing.Color.Red
        Me.tblDownload.DragDropRenderer = DragDropRenderer2
        Me.tblDownload.EnableHeaderContextMenu = False
        Me.tblDownload.FullRowSelect = True
        Me.tblDownload.GridLines = XPTable.Models.GridLines.Both
        Me.tblDownload.Location = New System.Drawing.Point(0, 2)
        Me.tblDownload.Name = "tblDownload"
        Me.tblDownload.NoItemsText = ""
        Me.tblDownload.Size = New System.Drawing.Size(680, 112)
        Me.tblDownload.TabIndex = 4
        Me.tblDownload.TableModel = Me.tmDownload
        Me.tblDownload.Text = "Table2"
        Me.tblDownload.UnfocusedBorderColor = System.Drawing.Color.Black
        '
        'cmDownload
        '
        Me.cmDownload.Columns.AddRange(New XPTable.Models.Column() {Me.NumberColumn2, Me.TextColumn7, Me.ProgressBarColumn1, Me.TextColumn8})
        '
        'NumberColumn2
        '
        Me.NumberColumn2.IsTextTrimmed = False
        Me.NumberColumn2.Visible = False
        '
        'TextColumn7
        '
        Me.TextColumn7.IsTextTrimmed = False
        Me.TextColumn7.Text = "File"
        Me.TextColumn7.Width = 330
        '
        'ProgressBarColumn1
        '
        Me.ProgressBarColumn1.IsTextTrimmed = False
        Me.ProgressBarColumn1.Text = "Progress"
        Me.ProgressBarColumn1.Width = 252
        '
        'TextColumn8
        '
        Me.TextColumn8.IsTextTrimmed = False
        Me.TextColumn8.Text = "Speed"
        '
        'tmDownload
        '
        Me.tmDownload.RowHeight = 24
        '
        'pbProgress
        '
        Me.pbProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbProgress.Location = New System.Drawing.Point(2, 276)
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(680, 19)
        Me.pbProgress.TabIndex = 7
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 412)
        Me.Controls.Add(Me.pbProgress)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(600, 350)
        Me.Name = "frmMain"
        Me.Text = "Pirate"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.tblSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblDownload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents tblDownload As XPTable.Models.Table
    Friend WithEvents cmSearch As XPTable.Models.ColumnModel
    Friend WithEvents cmDownload As XPTable.Models.ColumnModel
    Friend WithEvents tmSearch As XPTable.Models.TableModel
    Friend WithEvents tmDownload As XPTable.Models.TableModel
    Friend WithEvents TextColumn2 As XPTable.Models.TextColumn
    Friend WithEvents TextColumn3 As XPTable.Models.TextColumn
    Friend WithEvents TextColumn4 As XPTable.Models.TextColumn
    Friend WithEvents ButtonColumn1 As XPTable.Models.ButtonColumn
    Friend WithEvents TextColumn7 As XPTable.Models.TextColumn
    Friend WithEvents ProgressBarColumn1 As XPTable.Models.ProgressBarColumn
    Friend WithEvents TextColumn8 As XPTable.Models.TextColumn
    Friend WithEvents sfdDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnSettings As System.Windows.Forms.Button
    Friend WithEvents NumberColumn1 As XPTable.Models.NumberColumn
    Friend WithEvents NumberColumn2 As XPTable.Models.NumberColumn
    Friend WithEvents tblSearch As XPTable.Models.Table
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents pbProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents NumberColumn3 As XPTable.Models.NumberColumn
    Friend WithEvents NumberColumn4 As XPTable.Models.NumberColumn
    Friend WithEvents NumberColumn5 As XPTable.Models.NumberColumn

End Class
