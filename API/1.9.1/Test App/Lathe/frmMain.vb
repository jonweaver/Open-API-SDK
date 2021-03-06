Imports System.Reflection

Imports Okuma.CLDATAPI
Imports Okuma.CLDATAPI.DataAPI
Imports Okuma.CLCMDAPI

Imports Okuma.CLDATAPI.Enumerations
Imports Okuma.CLCMDAPI.Enumerations

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Dim objMachine As DataAPI.CMachine

    Dim objAxis As DataAPI.CAxis
    Dim objAxis2 As DataAPI.CAxis
    Dim objSpindle As DataAPI.CSpindle
    Dim objBallScrew As DataAPI.CBallScrew
    Dim objWorkpiece As DataAPI.CWorkpiece
    Dim objVariables As DataAPI.CVariables
    Dim objTool As DataAPI.CTools
    Dim m_objMultiTool As DataAPI.CTools
    Dim objSpec As DataAPI.CSpec
    Dim objMSpindle As DataAPI.CMSpindle
    Dim objProgram As DataAPI.CProgram
    Dim objChuck As DataAPI.CChuck
    Dim objTurret As DataAPI.CTurret
    Dim objTailStock As DataAPI.CTailStock
    Dim objATC As DataAPI.CATC
    Dim objIO As DataAPI.CIO
    Dim objOptionalParameter As Okuma.CLDATAPI.DataAPI.COptionalParameter

    Dim objMor As DataAPI.MacMan.COperatingReport
    Dim objMcAH As DataAPI.MacMan.CAlarmHistory
    Dim objMcOH As DataAPI.MacMan.COperationHistory
    Dim objMopnh As DataAPI.MacMan.COperatingHistory
    Dim OjbOptreport As DataAPI.MacMan.COperatingReport
    Dim objMeh As Okuma.CLDATAPI.DataAPI.MacMan.CMachiningReport



    Dim objCMDTool As CommandAPI.CTools
    Dim objCMDMachine As CommandAPI.CMachine
    Dim objCMDProgram As CommandAPI.CProgram
    Dim objCMDSpec As CommandAPI.CSpec
    Dim objSimulation As CommandAPI.CSimulation
    Dim m_objCmdATC As CommandAPI.CATC





    Private Sub ballscrewUpdate()

        Try


            Me.bsDataPoint.Text = objBallScrew.GetDataPoint(CInt(Me.bsPecPoint.Text), Me.bsDataPointCombo.SelectedValue)
            Me.bsInterval.Text = objBallScrew.GetInterval(Me.bsIntervalCombo.SelectedValue)

            Me.bsBAxisDataPoint.Text = objBallScrew.GetBAxisDataPoint(CInt(Me.bsPecPoint.Text))
            Me.bsBAxisInterval.Text = objBallScrew.GetBAxisInterval()
            Me.bsBAxisStartPosition.Text = objBallScrew.GetBAxisStartPosition()

        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub
    Public Sub Update_MSpindle()
        On Error GoTo sd


        Me.mspinActualMSpindleRate.Text = objMSpindle.GetActualMSpindlerate
        Me.mspinCommandMSpindleRate.Text = objMSpindle.GetCommandMSpindlerate
        Me.mspinCurrentToolInH1Turret.Text = objMSpindle.GetCurrentToolInH1Turret
        Me.mspinMSpindleLoad.Text = objMSpindle.GetMSpindleLoad
        Me.mspinSpindleRateOverride.Text = objMSpindle.GetSpindlerateOverride(Me.mspinSpindleRateOverrideCombo.SelectedValue)
        Me.mspinMSpindleState.Text = System.Enum.GetNames(GetType(SpindleStateEnum)).GetValue(objMSpindle.GetMSpindleState)

        Exit Sub
sd:
        DisplayError("CSpindle", Err.Description)
        Resume Next
    End Sub
    Public Sub Update_TailStock()
        Try


            Me.TailStockDiameter.Text = objTailStock.GetDiameter(Me.TailStockDiameterCombo.SelectedValue)
            Me.TailStockLength.Text = objTailStock.GetLength(Me.TailStockLengthCombo.SelectedValue)
            txtTailStockSpindlePosition.Text = objTailStock.GetTailstockSpindlePosition()

        Catch ae As ApplicationException
            DisplayError("CTailStock", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTailStock", ex.Message)
        End Try
    End Sub
    Public Sub Update_Turret()
        On Error GoTo sd

        Me.turTurretOffset.Text = objTurret.GetTurretOffset(CInt(Me.turToolNo.Text), Me.turToolOffsetAxisCombo.SelectedValue)
        Me.turTurretMode.Text = System.Enum.GetNames(GetType(TurretModeEnum)).GetValue(objTurret.GetTurretMode)

        Me.txtMaxToolPotPerTurret.Text = objTurret.GetMaxToolPots(cboTurretSides.SelectedValue)

        Me.turBAxisTurretOffset.Text = objTurret.GetBAxisTurretOffset(CInt(Me.turToolNo.Text), Me.turToolOffsetAxisCombo.SelectedValue, Me.turBAxisTurretCombo.SelectedValue)

        Exit Sub
sd:
        DisplayError("CTurret", Err.Description)
        Resume Next
    End Sub


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    


    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents tab_axis As System.Windows.Forms.TabPage
    Friend WithEvents tab_ballscrew As System.Windows.Forms.TabPage
    Friend WithEvents tab_machine As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents axisLoad As System.Windows.Forms.TextBox
    Friend WithEvents axisName As System.Windows.Forms.TextBox
    Friend WithEvents axisUpdateButton As System.Windows.Forms.Button
    Friend WithEvents axisTimerStart As System.Windows.Forms.Button
    Friend WithEvents AxisTimerStop As System.Windows.Forms.Button
    Friend WithEvents globalTimer As System.Windows.Forms.Timer
    Friend WithEvents tab_program As System.Windows.Forms.TabPage
    Friend WithEvents tab_spec As System.Windows.Forms.TabPage
    Friend WithEvents tab_spindle As System.Windows.Forms.TabPage
    Friend WithEvents tab_tools As System.Windows.Forms.TabPage
    Friend WithEvents tab_variables As System.Windows.Forms.TabPage
    Friend WithEvents tab_workpiece As System.Windows.Forms.TabPage
    Friend WithEvents bsDataPoint As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents bsInterval As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents ballscrewUpdateButton As System.Windows.Forms.Button
    Friend WithEvents bsDataPointUpdate As System.Windows.Forms.TextBox
    Friend WithEvents bsIntervalUpdate As System.Windows.Forms.TextBox
    Friend WithEvents bsDataPointSet As System.Windows.Forms.Button
    Friend WithEvents bsIntervalAdd As System.Windows.Forms.Button
    Friend WithEvents bsIntervalSet As System.Windows.Forms.Button
    Friend WithEvents machineUpdateButton As System.Windows.Forms.Button
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents label99 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents progExecutePoint As System.Windows.Forms.TextBox
    Friend WithEvents progRead As System.Windows.Forms.TextBox
    Friend WithEvents progColumn As System.Windows.Forms.TextBox
    Friend WithEvents progRow As System.Windows.Forms.TextBox
    Friend WithEvents progButtonGetRunProgram As System.Windows.Forms.Button
    Friend WithEvents progRunningPrograms As System.Windows.Forms.TextBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents specCode As System.Windows.Forms.TextBox
    Friend WithEvents specUpdateButton As System.Windows.Forms.Button
    Friend WithEvents specCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents spinUpdate As System.Windows.Forms.Button
    Friend WithEvents spinRateOverride As System.Windows.Forms.TextBox
    Friend WithEvents spinLoad As System.Windows.Forms.TextBox
    Friend WithEvents spinOilMist As System.Windows.Forms.TextBox
    Friend WithEvents spinCommandRate As System.Windows.Forms.TextBox
    Friend WithEvents spinActualRate As System.Windows.Forms.TextBox
    Friend WithEvents spinState As System.Windows.Forms.TextBox
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents tulReferenceToolOffset3 As System.Windows.Forms.TextBox
    Friend WithEvents tulReferenceToolOffset2 As System.Windows.Forms.TextBox
    Friend WithEvents tulToolLife As System.Windows.Forms.TextBox
    Friend WithEvents tulUpdateButton As System.Windows.Forms.Button
    Friend WithEvents tulToolNumber As System.Windows.Forms.TextBox
    Friend WithEvents label100 As System.Windows.Forms.Label
    Friend WithEvents tulUpdReferenceToolOffset3 As System.Windows.Forms.TextBox
    Friend WithEvents tulUpdReferenceToolOffset2 As System.Windows.Forms.TextBox
    Friend WithEvents tulUpdToolLife As System.Windows.Forms.TextBox
    Friend WithEvents tulSetReferenceToolOffset3 As System.Windows.Forms.Button
    Friend WithEvents tulSetReferenceToolOffset2 As System.Windows.Forms.Button
    Friend WithEvents tulSetToolLife As System.Windows.Forms.Button
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents varValueUpdate As System.Windows.Forms.TextBox
    Friend WithEvents varAddValue As System.Windows.Forms.Button
    Friend WithEvents varSetValue As System.Windows.Forms.Button
    Friend WithEvents varEnd As System.Windows.Forms.TextBox
    Friend WithEvents varBegin As System.Windows.Forms.TextBox
    Friend WithEvents varGetAllResults As System.Windows.Forms.TextBox
    Friend WithEvents varNumberOfVars As System.Windows.Forms.TextBox
    Friend WithEvents varGetAllButton As System.Windows.Forms.Button
    Friend WithEvents varCommonVarNumber As System.Windows.Forms.TextBox
    Friend WithEvents varUpdateButton As System.Windows.Forms.Button
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents varValue As System.Windows.Forms.TextBox
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents wkCounterCombo As System.Windows.Forms.ComboBox
    Friend WithEvents wkUpdateCounter As System.Windows.Forms.TextBox
    Friend WithEvents wkCounterValue As System.Windows.Forms.TextBox
    Friend WithEvents wkUpdateZeroOffset As System.Windows.Forms.TextBox
    Friend WithEvents wkZeroOffset As System.Windows.Forms.TextBox
    Friend WithEvents wkUpdateValsWithNoParams As System.Windows.Forms.Button
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents tab_MacManAlarmHistory As System.Windows.Forms.TabPage
    Friend WithEvents tab_MacmanOperatingReport As System.Windows.Forms.TabPage
    Friend WithEvents tab_MacmanOperatingHistory As System.Windows.Forms.TabPage
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents Label105 As System.Windows.Forms.Label
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents mahAlarmIndex As System.Windows.Forms.TextBox
    Friend WithEvents mahAlarmCount As System.Windows.Forms.TextBox
    Friend WithEvents mahAlarmTime As System.Windows.Forms.TextBox
    Friend WithEvents mahAlarmNumber As System.Windows.Forms.TextBox
    Friend WithEvents mahAlarmMessage As System.Windows.Forms.TextBox
    Friend WithEvents mahAlarmDate As System.Windows.Forms.TextBox
    Friend WithEvents mahAlarmCode As System.Windows.Forms.TextBox
    Friend WithEvents mahUpdateButton As System.Windows.Forms.Button
    Friend WithEvents mahMaxAlarmCount As System.Windows.Forms.TextBox
    Friend WithEvents mohUpdateButton As System.Windows.Forms.Button
    Friend WithEvents mohOperationIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label113 As System.Windows.Forms.Label
    Friend WithEvents mohOperationTime As System.Windows.Forms.TextBox
    Friend WithEvents Label116 As System.Windows.Forms.Label
    Friend WithEvents mohOperationDate As System.Windows.Forms.TextBox
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents mohOperationData As System.Windows.Forms.TextBox
    Friend WithEvents Label118 As System.Windows.Forms.Label
    Friend WithEvents Label119 As System.Windows.Forms.Label
    Friend WithEvents Label120 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents spinComboAxis As System.Windows.Forms.ComboBox
    Friend WithEvents MSpindle As System.Windows.Forms.TabPage
    Friend WithEvents tulCurrentNoseRCompNumber As System.Windows.Forms.TextBox
    Friend WithEvents tulUpdLifeStatus As System.Windows.Forms.ComboBox
    Friend WithEvents tulLifeStatus As System.Windows.Forms.TextBox
    Friend WithEvents tulGroupNumber As System.Windows.Forms.TextBox
    Friend WithEvents tulCurrentToolOffsetNumber As System.Windows.Forms.TextBox
    Friend WithEvents tulGauseStatus As System.Windows.Forms.TextBox
    Friend WithEvents tulCurrentToolNumber As System.Windows.Forms.TextBox
    Friend WithEvents tulUpdToolWearOffset As System.Windows.Forms.TextBox
    Friend WithEvents tulToolWearOffset As System.Windows.Forms.TextBox
    Friend WithEvents tulUpdToolOffset As System.Windows.Forms.TextBox
    Friend WithEvents tulToolOffset As System.Windows.Forms.TextBox
    Friend WithEvents tulUpdToolNumberInGroup As System.Windows.Forms.TextBox
    Friend WithEvents tulToolNumberInGroup As System.Windows.Forms.TextBox
    Friend WithEvents tulSetGauseStatus As System.Windows.Forms.Button
    Friend WithEvents tulSetToolNumberInGroup As System.Windows.Forms.Button
    Friend WithEvents tulSetToolOffset As System.Windows.Forms.Button
    Friend WithEvents tulSetGroupNumber As System.Windows.Forms.Button
    Friend WithEvents tulUpdGroupNumber As System.Windows.Forms.TextBox
    Friend WithEvents tulComboToolOffset As System.Windows.Forms.ComboBox
    Friend WithEvents tulComboToolLife As System.Windows.Forms.ComboBox
    Friend WithEvents tulComboToolWearOffset As System.Windows.Forms.ComboBox
    Friend WithEvents tulSetToolWearOffset As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TulNoseRCompensation As System.Windows.Forms.TextBox
    Friend WithEvents TulUpdNoseRCompensation As System.Windows.Forms.TextBox
    Friend WithEvents TulSetNoseRCompensation As System.Windows.Forms.Button
    Friend WithEvents TulComboNoseRCompensation As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TulSetNoseRCompensationPattern As System.Windows.Forms.Button
    Friend WithEvents TulUpdNoseRCompensationPattern As System.Windows.Forms.TextBox
    Friend WithEvents TulNoseRCompensationPattern As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tulComboActualToolLife As System.Windows.Forms.ComboBox
    Friend WithEvents tulUpdActualToolLife As System.Windows.Forms.TextBox
    Friend WithEvents tulActualToolLife As System.Windows.Forms.TextBox
    Friend WithEvents tulSetActualToolLife As System.Windows.Forms.Button
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tulSetReferenceToolOffset1 As System.Windows.Forms.Button
    Friend WithEvents tulUpdReferenceToolOffset1 As System.Windows.Forms.TextBox
    Friend WithEvents tulReferenceToolOffset1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tulAddToolWearOffset As System.Windows.Forms.Button
    Friend WithEvents tulAddToolOffset As System.Windows.Forms.Button
    Friend WithEvents TulAddNoseRCompensation As System.Windows.Forms.Button
    Friend WithEvents wkCalZeroOffset As System.Windows.Forms.Button
    Friend WithEvents wkAddZeroOffset As System.Windows.Forms.Button
    Friend WithEvents wkSetZeroOffset As System.Windows.Forms.Button
    Friend WithEvents wkGetCounterValue As System.Windows.Forms.Button
    Friend WithEvents wkSetCounterValue As System.Windows.Forms.Button
    Friend WithEvents wkZeroOffsetCombo As System.Windows.Forms.ComboBox
    Friend WithEvents wkGetZeroOffset As System.Windows.Forms.Button
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents varGetValue As System.Windows.Forms.Button
    Friend WithEvents TulNoseRCompensationPatternFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TulNoseRCompensationPatternTo As System.Windows.Forms.TextBox
    Friend WithEvents tulResults As System.Windows.Forms.TextBox
    Friend WithEvents tulSetLifeStatus As System.Windows.Forms.Button
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents specSaddleSpec As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents mspinActualMSpindleRate As System.Windows.Forms.TextBox
    Friend WithEvents mspinCommandMSpindleRate As System.Windows.Forms.TextBox
    Friend WithEvents mspinCurrentToolInH1Turret As System.Windows.Forms.TextBox
    Friend WithEvents mspinMSpindleLoad As System.Windows.Forms.TextBox
    Friend WithEvents mspinMSpindleState As System.Windows.Forms.TextBox
    Friend WithEvents mspinSpindleRateOverride As System.Windows.Forms.TextBox
    Friend WithEvents mspinSpindleRateOverrideCombo As System.Windows.Forms.ComboBox
    Friend WithEvents mspinSubSystemCombo As System.Windows.Forms.ComboBox
    Friend WithEvents mspinUpdate As System.Windows.Forms.Button
    Friend WithEvents mspinSetSubSystem As System.Windows.Forms.Button
    Friend WithEvents progGetMCodes As System.Windows.Forms.Button
    Friend WithEvents progMCodes As System.Windows.Forms.TextBox
    Friend WithEvents progMCodesCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label115 As System.Windows.Forms.Label
    Friend WithEvents bsPecPoint As System.Windows.Forms.TextBox
    Friend WithEvents bsDataPointCombo As System.Windows.Forms.ComboBox
    Friend WithEvents bsIntervalCombo As System.Windows.Forms.ComboBox
    Friend WithEvents bsDataPointAdd As System.Windows.Forms.Button
    Friend WithEvents bsBAxisDataPointAdd As System.Windows.Forms.Button
    Friend WithEvents bsBAxisDataPointSet As System.Windows.Forms.Button
    Friend WithEvents bsBAxisDataPointUpdate As System.Windows.Forms.TextBox
    Friend WithEvents bsBAxisDataPoint As System.Windows.Forms.TextBox
    Friend WithEvents bsBAxisIntervalUpdate As System.Windows.Forms.TextBox
    Friend WithEvents bsBAxisInterval As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents bsBAxisIntervalAdd As System.Windows.Forms.Button
    Friend WithEvents bsBAxisIntervalSet As System.Windows.Forms.Button
    Friend WithEvents bsBAxisStartPositionAdd As System.Windows.Forms.Button
    Friend WithEvents bsBAxisStartPositionSet As System.Windows.Forms.Button
    Friend WithEvents bsBAxisStartPositionUpdate As System.Windows.Forms.TextBox
    Friend WithEvents bsBAxisStartPosition As System.Windows.Forms.TextBox
    Friend WithEvents spinSpindleMode As System.Windows.Forms.TextBox
    Friend WithEvents spinSpindleSurfaceSpeed As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents chuckIndexEnum As System.Windows.Forms.ComboBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents tab_Chuck As System.Windows.Forms.TabPage
    Friend WithEvents chuckHold As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents chuckGrippingDiameter As System.Windows.Forms.TextBox
    Friend WithEvents chuckGrippingDiameterUpd As System.Windows.Forms.TextBox
    Friend WithEvents chuckGrippingFaceToDistanceUpd As System.Windows.Forms.TextBox
    Friend WithEvents chuckGrippingFaceToDistance As System.Windows.Forms.TextBox
    Friend WithEvents chuckGrippingFaceWidthUpd As System.Windows.Forms.TextBox
    Friend WithEvents chuckGrippingFaceWidth As System.Windows.Forms.TextBox
    Friend WithEvents chuckGrippingLengthUpd As System.Windows.Forms.TextBox
    Friend WithEvents chuckGrippingLength As System.Windows.Forms.TextBox
    Friend WithEvents chuckJawLengthUpd As System.Windows.Forms.TextBox
    Friend WithEvents chuckJawLength As System.Windows.Forms.TextBox
    Friend WithEvents chuckJawSizeUpd As System.Windows.Forms.TextBox
    Friend WithEvents chuckJawSize As System.Windows.Forms.TextBox
    Friend WithEvents chuckSecondChuckZeroOffsetUpd As System.Windows.Forms.TextBox
    Friend WithEvents chuckSecondChuckZeroOffset As System.Windows.Forms.TextBox
    Friend WithEvents chuckGrippingDiameterAdd As System.Windows.Forms.Button
    Friend WithEvents chuckGrippingDiameterSet As System.Windows.Forms.Button
    Friend WithEvents chuckGrippingFaceToDistanceAdd As System.Windows.Forms.Button
    Friend WithEvents chuckGrippingFaceToDistanceSet As System.Windows.Forms.Button
    Friend WithEvents chuckGrippingFaceWidthAdd As System.Windows.Forms.Button
    Friend WithEvents chuckGrippingFaceWidthSet As System.Windows.Forms.Button
    Friend WithEvents chuckGrippingLengthAdd As System.Windows.Forms.Button
    Friend WithEvents chuckGrippingLengthSet As System.Windows.Forms.Button
    Friend WithEvents chuckJawLengthAdd As System.Windows.Forms.Button
    Friend WithEvents chuckJawLengthSet As System.Windows.Forms.Button
    Friend WithEvents chuckJawSizeAdd As System.Windows.Forms.Button
    Friend WithEvents chuckJawSizeSet As System.Windows.Forms.Button
    Friend WithEvents chuckSecondChuckZeroOffsetAdd As System.Windows.Forms.Button
    Friend WithEvents chuckSecondChuckZeroOffsetSet As System.Windows.Forms.Button
    Friend WithEvents chuckUpdateButton As System.Windows.Forms.Button
    Friend WithEvents chuckHoldCombo As System.Windows.Forms.ComboBox
    Friend WithEvents chuckHoldSet As System.Windows.Forms.Button
    Friend WithEvents chuckGrippingDiameterCal As System.Windows.Forms.Button
    Friend WithEvents chuckGrippingFaceToDistanceCal As System.Windows.Forms.Button
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents turBAxisTurretOffset As System.Windows.Forms.TextBox
    Friend WithEvents turBAxisTurretOffsetUpd As System.Windows.Forms.TextBox
    Friend WithEvents turBAxisTurretOffsetSet As System.Windows.Forms.Button
    Friend WithEvents turBAxisTurretOffsetAdd As System.Windows.Forms.Button
    Friend WithEvents turTurretOffsetAdd As System.Windows.Forms.Button
    Friend WithEvents turTurretOffsetSet As System.Windows.Forms.Button
    Friend WithEvents turTurretOffsetUpd As System.Windows.Forms.TextBox
    Friend WithEvents turTurretOffset As System.Windows.Forms.TextBox
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents turTurretMode As System.Windows.Forms.TextBox
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents turUpdate As System.Windows.Forms.Button
    Friend WithEvents turToolNo As System.Windows.Forms.TextBox
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents turToolOffsetAxisCombo As System.Windows.Forms.ComboBox
    Friend WithEvents turBAxisTurretCombo As System.Windows.Forms.ComboBox
    Friend WithEvents tab_TailStock As System.Windows.Forms.TabPage
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents TailStockDiameterCombo As System.Windows.Forms.ComboBox
    Friend WithEvents TailStockLengthCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label114 As System.Windows.Forms.Label
    Friend WithEvents Label121 As System.Windows.Forms.Label
    Friend WithEvents TailStockDiameter As System.Windows.Forms.TextBox
    Friend WithEvents TailStockDiameterSet As System.Windows.Forms.Button
    Friend WithEvents TailStockDiameterUpd As System.Windows.Forms.TextBox
    Friend WithEvents TailStockLengthSet As System.Windows.Forms.Button
    Friend WithEvents TailStockDiameterAdd As System.Windows.Forms.Button
    Friend WithEvents TailStockLengthAdd As System.Windows.Forms.Button
    Friend WithEvents TailStockLengthUpd As System.Windows.Forms.TextBox
    Friend WithEvents Label122 As System.Windows.Forms.Label
    Friend WithEvents TailStockLength As System.Windows.Forms.TextBox
    Friend WithEvents tailstockUpdate As System.Windows.Forms.Button
    Friend WithEvents AxismaxFeedrateOverride As System.Windows.Forms.TextBox
    Friend WithEvents AxisBAxisLoad As System.Windows.Forms.TextBox
    Friend WithEvents AxisfeedrateOverride As System.Windows.Forms.TextBox
    Friend WithEvents AxisfeedHold As System.Windows.Forms.TextBox
    Friend WithEvents AxistargetPosition As System.Windows.Forms.TextBox
    Friend WithEvents AxisdistanceTarget As System.Windows.Forms.TextBox
    Friend WithEvents AxiscommandFeedRate As System.Windows.Forms.TextBox
    Friend WithEvents AxisAPProgramCoord As System.Windows.Forms.TextBox
    Friend WithEvents AxisAPMachineCoord As System.Windows.Forms.TextBox
    Friend WithEvents AxisAPEncoderCoord As System.Windows.Forms.TextBox
    Friend WithEvents AxisActualFeedrate As System.Windows.Forms.TextBox
    Friend WithEvents Label123 As System.Windows.Forms.Label
    Friend WithEvents axis2Combo As System.Windows.Forms.ComboBox
    Friend WithEvents axis1Combo As System.Windows.Forms.ComboBox
    Friend WithEvents axisAllCombo As System.Windows.Forms.ComboBox
    Friend WithEvents tab_CMDTool As System.Windows.Forms.TabPage
    Friend WithEvents toolOffsetAxis1Combo As System.Windows.Forms.ComboBox
    Friend WithEvents Label124 As System.Windows.Forms.Label
    Friend WithEvents Label125 As System.Windows.Forms.Label
    Friend WithEvents toolOffsetAxis2Combo As System.Windows.Forms.ComboBox
    Friend WithEvents Label126 As System.Windows.Forms.Label
    Friend WithEvents toolSubSystemsCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label127 As System.Windows.Forms.Label
    Friend WithEvents toolCuttingPositionsCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label128 As System.Windows.Forms.Label
    Friend WithEvents toolSensorDirectionCombo As System.Windows.Forms.ComboBox
    Friend WithEvents toolToolNo As System.Windows.Forms.TextBox
    Friend WithEvents Label130 As System.Windows.Forms.Label
    Friend WithEvents toolAddMethod As System.Windows.Forms.Button
    Friend WithEvents toolCalToolOffset As System.Windows.Forms.TextBox
    Friend WithEvents toolAutoCalToolOffsetExe As System.Windows.Forms.Button
    Friend WithEvents toolCalToolOffsetExe As System.Windows.Forms.Button
    Friend WithEvents toolMeasureCalToolOffsetExe As System.Windows.Forms.Button
    Friend WithEvents Label134 As System.Windows.Forms.Label
    Friend WithEvents mahAlarmSubSystemSet As System.Windows.Forms.Button
    Friend WithEvents mahAlarmSubSystemCombo As System.Windows.Forms.ComboBox
    Friend WithEvents mahAlarmObject As System.Windows.Forms.TextBox
    Friend WithEvents Label135 As System.Windows.Forms.Label
    Friend WithEvents mohSubSystemSet As System.Windows.Forms.Button
    Friend WithEvents mohSubSystemCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label136 As System.Windows.Forms.Label
    Friend WithEvents mohMaxCount As System.Windows.Forms.TextBox
    Friend WithEvents mohCount As System.Windows.Forms.TextBox
    Friend WithEvents Label137 As System.Windows.Forms.Label
    Friend WithEvents Label138 As System.Windows.Forms.Label
    Friend WithEvents mahTo As System.Windows.Forms.TextBox
    Friend WithEvents mahFrom As System.Windows.Forms.TextBox
    Friend WithEvents mahResults As System.Windows.Forms.TextBox
    Friend WithEvents mahButtonResults As System.Windows.Forms.Button
    Friend WithEvents mohTo As System.Windows.Forms.TextBox
    Friend WithEvents Label139 As System.Windows.Forms.Label
    Friend WithEvents mohFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label140 As System.Windows.Forms.Label
    Friend WithEvents mohResults As System.Windows.Forms.TextBox
    Friend WithEvents mohButtonResults As System.Windows.Forms.Button
    Friend WithEvents macMDICommand As System.Windows.Forms.TextBox
    Friend WithEvents macMDIExecButton As System.Windows.Forms.Button
    Friend WithEvents Label146 As System.Windows.Forms.Label
    Friend WithEvents prog4 As System.Windows.Forms.TextBox
    Friend WithEvents prog3 As System.Windows.Forms.TextBox
    Friend WithEvents Label147 As System.Windows.Forms.Label
    Friend WithEvents prog2 As System.Windows.Forms.TextBox
    Friend WithEvents Label148 As System.Windows.Forms.Label
    Friend WithEvents prog1 As System.Windows.Forms.TextBox
    Friend WithEvents Label149 As System.Windows.Forms.Label
    Friend WithEvents progSelectProgramButton As System.Windows.Forms.Button
    Friend WithEvents progCancelProgramButton As System.Windows.Forms.Button
    Friend WithEvents Tools2 As System.Windows.Forms.TabPage
    Friend WithEvents tulButtonNoseRPattern As System.Windows.Forms.Button
    Friend WithEvents tulButtonNoseRComp As System.Windows.Forms.Button
    Friend WithEvents tulButtonToolOffset As System.Windows.Forms.Button
    Friend WithEvents tulButtonToolWear As System.Windows.Forms.Button
    Friend WithEvents tul1ComboNoseRComp As System.Windows.Forms.ComboBox
    Friend WithEvents tul1ComboToolOffset As System.Windows.Forms.ComboBox
    Friend WithEvents CATC As System.Windows.Forms.TabPage
    Friend WithEvents Label150 As System.Windows.Forms.Label
    Friend WithEvents atcResults As System.Windows.Forms.TextBox
    Friend WithEvents atcUpdate As System.Windows.Forms.Button
    Friend WithEvents tul2Button1 As System.Windows.Forms.Button
    Friend WithEvents tul2set1 As System.Windows.Forms.TextBox
    Friend WithEvents tul2get1 As System.Windows.Forms.TextBox
    Friend WithEvents Label151 As System.Windows.Forms.Label
    Friend WithEvents tul2Button3 As System.Windows.Forms.Button
    Friend WithEvents tul2Button2 As System.Windows.Forms.Button
    Friend WithEvents tul2set3 As System.Windows.Forms.TextBox
    Friend WithEvents tul2set2 As System.Windows.Forms.TextBox
    Friend WithEvents tul2get3 As System.Windows.Forms.TextBox
    Friend WithEvents Label152 As System.Windows.Forms.Label
    Friend WithEvents tul2get2 As System.Windows.Forms.TextBox
    Friend WithEvents Label153 As System.Windows.Forms.Label
    Friend WithEvents tul2ba1 As System.Windows.Forms.ComboBox
    Friend WithEvents tul2ba2 As System.Windows.Forms.ComboBox
    Friend WithEvents tul2ba3 As System.Windows.Forms.ComboBox
    Friend WithEvents tul2pa3 As System.Windows.Forms.ComboBox
    Friend WithEvents tul2pa2 As System.Windows.Forms.ComboBox
    Friend WithEvents tul2pa1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label154 As System.Windows.Forms.Label
    Friend WithEvents Label155 As System.Windows.Forms.Label
    Friend WithEvents tul2ButtonUpdate As System.Windows.Forms.Button
    Friend WithEvents tul2tn As System.Windows.Forms.TextBox
    Friend WithEvents Label156 As System.Windows.Forms.Label
    Friend WithEvents chuckWorkType As System.Windows.Forms.TextBox
    Friend WithEvents Label157 As System.Windows.Forms.Label
    Friend WithEvents chuckWorkTypeCombo As System.Windows.Forms.ComboBox
    Friend WithEvents chuckButtonSetWorkType As System.Windows.Forms.Button
    Friend WithEvents cmb_Currentsubsystem As System.Windows.Forms.ComboBox
    Friend WithEvents Label159 As System.Windows.Forms.Label
    Friend WithEvents Label160 As System.Windows.Forms.Label
    Friend WithEvents cmb_Currentdataunit As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_FeedRate As System.Windows.Forms.TextBox
    Friend WithEvents Label158 As System.Windows.Forms.Label
    Friend WithEvents cmb_BallScrew_SubSystem As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_BallScrew_DataUnit As System.Windows.Forms.ComboBox
    Friend WithEvents Label161 As System.Windows.Forms.Label
    Friend WithEvents Label162 As System.Windows.Forms.Label
    Friend WithEvents cmb_Chuck_SubSys As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_Chuck_Dataunit As System.Windows.Forms.ComboBox
    Friend WithEvents Label163 As System.Windows.Forms.Label
    Friend WithEvents Label164 As System.Windows.Forms.Label
    Friend WithEvents Label165 As System.Windows.Forms.Label
    Friend WithEvents cmb_Machine_SubSys As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_Spindle_SubSys As System.Windows.Forms.ComboBox
    Friend WithEvents Label167 As System.Windows.Forms.Label
    Friend WithEvents Label169 As System.Windows.Forms.Label
    Friend WithEvents Label170 As System.Windows.Forms.Label
    Friend WithEvents cmb_Tail_SubSys As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_Tail_Dataunit As System.Windows.Forms.ComboBox
    Friend WithEvents cmd_tailStock_SetAxisPos As System.Windows.Forms.Button
    Friend WithEvents Label171 As System.Windows.Forms.Label

    Friend WithEvents cmd_tailStock_AddAxisPos As System.Windows.Forms.Button
    Friend WithEvents cmd_tailStock_CalAxisPos As System.Windows.Forms.Button
    Friend WithEvents Label172 As System.Windows.Forms.Label
    Friend WithEvents Label173 As System.Windows.Forms.Label
    Friend WithEvents cmb_Tool2_DataUnit As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_Tool2_SubSys As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_Turret_DataUnit As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_Turret_subsys As System.Windows.Forms.ComboBox
    Friend WithEvents Label176 As System.Windows.Forms.Label
    Friend WithEvents cmb_Variable_SubSys As System.Windows.Forms.ComboBox
    Friend WithEvents Panel17 As System.Windows.Forms.Panel
    Friend WithEvents Btn_AddCompensation As System.Windows.Forms.Button
    Friend WithEvents Label178 As System.Windows.Forms.Label
    Friend WithEvents Cmb_NoseRCompensationAxisIndex As System.Windows.Forms.ComboBox
    Friend WithEvents Btn_GetNose2 As System.Windows.Forms.Button
    Friend WithEvents Btn_GetNose As System.Windows.Forms.Button
    Friend WithEvents cmd_Ctools2_setToolOffset As System.Windows.Forms.Button
    Friend WithEvents cmd_Ctools2_AddToolOffset As System.Windows.Forms.Button
    Friend WithEvents txt_CTools2_ToolOffSet As System.Windows.Forms.TextBox
    Friend WithEvents cbo_Ctools2_getToolOffset As System.Windows.Forms.Button
    Friend WithEvents cbo_Ctools2_ToolOffSetAxisIndex As System.Windows.Forms.ComboBox
    Friend WithEvents txt_CTools2_fromindx As System.Windows.Forms.TextBox
    Friend WithEvents Label180 As System.Windows.Forms.Label
    Friend WithEvents Label181 As System.Windows.Forms.Label
    Friend WithEvents txt_CTools2_toindx As System.Windows.Forms.TextBox
    Friend WithEvents Label182 As System.Windows.Forms.Label
    Friend WithEvents Label183 As System.Windows.Forms.Label
    Friend WithEvents cbo_Ctools2_Cutpos As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_Ctools2_getToolOffset2 As System.Windows.Forms.Button
    Friend WithEvents btn_setCompensation As System.Windows.Forms.Button
    Friend WithEvents txt_CTools2_ToolIntNDX As System.Windows.Forms.TextBox
    Friend WithEvents txtCTool2_NoseRCompensationPatternSettingValue As System.Windows.Forms.TextBox
    Friend WithEvents Label184 As System.Windows.Forms.Label
    Friend WithEvents Label192 As System.Windows.Forms.Label
    Friend WithEvents Label193 As System.Windows.Forms.Label
    Friend WithEvents cmb_ToolWearOffsetAxisIndex As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_CuttingPosition As System.Windows.Forms.ComboBox
    Friend WithEvents txt_ToIndex As System.Windows.Forms.TextBox
    Friend WithEvents txt_FromIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label194 As System.Windows.Forms.Label
    Friend WithEvents txt_double1 As System.Windows.Forms.TextBox
    Friend WithEvents GetToolWearOffsetButton As System.Windows.Forms.Button
    Friend WithEvents tul2AddToolWearOffset As System.Windows.Forms.Button
    Friend WithEvents txt_getValue As System.Windows.Forms.TextBox
    Friend WithEvents Label197 As System.Windows.Forms.Label
    Friend WithEvents Label198 As System.Windows.Forms.Label
    Friend WithEvents tul3tn As System.Windows.Forms.TextBox
    Friend WithEvents Label199 As System.Windows.Forms.Label
    Friend WithEvents tu3_Update As System.Windows.Forms.Button
    Friend WithEvents tul3_Set As System.Windows.Forms.Button
    Friend WithEvents tul3get4 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label216 As System.Windows.Forms.Label
    Friend WithEvents Cmb_rptPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents MacReport_programname As System.Windows.Forms.TextBox
    Friend WithEvents Label217 As System.Windows.Forms.Label
    Friend WithEvents Macreport_filename As System.Windows.Forms.TextBox
    Friend WithEvents Label218 As System.Windows.Forms.Label
    Friend WithEvents MacReport_count As System.Windows.Forms.TextBox
    Friend WithEvents Label219 As System.Windows.Forms.Label
    Friend WithEvents macReportUpdateButton As System.Windows.Forms.Button
    Friend WithEvents MacReport_Index As System.Windows.Forms.TextBox
    Friend WithEvents Label220 As System.Windows.Forms.Label
    Friend WithEvents macreport_Operatingtime As System.Windows.Forms.TextBox
    Friend WithEvents Label225 As System.Windows.Forms.Label
    Friend WithEvents macreport_Runningtime As System.Windows.Forms.TextBox
    Friend WithEvents Label226 As System.Windows.Forms.Label
    Friend WithEvents Macreportdate As System.Windows.Forms.TextBox
    Friend WithEvents Label227 As System.Windows.Forms.Label
    Friend WithEvents macreport_maxcount As System.Windows.Forms.TextBox
    Friend WithEvents Label228 As System.Windows.Forms.Label
    Friend WithEvents macreport_cuttingtime As System.Windows.Forms.TextBox
    Friend WithEvents Label229 As System.Windows.Forms.Label
    Friend WithEvents Label221 As System.Windows.Forms.Label
    Friend WithEvents Label222 As System.Windows.Forms.Label
    Friend WithEvents macreport_result As System.Windows.Forms.Button
    Friend WithEvents txtto As System.Windows.Forms.TextBox
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents tab_views As System.Windows.Forms.TabPage
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Label231 As System.Windows.Forms.Label
    Friend WithEvents Cmb_ChangeScreen As System.Windows.Forms.ComboBox
    Friend WithEvents cmd_ChangeScreen As System.Windows.Forms.Button
    Friend WithEvents txt_screenname As System.Windows.Forms.TextBox
    Friend WithEvents Label232 As System.Windows.Forms.Label
    Friend WithEvents cmd_addWorkpiece As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCycleCompleteCombo As System.Windows.Forms.ComboBox
    Friend WithEvents ScheduleProgramCycleCompleteCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label230 As System.Windows.Forms.Label
    Friend WithEvents ScheduleProgramCycleComplete As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents progButtonCycleStatus As System.Windows.Forms.Button
    Friend WithEvents Label248 As System.Windows.Forms.Label
    Friend WithEvents MaxSpindleRateOverride As System.Windows.Forms.TextBox
    Friend WithEvents tulAddToolLife_button As System.Windows.Forms.Button
    Friend WithEvents Label249 As System.Windows.Forms.Label
    Friend WithEvents TxtRunningPrograme As System.Windows.Forms.TextBox
    Friend WithEvents TxtCycleComplte As System.Windows.Forms.TextBox
    Friend WithEvents Label253 As System.Windows.Forms.Label
    Friend WithEvents TxtProgrameCycleComplete As System.Windows.Forms.TextBox
    Friend WithEvents Label254 As System.Windows.Forms.Label
    Friend WithEvents Label252 As System.Windows.Forms.Label
    Friend WithEvents CMD_SETOPERATINGHISTORY As System.Windows.Forms.Button
    Friend WithEvents CMB_OPERATINGHISTORY As System.Windows.Forms.ComboBox
    Friend WithEvents Label256 As System.Windows.Forms.Label
    Friend WithEvents cmb_WorkpieceDataunit As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents tulMaxToolOffset As System.Windows.Forms.TextBox
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents Label241 As System.Windows.Forms.Label
    Friend WithEvents McORSubSystemCombo As System.Windows.Forms.ComboBox
    Friend WithEvents cmdAddActualToolLife As System.Windows.Forms.Button
    Friend WithEvents Label243 As System.Windows.Forms.Label
    Friend WithEvents Label244 As System.Windows.Forms.Label
    Friend WithEvents Label195 As System.Windows.Forms.Label
    Friend WithEvents Label196 As System.Windows.Forms.Label
    Friend WithEvents Tools3 As System.Windows.Forms.TabPage
    Friend WithEvents Label233 As System.Windows.Forms.Label
    Friend WithEvents txtTailStockSpindlePosition As System.Windows.Forms.TextBox
    Friend WithEvents txtTailStockSpindlePositionSetting As System.Windows.Forms.TextBox
    Friend WithEvents Label245 As System.Windows.Forms.Label
    Friend WithEvents Label246 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents mopnhAlarmOnTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhExternalInputTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhSpindleRunTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhOtherTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhMaintenanceTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPartWaitingTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhNoOperatorTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhInProSetupTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhNonOperatingReport As System.Windows.Forms.TextBox
    Friend WithEvents mopnhCuttingTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhRunningTime As System.Windows.Forms.TextBox
    Friend WithEvents Label200 As System.Windows.Forms.Label
    Friend WithEvents Label201 As System.Windows.Forms.Label
    Friend WithEvents Label202 As System.Windows.Forms.Label
    Friend WithEvents Label203 As System.Windows.Forms.Label
    Friend WithEvents Label204 As System.Windows.Forms.Label
    Friend WithEvents Label205 As System.Windows.Forms.Label
    Friend WithEvents Label206 As System.Windows.Forms.Label
    Friend WithEvents Label207 As System.Windows.Forms.Label
    Friend WithEvents Label208 As System.Windows.Forms.Label
    Friend WithEvents Label209 As System.Windows.Forms.Label
    Friend WithEvents Label210 As System.Windows.Forms.Label
    Friend WithEvents Label211 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents mopnhPrevAlarmonTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevExternalInputTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevSpindleRunTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevOtherTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevMaintenanceTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevPartWaitingTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevNoOperatorTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevInProSetupTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevNonOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevCuttingTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents Label223 As System.Windows.Forms.Label
    Friend WithEvents Label247 As System.Windows.Forms.Label
    Friend WithEvents Label250 As System.Windows.Forms.Label
    Friend WithEvents Label251 As System.Windows.Forms.Label
    Friend WithEvents Label255 As System.Windows.Forms.Label
    Friend WithEvents Label257 As System.Windows.Forms.Label
    Friend WithEvents Label258 As System.Windows.Forms.Label
    Friend WithEvents Label259 As System.Windows.Forms.Label
    Friend WithEvents Label260 As System.Windows.Forms.Label
    Friend WithEvents Label261 As System.Windows.Forms.Label
    Friend WithEvents Label262 As System.Windows.Forms.Label
    Friend WithEvents Label263 As System.Windows.Forms.Label
    Friend WithEvents mopnhPrevRunningTime As System.Windows.Forms.TextBox
    Friend WithEvents Label191 As System.Windows.Forms.Label
    Friend WithEvents mopnhMaxNoofReports As System.Windows.Forms.TextBox
    Friend WithEvents objMopnhUpdateButton As System.Windows.Forms.Button
    Friend WithEvents Label212 As System.Windows.Forms.Label
    Friend WithEvents Label213 As System.Windows.Forms.Label
    Friend WithEvents mopnhTo As System.Windows.Forms.TextBox
    Friend WithEvents mopnhFrom As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents morPeriodDateOfOperatingReport As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodAlarmOnTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodExternalInputTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodSpindleRunTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodOtherTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodMaintenanceTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodNoOperatorTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodPartWaitingTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodInproSetupTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodNonOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodCuttingTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodRunningTime As System.Windows.Forms.TextBox
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents Label108 As System.Windows.Forms.Label
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents Label111 As System.Windows.Forms.Label
    Friend WithEvents Label112 As System.Windows.Forms.Label
    Friend WithEvents Label133 As System.Windows.Forms.Label
    Friend WithEvents Label234 As System.Windows.Forms.Label
    Friend WithEvents Label235 As System.Windows.Forms.Label
    Friend WithEvents Label236 As System.Windows.Forms.Label
    Friend WithEvents Label237 As System.Windows.Forms.Label
    Friend WithEvents Label238 As System.Windows.Forms.Label
    Friend WithEvents morPeriodOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents Label239 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label240 As System.Windows.Forms.Label
    Friend WithEvents morOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents Label264 As System.Windows.Forms.Label
    Friend WithEvents Label265 As System.Windows.Forms.Label
    Friend WithEvents Label266 As System.Windows.Forms.Label
    Friend WithEvents Label267 As System.Windows.Forms.Label
    Friend WithEvents Label268 As System.Windows.Forms.Label
    Friend WithEvents Label269 As System.Windows.Forms.Label
    Friend WithEvents morRunningTime As System.Windows.Forms.TextBox
    Friend WithEvents morCuttingTime As System.Windows.Forms.TextBox
    Friend WithEvents morNonOPeratingTime As System.Windows.Forms.TextBox
    Friend WithEvents morInProSetupTime As System.Windows.Forms.TextBox
    Friend WithEvents morNoOperatorTime As System.Windows.Forms.TextBox
    Friend WithEvents morPartWaitingTime As System.Windows.Forms.TextBox
    Friend WithEvents Label270 As System.Windows.Forms.Label
    Friend WithEvents mormaintenanceTime As System.Windows.Forms.TextBox
    Friend WithEvents Label271 As System.Windows.Forms.Label
    Friend WithEvents morOtherTime As System.Windows.Forms.TextBox
    Friend WithEvents Label272 As System.Windows.Forms.Label
    Friend WithEvents morSpindleRunTime As System.Windows.Forms.TextBox
    Friend WithEvents Label273 As System.Windows.Forms.Label
    Friend WithEvents morExternalInputTime As System.Windows.Forms.TextBox
    Friend WithEvents morAlarmOnTime As System.Windows.Forms.TextBox
    Friend WithEvents Label274 As System.Windows.Forms.Label
    Friend WithEvents morDateOfOperatingReport As System.Windows.Forms.TextBox
    Friend WithEvents Label275 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents morPrevDateOfOperatingRept As System.Windows.Forms.TextBox
    Friend WithEvents morPrevAlarmOnTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevSpindleRunTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevOtherTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevMaintenanceTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevPartwaitingTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevNoOperatorTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevInProSetupTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevNonOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevCuttingTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevRunningTime As System.Windows.Forms.TextBox
    Friend WithEvents Label276 As System.Windows.Forms.Label
    Friend WithEvents Label277 As System.Windows.Forms.Label
    Friend WithEvents Label278 As System.Windows.Forms.Label
    Friend WithEvents Label279 As System.Windows.Forms.Label
    Friend WithEvents Label280 As System.Windows.Forms.Label
    Friend WithEvents Label281 As System.Windows.Forms.Label
    Friend WithEvents Label282 As System.Windows.Forms.Label
    Friend WithEvents Label283 As System.Windows.Forms.Label
    Friend WithEvents Label284 As System.Windows.Forms.Label
    Friend WithEvents Label285 As System.Windows.Forms.Label
    Friend WithEvents Label286 As System.Windows.Forms.Label
    Friend WithEvents Label287 As System.Windows.Forms.Label
    Friend WithEvents morPrevOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents morMaxNoOfOpReport As System.Windows.Forms.TextBox
    Friend WithEvents Label288 As System.Windows.Forms.Label
    Friend WithEvents morUpdateButton As System.Windows.Forms.Button
    Friend WithEvents morOperatingStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label289 As System.Windows.Forms.Label
    Friend WithEvents morNonoperatingCondition As System.Windows.Forms.TextBox
    Friend WithEvents Label290 As System.Windows.Forms.Label
    Friend WithEvents Tab_MacManMachiningReport As System.Windows.Forms.TabPage
    Friend WithEvents txtAxisType As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label142 As System.Windows.Forms.Label
    Friend WithEvents cboWorkpieceSubSystem As System.Windows.Forms.ComboBox
    Friend WithEvents cboMachiningReportSubSystem As System.Windows.Forms.ComboBox
    Friend WithEvents Label143 As System.Windows.Forms.Label
    Friend WithEvents txtMachiningReport_NoOfWork As System.Windows.Forms.TextBox
    Friend WithEvents Label144 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents grdMMMachiningReports As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents MacreportTime As System.Windows.Forms.TextBox
    Friend WithEvents grdMMMachiningReportTableStyle As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cmdMMMachiningReportsSubSystem As System.Windows.Forms.Button
    Friend WithEvents Label145 As System.Windows.Forms.Label
    Friend WithEvents morPrevExternalInputTime As System.Windows.Forms.TextBox
    Friend WithEvents cboGaugeStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label224 As System.Windows.Forms.Label
    Friend WithEvents cboToolsSubSystem As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboToolWearOffsetAxis As System.Windows.Forms.ComboBox
    Friend WithEvents cmdToolOffsetStandard_SetSubSystem As System.Windows.Forms.Button
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents cboTool_Standard_DataUnit As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSubNoseR As System.Windows.Forms.Button
    Friend WithEvents cmdAddNoseRCuttingPos As System.Windows.Forms.Button
    Friend WithEvents cmdAddToolOffset As System.Windows.Forms.Button
    Friend WithEvents cmdAddToolOffsetCuttingPos As System.Windows.Forms.Button
    Friend WithEvents cmdAddToolWearOffsetCuttingPos As System.Windows.Forms.Button
    Friend WithEvents cmdSubNoseRCuttingPos As System.Windows.Forms.Button
    Friend WithEvents cmdSubToolOffset As System.Windows.Forms.Button
    Friend WithEvents cmdSubToolOffsetCuttingPos As System.Windows.Forms.Button
    Friend WithEvents cmdSubToolWearOffsetCuttingPos As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAddToolWearOffset As System.Windows.Forms.Button
    Friend WithEvents cmdAutoScaleAnimate As System.Windows.Forms.Button
    Friend WithEvents cmdChangeReal3DSpindleMode As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteGraphWork As System.Windows.Forms.Button
    Friend WithEvents cmdSelect2D3DGraph As System.Windows.Forms.Button
    Friend WithEvents cmdSelectGraphLineAnimate As System.Windows.Forms.Button
    Friend WithEvents cmdStartGraphWork As System.Windows.Forms.Button
    Friend WithEvents cmdTurretDataUnit As System.Windows.Forms.Button
    Friend WithEvents cmdTurretSubSystem As System.Windows.Forms.Button
    Friend WithEvents Label129 As System.Windows.Forms.Label
    Friend WithEvents txtTool2Input As System.Windows.Forms.TextBox
    Friend WithEvents cmdTool2Set As System.Windows.Forms.Button
    Friend WithEvents cmdTool3Set As System.Windows.Forms.Button
    Friend WithEvents Label131 As System.Windows.Forms.Label
    Friend WithEvents Label132 As System.Windows.Forms.Label
    Friend WithEvents cboTool3DataUnit As System.Windows.Forms.ComboBox
    Friend WithEvents cboTool3SubSystem As System.Windows.Forms.ComboBox
    Friend WithEvents cmdPECSet As System.Windows.Forms.Button
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents progUpdateButton As System.Windows.Forms.Button
    Friend WithEvents progNoParams As System.Windows.Forms.TextBox
    Friend WithEvents cmb_Program_SubSys As System.Windows.Forms.ComboBox
    Friend WithEvents cmdProgramSubSystem As System.Windows.Forms.Button
    Friend WithEvents cmdTailStockSet As System.Windows.Forms.Button
    Friend WithEvents Label166 As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMachineName As System.Windows.Forms.TextBox
    Friend WithEvents Label174 As System.Windows.Forms.Label
    Friend WithEvents Tab_Turret As System.Windows.Forms.TabPage
    Friend WithEvents cboTurretSides As System.Windows.Forms.ComboBox
    Friend WithEvents Label175 As System.Windows.Forms.Label
    Friend WithEvents txtMaxToolPotPerTurret As System.Windows.Forms.TextBox
    Friend WithEvents txtMachineSerial As System.Windows.Forms.TextBox
    Friend WithEvents Label168 As System.Windows.Forms.Label
    Friend WithEvents tab_axis_2 As System.Windows.Forms.TabPage
    Friend WithEvents tab_OptionalParameter As System.Windows.Forms.TabPage
    Friend WithEvents Label177 As System.Windows.Forms.Label
    Friend WithEvents txtUserParameterDroopData As System.Windows.Forms.TextBox
    Friend WithEvents UserParameterDroopDataAxis As System.Windows.Forms.GroupBox
    Friend WithEvents Label179 As System.Windows.Forms.Label
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents cboUserParameterVariableLimitAxis As System.Windows.Forms.ComboBox
    Friend WithEvents Label214 As System.Windows.Forms.Label
    Friend WithEvents Label215 As System.Windows.Forms.Label
    Friend WithEvents Label291 As System.Windows.Forms.Label
    Friend WithEvents cboAxis2SubSystem As System.Windows.Forms.ComboBox
    Friend WithEvents ErrorLog As System.Windows.Forms.TextBox
    Friend WithEvents cmdAxis2SubSystem As System.Windows.Forms.Button
    Friend WithEvents cmdUserParameterVariableLimitAdd As System.Windows.Forms.Button
    Friend WithEvents cmdUserParameterVariableLimitSet As System.Windows.Forms.Button
    Friend WithEvents cmdUserParameterVariableLimitGet As System.Windows.Forms.Button
    Friend WithEvents txtUserParameterDroopDataInput As System.Windows.Forms.TextBox
    Friend WithEvents cboAxis2UserParameterDroopData As System.Windows.Forms.ComboBox
    Friend WithEvents cmdUserParameterDroopDataAdd As System.Windows.Forms.Button
    Friend WithEvents cmdUserParameterDroopDataSet As System.Windows.Forms.Button
    Friend WithEvents cmdUserParameterDroopDataGet As System.Windows.Forms.Button
    Friend WithEvents cmdOptionalParameterSubSystem As System.Windows.Forms.Button
    Friend WithEvents cboOptionalParameterSubSystem As System.Windows.Forms.ComboBox
    Friend WithEvents cboUserParameterVariableLimitCoordinate As System.Windows.Forms.ComboBox
    Friend WithEvents txtUserParameterLimitInput As System.Windows.Forms.TextBox
    Friend WithEvents txtUserParameterLimit As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdGetZeroShift As System.Windows.Forms.Button
    Friend WithEvents Label298 As System.Windows.Forms.Label
    Friend WithEvents cmdSetZeroShift As System.Windows.Forms.Button
    Friend WithEvents cmdAddZeroShift As System.Windows.Forms.Button
    Friend WithEvents cmdCalZeroShift As System.Windows.Forms.Button
    Friend WithEvents txtZeroShiftInput As System.Windows.Forms.TextBox
    Friend WithEvents cboZeroShiftAxis As System.Windows.Forms.ComboBox
    Friend WithEvents txtZeroShift As System.Windows.Forms.TextBox
    Friend WithEvents cboAxis2DataUnit As System.Windows.Forms.ComboBox
    Friend WithEvents cmdAxis2DataUnit As System.Windows.Forms.Button
    Friend WithEvents tab_PLC As System.Windows.Forms.TabPage
    Friend WithEvents grpIOVariables As System.Windows.Forms.GroupBox
    Friend WithEvents Label297 As System.Windows.Forms.Label
    Friend WithEvents cboIOVariableTypes As System.Windows.Forms.ComboBox
    Friend WithEvents cmdIOGetBit As System.Windows.Forms.Button
    Friend WithEvents cmdIOGetWord As System.Windows.Forms.Button
    Friend WithEvents cmdIOGetLongWord As System.Windows.Forms.Button
    Friend WithEvents txtIOLongWord As System.Windows.Forms.TextBox
    Friend WithEvents txtIOWord As System.Windows.Forms.TextBox
    Friend WithEvents txtIOBit As System.Windows.Forms.TextBox
    Friend WithEvents Label296 As System.Windows.Forms.Label
    Friend WithEvents txtIOBitNo As System.Windows.Forms.TextBox
    Friend WithEvents Label295 As System.Windows.Forms.Label
    Friend WithEvents txtIOLongWordIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label294 As System.Windows.Forms.Label
    Friend WithEvents txtIOWordIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label293 As System.Windows.Forms.Label
    Friend WithEvents txtIOBitIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label292 As System.Windows.Forms.Label
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNormalScaleValue As System.Windows.Forms.TextBox
    Friend WithEvents cmdNormalScale As System.Windows.Forms.Button
    Friend WithEvents cmdChangeEnlargeScaleFrame As System.Windows.Forms.Button
    Friend WithEvents cboEnlargeScaleFrame As System.Windows.Forms.ComboBox
    Friend WithEvents cmdShiftEnlargeScaleFrame As System.Windows.Forms.Button
    Friend WithEvents cboShiftEnlargeScaleFrame As System.Windows.Forms.ComboBox
    Friend WithEvents cboGraphMode As System.Windows.Forms.ComboBox
    Friend WithEvents cmdChangeGraphMode As System.Windows.Forms.Button
    Friend WithEvents cmdSelectProgramLSide As System.Windows.Forms.Button
    Friend WithEvents cmdSelectScheduleProgram As System.Windows.Forms.Button
    Friend WithEvents cmdSelectScheduleProgramRSide As System.Windows.Forms.Button
    Friend WithEvents cmdSelectScheduleProgramLSide As System.Windows.Forms.Button
    Friend WithEvents cmdSelectProgramRSide As System.Windows.Forms.Button
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGetBSpecCode As System.Windows.Forms.Button
    Friend WithEvents txtSpecCode As System.Windows.Forms.TextBox
    Friend WithEvents Label306 As System.Windows.Forms.Label
    Friend WithEvents txtSpecCodeBit As System.Windows.Forms.TextBox
    Friend WithEvents Label308 As System.Windows.Forms.Label
    Friend WithEvents txtSpecCodeIndex As System.Windows.Forms.TextBox
    Friend WithEvents cmdGetSpecCode As System.Windows.Forms.Button
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLongWordInput As System.Windows.Forms.TextBox
    Friend WithEvents txtWordInput As System.Windows.Forms.TextBox
    Friend WithEvents txtBitInput As System.Windows.Forms.TextBox
    Friend WithEvents cmdWordAdd As System.Windows.Forms.Button
    Friend WithEvents cmdLongWordAdd As System.Windows.Forms.Button
    Friend WithEvents cmdBitSet As System.Windows.Forms.Button
    Friend WithEvents cmdWordSet As System.Windows.Forms.Button
    Friend WithEvents cmdLongWordSet As System.Windows.Forms.Button
    Friend WithEvents cmdOptionalParameterBitGet As System.Windows.Forms.Button
    Friend WithEvents cmdOptionalParameterWordGet As System.Windows.Forms.Button
    Friend WithEvents cmdOptionalParameterLongWordGet As System.Windows.Forms.Button
    Friend WithEvents txtOptionalParameterLongWord As System.Windows.Forms.TextBox
    Friend WithEvents txtOptionalParameterWord As System.Windows.Forms.TextBox
    Friend WithEvents txtOptionalParameterBit As System.Windows.Forms.TextBox
    Friend WithEvents Label299 As System.Windows.Forms.Label
    Friend WithEvents txtOptionalParameterBitNo As System.Windows.Forms.TextBox
    Friend WithEvents Label300 As System.Windows.Forms.Label
    Friend WithEvents txtOptionalParameterLongWordIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label301 As System.Windows.Forms.Label
    Friend WithEvents txtOptionalParameterWordIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label302 As System.Windows.Forms.Label
    Friend WithEvents txtOptionalParameterBitIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label303 As System.Windows.Forms.Label
    Friend WithEvents txtCurrentAlarmNumber As System.Windows.Forms.Button
    Friend WithEvents GroupBox19 As System.Windows.Forms.GroupBox
    Friend WithEvents tab_CurrentAlarm As System.Windows.Forms.TabPage
    Friend WithEvents cmdCurrentAlarm_Update As System.Windows.Forms.Button
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCurrentAlarm_AlarmCharacterString As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentAlarm_AlarmCode As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtCurrentAlarm_ObjectMessage As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentAlarm_AlarmMessage As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentAlarm_AlarmLevel As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentAlarm_ObjectNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentAlarm_AlarmNumber As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents cboCurrentAlarm_SubSystem As System.Windows.Forms.ComboBox
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents tab_Program2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents Label309 As System.Windows.Forms.Label
    Friend WithEvents Label310 As System.Windows.Forms.Label
    Friend WithEvents txtProgram2_OrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtProgram2_Sequence As System.Windows.Forms.TextBox
    Friend WithEvents cmdProgram2_SequenceRestart As System.Windows.Forms.Button
    Friend WithEvents cboATCTurretStation As System.Windows.Forms.ComboBox
    Friend WithEvents Label311 As System.Windows.Forms.Label
    Friend WithEvents Label312 As System.Windows.Forms.Label
    Friend WithEvents txtATCToolNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdRegisterTool As System.Windows.Forms.Button
    Friend WithEvents Label313 As System.Windows.Forms.Label
    Friend WithEvents cboATCToolKind As System.Windows.Forms.ComboBox
    Friend WithEvents Label314 As System.Windows.Forms.Label
    Friend WithEvents cboATCToolSize As System.Windows.Forms.ComboBox
    Friend WithEvents Label315 As System.Windows.Forms.Label
    Friend WithEvents cboATCReturnMagazine As System.Windows.Forms.ComboBox
    Friend WithEvents cmdATCUnRegisterTool As System.Windows.Forms.Button
    Friend WithEvents cmdATCSetToolInStation As System.Windows.Forms.Button
    Friend WithEvents cmdATCSetNextTool As System.Windows.Forms.Button
    Friend WithEvents txtATCPotNo As System.Windows.Forms.TextBox
    Friend WithEvents txtMachine As System.Windows.Forms.TextBox
    Friend WithEvents tab_MultiTools As System.Windows.Forms.TabPage
    Friend WithEvents Label141 As System.Windows.Forms.Label
    Friend WithEvents Label242 As System.Windows.Forms.Label
    Friend WithEvents Label185 As System.Windows.Forms.Label
    Friend WithEvents txt_edgenumber As System.Windows.Forms.TextBox
    Friend WithEvents Label186 As System.Windows.Forms.Label
    Friend WithEvents Label187 As System.Windows.Forms.Label
    Friend WithEvents Label188 As System.Windows.Forms.Label
    Friend WithEvents Label189 As System.Windows.Forms.Label
    Friend WithEvents Label190 As System.Windows.Forms.Label
    Friend WithEvents cmdMultiTool_ToolSetAdd As System.Windows.Forms.Button
    Friend WithEvents cmdMultiTool_ToolSetSet As System.Windows.Forms.Button
    Friend WithEvents txtMultiTool_ToolLifeGaugeValue As System.Windows.Forms.TextBox
    Friend WithEvents txtMultiTool_ToolLifeGauge As System.Windows.Forms.TextBox
    Friend WithEvents cmdMultiTool_ToolGaugeSet As System.Windows.Forms.Button
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cboMultiToolSubSystem As System.Windows.Forms.ComboBox
    Friend WithEvents cmdMultiTool_ToolGaugeGet As System.Windows.Forms.Button
    Friend WithEvents cmdMultiTool_ToolSetGet As System.Windows.Forms.Button
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cmdMultiTool_ToolRef1Get As System.Windows.Forms.Button
    Friend WithEvents txtMultiTool_ToolRef1Value As System.Windows.Forms.TextBox
    Friend WithEvents txtMultiTool_ToolRef1 As System.Windows.Forms.TextBox
    Friend WithEvents cmdMultiTool_ToolRef1Set As System.Windows.Forms.Button
    Friend WithEvents Label316 As System.Windows.Forms.Label
    Friend WithEvents cmdMultiTool_ToolRef2Get As System.Windows.Forms.Button
    Friend WithEvents txtMultiTool_ToolRef2Value As System.Windows.Forms.TextBox
    Friend WithEvents txtMultiTool_ToolRef2 As System.Windows.Forms.TextBox
    Friend WithEvents cmdMultiTool_ToolRef2Set As System.Windows.Forms.Button
    Friend WithEvents Label317 As System.Windows.Forms.Label
    Friend WithEvents cmdMultiTool_ToolRef3Get As System.Windows.Forms.Button
    Friend WithEvents txtMultiTool_ToolRef3Value As System.Windows.Forms.TextBox
    Friend WithEvents txtMultiTool_ToolRef3 As System.Windows.Forms.TextBox
    Friend WithEvents Label318 As System.Windows.Forms.Label
    Friend WithEvents cmdMultiTool_GroupEdgeGet As System.Windows.Forms.Button
    Friend WithEvents txtMultiTool_GroupEdgeValue As System.Windows.Forms.TextBox
    Friend WithEvents txtMultiTool_GroupEdge As System.Windows.Forms.TextBox
    Friend WithEvents cmdMultiTool_GroupEdgeSet As System.Windows.Forms.Button
    Friend WithEvents cmdMultiTool_ToolGroupLifeGet As System.Windows.Forms.Button
    Friend WithEvents txtMultiTool_ToolGroupLifeValue As System.Windows.Forms.TextBox
    Friend WithEvents txtMultiTool_ToolGroupLife As System.Windows.Forms.TextBox
    Friend WithEvents cmdMultiTool_ToolGroupLifeSet As System.Windows.Forms.Button
    Friend WithEvents cmdMultiTool_GroupNoGet As System.Windows.Forms.Button
    Friend WithEvents txtMultiTool_GroupNoValue As System.Windows.Forms.TextBox
    Friend WithEvents txtMultiTool_GroupNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdMultiTool_GroupNoSet As System.Windows.Forms.Button
    Friend WithEvents Label319 As System.Windows.Forms.Label
    Friend WithEvents cmdMultiTool_ToolInGroupGet As System.Windows.Forms.Button
    Friend WithEvents txtMultiTool_ToolInGroupValue As System.Windows.Forms.TextBox
    Friend WithEvents txtMultiTool_ToolInGroup As System.Windows.Forms.TextBox
    Friend WithEvents cmdMultiTool_ToolInGroupSet As System.Windows.Forms.Button
    Friend WithEvents Label320 As System.Windows.Forms.Label
    Friend WithEvents cmdMultiTool_EntryToolNoGet As System.Windows.Forms.Button
    Friend WithEvents txtMultiTool_EntryToolNo As System.Windows.Forms.TextBox
    Friend WithEvents Label321 As System.Windows.Forms.Label
    Friend WithEvents GroupBox21 As System.Windows.Forms.GroupBox
    Friend WithEvents cboMultiToolEdges As System.Windows.Forms.ComboBox
    Friend WithEvents cboMultiToolHolder As System.Windows.Forms.ComboBox
    Friend WithEvents cboMultiToolLifeCondition As System.Windows.Forms.ComboBox
    Friend WithEvents txtMultiTool_ToolLifeSetValue As System.Windows.Forms.TextBox
    Friend WithEvents txtMultiTool_ToolLifeSet As System.Windows.Forms.TextBox
    Friend WithEvents cmdMultiTool_ToolLifeActualGet As System.Windows.Forms.Button
    Friend WithEvents cmdMultiTool_ToolLifeActualAdd As System.Windows.Forms.Button
    Friend WithEvents txtMultiTool_ToolLifeActualValue As System.Windows.Forms.TextBox
    Friend WithEvents txtMultiTool_ToolLifeActual As System.Windows.Forms.TextBox
    Friend WithEvents cmdMultiTool_ToolLifeActualSet As System.Windows.Forms.Button
    Friend WithEvents txtMultiTool_ToolLifeStatusValue As System.Windows.Forms.TextBox
    Friend WithEvents txtMultiTool_ToolLifeStatus As System.Windows.Forms.TextBox
    Friend WithEvents cmdMultiTool_ToolLifeStatusGet As System.Windows.Forms.Button
    Friend WithEvents cmdMultiTool_ToolLifeStatusSet As System.Windows.Forms.Button
    Friend WithEvents txtMultiTool_GroupNoInput As System.Windows.Forms.TextBox
    Friend WithEvents Label322 As System.Windows.Forms.Label
    Friend WithEvents Label323 As System.Windows.Forms.Label
    Friend WithEvents cmdToolGroupLifeStatusSet As System.Windows.Forms.Button
    Friend WithEvents txtToolGroupLifeStatusValue As System.Windows.Forms.TextBox
    Friend WithEvents txtToolGroupLifeStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtGroupNo As System.Windows.Forms.TextBox
    Friend WithEvents Label324 As System.Windows.Forms.Label
    Friend WithEvents Label325 As System.Windows.Forms.Label
    Friend WithEvents txtMultiTool_EntryToolNoInput As System.Windows.Forms.TextBox
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents cmdMultiTool_ToolRef3Set As System.Windows.Forms.Button
    Friend WithEvents tab_ToolStandard2 As System.Windows.Forms.TabPage
    Friend WithEvents Label326 As System.Windows.Forms.Label
    Friend WithEvents cmdToolEntryNoGet As System.Windows.Forms.Button
    Friend WithEvents txtTool2EntryNo As System.Windows.Forms.TextBox
    Friend WithEvents Tool2InputPanel As System.Windows.Forms.GroupBox
    Friend WithEvents txtTool2EntryToolIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label327 As System.Windows.Forms.Label
    Friend WithEvents txtTool2GroupNoInput As System.Windows.Forms.TextBox
    Friend WithEvents Label328 As System.Windows.Forms.Label
    Friend WithEvents Tab_IO As System.Windows.Forms.TabControl
    Friend WithEvents cmdMagazinePosition As System.Windows.Forms.Button
    Friend WithEvents txtMagazineNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label304 As System.Windows.Forms.Label
    Friend WithEvents txtMagazinePosition As System.Windows.Forms.TextBox
    Friend WithEvents Label305 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
Me.Tab_IO = New System.Windows.Forms.TabControl
Me.tab_axis = New System.Windows.Forms.TabPage
Me.lbl_FeedRate = New System.Windows.Forms.TextBox
Me.Label158 = New System.Windows.Forms.Label
Me.AxismaxFeedrateOverride = New System.Windows.Forms.TextBox
Me.Label26 = New System.Windows.Forms.Label
Me.AxisBAxisLoad = New System.Windows.Forms.TextBox
Me.Label25 = New System.Windows.Forms.Label
Me.AxisfeedrateOverride = New System.Windows.Forms.TextBox
Me.Label24 = New System.Windows.Forms.Label
Me.AxisfeedHold = New System.Windows.Forms.TextBox
Me.Label23 = New System.Windows.Forms.Label
Me.txtAxisType = New System.Windows.Forms.TextBox
Me.Label22 = New System.Windows.Forms.Label
Me.axisName = New System.Windows.Forms.TextBox
Me.Label21 = New System.Windows.Forms.Label
Me.AxistargetPosition = New System.Windows.Forms.TextBox
Me.Label20 = New System.Windows.Forms.Label
Me.AxisdistanceTarget = New System.Windows.Forms.TextBox
Me.Label19 = New System.Windows.Forms.Label
Me.AxiscommandFeedRate = New System.Windows.Forms.TextBox
Me.Label18 = New System.Windows.Forms.Label
Me.axisLoad = New System.Windows.Forms.TextBox
Me.Label17 = New System.Windows.Forms.Label
Me.AxisAPProgramCoord = New System.Windows.Forms.TextBox
Me.Label16 = New System.Windows.Forms.Label
Me.AxisAPMachineCoord = New System.Windows.Forms.TextBox
Me.Label15 = New System.Windows.Forms.Label
Me.AxisAPEncoderCoord = New System.Windows.Forms.TextBox
Me.Label14 = New System.Windows.Forms.Label
Me.AxisActualFeedrate = New System.Windows.Forms.TextBox
Me.Label12 = New System.Windows.Forms.Label
Me.axis2Combo = New System.Windows.Forms.ComboBox
Me.axis1Combo = New System.Windows.Forms.ComboBox
Me.Label10 = New System.Windows.Forms.Label
Me.Panel4 = New System.Windows.Forms.Panel
Me.cmb_Currentdataunit = New System.Windows.Forms.ComboBox
Me.Label160 = New System.Windows.Forms.Label
Me.cmb_Currentsubsystem = New System.Windows.Forms.ComboBox
Me.Label159 = New System.Windows.Forms.Label
Me.AxisTimerStop = New System.Windows.Forms.Button
Me.axisTimerStart = New System.Windows.Forms.Button
Me.Label123 = New System.Windows.Forms.Label
Me.axisAllCombo = New System.Windows.Forms.ComboBox
Me.Label11 = New System.Windows.Forms.Label
Me.axisUpdateButton = New System.Windows.Forms.Button
Me.CATC = New System.Windows.Forms.TabPage
Me.Label305 = New System.Windows.Forms.Label
Me.txtMagazinePosition = New System.Windows.Forms.TextBox
Me.txtMagazineNumber = New System.Windows.Forms.TextBox
Me.Label304 = New System.Windows.Forms.Label
Me.cmdMagazinePosition = New System.Windows.Forms.Button
Me.cmdATCSetNextTool = New System.Windows.Forms.Button
Me.cmdATCSetToolInStation = New System.Windows.Forms.Button
Me.cmdATCUnRegisterTool = New System.Windows.Forms.Button
Me.Label315 = New System.Windows.Forms.Label
Me.cboATCReturnMagazine = New System.Windows.Forms.ComboBox
Me.Label314 = New System.Windows.Forms.Label
Me.cboATCToolSize = New System.Windows.Forms.ComboBox
Me.Label313 = New System.Windows.Forms.Label
Me.cboATCToolKind = New System.Windows.Forms.ComboBox
Me.cmdRegisterTool = New System.Windows.Forms.Button
Me.Label312 = New System.Windows.Forms.Label
Me.txtATCToolNo = New System.Windows.Forms.TextBox
Me.Label311 = New System.Windows.Forms.Label
Me.cboATCTurretStation = New System.Windows.Forms.ComboBox
Me.Label65 = New System.Windows.Forms.Label
Me.atcUpdate = New System.Windows.Forms.Button
Me.atcResults = New System.Windows.Forms.TextBox
Me.txtATCPotNo = New System.Windows.Forms.TextBox
Me.Label150 = New System.Windows.Forms.Label
Me.tab_Program2 = New System.Windows.Forms.TabPage
Me.GroupBox18 = New System.Windows.Forms.GroupBox
Me.txtProgram2_OrderNumber = New System.Windows.Forms.TextBox
Me.Label310 = New System.Windows.Forms.Label
Me.Label309 = New System.Windows.Forms.Label
Me.txtProgram2_Sequence = New System.Windows.Forms.TextBox
Me.cmdProgram2_SequenceRestart = New System.Windows.Forms.Button
Me.tab_program = New System.Windows.Forms.TabPage
Me.cmdSelectScheduleProgram = New System.Windows.Forms.Button
Me.cmdSelectScheduleProgramRSide = New System.Windows.Forms.Button
Me.cmdSelectScheduleProgramLSide = New System.Windows.Forms.Button
Me.cmdSelectProgramRSide = New System.Windows.Forms.Button
Me.cmdSelectProgramLSide = New System.Windows.Forms.Button
Me.cmdProgramSubSystem = New System.Windows.Forms.Button
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.TxtCycleComplte = New System.Windows.Forms.TextBox
Me.Label253 = New System.Windows.Forms.Label
Me.TxtProgrameCycleComplete = New System.Windows.Forms.TextBox
Me.Label254 = New System.Windows.Forms.Label
Me.progButtonCycleStatus = New System.Windows.Forms.Button
Me.cboCycleCompleteCombo = New System.Windows.Forms.ComboBox
Me.ScheduleProgramCycleCompleteCombo = New System.Windows.Forms.ComboBox
Me.Label230 = New System.Windows.Forms.Label
Me.ScheduleProgramCycleComplete = New System.Windows.Forms.Label
Me.cmb_Program_SubSys = New System.Windows.Forms.ComboBox
Me.progCancelProgramButton = New System.Windows.Forms.Button
Me.progSelectProgramButton = New System.Windows.Forms.Button
Me.Label146 = New System.Windows.Forms.Label
Me.prog4 = New System.Windows.Forms.TextBox
Me.prog3 = New System.Windows.Forms.TextBox
Me.Label147 = New System.Windows.Forms.Label
Me.prog2 = New System.Windows.Forms.TextBox
Me.Label148 = New System.Windows.Forms.Label
Me.prog1 = New System.Windows.Forms.TextBox
Me.Label149 = New System.Windows.Forms.Label
Me.progGetMCodes = New System.Windows.Forms.Button
Me.Label59 = New System.Windows.Forms.Label
Me.progRead = New System.Windows.Forms.TextBox
Me.Label60 = New System.Windows.Forms.Label
Me.progColumn = New System.Windows.Forms.TextBox
Me.progRow = New System.Windows.Forms.TextBox
Me.Label62 = New System.Windows.Forms.Label
Me.Label58 = New System.Windows.Forms.Label
Me.progMCodes = New System.Windows.Forms.TextBox
Me.label99 = New System.Windows.Forms.Label
Me.progMCodesCombo = New System.Windows.Forms.ComboBox
Me.Label57 = New System.Windows.Forms.Label
Me.progUpdateButton = New System.Windows.Forms.Button
Me.progNoParams = New System.Windows.Forms.TextBox
Me.Panel7 = New System.Windows.Forms.Panel
Me.Panel8 = New System.Windows.Forms.Panel
Me.TxtRunningPrograme = New System.Windows.Forms.TextBox
Me.Label249 = New System.Windows.Forms.Label
Me.progButtonGetRunProgram = New System.Windows.Forms.Button
Me.progRunningPrograms = New System.Windows.Forms.TextBox
Me.Label61 = New System.Windows.Forms.Label
Me.progExecutePoint = New System.Windows.Forms.TextBox
Me.tab_MacmanOperatingReport = New System.Windows.Forms.TabPage
Me.morMaxNoOfOpReport = New System.Windows.Forms.TextBox
Me.Label288 = New System.Windows.Forms.Label
Me.morUpdateButton = New System.Windows.Forms.Button
Me.morOperatingStatus = New System.Windows.Forms.TextBox
Me.Label289 = New System.Windows.Forms.Label
Me.morNonoperatingCondition = New System.Windows.Forms.TextBox
Me.Label290 = New System.Windows.Forms.Label
Me.GroupBox6 = New System.Windows.Forms.GroupBox
Me.Label145 = New System.Windows.Forms.Label
Me.morPrevExternalInputTime = New System.Windows.Forms.TextBox
Me.morPrevDateOfOperatingRept = New System.Windows.Forms.TextBox
Me.morPrevAlarmOnTime = New System.Windows.Forms.TextBox
Me.morPrevSpindleRunTime = New System.Windows.Forms.TextBox
Me.morPrevOtherTime = New System.Windows.Forms.TextBox
Me.morPrevMaintenanceTime = New System.Windows.Forms.TextBox
Me.morPrevPartwaitingTime = New System.Windows.Forms.TextBox
Me.morPrevNoOperatorTime = New System.Windows.Forms.TextBox
Me.morPrevInProSetupTime = New System.Windows.Forms.TextBox
Me.morPrevNonOperatingTime = New System.Windows.Forms.TextBox
Me.morPrevCuttingTime = New System.Windows.Forms.TextBox
Me.morPrevRunningTime = New System.Windows.Forms.TextBox
Me.Label276 = New System.Windows.Forms.Label
Me.Label277 = New System.Windows.Forms.Label
Me.Label278 = New System.Windows.Forms.Label
Me.Label279 = New System.Windows.Forms.Label
Me.Label280 = New System.Windows.Forms.Label
Me.Label281 = New System.Windows.Forms.Label
Me.Label282 = New System.Windows.Forms.Label
Me.Label283 = New System.Windows.Forms.Label
Me.Label284 = New System.Windows.Forms.Label
Me.Label285 = New System.Windows.Forms.Label
Me.Label286 = New System.Windows.Forms.Label
Me.Label287 = New System.Windows.Forms.Label
Me.morPrevOperatingTime = New System.Windows.Forms.TextBox
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.Label240 = New System.Windows.Forms.Label
Me.morOperatingTime = New System.Windows.Forms.TextBox
Me.Label264 = New System.Windows.Forms.Label
Me.Label265 = New System.Windows.Forms.Label
Me.Label266 = New System.Windows.Forms.Label
Me.Label267 = New System.Windows.Forms.Label
Me.Label268 = New System.Windows.Forms.Label
Me.Label269 = New System.Windows.Forms.Label
Me.morRunningTime = New System.Windows.Forms.TextBox
Me.morCuttingTime = New System.Windows.Forms.TextBox
Me.morNonOPeratingTime = New System.Windows.Forms.TextBox
Me.morInProSetupTime = New System.Windows.Forms.TextBox
Me.morNoOperatorTime = New System.Windows.Forms.TextBox
Me.morPartWaitingTime = New System.Windows.Forms.TextBox
Me.Label270 = New System.Windows.Forms.Label
Me.mormaintenanceTime = New System.Windows.Forms.TextBox
Me.Label271 = New System.Windows.Forms.Label
Me.morOtherTime = New System.Windows.Forms.TextBox
Me.Label272 = New System.Windows.Forms.Label
Me.morSpindleRunTime = New System.Windows.Forms.TextBox
Me.Label273 = New System.Windows.Forms.Label
Me.morExternalInputTime = New System.Windows.Forms.TextBox
Me.morAlarmOnTime = New System.Windows.Forms.TextBox
Me.Label274 = New System.Windows.Forms.Label
Me.morDateOfOperatingReport = New System.Windows.Forms.TextBox
Me.Label275 = New System.Windows.Forms.Label
Me.GroupBox3 = New System.Windows.Forms.GroupBox
Me.morPeriodDateOfOperatingReport = New System.Windows.Forms.TextBox
Me.morPeriodAlarmOnTime = New System.Windows.Forms.TextBox
Me.morPeriodExternalInputTime = New System.Windows.Forms.TextBox
Me.morPeriodSpindleRunTime = New System.Windows.Forms.TextBox
Me.morPeriodOtherTime = New System.Windows.Forms.TextBox
Me.morPeriodMaintenanceTime = New System.Windows.Forms.TextBox
Me.morPeriodNoOperatorTime = New System.Windows.Forms.TextBox
Me.morPeriodPartWaitingTime = New System.Windows.Forms.TextBox
Me.morPeriodInproSetupTime = New System.Windows.Forms.TextBox
Me.morPeriodNonOperatingTime = New System.Windows.Forms.TextBox
Me.morPeriodCuttingTime = New System.Windows.Forms.TextBox
Me.morPeriodRunningTime = New System.Windows.Forms.TextBox
Me.Label84 = New System.Windows.Forms.Label
Me.Label108 = New System.Windows.Forms.Label
Me.Label109 = New System.Windows.Forms.Label
Me.Label110 = New System.Windows.Forms.Label
Me.Label111 = New System.Windows.Forms.Label
Me.Label112 = New System.Windows.Forms.Label
Me.Label133 = New System.Windows.Forms.Label
Me.Label234 = New System.Windows.Forms.Label
Me.Label235 = New System.Windows.Forms.Label
Me.Label236 = New System.Windows.Forms.Label
Me.Label237 = New System.Windows.Forms.Label
Me.Label238 = New System.Windows.Forms.Label
Me.morPeriodOperatingTime = New System.Windows.Forms.TextBox
Me.Label239 = New System.Windows.Forms.Label
Me.McORSubSystemCombo = New System.Windows.Forms.ComboBox
Me.Label241 = New System.Windows.Forms.Label
Me.tab_spec = New System.Windows.Forms.TabPage
Me.GroupBox17 = New System.Windows.Forms.GroupBox
Me.cmdGetBSpecCode = New System.Windows.Forms.Button
Me.txtSpecCode = New System.Windows.Forms.TextBox
Me.Label306 = New System.Windows.Forms.Label
Me.txtSpecCodeBit = New System.Windows.Forms.TextBox
Me.Label308 = New System.Windows.Forms.Label
Me.txtSpecCodeIndex = New System.Windows.Forms.TextBox
Me.cmdGetSpecCode = New System.Windows.Forms.Button
Me.txtMachineSerial = New System.Windows.Forms.TextBox
Me.txtMachineName = New System.Windows.Forms.TextBox
Me.Label168 = New System.Windows.Forms.Label
Me.Label174 = New System.Windows.Forms.Label
Me.txtVersion = New System.Windows.Forms.TextBox
Me.Label64 = New System.Windows.Forms.Label
Me.Label37 = New System.Windows.Forms.Label
Me.specSaddleSpec = New System.Windows.Forms.TextBox
Me.Label66 = New System.Windows.Forms.Label
Me.specCombo = New System.Windows.Forms.ComboBox
Me.specUpdateButton = New System.Windows.Forms.Button
Me.specCode = New System.Windows.Forms.TextBox
Me.Label63 = New System.Windows.Forms.Label
Me.tab_views = New System.Windows.Forms.TabPage
Me.Panel12 = New System.Windows.Forms.Panel
Me.Label231 = New System.Windows.Forms.Label
Me.Cmb_ChangeScreen = New System.Windows.Forms.ComboBox
Me.cmd_ChangeScreen = New System.Windows.Forms.Button
Me.txt_screenname = New System.Windows.Forms.TextBox
Me.Label232 = New System.Windows.Forms.Label
Me.tab_ToolStandard2 = New System.Windows.Forms.TabPage
Me.Tool2InputPanel = New System.Windows.Forms.GroupBox
Me.txtTool2GroupNoInput = New System.Windows.Forms.TextBox
Me.Label328 = New System.Windows.Forms.Label
Me.txtTool2EntryToolIndex = New System.Windows.Forms.TextBox
Me.Label327 = New System.Windows.Forms.Label
Me.txtTool2EntryNo = New System.Windows.Forms.TextBox
Me.Label326 = New System.Windows.Forms.Label
Me.cmdToolEntryNoGet = New System.Windows.Forms.Button
Me.TabPage3 = New System.Windows.Forms.TabPage
Me.cboGraphMode = New System.Windows.Forms.ComboBox
Me.cmdChangeGraphMode = New System.Windows.Forms.Button
Me.GroupBox14 = New System.Windows.Forms.GroupBox
Me.cboShiftEnlargeScaleFrame = New System.Windows.Forms.ComboBox
Me.cmdShiftEnlargeScaleFrame = New System.Windows.Forms.Button
Me.cboEnlargeScaleFrame = New System.Windows.Forms.ComboBox
Me.txtNormalScaleValue = New System.Windows.Forms.TextBox
Me.cmdNormalScale = New System.Windows.Forms.Button
Me.cmdChangeEnlargeScaleFrame = New System.Windows.Forms.Button
Me.cmdAutoScaleAnimate = New System.Windows.Forms.Button
Me.cmdStartGraphWork = New System.Windows.Forms.Button
Me.cmdSelectGraphLineAnimate = New System.Windows.Forms.Button
Me.cmdSelect2D3DGraph = New System.Windows.Forms.Button
Me.cmdDeleteGraphWork = New System.Windows.Forms.Button
Me.cmdChangeReal3DSpindleMode = New System.Windows.Forms.Button
Me.tab_MacmanOperatingHistory = New System.Windows.Forms.TabPage
Me.mohTo = New System.Windows.Forms.TextBox
Me.Label139 = New System.Windows.Forms.Label
Me.mohFrom = New System.Windows.Forms.TextBox
Me.Label140 = New System.Windows.Forms.Label
Me.mohResults = New System.Windows.Forms.TextBox
Me.mohButtonResults = New System.Windows.Forms.Button
Me.mohSubSystemSet = New System.Windows.Forms.Button
Me.mohSubSystemCombo = New System.Windows.Forms.ComboBox
Me.Label136 = New System.Windows.Forms.Label
Me.mohUpdateButton = New System.Windows.Forms.Button
Me.mohOperationIndex = New System.Windows.Forms.TextBox
Me.Label113 = New System.Windows.Forms.Label
Me.mohOperationTime = New System.Windows.Forms.TextBox
Me.Label116 = New System.Windows.Forms.Label
Me.mohOperationDate = New System.Windows.Forms.TextBox
Me.Label117 = New System.Windows.Forms.Label
Me.mohOperationData = New System.Windows.Forms.TextBox
Me.Label118 = New System.Windows.Forms.Label
Me.mohMaxCount = New System.Windows.Forms.TextBox
Me.Label119 = New System.Windows.Forms.Label
Me.mohCount = New System.Windows.Forms.TextBox
Me.Label120 = New System.Windows.Forms.Label
Me.tab_workpiece = New System.Windows.Forms.TabPage
Me.Panel1 = New System.Windows.Forms.Panel
Me.cmdGetZeroShift = New System.Windows.Forms.Button
Me.txtZeroShiftInput = New System.Windows.Forms.TextBox
Me.cboZeroShiftAxis = New System.Windows.Forms.ComboBox
Me.Label298 = New System.Windows.Forms.Label
Me.txtZeroShift = New System.Windows.Forms.TextBox
Me.cmdSetZeroShift = New System.Windows.Forms.Button
Me.cmdAddZeroShift = New System.Windows.Forms.Button
Me.cmdCalZeroShift = New System.Windows.Forms.Button
Me.Label142 = New System.Windows.Forms.Label
Me.cboWorkpieceSubSystem = New System.Windows.Forms.ComboBox
Me.Label256 = New System.Windows.Forms.Label
Me.cmb_WorkpieceDataunit = New System.Windows.Forms.ComboBox
Me.wkUpdateValsWithNoParams = New System.Windows.Forms.Button
Me.Panel9 = New System.Windows.Forms.Panel
Me.wkGetZeroOffset = New System.Windows.Forms.Button
Me.wkUpdateZeroOffset = New System.Windows.Forms.TextBox
Me.wkZeroOffsetCombo = New System.Windows.Forms.ComboBox
Me.Label94 = New System.Windows.Forms.Label
Me.wkZeroOffset = New System.Windows.Forms.TextBox
Me.wkSetZeroOffset = New System.Windows.Forms.Button
Me.wkAddZeroOffset = New System.Windows.Forms.Button
Me.wkCalZeroOffset = New System.Windows.Forms.Button
Me.Panel10 = New System.Windows.Forms.Panel
Me.cmd_addWorkpiece = New System.Windows.Forms.Button
Me.Label95 = New System.Windows.Forms.Label
Me.wkSetCounterValue = New System.Windows.Forms.Button
Me.wkCounterValue = New System.Windows.Forms.TextBox
Me.wkUpdateCounter = New System.Windows.Forms.TextBox
Me.wkGetCounterValue = New System.Windows.Forms.Button
Me.wkCounterCombo = New System.Windows.Forms.ComboBox
Me.tab_machine = New System.Windows.Forms.TabPage
Me.txtMachine = New System.Windows.Forms.TextBox
Me.GroupBox19 = New System.Windows.Forms.GroupBox
Me.macMDICommand = New System.Windows.Forms.TextBox
Me.macMDIExecButton = New System.Windows.Forms.Button
Me.cmb_Machine_SubSys = New System.Windows.Forms.ComboBox
Me.Label165 = New System.Windows.Forms.Label
Me.machineUpdateButton = New System.Windows.Forms.Button
Me.tab_axis_2 = New System.Windows.Forms.TabPage
Me.cmdAxis2DataUnit = New System.Windows.Forms.Button
Me.cboAxis2DataUnit = New System.Windows.Forms.ComboBox
Me.cmdAxis2SubSystem = New System.Windows.Forms.Button
Me.cboAxis2SubSystem = New System.Windows.Forms.ComboBox
Me.GroupBox11 = New System.Windows.Forms.GroupBox
Me.Label291 = New System.Windows.Forms.Label
Me.cboUserParameterVariableLimitCoordinate = New System.Windows.Forms.ComboBox
Me.txtUserParameterLimitInput = New System.Windows.Forms.TextBox
Me.txtUserParameterLimit = New System.Windows.Forms.TextBox
Me.Label215 = New System.Windows.Forms.Label
Me.cmdUserParameterVariableLimitAdd = New System.Windows.Forms.Button
Me.cmdUserParameterVariableLimitSet = New System.Windows.Forms.Button
Me.cmdUserParameterVariableLimitGet = New System.Windows.Forms.Button
Me.Label214 = New System.Windows.Forms.Label
Me.cboUserParameterVariableLimitAxis = New System.Windows.Forms.ComboBox
Me.UserParameterDroopDataAxis = New System.Windows.Forms.GroupBox
Me.txtUserParameterDroopDataInput = New System.Windows.Forms.TextBox
Me.Label179 = New System.Windows.Forms.Label
Me.cboAxis2UserParameterDroopData = New System.Windows.Forms.ComboBox
Me.txtUserParameterDroopData = New System.Windows.Forms.TextBox
Me.Label177 = New System.Windows.Forms.Label
Me.cmdUserParameterDroopDataAdd = New System.Windows.Forms.Button
Me.cmdUserParameterDroopDataSet = New System.Windows.Forms.Button
Me.cmdUserParameterDroopDataGet = New System.Windows.Forms.Button
Me.tab_MultiTools = New System.Windows.Forms.TabPage
Me.Label141 = New System.Windows.Forms.Label
Me.Panel = New System.Windows.Forms.Panel
Me.GroupBox21 = New System.Windows.Forms.GroupBox
Me.txtMultiTool_EntryToolNoInput = New System.Windows.Forms.TextBox
Me.Label325 = New System.Windows.Forms.Label
Me.txtMultiTool_GroupNoInput = New System.Windows.Forms.TextBox
Me.Label322 = New System.Windows.Forms.Label
Me.txt_edgenumber = New System.Windows.Forms.TextBox
Me.Label186 = New System.Windows.Forms.Label
Me.Label188 = New System.Windows.Forms.Label
Me.Label189 = New System.Windows.Forms.Label
Me.cboMultiToolLifeCondition = New System.Windows.Forms.ComboBox
Me.cboMultiToolHolder = New System.Windows.Forms.ComboBox
Me.cmdMultiTool_EntryToolNoGet = New System.Windows.Forms.Button
Me.txtMultiTool_EntryToolNo = New System.Windows.Forms.TextBox
Me.Label321 = New System.Windows.Forms.Label
Me.cmdMultiTool_ToolInGroupGet = New System.Windows.Forms.Button
Me.txtMultiTool_ToolInGroupValue = New System.Windows.Forms.TextBox
Me.txtMultiTool_ToolInGroup = New System.Windows.Forms.TextBox
Me.cmdMultiTool_ToolInGroupSet = New System.Windows.Forms.Button
Me.Label320 = New System.Windows.Forms.Label
Me.cmdMultiTool_GroupNoGet = New System.Windows.Forms.Button
Me.txtMultiTool_GroupNoValue = New System.Windows.Forms.TextBox
Me.txtMultiTool_GroupNo = New System.Windows.Forms.TextBox
Me.cmdMultiTool_GroupNoSet = New System.Windows.Forms.Button
Me.Label319 = New System.Windows.Forms.Label
Me.cmdMultiTool_ToolRef3Get = New System.Windows.Forms.Button
Me.txtMultiTool_ToolRef3Value = New System.Windows.Forms.TextBox
Me.txtMultiTool_ToolRef3 = New System.Windows.Forms.TextBox
Me.cmdMultiTool_ToolRef3Set = New System.Windows.Forms.Button
Me.Label318 = New System.Windows.Forms.Label
Me.cmdMultiTool_ToolRef2Get = New System.Windows.Forms.Button
Me.txtMultiTool_ToolRef2Value = New System.Windows.Forms.TextBox
Me.txtMultiTool_ToolRef2 = New System.Windows.Forms.TextBox
Me.cmdMultiTool_ToolRef2Set = New System.Windows.Forms.Button
Me.Label317 = New System.Windows.Forms.Label
Me.cmdMultiTool_ToolRef1Get = New System.Windows.Forms.Button
Me.txtMultiTool_ToolRef1Value = New System.Windows.Forms.TextBox
Me.txtMultiTool_ToolRef1 = New System.Windows.Forms.TextBox
Me.cmdMultiTool_ToolRef1Set = New System.Windows.Forms.Button
Me.Label316 = New System.Windows.Forms.Label
Me.cmdMultiTool_GroupEdgeGet = New System.Windows.Forms.Button
Me.txtMultiTool_GroupEdgeValue = New System.Windows.Forms.TextBox
Me.txtMultiTool_GroupEdge = New System.Windows.Forms.TextBox
Me.cmdMultiTool_GroupEdgeSet = New System.Windows.Forms.Button
Me.Label35 = New System.Windows.Forms.Label
Me.cmdMultiTool_ToolGroupLifeGet = New System.Windows.Forms.Button
Me.txtMultiTool_ToolGroupLifeValue = New System.Windows.Forms.TextBox
Me.txtMultiTool_ToolGroupLife = New System.Windows.Forms.TextBox
Me.cmdMultiTool_ToolGroupLifeSet = New System.Windows.Forms.Button
Me.Label34 = New System.Windows.Forms.Label
Me.cmdMultiTool_ToolLifeStatusGet = New System.Windows.Forms.Button
Me.txtMultiTool_ToolLifeStatusValue = New System.Windows.Forms.TextBox
Me.txtMultiTool_ToolLifeStatus = New System.Windows.Forms.TextBox
Me.cmdMultiTool_ToolLifeStatusSet = New System.Windows.Forms.Button
Me.Label33 = New System.Windows.Forms.Label
Me.cmdMultiTool_ToolGaugeGet = New System.Windows.Forms.Button
Me.cmdMultiTool_ToolLifeActualGet = New System.Windows.Forms.Button
Me.cmdMultiTool_ToolSetGet = New System.Windows.Forms.Button
Me.cboMultiToolSubSystem = New System.Windows.Forms.ComboBox
Me.txtMultiTool_ToolLifeGaugeValue = New System.Windows.Forms.TextBox
Me.txtMultiTool_ToolLifeGauge = New System.Windows.Forms.TextBox
Me.cmdMultiTool_ToolGaugeSet = New System.Windows.Forms.Button
Me.Label32 = New System.Windows.Forms.Label
Me.Label242 = New System.Windows.Forms.Label
Me.cmdMultiTool_ToolLifeActualAdd = New System.Windows.Forms.Button
Me.txtMultiTool_ToolLifeActualValue = New System.Windows.Forms.TextBox
Me.txtMultiTool_ToolLifeActual = New System.Windows.Forms.TextBox
Me.cmdMultiTool_ToolLifeActualSet = New System.Windows.Forms.Button
Me.Label185 = New System.Windows.Forms.Label
Me.cmdMultiTool_ToolSetAdd = New System.Windows.Forms.Button
Me.txtMultiTool_ToolLifeSetValue = New System.Windows.Forms.TextBox
Me.txtMultiTool_ToolLifeSet = New System.Windows.Forms.TextBox
Me.cmdMultiTool_ToolSetSet = New System.Windows.Forms.Button
Me.Label187 = New System.Windows.Forms.Label
Me.cboMultiToolEdges = New System.Windows.Forms.ComboBox
Me.Label190 = New System.Windows.Forms.Label
Me.Tab_MacManMachiningReport = New System.Windows.Forms.TabPage
Me.grdMMMachiningReports = New System.Windows.Forms.DataGrid
Me.grdMMMachiningReportTableStyle = New System.Windows.Forms.DataGridTableStyle
Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn
Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn
Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn
Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn
Me.PictureBox1 = New System.Windows.Forms.PictureBox
Me.txtMachiningReport_NoOfWork = New System.Windows.Forms.TextBox
Me.Label144 = New System.Windows.Forms.Label
Me.cmdMMMachiningReportsSubSystem = New System.Windows.Forms.Button
Me.cboMachiningReportSubSystem = New System.Windows.Forms.ComboBox
Me.Label143 = New System.Windows.Forms.Label
Me.MacreportTime = New System.Windows.Forms.TextBox
Me.Label245 = New System.Windows.Forms.Label
Me.txtto = New System.Windows.Forms.TextBox
Me.Label221 = New System.Windows.Forms.Label
Me.txtFrom = New System.Windows.Forms.TextBox
Me.Label222 = New System.Windows.Forms.Label
Me.macreport_result = New System.Windows.Forms.Button
Me.Label216 = New System.Windows.Forms.Label
Me.Cmb_rptPeriod = New System.Windows.Forms.ComboBox
Me.MacReport_programname = New System.Windows.Forms.TextBox
Me.Label217 = New System.Windows.Forms.Label
Me.Macreport_filename = New System.Windows.Forms.TextBox
Me.Label218 = New System.Windows.Forms.Label
Me.MacReport_count = New System.Windows.Forms.TextBox
Me.Label219 = New System.Windows.Forms.Label
Me.macReportUpdateButton = New System.Windows.Forms.Button
Me.MacReport_Index = New System.Windows.Forms.TextBox
Me.Label220 = New System.Windows.Forms.Label
Me.macreport_Operatingtime = New System.Windows.Forms.TextBox
Me.Label225 = New System.Windows.Forms.Label
Me.macreport_Runningtime = New System.Windows.Forms.TextBox
Me.Label226 = New System.Windows.Forms.Label
Me.Macreportdate = New System.Windows.Forms.TextBox
Me.Label227 = New System.Windows.Forms.Label
Me.macreport_maxcount = New System.Windows.Forms.TextBox
Me.Label228 = New System.Windows.Forms.Label
Me.macreport_cuttingtime = New System.Windows.Forms.TextBox
Me.Label229 = New System.Windows.Forms.Label
Me.tab_Chuck = New System.Windows.Forms.TabPage
Me.Label163 = New System.Windows.Forms.Label
Me.Label164 = New System.Windows.Forms.Label
Me.cmb_Chuck_Dataunit = New System.Windows.Forms.ComboBox
Me.cmb_Chuck_SubSys = New System.Windows.Forms.ComboBox
Me.chuckWorkTypeCombo = New System.Windows.Forms.ComboBox
Me.chuckButtonSetWorkType = New System.Windows.Forms.Button
Me.chuckWorkType = New System.Windows.Forms.TextBox
Me.Label157 = New System.Windows.Forms.Label
Me.chuckGrippingFaceToDistanceCal = New System.Windows.Forms.Button
Me.chuckGrippingDiameterCal = New System.Windows.Forms.Button
Me.chuckHoldSet = New System.Windows.Forms.Button
Me.chuckHoldCombo = New System.Windows.Forms.ComboBox
Me.chuckSecondChuckZeroOffsetAdd = New System.Windows.Forms.Button
Me.chuckSecondChuckZeroOffsetSet = New System.Windows.Forms.Button
Me.chuckJawSizeAdd = New System.Windows.Forms.Button
Me.chuckJawSizeSet = New System.Windows.Forms.Button
Me.chuckJawLengthAdd = New System.Windows.Forms.Button
Me.chuckJawLengthSet = New System.Windows.Forms.Button
Me.chuckGrippingLengthAdd = New System.Windows.Forms.Button
Me.chuckGrippingLengthSet = New System.Windows.Forms.Button
Me.chuckGrippingFaceWidthAdd = New System.Windows.Forms.Button
Me.chuckGrippingFaceWidthSet = New System.Windows.Forms.Button
Me.chuckGrippingFaceToDistanceAdd = New System.Windows.Forms.Button
Me.chuckGrippingFaceToDistanceSet = New System.Windows.Forms.Button
Me.chuckGrippingDiameterAdd = New System.Windows.Forms.Button
Me.chuckGrippingDiameterSet = New System.Windows.Forms.Button
Me.chuckSecondChuckZeroOffsetUpd = New System.Windows.Forms.TextBox
Me.chuckSecondChuckZeroOffset = New System.Windows.Forms.TextBox
Me.Label53 = New System.Windows.Forms.Label
Me.chuckJawSizeUpd = New System.Windows.Forms.TextBox
Me.chuckJawSize = New System.Windows.Forms.TextBox
Me.Label52 = New System.Windows.Forms.Label
Me.chuckJawLengthUpd = New System.Windows.Forms.TextBox
Me.chuckJawLength = New System.Windows.Forms.TextBox
Me.Label51 = New System.Windows.Forms.Label
Me.chuckGrippingLengthUpd = New System.Windows.Forms.TextBox
Me.chuckGrippingLength = New System.Windows.Forms.TextBox
Me.Label50 = New System.Windows.Forms.Label
Me.chuckGrippingFaceWidthUpd = New System.Windows.Forms.TextBox
Me.chuckGrippingFaceWidth = New System.Windows.Forms.TextBox
Me.Label49 = New System.Windows.Forms.Label
Me.chuckGrippingFaceToDistanceUpd = New System.Windows.Forms.TextBox
Me.chuckGrippingFaceToDistance = New System.Windows.Forms.TextBox
Me.Label48 = New System.Windows.Forms.Label
Me.chuckGrippingDiameterUpd = New System.Windows.Forms.TextBox
Me.chuckGrippingDiameter = New System.Windows.Forms.TextBox
Me.Label47 = New System.Windows.Forms.Label
Me.Label46 = New System.Windows.Forms.Label
Me.chuckIndexEnum = New System.Windows.Forms.ComboBox
Me.chuckUpdateButton = New System.Windows.Forms.Button
Me.chuckHold = New System.Windows.Forms.TextBox
Me.Label36 = New System.Windows.Forms.Label
Me.tab_tools = New System.Windows.Forms.TabPage
Me.txtGroupNo = New System.Windows.Forms.TextBox
Me.Label324 = New System.Windows.Forms.Label
Me.cmdToolGroupLifeStatusSet = New System.Windows.Forms.Button
Me.txtToolGroupLifeStatusValue = New System.Windows.Forms.TextBox
Me.txtToolGroupLifeStatus = New System.Windows.Forms.TextBox
Me.Label323 = New System.Windows.Forms.Label
Me.Label87 = New System.Windows.Forms.Label
Me.cboTool_Standard_DataUnit = New System.Windows.Forms.ComboBox
Me.cmdToolOffsetStandard_SetSubSystem = New System.Windows.Forms.Button
Me.cboToolWearOffsetAxis = New System.Windows.Forms.ComboBox
Me.Label13 = New System.Windows.Forms.Label
Me.cboToolsSubSystem = New System.Windows.Forms.ComboBox
Me.Label224 = New System.Windows.Forms.Label
Me.cboGaugeStatus = New System.Windows.Forms.ComboBox
Me.cmdAddActualToolLife = New System.Windows.Forms.Button
Me.tulAddToolLife_button = New System.Windows.Forms.Button
Me.tul1ComboToolOffset = New System.Windows.Forms.ComboBox
Me.tul1ComboNoseRComp = New System.Windows.Forms.ComboBox
Me.tulButtonToolWear = New System.Windows.Forms.Button
Me.tulButtonToolOffset = New System.Windows.Forms.Button
Me.tulButtonNoseRComp = New System.Windows.Forms.Button
Me.tulButtonNoseRPattern = New System.Windows.Forms.Button
Me.tulResults = New System.Windows.Forms.TextBox
Me.TulNoseRCompensationPatternTo = New System.Windows.Forms.TextBox
Me.Label9 = New System.Windows.Forms.Label
Me.Label8 = New System.Windows.Forms.Label
Me.TulNoseRCompensationPatternFrom = New System.Windows.Forms.TextBox
Me.TulAddNoseRCompensation = New System.Windows.Forms.Button
Me.tulSetReferenceToolOffset1 = New System.Windows.Forms.Button
Me.tulUpdReferenceToolOffset1 = New System.Windows.Forms.TextBox
Me.tulReferenceToolOffset1 = New System.Windows.Forms.TextBox
Me.Label7 = New System.Windows.Forms.Label
Me.tulComboActualToolLife = New System.Windows.Forms.ComboBox
Me.tulSetActualToolLife = New System.Windows.Forms.Button
Me.tulUpdActualToolLife = New System.Windows.Forms.TextBox
Me.tulActualToolLife = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.TulSetNoseRCompensationPattern = New System.Windows.Forms.Button
Me.TulUpdNoseRCompensationPattern = New System.Windows.Forms.TextBox
Me.TulNoseRCompensationPattern = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.TulComboNoseRCompensation = New System.Windows.Forms.ComboBox
Me.TulSetNoseRCompensation = New System.Windows.Forms.Button
Me.TulUpdNoseRCompensation = New System.Windows.Forms.TextBox
Me.TulNoseRCompensation = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.tulComboToolWearOffset = New System.Windows.Forms.ComboBox
Me.tulComboToolLife = New System.Windows.Forms.ComboBox
Me.tulComboToolOffset = New System.Windows.Forms.ComboBox
Me.tulUpdGroupNumber = New System.Windows.Forms.TextBox
Me.tulSetGroupNumber = New System.Windows.Forms.Button
Me.tulAddToolWearOffset = New System.Windows.Forms.Button
Me.tulUpdLifeStatus = New System.Windows.Forms.ComboBox
Me.tulToolNumber = New System.Windows.Forms.TextBox
Me.label100 = New System.Windows.Forms.Label
Me.tulUpdateButton = New System.Windows.Forms.Button
Me.tulSetToolWearOffset = New System.Windows.Forms.Button
Me.tulUpdToolWearOffset = New System.Windows.Forms.TextBox
Me.tulToolWearOffset = New System.Windows.Forms.TextBox
Me.tulSetToolLife = New System.Windows.Forms.Button
Me.tulUpdToolLife = New System.Windows.Forms.TextBox
Me.tulToolLife = New System.Windows.Forms.TextBox
Me.tulAddToolOffset = New System.Windows.Forms.Button
Me.tulSetToolOffset = New System.Windows.Forms.Button
Me.tulUpdToolOffset = New System.Windows.Forms.TextBox
Me.tulToolOffset = New System.Windows.Forms.TextBox
Me.Label86 = New System.Windows.Forms.Label
Me.tulSetToolNumberInGroup = New System.Windows.Forms.Button
Me.tulUpdToolNumberInGroup = New System.Windows.Forms.TextBox
Me.tulToolNumberInGroup = New System.Windows.Forms.TextBox
Me.Label85 = New System.Windows.Forms.Label
Me.tulMaxToolOffset = New System.Windows.Forms.TextBox
Me.Label83 = New System.Windows.Forms.Label
Me.tulSetLifeStatus = New System.Windows.Forms.Button
Me.tulLifeStatus = New System.Windows.Forms.TextBox
Me.Label82 = New System.Windows.Forms.Label
Me.tulSetReferenceToolOffset3 = New System.Windows.Forms.Button
Me.tulSetReferenceToolOffset2 = New System.Windows.Forms.Button
Me.tulSetGauseStatus = New System.Windows.Forms.Button
Me.tulUpdReferenceToolOffset3 = New System.Windows.Forms.TextBox
Me.tulUpdReferenceToolOffset2 = New System.Windows.Forms.TextBox
Me.tulReferenceToolOffset3 = New System.Windows.Forms.TextBox
Me.Label74 = New System.Windows.Forms.Label
Me.tulReferenceToolOffset2 = New System.Windows.Forms.TextBox
Me.Label75 = New System.Windows.Forms.Label
Me.tulGroupNumber = New System.Windows.Forms.TextBox
Me.Label76 = New System.Windows.Forms.Label
Me.tulCurrentToolOffsetNumber = New System.Windows.Forms.TextBox
Me.Label77 = New System.Windows.Forms.Label
Me.tulGauseStatus = New System.Windows.Forms.TextBox
Me.Label78 = New System.Windows.Forms.Label
Me.Label79 = New System.Windows.Forms.Label
Me.tulCurrentToolNumber = New System.Windows.Forms.TextBox
Me.Label80 = New System.Windows.Forms.Label
Me.tulCurrentNoseRCompNumber = New System.Windows.Forms.TextBox
Me.TextBox3 = New System.Windows.Forms.TextBox
Me.TextBox4 = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.TabPage2 = New System.Windows.Forms.TabPage
Me.Label191 = New System.Windows.Forms.Label
Me.mopnhMaxNoofReports = New System.Windows.Forms.TextBox
Me.objMopnhUpdateButton = New System.Windows.Forms.Button
Me.Label212 = New System.Windows.Forms.Label
Me.Label213 = New System.Windows.Forms.Label
Me.mopnhTo = New System.Windows.Forms.TextBox
Me.mopnhFrom = New System.Windows.Forms.TextBox
Me.GroupBox5 = New System.Windows.Forms.GroupBox
Me.mopnhPrevAlarmonTime = New System.Windows.Forms.TextBox
Me.mopnhPrevExternalInputTime = New System.Windows.Forms.TextBox
Me.mopnhPrevSpindleRunTime = New System.Windows.Forms.TextBox
Me.mopnhPrevOtherTime = New System.Windows.Forms.TextBox
Me.mopnhPrevMaintenanceTime = New System.Windows.Forms.TextBox
Me.mopnhPrevPartWaitingTime = New System.Windows.Forms.TextBox
Me.mopnhPrevNoOperatorTime = New System.Windows.Forms.TextBox
Me.mopnhPrevInProSetupTime = New System.Windows.Forms.TextBox
Me.mopnhPrevNonOperatingTime = New System.Windows.Forms.TextBox
Me.mopnhPrevCuttingTime = New System.Windows.Forms.TextBox
Me.mopnhPrevOperatingTime = New System.Windows.Forms.TextBox
Me.Label223 = New System.Windows.Forms.Label
Me.Label247 = New System.Windows.Forms.Label
Me.Label250 = New System.Windows.Forms.Label
Me.Label251 = New System.Windows.Forms.Label
Me.Label255 = New System.Windows.Forms.Label
Me.Label257 = New System.Windows.Forms.Label
Me.Label258 = New System.Windows.Forms.Label
Me.Label259 = New System.Windows.Forms.Label
Me.Label260 = New System.Windows.Forms.Label
Me.Label261 = New System.Windows.Forms.Label
Me.Label262 = New System.Windows.Forms.Label
Me.Label263 = New System.Windows.Forms.Label
Me.mopnhPrevRunningTime = New System.Windows.Forms.TextBox
Me.GroupBox4 = New System.Windows.Forms.GroupBox
Me.mopnhAlarmOnTime = New System.Windows.Forms.TextBox
Me.mopnhExternalInputTime = New System.Windows.Forms.TextBox
Me.mopnhSpindleRunTime = New System.Windows.Forms.TextBox
Me.mopnhOtherTime = New System.Windows.Forms.TextBox
Me.mopnhMaintenanceTime = New System.Windows.Forms.TextBox
Me.mopnhPartWaitingTime = New System.Windows.Forms.TextBox
Me.mopnhNoOperatorTime = New System.Windows.Forms.TextBox
Me.mopnhInProSetupTime = New System.Windows.Forms.TextBox
Me.mopnhNonOperatingReport = New System.Windows.Forms.TextBox
Me.mopnhCuttingTime = New System.Windows.Forms.TextBox
Me.mopnhOperatingTime = New System.Windows.Forms.TextBox
Me.mopnhRunningTime = New System.Windows.Forms.TextBox
Me.Label200 = New System.Windows.Forms.Label
Me.Label201 = New System.Windows.Forms.Label
Me.Label202 = New System.Windows.Forms.Label
Me.Label203 = New System.Windows.Forms.Label
Me.Label204 = New System.Windows.Forms.Label
Me.Label205 = New System.Windows.Forms.Label
Me.Label206 = New System.Windows.Forms.Label
Me.Label207 = New System.Windows.Forms.Label
Me.Label208 = New System.Windows.Forms.Label
Me.Label209 = New System.Windows.Forms.Label
Me.Label210 = New System.Windows.Forms.Label
Me.Label211 = New System.Windows.Forms.Label
Me.CMD_SETOPERATINGHISTORY = New System.Windows.Forms.Button
Me.CMB_OPERATINGHISTORY = New System.Windows.Forms.ComboBox
Me.Label252 = New System.Windows.Forms.Label
Me.tab_CMDTool = New System.Windows.Forms.TabPage
Me.GroupBox8 = New System.Windows.Forms.GroupBox
Me.toolOffsetAxis1Combo = New System.Windows.Forms.ComboBox
Me.Label124 = New System.Windows.Forms.Label
Me.cmdAddToolOffset = New System.Windows.Forms.Button
Me.cmdAddToolOffsetCuttingPos = New System.Windows.Forms.Button
Me.cmdSubToolOffset = New System.Windows.Forms.Button
Me.cmdSubToolOffsetCuttingPos = New System.Windows.Forms.Button
Me.toolCalToolOffset = New System.Windows.Forms.TextBox
Me.toolCalToolOffsetExe = New System.Windows.Forms.Button
Me.GroupBox7 = New System.Windows.Forms.GroupBox
Me.cmdAddToolWearOffset = New System.Windows.Forms.Button
Me.toolAddMethod = New System.Windows.Forms.Button
Me.toolOffsetAxis2Combo = New System.Windows.Forms.ComboBox
Me.Label125 = New System.Windows.Forms.Label
Me.cmdAddNoseRCuttingPos = New System.Windows.Forms.Button
Me.cmdAddToolWearOffsetCuttingPos = New System.Windows.Forms.Button
Me.cmdSubNoseR = New System.Windows.Forms.Button
Me.cmdSubNoseRCuttingPos = New System.Windows.Forms.Button
Me.cmdSubToolWearOffsetCuttingPos = New System.Windows.Forms.Button
Me.toolAutoCalToolOffsetExe = New System.Windows.Forms.Button
Me.toolMeasureCalToolOffsetExe = New System.Windows.Forms.Button
Me.Label128 = New System.Windows.Forms.Label
Me.toolSensorDirectionCombo = New System.Windows.Forms.ComboBox
Me.Label130 = New System.Windows.Forms.Label
Me.toolToolNo = New System.Windows.Forms.TextBox
Me.Label127 = New System.Windows.Forms.Label
Me.toolCuttingPositionsCombo = New System.Windows.Forms.ComboBox
Me.Label126 = New System.Windows.Forms.Label
Me.toolSubSystemsCombo = New System.Windows.Forms.ComboBox
Me.Tools2 = New System.Windows.Forms.TabPage
Me.cmdTool2Set = New System.Windows.Forms.Button
Me.Panel17 = New System.Windows.Forms.Panel
Me.Label166 = New System.Windows.Forms.Label
Me.txtTool2Input = New System.Windows.Forms.TextBox
Me.Label129 = New System.Windows.Forms.Label
Me.Label244 = New System.Windows.Forms.Label
Me.Label243 = New System.Windows.Forms.Label
Me.Btn_AddCompensation = New System.Windows.Forms.Button
Me.Label178 = New System.Windows.Forms.Label
Me.Cmb_NoseRCompensationAxisIndex = New System.Windows.Forms.ComboBox
Me.Btn_GetNose2 = New System.Windows.Forms.Button
Me.Btn_GetNose = New System.Windows.Forms.Button
Me.cmd_Ctools2_setToolOffset = New System.Windows.Forms.Button
Me.cmd_Ctools2_AddToolOffset = New System.Windows.Forms.Button
Me.txt_CTools2_ToolOffSet = New System.Windows.Forms.TextBox
Me.cbo_Ctools2_getToolOffset = New System.Windows.Forms.Button
Me.cbo_Ctools2_ToolOffSetAxisIndex = New System.Windows.Forms.ComboBox
Me.txt_CTools2_fromindx = New System.Windows.Forms.TextBox
Me.Label180 = New System.Windows.Forms.Label
Me.Label181 = New System.Windows.Forms.Label
Me.txt_CTools2_toindx = New System.Windows.Forms.TextBox
Me.Label182 = New System.Windows.Forms.Label
Me.Label183 = New System.Windows.Forms.Label
Me.cbo_Ctools2_Cutpos = New System.Windows.Forms.ComboBox
Me.cbo_Ctools2_getToolOffset2 = New System.Windows.Forms.Button
Me.btn_setCompensation = New System.Windows.Forms.Button
Me.txt_CTools2_ToolIntNDX = New System.Windows.Forms.TextBox
Me.txtCTool2_NoseRCompensationPatternSettingValue = New System.Windows.Forms.TextBox
Me.Label184 = New System.Windows.Forms.Label
Me.Label172 = New System.Windows.Forms.Label
Me.Label173 = New System.Windows.Forms.Label
Me.cmb_Tool2_DataUnit = New System.Windows.Forms.ComboBox
Me.cmb_Tool2_SubSys = New System.Windows.Forms.ComboBox
Me.tul2tn = New System.Windows.Forms.TextBox
Me.Label156 = New System.Windows.Forms.Label
Me.tul2ButtonUpdate = New System.Windows.Forms.Button
Me.Label155 = New System.Windows.Forms.Label
Me.Label154 = New System.Windows.Forms.Label
Me.tul2pa3 = New System.Windows.Forms.ComboBox
Me.tul2pa2 = New System.Windows.Forms.ComboBox
Me.tul2pa1 = New System.Windows.Forms.ComboBox
Me.tul2ba3 = New System.Windows.Forms.ComboBox
Me.tul2ba2 = New System.Windows.Forms.ComboBox
Me.tul2ba1 = New System.Windows.Forms.ComboBox
Me.tul2Button1 = New System.Windows.Forms.Button
Me.tul2set1 = New System.Windows.Forms.TextBox
Me.tul2get1 = New System.Windows.Forms.TextBox
Me.Label151 = New System.Windows.Forms.Label
Me.tul2Button3 = New System.Windows.Forms.Button
Me.tul2Button2 = New System.Windows.Forms.Button
Me.tul2set3 = New System.Windows.Forms.TextBox
Me.tul2set2 = New System.Windows.Forms.TextBox
Me.tul2get3 = New System.Windows.Forms.TextBox
Me.Label152 = New System.Windows.Forms.Label
Me.tul2get2 = New System.Windows.Forms.TextBox
Me.Label153 = New System.Windows.Forms.Label
Me.Tools3 = New System.Windows.Forms.TabPage
Me.cmdTool3Set = New System.Windows.Forms.Button
Me.Label131 = New System.Windows.Forms.Label
Me.Label132 = New System.Windows.Forms.Label
Me.cboTool3DataUnit = New System.Windows.Forms.ComboBox
Me.cboTool3SubSystem = New System.Windows.Forms.ComboBox
Me.Label196 = New System.Windows.Forms.Label
Me.Label195 = New System.Windows.Forms.Label
Me.tul3tn = New System.Windows.Forms.TextBox
Me.Label199 = New System.Windows.Forms.Label
Me.tu3_Update = New System.Windows.Forms.Button
Me.Label197 = New System.Windows.Forms.Label
Me.Label198 = New System.Windows.Forms.Label
Me.txt_getValue = New System.Windows.Forms.TextBox
Me.tul2AddToolWearOffset = New System.Windows.Forms.Button
Me.GetToolWearOffsetButton = New System.Windows.Forms.Button
Me.Label194 = New System.Windows.Forms.Label
Me.tul3get4 = New System.Windows.Forms.TextBox
Me.tul3_Set = New System.Windows.Forms.Button
Me.txt_double1 = New System.Windows.Forms.TextBox
Me.Label192 = New System.Windows.Forms.Label
Me.Label193 = New System.Windows.Forms.Label
Me.cmb_ToolWearOffsetAxisIndex = New System.Windows.Forms.ComboBox
Me.cmb_CuttingPosition = New System.Windows.Forms.ComboBox
Me.txt_ToIndex = New System.Windows.Forms.TextBox
Me.txt_FromIndex = New System.Windows.Forms.TextBox
Me.Tab_Turret = New System.Windows.Forms.TabPage
Me.txtMaxToolPotPerTurret = New System.Windows.Forms.TextBox
Me.Label175 = New System.Windows.Forms.Label
Me.cboTurretSides = New System.Windows.Forms.ComboBox
Me.GroupBox10 = New System.Windows.Forms.GroupBox
Me.turTurretOffsetAdd = New System.Windows.Forms.Button
Me.turTurretOffsetSet = New System.Windows.Forms.Button
Me.turTurretOffsetUpd = New System.Windows.Forms.TextBox
Me.turTurretOffset = New System.Windows.Forms.TextBox
Me.Label81 = New System.Windows.Forms.Label
Me.GroupBox9 = New System.Windows.Forms.GroupBox
Me.Label54 = New System.Windows.Forms.Label
Me.turBAxisTurretOffsetAdd = New System.Windows.Forms.Button
Me.turBAxisTurretOffsetSet = New System.Windows.Forms.Button
Me.turBAxisTurretOffsetUpd = New System.Windows.Forms.TextBox
Me.turTurretMode = New System.Windows.Forms.TextBox
Me.turBAxisTurretOffset = New System.Windows.Forms.TextBox
Me.Label88 = New System.Windows.Forms.Label
Me.turBAxisTurretCombo = New System.Windows.Forms.ComboBox
Me.Label56 = New System.Windows.Forms.Label
Me.cmdTurretDataUnit = New System.Windows.Forms.Button
Me.cmdTurretSubSystem = New System.Windows.Forms.Button
Me.cmb_Turret_DataUnit = New System.Windows.Forms.ComboBox
Me.cmb_Turret_subsys = New System.Windows.Forms.ComboBox
Me.turToolNo = New System.Windows.Forms.TextBox
Me.Label93 = New System.Windows.Forms.Label
Me.turUpdate = New System.Windows.Forms.Button
Me.Label55 = New System.Windows.Forms.Label
Me.turToolOffsetAxisCombo = New System.Windows.Forms.ComboBox
Me.tab_variables = New System.Windows.Forms.TabPage
Me.GroupBox13 = New System.Windows.Forms.GroupBox
Me.varSetValue = New System.Windows.Forms.Button
Me.varEnd = New System.Windows.Forms.TextBox
Me.varBegin = New System.Windows.Forms.TextBox
Me.varValueUpdate = New System.Windows.Forms.TextBox
Me.Label91 = New System.Windows.Forms.Label
Me.varCommonVarNumber = New System.Windows.Forms.TextBox
Me.Label92 = New System.Windows.Forms.Label
Me.Label176 = New System.Windows.Forms.Label
Me.cmb_Variable_SubSys = New System.Windows.Forms.ComboBox
Me.varGetValue = New System.Windows.Forms.Button
Me.Label90 = New System.Windows.Forms.Label
Me.varValue = New System.Windows.Forms.TextBox
Me.varUpdateButton = New System.Windows.Forms.Button
Me.varGetAllButton = New System.Windows.Forms.Button
Me.Label89 = New System.Windows.Forms.Label
Me.varNumberOfVars = New System.Windows.Forms.TextBox
Me.varAddValue = New System.Windows.Forms.Button
Me.Label246 = New System.Windows.Forms.Label
Me.varGetAllResults = New System.Windows.Forms.TextBox
Me.tab_TailStock = New System.Windows.Forms.TabPage
Me.cmdTailStockSet = New System.Windows.Forms.Button
Me.txtTailStockSpindlePositionSetting = New System.Windows.Forms.TextBox
Me.txtTailStockSpindlePosition = New System.Windows.Forms.TextBox
Me.cmb_Tail_SubSys = New System.Windows.Forms.ComboBox
Me.tailstockUpdate = New System.Windows.Forms.Button
Me.TailStockLengthUpd = New System.Windows.Forms.TextBox
Me.Label122 = New System.Windows.Forms.Label
Me.TailStockLength = New System.Windows.Forms.TextBox
Me.TailStockLengthAdd = New System.Windows.Forms.Button
Me.TailStockDiameterAdd = New System.Windows.Forms.Button
Me.TailStockLengthSet = New System.Windows.Forms.Button
Me.TailStockDiameterUpd = New System.Windows.Forms.TextBox
Me.TailStockDiameterSet = New System.Windows.Forms.Button
Me.Label121 = New System.Windows.Forms.Label
Me.TailStockLengthCombo = New System.Windows.Forms.ComboBox
Me.Label114 = New System.Windows.Forms.Label
Me.TailStockDiameter = New System.Windows.Forms.TextBox
Me.TailStockDiameterCombo = New System.Windows.Forms.ComboBox
Me.Label97 = New System.Windows.Forms.Label
Me.Label169 = New System.Windows.Forms.Label
Me.Label170 = New System.Windows.Forms.Label
Me.cmb_Tail_Dataunit = New System.Windows.Forms.ComboBox
Me.cmd_tailStock_SetAxisPos = New System.Windows.Forms.Button
Me.Label171 = New System.Windows.Forms.Label
Me.cmd_tailStock_AddAxisPos = New System.Windows.Forms.Button
Me.cmd_tailStock_CalAxisPos = New System.Windows.Forms.Button
Me.tab_spindle = New System.Windows.Forms.TabPage
Me.MaxSpindleRateOverride = New System.Windows.Forms.TextBox
Me.Label248 = New System.Windows.Forms.Label
Me.Label167 = New System.Windows.Forms.Label
Me.cmb_Spindle_SubSys = New System.Windows.Forms.ComboBox
Me.spinSpindleSurfaceSpeed = New System.Windows.Forms.TextBox
Me.Label45 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.spinComboAxis = New System.Windows.Forms.ComboBox
Me.spinState = New System.Windows.Forms.TextBox
Me.Label73 = New System.Windows.Forms.Label
Me.spinUpdate = New System.Windows.Forms.Button
Me.spinRateOverride = New System.Windows.Forms.TextBox
Me.Label67 = New System.Windows.Forms.Label
Me.spinLoad = New System.Windows.Forms.TextBox
Me.Label68 = New System.Windows.Forms.Label
Me.spinOilMist = New System.Windows.Forms.TextBox
Me.Label69 = New System.Windows.Forms.Label
Me.spinSpindleMode = New System.Windows.Forms.TextBox
Me.Label70 = New System.Windows.Forms.Label
Me.spinCommandRate = New System.Windows.Forms.TextBox
Me.Label71 = New System.Windows.Forms.Label
Me.spinActualRate = New System.Windows.Forms.TextBox
Me.Label72 = New System.Windows.Forms.Label
Me.MSpindle = New System.Windows.Forms.TabPage
Me.Label233 = New System.Windows.Forms.Label
Me.mspinSetSubSystem = New System.Windows.Forms.Button
Me.mspinUpdate = New System.Windows.Forms.Button
Me.mspinSubSystemCombo = New System.Windows.Forms.ComboBox
Me.Label44 = New System.Windows.Forms.Label
Me.mspinSpindleRateOverrideCombo = New System.Windows.Forms.ComboBox
Me.mspinSpindleRateOverride = New System.Windows.Forms.TextBox
Me.Label43 = New System.Windows.Forms.Label
Me.mspinMSpindleState = New System.Windows.Forms.TextBox
Me.Label42 = New System.Windows.Forms.Label
Me.mspinMSpindleLoad = New System.Windows.Forms.TextBox
Me.Label41 = New System.Windows.Forms.Label
Me.mspinCurrentToolInH1Turret = New System.Windows.Forms.TextBox
Me.Label40 = New System.Windows.Forms.Label
Me.mspinCommandMSpindleRate = New System.Windows.Forms.TextBox
Me.Label39 = New System.Windows.Forms.Label
Me.mspinActualMSpindleRate = New System.Windows.Forms.TextBox
Me.Label38 = New System.Windows.Forms.Label
Me.tab_OptionalParameter = New System.Windows.Forms.TabPage
Me.GroupBox12 = New System.Windows.Forms.GroupBox
Me.txtLongWordInput = New System.Windows.Forms.TextBox
Me.txtWordInput = New System.Windows.Forms.TextBox
Me.txtBitInput = New System.Windows.Forms.TextBox
Me.cmdWordAdd = New System.Windows.Forms.Button
Me.cmdLongWordAdd = New System.Windows.Forms.Button
Me.cmdBitSet = New System.Windows.Forms.Button
Me.cmdWordSet = New System.Windows.Forms.Button
Me.cmdLongWordSet = New System.Windows.Forms.Button
Me.cmdOptionalParameterBitGet = New System.Windows.Forms.Button
Me.cmdOptionalParameterWordGet = New System.Windows.Forms.Button
Me.cmdOptionalParameterLongWordGet = New System.Windows.Forms.Button
Me.txtOptionalParameterLongWord = New System.Windows.Forms.TextBox
Me.txtOptionalParameterWord = New System.Windows.Forms.TextBox
Me.txtOptionalParameterBit = New System.Windows.Forms.TextBox
Me.Label299 = New System.Windows.Forms.Label
Me.txtOptionalParameterBitNo = New System.Windows.Forms.TextBox
Me.Label300 = New System.Windows.Forms.Label
Me.txtOptionalParameterLongWordIndex = New System.Windows.Forms.TextBox
Me.Label301 = New System.Windows.Forms.Label
Me.txtOptionalParameterWordIndex = New System.Windows.Forms.TextBox
Me.Label302 = New System.Windows.Forms.Label
Me.txtOptionalParameterBitIndex = New System.Windows.Forms.TextBox
Me.Label303 = New System.Windows.Forms.Label
Me.cmdOptionalParameterSubSystem = New System.Windows.Forms.Button
Me.cboOptionalParameterSubSystem = New System.Windows.Forms.ComboBox
Me.tab_PLC = New System.Windows.Forms.TabPage
Me.grpIOVariables = New System.Windows.Forms.GroupBox
Me.Label297 = New System.Windows.Forms.Label
Me.cboIOVariableTypes = New System.Windows.Forms.ComboBox
Me.cmdIOGetBit = New System.Windows.Forms.Button
Me.cmdIOGetWord = New System.Windows.Forms.Button
Me.cmdIOGetLongWord = New System.Windows.Forms.Button
Me.txtIOLongWord = New System.Windows.Forms.TextBox
Me.txtIOWord = New System.Windows.Forms.TextBox
Me.txtIOBit = New System.Windows.Forms.TextBox
Me.Label296 = New System.Windows.Forms.Label
Me.txtIOBitNo = New System.Windows.Forms.TextBox
Me.Label295 = New System.Windows.Forms.Label
Me.txtIOLongWordIndex = New System.Windows.Forms.TextBox
Me.Label294 = New System.Windows.Forms.Label
Me.txtIOWordIndex = New System.Windows.Forms.TextBox
Me.Label293 = New System.Windows.Forms.Label
Me.txtIOBitIndex = New System.Windows.Forms.TextBox
Me.Label292 = New System.Windows.Forms.Label
Me.tab_CurrentAlarm = New System.Windows.Forms.TabPage
Me.cboCurrentAlarm_SubSystem = New System.Windows.Forms.ComboBox
Me.Label96 = New System.Windows.Forms.Label
Me.cmdCurrentAlarm_Update = New System.Windows.Forms.Button
Me.GroupBox20 = New System.Windows.Forms.GroupBox
Me.txtCurrentAlarm_AlarmCharacterString = New System.Windows.Forms.TextBox
Me.txtCurrentAlarm_AlarmCode = New System.Windows.Forms.TextBox
Me.PictureBox2 = New System.Windows.Forms.PictureBox
Me.txtCurrentAlarm_ObjectMessage = New System.Windows.Forms.TextBox
Me.txtCurrentAlarm_AlarmMessage = New System.Windows.Forms.TextBox
Me.txtCurrentAlarm_AlarmLevel = New System.Windows.Forms.TextBox
Me.txtCurrentAlarm_ObjectNumber = New System.Windows.Forms.TextBox
Me.txtCurrentAlarm_AlarmNumber = New System.Windows.Forms.TextBox
Me.PictureBox3 = New System.Windows.Forms.PictureBox
Me.tab_ballscrew = New System.Windows.Forms.TabPage
Me.cmdPECSet = New System.Windows.Forms.Button
Me.cmb_BallScrew_DataUnit = New System.Windows.Forms.ComboBox
Me.cmb_BallScrew_SubSystem = New System.Windows.Forms.ComboBox
Me.bsBAxisIntervalAdd = New System.Windows.Forms.Button
Me.bsBAxisIntervalSet = New System.Windows.Forms.Button
Me.bsBAxisIntervalUpdate = New System.Windows.Forms.TextBox
Me.bsBAxisInterval = New System.Windows.Forms.TextBox
Me.Label28 = New System.Windows.Forms.Label
Me.bsIntervalCombo = New System.Windows.Forms.ComboBox
Me.bsDataPointCombo = New System.Windows.Forms.ComboBox
Me.Label115 = New System.Windows.Forms.Label
Me.bsPecPoint = New System.Windows.Forms.TextBox
Me.bsBAxisStartPositionAdd = New System.Windows.Forms.Button
Me.bsBAxisStartPositionSet = New System.Windows.Forms.Button
Me.bsBAxisDataPointAdd = New System.Windows.Forms.Button
Me.bsBAxisDataPointSet = New System.Windows.Forms.Button
Me.bsIntervalAdd = New System.Windows.Forms.Button
Me.bsIntervalSet = New System.Windows.Forms.Button
Me.bsDataPointAdd = New System.Windows.Forms.Button
Me.bsDataPointSet = New System.Windows.Forms.Button
Me.bsBAxisStartPositionUpdate = New System.Windows.Forms.TextBox
Me.bsBAxisDataPointUpdate = New System.Windows.Forms.TextBox
Me.bsIntervalUpdate = New System.Windows.Forms.TextBox
Me.bsDataPointUpdate = New System.Windows.Forms.TextBox
Me.bsBAxisStartPosition = New System.Windows.Forms.TextBox
Me.Label31 = New System.Windows.Forms.Label
Me.bsBAxisDataPoint = New System.Windows.Forms.TextBox
Me.Label30 = New System.Windows.Forms.Label
Me.bsInterval = New System.Windows.Forms.TextBox
Me.Label29 = New System.Windows.Forms.Label
Me.ballscrewUpdateButton = New System.Windows.Forms.Button
Me.bsDataPoint = New System.Windows.Forms.TextBox
Me.Label27 = New System.Windows.Forms.Label
Me.Label161 = New System.Windows.Forms.Label
Me.Label162 = New System.Windows.Forms.Label
Me.tab_MacManAlarmHistory = New System.Windows.Forms.TabPage
Me.mahTo = New System.Windows.Forms.TextBox
Me.Label137 = New System.Windows.Forms.Label
Me.mahFrom = New System.Windows.Forms.TextBox
Me.Label138 = New System.Windows.Forms.Label
Me.mahResults = New System.Windows.Forms.TextBox
Me.mahButtonResults = New System.Windows.Forms.Button
Me.mahAlarmObject = New System.Windows.Forms.TextBox
Me.Label135 = New System.Windows.Forms.Label
Me.mahAlarmSubSystemSet = New System.Windows.Forms.Button
Me.mahAlarmSubSystemCombo = New System.Windows.Forms.ComboBox
Me.Label134 = New System.Windows.Forms.Label
Me.mahUpdateButton = New System.Windows.Forms.Button
Me.mahAlarmIndex = New System.Windows.Forms.TextBox
Me.Label107 = New System.Windows.Forms.Label
Me.mahMaxAlarmCount = New System.Windows.Forms.TextBox
Me.Label98 = New System.Windows.Forms.Label
Me.mahAlarmCount = New System.Windows.Forms.TextBox
Me.Label101 = New System.Windows.Forms.Label
Me.mahAlarmTime = New System.Windows.Forms.TextBox
Me.Label102 = New System.Windows.Forms.Label
Me.mahAlarmNumber = New System.Windows.Forms.TextBox
Me.Label103 = New System.Windows.Forms.Label
Me.mahAlarmMessage = New System.Windows.Forms.TextBox
Me.Label104 = New System.Windows.Forms.Label
Me.mahAlarmDate = New System.Windows.Forms.TextBox
Me.Label105 = New System.Windows.Forms.Label
Me.mahAlarmCode = New System.Windows.Forms.TextBox
Me.Label106 = New System.Windows.Forms.Label
Me.ErrorLog = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.txtCurrentAlarmNumber = New System.Windows.Forms.Button
Me.ComboBox1 = New System.Windows.Forms.ComboBox
Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
Me.Tab_IO.SuspendLayout
Me.tab_axis.SuspendLayout
Me.Panel4.SuspendLayout
Me.CATC.SuspendLayout
Me.tab_Program2.SuspendLayout
Me.GroupBox18.SuspendLayout
Me.tab_program.SuspendLayout
Me.GroupBox1.SuspendLayout
Me.Panel8.SuspendLayout
Me.tab_MacmanOperatingReport.SuspendLayout
Me.GroupBox6.SuspendLayout
Me.GroupBox2.SuspendLayout
Me.GroupBox3.SuspendLayout
Me.tab_spec.SuspendLayout
Me.GroupBox17.SuspendLayout
Me.tab_views.SuspendLayout
Me.Panel12.SuspendLayout
Me.tab_ToolStandard2.SuspendLayout
Me.Tool2InputPanel.SuspendLayout
Me.TabPage3.SuspendLayout
Me.GroupBox14.SuspendLayout
Me.tab_MacmanOperatingHistory.SuspendLayout
Me.tab_workpiece.SuspendLayout
Me.Panel1.SuspendLayout
Me.Panel9.SuspendLayout
Me.Panel10.SuspendLayout
Me.tab_machine.SuspendLayout
Me.GroupBox19.SuspendLayout
Me.tab_axis_2.SuspendLayout
Me.GroupBox11.SuspendLayout
Me.UserParameterDroopDataAxis.SuspendLayout
Me.tab_MultiTools.SuspendLayout
Me.Panel.SuspendLayout
Me.GroupBox21.SuspendLayout
Me.Tab_MacManMachiningReport.SuspendLayout
CType(Me.grdMMMachiningReports,System.ComponentModel.ISupportInitialize).BeginInit
Me.tab_Chuck.SuspendLayout
Me.tab_tools.SuspendLayout
Me.TabPage2.SuspendLayout
Me.GroupBox5.SuspendLayout
Me.GroupBox4.SuspendLayout
Me.tab_CMDTool.SuspendLayout
Me.GroupBox8.SuspendLayout
Me.GroupBox7.SuspendLayout
Me.Tools2.SuspendLayout
Me.Panel17.SuspendLayout
Me.Tools3.SuspendLayout
Me.Tab_Turret.SuspendLayout
Me.GroupBox10.SuspendLayout
Me.GroupBox9.SuspendLayout
Me.tab_variables.SuspendLayout
Me.GroupBox13.SuspendLayout
Me.tab_TailStock.SuspendLayout
Me.tab_spindle.SuspendLayout
Me.MSpindle.SuspendLayout
Me.tab_OptionalParameter.SuspendLayout
Me.GroupBox12.SuspendLayout
Me.tab_PLC.SuspendLayout
Me.grpIOVariables.SuspendLayout
Me.tab_CurrentAlarm.SuspendLayout
Me.GroupBox20.SuspendLayout
Me.tab_ballscrew.SuspendLayout
Me.tab_MacManAlarmHistory.SuspendLayout
Me.SuspendLayout
'
'Tab_IO
'
Me.Tab_IO.Controls.Add(Me.tab_axis)
Me.Tab_IO.Controls.Add(Me.tab_machine)
Me.Tab_IO.Controls.Add(Me.CATC)
Me.Tab_IO.Controls.Add(Me.tab_Program2)
Me.Tab_IO.Controls.Add(Me.tab_program)
Me.Tab_IO.Controls.Add(Me.tab_MacmanOperatingReport)
Me.Tab_IO.Controls.Add(Me.tab_spec)
Me.Tab_IO.Controls.Add(Me.tab_views)
Me.Tab_IO.Controls.Add(Me.tab_ToolStandard2)
Me.Tab_IO.Controls.Add(Me.TabPage3)
Me.Tab_IO.Controls.Add(Me.tab_MacmanOperatingHistory)
Me.Tab_IO.Controls.Add(Me.tab_workpiece)
Me.Tab_IO.Controls.Add(Me.tab_axis_2)
Me.Tab_IO.Controls.Add(Me.tab_MultiTools)
Me.Tab_IO.Controls.Add(Me.Tab_MacManMachiningReport)
Me.Tab_IO.Controls.Add(Me.tab_Chuck)
Me.Tab_IO.Controls.Add(Me.tab_tools)
Me.Tab_IO.Controls.Add(Me.TabPage2)
Me.Tab_IO.Controls.Add(Me.tab_CMDTool)
Me.Tab_IO.Controls.Add(Me.Tools2)
Me.Tab_IO.Controls.Add(Me.Tools3)
Me.Tab_IO.Controls.Add(Me.Tab_Turret)
Me.Tab_IO.Controls.Add(Me.tab_variables)
Me.Tab_IO.Controls.Add(Me.tab_TailStock)
Me.Tab_IO.Controls.Add(Me.tab_spindle)
Me.Tab_IO.Controls.Add(Me.MSpindle)
Me.Tab_IO.Controls.Add(Me.tab_OptionalParameter)
Me.Tab_IO.Controls.Add(Me.tab_PLC)
Me.Tab_IO.Controls.Add(Me.tab_CurrentAlarm)
Me.Tab_IO.Controls.Add(Me.tab_ballscrew)
Me.Tab_IO.Controls.Add(Me.tab_MacManAlarmHistory)
Me.Tab_IO.Location = New System.Drawing.Point(8, 8)
Me.Tab_IO.Name = "Tab_IO"
Me.Tab_IO.SelectedIndex = 0
Me.Tab_IO.Size = New System.Drawing.Size(784, 472)
Me.Tab_IO.TabIndex = 0
'
'tab_axis
'
Me.tab_axis.Controls.Add(Me.lbl_FeedRate)
Me.tab_axis.Controls.Add(Me.Label158)
Me.tab_axis.Controls.Add(Me.AxismaxFeedrateOverride)
Me.tab_axis.Controls.Add(Me.Label26)
Me.tab_axis.Controls.Add(Me.AxisBAxisLoad)
Me.tab_axis.Controls.Add(Me.Label25)
Me.tab_axis.Controls.Add(Me.AxisfeedrateOverride)
Me.tab_axis.Controls.Add(Me.Label24)
Me.tab_axis.Controls.Add(Me.AxisfeedHold)
Me.tab_axis.Controls.Add(Me.Label23)
Me.tab_axis.Controls.Add(Me.txtAxisType)
Me.tab_axis.Controls.Add(Me.Label22)
Me.tab_axis.Controls.Add(Me.axisName)
Me.tab_axis.Controls.Add(Me.Label21)
Me.tab_axis.Controls.Add(Me.AxistargetPosition)
Me.tab_axis.Controls.Add(Me.Label20)
Me.tab_axis.Controls.Add(Me.AxisdistanceTarget)
Me.tab_axis.Controls.Add(Me.Label19)
Me.tab_axis.Controls.Add(Me.AxiscommandFeedRate)
Me.tab_axis.Controls.Add(Me.Label18)
Me.tab_axis.Controls.Add(Me.axisLoad)
Me.tab_axis.Controls.Add(Me.Label17)
Me.tab_axis.Controls.Add(Me.AxisAPProgramCoord)
Me.tab_axis.Controls.Add(Me.Label16)
Me.tab_axis.Controls.Add(Me.AxisAPMachineCoord)
Me.tab_axis.Controls.Add(Me.Label15)
Me.tab_axis.Controls.Add(Me.AxisAPEncoderCoord)
Me.tab_axis.Controls.Add(Me.Label14)
Me.tab_axis.Controls.Add(Me.AxisActualFeedrate)
Me.tab_axis.Controls.Add(Me.Label12)
Me.tab_axis.Controls.Add(Me.axis2Combo)
Me.tab_axis.Controls.Add(Me.axis1Combo)
Me.tab_axis.Controls.Add(Me.Label10)
Me.tab_axis.Controls.Add(Me.Panel4)
Me.tab_axis.Controls.Add(Me.Label123)
Me.tab_axis.Controls.Add(Me.axisAllCombo)
Me.tab_axis.Controls.Add(Me.Label11)
Me.tab_axis.Controls.Add(Me.axisUpdateButton)
Me.tab_axis.Location = New System.Drawing.Point(4, 22)
Me.tab_axis.Name = "tab_axis"
Me.tab_axis.Size = New System.Drawing.Size(776, 446)
Me.tab_axis.TabIndex = 1
Me.tab_axis.Text = "Axis"
'
'lbl_FeedRate
'
Me.lbl_FeedRate.BackColor = System.Drawing.SystemColors.Control
Me.lbl_FeedRate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.lbl_FeedRate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.lbl_FeedRate.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.lbl_FeedRate.Location = New System.Drawing.Point(584, 296)
Me.lbl_FeedRate.Name = "lbl_FeedRate"
Me.lbl_FeedRate.Size = New System.Drawing.Size(128, 16)
Me.lbl_FeedRate.TabIndex = 52
Me.lbl_FeedRate.Text = "0"
'
'Label158
'
Me.Label158.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label158.Location = New System.Drawing.Point(424, 296)
Me.Label158.Name = "Label158"
Me.Label158.Size = New System.Drawing.Size(152, 16)
Me.Label158.TabIndex = 51
Me.Label158.Text = "Feed Rate type:"
'
'AxismaxFeedrateOverride
'
Me.AxismaxFeedrateOverride.BackColor = System.Drawing.SystemColors.Control
Me.AxismaxFeedrateOverride.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.AxismaxFeedrateOverride.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.AxismaxFeedrateOverride.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.AxismaxFeedrateOverride.Location = New System.Drawing.Point(584, 264)
Me.AxismaxFeedrateOverride.Name = "AxismaxFeedrateOverride"
Me.AxismaxFeedrateOverride.Size = New System.Drawing.Size(128, 16)
Me.AxismaxFeedrateOverride.TabIndex = 47
Me.AxismaxFeedrateOverride.Text = "0"
'
'Label26
'
Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label26.Location = New System.Drawing.Point(424, 264)
Me.Label26.Name = "Label26"
Me.Label26.Size = New System.Drawing.Size(152, 16)
Me.Label26.TabIndex = 46
Me.Label26.Text = "Max Feedrate Override :"
'
'AxisBAxisLoad
'
Me.AxisBAxisLoad.BackColor = System.Drawing.SystemColors.Control
Me.AxisBAxisLoad.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.AxisBAxisLoad.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.AxisBAxisLoad.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.AxisBAxisLoad.Location = New System.Drawing.Point(584, 240)
Me.AxisBAxisLoad.Name = "AxisBAxisLoad"
Me.AxisBAxisLoad.Size = New System.Drawing.Size(128, 16)
Me.AxisBAxisLoad.TabIndex = 45
Me.AxisBAxisLoad.Text = "0"
'
'Label25
'
Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label25.Location = New System.Drawing.Point(424, 240)
Me.Label25.Name = "Label25"
Me.Label25.Size = New System.Drawing.Size(152, 16)
Me.Label25.TabIndex = 44
Me.Label25.Text = "B Axis Load :"
'
'AxisfeedrateOverride
'
Me.AxisfeedrateOverride.BackColor = System.Drawing.SystemColors.Control
Me.AxisfeedrateOverride.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.AxisfeedrateOverride.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.AxisfeedrateOverride.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.AxisfeedrateOverride.Location = New System.Drawing.Point(584, 216)
Me.AxisfeedrateOverride.Name = "AxisfeedrateOverride"
Me.AxisfeedrateOverride.Size = New System.Drawing.Size(128, 16)
Me.AxisfeedrateOverride.TabIndex = 43
Me.AxisfeedrateOverride.Text = "0"
'
'Label24
'
Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label24.Location = New System.Drawing.Point(424, 216)
Me.Label24.Name = "Label24"
Me.Label24.Size = New System.Drawing.Size(152, 16)
Me.Label24.TabIndex = 42
Me.Label24.Text = "Feedrate Override :"
'
'AxisfeedHold
'
Me.AxisfeedHold.BackColor = System.Drawing.SystemColors.Control
Me.AxisfeedHold.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.AxisfeedHold.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.AxisfeedHold.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.AxisfeedHold.Location = New System.Drawing.Point(584, 192)
Me.AxisfeedHold.Name = "AxisfeedHold"
Me.AxisfeedHold.Size = New System.Drawing.Size(128, 16)
Me.AxisfeedHold.TabIndex = 41
Me.AxisfeedHold.Text = "0"
'
'Label23
'
Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label23.Location = New System.Drawing.Point(424, 192)
Me.Label23.Name = "Label23"
Me.Label23.Size = New System.Drawing.Size(152, 16)
Me.Label23.TabIndex = 40
Me.Label23.Text = "Feed Hold :"
'
'txtAxisType
'
Me.txtAxisType.BackColor = System.Drawing.SystemColors.Control
Me.txtAxisType.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.txtAxisType.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.txtAxisType.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.txtAxisType.Location = New System.Drawing.Point(176, 368)
Me.txtAxisType.Name = "txtAxisType"
Me.txtAxisType.Size = New System.Drawing.Size(128, 16)
Me.txtAxisType.TabIndex = 39
Me.txtAxisType.Text = "0"
'
'Label22
'
Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label22.Location = New System.Drawing.Point(8, 368)
Me.Label22.Name = "Label22"
Me.Label22.Size = New System.Drawing.Size(152, 16)
Me.Label22.TabIndex = 38
Me.Label22.Text = "Axis Type :"
'
'axisName
'
Me.axisName.BackColor = System.Drawing.SystemColors.Control
Me.axisName.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.axisName.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.axisName.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.axisName.Location = New System.Drawing.Point(176, 344)
Me.axisName.Name = "axisName"
Me.axisName.Size = New System.Drawing.Size(128, 16)
Me.axisName.TabIndex = 37
Me.axisName.Text = "0"
'
'Label21
'
Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label21.Location = New System.Drawing.Point(8, 344)
Me.Label21.Name = "Label21"
Me.Label21.Size = New System.Drawing.Size(152, 16)
Me.Label21.TabIndex = 36
Me.Label21.Text = "Axis Name :"
'
'AxistargetPosition
'
Me.AxistargetPosition.BackColor = System.Drawing.SystemColors.Control
Me.AxistargetPosition.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.AxistargetPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.AxistargetPosition.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.AxistargetPosition.Location = New System.Drawing.Point(248, 200)
Me.AxistargetPosition.Name = "AxistargetPosition"
Me.AxistargetPosition.Size = New System.Drawing.Size(160, 13)
Me.AxistargetPosition.TabIndex = 35
Me.AxistargetPosition.Text = "0"
'
'Label20
'
Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label20.Location = New System.Drawing.Point(8, 200)
Me.Label20.Name = "Label20"
Me.Label20.Size = New System.Drawing.Size(208, 16)
Me.Label20.TabIndex = 34
Me.Label20.Text = "Target Position :"
'
'AxisdistanceTarget
'
Me.AxisdistanceTarget.BackColor = System.Drawing.SystemColors.Control
Me.AxisdistanceTarget.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.AxisdistanceTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.AxisdistanceTarget.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.AxisdistanceTarget.Location = New System.Drawing.Point(248, 176)
Me.AxisdistanceTarget.Name = "AxisdistanceTarget"
Me.AxisdistanceTarget.Size = New System.Drawing.Size(160, 13)
Me.AxisdistanceTarget.TabIndex = 33
Me.AxisdistanceTarget.Text = "0"
'
'Label19
'
Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label19.Location = New System.Drawing.Point(8, 176)
Me.Label19.Name = "Label19"
Me.Label19.Size = New System.Drawing.Size(208, 16)
Me.Label19.TabIndex = 32
Me.Label19.Text = "Distance to Target Position :"
'
'AxiscommandFeedRate
'
Me.AxiscommandFeedRate.BackColor = System.Drawing.SystemColors.Control
Me.AxiscommandFeedRate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.AxiscommandFeedRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.AxiscommandFeedRate.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.AxiscommandFeedRate.Location = New System.Drawing.Point(584, 128)
Me.AxiscommandFeedRate.Name = "AxiscommandFeedRate"
Me.AxiscommandFeedRate.Size = New System.Drawing.Size(160, 13)
Me.AxiscommandFeedRate.TabIndex = 31
Me.AxiscommandFeedRate.Text = "0"
'
'Label18
'
Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label18.Location = New System.Drawing.Point(424, 128)
Me.Label18.Name = "Label18"
Me.Label18.Size = New System.Drawing.Size(144, 16)
Me.Label18.TabIndex = 30
Me.Label18.Text = "Command FeedRate:"
'
'axisLoad
'
Me.axisLoad.BackColor = System.Drawing.SystemColors.Control
Me.axisLoad.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.axisLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.axisLoad.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.axisLoad.Location = New System.Drawing.Point(248, 272)
Me.axisLoad.Name = "axisLoad"
Me.axisLoad.Size = New System.Drawing.Size(160, 13)
Me.axisLoad.TabIndex = 29
Me.axisLoad.Text = "0"
'
'Label17
'
Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label17.Location = New System.Drawing.Point(8, 272)
Me.Label17.Name = "Label17"
Me.Label17.Size = New System.Drawing.Size(96, 16)
Me.Label17.TabIndex = 28
Me.Label17.Text = "Axis Load:"
'
'AxisAPProgramCoord
'
Me.AxisAPProgramCoord.BackColor = System.Drawing.SystemColors.Control
Me.AxisAPProgramCoord.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.AxisAPProgramCoord.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.AxisAPProgramCoord.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.AxisAPProgramCoord.Location = New System.Drawing.Point(248, 152)
Me.AxisAPProgramCoord.Name = "AxisAPProgramCoord"
Me.AxisAPProgramCoord.Size = New System.Drawing.Size(160, 13)
Me.AxisAPProgramCoord.TabIndex = 27
Me.AxisAPProgramCoord.Text = "0"
'
'Label16
'
Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label16.Location = New System.Drawing.Point(8, 152)
Me.Label16.Name = "Label16"
Me.Label16.Size = New System.Drawing.Size(208, 16)
Me.Label16.TabIndex = 26
Me.Label16.Text = "Actual Position Program Coordinates:"
'
'AxisAPMachineCoord
'
Me.AxisAPMachineCoord.BackColor = System.Drawing.SystemColors.Control
Me.AxisAPMachineCoord.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.AxisAPMachineCoord.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.AxisAPMachineCoord.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.AxisAPMachineCoord.Location = New System.Drawing.Point(248, 128)
Me.AxisAPMachineCoord.Name = "AxisAPMachineCoord"
Me.AxisAPMachineCoord.Size = New System.Drawing.Size(160, 13)
Me.AxisAPMachineCoord.TabIndex = 25
Me.AxisAPMachineCoord.Text = "0"
'
'Label15
'
Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label15.Location = New System.Drawing.Point(8, 128)
Me.Label15.Name = "Label15"
Me.Label15.Size = New System.Drawing.Size(208, 16)
Me.Label15.TabIndex = 24
Me.Label15.Text = "Actual Position Machine Coordinates:"
'
'AxisAPEncoderCoord
'
Me.AxisAPEncoderCoord.BackColor = System.Drawing.SystemColors.Control
Me.AxisAPEncoderCoord.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.AxisAPEncoderCoord.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.AxisAPEncoderCoord.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.AxisAPEncoderCoord.Location = New System.Drawing.Point(248, 248)
Me.AxisAPEncoderCoord.Name = "AxisAPEncoderCoord"
Me.AxisAPEncoderCoord.Size = New System.Drawing.Size(160, 13)
Me.AxisAPEncoderCoord.TabIndex = 23
Me.AxisAPEncoderCoord.Text = "0"
'
'Label14
'
Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label14.Location = New System.Drawing.Point(8, 248)
Me.Label14.Name = "Label14"
Me.Label14.Size = New System.Drawing.Size(208, 16)
Me.Label14.TabIndex = 22
Me.Label14.Text = "Actual Position Encoder Coordinates:"
'
'AxisActualFeedrate
'
Me.AxisActualFeedrate.BackColor = System.Drawing.SystemColors.Control
Me.AxisActualFeedrate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.AxisActualFeedrate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.AxisActualFeedrate.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.AxisActualFeedrate.Location = New System.Drawing.Point(584, 168)
Me.AxisActualFeedrate.Name = "AxisActualFeedrate"
Me.AxisActualFeedrate.Size = New System.Drawing.Size(160, 13)
Me.AxisActualFeedrate.TabIndex = 21
Me.AxisActualFeedrate.Text = "0"
'
'Label12
'
Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(255,Byte), CType(192,Byte), CType(128,Byte))
Me.Label12.Location = New System.Drawing.Point(8, 224)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(52, 16)
Me.Label12.TabIndex = 16
Me.Label12.Text = "Axis 2"
'
'axis2Combo
'
Me.axis2Combo.Location = New System.Drawing.Point(72, 224)
Me.axis2Combo.Name = "axis2Combo"
Me.axis2Combo.Size = New System.Drawing.Size(120, 21)
Me.axis2Combo.TabIndex = 15
'
'axis1Combo
'
Me.axis1Combo.Location = New System.Drawing.Point(64, 104)
Me.axis1Combo.Name = "axis1Combo"
Me.axis1Combo.Size = New System.Drawing.Size(120, 21)
Me.axis1Combo.TabIndex = 13
'
'Label10
'
Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label10.Location = New System.Drawing.Point(424, 168)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(96, 16)
Me.Label10.TabIndex = 12
Me.Label10.Text = "Actual FeedRate:"
'
'Panel4
'
Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(255,Byte), CType(192,Byte), CType(128,Byte))
Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel4.Controls.Add(Me.cmb_Currentdataunit)
Me.Panel4.Controls.Add(Me.Label160)
Me.Panel4.Controls.Add(Me.cmb_Currentsubsystem)
Me.Panel4.Controls.Add(Me.Label159)
Me.Panel4.Controls.Add(Me.AxisTimerStop)
Me.Panel4.Controls.Add(Me.axisTimerStart)
Me.Panel4.Location = New System.Drawing.Point(6, 8)
Me.Panel4.Name = "Panel4"
Me.Panel4.Size = New System.Drawing.Size(736, 56)
Me.Panel4.TabIndex = 19
'
'cmb_Currentdataunit
'
Me.cmb_Currentdataunit.Location = New System.Drawing.Point(328, 16)
Me.cmb_Currentdataunit.Name = "cmb_Currentdataunit"
Me.cmb_Currentdataunit.Size = New System.Drawing.Size(120, 21)
Me.cmb_Currentdataunit.TabIndex = 21
'
'Label160
'
Me.Label160.BackColor = System.Drawing.Color.FromArgb(CType(255,Byte), CType(192,Byte), CType(128,Byte))
Me.Label160.Location = New System.Drawing.Point(248, 16)
Me.Label160.Name = "Label160"
Me.Label160.Size = New System.Drawing.Size(72, 24)
Me.Label160.TabIndex = 22
Me.Label160.Text = "Data unit :"
'
'cmb_Currentsubsystem
'
Me.cmb_Currentsubsystem.Location = New System.Drawing.Point(88, 8)
Me.cmb_Currentsubsystem.Name = "cmb_Currentsubsystem"
Me.cmb_Currentsubsystem.Size = New System.Drawing.Size(120, 21)
Me.cmb_Currentsubsystem.TabIndex = 19
'
'Label159
'
Me.Label159.BackColor = System.Drawing.Color.FromArgb(CType(255,Byte), CType(192,Byte), CType(128,Byte))
Me.Label159.Location = New System.Drawing.Point(8, 16)
Me.Label159.Name = "Label159"
Me.Label159.Size = New System.Drawing.Size(88, 40)
Me.Label159.TabIndex = 20
Me.Label159.Text = "Current Subsystem"
'
'AxisTimerStop
'
Me.AxisTimerStop.Location = New System.Drawing.Point(624, 16)
Me.AxisTimerStop.Name = "AxisTimerStop"
Me.AxisTimerStop.Size = New System.Drawing.Size(104, 24)
Me.AxisTimerStop.TabIndex = 50
Me.AxisTimerStop.Text = "Stop"
'
'axisTimerStart
'
Me.axisTimerStart.Location = New System.Drawing.Point(480, 16)
Me.axisTimerStart.Name = "axisTimerStart"
Me.axisTimerStart.Size = New System.Drawing.Size(104, 24)
Me.axisTimerStart.TabIndex = 49
Me.axisTimerStart.Text = "Start"
'
'Label123
'
Me.Label123.BackColor = System.Drawing.Color.FromArgb(CType(255,Byte), CType(192,Byte), CType(128,Byte))
Me.Label123.Location = New System.Drawing.Point(8, 312)
Me.Label123.Name = "Label123"
Me.Label123.Size = New System.Drawing.Size(52, 16)
Me.Label123.TabIndex = 18
Me.Label123.Text = "All Axis"
'
'axisAllCombo
'
Me.axisAllCombo.Location = New System.Drawing.Point(72, 312)
Me.axisAllCombo.Name = "axisAllCombo"
Me.axisAllCombo.Size = New System.Drawing.Size(120, 21)
Me.axisAllCombo.TabIndex = 17
'
'Label11
'
Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(255,Byte), CType(192,Byte), CType(128,Byte))
Me.Label11.Location = New System.Drawing.Point(8, 104)
Me.Label11.Name = "Label11"
Me.Label11.Size = New System.Drawing.Size(40, 16)
Me.Label11.TabIndex = 14
Me.Label11.Text = "Axis 1"
'
'axisUpdateButton
'
Me.axisUpdateButton.Location = New System.Drawing.Point(312, 72)
Me.axisUpdateButton.Name = "axisUpdateButton"
Me.axisUpdateButton.Size = New System.Drawing.Size(104, 24)
Me.axisUpdateButton.TabIndex = 48
Me.axisUpdateButton.Text = "Update"
'
'CATC
'
Me.CATC.Controls.Add(Me.Label305)
Me.CATC.Controls.Add(Me.txtMagazinePosition)
Me.CATC.Controls.Add(Me.txtMagazineNumber)
Me.CATC.Controls.Add(Me.Label304)
Me.CATC.Controls.Add(Me.cmdMagazinePosition)
Me.CATC.Controls.Add(Me.cmdATCSetNextTool)
Me.CATC.Controls.Add(Me.cmdATCSetToolInStation)
Me.CATC.Controls.Add(Me.cmdATCUnRegisterTool)
Me.CATC.Controls.Add(Me.Label315)
Me.CATC.Controls.Add(Me.cboATCReturnMagazine)
Me.CATC.Controls.Add(Me.Label314)
Me.CATC.Controls.Add(Me.cboATCToolSize)
Me.CATC.Controls.Add(Me.Label313)
Me.CATC.Controls.Add(Me.cboATCToolKind)
Me.CATC.Controls.Add(Me.cmdRegisterTool)
Me.CATC.Controls.Add(Me.Label312)
Me.CATC.Controls.Add(Me.txtATCToolNo)
Me.CATC.Controls.Add(Me.Label311)
Me.CATC.Controls.Add(Me.cboATCTurretStation)
Me.CATC.Controls.Add(Me.Label65)
Me.CATC.Controls.Add(Me.atcUpdate)
Me.CATC.Controls.Add(Me.atcResults)
Me.CATC.Controls.Add(Me.txtATCPotNo)
Me.CATC.Controls.Add(Me.Label150)
Me.CATC.Location = New System.Drawing.Point(4, 22)
Me.CATC.Name = "CATC"
Me.CATC.Size = New System.Drawing.Size(776, 446)
Me.CATC.TabIndex = 20
Me.CATC.Text = "ATC"
'
'Label305
'
Me.Label305.Location = New System.Drawing.Point(144, 320)
Me.Label305.Name = "Label305"
Me.Label305.Size = New System.Drawing.Size(112, 17)
Me.Label305.TabIndex = 192
Me.Label305.Text = "Magazine Position:"
'
'txtMagazinePosition
'
Me.txtMagazinePosition.Location = New System.Drawing.Point(144, 344)
Me.txtMagazinePosition.Name = "txtMagazinePosition"
Me.txtMagazinePosition.ReadOnly = true
Me.txtMagazinePosition.Size = New System.Drawing.Size(88, 20)
Me.txtMagazinePosition.TabIndex = 191
Me.txtMagazinePosition.Text = "1"
'
'txtMagazineNumber
'
Me.txtMagazineNumber.Location = New System.Drawing.Point(24, 344)
Me.txtMagazineNumber.Name = "txtMagazineNumber"
Me.txtMagazineNumber.Size = New System.Drawing.Size(88, 20)
Me.txtMagazineNumber.TabIndex = 190
Me.txtMagazineNumber.Text = "1"
'
'Label304
'
Me.Label304.Location = New System.Drawing.Point(24, 320)
Me.Label304.Name = "Label304"
Me.Label304.Size = New System.Drawing.Size(112, 17)
Me.Label304.TabIndex = 189
Me.Label304.Text = "Magazine number:"
'
'cmdMagazinePosition
'
Me.cmdMagazinePosition.Location = New System.Drawing.Point(264, 336)
Me.cmdMagazinePosition.Name = "cmdMagazinePosition"
Me.cmdMagazinePosition.Size = New System.Drawing.Size(120, 28)
Me.cmdMagazinePosition.TabIndex = 188
Me.cmdMagazinePosition.Text = "Get"
'
'cmdATCSetNextTool
'
Me.cmdATCSetNextTool.Location = New System.Drawing.Point(216, 232)
Me.cmdATCSetNextTool.Name = "cmdATCSetNextTool"
Me.cmdATCSetNextTool.Size = New System.Drawing.Size(167, 28)
Me.cmdATCSetNextTool.TabIndex = 186
Me.cmdATCSetNextTool.Text = "Set Next Tool"
'
'cmdATCSetToolInStation
'
Me.cmdATCSetToolInStation.Location = New System.Drawing.Point(20, 229)
Me.cmdATCSetToolInStation.Name = "cmdATCSetToolInStation"
Me.cmdATCSetToolInStation.Size = New System.Drawing.Size(167, 28)
Me.cmdATCSetToolInStation.TabIndex = 185
Me.cmdATCSetToolInStation.Text = "Set Tool In Station"
'
'cmdATCUnRegisterTool
'
Me.cmdATCUnRegisterTool.Location = New System.Drawing.Point(216, 194)
Me.cmdATCUnRegisterTool.Name = "cmdATCUnRegisterTool"
Me.cmdATCUnRegisterTool.Size = New System.Drawing.Size(167, 28)
Me.cmdATCUnRegisterTool.TabIndex = 184
Me.cmdATCUnRegisterTool.Text = "Un-Register Tool:"
'
'Label315
'
Me.Label315.Location = New System.Drawing.Point(320, 111)
Me.Label315.Name = "Label315"
Me.Label315.Size = New System.Drawing.Size(140, 16)
Me.Label315.TabIndex = 183
Me.Label315.Text = "Return Magazine:"
'
'cboATCReturnMagazine
'
Me.cboATCReturnMagazine.Location = New System.Drawing.Point(320, 132)
Me.cboATCReturnMagazine.Name = "cboATCReturnMagazine"
Me.cboATCReturnMagazine.Size = New System.Drawing.Size(140, 21)
Me.cboATCReturnMagazine.TabIndex = 182
'
'Label314
'
Me.Label314.Location = New System.Drawing.Point(173, 111)
Me.Label314.Name = "Label314"
Me.Label314.Size = New System.Drawing.Size(140, 16)
Me.Label314.TabIndex = 181
Me.Label314.Text = "Tool Size:"
'
'cboATCToolSize
'
Me.cboATCToolSize.Location = New System.Drawing.Point(173, 132)
Me.cboATCToolSize.Name = "cboATCToolSize"
Me.cboATCToolSize.Size = New System.Drawing.Size(140, 21)
Me.cboATCToolSize.TabIndex = 180
'
'Label313
'
Me.Label313.Location = New System.Drawing.Point(20, 111)
Me.Label313.Name = "Label313"
Me.Label313.Size = New System.Drawing.Size(140, 16)
Me.Label313.TabIndex = 179
Me.Label313.Text = "Tool Kind:"
'
'cboATCToolKind
'
Me.cboATCToolKind.Location = New System.Drawing.Point(20, 132)
Me.cboATCToolKind.Name = "cboATCToolKind"
Me.cboATCToolKind.Size = New System.Drawing.Size(140, 21)
Me.cboATCToolKind.TabIndex = 178
'
'cmdRegisterTool
'
Me.cmdRegisterTool.Location = New System.Drawing.Point(20, 194)
Me.cmdRegisterTool.Name = "cmdRegisterTool"
Me.cmdRegisterTool.Size = New System.Drawing.Size(167, 28)
Me.cmdRegisterTool.TabIndex = 177
Me.cmdRegisterTool.Text = "Register Tool:"
'
'Label312
'
Me.Label312.Location = New System.Drawing.Point(320, 62)
Me.Label312.Name = "Label312"
Me.Label312.Size = New System.Drawing.Size(140, 17)
Me.Label312.TabIndex = 175
Me.Label312.Text = "Turret Station No."
'
'txtATCToolNo
'
Me.txtATCToolNo.Location = New System.Drawing.Point(173, 83)
Me.txtATCToolNo.Name = "txtATCToolNo"
Me.txtATCToolNo.Size = New System.Drawing.Size(96, 20)
Me.txtATCToolNo.TabIndex = 174
Me.txtATCToolNo.Text = "1"
'
'Label311
'
Me.Label311.Location = New System.Drawing.Point(173, 62)
Me.Label311.Name = "Label311"
Me.Label311.Size = New System.Drawing.Size(80, 17)
Me.Label311.TabIndex = 173
Me.Label311.Text = "Tool No. :"
'
'cboATCTurretStation
'
Me.cboATCTurretStation.Location = New System.Drawing.Point(320, 83)
Me.cboATCTurretStation.Name = "cboATCTurretStation"
Me.cboATCTurretStation.Size = New System.Drawing.Size(140, 21)
Me.cboATCTurretStation.TabIndex = 172
'
'Label65
'
Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label65.ForeColor = System.Drawing.Color.Red
Me.Label65.Location = New System.Drawing.Point(16, 8)
Me.Label65.Name = "Label65"
Me.Label65.Size = New System.Drawing.Size(744, 40)
Me.Label65.TabIndex = 171
Me.Label65.Text = "For Lathe machine that has ATC only."
'
'atcUpdate
'
Me.atcUpdate.Location = New System.Drawing.Point(513, 55)
Me.atcUpdate.Name = "atcUpdate"
Me.atcUpdate.Size = New System.Drawing.Size(107, 25)
Me.atcUpdate.TabIndex = 170
Me.atcUpdate.Text = "Update"
'
'atcResults
'
Me.atcResults.Location = New System.Drawing.Point(513, 83)
Me.atcResults.Multiline = true
Me.atcResults.Name = "atcResults"
Me.atcResults.Size = New System.Drawing.Size(240, 347)
Me.atcResults.TabIndex = 169
Me.atcResults.Text = "0"
'
'txtATCPotNo
'
Me.txtATCPotNo.Location = New System.Drawing.Point(20, 83)
Me.txtATCPotNo.Name = "txtATCPotNo"
Me.txtATCPotNo.Size = New System.Drawing.Size(96, 20)
Me.txtATCPotNo.TabIndex = 168
Me.txtATCPotNo.Text = "1"
'
'Label150
'
Me.Label150.Location = New System.Drawing.Point(20, 62)
Me.Label150.Name = "Label150"
Me.Label150.Size = New System.Drawing.Size(80, 17)
Me.Label150.TabIndex = 167
Me.Label150.Text = "Pot Number :"
'
'tab_Program2
'
Me.tab_Program2.Controls.Add(Me.GroupBox18)
Me.tab_Program2.Location = New System.Drawing.Point(4, 22)
Me.tab_Program2.Name = "tab_Program2"
Me.tab_Program2.Size = New System.Drawing.Size(776, 446)
Me.tab_Program2.TabIndex = 30
Me.tab_Program2.Text = "Program - 2"
'
'GroupBox18
'
Me.GroupBox18.Controls.Add(Me.txtProgram2_OrderNumber)
Me.GroupBox18.Controls.Add(Me.Label310)
Me.GroupBox18.Controls.Add(Me.Label309)
Me.GroupBox18.Controls.Add(Me.txtProgram2_Sequence)
Me.GroupBox18.Controls.Add(Me.cmdProgram2_SequenceRestart)
Me.GroupBox18.Location = New System.Drawing.Point(8, 8)
Me.GroupBox18.Name = "GroupBox18"
Me.GroupBox18.Size = New System.Drawing.Size(472, 56)
Me.GroupBox18.TabIndex = 0
Me.GroupBox18.TabStop = false
'
'txtProgram2_OrderNumber
'
Me.txtProgram2_OrderNumber.Location = New System.Drawing.Point(256, 16)
Me.txtProgram2_OrderNumber.Name = "txtProgram2_OrderNumber"
Me.txtProgram2_OrderNumber.Size = New System.Drawing.Size(72, 20)
Me.txtProgram2_OrderNumber.TabIndex = 4
Me.txtProgram2_OrderNumber.Text = "1"
'
'Label310
'
Me.Label310.Location = New System.Drawing.Point(160, 16)
Me.Label310.Name = "Label310"
Me.Label310.Size = New System.Drawing.Size(80, 24)
Me.Label310.TabIndex = 3
Me.Label310.Text = "Order Number"
'
'Label309
'
Me.Label309.Location = New System.Drawing.Point(8, 16)
Me.Label309.Name = "Label309"
Me.Label309.Size = New System.Drawing.Size(64, 16)
Me.Label309.TabIndex = 2
Me.Label309.Text = "Sequence"
'
'txtProgram2_Sequence
'
Me.txtProgram2_Sequence.Location = New System.Drawing.Point(80, 16)
Me.txtProgram2_Sequence.Name = "txtProgram2_Sequence"
Me.txtProgram2_Sequence.Size = New System.Drawing.Size(72, 20)
Me.txtProgram2_Sequence.TabIndex = 1
Me.txtProgram2_Sequence.Text = "1"
'
'cmdProgram2_SequenceRestart
'
Me.cmdProgram2_SequenceRestart.Location = New System.Drawing.Point(344, 16)
Me.cmdProgram2_SequenceRestart.Name = "cmdProgram2_SequenceRestart"
Me.cmdProgram2_SequenceRestart.Size = New System.Drawing.Size(120, 32)
Me.cmdProgram2_SequenceRestart.TabIndex = 0
Me.cmdProgram2_SequenceRestart.Text = "Sequence Restart"
'
'tab_program
'
Me.tab_program.Controls.Add(Me.cmdSelectScheduleProgram)
Me.tab_program.Controls.Add(Me.cmdSelectScheduleProgramRSide)
Me.tab_program.Controls.Add(Me.cmdSelectScheduleProgramLSide)
Me.tab_program.Controls.Add(Me.cmdSelectProgramRSide)
Me.tab_program.Controls.Add(Me.cmdSelectProgramLSide)
Me.tab_program.Controls.Add(Me.cmdProgramSubSystem)
Me.tab_program.Controls.Add(Me.GroupBox1)
Me.tab_program.Controls.Add(Me.cmb_Program_SubSys)
Me.tab_program.Controls.Add(Me.progCancelProgramButton)
Me.tab_program.Controls.Add(Me.progSelectProgramButton)
Me.tab_program.Controls.Add(Me.Label146)
Me.tab_program.Controls.Add(Me.prog4)
Me.tab_program.Controls.Add(Me.prog3)
Me.tab_program.Controls.Add(Me.Label147)
Me.tab_program.Controls.Add(Me.prog2)
Me.tab_program.Controls.Add(Me.Label148)
Me.tab_program.Controls.Add(Me.prog1)
Me.tab_program.Controls.Add(Me.Label149)
Me.tab_program.Controls.Add(Me.progGetMCodes)
Me.tab_program.Controls.Add(Me.Label59)
Me.tab_program.Controls.Add(Me.progRead)
Me.tab_program.Controls.Add(Me.Label60)
Me.tab_program.Controls.Add(Me.progColumn)
Me.tab_program.Controls.Add(Me.progRow)
Me.tab_program.Controls.Add(Me.Label62)
Me.tab_program.Controls.Add(Me.Label58)
Me.tab_program.Controls.Add(Me.progMCodes)
Me.tab_program.Controls.Add(Me.label99)
Me.tab_program.Controls.Add(Me.progMCodesCombo)
Me.tab_program.Controls.Add(Me.Label57)
Me.tab_program.Controls.Add(Me.progUpdateButton)
Me.tab_program.Controls.Add(Me.progNoParams)
Me.tab_program.Controls.Add(Me.Panel7)
Me.tab_program.Controls.Add(Me.Panel8)
Me.tab_program.Location = New System.Drawing.Point(4, 22)
Me.tab_program.Name = "tab_program"
Me.tab_program.Size = New System.Drawing.Size(776, 446)
Me.tab_program.TabIndex = 6
Me.tab_program.Text = "Program"
'
'cmdSelectScheduleProgram
'
Me.cmdSelectScheduleProgram.Location = New System.Drawing.Point(424, 376)
Me.cmdSelectScheduleProgram.Name = "cmdSelectScheduleProgram"
Me.cmdSelectScheduleProgram.Size = New System.Drawing.Size(160, 24)
Me.cmdSelectScheduleProgram.TabIndex = 106
Me.cmdSelectScheduleProgram.Text = "Select Schedule Program"
'
'cmdSelectScheduleProgramRSide
'
Me.cmdSelectScheduleProgramRSide.Location = New System.Drawing.Point(592, 408)
Me.cmdSelectScheduleProgramRSide.Name = "cmdSelectScheduleProgramRSide"
Me.cmdSelectScheduleProgramRSide.Size = New System.Drawing.Size(160, 32)
Me.cmdSelectScheduleProgramRSide.TabIndex = 105
Me.cmdSelectScheduleProgramRSide.Text = "Select Schedule Program For  R Side"
'
'cmdSelectScheduleProgramLSide
'
Me.cmdSelectScheduleProgramLSide.Location = New System.Drawing.Point(424, 408)
Me.cmdSelectScheduleProgramLSide.Name = "cmdSelectScheduleProgramLSide"
Me.cmdSelectScheduleProgramLSide.Size = New System.Drawing.Size(160, 32)
Me.cmdSelectScheduleProgramLSide.TabIndex = 104
Me.cmdSelectScheduleProgramLSide.Text = "Select Schedule Program For L Side"
'
'cmdSelectProgramRSide
'
Me.cmdSelectProgramRSide.Location = New System.Drawing.Point(592, 344)
Me.cmdSelectProgramRSide.Name = "cmdSelectProgramRSide"
Me.cmdSelectProgramRSide.Size = New System.Drawing.Size(160, 24)
Me.cmdSelectProgramRSide.TabIndex = 103
Me.cmdSelectProgramRSide.Text = "Select Program For  R Side"
'
'cmdSelectProgramLSide
'
Me.cmdSelectProgramLSide.Location = New System.Drawing.Point(424, 344)
Me.cmdSelectProgramLSide.Name = "cmdSelectProgramLSide"
Me.cmdSelectProgramLSide.Size = New System.Drawing.Size(160, 24)
Me.cmdSelectProgramLSide.TabIndex = 102
Me.cmdSelectProgramLSide.Text = "Select Program For L Side"
'
'cmdProgramSubSystem
'
Me.cmdProgramSubSystem.Location = New System.Drawing.Point(432, 8)
Me.cmdProgramSubSystem.Name = "cmdProgramSubSystem"
Me.cmdProgramSubSystem.Size = New System.Drawing.Size(184, 24)
Me.cmdProgramSubSystem.TabIndex = 101
Me.cmdProgramSubSystem.Text = "Sub System"
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.TxtCycleComplte)
Me.GroupBox1.Controls.Add(Me.Label253)
Me.GroupBox1.Controls.Add(Me.TxtProgrameCycleComplete)
Me.GroupBox1.Controls.Add(Me.Label254)
Me.GroupBox1.Controls.Add(Me.progButtonCycleStatus)
Me.GroupBox1.Controls.Add(Me.cboCycleCompleteCombo)
Me.GroupBox1.Controls.Add(Me.ScheduleProgramCycleCompleteCombo)
Me.GroupBox1.Controls.Add(Me.Label230)
Me.GroupBox1.Controls.Add(Me.ScheduleProgramCycleComplete)
Me.GroupBox1.Location = New System.Drawing.Point(8, 320)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(408, 120)
Me.GroupBox1.TabIndex = 100
Me.GroupBox1.TabStop = false
'
'TxtCycleComplte
'
Me.TxtCycleComplte.Location = New System.Drawing.Point(192, 88)
Me.TxtCycleComplte.Name = "TxtCycleComplte"
Me.TxtCycleComplte.Size = New System.Drawing.Size(112, 20)
Me.TxtCycleComplte.TabIndex = 104
Me.TxtCycleComplte.Text = ""
'
'Label253
'
Me.Label253.Location = New System.Drawing.Point(8, 88)
Me.Label253.Name = "Label253"
Me.Label253.Size = New System.Drawing.Size(98, 16)
Me.Label253.TabIndex = 103
Me.Label253.Text = "CycleComplete"
'
'TxtProgrameCycleComplete
'
Me.TxtProgrameCycleComplete.Location = New System.Drawing.Point(192, 64)
Me.TxtProgrameCycleComplete.Name = "TxtProgrameCycleComplete"
Me.TxtProgrameCycleComplete.Size = New System.Drawing.Size(112, 20)
Me.TxtProgrameCycleComplete.TabIndex = 102
Me.TxtProgrameCycleComplete.Text = ""
'
'Label254
'
Me.Label254.Location = New System.Drawing.Point(8, 64)
Me.Label254.Name = "Label254"
Me.Label254.Size = New System.Drawing.Size(176, 16)
Me.Label254.TabIndex = 101
Me.Label254.Text = "ScheduleProgramCycleComplete"
'
'progButtonCycleStatus
'
Me.progButtonCycleStatus.Location = New System.Drawing.Point(312, 88)
Me.progButtonCycleStatus.Name = "progButtonCycleStatus"
Me.progButtonCycleStatus.Size = New System.Drawing.Size(88, 24)
Me.progButtonCycleStatus.TabIndex = 96
Me.progButtonCycleStatus.Text = "CycleStatus"
'
'cboCycleCompleteCombo
'
Me.cboCycleCompleteCombo.Location = New System.Drawing.Point(192, 40)
Me.cboCycleCompleteCombo.Name = "cboCycleCompleteCombo"
Me.cboCycleCompleteCombo.Size = New System.Drawing.Size(208, 21)
Me.cboCycleCompleteCombo.TabIndex = 95
'
'ScheduleProgramCycleCompleteCombo
'
Me.ScheduleProgramCycleCompleteCombo.Location = New System.Drawing.Point(192, 16)
Me.ScheduleProgramCycleCompleteCombo.Name = "ScheduleProgramCycleCompleteCombo"
Me.ScheduleProgramCycleCompleteCombo.Size = New System.Drawing.Size(208, 21)
Me.ScheduleProgramCycleCompleteCombo.TabIndex = 94
'
'Label230
'
Me.Label230.Location = New System.Drawing.Point(8, 40)
Me.Label230.Name = "Label230"
Me.Label230.Size = New System.Drawing.Size(160, 16)
Me.Label230.TabIndex = 93
Me.Label230.Text = "CycleComplete"
'
'ScheduleProgramCycleComplete
'
Me.ScheduleProgramCycleComplete.Location = New System.Drawing.Point(8, 16)
Me.ScheduleProgramCycleComplete.Name = "ScheduleProgramCycleComplete"
Me.ScheduleProgramCycleComplete.Size = New System.Drawing.Size(176, 16)
Me.ScheduleProgramCycleComplete.TabIndex = 92
Me.ScheduleProgramCycleComplete.Text = "ScheduleProgramCycleComplete"
'
'cmb_Program_SubSys
'
Me.cmb_Program_SubSys.ItemHeight = 13
Me.cmb_Program_SubSys.Location = New System.Drawing.Point(632, 8)
Me.cmb_Program_SubSys.Name = "cmb_Program_SubSys"
Me.cmb_Program_SubSys.Size = New System.Drawing.Size(121, 21)
Me.cmb_Program_SubSys.TabIndex = 99
'
'progCancelProgramButton
'
Me.progCancelProgramButton.Location = New System.Drawing.Point(592, 312)
Me.progCancelProgramButton.Name = "progCancelProgramButton"
Me.progCancelProgramButton.Size = New System.Drawing.Size(160, 24)
Me.progCancelProgramButton.TabIndex = 97
Me.progCancelProgramButton.Text = "Cancel Program"
'
'progSelectProgramButton
'
Me.progSelectProgramButton.Location = New System.Drawing.Point(424, 312)
Me.progSelectProgramButton.Name = "progSelectProgramButton"
Me.progSelectProgramButton.Size = New System.Drawing.Size(160, 24)
Me.progSelectProgramButton.TabIndex = 96
Me.progSelectProgramButton.Text = "Select Program"
'
'Label146
'
Me.Label146.Location = New System.Drawing.Point(432, 280)
Me.Label146.Name = "Label146"
Me.Label146.Size = New System.Drawing.Size(136, 16)
Me.Label146.TabIndex = 95
Me.Label146.Text = "Program Name"
'
'prog4
'
Me.prog4.Location = New System.Drawing.Point(576, 280)
Me.prog4.Name = "prog4"
Me.prog4.Size = New System.Drawing.Size(176, 20)
Me.prog4.TabIndex = 94
Me.prog4.Text = "0"
'
'prog3
'
Me.prog3.Location = New System.Drawing.Point(576, 256)
Me.prog3.Name = "prog3"
Me.prog3.Size = New System.Drawing.Size(176, 20)
Me.prog3.TabIndex = 93
Me.prog3.Text = "0"
'
'Label147
'
Me.Label147.Location = New System.Drawing.Point(432, 256)
Me.Label147.Name = "Label147"
Me.Label147.Size = New System.Drawing.Size(136, 16)
Me.Label147.TabIndex = 92
Me.Label147.Text = "System Sub FileName"
'
'prog2
'
Me.prog2.Location = New System.Drawing.Point(576, 232)
Me.prog2.Name = "prog2"
Me.prog2.Size = New System.Drawing.Size(176, 20)
Me.prog2.TabIndex = 90
Me.prog2.Text = "0"
'
'Label148
'
Me.Label148.Location = New System.Drawing.Point(432, 208)
Me.Label148.Name = "Label148"
Me.Label148.Size = New System.Drawing.Size(136, 16)
Me.Label148.TabIndex = 91
Me.Label148.Text = "Program FileName"
'
'prog1
'
Me.prog1.Location = New System.Drawing.Point(576, 208)
Me.prog1.Name = "prog1"
Me.prog1.Size = New System.Drawing.Size(176, 20)
Me.prog1.TabIndex = 89
Me.prog1.Text = "0"
'
'Label149
'
Me.Label149.Location = New System.Drawing.Point(432, 232)
Me.Label149.Name = "Label149"
Me.Label149.Size = New System.Drawing.Size(136, 16)
Me.Label149.TabIndex = 88
Me.Label149.Text = "SubProgram FileName"
'
'progGetMCodes
'
Me.progGetMCodes.Location = New System.Drawing.Point(280, 56)
Me.progGetMCodes.Name = "progGetMCodes"
Me.progGetMCodes.Size = New System.Drawing.Size(128, 24)
Me.progGetMCodes.TabIndex = 77
Me.progGetMCodes.Text = "Get M Codes"
'
'Label59
'
Me.Label59.Location = New System.Drawing.Point(24, 176)
Me.Label59.Name = "Label59"
Me.Label59.Size = New System.Drawing.Size(136, 16)
Me.Label59.TabIndex = 75
Me.Label59.Text = "Execute Point (Int)"
'
'progRead
'
Me.progRead.Location = New System.Drawing.Point(168, 152)
Me.progRead.Name = "progRead"
Me.progRead.Size = New System.Drawing.Size(64, 20)
Me.progRead.TabIndex = 73
Me.progRead.Text = "0"
'
'Label60
'
Me.Label60.Location = New System.Drawing.Point(24, 128)
Me.Label60.Name = "Label60"
Me.Label60.Size = New System.Drawing.Size(136, 16)
Me.Label60.TabIndex = 74
Me.Label60.Text = "Column (int)"
'
'progColumn
'
Me.progColumn.Location = New System.Drawing.Point(168, 128)
Me.progColumn.Name = "progColumn"
Me.progColumn.Size = New System.Drawing.Size(64, 20)
Me.progColumn.TabIndex = 71
Me.progColumn.Text = "79"
'
'progRow
'
Me.progRow.Location = New System.Drawing.Point(168, 104)
Me.progRow.Name = "progRow"
Me.progRow.Size = New System.Drawing.Size(64, 20)
Me.progRow.TabIndex = 69
Me.progRow.Text = "10"
'
'Label62
'
Me.Label62.Location = New System.Drawing.Point(24, 152)
Me.Label62.Name = "Label62"
Me.Label62.Size = New System.Drawing.Size(136, 16)
Me.Label62.TabIndex = 70
Me.Label62.Text = "Read Point (int)"
'
'Label58
'
Me.Label58.BackColor = System.Drawing.SystemColors.Control
Me.Label58.Location = New System.Drawing.Point(40, 56)
Me.Label58.Name = "Label58"
Me.Label58.Size = New System.Drawing.Size(88, 16)
Me.Label58.TabIndex = 61
Me.Label58.Text = "M Codes :"
'
'progMCodes
'
Me.progMCodes.Location = New System.Drawing.Point(144, 56)
Me.progMCodes.Name = "progMCodes"
Me.progMCodes.Size = New System.Drawing.Size(120, 20)
Me.progMCodes.TabIndex = 60
Me.progMCodes.Text = ""
'
'label99
'
Me.label99.BackColor = System.Drawing.SystemColors.Control
Me.label99.Location = New System.Drawing.Point(40, 24)
Me.label99.Name = "label99"
Me.label99.Size = New System.Drawing.Size(88, 16)
Me.label99.TabIndex = 58
Me.label99.Text = "M Codes Type :"
'
'progMCodesCombo
'
Me.progMCodesCombo.Location = New System.Drawing.Point(144, 24)
Me.progMCodesCombo.Name = "progMCodesCombo"
Me.progMCodesCombo.Size = New System.Drawing.Size(168, 21)
Me.progMCodesCombo.TabIndex = 57
'
'Label57
'
Me.Label57.Location = New System.Drawing.Point(440, 176)
Me.Label57.Name = "Label57"
Me.Label57.Size = New System.Drawing.Size(152, 24)
Me.Label57.TabIndex = 16
Me.Label57.Text = "Values with no parameters :"
Me.Label57.TextAlign = System.Drawing.ContentAlignment.TopRight
'
'progUpdateButton
'
Me.progUpdateButton.Location = New System.Drawing.Point(680, 176)
Me.progUpdateButton.Name = "progUpdateButton"
Me.progUpdateButton.Size = New System.Drawing.Size(72, 24)
Me.progUpdateButton.TabIndex = 15
Me.progUpdateButton.Text = "Update"
'
'progNoParams
'
Me.progNoParams.Location = New System.Drawing.Point(432, 40)
Me.progNoParams.Multiline = true
Me.progNoParams.Name = "progNoParams"
Me.progNoParams.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.progNoParams.Size = New System.Drawing.Size(320, 128)
Me.progNoParams.TabIndex = 14
Me.progNoParams.Text = ""
'
'Panel7
'
Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel7.Location = New System.Drawing.Point(8, 8)
Me.Panel7.Name = "Panel7"
Me.Panel7.Size = New System.Drawing.Size(408, 80)
Me.Panel7.TabIndex = 78
'
'Panel8
'
Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel8.Controls.Add(Me.TxtRunningPrograme)
Me.Panel8.Controls.Add(Me.Label249)
Me.Panel8.Controls.Add(Me.progButtonGetRunProgram)
Me.Panel8.Controls.Add(Me.progRunningPrograms)
Me.Panel8.Controls.Add(Me.Label61)
Me.Panel8.Controls.Add(Me.progExecutePoint)
Me.Panel8.Location = New System.Drawing.Point(8, 96)
Me.Panel8.Name = "Panel8"
Me.Panel8.Size = New System.Drawing.Size(408, 224)
Me.Panel8.TabIndex = 79
'
'TxtRunningPrograme
'
Me.TxtRunningPrograme.Location = New System.Drawing.Point(160, 104)
Me.TxtRunningPrograme.Name = "TxtRunningPrograme"
Me.TxtRunningPrograme.Size = New System.Drawing.Size(64, 20)
Me.TxtRunningPrograme.TabIndex = 82
Me.TxtRunningPrograme.Text = ""
'
'Label249
'
Me.Label249.Location = New System.Drawing.Point(16, 103)
Me.Label249.Name = "Label249"
Me.Label249.Size = New System.Drawing.Size(136, 16)
Me.Label249.TabIndex = 81
Me.Label249.Text = "Programe Name"
'
'progButtonGetRunProgram
'
Me.progButtonGetRunProgram.Location = New System.Drawing.Point(240, 80)
Me.progButtonGetRunProgram.Name = "progButtonGetRunProgram"
Me.progButtonGetRunProgram.Size = New System.Drawing.Size(128, 24)
Me.progButtonGetRunProgram.TabIndex = 78
Me.progButtonGetRunProgram.Text = "Get Running Program"
'
'progRunningPrograms
'
Me.progRunningPrograms.Location = New System.Drawing.Point(8, 136)
Me.progRunningPrograms.Multiline = true
Me.progRunningPrograms.Name = "progRunningPrograms"
Me.progRunningPrograms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.progRunningPrograms.Size = New System.Drawing.Size(384, 80)
Me.progRunningPrograms.TabIndex = 80
Me.progRunningPrograms.Text = ""
'
'Label61
'
Me.Label61.Location = New System.Drawing.Point(16, 8)
Me.Label61.Name = "Label61"
Me.Label61.Size = New System.Drawing.Size(136, 16)
Me.Label61.TabIndex = 72
Me.Label61.Text = "Row (int)"
'
'progExecutePoint
'
Me.progExecutePoint.Location = New System.Drawing.Point(160, 80)
Me.progExecutePoint.Name = "progExecutePoint"
Me.progExecutePoint.Size = New System.Drawing.Size(64, 20)
Me.progExecutePoint.TabIndex = 76
Me.progExecutePoint.Text = "0"
'
'tab_MacmanOperatingReport
'
Me.tab_MacmanOperatingReport.Controls.Add(Me.morMaxNoOfOpReport)
Me.tab_MacmanOperatingReport.Controls.Add(Me.Label288)
Me.tab_MacmanOperatingReport.Controls.Add(Me.morUpdateButton)
Me.tab_MacmanOperatingReport.Controls.Add(Me.morOperatingStatus)
Me.tab_MacmanOperatingReport.Controls.Add(Me.Label289)
Me.tab_MacmanOperatingReport.Controls.Add(Me.morNonoperatingCondition)
Me.tab_MacmanOperatingReport.Controls.Add(Me.Label290)
Me.tab_MacmanOperatingReport.Controls.Add(Me.GroupBox6)
Me.tab_MacmanOperatingReport.Controls.Add(Me.GroupBox2)
Me.tab_MacmanOperatingReport.Controls.Add(Me.GroupBox3)
Me.tab_MacmanOperatingReport.Controls.Add(Me.McORSubSystemCombo)
Me.tab_MacmanOperatingReport.Controls.Add(Me.Label241)
Me.tab_MacmanOperatingReport.Location = New System.Drawing.Point(4, 22)
Me.tab_MacmanOperatingReport.Name = "tab_MacmanOperatingReport"
Me.tab_MacmanOperatingReport.Size = New System.Drawing.Size(776, 446)
Me.tab_MacmanOperatingReport.TabIndex = 13
Me.tab_MacmanOperatingReport.Text = "MacMan Operating Report"
'
'morMaxNoOfOpReport
'
Me.morMaxNoOfOpReport.Location = New System.Drawing.Point(664, 48)
Me.morMaxNoOfOpReport.Name = "morMaxNoOfOpReport"
Me.morMaxNoOfOpReport.Size = New System.Drawing.Size(96, 20)
Me.morMaxNoOfOpReport.TabIndex = 311
Me.morMaxNoOfOpReport.Text = "0"
'
'Label288
'
Me.Label288.Location = New System.Drawing.Point(488, 48)
Me.Label288.Name = "Label288"
Me.Label288.Size = New System.Drawing.Size(168, 24)
Me.Label288.TabIndex = 310
Me.Label288.Text = "Maximum no of operating report"
'
'morUpdateButton
'
Me.morUpdateButton.Location = New System.Drawing.Point(440, 8)
Me.morUpdateButton.Name = "morUpdateButton"
Me.morUpdateButton.Size = New System.Drawing.Size(88, 24)
Me.morUpdateButton.TabIndex = 309
Me.morUpdateButton.Text = "Update"
'
'morOperatingStatus
'
Me.morOperatingStatus.Location = New System.Drawing.Point(376, 48)
Me.morOperatingStatus.Name = "morOperatingStatus"
Me.morOperatingStatus.Size = New System.Drawing.Size(80, 20)
Me.morOperatingStatus.TabIndex = 308
Me.morOperatingStatus.Text = "0"
'
'Label289
'
Me.Label289.Location = New System.Drawing.Point(272, 48)
Me.Label289.Name = "Label289"
Me.Label289.Size = New System.Drawing.Size(96, 24)
Me.Label289.TabIndex = 307
Me.Label289.Text = "Operating Status :"
'
'morNonoperatingCondition
'
Me.morNonoperatingCondition.Location = New System.Drawing.Point(152, 48)
Me.morNonoperatingCondition.Name = "morNonoperatingCondition"
Me.morNonoperatingCondition.Size = New System.Drawing.Size(96, 20)
Me.morNonoperatingCondition.TabIndex = 306
Me.morNonoperatingCondition.Text = "0"
'
'Label290
'
Me.Label290.Location = New System.Drawing.Point(16, 48)
Me.Label290.Name = "Label290"
Me.Label290.Size = New System.Drawing.Size(136, 16)
Me.Label290.TabIndex = 305
Me.Label290.Text = "Non Operating Condition :"
'
'GroupBox6
'
Me.GroupBox6.Controls.Add(Me.Label145)
Me.GroupBox6.Controls.Add(Me.morPrevExternalInputTime)
Me.GroupBox6.Controls.Add(Me.morPrevDateOfOperatingRept)
Me.GroupBox6.Controls.Add(Me.morPrevAlarmOnTime)
Me.GroupBox6.Controls.Add(Me.morPrevSpindleRunTime)
Me.GroupBox6.Controls.Add(Me.morPrevOtherTime)
Me.GroupBox6.Controls.Add(Me.morPrevMaintenanceTime)
Me.GroupBox6.Controls.Add(Me.morPrevPartwaitingTime)
Me.GroupBox6.Controls.Add(Me.morPrevNoOperatorTime)
Me.GroupBox6.Controls.Add(Me.morPrevInProSetupTime)
Me.GroupBox6.Controls.Add(Me.morPrevNonOperatingTime)
Me.GroupBox6.Controls.Add(Me.morPrevCuttingTime)
Me.GroupBox6.Controls.Add(Me.morPrevRunningTime)
Me.GroupBox6.Controls.Add(Me.Label276)
Me.GroupBox6.Controls.Add(Me.Label277)
Me.GroupBox6.Controls.Add(Me.Label278)
Me.GroupBox6.Controls.Add(Me.Label279)
Me.GroupBox6.Controls.Add(Me.Label280)
Me.GroupBox6.Controls.Add(Me.Label281)
Me.GroupBox6.Controls.Add(Me.Label282)
Me.GroupBox6.Controls.Add(Me.Label283)
Me.GroupBox6.Controls.Add(Me.Label284)
Me.GroupBox6.Controls.Add(Me.Label285)
Me.GroupBox6.Controls.Add(Me.Label286)
Me.GroupBox6.Controls.Add(Me.Label287)
Me.GroupBox6.Controls.Add(Me.morPrevOperatingTime)
Me.GroupBox6.Location = New System.Drawing.Point(520, 80)
Me.GroupBox6.Name = "GroupBox6"
Me.GroupBox6.Size = New System.Drawing.Size(240, 352)
Me.GroupBox6.TabIndex = 304
Me.GroupBox6.TabStop = false
Me.GroupBox6.Text = "Previous Day Operating Report"
'
'Label145
'
Me.Label145.Location = New System.Drawing.Point(8, 264)
Me.Label145.Name = "Label145"
Me.Label145.Size = New System.Drawing.Size(104, 23)
Me.Label145.TabIndex = 219
Me.Label145.Text = "External Input Time"
'
'morPrevExternalInputTime
'
Me.morPrevExternalInputTime.Location = New System.Drawing.Point(136, 256)
Me.morPrevExternalInputTime.Name = "morPrevExternalInputTime"
Me.morPrevExternalInputTime.TabIndex = 220
Me.morPrevExternalInputTime.Text = "0"
'
'morPrevDateOfOperatingRept
'
Me.morPrevDateOfOperatingRept.Location = New System.Drawing.Point(136, 304)
Me.morPrevDateOfOperatingRept.Name = "morPrevDateOfOperatingRept"
Me.morPrevDateOfOperatingRept.TabIndex = 218
Me.morPrevDateOfOperatingRept.Text = "0"
'
'morPrevAlarmOnTime
'
Me.morPrevAlarmOnTime.Location = New System.Drawing.Point(136, 280)
Me.morPrevAlarmOnTime.Name = "morPrevAlarmOnTime"
Me.morPrevAlarmOnTime.TabIndex = 217
Me.morPrevAlarmOnTime.Text = "0"
'
'morPrevSpindleRunTime
'
Me.morPrevSpindleRunTime.Location = New System.Drawing.Point(136, 232)
Me.morPrevSpindleRunTime.Name = "morPrevSpindleRunTime"
Me.morPrevSpindleRunTime.TabIndex = 216
Me.morPrevSpindleRunTime.Text = "0"
'
'morPrevOtherTime
'
Me.morPrevOtherTime.Location = New System.Drawing.Point(136, 208)
Me.morPrevOtherTime.Name = "morPrevOtherTime"
Me.morPrevOtherTime.TabIndex = 215
Me.morPrevOtherTime.Text = "0"
'
'morPrevMaintenanceTime
'
Me.morPrevMaintenanceTime.Location = New System.Drawing.Point(136, 184)
Me.morPrevMaintenanceTime.Name = "morPrevMaintenanceTime"
Me.morPrevMaintenanceTime.TabIndex = 214
Me.morPrevMaintenanceTime.Text = "0"
'
'morPrevPartwaitingTime
'
Me.morPrevPartwaitingTime.Location = New System.Drawing.Point(136, 160)
Me.morPrevPartwaitingTime.Name = "morPrevPartwaitingTime"
Me.morPrevPartwaitingTime.TabIndex = 213
Me.morPrevPartwaitingTime.Text = "0"
'
'morPrevNoOperatorTime
'
Me.morPrevNoOperatorTime.Location = New System.Drawing.Point(136, 136)
Me.morPrevNoOperatorTime.Name = "morPrevNoOperatorTime"
Me.morPrevNoOperatorTime.TabIndex = 212
Me.morPrevNoOperatorTime.Text = "0"
'
'morPrevInProSetupTime
'
Me.morPrevInProSetupTime.Location = New System.Drawing.Point(136, 112)
Me.morPrevInProSetupTime.Name = "morPrevInProSetupTime"
Me.morPrevInProSetupTime.TabIndex = 211
Me.morPrevInProSetupTime.Text = "0"
'
'morPrevNonOperatingTime
'
Me.morPrevNonOperatingTime.Location = New System.Drawing.Point(136, 88)
Me.morPrevNonOperatingTime.Name = "morPrevNonOperatingTime"
Me.morPrevNonOperatingTime.TabIndex = 210
Me.morPrevNonOperatingTime.Text = "0"
'
'morPrevCuttingTime
'
Me.morPrevCuttingTime.Location = New System.Drawing.Point(136, 64)
Me.morPrevCuttingTime.Name = "morPrevCuttingTime"
Me.morPrevCuttingTime.TabIndex = 209
Me.morPrevCuttingTime.Text = "0"
'
'morPrevRunningTime
'
Me.morPrevRunningTime.Location = New System.Drawing.Point(136, 40)
Me.morPrevRunningTime.Name = "morPrevRunningTime"
Me.morPrevRunningTime.TabIndex = 208
Me.morPrevRunningTime.Text = "0"
'
'Label276
'
Me.Label276.Location = New System.Drawing.Point(8, 16)
Me.Label276.Name = "Label276"
Me.Label276.Size = New System.Drawing.Size(88, 23)
Me.Label276.TabIndex = 203
Me.Label276.Text = "Operating Time"
'
'Label277
'
Me.Label277.Location = New System.Drawing.Point(8, 40)
Me.Label277.Name = "Label277"
Me.Label277.TabIndex = 203
Me.Label277.Text = "Runing Time"
'
'Label278
'
Me.Label278.Location = New System.Drawing.Point(8, 64)
Me.Label278.Name = "Label278"
Me.Label278.TabIndex = 203
Me.Label278.Text = "Cutting Time"
'
'Label279
'
Me.Label279.Location = New System.Drawing.Point(8, 88)
Me.Label279.Name = "Label279"
Me.Label279.Size = New System.Drawing.Size(120, 23)
Me.Label279.TabIndex = 203
Me.Label279.Text = "Non Operating Time"
'
'Label280
'
Me.Label280.Location = New System.Drawing.Point(8, 112)
Me.Label280.Name = "Label280"
Me.Label280.TabIndex = 203
Me.Label280.Text = "In Pro Setup Time"
'
'Label281
'
Me.Label281.Location = New System.Drawing.Point(8, 136)
Me.Label281.Name = "Label281"
Me.Label281.TabIndex = 203
Me.Label281.Text = "No Operator Time"
'
'Label282
'
Me.Label282.Location = New System.Drawing.Point(8, 160)
Me.Label282.Name = "Label282"
Me.Label282.TabIndex = 203
Me.Label282.Text = "Part waiting Time"
'
'Label283
'
Me.Label283.Location = New System.Drawing.Point(8, 192)
Me.Label283.Name = "Label283"
Me.Label283.TabIndex = 203
Me.Label283.Text = "Maintenance Time"
'
'Label284
'
Me.Label284.Location = New System.Drawing.Point(8, 216)
Me.Label284.Name = "Label284"
Me.Label284.TabIndex = 203
Me.Label284.Text = "Other Time"
'
'Label285
'
Me.Label285.Location = New System.Drawing.Point(8, 240)
Me.Label285.Name = "Label285"
Me.Label285.TabIndex = 203
Me.Label285.Text = "Spindle Run Time"
'
'Label286
'
Me.Label286.Location = New System.Drawing.Point(8, 288)
Me.Label286.Name = "Label286"
Me.Label286.Size = New System.Drawing.Size(80, 23)
Me.Label286.TabIndex = 203
Me.Label286.Text = "Alarm On Time"
'
'Label287
'
Me.Label287.Location = New System.Drawing.Point(8, 312)
Me.Label287.Name = "Label287"
Me.Label287.Size = New System.Drawing.Size(112, 32)
Me.Label287.TabIndex = 203
Me.Label287.Text = "Date Of Operating report"
'
'morPrevOperatingTime
'
Me.morPrevOperatingTime.Location = New System.Drawing.Point(136, 16)
Me.morPrevOperatingTime.Name = "morPrevOperatingTime"
Me.morPrevOperatingTime.TabIndex = 207
Me.morPrevOperatingTime.Text = "0"
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.Label240)
Me.GroupBox2.Controls.Add(Me.morOperatingTime)
Me.GroupBox2.Controls.Add(Me.Label264)
Me.GroupBox2.Controls.Add(Me.Label265)
Me.GroupBox2.Controls.Add(Me.Label266)
Me.GroupBox2.Controls.Add(Me.Label267)
Me.GroupBox2.Controls.Add(Me.Label268)
Me.GroupBox2.Controls.Add(Me.Label269)
Me.GroupBox2.Controls.Add(Me.morRunningTime)
Me.GroupBox2.Controls.Add(Me.morCuttingTime)
Me.GroupBox2.Controls.Add(Me.morNonOPeratingTime)
Me.GroupBox2.Controls.Add(Me.morInProSetupTime)
Me.GroupBox2.Controls.Add(Me.morNoOperatorTime)
Me.GroupBox2.Controls.Add(Me.morPartWaitingTime)
Me.GroupBox2.Controls.Add(Me.Label270)
Me.GroupBox2.Controls.Add(Me.mormaintenanceTime)
Me.GroupBox2.Controls.Add(Me.Label271)
Me.GroupBox2.Controls.Add(Me.morOtherTime)
Me.GroupBox2.Controls.Add(Me.Label272)
Me.GroupBox2.Controls.Add(Me.morSpindleRunTime)
Me.GroupBox2.Controls.Add(Me.Label273)
Me.GroupBox2.Controls.Add(Me.morExternalInputTime)
Me.GroupBox2.Controls.Add(Me.morAlarmOnTime)
Me.GroupBox2.Controls.Add(Me.Label274)
Me.GroupBox2.Controls.Add(Me.morDateOfOperatingReport)
Me.GroupBox2.Controls.Add(Me.Label275)
Me.GroupBox2.Location = New System.Drawing.Point(264, 80)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(248, 352)
Me.GroupBox2.TabIndex = 303
Me.GroupBox2.TabStop = false
Me.GroupBox2.Text = "Today Operating report"
'
'Label240
'
Me.Label240.Location = New System.Drawing.Point(8, 16)
Me.Label240.Name = "Label240"
Me.Label240.Size = New System.Drawing.Size(88, 23)
Me.Label240.TabIndex = 176
Me.Label240.Text = "Operating Time"
'
'morOperatingTime
'
Me.morOperatingTime.Location = New System.Drawing.Point(144, 16)
Me.morOperatingTime.Name = "morOperatingTime"
Me.morOperatingTime.Size = New System.Drawing.Size(96, 20)
Me.morOperatingTime.TabIndex = 179
Me.morOperatingTime.Text = "0"
'
'Label264
'
Me.Label264.Location = New System.Drawing.Point(8, 40)
Me.Label264.Name = "Label264"
Me.Label264.TabIndex = 177
Me.Label264.Text = "Runing Time"
'
'Label265
'
Me.Label265.Location = New System.Drawing.Point(8, 64)
Me.Label265.Name = "Label265"
Me.Label265.TabIndex = 178
Me.Label265.Text = "Cutting Time"
'
'Label266
'
Me.Label266.Location = New System.Drawing.Point(8, 88)
Me.Label266.Name = "Label266"
Me.Label266.Size = New System.Drawing.Size(120, 23)
Me.Label266.TabIndex = 182
Me.Label266.Text = "Non Operating Time"
'
'Label267
'
Me.Label267.Location = New System.Drawing.Point(8, 112)
Me.Label267.Name = "Label267"
Me.Label267.TabIndex = 183
Me.Label267.Text = "In Pro Setup Time"
'
'Label268
'
Me.Label268.Location = New System.Drawing.Point(8, 136)
Me.Label268.Name = "Label268"
Me.Label268.TabIndex = 184
Me.Label268.Text = "No Operator Time"
'
'Label269
'
Me.Label269.Location = New System.Drawing.Point(8, 160)
Me.Label269.Name = "Label269"
Me.Label269.TabIndex = 188
Me.Label269.Text = "Part waiting Time"
'
'morRunningTime
'
Me.morRunningTime.Location = New System.Drawing.Point(144, 40)
Me.morRunningTime.Name = "morRunningTime"
Me.morRunningTime.Size = New System.Drawing.Size(96, 20)
Me.morRunningTime.TabIndex = 180
Me.morRunningTime.Text = "0"
'
'morCuttingTime
'
Me.morCuttingTime.Location = New System.Drawing.Point(144, 64)
Me.morCuttingTime.Name = "morCuttingTime"
Me.morCuttingTime.Size = New System.Drawing.Size(96, 20)
Me.morCuttingTime.TabIndex = 181
Me.morCuttingTime.Text = "0"
'
'morNonOPeratingTime
'
Me.morNonOPeratingTime.Location = New System.Drawing.Point(144, 88)
Me.morNonOPeratingTime.Name = "morNonOPeratingTime"
Me.morNonOPeratingTime.Size = New System.Drawing.Size(96, 20)
Me.morNonOPeratingTime.TabIndex = 185
Me.morNonOPeratingTime.Text = "0"
'
'morInProSetupTime
'
Me.morInProSetupTime.Location = New System.Drawing.Point(144, 112)
Me.morInProSetupTime.Name = "morInProSetupTime"
Me.morInProSetupTime.Size = New System.Drawing.Size(96, 20)
Me.morInProSetupTime.TabIndex = 186
Me.morInProSetupTime.Text = "0"
'
'morNoOperatorTime
'
Me.morNoOperatorTime.Location = New System.Drawing.Point(144, 136)
Me.morNoOperatorTime.Name = "morNoOperatorTime"
Me.morNoOperatorTime.Size = New System.Drawing.Size(96, 20)
Me.morNoOperatorTime.TabIndex = 187
Me.morNoOperatorTime.Text = "0"
'
'morPartWaitingTime
'
Me.morPartWaitingTime.Location = New System.Drawing.Point(144, 160)
Me.morPartWaitingTime.Name = "morPartWaitingTime"
Me.morPartWaitingTime.Size = New System.Drawing.Size(96, 20)
Me.morPartWaitingTime.TabIndex = 191
Me.morPartWaitingTime.Text = "0"
'
'Label270
'
Me.Label270.Location = New System.Drawing.Point(8, 184)
Me.Label270.Name = "Label270"
Me.Label270.TabIndex = 189
Me.Label270.Text = "Maintenance Time"
'
'mormaintenanceTime
'
Me.mormaintenanceTime.Location = New System.Drawing.Point(144, 184)
Me.mormaintenanceTime.Name = "mormaintenanceTime"
Me.mormaintenanceTime.Size = New System.Drawing.Size(96, 20)
Me.mormaintenanceTime.TabIndex = 192
Me.mormaintenanceTime.Text = "0"
'
'Label271
'
Me.Label271.Location = New System.Drawing.Point(8, 208)
Me.Label271.Name = "Label271"
Me.Label271.TabIndex = 190
Me.Label271.Text = "Other Time"
'
'morOtherTime
'
Me.morOtherTime.Location = New System.Drawing.Point(144, 208)
Me.morOtherTime.Name = "morOtherTime"
Me.morOtherTime.Size = New System.Drawing.Size(96, 20)
Me.morOtherTime.TabIndex = 193
Me.morOtherTime.Text = "0"
'
'Label272
'
Me.Label272.Location = New System.Drawing.Point(8, 232)
Me.Label272.Name = "Label272"
Me.Label272.TabIndex = 194
Me.Label272.Text = "Spindle Run Time"
'
'morSpindleRunTime
'
Me.morSpindleRunTime.Location = New System.Drawing.Point(144, 232)
Me.morSpindleRunTime.Name = "morSpindleRunTime"
Me.morSpindleRunTime.Size = New System.Drawing.Size(96, 20)
Me.morSpindleRunTime.TabIndex = 199
Me.morSpindleRunTime.Text = "0"
'
'Label273
'
Me.Label273.Location = New System.Drawing.Point(8, 256)
Me.Label273.Name = "Label273"
Me.Label273.Size = New System.Drawing.Size(104, 23)
Me.Label273.TabIndex = 195
Me.Label273.Text = "External Input Time"
'
'morExternalInputTime
'
Me.morExternalInputTime.Location = New System.Drawing.Point(144, 256)
Me.morExternalInputTime.Name = "morExternalInputTime"
Me.morExternalInputTime.Size = New System.Drawing.Size(96, 20)
Me.morExternalInputTime.TabIndex = 200
Me.morExternalInputTime.Text = "0"
'
'morAlarmOnTime
'
Me.morAlarmOnTime.Location = New System.Drawing.Point(144, 280)
Me.morAlarmOnTime.Name = "morAlarmOnTime"
Me.morAlarmOnTime.Size = New System.Drawing.Size(96, 20)
Me.morAlarmOnTime.TabIndex = 201
Me.morAlarmOnTime.Text = "0"
'
'Label274
'
Me.Label274.Location = New System.Drawing.Point(8, 280)
Me.Label274.Name = "Label274"
Me.Label274.TabIndex = 196
Me.Label274.Text = "Alarm On Time"
'
'morDateOfOperatingReport
'
Me.morDateOfOperatingReport.Location = New System.Drawing.Point(144, 304)
Me.morDateOfOperatingReport.Name = "morDateOfOperatingReport"
Me.morDateOfOperatingReport.Size = New System.Drawing.Size(96, 20)
Me.morDateOfOperatingReport.TabIndex = 202
Me.morDateOfOperatingReport.Text = "0"
'
'Label275
'
Me.Label275.Location = New System.Drawing.Point(8, 304)
Me.Label275.Name = "Label275"
Me.Label275.Size = New System.Drawing.Size(112, 40)
Me.Label275.TabIndex = 197
Me.Label275.Text = "Date Of Operating report"
'
'GroupBox3
'
Me.GroupBox3.Controls.Add(Me.morPeriodDateOfOperatingReport)
Me.GroupBox3.Controls.Add(Me.morPeriodAlarmOnTime)
Me.GroupBox3.Controls.Add(Me.morPeriodExternalInputTime)
Me.GroupBox3.Controls.Add(Me.morPeriodSpindleRunTime)
Me.GroupBox3.Controls.Add(Me.morPeriodOtherTime)
Me.GroupBox3.Controls.Add(Me.morPeriodMaintenanceTime)
Me.GroupBox3.Controls.Add(Me.morPeriodNoOperatorTime)
Me.GroupBox3.Controls.Add(Me.morPeriodPartWaitingTime)
Me.GroupBox3.Controls.Add(Me.morPeriodInproSetupTime)
Me.GroupBox3.Controls.Add(Me.morPeriodNonOperatingTime)
Me.GroupBox3.Controls.Add(Me.morPeriodCuttingTime)
Me.GroupBox3.Controls.Add(Me.morPeriodRunningTime)
Me.GroupBox3.Controls.Add(Me.Label84)
Me.GroupBox3.Controls.Add(Me.Label108)
Me.GroupBox3.Controls.Add(Me.Label109)
Me.GroupBox3.Controls.Add(Me.Label110)
Me.GroupBox3.Controls.Add(Me.Label111)
Me.GroupBox3.Controls.Add(Me.Label112)
Me.GroupBox3.Controls.Add(Me.Label133)
Me.GroupBox3.Controls.Add(Me.Label234)
Me.GroupBox3.Controls.Add(Me.Label235)
Me.GroupBox3.Controls.Add(Me.Label236)
Me.GroupBox3.Controls.Add(Me.Label237)
Me.GroupBox3.Controls.Add(Me.Label238)
Me.GroupBox3.Controls.Add(Me.morPeriodOperatingTime)
Me.GroupBox3.Controls.Add(Me.Label239)
Me.GroupBox3.Location = New System.Drawing.Point(8, 80)
Me.GroupBox3.Name = "GroupBox3"
Me.GroupBox3.Size = New System.Drawing.Size(248, 352)
Me.GroupBox3.TabIndex = 302
Me.GroupBox3.TabStop = false
Me.GroupBox3.Text = "Period Operating Report"
'
'morPeriodDateOfOperatingReport
'
Me.morPeriodDateOfOperatingReport.Location = New System.Drawing.Point(144, 296)
Me.morPeriodDateOfOperatingReport.Name = "morPeriodDateOfOperatingReport"
Me.morPeriodDateOfOperatingReport.Size = New System.Drawing.Size(96, 20)
Me.morPeriodDateOfOperatingReport.TabIndex = 216
Me.morPeriodDateOfOperatingReport.Text = "0"
'
'morPeriodAlarmOnTime
'
Me.morPeriodAlarmOnTime.Location = New System.Drawing.Point(144, 272)
Me.morPeriodAlarmOnTime.Name = "morPeriodAlarmOnTime"
Me.morPeriodAlarmOnTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodAlarmOnTime.TabIndex = 215
Me.morPeriodAlarmOnTime.Text = "0"
'
'morPeriodExternalInputTime
'
Me.morPeriodExternalInputTime.Location = New System.Drawing.Point(144, 248)
Me.morPeriodExternalInputTime.Name = "morPeriodExternalInputTime"
Me.morPeriodExternalInputTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodExternalInputTime.TabIndex = 214
Me.morPeriodExternalInputTime.Text = "0"
'
'morPeriodSpindleRunTime
'
Me.morPeriodSpindleRunTime.Location = New System.Drawing.Point(144, 224)
Me.morPeriodSpindleRunTime.Name = "morPeriodSpindleRunTime"
Me.morPeriodSpindleRunTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodSpindleRunTime.TabIndex = 213
Me.morPeriodSpindleRunTime.Text = "0"
'
'morPeriodOtherTime
'
Me.morPeriodOtherTime.Location = New System.Drawing.Point(144, 200)
Me.morPeriodOtherTime.Name = "morPeriodOtherTime"
Me.morPeriodOtherTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodOtherTime.TabIndex = 212
Me.morPeriodOtherTime.Text = "0"
'
'morPeriodMaintenanceTime
'
Me.morPeriodMaintenanceTime.Location = New System.Drawing.Point(144, 176)
Me.morPeriodMaintenanceTime.Name = "morPeriodMaintenanceTime"
Me.morPeriodMaintenanceTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodMaintenanceTime.TabIndex = 211
Me.morPeriodMaintenanceTime.Text = "0"
'
'morPeriodNoOperatorTime
'
Me.morPeriodNoOperatorTime.Location = New System.Drawing.Point(144, 128)
Me.morPeriodNoOperatorTime.Name = "morPeriodNoOperatorTime"
Me.morPeriodNoOperatorTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodNoOperatorTime.TabIndex = 209
Me.morPeriodNoOperatorTime.Text = "0"
'
'morPeriodPartWaitingTime
'
Me.morPeriodPartWaitingTime.Location = New System.Drawing.Point(144, 152)
Me.morPeriodPartWaitingTime.Name = "morPeriodPartWaitingTime"
Me.morPeriodPartWaitingTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodPartWaitingTime.TabIndex = 208
Me.morPeriodPartWaitingTime.Text = "0"
'
'morPeriodInproSetupTime
'
Me.morPeriodInproSetupTime.Location = New System.Drawing.Point(144, 104)
Me.morPeriodInproSetupTime.Name = "morPeriodInproSetupTime"
Me.morPeriodInproSetupTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodInproSetupTime.TabIndex = 207
Me.morPeriodInproSetupTime.Text = "0"
'
'morPeriodNonOperatingTime
'
Me.morPeriodNonOperatingTime.Location = New System.Drawing.Point(144, 80)
Me.morPeriodNonOperatingTime.Name = "morPeriodNonOperatingTime"
Me.morPeriodNonOperatingTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodNonOperatingTime.TabIndex = 206
Me.morPeriodNonOperatingTime.Text = "0"
'
'morPeriodCuttingTime
'
Me.morPeriodCuttingTime.Location = New System.Drawing.Point(144, 56)
Me.morPeriodCuttingTime.Name = "morPeriodCuttingTime"
Me.morPeriodCuttingTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodCuttingTime.TabIndex = 205
Me.morPeriodCuttingTime.Text = "0"
'
'morPeriodRunningTime
'
Me.morPeriodRunningTime.Location = New System.Drawing.Point(144, 32)
Me.morPeriodRunningTime.Name = "morPeriodRunningTime"
Me.morPeriodRunningTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodRunningTime.TabIndex = 204
Me.morPeriodRunningTime.Text = "0"
'
'Label84
'
Me.Label84.Location = New System.Drawing.Point(8, 16)
Me.Label84.Name = "Label84"
Me.Label84.Size = New System.Drawing.Size(88, 23)
Me.Label84.TabIndex = 203
Me.Label84.Text = "Operating Time"
'
'Label108
'
Me.Label108.Location = New System.Drawing.Point(8, 40)
Me.Label108.Name = "Label108"
Me.Label108.TabIndex = 203
Me.Label108.Text = "Runing Time"
'
'Label109
'
Me.Label109.Location = New System.Drawing.Point(8, 64)
Me.Label109.Name = "Label109"
Me.Label109.TabIndex = 203
Me.Label109.Text = "Cutting Time"
'
'Label110
'
Me.Label110.Location = New System.Drawing.Point(8, 88)
Me.Label110.Name = "Label110"
Me.Label110.Size = New System.Drawing.Size(120, 23)
Me.Label110.TabIndex = 203
Me.Label110.Text = "Non Operating Time"
'
'Label111
'
Me.Label111.Location = New System.Drawing.Point(8, 112)
Me.Label111.Name = "Label111"
Me.Label111.TabIndex = 203
Me.Label111.Text = "In Pro Setup Time"
'
'Label112
'
Me.Label112.Location = New System.Drawing.Point(8, 136)
Me.Label112.Name = "Label112"
Me.Label112.TabIndex = 203
Me.Label112.Text = "No Operator Time"
'
'Label133
'
Me.Label133.Location = New System.Drawing.Point(8, 160)
Me.Label133.Name = "Label133"
Me.Label133.Size = New System.Drawing.Size(112, 23)
Me.Label133.TabIndex = 203
Me.Label133.Text = "Part waiting Time"
'
'Label234
'
Me.Label234.Location = New System.Drawing.Point(8, 184)
Me.Label234.Name = "Label234"
Me.Label234.TabIndex = 203
Me.Label234.Text = "Maintenance Time"
'
'Label235
'
Me.Label235.Location = New System.Drawing.Point(8, 208)
Me.Label235.Name = "Label235"
Me.Label235.TabIndex = 203
Me.Label235.Text = "Other Time"
'
'Label236
'
Me.Label236.Location = New System.Drawing.Point(8, 232)
Me.Label236.Name = "Label236"
Me.Label236.TabIndex = 203
Me.Label236.Text = "Spindle Run Time"
'
'Label237
'
Me.Label237.Location = New System.Drawing.Point(8, 256)
Me.Label237.Name = "Label237"
Me.Label237.Size = New System.Drawing.Size(104, 23)
Me.Label237.TabIndex = 203
Me.Label237.Text = "External Input Time"
'
'Label238
'
Me.Label238.Location = New System.Drawing.Point(16, 280)
Me.Label238.Name = "Label238"
Me.Label238.TabIndex = 203
Me.Label238.Text = "Alarm On Time"
'
'morPeriodOperatingTime
'
Me.morPeriodOperatingTime.Location = New System.Drawing.Point(144, 8)
Me.morPeriodOperatingTime.Name = "morPeriodOperatingTime"
Me.morPeriodOperatingTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodOperatingTime.TabIndex = 203
Me.morPeriodOperatingTime.Text = "0"
'
'Label239
'
Me.Label239.Location = New System.Drawing.Point(8, 304)
Me.Label239.Name = "Label239"
Me.Label239.Size = New System.Drawing.Size(120, 32)
Me.Label239.TabIndex = 203
Me.Label239.Text = "Date Of Operating report"
'
'McORSubSystemCombo
'
Me.McORSubSystemCombo.Location = New System.Drawing.Point(232, 8)
Me.McORSubSystemCombo.Name = "McORSubSystemCombo"
Me.McORSubSystemCombo.Size = New System.Drawing.Size(176, 21)
Me.McORSubSystemCombo.TabIndex = 301
'
'Label241
'
Me.Label241.Location = New System.Drawing.Point(152, 8)
Me.Label241.Name = "Label241"
Me.Label241.Size = New System.Drawing.Size(72, 24)
Me.Label241.TabIndex = 300
Me.Label241.Text = "Sub System"
'
'tab_spec
'
Me.tab_spec.Controls.Add(Me.GroupBox17)
Me.tab_spec.Controls.Add(Me.txtMachineSerial)
Me.tab_spec.Controls.Add(Me.txtMachineName)
Me.tab_spec.Controls.Add(Me.Label168)
Me.tab_spec.Controls.Add(Me.Label174)
Me.tab_spec.Controls.Add(Me.txtVersion)
Me.tab_spec.Controls.Add(Me.Label64)
Me.tab_spec.Controls.Add(Me.Label37)
Me.tab_spec.Controls.Add(Me.specSaddleSpec)
Me.tab_spec.Controls.Add(Me.Label66)
Me.tab_spec.Controls.Add(Me.specCombo)
Me.tab_spec.Controls.Add(Me.specUpdateButton)
Me.tab_spec.Controls.Add(Me.specCode)
Me.tab_spec.Controls.Add(Me.Label63)
Me.tab_spec.Location = New System.Drawing.Point(4, 22)
Me.tab_spec.Name = "tab_spec"
Me.tab_spec.Size = New System.Drawing.Size(776, 446)
Me.tab_spec.TabIndex = 7
Me.tab_spec.Text = "Spec"
'
'GroupBox17
'
Me.GroupBox17.Controls.Add(Me.cmdGetBSpecCode)
Me.GroupBox17.Controls.Add(Me.txtSpecCode)
Me.GroupBox17.Controls.Add(Me.Label306)
Me.GroupBox17.Controls.Add(Me.txtSpecCodeBit)
Me.GroupBox17.Controls.Add(Me.Label308)
Me.GroupBox17.Controls.Add(Me.txtSpecCodeIndex)
Me.GroupBox17.Controls.Add(Me.cmdGetSpecCode)
Me.GroupBox17.Location = New System.Drawing.Point(8, 224)
Me.GroupBox17.Name = "GroupBox17"
Me.GroupBox17.Size = New System.Drawing.Size(224, 176)
Me.GroupBox17.TabIndex = 104
Me.GroupBox17.TabStop = false
Me.GroupBox17.Text = "General Spec Code"
'
'cmdGetBSpecCode
'
Me.cmdGetBSpecCode.Location = New System.Drawing.Point(16, 64)
Me.cmdGetBSpecCode.Name = "cmdGetBSpecCode"
Me.cmdGetBSpecCode.Size = New System.Drawing.Size(152, 24)
Me.cmdGetBSpecCode.TabIndex = 102
Me.cmdGetBSpecCode.Text = "Get B Spec Code"
'
'txtSpecCode
'
Me.txtSpecCode.Location = New System.Drawing.Point(176, 48)
Me.txtSpecCode.Name = "txtSpecCode"
Me.txtSpecCode.ReadOnly = true
Me.txtSpecCode.Size = New System.Drawing.Size(32, 20)
Me.txtSpecCode.TabIndex = 101
Me.txtSpecCode.Text = "0"
'
'Label306
'
Me.Label306.Location = New System.Drawing.Point(16, 144)
Me.Label306.Name = "Label306"
Me.Label306.Size = New System.Drawing.Size(136, 24)
Me.Label306.TabIndex = 100
Me.Label306.Text = "Spec Code Bit Number"
'
'txtSpecCodeBit
'
Me.txtSpecCodeBit.Location = New System.Drawing.Point(176, 144)
Me.txtSpecCodeBit.Name = "txtSpecCodeBit"
Me.txtSpecCodeBit.Size = New System.Drawing.Size(32, 20)
Me.txtSpecCodeBit.TabIndex = 99
Me.txtSpecCodeBit.Text = "1"
'
'Label308
'
Me.Label308.Location = New System.Drawing.Point(16, 104)
Me.Label308.Name = "Label308"
Me.Label308.Size = New System.Drawing.Size(144, 24)
Me.Label308.TabIndex = 98
Me.Label308.Text = "Spec Code Index"
'
'txtSpecCodeIndex
'
Me.txtSpecCodeIndex.Location = New System.Drawing.Point(176, 104)
Me.txtSpecCodeIndex.Name = "txtSpecCodeIndex"
Me.txtSpecCodeIndex.Size = New System.Drawing.Size(32, 20)
Me.txtSpecCodeIndex.TabIndex = 97
Me.txtSpecCodeIndex.Text = "1"
'
'cmdGetSpecCode
'
Me.cmdGetSpecCode.Location = New System.Drawing.Point(16, 24)
Me.cmdGetSpecCode.Name = "cmdGetSpecCode"
Me.cmdGetSpecCode.Size = New System.Drawing.Size(152, 24)
Me.cmdGetSpecCode.TabIndex = 96
Me.cmdGetSpecCode.Text = "Get Spec Code"
'
'txtMachineSerial
'
Me.txtMachineSerial.BackColor = System.Drawing.SystemColors.Control
Me.txtMachineSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtMachineSerial.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.txtMachineSerial.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.txtMachineSerial.Location = New System.Drawing.Point(160, 176)
Me.txtMachineSerial.Name = "txtMachineSerial"
Me.txtMachineSerial.Size = New System.Drawing.Size(272, 31)
Me.txtMachineSerial.TabIndex = 103
Me.txtMachineSerial.Text = ""
'
'txtMachineName
'
Me.txtMachineName.BackColor = System.Drawing.SystemColors.Control
Me.txtMachineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtMachineName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.txtMachineName.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.txtMachineName.Location = New System.Drawing.Point(160, 136)
Me.txtMachineName.Name = "txtMachineName"
Me.txtMachineName.Size = New System.Drawing.Size(272, 31)
Me.txtMachineName.TabIndex = 102
Me.txtMachineName.Text = ""
'
'Label168
'
Me.Label168.Location = New System.Drawing.Point(8, 176)
Me.Label168.Name = "Label168"
Me.Label168.Size = New System.Drawing.Size(96, 16)
Me.Label168.TabIndex = 101
Me.Label168.Text = "Machine Serial:"
'
'Label174
'
Me.Label174.Location = New System.Drawing.Point(8, 136)
Me.Label174.Name = "Label174"
Me.Label174.Size = New System.Drawing.Size(88, 16)
Me.Label174.TabIndex = 100
Me.Label174.Text = "Machine Name:"
'
'txtVersion
'
Me.txtVersion.Location = New System.Drawing.Point(160, 104)
Me.txtVersion.Name = "txtVersion"
Me.txtVersion.Size = New System.Drawing.Size(176, 20)
Me.txtVersion.TabIndex = 99
Me.txtVersion.Text = ""
'
'Label64
'
Me.Label64.Location = New System.Drawing.Point(8, 104)
Me.Label64.Name = "Label64"
Me.Label64.Size = New System.Drawing.Size(128, 16)
Me.Label64.TabIndex = 98
Me.Label64.Text = "Command API version:"
'
'Label37
'
Me.Label37.Location = New System.Drawing.Point(8, 72)
Me.Label37.Name = "Label37"
Me.Label37.Size = New System.Drawing.Size(136, 16)
Me.Label37.TabIndex = 87
Me.Label37.Text = "Saddle Spec"
'
'specSaddleSpec
'
Me.specSaddleSpec.Location = New System.Drawing.Point(160, 72)
Me.specSaddleSpec.Name = "specSaddleSpec"
Me.specSaddleSpec.Size = New System.Drawing.Size(176, 20)
Me.specSaddleSpec.TabIndex = 86
Me.specSaddleSpec.Text = "0"
'
'Label66
'
Me.Label66.Location = New System.Drawing.Point(8, 8)
Me.Label66.Name = "Label66"
Me.Label66.Size = New System.Drawing.Size(136, 16)
Me.Label66.TabIndex = 85
Me.Label66.Text = "Option Spec Code"
'
'specCombo
'
Me.specCombo.Location = New System.Drawing.Point(160, 8)
Me.specCombo.Name = "specCombo"
Me.specCombo.Size = New System.Drawing.Size(176, 21)
Me.specCombo.TabIndex = 84
'
'specUpdateButton
'
Me.specUpdateButton.Location = New System.Drawing.Point(528, 8)
Me.specUpdateButton.Name = "specUpdateButton"
Me.specUpdateButton.Size = New System.Drawing.Size(72, 24)
Me.specUpdateButton.TabIndex = 83
Me.specUpdateButton.Text = "Update"
'
'specCode
'
Me.specCode.Location = New System.Drawing.Point(160, 40)
Me.specCode.Name = "specCode"
Me.specCode.Size = New System.Drawing.Size(176, 20)
Me.specCode.TabIndex = 82
Me.specCode.Text = "0"
'
'Label63
'
Me.Label63.Location = New System.Drawing.Point(8, 40)
Me.Label63.Name = "Label63"
Me.Label63.Size = New System.Drawing.Size(136, 16)
Me.Label63.TabIndex = 81
Me.Label63.Text = "Option Spec Code"
'
'tab_views
'
Me.tab_views.Controls.Add(Me.Panel12)
Me.tab_views.Location = New System.Drawing.Point(4, 22)
Me.tab_views.Name = "tab_views"
Me.tab_views.Size = New System.Drawing.Size(776, 446)
Me.tab_views.TabIndex = 24
Me.tab_views.Text = "Views"
'
'Panel12
'
Me.Panel12.Controls.Add(Me.Label231)
Me.Panel12.Controls.Add(Me.Cmb_ChangeScreen)
Me.Panel12.Controls.Add(Me.cmd_ChangeScreen)
Me.Panel12.Controls.Add(Me.txt_screenname)
Me.Panel12.Controls.Add(Me.Label232)
Me.Panel12.Location = New System.Drawing.Point(168, 32)
Me.Panel12.Name = "Panel12"
Me.Panel12.Size = New System.Drawing.Size(480, 168)
Me.Panel12.TabIndex = 271
'
'Label231
'
Me.Label231.Location = New System.Drawing.Point(8, 56)
Me.Label231.Name = "Label231"
Me.Label231.Size = New System.Drawing.Size(128, 16)
Me.Label231.TabIndex = 274
Me.Label231.Text = "PanelGroupEnum"
'
'Cmb_ChangeScreen
'
Me.Cmb_ChangeScreen.Location = New System.Drawing.Point(160, 56)
Me.Cmb_ChangeScreen.Name = "Cmb_ChangeScreen"
Me.Cmb_ChangeScreen.Size = New System.Drawing.Size(312, 21)
Me.Cmb_ChangeScreen.TabIndex = 273
'
'cmd_ChangeScreen
'
Me.cmd_ChangeScreen.Location = New System.Drawing.Point(192, 120)
Me.cmd_ChangeScreen.Name = "cmd_ChangeScreen"
Me.cmd_ChangeScreen.Size = New System.Drawing.Size(104, 32)
Me.cmd_ChangeScreen.TabIndex = 272
Me.cmd_ChangeScreen.Text = "ChangeScreen"
'
'txt_screenname
'
Me.txt_screenname.Location = New System.Drawing.Point(160, 8)
Me.txt_screenname.Name = "txt_screenname"
Me.txt_screenname.Size = New System.Drawing.Size(312, 20)
Me.txt_screenname.TabIndex = 271
Me.txt_screenname.Text = ""
'
'Label232
'
Me.Label232.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label232.Location = New System.Drawing.Point(8, 8)
Me.Label232.Name = "Label232"
Me.Label232.Size = New System.Drawing.Size(136, 16)
Me.Label232.TabIndex = 270
Me.Label232.Text = "Screen Name"
'
'tab_ToolStandard2
'
Me.tab_ToolStandard2.Controls.Add(Me.Tool2InputPanel)
Me.tab_ToolStandard2.Controls.Add(Me.txtTool2EntryNo)
Me.tab_ToolStandard2.Controls.Add(Me.Label326)
Me.tab_ToolStandard2.Controls.Add(Me.cmdToolEntryNoGet)
Me.tab_ToolStandard2.Location = New System.Drawing.Point(4, 22)
Me.tab_ToolStandard2.Name = "tab_ToolStandard2"
Me.tab_ToolStandard2.Size = New System.Drawing.Size(776, 446)
Me.tab_ToolStandard2.TabIndex = 32
Me.tab_ToolStandard2.Text = "Tool Standard - 2"
'
'Tool2InputPanel
'
Me.Tool2InputPanel.Controls.Add(Me.txtTool2GroupNoInput)
Me.Tool2InputPanel.Controls.Add(Me.Label328)
Me.Tool2InputPanel.Controls.Add(Me.txtTool2EntryToolIndex)
Me.Tool2InputPanel.Controls.Add(Me.Label327)
Me.Tool2InputPanel.Location = New System.Drawing.Point(7, 7)
Me.Tool2InputPanel.Name = "Tool2InputPanel"
Me.Tool2InputPanel.Size = New System.Drawing.Size(560, 69)
Me.Tool2InputPanel.TabIndex = 292
Me.Tool2InputPanel.TabStop = false
Me.Tool2InputPanel.Text = "Input Data"
'
'txtTool2GroupNoInput
'
Me.txtTool2GroupNoInput.Location = New System.Drawing.Point(127, 21)
Me.txtTool2GroupNoInput.Name = "txtTool2GroupNoInput"
Me.txtTool2GroupNoInput.Size = New System.Drawing.Size(47, 20)
Me.txtTool2GroupNoInput.TabIndex = 294
Me.txtTool2GroupNoInput.Text = "1"
'
'Label328
'
Me.Label328.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label328.Location = New System.Drawing.Point(7, 21)
Me.Label328.Name = "Label328"
Me.Label328.Size = New System.Drawing.Size(106, 16)
Me.Label328.TabIndex = 293
Me.Label328.Text = "Group No.:"
'
'txtTool2EntryToolIndex
'
Me.txtTool2EntryToolIndex.Location = New System.Drawing.Point(333, 21)
Me.txtTool2EntryToolIndex.Name = "txtTool2EntryToolIndex"
Me.txtTool2EntryToolIndex.Size = New System.Drawing.Size(48, 20)
Me.txtTool2EntryToolIndex.TabIndex = 292
Me.txtTool2EntryToolIndex.Text = "1"
'
'Label327
'
Me.Label327.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label327.Location = New System.Drawing.Point(213, 21)
Me.Label327.Name = "Label327"
Me.Label327.Size = New System.Drawing.Size(107, 16)
Me.Label327.TabIndex = 291
Me.Label327.Text = "Entry Tool Index:"
'
'txtTool2EntryNo
'
Me.txtTool2EntryNo.Location = New System.Drawing.Point(113, 83)
Me.txtTool2EntryNo.Name = "txtTool2EntryNo"
Me.txtTool2EntryNo.ReadOnly = true
Me.txtTool2EntryNo.Size = New System.Drawing.Size(48, 20)
Me.txtTool2EntryNo.TabIndex = 291
Me.txtTool2EntryNo.Text = "1"
'
'Label326
'
Me.Label326.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label326.Location = New System.Drawing.Point(13, 83)
Me.Label326.Name = "Label326"
Me.Label326.Size = New System.Drawing.Size(88, 17)
Me.Label326.TabIndex = 289
Me.Label326.Text = "Entry Tool No."
'
'cmdToolEntryNoGet
'
Me.cmdToolEntryNoGet.Location = New System.Drawing.Point(167, 83)
Me.cmdToolEntryNoGet.Name = "cmdToolEntryNoGet"
Me.cmdToolEntryNoGet.Size = New System.Drawing.Size(40, 24)
Me.cmdToolEntryNoGet.TabIndex = 288
Me.cmdToolEntryNoGet.Text = "Get"
'
'TabPage3
'
Me.TabPage3.Controls.Add(Me.cboGraphMode)
Me.TabPage3.Controls.Add(Me.cmdChangeGraphMode)
Me.TabPage3.Controls.Add(Me.GroupBox14)
Me.TabPage3.Controls.Add(Me.cmdStartGraphWork)
Me.TabPage3.Controls.Add(Me.cmdSelectGraphLineAnimate)
Me.TabPage3.Controls.Add(Me.cmdSelect2D3DGraph)
Me.TabPage3.Controls.Add(Me.cmdDeleteGraphWork)
Me.TabPage3.Controls.Add(Me.cmdChangeReal3DSpindleMode)
Me.TabPage3.Location = New System.Drawing.Point(4, 22)
Me.TabPage3.Name = "TabPage3"
Me.TabPage3.Size = New System.Drawing.Size(776, 446)
Me.TabPage3.TabIndex = 25
Me.TabPage3.Text = "Simulation"
'
'cboGraphMode
'
Me.cboGraphMode.Location = New System.Drawing.Point(192, 144)
Me.cboGraphMode.Name = "cboGraphMode"
Me.cboGraphMode.Size = New System.Drawing.Size(176, 21)
Me.cboGraphMode.TabIndex = 9
'
'cmdChangeGraphMode
'
Me.cmdChangeGraphMode.Location = New System.Drawing.Point(8, 136)
Me.cmdChangeGraphMode.Name = "cmdChangeGraphMode"
Me.cmdChangeGraphMode.Size = New System.Drawing.Size(176, 32)
Me.cmdChangeGraphMode.TabIndex = 8
Me.cmdChangeGraphMode.Text = "Change Graph Mode"
'
'GroupBox14
'
Me.GroupBox14.Controls.Add(Me.cboShiftEnlargeScaleFrame)
Me.GroupBox14.Controls.Add(Me.cmdShiftEnlargeScaleFrame)
Me.GroupBox14.Controls.Add(Me.cboEnlargeScaleFrame)
Me.GroupBox14.Controls.Add(Me.txtNormalScaleValue)
Me.GroupBox14.Controls.Add(Me.cmdNormalScale)
Me.GroupBox14.Controls.Add(Me.cmdChangeEnlargeScaleFrame)
Me.GroupBox14.Controls.Add(Me.cmdAutoScaleAnimate)
Me.GroupBox14.Location = New System.Drawing.Point(376, 8)
Me.GroupBox14.Name = "GroupBox14"
Me.GroupBox14.Size = New System.Drawing.Size(384, 176)
Me.GroupBox14.TabIndex = 7
Me.GroupBox14.TabStop = false
Me.GroupBox14.Text = "Scale"
'
'cboShiftEnlargeScaleFrame
'
Me.cboShiftEnlargeScaleFrame.Location = New System.Drawing.Point(208, 104)
Me.cboShiftEnlargeScaleFrame.Name = "cboShiftEnlargeScaleFrame"
Me.cboShiftEnlargeScaleFrame.Size = New System.Drawing.Size(160, 21)
Me.cboShiftEnlargeScaleFrame.TabIndex = 11
'
'cmdShiftEnlargeScaleFrame
'
Me.cmdShiftEnlargeScaleFrame.Location = New System.Drawing.Point(16, 96)
Me.cmdShiftEnlargeScaleFrame.Name = "cmdShiftEnlargeScaleFrame"
Me.cmdShiftEnlargeScaleFrame.Size = New System.Drawing.Size(176, 32)
Me.cmdShiftEnlargeScaleFrame.TabIndex = 10
Me.cmdShiftEnlargeScaleFrame.Text = "Shift Enlarge Scale Frame"
'
'cboEnlargeScaleFrame
'
Me.cboEnlargeScaleFrame.Location = New System.Drawing.Point(208, 64)
Me.cboEnlargeScaleFrame.Name = "cboEnlargeScaleFrame"
Me.cboEnlargeScaleFrame.Size = New System.Drawing.Size(160, 21)
Me.cboEnlargeScaleFrame.TabIndex = 9
'
'txtNormalScaleValue
'
Me.txtNormalScaleValue.Location = New System.Drawing.Point(208, 144)
Me.txtNormalScaleValue.Name = "txtNormalScaleValue"
Me.txtNormalScaleValue.Size = New System.Drawing.Size(160, 20)
Me.txtNormalScaleValue.TabIndex = 8
Me.txtNormalScaleValue.Text = ""
'
'cmdNormalScale
'
Me.cmdNormalScale.Location = New System.Drawing.Point(16, 136)
Me.cmdNormalScale.Name = "cmdNormalScale"
Me.cmdNormalScale.Size = New System.Drawing.Size(176, 32)
Me.cmdNormalScale.TabIndex = 7
Me.cmdNormalScale.Text = "Change Normal Scale"
'
'cmdChangeEnlargeScaleFrame
'
Me.cmdChangeEnlargeScaleFrame.Location = New System.Drawing.Point(16, 56)
Me.cmdChangeEnlargeScaleFrame.Name = "cmdChangeEnlargeScaleFrame"
Me.cmdChangeEnlargeScaleFrame.Size = New System.Drawing.Size(176, 32)
Me.cmdChangeEnlargeScaleFrame.TabIndex = 6
Me.cmdChangeEnlargeScaleFrame.Text = "Change Enlarge Scale Frame"
'
'cmdAutoScaleAnimate
'
Me.cmdAutoScaleAnimate.Location = New System.Drawing.Point(16, 16)
Me.cmdAutoScaleAnimate.Name = "cmdAutoScaleAnimate"
Me.cmdAutoScaleAnimate.Size = New System.Drawing.Size(176, 32)
Me.cmdAutoScaleAnimate.TabIndex = 0
Me.cmdAutoScaleAnimate.Text = "Auto Scale Animate"
'
'cmdStartGraphWork
'
Me.cmdStartGraphWork.Location = New System.Drawing.Point(192, 56)
Me.cmdStartGraphWork.Name = "cmdStartGraphWork"
Me.cmdStartGraphWork.Size = New System.Drawing.Size(176, 32)
Me.cmdStartGraphWork.TabIndex = 5
Me.cmdStartGraphWork.Text = "Start Graph Work"
'
'cmdSelectGraphLineAnimate
'
Me.cmdSelectGraphLineAnimate.Location = New System.Drawing.Point(8, 96)
Me.cmdSelectGraphLineAnimate.Name = "cmdSelectGraphLineAnimate"
Me.cmdSelectGraphLineAnimate.Size = New System.Drawing.Size(176, 32)
Me.cmdSelectGraphLineAnimate.TabIndex = 4
Me.cmdSelectGraphLineAnimate.Text = "Select Graph Line Animate"
'
'cmdSelect2D3DGraph
'
Me.cmdSelect2D3DGraph.Location = New System.Drawing.Point(8, 56)
Me.cmdSelect2D3DGraph.Name = "cmdSelect2D3DGraph"
Me.cmdSelect2D3DGraph.Size = New System.Drawing.Size(176, 32)
Me.cmdSelect2D3DGraph.TabIndex = 3
Me.cmdSelect2D3DGraph.Text = "Select 2D/3D Graph"
'
'cmdDeleteGraphWork
'
Me.cmdDeleteGraphWork.Location = New System.Drawing.Point(192, 16)
Me.cmdDeleteGraphWork.Name = "cmdDeleteGraphWork"
Me.cmdDeleteGraphWork.Size = New System.Drawing.Size(176, 32)
Me.cmdDeleteGraphWork.TabIndex = 2
Me.cmdDeleteGraphWork.Text = "Delete Graph Work"
'
'cmdChangeReal3DSpindleMode
'
Me.cmdChangeReal3DSpindleMode.Location = New System.Drawing.Point(8, 16)
Me.cmdChangeReal3DSpindleMode.Name = "cmdChangeReal3DSpindleMode"
Me.cmdChangeReal3DSpindleMode.Size = New System.Drawing.Size(176, 32)
Me.cmdChangeReal3DSpindleMode.TabIndex = 1
Me.cmdChangeReal3DSpindleMode.Text = "Change Real 3D Spindle Mode"
'
'tab_MacmanOperatingHistory
'
Me.tab_MacmanOperatingHistory.Controls.Add(Me.mohTo)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.Label139)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.mohFrom)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.Label140)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.mohResults)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.mohButtonResults)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.mohSubSystemSet)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.mohSubSystemCombo)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.Label136)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.mohUpdateButton)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.mohOperationIndex)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.Label113)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.mohOperationTime)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.Label116)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.mohOperationDate)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.Label117)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.mohOperationData)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.Label118)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.mohMaxCount)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.Label119)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.mohCount)
Me.tab_MacmanOperatingHistory.Controls.Add(Me.Label120)
Me.tab_MacmanOperatingHistory.Location = New System.Drawing.Point(4, 22)
Me.tab_MacmanOperatingHistory.Name = "tab_MacmanOperatingHistory"
Me.tab_MacmanOperatingHistory.Size = New System.Drawing.Size(776, 446)
Me.tab_MacmanOperatingHistory.TabIndex = 14
Me.tab_MacmanOperatingHistory.Text = "MacMan Operation History"
'
'mohTo
'
Me.mohTo.Location = New System.Drawing.Point(664, 24)
Me.mohTo.Name = "mohTo"
Me.mohTo.Size = New System.Drawing.Size(64, 20)
Me.mohTo.TabIndex = 212
Me.mohTo.Text = "2"
'
'Label139
'
Me.Label139.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label139.Location = New System.Drawing.Point(608, 24)
Me.Label139.Name = "Label139"
Me.Label139.Size = New System.Drawing.Size(48, 16)
Me.Label139.TabIndex = 211
Me.Label139.Text = "To"
'
'mohFrom
'
Me.mohFrom.Location = New System.Drawing.Point(512, 24)
Me.mohFrom.Name = "mohFrom"
Me.mohFrom.Size = New System.Drawing.Size(64, 20)
Me.mohFrom.TabIndex = 210
Me.mohFrom.Text = "1"
'
'Label140
'
Me.Label140.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label140.Location = New System.Drawing.Point(456, 24)
Me.Label140.Name = "Label140"
Me.Label140.Size = New System.Drawing.Size(48, 16)
Me.Label140.TabIndex = 209
Me.Label140.Text = "From"
'
'mohResults
'
Me.mohResults.Location = New System.Drawing.Point(424, 80)
Me.mohResults.Multiline = true
Me.mohResults.Name = "mohResults"
Me.mohResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.mohResults.Size = New System.Drawing.Size(312, 288)
Me.mohResults.TabIndex = 208
Me.mohResults.Text = ""
'
'mohButtonResults
'
Me.mohButtonResults.Location = New System.Drawing.Point(576, 48)
Me.mohButtonResults.Name = "mohButtonResults"
Me.mohButtonResults.Size = New System.Drawing.Size(72, 24)
Me.mohButtonResults.TabIndex = 207
Me.mohButtonResults.Text = "Update"
'
'mohSubSystemSet
'
Me.mohSubSystemSet.Location = New System.Drawing.Point(272, 48)
Me.mohSubSystemSet.Name = "mohSubSystemSet"
Me.mohSubSystemSet.Size = New System.Drawing.Size(64, 24)
Me.mohSubSystemSet.TabIndex = 201
Me.mohSubSystemSet.Text = "Set"
'
'mohSubSystemCombo
'
Me.mohSubSystemCombo.Location = New System.Drawing.Point(104, 48)
Me.mohSubSystemCombo.Name = "mohSubSystemCombo"
Me.mohSubSystemCombo.Size = New System.Drawing.Size(160, 21)
Me.mohSubSystemCombo.TabIndex = 200
'
'Label136
'
Me.Label136.Location = New System.Drawing.Point(16, 48)
Me.Label136.Name = "Label136"
Me.Label136.Size = New System.Drawing.Size(72, 16)
Me.Label136.TabIndex = 199
Me.Label136.Text = "Sub System :"
'
'mohUpdateButton
'
Me.mohUpdateButton.Location = New System.Drawing.Point(264, 85)
Me.mohUpdateButton.Name = "mohUpdateButton"
Me.mohUpdateButton.Size = New System.Drawing.Size(72, 24)
Me.mohUpdateButton.TabIndex = 198
Me.mohUpdateButton.Text = "Update"
'
'mohOperationIndex
'
Me.mohOperationIndex.Location = New System.Drawing.Point(184, 85)
Me.mohOperationIndex.Name = "mohOperationIndex"
Me.mohOperationIndex.Size = New System.Drawing.Size(64, 20)
Me.mohOperationIndex.TabIndex = 197
Me.mohOperationIndex.Text = "1"
'
'Label113
'
Me.Label113.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label113.Location = New System.Drawing.Point(40, 85)
Me.Label113.Name = "Label113"
Me.Label113.Size = New System.Drawing.Size(136, 16)
Me.Label113.TabIndex = 196
Me.Label113.Text = "Operation History Index :"
'
'mohOperationTime
'
Me.mohOperationTime.Location = New System.Drawing.Point(184, 184)
Me.mohOperationTime.Name = "mohOperationTime"
Me.mohOperationTime.Size = New System.Drawing.Size(184, 20)
Me.mohOperationTime.TabIndex = 191
Me.mohOperationTime.Text = ""
'
'Label116
'
Me.Label116.Location = New System.Drawing.Point(16, 184)
Me.Label116.Name = "Label116"
Me.Label116.Size = New System.Drawing.Size(160, 16)
Me.Label116.TabIndex = 190
Me.Label116.Text = "Operation Time :"
'
'mohOperationDate
'
Me.mohOperationDate.Location = New System.Drawing.Point(184, 160)
Me.mohOperationDate.Name = "mohOperationDate"
Me.mohOperationDate.Size = New System.Drawing.Size(184, 20)
Me.mohOperationDate.TabIndex = 189
Me.mohOperationDate.Text = ""
'
'Label117
'
Me.Label117.Location = New System.Drawing.Point(16, 160)
Me.Label117.Name = "Label117"
Me.Label117.Size = New System.Drawing.Size(160, 16)
Me.Label117.TabIndex = 188
Me.Label117.Text = "Operation Date :"
'
'mohOperationData
'
Me.mohOperationData.Location = New System.Drawing.Point(184, 136)
Me.mohOperationData.Name = "mohOperationData"
Me.mohOperationData.Size = New System.Drawing.Size(184, 20)
Me.mohOperationData.TabIndex = 187
Me.mohOperationData.Text = ""
'
'Label118
'
Me.Label118.Location = New System.Drawing.Point(16, 136)
Me.Label118.Name = "Label118"
Me.Label118.Size = New System.Drawing.Size(160, 16)
Me.Label118.TabIndex = 186
Me.Label118.Text = "Operation Data :"
'
'mohMaxCount
'
Me.mohMaxCount.Location = New System.Drawing.Point(184, 232)
Me.mohMaxCount.Name = "mohMaxCount"
Me.mohMaxCount.Size = New System.Drawing.Size(184, 20)
Me.mohMaxCount.TabIndex = 185
Me.mohMaxCount.Text = ""
'
'Label119
'
Me.Label119.Location = New System.Drawing.Point(16, 232)
Me.Label119.Name = "Label119"
Me.Label119.Size = New System.Drawing.Size(160, 16)
Me.Label119.TabIndex = 184
Me.Label119.Text = "Operation History Max Count :"
'
'mohCount
'
Me.mohCount.Location = New System.Drawing.Point(184, 208)
Me.mohCount.Name = "mohCount"
Me.mohCount.Size = New System.Drawing.Size(184, 20)
Me.mohCount.TabIndex = 183
Me.mohCount.Text = ""
'
'Label120
'
Me.Label120.Location = New System.Drawing.Point(16, 208)
Me.Label120.Name = "Label120"
Me.Label120.Size = New System.Drawing.Size(160, 16)
Me.Label120.TabIndex = 182
Me.Label120.Text = "Operation History Count :"
'
'tab_workpiece
'
Me.tab_workpiece.Controls.Add(Me.Panel1)
Me.tab_workpiece.Controls.Add(Me.Label142)
Me.tab_workpiece.Controls.Add(Me.cboWorkpieceSubSystem)
Me.tab_workpiece.Controls.Add(Me.Label256)
Me.tab_workpiece.Controls.Add(Me.cmb_WorkpieceDataunit)
Me.tab_workpiece.Controls.Add(Me.wkUpdateValsWithNoParams)
Me.tab_workpiece.Controls.Add(Me.Panel9)
Me.tab_workpiece.Controls.Add(Me.Panel10)
Me.tab_workpiece.Location = New System.Drawing.Point(4, 22)
Me.tab_workpiece.Name = "tab_workpiece"
Me.tab_workpiece.Size = New System.Drawing.Size(776, 446)
Me.tab_workpiece.TabIndex = 11
Me.tab_workpiece.Text = "Workpiece"
'
'Panel1
'
Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel1.Controls.Add(Me.cmdGetZeroShift)
Me.Panel1.Controls.Add(Me.txtZeroShiftInput)
Me.Panel1.Controls.Add(Me.cboZeroShiftAxis)
Me.Panel1.Controls.Add(Me.Label298)
Me.Panel1.Controls.Add(Me.txtZeroShift)
Me.Panel1.Controls.Add(Me.cmdSetZeroShift)
Me.Panel1.Controls.Add(Me.cmdAddZeroShift)
Me.Panel1.Controls.Add(Me.cmdCalZeroShift)
Me.Panel1.Location = New System.Drawing.Point(8, 232)
Me.Panel1.Name = "Panel1"
Me.Panel1.Size = New System.Drawing.Size(328, 72)
Me.Panel1.TabIndex = 234
'
'cmdGetZeroShift
'
Me.cmdGetZeroShift.Location = New System.Drawing.Point(112, 8)
Me.cmdGetZeroShift.Name = "cmdGetZeroShift"
Me.cmdGetZeroShift.Size = New System.Drawing.Size(40, 24)
Me.cmdGetZeroShift.TabIndex = 172
Me.cmdGetZeroShift.Text = "Get"
'
'txtZeroShiftInput
'
Me.txtZeroShiftInput.ForeColor = System.Drawing.Color.Red
Me.txtZeroShiftInput.Location = New System.Drawing.Point(80, 40)
Me.txtZeroShiftInput.Name = "txtZeroShiftInput"
Me.txtZeroShiftInput.Size = New System.Drawing.Size(64, 20)
Me.txtZeroShiftInput.TabIndex = 159
Me.txtZeroShiftInput.Text = "0.00"
'
'cboZeroShiftAxis
'
Me.cboZeroShiftAxis.Location = New System.Drawing.Point(152, 40)
Me.cboZeroShiftAxis.Name = "cboZeroShiftAxis"
Me.cboZeroShiftAxis.Size = New System.Drawing.Size(168, 21)
Me.cboZeroShiftAxis.TabIndex = 15
'
'Label298
'
Me.Label298.Location = New System.Drawing.Point(8, 16)
Me.Label298.Name = "Label298"
Me.Label298.Size = New System.Drawing.Size(80, 16)
Me.Label298.TabIndex = 157
Me.Label298.Text = "Zero Shift :"
'
'txtZeroShift
'
Me.txtZeroShift.Location = New System.Drawing.Point(8, 40)
Me.txtZeroShift.Name = "txtZeroShift"
Me.txtZeroShift.ReadOnly = true
Me.txtZeroShift.Size = New System.Drawing.Size(64, 20)
Me.txtZeroShift.TabIndex = 158
Me.txtZeroShift.Text = "0.00"
'
'cmdSetZeroShift
'
Me.cmdSetZeroShift.Location = New System.Drawing.Point(168, 8)
Me.cmdSetZeroShift.Name = "cmdSetZeroShift"
Me.cmdSetZeroShift.Size = New System.Drawing.Size(40, 24)
Me.cmdSetZeroShift.TabIndex = 160
Me.cmdSetZeroShift.Text = "Set"
'
'cmdAddZeroShift
'
Me.cmdAddZeroShift.Location = New System.Drawing.Point(224, 8)
Me.cmdAddZeroShift.Name = "cmdAddZeroShift"
Me.cmdAddZeroShift.Size = New System.Drawing.Size(40, 24)
Me.cmdAddZeroShift.TabIndex = 161
Me.cmdAddZeroShift.Text = "Add"
'
'cmdCalZeroShift
'
Me.cmdCalZeroShift.Location = New System.Drawing.Point(280, 8)
Me.cmdCalZeroShift.Name = "cmdCalZeroShift"
Me.cmdCalZeroShift.Size = New System.Drawing.Size(40, 24)
Me.cmdCalZeroShift.TabIndex = 162
Me.cmdCalZeroShift.Text = "Cal"
'
'Label142
'
Me.Label142.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label142.Location = New System.Drawing.Point(8, 40)
Me.Label142.Name = "Label142"
Me.Label142.Size = New System.Drawing.Size(80, 16)
Me.Label142.TabIndex = 233
Me.Label142.Text = "Sub System:"
'
'cboWorkpieceSubSystem
'
Me.cboWorkpieceSubSystem.Location = New System.Drawing.Point(88, 40)
Me.cboWorkpieceSubSystem.Name = "cboWorkpieceSubSystem"
Me.cboWorkpieceSubSystem.Size = New System.Drawing.Size(280, 21)
Me.cboWorkpieceSubSystem.TabIndex = 232
'
'Label256
'
Me.Label256.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label256.Location = New System.Drawing.Point(392, 40)
Me.Label256.Name = "Label256"
Me.Label256.Size = New System.Drawing.Size(80, 16)
Me.Label256.TabIndex = 231
Me.Label256.Text = "Data Unit :"
'
'cmb_WorkpieceDataunit
'
Me.cmb_WorkpieceDataunit.Location = New System.Drawing.Point(480, 40)
Me.cmb_WorkpieceDataunit.Name = "cmb_WorkpieceDataunit"
Me.cmb_WorkpieceDataunit.Size = New System.Drawing.Size(280, 21)
Me.cmb_WorkpieceDataunit.TabIndex = 230
'
'wkUpdateValsWithNoParams
'
Me.wkUpdateValsWithNoParams.Location = New System.Drawing.Point(328, 8)
Me.wkUpdateValsWithNoParams.Name = "wkUpdateValsWithNoParams"
Me.wkUpdateValsWithNoParams.Size = New System.Drawing.Size(72, 24)
Me.wkUpdateValsWithNoParams.TabIndex = 169
Me.wkUpdateValsWithNoParams.Text = "Set"
'
'Panel9
'
Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel9.Controls.Add(Me.wkGetZeroOffset)
Me.Panel9.Controls.Add(Me.wkUpdateZeroOffset)
Me.Panel9.Controls.Add(Me.wkZeroOffsetCombo)
Me.Panel9.Controls.Add(Me.Label94)
Me.Panel9.Controls.Add(Me.wkZeroOffset)
Me.Panel9.Controls.Add(Me.wkSetZeroOffset)
Me.Panel9.Controls.Add(Me.wkAddZeroOffset)
Me.Panel9.Controls.Add(Me.wkCalZeroOffset)
Me.Panel9.Location = New System.Drawing.Point(8, 152)
Me.Panel9.Name = "Panel9"
Me.Panel9.Size = New System.Drawing.Size(328, 72)
Me.Panel9.TabIndex = 173
'
'wkGetZeroOffset
'
Me.wkGetZeroOffset.Location = New System.Drawing.Point(112, 8)
Me.wkGetZeroOffset.Name = "wkGetZeroOffset"
Me.wkGetZeroOffset.Size = New System.Drawing.Size(40, 24)
Me.wkGetZeroOffset.TabIndex = 172
Me.wkGetZeroOffset.Text = "Get"
'
'wkUpdateZeroOffset
'
Me.wkUpdateZeroOffset.ForeColor = System.Drawing.Color.Red
Me.wkUpdateZeroOffset.Location = New System.Drawing.Point(80, 40)
Me.wkUpdateZeroOffset.Name = "wkUpdateZeroOffset"
Me.wkUpdateZeroOffset.Size = New System.Drawing.Size(64, 20)
Me.wkUpdateZeroOffset.TabIndex = 159
Me.wkUpdateZeroOffset.Text = "0.00"
'
'wkZeroOffsetCombo
'
Me.wkZeroOffsetCombo.Location = New System.Drawing.Point(152, 40)
Me.wkZeroOffsetCombo.Name = "wkZeroOffsetCombo"
Me.wkZeroOffsetCombo.Size = New System.Drawing.Size(168, 21)
Me.wkZeroOffsetCombo.TabIndex = 15
'
'Label94
'
Me.Label94.Location = New System.Drawing.Point(8, 16)
Me.Label94.Name = "Label94"
Me.Label94.Size = New System.Drawing.Size(80, 16)
Me.Label94.TabIndex = 157
Me.Label94.Text = "Zero Offsets :"
'
'wkZeroOffset
'
Me.wkZeroOffset.Location = New System.Drawing.Point(8, 40)
Me.wkZeroOffset.Name = "wkZeroOffset"
Me.wkZeroOffset.ReadOnly = true
Me.wkZeroOffset.Size = New System.Drawing.Size(64, 20)
Me.wkZeroOffset.TabIndex = 158
Me.wkZeroOffset.Text = "0.00"
'
'wkSetZeroOffset
'
Me.wkSetZeroOffset.Location = New System.Drawing.Point(168, 8)
Me.wkSetZeroOffset.Name = "wkSetZeroOffset"
Me.wkSetZeroOffset.Size = New System.Drawing.Size(40, 24)
Me.wkSetZeroOffset.TabIndex = 160
Me.wkSetZeroOffset.Text = "Set"
'
'wkAddZeroOffset
'
Me.wkAddZeroOffset.Location = New System.Drawing.Point(224, 8)
Me.wkAddZeroOffset.Name = "wkAddZeroOffset"
Me.wkAddZeroOffset.Size = New System.Drawing.Size(40, 24)
Me.wkAddZeroOffset.TabIndex = 161
Me.wkAddZeroOffset.Text = "Add"
'
'wkCalZeroOffset
'
Me.wkCalZeroOffset.Location = New System.Drawing.Point(280, 8)
Me.wkCalZeroOffset.Name = "wkCalZeroOffset"
Me.wkCalZeroOffset.Size = New System.Drawing.Size(40, 24)
Me.wkCalZeroOffset.TabIndex = 162
Me.wkCalZeroOffset.Text = "Cal"
'
'Panel10
'
Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel10.Controls.Add(Me.cmd_addWorkpiece)
Me.Panel10.Controls.Add(Me.Label95)
Me.Panel10.Controls.Add(Me.wkSetCounterValue)
Me.Panel10.Controls.Add(Me.wkCounterValue)
Me.Panel10.Controls.Add(Me.wkUpdateCounter)
Me.Panel10.Controls.Add(Me.wkGetCounterValue)
Me.Panel10.Controls.Add(Me.wkCounterCombo)
Me.Panel10.Location = New System.Drawing.Point(8, 72)
Me.Panel10.Name = "Panel10"
Me.Panel10.Size = New System.Drawing.Size(288, 72)
Me.Panel10.TabIndex = 175
'
'cmd_addWorkpiece
'
Me.cmd_addWorkpiece.Location = New System.Drawing.Point(232, 8)
Me.cmd_addWorkpiece.Name = "cmd_addWorkpiece"
Me.cmd_addWorkpiece.Size = New System.Drawing.Size(48, 23)
Me.cmd_addWorkpiece.TabIndex = 176
Me.cmd_addWorkpiece.Text = "Add"
'
'Label95
'
Me.Label95.Location = New System.Drawing.Point(0, 16)
Me.Label95.Name = "Label95"
Me.Label95.Size = New System.Drawing.Size(104, 16)
Me.Label95.TabIndex = 175
Me.Label95.Text = "Workpiece Counter"
'
'wkSetCounterValue
'
Me.wkSetCounterValue.Location = New System.Drawing.Point(176, 8)
Me.wkSetCounterValue.Name = "wkSetCounterValue"
Me.wkSetCounterValue.Size = New System.Drawing.Size(40, 24)
Me.wkSetCounterValue.TabIndex = 167
Me.wkSetCounterValue.Text = "Set"
'
'wkCounterValue
'
Me.wkCounterValue.Enabled = false
Me.wkCounterValue.Location = New System.Drawing.Point(8, 40)
Me.wkCounterValue.Name = "wkCounterValue"
Me.wkCounterValue.ReadOnly = true
Me.wkCounterValue.Size = New System.Drawing.Size(64, 20)
Me.wkCounterValue.TabIndex = 166
Me.wkCounterValue.Text = "0"
'
'wkUpdateCounter
'
Me.wkUpdateCounter.ForeColor = System.Drawing.Color.Red
Me.wkUpdateCounter.Location = New System.Drawing.Point(88, 40)
Me.wkUpdateCounter.Name = "wkUpdateCounter"
Me.wkUpdateCounter.Size = New System.Drawing.Size(64, 20)
Me.wkUpdateCounter.TabIndex = 164
Me.wkUpdateCounter.Text = "0"
'
'wkGetCounterValue
'
Me.wkGetCounterValue.Location = New System.Drawing.Point(120, 8)
Me.wkGetCounterValue.Name = "wkGetCounterValue"
Me.wkGetCounterValue.Size = New System.Drawing.Size(40, 24)
Me.wkGetCounterValue.TabIndex = 174
Me.wkGetCounterValue.Text = "Get"
'
'wkCounterCombo
'
Me.wkCounterCombo.Location = New System.Drawing.Point(168, 40)
Me.wkCounterCombo.Name = "wkCounterCombo"
Me.wkCounterCombo.Size = New System.Drawing.Size(112, 21)
Me.wkCounterCombo.TabIndex = 163
'
'tab_machine
'
Me.tab_machine.Controls.Add(Me.txtMachine)
Me.tab_machine.Controls.Add(Me.GroupBox19)
Me.tab_machine.Controls.Add(Me.cmb_Machine_SubSys)
Me.tab_machine.Controls.Add(Me.Label165)
Me.tab_machine.Controls.Add(Me.machineUpdateButton)
Me.tab_machine.Location = New System.Drawing.Point(4, 22)
Me.tab_machine.Name = "tab_machine"
Me.tab_machine.Size = New System.Drawing.Size(776, 446)
Me.tab_machine.TabIndex = 3
Me.tab_machine.Text = "Machine"
'
'txtMachine
'
Me.txtMachine.Location = New System.Drawing.Point(13, 42)
Me.txtMachine.Multiline = true
Me.txtMachine.Name = "txtMachine"
Me.txtMachine.Size = New System.Drawing.Size(374, 256)
Me.txtMachine.TabIndex = 87
Me.txtMachine.Text = ""
'
'GroupBox19
'
Me.GroupBox19.Controls.Add(Me.macMDICommand)
Me.GroupBox19.Controls.Add(Me.macMDIExecButton)
Me.GroupBox19.Location = New System.Drawing.Point(13, 305)
Me.GroupBox19.Name = "GroupBox19"
Me.GroupBox19.Size = New System.Drawing.Size(747, 56)
Me.GroupBox19.TabIndex = 82
Me.GroupBox19.TabStop = false
Me.GroupBox19.Text = "MDI"
'
'macMDICommand
'
Me.macMDICommand.BackColor = System.Drawing.Color.Yellow
Me.macMDICommand.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.macMDICommand.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.macMDICommand.ForeColor = System.Drawing.Color.Black
Me.macMDICommand.Location = New System.Drawing.Point(128, 24)
Me.macMDICommand.Name = "macMDICommand"
Me.macMDICommand.Size = New System.Drawing.Size(612, 24)
Me.macMDICommand.TabIndex = 77
Me.macMDICommand.Text = ""
'
'macMDIExecButton
'
Me.macMDIExecButton.Location = New System.Drawing.Point(8, 24)
Me.macMDIExecButton.Name = "macMDIExecButton"
Me.macMDIExecButton.Size = New System.Drawing.Size(112, 24)
Me.macMDIExecButton.TabIndex = 78
Me.macMDIExecButton.Text = "Execute MDI"
'
'cmb_Machine_SubSys
'
Me.cmb_Machine_SubSys.Location = New System.Drawing.Point(120, 8)
Me.cmb_Machine_SubSys.Name = "cmb_Machine_SubSys"
Me.cmb_Machine_SubSys.Size = New System.Drawing.Size(180, 21)
Me.cmb_Machine_SubSys.TabIndex = 80
'
'Label165
'
Me.Label165.Location = New System.Drawing.Point(16, 8)
Me.Label165.Name = "Label165"
Me.Label165.Size = New System.Drawing.Size(91, 16)
Me.Label165.TabIndex = 79
Me.Label165.Text = "Sub System : "
'
'machineUpdateButton
'
Me.machineUpdateButton.Location = New System.Drawing.Point(307, 7)
Me.machineUpdateButton.Name = "machineUpdateButton"
Me.machineUpdateButton.Size = New System.Drawing.Size(80, 24)
Me.machineUpdateButton.TabIndex = 75
Me.machineUpdateButton.Text = "Update"
'
'tab_axis_2
'
Me.tab_axis_2.Controls.Add(Me.cmdAxis2DataUnit)
Me.tab_axis_2.Controls.Add(Me.cboAxis2DataUnit)
Me.tab_axis_2.Controls.Add(Me.cmdAxis2SubSystem)
Me.tab_axis_2.Controls.Add(Me.cboAxis2SubSystem)
Me.tab_axis_2.Controls.Add(Me.GroupBox11)
Me.tab_axis_2.Controls.Add(Me.UserParameterDroopDataAxis)
Me.tab_axis_2.Location = New System.Drawing.Point(4, 22)
Me.tab_axis_2.Name = "tab_axis_2"
Me.tab_axis_2.Size = New System.Drawing.Size(776, 446)
Me.tab_axis_2.TabIndex = 26
Me.tab_axis_2.Text = "Axis 2"
'
'cmdAxis2DataUnit
'
Me.cmdAxis2DataUnit.Location = New System.Drawing.Point(432, 8)
Me.cmdAxis2DataUnit.Name = "cmdAxis2DataUnit"
Me.cmdAxis2DataUnit.Size = New System.Drawing.Size(96, 24)
Me.cmdAxis2DataUnit.TabIndex = 296
Me.cmdAxis2DataUnit.Text = "Set Data Unit"
'
'cboAxis2DataUnit
'
Me.cboAxis2DataUnit.ItemHeight = 13
Me.cboAxis2DataUnit.Location = New System.Drawing.Point(536, 8)
Me.cboAxis2DataUnit.Name = "cboAxis2DataUnit"
Me.cboAxis2DataUnit.Size = New System.Drawing.Size(224, 21)
Me.cboAxis2DataUnit.TabIndex = 294
'
'cmdAxis2SubSystem
'
Me.cmdAxis2SubSystem.Location = New System.Drawing.Point(16, 8)
Me.cmdAxis2SubSystem.Name = "cmdAxis2SubSystem"
Me.cmdAxis2SubSystem.Size = New System.Drawing.Size(184, 24)
Me.cmdAxis2SubSystem.TabIndex = 105
Me.cmdAxis2SubSystem.Text = "Sub System"
'
'cboAxis2SubSystem
'
Me.cboAxis2SubSystem.ItemHeight = 13
Me.cboAxis2SubSystem.Location = New System.Drawing.Point(216, 8)
Me.cboAxis2SubSystem.Name = "cboAxis2SubSystem"
Me.cboAxis2SubSystem.Size = New System.Drawing.Size(184, 21)
Me.cboAxis2SubSystem.TabIndex = 104
'
'GroupBox11
'
Me.GroupBox11.Controls.Add(Me.Label291)
Me.GroupBox11.Controls.Add(Me.cboUserParameterVariableLimitCoordinate)
Me.GroupBox11.Controls.Add(Me.txtUserParameterLimitInput)
Me.GroupBox11.Controls.Add(Me.txtUserParameterLimit)
Me.GroupBox11.Controls.Add(Me.Label215)
Me.GroupBox11.Controls.Add(Me.cmdUserParameterVariableLimitAdd)
Me.GroupBox11.Controls.Add(Me.cmdUserParameterVariableLimitSet)
Me.GroupBox11.Controls.Add(Me.cmdUserParameterVariableLimitGet)
Me.GroupBox11.Controls.Add(Me.Label214)
Me.GroupBox11.Controls.Add(Me.cboUserParameterVariableLimitAxis)
Me.GroupBox11.Location = New System.Drawing.Point(8, 120)
Me.GroupBox11.Name = "GroupBox11"
Me.GroupBox11.Size = New System.Drawing.Size(752, 88)
Me.GroupBox11.TabIndex = 6
Me.GroupBox11.TabStop = false
Me.GroupBox11.Text = "Variable Limit"
'
'Label291
'
Me.Label291.Location = New System.Drawing.Point(312, 24)
Me.Label291.Name = "Label291"
Me.Label291.Size = New System.Drawing.Size(144, 24)
Me.Label291.TabIndex = 15
Me.Label291.Text = "Variable Limit Coordinate"
'
'cboUserParameterVariableLimitCoordinate
'
Me.cboUserParameterVariableLimitCoordinate.Location = New System.Drawing.Point(472, 24)
Me.cboUserParameterVariableLimitCoordinate.Name = "cboUserParameterVariableLimitCoordinate"
Me.cboUserParameterVariableLimitCoordinate.Size = New System.Drawing.Size(216, 21)
Me.cboUserParameterVariableLimitCoordinate.TabIndex = 14
'
'txtUserParameterLimitInput
'
Me.txtUserParameterLimitInput.ForeColor = System.Drawing.Color.Red
Me.txtUserParameterLimitInput.Location = New System.Drawing.Point(320, 56)
Me.txtUserParameterLimitInput.Name = "txtUserParameterLimitInput"
Me.txtUserParameterLimitInput.Size = New System.Drawing.Size(96, 20)
Me.txtUserParameterLimitInput.TabIndex = 13
Me.txtUserParameterLimitInput.Text = "0.0"
'
'txtUserParameterLimit
'
Me.txtUserParameterLimit.Location = New System.Drawing.Point(200, 56)
Me.txtUserParameterLimit.Name = "txtUserParameterLimit"
Me.txtUserParameterLimit.ReadOnly = true
Me.txtUserParameterLimit.Size = New System.Drawing.Size(104, 20)
Me.txtUserParameterLimit.TabIndex = 12
Me.txtUserParameterLimit.Text = "0.0"
'
'Label215
'
Me.Label215.Location = New System.Drawing.Point(8, 56)
Me.Label215.Name = "Label215"
Me.Label215.Size = New System.Drawing.Size(176, 24)
Me.Label215.TabIndex = 8
Me.Label215.Text = "User Parameter Variable Limit"
'
'cmdUserParameterVariableLimitAdd
'
Me.cmdUserParameterVariableLimitAdd.Location = New System.Drawing.Point(592, 56)
Me.cmdUserParameterVariableLimitAdd.Name = "cmdUserParameterVariableLimitAdd"
Me.cmdUserParameterVariableLimitAdd.Size = New System.Drawing.Size(64, 24)
Me.cmdUserParameterVariableLimitAdd.TabIndex = 10
Me.cmdUserParameterVariableLimitAdd.Text = "Add"
'
'cmdUserParameterVariableLimitSet
'
Me.cmdUserParameterVariableLimitSet.Location = New System.Drawing.Point(512, 56)
Me.cmdUserParameterVariableLimitSet.Name = "cmdUserParameterVariableLimitSet"
Me.cmdUserParameterVariableLimitSet.Size = New System.Drawing.Size(64, 24)
Me.cmdUserParameterVariableLimitSet.TabIndex = 9
Me.cmdUserParameterVariableLimitSet.Text = "Set"
'
'cmdUserParameterVariableLimitGet
'
Me.cmdUserParameterVariableLimitGet.Location = New System.Drawing.Point(432, 56)
Me.cmdUserParameterVariableLimitGet.Name = "cmdUserParameterVariableLimitGet"
Me.cmdUserParameterVariableLimitGet.Size = New System.Drawing.Size(64, 24)
Me.cmdUserParameterVariableLimitGet.TabIndex = 11
Me.cmdUserParameterVariableLimitGet.Text = "Get"
'
'Label214
'
Me.Label214.Location = New System.Drawing.Point(8, 24)
Me.Label214.Name = "Label214"
Me.Label214.Size = New System.Drawing.Size(64, 24)
Me.Label214.TabIndex = 1
Me.Label214.Text = "Axis Index"
'
'cboUserParameterVariableLimitAxis
'
Me.cboUserParameterVariableLimitAxis.Location = New System.Drawing.Point(80, 24)
Me.cboUserParameterVariableLimitAxis.Name = "cboUserParameterVariableLimitAxis"
Me.cboUserParameterVariableLimitAxis.Size = New System.Drawing.Size(184, 21)
Me.cboUserParameterVariableLimitAxis.TabIndex = 0
'
'UserParameterDroopDataAxis
'
Me.UserParameterDroopDataAxis.Controls.Add(Me.txtUserParameterDroopDataInput)
Me.UserParameterDroopDataAxis.Controls.Add(Me.Label179)
Me.UserParameterDroopDataAxis.Controls.Add(Me.cboAxis2UserParameterDroopData)
Me.UserParameterDroopDataAxis.Controls.Add(Me.txtUserParameterDroopData)
Me.UserParameterDroopDataAxis.Controls.Add(Me.Label177)
Me.UserParameterDroopDataAxis.Controls.Add(Me.cmdUserParameterDroopDataAdd)
Me.UserParameterDroopDataAxis.Controls.Add(Me.cmdUserParameterDroopDataSet)
Me.UserParameterDroopDataAxis.Controls.Add(Me.cmdUserParameterDroopDataGet)
Me.UserParameterDroopDataAxis.Location = New System.Drawing.Point(8, 40)
Me.UserParameterDroopDataAxis.Name = "UserParameterDroopDataAxis"
Me.UserParameterDroopDataAxis.Size = New System.Drawing.Size(752, 80)
Me.UserParameterDroopDataAxis.TabIndex = 5
Me.UserParameterDroopDataAxis.TabStop = false
Me.UserParameterDroopDataAxis.Text = "UserParameterDroopData"
'
'txtUserParameterDroopDataInput
'
Me.txtUserParameterDroopDataInput.ForeColor = System.Drawing.Color.Red
Me.txtUserParameterDroopDataInput.Location = New System.Drawing.Point(608, 16)
Me.txtUserParameterDroopDataInput.Name = "txtUserParameterDroopDataInput"
Me.txtUserParameterDroopDataInput.Size = New System.Drawing.Size(96, 20)
Me.txtUserParameterDroopDataInput.TabIndex = 7
Me.txtUserParameterDroopDataInput.Text = "0.0"
'
'Label179
'
Me.Label179.Location = New System.Drawing.Point(8, 24)
Me.Label179.Name = "Label179"
Me.Label179.Size = New System.Drawing.Size(64, 24)
Me.Label179.TabIndex = 6
Me.Label179.Text = "Axis Index"
'
'cboAxis2UserParameterDroopData
'
Me.cboAxis2UserParameterDroopData.Location = New System.Drawing.Point(80, 24)
Me.cboAxis2UserParameterDroopData.Name = "cboAxis2UserParameterDroopData"
Me.cboAxis2UserParameterDroopData.Size = New System.Drawing.Size(192, 21)
Me.cboAxis2UserParameterDroopData.TabIndex = 5
'
'txtUserParameterDroopData
'
Me.txtUserParameterDroopData.Location = New System.Drawing.Point(488, 16)
Me.txtUserParameterDroopData.Name = "txtUserParameterDroopData"
Me.txtUserParameterDroopData.ReadOnly = true
Me.txtUserParameterDroopData.Size = New System.Drawing.Size(104, 20)
Me.txtUserParameterDroopData.TabIndex = 4
Me.txtUserParameterDroopData.Text = "0.0"
'
'Label177
'
Me.Label177.Location = New System.Drawing.Point(296, 16)
Me.Label177.Name = "Label177"
Me.Label177.Size = New System.Drawing.Size(176, 24)
Me.Label177.TabIndex = 0
Me.Label177.Text = "User Parameter Droop Data"
'
'cmdUserParameterDroopDataAdd
'
Me.cmdUserParameterDroopDataAdd.Location = New System.Drawing.Point(640, 48)
Me.cmdUserParameterDroopDataAdd.Name = "cmdUserParameterDroopDataAdd"
Me.cmdUserParameterDroopDataAdd.Size = New System.Drawing.Size(64, 24)
Me.cmdUserParameterDroopDataAdd.TabIndex = 2
Me.cmdUserParameterDroopDataAdd.Text = "Add"
'
'cmdUserParameterDroopDataSet
'
Me.cmdUserParameterDroopDataSet.Location = New System.Drawing.Point(568, 48)
Me.cmdUserParameterDroopDataSet.Name = "cmdUserParameterDroopDataSet"
Me.cmdUserParameterDroopDataSet.Size = New System.Drawing.Size(64, 24)
Me.cmdUserParameterDroopDataSet.TabIndex = 1
Me.cmdUserParameterDroopDataSet.Text = "Set"
'
'cmdUserParameterDroopDataGet
'
Me.cmdUserParameterDroopDataGet.Location = New System.Drawing.Point(496, 48)
Me.cmdUserParameterDroopDataGet.Name = "cmdUserParameterDroopDataGet"
Me.cmdUserParameterDroopDataGet.Size = New System.Drawing.Size(64, 24)
Me.cmdUserParameterDroopDataGet.TabIndex = 3
Me.cmdUserParameterDroopDataGet.Text = "Get"
'
'tab_MultiTools
'
Me.tab_MultiTools.Controls.Add(Me.Label141)
Me.tab_MultiTools.Controls.Add(Me.Panel)
Me.tab_MultiTools.Location = New System.Drawing.Point(4, 22)
Me.tab_MultiTools.Name = "tab_MultiTools"
Me.tab_MultiTools.Size = New System.Drawing.Size(776, 446)
Me.tab_MultiTools.TabIndex = 31
Me.tab_MultiTools.Text = "Multi-Tool"
'
'Label141
'
Me.Label141.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label141.ForeColor = System.Drawing.Color.Red
Me.Label141.Location = New System.Drawing.Point(13, 7)
Me.Label141.Name = "Label141"
Me.Label141.Size = New System.Drawing.Size(754, 28)
Me.Label141.TabIndex = 238
Me.Label141.Text = "For Lathe machine that has Multi-Tools system only."
'
'Panel
'
Me.Panel.Controls.Add(Me.GroupBox21)
Me.Panel.Controls.Add(Me.cmdMultiTool_EntryToolNoGet)
Me.Panel.Controls.Add(Me.txtMultiTool_EntryToolNo)
Me.Panel.Controls.Add(Me.Label321)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolInGroupGet)
Me.Panel.Controls.Add(Me.txtMultiTool_ToolInGroupValue)
Me.Panel.Controls.Add(Me.txtMultiTool_ToolInGroup)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolInGroupSet)
Me.Panel.Controls.Add(Me.Label320)
Me.Panel.Controls.Add(Me.cmdMultiTool_GroupNoGet)
Me.Panel.Controls.Add(Me.txtMultiTool_GroupNoValue)
Me.Panel.Controls.Add(Me.txtMultiTool_GroupNo)
Me.Panel.Controls.Add(Me.cmdMultiTool_GroupNoSet)
Me.Panel.Controls.Add(Me.Label319)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolRef3Get)
Me.Panel.Controls.Add(Me.txtMultiTool_ToolRef3Value)
Me.Panel.Controls.Add(Me.txtMultiTool_ToolRef3)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolRef3Set)
Me.Panel.Controls.Add(Me.Label318)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolRef2Get)
Me.Panel.Controls.Add(Me.txtMultiTool_ToolRef2Value)
Me.Panel.Controls.Add(Me.txtMultiTool_ToolRef2)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolRef2Set)
Me.Panel.Controls.Add(Me.Label317)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolRef1Get)
Me.Panel.Controls.Add(Me.txtMultiTool_ToolRef1Value)
Me.Panel.Controls.Add(Me.txtMultiTool_ToolRef1)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolRef1Set)
Me.Panel.Controls.Add(Me.Label316)
Me.Panel.Controls.Add(Me.cmdMultiTool_GroupEdgeGet)
Me.Panel.Controls.Add(Me.txtMultiTool_GroupEdgeValue)
Me.Panel.Controls.Add(Me.txtMultiTool_GroupEdge)
Me.Panel.Controls.Add(Me.cmdMultiTool_GroupEdgeSet)
Me.Panel.Controls.Add(Me.Label35)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolGroupLifeGet)
Me.Panel.Controls.Add(Me.txtMultiTool_ToolGroupLifeValue)
Me.Panel.Controls.Add(Me.txtMultiTool_ToolGroupLife)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolGroupLifeSet)
Me.Panel.Controls.Add(Me.Label34)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolLifeStatusGet)
Me.Panel.Controls.Add(Me.txtMultiTool_ToolLifeStatusValue)
Me.Panel.Controls.Add(Me.txtMultiTool_ToolLifeStatus)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolLifeStatusSet)
Me.Panel.Controls.Add(Me.Label33)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolGaugeGet)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolLifeActualGet)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolSetGet)
Me.Panel.Controls.Add(Me.cboMultiToolSubSystem)
Me.Panel.Controls.Add(Me.txtMultiTool_ToolLifeGaugeValue)
Me.Panel.Controls.Add(Me.txtMultiTool_ToolLifeGauge)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolGaugeSet)
Me.Panel.Controls.Add(Me.Label32)
Me.Panel.Controls.Add(Me.Label242)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolLifeActualAdd)
Me.Panel.Controls.Add(Me.txtMultiTool_ToolLifeActualValue)
Me.Panel.Controls.Add(Me.txtMultiTool_ToolLifeActual)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolLifeActualSet)
Me.Panel.Controls.Add(Me.Label185)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolSetAdd)
Me.Panel.Controls.Add(Me.txtMultiTool_ToolLifeSetValue)
Me.Panel.Controls.Add(Me.txtMultiTool_ToolLifeSet)
Me.Panel.Controls.Add(Me.cmdMultiTool_ToolSetSet)
Me.Panel.Controls.Add(Me.Label187)
Me.Panel.Controls.Add(Me.cboMultiToolEdges)
Me.Panel.Controls.Add(Me.Label190)
Me.Panel.Location = New System.Drawing.Point(13, 42)
Me.Panel.Name = "Panel"
Me.Panel.Size = New System.Drawing.Size(747, 402)
Me.Panel.TabIndex = 237
'
'GroupBox21
'
Me.GroupBox21.Controls.Add(Me.txtMultiTool_EntryToolNoInput)
Me.GroupBox21.Controls.Add(Me.Label325)
Me.GroupBox21.Controls.Add(Me.txtMultiTool_GroupNoInput)
Me.GroupBox21.Controls.Add(Me.Label322)
Me.GroupBox21.Controls.Add(Me.txt_edgenumber)
Me.GroupBox21.Controls.Add(Me.Label186)
Me.GroupBox21.Controls.Add(Me.Label188)
Me.GroupBox21.Controls.Add(Me.Label189)
Me.GroupBox21.Controls.Add(Me.cboMultiToolLifeCondition)
Me.GroupBox21.Controls.Add(Me.cboMultiToolHolder)
Me.GroupBox21.Location = New System.Drawing.Point(7, 35)
Me.GroupBox21.Name = "GroupBox21"
Me.GroupBox21.Size = New System.Drawing.Size(733, 83)
Me.GroupBox21.TabIndex = 288
Me.GroupBox21.TabStop = false
Me.GroupBox21.Text = "Input Tool Data"
'
'txtMultiTool_EntryToolNoInput
'
Me.txtMultiTool_EntryToolNoInput.Location = New System.Drawing.Point(533, 49)
Me.txtMultiTool_EntryToolNoInput.Name = "txtMultiTool_EntryToolNoInput"
Me.txtMultiTool_EntryToolNoInput.Size = New System.Drawing.Size(80, 20)
Me.txtMultiTool_EntryToolNoInput.TabIndex = 230
Me.txtMultiTool_EntryToolNoInput.Text = "1"
'
'Label325
'
Me.Label325.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label325.Location = New System.Drawing.Point(533, 21)
Me.Label325.Name = "Label325"
Me.Label325.Size = New System.Drawing.Size(94, 16)
Me.Label325.TabIndex = 229
Me.Label325.Text = "Entry Tool  No."
'
'txtMultiTool_GroupNoInput
'
Me.txtMultiTool_GroupNoInput.Location = New System.Drawing.Point(447, 49)
Me.txtMultiTool_GroupNoInput.Name = "txtMultiTool_GroupNoInput"
Me.txtMultiTool_GroupNoInput.Size = New System.Drawing.Size(80, 20)
Me.txtMultiTool_GroupNoInput.TabIndex = 228
Me.txtMultiTool_GroupNoInput.Text = "1"
'
'Label322
'
Me.Label322.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label322.Location = New System.Drawing.Point(447, 21)
Me.Label322.Name = "Label322"
Me.Label322.Size = New System.Drawing.Size(80, 16)
Me.Label322.TabIndex = 227
Me.Label322.Text = "Group No."
'
'txt_edgenumber
'
Me.txt_edgenumber.Location = New System.Drawing.Point(7, 49)
Me.txt_edgenumber.Name = "txt_edgenumber"
Me.txt_edgenumber.Size = New System.Drawing.Size(80, 20)
Me.txt_edgenumber.TabIndex = 226
Me.txt_edgenumber.Text = "1"
'
'Label186
'
Me.Label186.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label186.Location = New System.Drawing.Point(7, 21)
Me.Label186.Name = "Label186"
Me.Label186.Size = New System.Drawing.Size(80, 16)
Me.Label186.TabIndex = 225
Me.Label186.Text = "Edge number"
'
'Label188
'
Me.Label188.Location = New System.Drawing.Point(100, 21)
Me.Label188.Name = "Label188"
Me.Label188.Size = New System.Drawing.Size(56, 21)
Me.Label188.TabIndex = 218
Me.Label188.Text = "Condition"
'
'Label189
'
Me.Label189.Location = New System.Drawing.Point(280, 21)
Me.Label189.Name = "Label189"
Me.Label189.Size = New System.Drawing.Size(47, 11)
Me.Label189.TabIndex = 217
Me.Label189.Text = "Holder"
'
'cboMultiToolLifeCondition
'
Me.cboMultiToolLifeCondition.Location = New System.Drawing.Point(100, 49)
Me.cboMultiToolLifeCondition.Name = "cboMultiToolLifeCondition"
Me.cboMultiToolLifeCondition.Size = New System.Drawing.Size(171, 21)
Me.cboMultiToolLifeCondition.TabIndex = 216
'
'cboMultiToolHolder
'
Me.cboMultiToolHolder.Location = New System.Drawing.Point(280, 49)
Me.cboMultiToolHolder.Name = "cboMultiToolHolder"
Me.cboMultiToolHolder.Size = New System.Drawing.Size(160, 21)
Me.cboMultiToolHolder.TabIndex = 215
'
'cmdMultiTool_EntryToolNoGet
'
Me.cmdMultiTool_EntryToolNoGet.Location = New System.Drawing.Point(253, 347)
Me.cmdMultiTool_EntryToolNoGet.Name = "cmdMultiTool_EntryToolNoGet"
Me.cmdMultiTool_EntryToolNoGet.Size = New System.Drawing.Size(40, 24)
Me.cmdMultiTool_EntryToolNoGet.TabIndex = 287
Me.cmdMultiTool_EntryToolNoGet.Text = "Get"
'
'txtMultiTool_EntryToolNo
'
Me.txtMultiTool_EntryToolNo.Location = New System.Drawing.Point(113, 347)
Me.txtMultiTool_EntryToolNo.Name = "txtMultiTool_EntryToolNo"
Me.txtMultiTool_EntryToolNo.ReadOnly = true
Me.txtMultiTool_EntryToolNo.Size = New System.Drawing.Size(64, 20)
Me.txtMultiTool_EntryToolNo.TabIndex = 285
Me.txtMultiTool_EntryToolNo.Text = "0"
'
'Label321
'
Me.Label321.Location = New System.Drawing.Point(7, 347)
Me.Label321.Name = "Label321"
Me.Label321.Size = New System.Drawing.Size(95, 15)
Me.Label321.TabIndex = 283
Me.Label321.Text = "Entry Tool No:"
'
'cmdMultiTool_ToolInGroupGet
'
Me.cmdMultiTool_ToolInGroupGet.Location = New System.Drawing.Point(253, 263)
Me.cmdMultiTool_ToolInGroupGet.Name = "cmdMultiTool_ToolInGroupGet"
Me.cmdMultiTool_ToolInGroupGet.Size = New System.Drawing.Size(40, 25)
Me.cmdMultiTool_ToolInGroupGet.TabIndex = 282
Me.cmdMultiTool_ToolInGroupGet.Text = "Get"
'
'txtMultiTool_ToolInGroupValue
'
Me.txtMultiTool_ToolInGroupValue.ForeColor = System.Drawing.Color.Red
Me.txtMultiTool_ToolInGroupValue.Location = New System.Drawing.Point(187, 263)
Me.txtMultiTool_ToolInGroupValue.Name = "txtMultiTool_ToolInGroupValue"
Me.txtMultiTool_ToolInGroupValue.Size = New System.Drawing.Size(55, 20)
Me.txtMultiTool_ToolInGroupValue.TabIndex = 281
Me.txtMultiTool_ToolInGroupValue.Text = "0"
'
'txtMultiTool_ToolInGroup
'
Me.txtMultiTool_ToolInGroup.Location = New System.Drawing.Point(113, 263)
Me.txtMultiTool_ToolInGroup.Name = "txtMultiTool_ToolInGroup"
Me.txtMultiTool_ToolInGroup.ReadOnly = true
Me.txtMultiTool_ToolInGroup.Size = New System.Drawing.Size(64, 20)
Me.txtMultiTool_ToolInGroup.TabIndex = 280
Me.txtMultiTool_ToolInGroup.Text = "0"
'
'cmdMultiTool_ToolInGroupSet
'
Me.cmdMultiTool_ToolInGroupSet.Location = New System.Drawing.Point(300, 263)
Me.cmdMultiTool_ToolInGroupSet.Name = "cmdMultiTool_ToolInGroupSet"
Me.cmdMultiTool_ToolInGroupSet.Size = New System.Drawing.Size(40, 25)
Me.cmdMultiTool_ToolInGroupSet.TabIndex = 279
Me.cmdMultiTool_ToolInGroupSet.Text = "Set"
'
'Label320
'
Me.Label320.Location = New System.Drawing.Point(7, 263)
Me.Label320.Name = "Label320"
Me.Label320.Size = New System.Drawing.Size(95, 16)
Me.Label320.TabIndex = 278
Me.Label320.Text = "Tool in group:"
'
'cmdMultiTool_GroupNoGet
'
Me.cmdMultiTool_GroupNoGet.Location = New System.Drawing.Point(253, 125)
Me.cmdMultiTool_GroupNoGet.Name = "cmdMultiTool_GroupNoGet"
Me.cmdMultiTool_GroupNoGet.Size = New System.Drawing.Size(40, 24)
Me.cmdMultiTool_GroupNoGet.TabIndex = 277
Me.cmdMultiTool_GroupNoGet.Text = "Get"
'
'txtMultiTool_GroupNoValue
'
Me.txtMultiTool_GroupNoValue.ForeColor = System.Drawing.Color.Red
Me.txtMultiTool_GroupNoValue.Location = New System.Drawing.Point(187, 125)
Me.txtMultiTool_GroupNoValue.Name = "txtMultiTool_GroupNoValue"
Me.txtMultiTool_GroupNoValue.Size = New System.Drawing.Size(55, 20)
Me.txtMultiTool_GroupNoValue.TabIndex = 276
Me.txtMultiTool_GroupNoValue.Text = "0"
'
'txtMultiTool_GroupNo
'
Me.txtMultiTool_GroupNo.Location = New System.Drawing.Point(113, 125)
Me.txtMultiTool_GroupNo.Name = "txtMultiTool_GroupNo"
Me.txtMultiTool_GroupNo.ReadOnly = true
Me.txtMultiTool_GroupNo.Size = New System.Drawing.Size(64, 20)
Me.txtMultiTool_GroupNo.TabIndex = 275
Me.txtMultiTool_GroupNo.Text = "0"
'
'cmdMultiTool_GroupNoSet
'
Me.cmdMultiTool_GroupNoSet.Location = New System.Drawing.Point(300, 125)
Me.cmdMultiTool_GroupNoSet.Name = "cmdMultiTool_GroupNoSet"
Me.cmdMultiTool_GroupNoSet.Size = New System.Drawing.Size(40, 24)
Me.cmdMultiTool_GroupNoSet.TabIndex = 274
Me.cmdMultiTool_GroupNoSet.Text = "Set"
'
'Label319
'
Me.Label319.Location = New System.Drawing.Point(7, 125)
Me.Label319.Name = "Label319"
Me.Label319.Size = New System.Drawing.Size(95, 15)
Me.Label319.TabIndex = 273
Me.Label319.Text = "Tool Group:"
'
'cmdMultiTool_ToolRef3Get
'
Me.cmdMultiTool_ToolRef3Get.Location = New System.Drawing.Point(653, 180)
Me.cmdMultiTool_ToolRef3Get.Name = "cmdMultiTool_ToolRef3Get"
Me.cmdMultiTool_ToolRef3Get.Size = New System.Drawing.Size(40, 25)
Me.cmdMultiTool_ToolRef3Get.TabIndex = 272
Me.cmdMultiTool_ToolRef3Get.Text = "Get"
'
'txtMultiTool_ToolRef3Value
'
Me.txtMultiTool_ToolRef3Value.ForeColor = System.Drawing.Color.Red
Me.txtMultiTool_ToolRef3Value.Location = New System.Drawing.Point(613, 180)
Me.txtMultiTool_ToolRef3Value.Name = "txtMultiTool_ToolRef3Value"
Me.txtMultiTool_ToolRef3Value.Size = New System.Drawing.Size(34, 20)
Me.txtMultiTool_ToolRef3Value.TabIndex = 271
Me.txtMultiTool_ToolRef3Value.Text = "0"
'
'txtMultiTool_ToolRef3
'
Me.txtMultiTool_ToolRef3.Location = New System.Drawing.Point(567, 180)
Me.txtMultiTool_ToolRef3.Name = "txtMultiTool_ToolRef3"
Me.txtMultiTool_ToolRef3.ReadOnly = true
Me.txtMultiTool_ToolRef3.Size = New System.Drawing.Size(40, 20)
Me.txtMultiTool_ToolRef3.TabIndex = 270
Me.txtMultiTool_ToolRef3.Text = "0"
'
'cmdMultiTool_ToolRef3Set
'
Me.cmdMultiTool_ToolRef3Set.Location = New System.Drawing.Point(700, 180)
Me.cmdMultiTool_ToolRef3Set.Name = "cmdMultiTool_ToolRef3Set"
Me.cmdMultiTool_ToolRef3Set.Size = New System.Drawing.Size(40, 25)
Me.cmdMultiTool_ToolRef3Set.TabIndex = 269
Me.cmdMultiTool_ToolRef3Set.Text = "Set"
'
'Label318
'
Me.Label318.Location = New System.Drawing.Point(447, 180)
Me.Label318.Name = "Label318"
Me.Label318.Size = New System.Drawing.Size(113, 16)
Me.Label318.TabIndex = 268
Me.Label318.Text = "Reference Offset 3"
'
'cmdMultiTool_ToolRef2Get
'
Me.cmdMultiTool_ToolRef2Get.Location = New System.Drawing.Point(653, 153)
Me.cmdMultiTool_ToolRef2Get.Name = "cmdMultiTool_ToolRef2Get"
Me.cmdMultiTool_ToolRef2Get.Size = New System.Drawing.Size(40, 24)
Me.cmdMultiTool_ToolRef2Get.TabIndex = 267
Me.cmdMultiTool_ToolRef2Get.Text = "Get"
'
'txtMultiTool_ToolRef2Value
'
Me.txtMultiTool_ToolRef2Value.ForeColor = System.Drawing.Color.Red
Me.txtMultiTool_ToolRef2Value.Location = New System.Drawing.Point(613, 153)
Me.txtMultiTool_ToolRef2Value.Name = "txtMultiTool_ToolRef2Value"
Me.txtMultiTool_ToolRef2Value.Size = New System.Drawing.Size(34, 20)
Me.txtMultiTool_ToolRef2Value.TabIndex = 266
Me.txtMultiTool_ToolRef2Value.Text = "0"
'
'txtMultiTool_ToolRef2
'
Me.txtMultiTool_ToolRef2.Location = New System.Drawing.Point(567, 153)
Me.txtMultiTool_ToolRef2.Name = "txtMultiTool_ToolRef2"
Me.txtMultiTool_ToolRef2.ReadOnly = true
Me.txtMultiTool_ToolRef2.Size = New System.Drawing.Size(40, 20)
Me.txtMultiTool_ToolRef2.TabIndex = 265
Me.txtMultiTool_ToolRef2.Text = "0"
'
'cmdMultiTool_ToolRef2Set
'
Me.cmdMultiTool_ToolRef2Set.Location = New System.Drawing.Point(700, 153)
Me.cmdMultiTool_ToolRef2Set.Name = "cmdMultiTool_ToolRef2Set"
Me.cmdMultiTool_ToolRef2Set.Size = New System.Drawing.Size(40, 24)
Me.cmdMultiTool_ToolRef2Set.TabIndex = 264
Me.cmdMultiTool_ToolRef2Set.Text = "Set"
'
'Label317
'
Me.Label317.Location = New System.Drawing.Point(447, 153)
Me.Label317.Name = "Label317"
Me.Label317.Size = New System.Drawing.Size(113, 15)
Me.Label317.TabIndex = 263
Me.Label317.Text = "Reference Offset 2"
'
'cmdMultiTool_ToolRef1Get
'
Me.cmdMultiTool_ToolRef1Get.Location = New System.Drawing.Point(653, 125)
Me.cmdMultiTool_ToolRef1Get.Name = "cmdMultiTool_ToolRef1Get"
Me.cmdMultiTool_ToolRef1Get.Size = New System.Drawing.Size(40, 24)
Me.cmdMultiTool_ToolRef1Get.TabIndex = 262
Me.cmdMultiTool_ToolRef1Get.Text = "Get"
'
'txtMultiTool_ToolRef1Value
'
Me.txtMultiTool_ToolRef1Value.ForeColor = System.Drawing.Color.Red
Me.txtMultiTool_ToolRef1Value.Location = New System.Drawing.Point(613, 125)
Me.txtMultiTool_ToolRef1Value.Name = "txtMultiTool_ToolRef1Value"
Me.txtMultiTool_ToolRef1Value.Size = New System.Drawing.Size(34, 20)
Me.txtMultiTool_ToolRef1Value.TabIndex = 261
Me.txtMultiTool_ToolRef1Value.Text = "0"
'
'txtMultiTool_ToolRef1
'
Me.txtMultiTool_ToolRef1.Location = New System.Drawing.Point(567, 125)
Me.txtMultiTool_ToolRef1.Name = "txtMultiTool_ToolRef1"
Me.txtMultiTool_ToolRef1.ReadOnly = true
Me.txtMultiTool_ToolRef1.Size = New System.Drawing.Size(40, 20)
Me.txtMultiTool_ToolRef1.TabIndex = 260
Me.txtMultiTool_ToolRef1.Text = "0"
'
'cmdMultiTool_ToolRef1Set
'
Me.cmdMultiTool_ToolRef1Set.Location = New System.Drawing.Point(700, 125)
Me.cmdMultiTool_ToolRef1Set.Name = "cmdMultiTool_ToolRef1Set"
Me.cmdMultiTool_ToolRef1Set.Size = New System.Drawing.Size(40, 24)
Me.cmdMultiTool_ToolRef1Set.TabIndex = 259
Me.cmdMultiTool_ToolRef1Set.Text = "Set"
'
'Label316
'
Me.Label316.Location = New System.Drawing.Point(447, 125)
Me.Label316.Name = "Label316"
Me.Label316.Size = New System.Drawing.Size(113, 15)
Me.Label316.TabIndex = 258
Me.Label316.Text = "Reference Offset 1"
'
'cmdMultiTool_GroupEdgeGet
'
Me.cmdMultiTool_GroupEdgeGet.Location = New System.Drawing.Point(253, 291)
Me.cmdMultiTool_GroupEdgeGet.Name = "cmdMultiTool_GroupEdgeGet"
Me.cmdMultiTool_GroupEdgeGet.Size = New System.Drawing.Size(40, 24)
Me.cmdMultiTool_GroupEdgeGet.TabIndex = 257
Me.cmdMultiTool_GroupEdgeGet.Text = "Get"
'
'txtMultiTool_GroupEdgeValue
'
Me.txtMultiTool_GroupEdgeValue.ForeColor = System.Drawing.Color.Red
Me.txtMultiTool_GroupEdgeValue.Location = New System.Drawing.Point(187, 291)
Me.txtMultiTool_GroupEdgeValue.Name = "txtMultiTool_GroupEdgeValue"
Me.txtMultiTool_GroupEdgeValue.Size = New System.Drawing.Size(55, 20)
Me.txtMultiTool_GroupEdgeValue.TabIndex = 256
Me.txtMultiTool_GroupEdgeValue.Text = "0"
'
'txtMultiTool_GroupEdge
'
Me.txtMultiTool_GroupEdge.Location = New System.Drawing.Point(113, 291)
Me.txtMultiTool_GroupEdge.Name = "txtMultiTool_GroupEdge"
Me.txtMultiTool_GroupEdge.ReadOnly = true
Me.txtMultiTool_GroupEdge.Size = New System.Drawing.Size(64, 20)
Me.txtMultiTool_GroupEdge.TabIndex = 255
Me.txtMultiTool_GroupEdge.Text = "0"
'
'cmdMultiTool_GroupEdgeSet
'
Me.cmdMultiTool_GroupEdgeSet.Location = New System.Drawing.Point(300, 291)
Me.cmdMultiTool_GroupEdgeSet.Name = "cmdMultiTool_GroupEdgeSet"
Me.cmdMultiTool_GroupEdgeSet.Size = New System.Drawing.Size(40, 24)
Me.cmdMultiTool_GroupEdgeSet.TabIndex = 254
Me.cmdMultiTool_GroupEdgeSet.Text = "Set"
'
'Label35
'
Me.Label35.Location = New System.Drawing.Point(7, 291)
Me.Label35.Name = "Label35"
Me.Label35.Size = New System.Drawing.Size(95, 16)
Me.Label35.TabIndex = 253
Me.Label35.Text = "Current Edge:"
'
'cmdMultiTool_ToolGroupLifeGet
'
Me.cmdMultiTool_ToolGroupLifeGet.Location = New System.Drawing.Point(253, 319)
Me.cmdMultiTool_ToolGroupLifeGet.Name = "cmdMultiTool_ToolGroupLifeGet"
Me.cmdMultiTool_ToolGroupLifeGet.Size = New System.Drawing.Size(40, 24)
Me.cmdMultiTool_ToolGroupLifeGet.TabIndex = 252
Me.cmdMultiTool_ToolGroupLifeGet.Text = "Get"
'
'txtMultiTool_ToolGroupLifeValue
'
Me.txtMultiTool_ToolGroupLifeValue.ForeColor = System.Drawing.Color.Red
Me.txtMultiTool_ToolGroupLifeValue.Location = New System.Drawing.Point(187, 319)
Me.txtMultiTool_ToolGroupLifeValue.Name = "txtMultiTool_ToolGroupLifeValue"
Me.txtMultiTool_ToolGroupLifeValue.Size = New System.Drawing.Size(55, 20)
Me.txtMultiTool_ToolGroupLifeValue.TabIndex = 251
Me.txtMultiTool_ToolGroupLifeValue.Text = "0"
'
'txtMultiTool_ToolGroupLife
'
Me.txtMultiTool_ToolGroupLife.Location = New System.Drawing.Point(113, 319)
Me.txtMultiTool_ToolGroupLife.Name = "txtMultiTool_ToolGroupLife"
Me.txtMultiTool_ToolGroupLife.ReadOnly = true
Me.txtMultiTool_ToolGroupLife.Size = New System.Drawing.Size(64, 20)
Me.txtMultiTool_ToolGroupLife.TabIndex = 250
Me.txtMultiTool_ToolGroupLife.Text = "0"
'
'cmdMultiTool_ToolGroupLifeSet
'
Me.cmdMultiTool_ToolGroupLifeSet.Location = New System.Drawing.Point(300, 319)
Me.cmdMultiTool_ToolGroupLifeSet.Name = "cmdMultiTool_ToolGroupLifeSet"
Me.cmdMultiTool_ToolGroupLifeSet.Size = New System.Drawing.Size(40, 24)
Me.cmdMultiTool_ToolGroupLifeSet.TabIndex = 249
Me.cmdMultiTool_ToolGroupLifeSet.Text = "Set"
'
'Label34
'
Me.Label34.Location = New System.Drawing.Point(7, 319)
Me.Label34.Name = "Label34"
Me.Label34.Size = New System.Drawing.Size(95, 16)
Me.Label34.TabIndex = 248
Me.Label34.Text = "Tool Group Life"
'
'cmdMultiTool_ToolLifeStatusGet
'
Me.cmdMultiTool_ToolLifeStatusGet.Location = New System.Drawing.Point(253, 236)
Me.cmdMultiTool_ToolLifeStatusGet.Name = "cmdMultiTool_ToolLifeStatusGet"
Me.cmdMultiTool_ToolLifeStatusGet.Size = New System.Drawing.Size(40, 24)
Me.cmdMultiTool_ToolLifeStatusGet.TabIndex = 247
Me.cmdMultiTool_ToolLifeStatusGet.Text = "Get"
'
'txtMultiTool_ToolLifeStatusValue
'
Me.txtMultiTool_ToolLifeStatusValue.ForeColor = System.Drawing.Color.Red
Me.txtMultiTool_ToolLifeStatusValue.Location = New System.Drawing.Point(187, 236)
Me.txtMultiTool_ToolLifeStatusValue.Name = "txtMultiTool_ToolLifeStatusValue"
Me.txtMultiTool_ToolLifeStatusValue.Size = New System.Drawing.Size(55, 20)
Me.txtMultiTool_ToolLifeStatusValue.TabIndex = 245
Me.txtMultiTool_ToolLifeStatusValue.Text = "0"
'
'txtMultiTool_ToolLifeStatus
'
Me.txtMultiTool_ToolLifeStatus.Location = New System.Drawing.Point(113, 236)
Me.txtMultiTool_ToolLifeStatus.Name = "txtMultiTool_ToolLifeStatus"
Me.txtMultiTool_ToolLifeStatus.ReadOnly = true
Me.txtMultiTool_ToolLifeStatus.Size = New System.Drawing.Size(64, 20)
Me.txtMultiTool_ToolLifeStatus.TabIndex = 244
Me.txtMultiTool_ToolLifeStatus.Text = "0"
'
'cmdMultiTool_ToolLifeStatusSet
'
Me.cmdMultiTool_ToolLifeStatusSet.Location = New System.Drawing.Point(300, 236)
Me.cmdMultiTool_ToolLifeStatusSet.Name = "cmdMultiTool_ToolLifeStatusSet"
Me.cmdMultiTool_ToolLifeStatusSet.Size = New System.Drawing.Size(40, 24)
Me.cmdMultiTool_ToolLifeStatusSet.TabIndex = 243
Me.cmdMultiTool_ToolLifeStatusSet.Text = "Set"
'
'Label33
'
Me.Label33.Location = New System.Drawing.Point(7, 236)
Me.Label33.Name = "Label33"
Me.Label33.Size = New System.Drawing.Size(95, 15)
Me.Label33.TabIndex = 242
Me.Label33.Text = "Tool Life Status"
'
'cmdMultiTool_ToolGaugeGet
'
Me.cmdMultiTool_ToolGaugeGet.Location = New System.Drawing.Point(253, 208)
Me.cmdMultiTool_ToolGaugeGet.Name = "cmdMultiTool_ToolGaugeGet"
Me.cmdMultiTool_ToolGaugeGet.Size = New System.Drawing.Size(40, 24)
Me.cmdMultiTool_ToolGaugeGet.TabIndex = 241
Me.cmdMultiTool_ToolGaugeGet.Text = "Get"
'
'cmdMultiTool_ToolLifeActualGet
'
Me.cmdMultiTool_ToolLifeActualGet.Location = New System.Drawing.Point(253, 180)
Me.cmdMultiTool_ToolLifeActualGet.Name = "cmdMultiTool_ToolLifeActualGet"
Me.cmdMultiTool_ToolLifeActualGet.Size = New System.Drawing.Size(40, 25)
Me.cmdMultiTool_ToolLifeActualGet.TabIndex = 240
Me.cmdMultiTool_ToolLifeActualGet.Text = "Get"
'
'cmdMultiTool_ToolSetGet
'
Me.cmdMultiTool_ToolSetGet.Location = New System.Drawing.Point(253, 153)
Me.cmdMultiTool_ToolSetGet.Name = "cmdMultiTool_ToolSetGet"
Me.cmdMultiTool_ToolSetGet.Size = New System.Drawing.Size(40, 24)
Me.cmdMultiTool_ToolSetGet.TabIndex = 239
Me.cmdMultiTool_ToolSetGet.Text = "Get"
'
'cboMultiToolSubSystem
'
Me.cboMultiToolSubSystem.Location = New System.Drawing.Point(87, 7)
Me.cboMultiToolSubSystem.Name = "cboMultiToolSubSystem"
Me.cboMultiToolSubSystem.Size = New System.Drawing.Size(126, 21)
Me.cboMultiToolSubSystem.TabIndex = 238
'
'txtMultiTool_ToolLifeGaugeValue
'
Me.txtMultiTool_ToolLifeGaugeValue.ForeColor = System.Drawing.Color.Red
Me.txtMultiTool_ToolLifeGaugeValue.Location = New System.Drawing.Point(187, 208)
Me.txtMultiTool_ToolLifeGaugeValue.Name = "txtMultiTool_ToolLifeGaugeValue"
Me.txtMultiTool_ToolLifeGaugeValue.Size = New System.Drawing.Size(55, 20)
Me.txtMultiTool_ToolLifeGaugeValue.TabIndex = 236
Me.txtMultiTool_ToolLifeGaugeValue.Text = "0"
'
'txtMultiTool_ToolLifeGauge
'
Me.txtMultiTool_ToolLifeGauge.Location = New System.Drawing.Point(113, 208)
Me.txtMultiTool_ToolLifeGauge.Name = "txtMultiTool_ToolLifeGauge"
Me.txtMultiTool_ToolLifeGauge.ReadOnly = true
Me.txtMultiTool_ToolLifeGauge.Size = New System.Drawing.Size(64, 20)
Me.txtMultiTool_ToolLifeGauge.TabIndex = 235
Me.txtMultiTool_ToolLifeGauge.Text = "0"
'
'cmdMultiTool_ToolGaugeSet
'
Me.cmdMultiTool_ToolGaugeSet.Location = New System.Drawing.Point(300, 208)
Me.cmdMultiTool_ToolGaugeSet.Name = "cmdMultiTool_ToolGaugeSet"
Me.cmdMultiTool_ToolGaugeSet.Size = New System.Drawing.Size(40, 24)
Me.cmdMultiTool_ToolGaugeSet.TabIndex = 234
Me.cmdMultiTool_ToolGaugeSet.Text = "Set"
'
'Label32
'
Me.Label32.Location = New System.Drawing.Point(7, 208)
Me.Label32.Name = "Label32"
Me.Label32.Size = New System.Drawing.Size(95, 16)
Me.Label32.TabIndex = 233
Me.Label32.Text = "Tool Life (Gauge)"
'
'Label242
'
Me.Label242.Location = New System.Drawing.Point(7, 7)
Me.Label242.Name = "Label242"
Me.Label242.Size = New System.Drawing.Size(73, 16)
Me.Label242.TabIndex = 232
Me.Label242.Text = "SubSystem:"
'
'cmdMultiTool_ToolLifeActualAdd
'
Me.cmdMultiTool_ToolLifeActualAdd.Location = New System.Drawing.Point(347, 180)
Me.cmdMultiTool_ToolLifeActualAdd.Name = "cmdMultiTool_ToolLifeActualAdd"
Me.cmdMultiTool_ToolLifeActualAdd.Size = New System.Drawing.Size(40, 25)
Me.cmdMultiTool_ToolLifeActualAdd.TabIndex = 231
Me.cmdMultiTool_ToolLifeActualAdd.Text = "Add"
'
'txtMultiTool_ToolLifeActualValue
'
Me.txtMultiTool_ToolLifeActualValue.ForeColor = System.Drawing.Color.Red
Me.txtMultiTool_ToolLifeActualValue.Location = New System.Drawing.Point(187, 180)
Me.txtMultiTool_ToolLifeActualValue.Name = "txtMultiTool_ToolLifeActualValue"
Me.txtMultiTool_ToolLifeActualValue.Size = New System.Drawing.Size(55, 20)
Me.txtMultiTool_ToolLifeActualValue.TabIndex = 230
Me.txtMultiTool_ToolLifeActualValue.Text = "0"
'
'txtMultiTool_ToolLifeActual
'
Me.txtMultiTool_ToolLifeActual.Location = New System.Drawing.Point(113, 180)
Me.txtMultiTool_ToolLifeActual.Name = "txtMultiTool_ToolLifeActual"
Me.txtMultiTool_ToolLifeActual.ReadOnly = true
Me.txtMultiTool_ToolLifeActual.Size = New System.Drawing.Size(64, 20)
Me.txtMultiTool_ToolLifeActual.TabIndex = 229
Me.txtMultiTool_ToolLifeActual.Text = "0"
'
'cmdMultiTool_ToolLifeActualSet
'
Me.cmdMultiTool_ToolLifeActualSet.Location = New System.Drawing.Point(300, 180)
Me.cmdMultiTool_ToolLifeActualSet.Name = "cmdMultiTool_ToolLifeActualSet"
Me.cmdMultiTool_ToolLifeActualSet.Size = New System.Drawing.Size(40, 25)
Me.cmdMultiTool_ToolLifeActualSet.TabIndex = 228
Me.cmdMultiTool_ToolLifeActualSet.Text = "Set"
'
'Label185
'
Me.Label185.Location = New System.Drawing.Point(7, 180)
Me.Label185.Name = "Label185"
Me.Label185.Size = New System.Drawing.Size(95, 16)
Me.Label185.TabIndex = 227
Me.Label185.Text = "Tool Life (Actual)"
'
'cmdMultiTool_ToolSetAdd
'
Me.cmdMultiTool_ToolSetAdd.Location = New System.Drawing.Point(347, 153)
Me.cmdMultiTool_ToolSetAdd.Name = "cmdMultiTool_ToolSetAdd"
Me.cmdMultiTool_ToolSetAdd.Size = New System.Drawing.Size(40, 24)
Me.cmdMultiTool_ToolSetAdd.TabIndex = 224
Me.cmdMultiTool_ToolSetAdd.Text = "Add"
'
'txtMultiTool_ToolLifeSetValue
'
Me.txtMultiTool_ToolLifeSetValue.ForeColor = System.Drawing.Color.Red
Me.txtMultiTool_ToolLifeSetValue.Location = New System.Drawing.Point(187, 153)
Me.txtMultiTool_ToolLifeSetValue.Name = "txtMultiTool_ToolLifeSetValue"
Me.txtMultiTool_ToolLifeSetValue.Size = New System.Drawing.Size(55, 20)
Me.txtMultiTool_ToolLifeSetValue.TabIndex = 223
Me.txtMultiTool_ToolLifeSetValue.Text = "0"
'
'txtMultiTool_ToolLifeSet
'
Me.txtMultiTool_ToolLifeSet.Location = New System.Drawing.Point(113, 153)
Me.txtMultiTool_ToolLifeSet.Name = "txtMultiTool_ToolLifeSet"
Me.txtMultiTool_ToolLifeSet.ReadOnly = true
Me.txtMultiTool_ToolLifeSet.Size = New System.Drawing.Size(64, 20)
Me.txtMultiTool_ToolLifeSet.TabIndex = 222
Me.txtMultiTool_ToolLifeSet.Text = "0"
'
'cmdMultiTool_ToolSetSet
'
Me.cmdMultiTool_ToolSetSet.Location = New System.Drawing.Point(300, 153)
Me.cmdMultiTool_ToolSetSet.Name = "cmdMultiTool_ToolSetSet"
Me.cmdMultiTool_ToolSetSet.Size = New System.Drawing.Size(40, 24)
Me.cmdMultiTool_ToolSetSet.TabIndex = 221
Me.cmdMultiTool_ToolSetSet.Text = "Set"
'
'Label187
'
Me.Label187.Location = New System.Drawing.Point(220, 7)
Me.Label187.Name = "Label187"
Me.Label187.Size = New System.Drawing.Size(40, 16)
Me.Label187.TabIndex = 220
Me.Label187.Text = "Edges"
'
'cboMultiToolEdges
'
Me.cboMultiToolEdges.Location = New System.Drawing.Point(267, 7)
Me.cboMultiToolEdges.Name = "cboMultiToolEdges"
Me.cboMultiToolEdges.Size = New System.Drawing.Size(166, 21)
Me.cboMultiToolEdges.TabIndex = 219
'
'Label190
'
Me.Label190.Location = New System.Drawing.Point(7, 153)
Me.Label190.Name = "Label190"
Me.Label190.Size = New System.Drawing.Size(95, 16)
Me.Label190.TabIndex = 214
Me.Label190.Text = "Tool Life (SET)"
'
'Tab_MacManMachiningReport
'
Me.Tab_MacManMachiningReport.Controls.Add(Me.grdMMMachiningReports)
Me.Tab_MacManMachiningReport.Controls.Add(Me.PictureBox1)
Me.Tab_MacManMachiningReport.Controls.Add(Me.txtMachiningReport_NoOfWork)
Me.Tab_MacManMachiningReport.Controls.Add(Me.Label144)
Me.Tab_MacManMachiningReport.Controls.Add(Me.cmdMMMachiningReportsSubSystem)
Me.Tab_MacManMachiningReport.Controls.Add(Me.cboMachiningReportSubSystem)
Me.Tab_MacManMachiningReport.Controls.Add(Me.Label143)
Me.Tab_MacManMachiningReport.Controls.Add(Me.MacreportTime)
Me.Tab_MacManMachiningReport.Controls.Add(Me.Label245)
Me.Tab_MacManMachiningReport.Controls.Add(Me.txtto)
Me.Tab_MacManMachiningReport.Controls.Add(Me.Label221)
Me.Tab_MacManMachiningReport.Controls.Add(Me.txtFrom)
Me.Tab_MacManMachiningReport.Controls.Add(Me.Label222)
Me.Tab_MacManMachiningReport.Controls.Add(Me.macreport_result)
Me.Tab_MacManMachiningReport.Controls.Add(Me.Label216)
Me.Tab_MacManMachiningReport.Controls.Add(Me.Cmb_rptPeriod)
Me.Tab_MacManMachiningReport.Controls.Add(Me.MacReport_programname)
Me.Tab_MacManMachiningReport.Controls.Add(Me.Label217)
Me.Tab_MacManMachiningReport.Controls.Add(Me.Macreport_filename)
Me.Tab_MacManMachiningReport.Controls.Add(Me.Label218)
Me.Tab_MacManMachiningReport.Controls.Add(Me.MacReport_count)
Me.Tab_MacManMachiningReport.Controls.Add(Me.Label219)
Me.Tab_MacManMachiningReport.Controls.Add(Me.macReportUpdateButton)
Me.Tab_MacManMachiningReport.Controls.Add(Me.MacReport_Index)
Me.Tab_MacManMachiningReport.Controls.Add(Me.Label220)
Me.Tab_MacManMachiningReport.Controls.Add(Me.macreport_Operatingtime)
Me.Tab_MacManMachiningReport.Controls.Add(Me.Label225)
Me.Tab_MacManMachiningReport.Controls.Add(Me.macreport_Runningtime)
Me.Tab_MacManMachiningReport.Controls.Add(Me.Label226)
Me.Tab_MacManMachiningReport.Controls.Add(Me.Macreportdate)
Me.Tab_MacManMachiningReport.Controls.Add(Me.Label227)
Me.Tab_MacManMachiningReport.Controls.Add(Me.macreport_maxcount)
Me.Tab_MacManMachiningReport.Controls.Add(Me.Label228)
Me.Tab_MacManMachiningReport.Controls.Add(Me.macreport_cuttingtime)
Me.Tab_MacManMachiningReport.Controls.Add(Me.Label229)
Me.Tab_MacManMachiningReport.Location = New System.Drawing.Point(4, 22)
Me.Tab_MacManMachiningReport.Name = "Tab_MacManMachiningReport"
Me.Tab_MacManMachiningReport.Size = New System.Drawing.Size(776, 446)
Me.Tab_MacManMachiningReport.TabIndex = 23
Me.Tab_MacManMachiningReport.Text = "MacMan Machining Reports"
'
'grdMMMachiningReports
'
Me.grdMMMachiningReports.DataMember = ""
Me.grdMMMachiningReports.HeaderForeColor = System.Drawing.SystemColors.ControlText
Me.grdMMMachiningReports.Location = New System.Drawing.Point(8, 216)
Me.grdMMMachiningReports.Name = "grdMMMachiningReports"
Me.grdMMMachiningReports.PreferredColumnWidth = 80
Me.grdMMMachiningReports.ReadOnly = true
Me.grdMMMachiningReports.Size = New System.Drawing.Size(752, 216)
Me.grdMMMachiningReports.TabIndex = 300
Me.grdMMMachiningReports.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.grdMMMachiningReportTableStyle})
'
'grdMMMachiningReportTableStyle
'
Me.grdMMMachiningReportTableStyle.DataGrid = Me.grdMMMachiningReports
Me.grdMMMachiningReportTableStyle.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8})
Me.grdMMMachiningReportTableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText
Me.grdMMMachiningReportTableStyle.MappingName = ""
'
'DataGridTextBoxColumn1
'
Me.DataGridTextBoxColumn1.Format = ""
Me.DataGridTextBoxColumn1.FormatInfo = Nothing
Me.DataGridTextBoxColumn1.HeaderText = "Main Program File Name"
Me.DataGridTextBoxColumn1.MappingName = "MainProgramFileName"
Me.DataGridTextBoxColumn1.ReadOnly = true
Me.DataGridTextBoxColumn1.Width = 75
'
'DataGridTextBoxColumn2
'
Me.DataGridTextBoxColumn2.Format = ""
Me.DataGridTextBoxColumn2.FormatInfo = Nothing
Me.DataGridTextBoxColumn2.HeaderText = "Main Program Name"
Me.DataGridTextBoxColumn2.MappingName = "MainProgramName"
Me.DataGridTextBoxColumn2.ReadOnly = true
Me.DataGridTextBoxColumn2.Width = 75
'
'DataGridTextBoxColumn3
'
Me.DataGridTextBoxColumn3.Format = ""
Me.DataGridTextBoxColumn3.FormatInfo = Nothing
Me.DataGridTextBoxColumn3.HeaderText = "Start Date"
Me.DataGridTextBoxColumn3.MappingName = "StartDate"
Me.DataGridTextBoxColumn3.ReadOnly = true
Me.DataGridTextBoxColumn3.Width = 75
'
'DataGridTextBoxColumn4
'
Me.DataGridTextBoxColumn4.Format = ""
Me.DataGridTextBoxColumn4.FormatInfo = Nothing
Me.DataGridTextBoxColumn4.HeaderText = "Start Time"
Me.DataGridTextBoxColumn4.MappingName = "StartTime"
Me.DataGridTextBoxColumn4.ReadOnly = true
Me.DataGridTextBoxColumn4.Width = 75
'
'DataGridTextBoxColumn5
'
Me.DataGridTextBoxColumn5.Format = ""
Me.DataGridTextBoxColumn5.FormatInfo = Nothing
Me.DataGridTextBoxColumn5.HeaderText = "No of Work"
Me.DataGridTextBoxColumn5.MappingName = "NumberOfWork"
Me.DataGridTextBoxColumn5.ReadOnly = true
Me.DataGridTextBoxColumn5.Width = 75
'
'DataGridTextBoxColumn6
'
Me.DataGridTextBoxColumn6.Format = ""
Me.DataGridTextBoxColumn6.FormatInfo = Nothing
Me.DataGridTextBoxColumn6.HeaderText = "Running Time (ms)"
Me.DataGridTextBoxColumn6.MappingName = "RunningTime"
Me.DataGridTextBoxColumn6.ReadOnly = true
Me.DataGridTextBoxColumn6.Width = 75
'
'DataGridTextBoxColumn7
'
Me.DataGridTextBoxColumn7.Format = "OperatingTime"
Me.DataGridTextBoxColumn7.FormatInfo = Nothing
Me.DataGridTextBoxColumn7.HeaderText = "Operating Time (ms)"
Me.DataGridTextBoxColumn7.MappingName = ""
Me.DataGridTextBoxColumn7.ReadOnly = true
Me.DataGridTextBoxColumn7.Width = 75
'
'DataGridTextBoxColumn8
'
Me.DataGridTextBoxColumn8.Format = "CuttingTime"
Me.DataGridTextBoxColumn8.FormatInfo = Nothing
Me.DataGridTextBoxColumn8.HeaderText = "Cutting Time (ms)"
Me.DataGridTextBoxColumn8.MappingName = ""
Me.DataGridTextBoxColumn8.ReadOnly = true
Me.DataGridTextBoxColumn8.Width = 75
'
'PictureBox1
'
Me.PictureBox1.Location = New System.Drawing.Point(496, 176)
Me.PictureBox1.Name = "PictureBox1"
Me.PictureBox1.Size = New System.Drawing.Size(8, 8)
Me.PictureBox1.TabIndex = 299
Me.PictureBox1.TabStop = false
'
'txtMachiningReport_NoOfWork
'
Me.txtMachiningReport_NoOfWork.Location = New System.Drawing.Point(392, 128)
Me.txtMachiningReport_NoOfWork.Name = "txtMachiningReport_NoOfWork"
Me.txtMachiningReport_NoOfWork.ReadOnly = true
Me.txtMachiningReport_NoOfWork.Size = New System.Drawing.Size(88, 20)
Me.txtMachiningReport_NoOfWork.TabIndex = 298
Me.txtMachiningReport_NoOfWork.Text = ""
'
'Label144
'
Me.Label144.Location = New System.Drawing.Point(392, 96)
Me.Label144.Name = "Label144"
Me.Label144.Size = New System.Drawing.Size(88, 16)
Me.Label144.TabIndex = 297
Me.Label144.Text = "No. Of Work"
'
'cmdMMMachiningReportsSubSystem
'
Me.cmdMMMachiningReportsSubSystem.Location = New System.Drawing.Point(264, 8)
Me.cmdMMMachiningReportsSubSystem.Name = "cmdMMMachiningReportsSubSystem"
Me.cmdMMMachiningReportsSubSystem.Size = New System.Drawing.Size(64, 24)
Me.cmdMMMachiningReportsSubSystem.TabIndex = 296
Me.cmdMMMachiningReportsSubSystem.Text = "Set"
'
'cboMachiningReportSubSystem
'
Me.cboMachiningReportSubSystem.Location = New System.Drawing.Point(96, 8)
Me.cboMachiningReportSubSystem.Name = "cboMachiningReportSubSystem"
Me.cboMachiningReportSubSystem.Size = New System.Drawing.Size(160, 21)
Me.cboMachiningReportSubSystem.TabIndex = 295
'
'Label143
'
Me.Label143.Location = New System.Drawing.Point(8, 8)
Me.Label143.Name = "Label143"
Me.Label143.Size = New System.Drawing.Size(72, 16)
Me.Label143.TabIndex = 294
Me.Label143.Text = "Sub System :"
'
'MacreportTime
'
Me.MacreportTime.Location = New System.Drawing.Point(296, 128)
Me.MacreportTime.Name = "MacreportTime"
Me.MacreportTime.ReadOnly = true
Me.MacreportTime.Size = New System.Drawing.Size(88, 20)
Me.MacreportTime.TabIndex = 293
Me.MacreportTime.Text = ""
'
'Label245
'
Me.Label245.Location = New System.Drawing.Point(288, 96)
Me.Label245.Name = "Label245"
Me.Label245.Size = New System.Drawing.Size(88, 16)
Me.Label245.TabIndex = 292
Me.Label245.Text = "Start Time:"
'
'txtto
'
Me.txtto.Location = New System.Drawing.Point(384, 184)
Me.txtto.Name = "txtto"
Me.txtto.Size = New System.Drawing.Size(64, 20)
Me.txtto.TabIndex = 291
Me.txtto.Text = "2"
'
'Label221
'
Me.Label221.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label221.Location = New System.Drawing.Point(328, 184)
Me.Label221.Name = "Label221"
Me.Label221.Size = New System.Drawing.Size(48, 16)
Me.Label221.TabIndex = 290
Me.Label221.Text = "To"
'
'txtFrom
'
Me.txtFrom.Location = New System.Drawing.Point(232, 184)
Me.txtFrom.Name = "txtFrom"
Me.txtFrom.Size = New System.Drawing.Size(64, 20)
Me.txtFrom.TabIndex = 289
Me.txtFrom.Text = "1"
'
'Label222
'
Me.Label222.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label222.Location = New System.Drawing.Point(176, 184)
Me.Label222.Name = "Label222"
Me.Label222.Size = New System.Drawing.Size(48, 16)
Me.Label222.TabIndex = 288
Me.Label222.Text = "From"
'
'macreport_result
'
Me.macreport_result.Location = New System.Drawing.Point(8, 184)
Me.macreport_result.Name = "macreport_result"
Me.macreport_result.Size = New System.Drawing.Size(72, 24)
Me.macreport_result.TabIndex = 286
Me.macreport_result.Text = "Update"
'
'Label216
'
Me.Label216.Location = New System.Drawing.Point(248, 56)
Me.Label216.Name = "Label216"
Me.Label216.Size = New System.Drawing.Size(72, 16)
Me.Label216.TabIndex = 285
Me.Label216.Text = "Period Time"
'
'Cmb_rptPeriod
'
Me.Cmb_rptPeriod.Location = New System.Drawing.Point(328, 56)
Me.Cmb_rptPeriod.Name = "Cmb_rptPeriod"
Me.Cmb_rptPeriod.Size = New System.Drawing.Size(104, 21)
Me.Cmb_rptPeriod.TabIndex = 284
'
'MacReport_programname
'
Me.MacReport_programname.Location = New System.Drawing.Point(104, 128)
Me.MacReport_programname.Name = "MacReport_programname"
Me.MacReport_programname.ReadOnly = true
Me.MacReport_programname.Size = New System.Drawing.Size(88, 20)
Me.MacReport_programname.TabIndex = 283
Me.MacReport_programname.Text = ""
'
'Label217
'
Me.Label217.Location = New System.Drawing.Point(104, 96)
Me.Label217.Name = "Label217"
Me.Label217.Size = New System.Drawing.Size(88, 24)
Me.Label217.TabIndex = 282
Me.Label217.Text = "Main program name"
'
'Macreport_filename
'
Me.Macreport_filename.Location = New System.Drawing.Point(8, 128)
Me.Macreport_filename.Name = "Macreport_filename"
Me.Macreport_filename.ReadOnly = true
Me.Macreport_filename.Size = New System.Drawing.Size(88, 20)
Me.Macreport_filename.TabIndex = 281
Me.Macreport_filename.Text = ""
'
'Label218
'
Me.Label218.Location = New System.Drawing.Point(8, 96)
Me.Label218.Name = "Label218"
Me.Label218.Size = New System.Drawing.Size(88, 24)
Me.Label218.TabIndex = 280
Me.Label218.Text = "Main program file name"
'
'MacReport_count
'
Me.MacReport_count.Location = New System.Drawing.Point(664, 56)
Me.MacReport_count.Name = "MacReport_count"
Me.MacReport_count.ReadOnly = true
Me.MacReport_count.Size = New System.Drawing.Size(64, 20)
Me.MacReport_count.TabIndex = 279
Me.MacReport_count.Text = ""
'
'Label219
'
Me.Label219.Location = New System.Drawing.Point(608, 56)
Me.Label219.Name = "Label219"
Me.Label219.Size = New System.Drawing.Size(48, 16)
Me.Label219.TabIndex = 278
Me.Label219.Text = "Count"
'
'macReportUpdateButton
'
Me.macReportUpdateButton.Location = New System.Drawing.Point(8, 56)
Me.macReportUpdateButton.Name = "macReportUpdateButton"
Me.macReportUpdateButton.Size = New System.Drawing.Size(72, 24)
Me.macReportUpdateButton.TabIndex = 277
Me.macReportUpdateButton.Text = "Update"
'
'MacReport_Index
'
Me.MacReport_Index.Location = New System.Drawing.Point(176, 56)
Me.MacReport_Index.Name = "MacReport_Index"
Me.MacReport_Index.Size = New System.Drawing.Size(64, 20)
Me.MacReport_Index.TabIndex = 276
Me.MacReport_Index.Text = "1"
'
'Label220
'
Me.Label220.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label220.Location = New System.Drawing.Point(96, 56)
Me.Label220.Name = "Label220"
Me.Label220.Size = New System.Drawing.Size(64, 16)
Me.Label220.TabIndex = 275
Me.Label220.Text = "Index :"
'
'macreport_Operatingtime
'
Me.macreport_Operatingtime.Location = New System.Drawing.Point(576, 128)
Me.macreport_Operatingtime.Name = "macreport_Operatingtime"
Me.macreport_Operatingtime.ReadOnly = true
Me.macreport_Operatingtime.Size = New System.Drawing.Size(88, 20)
Me.macreport_Operatingtime.TabIndex = 274
Me.macreport_Operatingtime.Text = ""
'
'Label225
'
Me.Label225.Location = New System.Drawing.Point(576, 96)
Me.Label225.Name = "Label225"
Me.Label225.Size = New System.Drawing.Size(88, 32)
Me.Label225.TabIndex = 273
Me.Label225.Text = "Operating Time (ms)"
'
'macreport_Runningtime
'
Me.macreport_Runningtime.Location = New System.Drawing.Point(488, 128)
Me.macreport_Runningtime.Name = "macreport_Runningtime"
Me.macreport_Runningtime.ReadOnly = true
Me.macreport_Runningtime.Size = New System.Drawing.Size(80, 20)
Me.macreport_Runningtime.TabIndex = 272
Me.macreport_Runningtime.Text = ""
'
'Label226
'
Me.Label226.Location = New System.Drawing.Point(488, 96)
Me.Label226.Name = "Label226"
Me.Label226.Size = New System.Drawing.Size(88, 32)
Me.Label226.TabIndex = 271
Me.Label226.Text = "Running Time (ms)"
'
'Macreportdate
'
Me.Macreportdate.Location = New System.Drawing.Point(200, 128)
Me.Macreportdate.Name = "Macreportdate"
Me.Macreportdate.ReadOnly = true
Me.Macreportdate.Size = New System.Drawing.Size(88, 20)
Me.Macreportdate.TabIndex = 270
Me.Macreportdate.Text = ""
'
'Label227
'
Me.Label227.Location = New System.Drawing.Point(200, 96)
Me.Label227.Name = "Label227"
Me.Label227.Size = New System.Drawing.Size(80, 16)
Me.Label227.TabIndex = 269
Me.Label227.Text = "Start Date:"
'
'macreport_maxcount
'
Me.macreport_maxcount.Location = New System.Drawing.Point(528, 56)
Me.macreport_maxcount.Name = "macreport_maxcount"
Me.macreport_maxcount.ReadOnly = true
Me.macreport_maxcount.Size = New System.Drawing.Size(64, 20)
Me.macreport_maxcount.TabIndex = 268
Me.macreport_maxcount.Text = ""
'
'Label228
'
Me.Label228.Location = New System.Drawing.Point(440, 56)
Me.Label228.Name = "Label228"
Me.Label228.Size = New System.Drawing.Size(72, 16)
Me.Label228.TabIndex = 267
Me.Label228.Text = "Max Count :"
'
'macreport_cuttingtime
'
Me.macreport_cuttingtime.Location = New System.Drawing.Point(672, 128)
Me.macreport_cuttingtime.Name = "macreport_cuttingtime"
Me.macreport_cuttingtime.ReadOnly = true
Me.macreport_cuttingtime.Size = New System.Drawing.Size(88, 20)
Me.macreport_cuttingtime.TabIndex = 266
Me.macreport_cuttingtime.Text = ""
'
'Label229
'
Me.Label229.Location = New System.Drawing.Point(672, 96)
Me.Label229.Name = "Label229"
Me.Label229.Size = New System.Drawing.Size(88, 32)
Me.Label229.TabIndex = 265
Me.Label229.Text = "Cutting Time (ms)"
'
'tab_Chuck
'
Me.tab_Chuck.Controls.Add(Me.Label163)
Me.tab_Chuck.Controls.Add(Me.Label164)
Me.tab_Chuck.Controls.Add(Me.cmb_Chuck_Dataunit)
Me.tab_Chuck.Controls.Add(Me.cmb_Chuck_SubSys)
Me.tab_Chuck.Controls.Add(Me.chuckWorkTypeCombo)
Me.tab_Chuck.Controls.Add(Me.chuckButtonSetWorkType)
Me.tab_Chuck.Controls.Add(Me.chuckWorkType)
Me.tab_Chuck.Controls.Add(Me.Label157)
Me.tab_Chuck.Controls.Add(Me.chuckGrippingFaceToDistanceCal)
Me.tab_Chuck.Controls.Add(Me.chuckGrippingDiameterCal)
Me.tab_Chuck.Controls.Add(Me.chuckHoldSet)
Me.tab_Chuck.Controls.Add(Me.chuckHoldCombo)
Me.tab_Chuck.Controls.Add(Me.chuckSecondChuckZeroOffsetAdd)
Me.tab_Chuck.Controls.Add(Me.chuckSecondChuckZeroOffsetSet)
Me.tab_Chuck.Controls.Add(Me.chuckJawSizeAdd)
Me.tab_Chuck.Controls.Add(Me.chuckJawSizeSet)
Me.tab_Chuck.Controls.Add(Me.chuckJawLengthAdd)
Me.tab_Chuck.Controls.Add(Me.chuckJawLengthSet)
Me.tab_Chuck.Controls.Add(Me.chuckGrippingLengthAdd)
Me.tab_Chuck.Controls.Add(Me.chuckGrippingLengthSet)
Me.tab_Chuck.Controls.Add(Me.chuckGrippingFaceWidthAdd)
Me.tab_Chuck.Controls.Add(Me.chuckGrippingFaceWidthSet)
Me.tab_Chuck.Controls.Add(Me.chuckGrippingFaceToDistanceAdd)
Me.tab_Chuck.Controls.Add(Me.chuckGrippingFaceToDistanceSet)
Me.tab_Chuck.Controls.Add(Me.chuckGrippingDiameterAdd)
Me.tab_Chuck.Controls.Add(Me.chuckGrippingDiameterSet)
Me.tab_Chuck.Controls.Add(Me.chuckSecondChuckZeroOffsetUpd)
Me.tab_Chuck.Controls.Add(Me.chuckSecondChuckZeroOffset)
Me.tab_Chuck.Controls.Add(Me.Label53)
Me.tab_Chuck.Controls.Add(Me.chuckJawSizeUpd)
Me.tab_Chuck.Controls.Add(Me.chuckJawSize)
Me.tab_Chuck.Controls.Add(Me.Label52)
Me.tab_Chuck.Controls.Add(Me.chuckJawLengthUpd)
Me.tab_Chuck.Controls.Add(Me.chuckJawLength)
Me.tab_Chuck.Controls.Add(Me.Label51)
Me.tab_Chuck.Controls.Add(Me.chuckGrippingLengthUpd)
Me.tab_Chuck.Controls.Add(Me.chuckGrippingLength)
Me.tab_Chuck.Controls.Add(Me.Label50)
Me.tab_Chuck.Controls.Add(Me.chuckGrippingFaceWidthUpd)
Me.tab_Chuck.Controls.Add(Me.chuckGrippingFaceWidth)
Me.tab_Chuck.Controls.Add(Me.Label49)
Me.tab_Chuck.Controls.Add(Me.chuckGrippingFaceToDistanceUpd)
Me.tab_Chuck.Controls.Add(Me.chuckGrippingFaceToDistance)
Me.tab_Chuck.Controls.Add(Me.Label48)
Me.tab_Chuck.Controls.Add(Me.chuckGrippingDiameterUpd)
Me.tab_Chuck.Controls.Add(Me.chuckGrippingDiameter)
Me.tab_Chuck.Controls.Add(Me.Label47)
Me.tab_Chuck.Controls.Add(Me.Label46)
Me.tab_Chuck.Controls.Add(Me.chuckIndexEnum)
Me.tab_Chuck.Controls.Add(Me.chuckUpdateButton)
Me.tab_Chuck.Controls.Add(Me.chuckHold)
Me.tab_Chuck.Controls.Add(Me.Label36)
Me.tab_Chuck.Location = New System.Drawing.Point(4, 22)
Me.tab_Chuck.Name = "tab_Chuck"
Me.tab_Chuck.Size = New System.Drawing.Size(776, 446)
Me.tab_Chuck.TabIndex = 4
Me.tab_Chuck.Text = "Chuck"
'
'Label163
'
Me.Label163.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label163.Location = New System.Drawing.Point(8, 8)
Me.Label163.Name = "Label163"
Me.Label163.Size = New System.Drawing.Size(120, 16)
Me.Label163.TabIndex = 182
Me.Label163.Text = "Current Sub System :"
'
'Label164
'
Me.Label164.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label164.Location = New System.Drawing.Point(264, 8)
Me.Label164.Name = "Label164"
Me.Label164.Size = New System.Drawing.Size(80, 16)
Me.Label164.TabIndex = 181
Me.Label164.Text = "Data Unit :"
'
'cmb_Chuck_Dataunit
'
Me.cmb_Chuck_Dataunit.Location = New System.Drawing.Point(352, 8)
Me.cmb_Chuck_Dataunit.Name = "cmb_Chuck_Dataunit"
Me.cmb_Chuck_Dataunit.Size = New System.Drawing.Size(96, 21)
Me.cmb_Chuck_Dataunit.TabIndex = 180
'
'cmb_Chuck_SubSys
'
Me.cmb_Chuck_SubSys.Location = New System.Drawing.Point(144, 8)
Me.cmb_Chuck_SubSys.Name = "cmb_Chuck_SubSys"
Me.cmb_Chuck_SubSys.Size = New System.Drawing.Size(121, 21)
Me.cmb_Chuck_SubSys.TabIndex = 179
'
'chuckWorkTypeCombo
'
Me.chuckWorkTypeCombo.Location = New System.Drawing.Point(384, 88)
Me.chuckWorkTypeCombo.Name = "chuckWorkTypeCombo"
Me.chuckWorkTypeCombo.Size = New System.Drawing.Size(124, 21)
Me.chuckWorkTypeCombo.TabIndex = 178
'
'chuckButtonSetWorkType
'
Me.chuckButtonSetWorkType.Location = New System.Drawing.Point(520, 88)
Me.chuckButtonSetWorkType.Name = "chuckButtonSetWorkType"
Me.chuckButtonSetWorkType.Size = New System.Drawing.Size(40, 24)
Me.chuckButtonSetWorkType.TabIndex = 177
Me.chuckButtonSetWorkType.Text = "Set"
'
'chuckWorkType
'
Me.chuckWorkType.BackColor = System.Drawing.SystemColors.Control
Me.chuckWorkType.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.chuckWorkType.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.chuckWorkType.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.chuckWorkType.Location = New System.Drawing.Point(272, 88)
Me.chuckWorkType.Name = "chuckWorkType"
Me.chuckWorkType.Size = New System.Drawing.Size(104, 24)
Me.chuckWorkType.TabIndex = 175
Me.chuckWorkType.Text = "0"
'
'Label157
'
Me.Label157.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label157.Location = New System.Drawing.Point(8, 88)
Me.Label157.Name = "Label157"
Me.Label157.Size = New System.Drawing.Size(208, 16)
Me.Label157.TabIndex = 174
Me.Label157.Text = "Work Type :"
'
'chuckGrippingFaceToDistanceCal
'
Me.chuckGrippingFaceToDistanceCal.Location = New System.Drawing.Point(616, 336)
Me.chuckGrippingFaceToDistanceCal.Name = "chuckGrippingFaceToDistanceCal"
Me.chuckGrippingFaceToDistanceCal.Size = New System.Drawing.Size(40, 24)
Me.chuckGrippingFaceToDistanceCal.TabIndex = 173
Me.chuckGrippingFaceToDistanceCal.Text = "Cal"
'
'chuckGrippingDiameterCal
'
Me.chuckGrippingDiameterCal.Location = New System.Drawing.Point(616, 296)
Me.chuckGrippingDiameterCal.Name = "chuckGrippingDiameterCal"
Me.chuckGrippingDiameterCal.Size = New System.Drawing.Size(40, 24)
Me.chuckGrippingDiameterCal.TabIndex = 172
Me.chuckGrippingDiameterCal.Text = "Cal"
'
'chuckHoldSet
'
Me.chuckHoldSet.Location = New System.Drawing.Point(520, 48)
Me.chuckHoldSet.Name = "chuckHoldSet"
Me.chuckHoldSet.Size = New System.Drawing.Size(40, 24)
Me.chuckHoldSet.TabIndex = 171
Me.chuckHoldSet.Text = "Set"
'
'chuckHoldCombo
'
Me.chuckHoldCombo.Location = New System.Drawing.Point(264, 48)
Me.chuckHoldCombo.Name = "chuckHoldCombo"
Me.chuckHoldCombo.Size = New System.Drawing.Size(240, 21)
Me.chuckHoldCombo.TabIndex = 170
'
'chuckSecondChuckZeroOffsetAdd
'
Me.chuckSecondChuckZeroOffsetAdd.Location = New System.Drawing.Point(568, 408)
Me.chuckSecondChuckZeroOffsetAdd.Name = "chuckSecondChuckZeroOffsetAdd"
Me.chuckSecondChuckZeroOffsetAdd.Size = New System.Drawing.Size(40, 24)
Me.chuckSecondChuckZeroOffsetAdd.TabIndex = 169
Me.chuckSecondChuckZeroOffsetAdd.Text = "Add"
'
'chuckSecondChuckZeroOffsetSet
'
Me.chuckSecondChuckZeroOffsetSet.Location = New System.Drawing.Point(520, 408)
Me.chuckSecondChuckZeroOffsetSet.Name = "chuckSecondChuckZeroOffsetSet"
Me.chuckSecondChuckZeroOffsetSet.Size = New System.Drawing.Size(40, 24)
Me.chuckSecondChuckZeroOffsetSet.TabIndex = 168
Me.chuckSecondChuckZeroOffsetSet.Text = "Set"
'
'chuckJawSizeAdd
'
Me.chuckJawSizeAdd.Location = New System.Drawing.Point(568, 200)
Me.chuckJawSizeAdd.Name = "chuckJawSizeAdd"
Me.chuckJawSizeAdd.Size = New System.Drawing.Size(40, 24)
Me.chuckJawSizeAdd.TabIndex = 167
Me.chuckJawSizeAdd.Text = "Add"
'
'chuckJawSizeSet
'
Me.chuckJawSizeSet.Location = New System.Drawing.Point(520, 200)
Me.chuckJawSizeSet.Name = "chuckJawSizeSet"
Me.chuckJawSizeSet.Size = New System.Drawing.Size(40, 24)
Me.chuckJawSizeSet.TabIndex = 166
Me.chuckJawSizeSet.Text = "Set"
'
'chuckJawLengthAdd
'
Me.chuckJawLengthAdd.Location = New System.Drawing.Point(568, 168)
Me.chuckJawLengthAdd.Name = "chuckJawLengthAdd"
Me.chuckJawLengthAdd.Size = New System.Drawing.Size(40, 24)
Me.chuckJawLengthAdd.TabIndex = 165
Me.chuckJawLengthAdd.Text = "Add"
'
'chuckJawLengthSet
'
Me.chuckJawLengthSet.Location = New System.Drawing.Point(520, 168)
Me.chuckJawLengthSet.Name = "chuckJawLengthSet"
Me.chuckJawLengthSet.Size = New System.Drawing.Size(40, 24)
Me.chuckJawLengthSet.TabIndex = 164
Me.chuckJawLengthSet.Text = "Set"
'
'chuckGrippingLengthAdd
'
Me.chuckGrippingLengthAdd.Location = New System.Drawing.Point(568, 232)
Me.chuckGrippingLengthAdd.Name = "chuckGrippingLengthAdd"
Me.chuckGrippingLengthAdd.Size = New System.Drawing.Size(40, 24)
Me.chuckGrippingLengthAdd.TabIndex = 163
Me.chuckGrippingLengthAdd.Text = "Add"
'
'chuckGrippingLengthSet
'
Me.chuckGrippingLengthSet.Location = New System.Drawing.Point(520, 232)
Me.chuckGrippingLengthSet.Name = "chuckGrippingLengthSet"
Me.chuckGrippingLengthSet.Size = New System.Drawing.Size(40, 24)
Me.chuckGrippingLengthSet.TabIndex = 162
Me.chuckGrippingLengthSet.Text = "Set"
'
'chuckGrippingFaceWidthAdd
'
Me.chuckGrippingFaceWidthAdd.Location = New System.Drawing.Point(568, 264)
Me.chuckGrippingFaceWidthAdd.Name = "chuckGrippingFaceWidthAdd"
Me.chuckGrippingFaceWidthAdd.Size = New System.Drawing.Size(40, 24)
Me.chuckGrippingFaceWidthAdd.TabIndex = 161
Me.chuckGrippingFaceWidthAdd.Text = "Add"
'
'chuckGrippingFaceWidthSet
'
Me.chuckGrippingFaceWidthSet.Location = New System.Drawing.Point(520, 264)
Me.chuckGrippingFaceWidthSet.Name = "chuckGrippingFaceWidthSet"
Me.chuckGrippingFaceWidthSet.Size = New System.Drawing.Size(40, 24)
Me.chuckGrippingFaceWidthSet.TabIndex = 160
Me.chuckGrippingFaceWidthSet.Text = "Set"
'
'chuckGrippingFaceToDistanceAdd
'
Me.chuckGrippingFaceToDistanceAdd.Location = New System.Drawing.Point(568, 336)
Me.chuckGrippingFaceToDistanceAdd.Name = "chuckGrippingFaceToDistanceAdd"
Me.chuckGrippingFaceToDistanceAdd.Size = New System.Drawing.Size(40, 24)
Me.chuckGrippingFaceToDistanceAdd.TabIndex = 159
Me.chuckGrippingFaceToDistanceAdd.Text = "Add"
'
'chuckGrippingFaceToDistanceSet
'
Me.chuckGrippingFaceToDistanceSet.Location = New System.Drawing.Point(520, 336)
Me.chuckGrippingFaceToDistanceSet.Name = "chuckGrippingFaceToDistanceSet"
Me.chuckGrippingFaceToDistanceSet.Size = New System.Drawing.Size(40, 24)
Me.chuckGrippingFaceToDistanceSet.TabIndex = 158
Me.chuckGrippingFaceToDistanceSet.Text = "Set"
'
'chuckGrippingDiameterAdd
'
Me.chuckGrippingDiameterAdd.Location = New System.Drawing.Point(568, 296)
Me.chuckGrippingDiameterAdd.Name = "chuckGrippingDiameterAdd"
Me.chuckGrippingDiameterAdd.Size = New System.Drawing.Size(40, 24)
Me.chuckGrippingDiameterAdd.TabIndex = 157
Me.chuckGrippingDiameterAdd.Text = "Add"
'
'chuckGrippingDiameterSet
'
Me.chuckGrippingDiameterSet.Location = New System.Drawing.Point(520, 296)
Me.chuckGrippingDiameterSet.Name = "chuckGrippingDiameterSet"
Me.chuckGrippingDiameterSet.Size = New System.Drawing.Size(40, 24)
Me.chuckGrippingDiameterSet.TabIndex = 156
Me.chuckGrippingDiameterSet.Text = "Set"
'
'chuckSecondChuckZeroOffsetUpd
'
Me.chuckSecondChuckZeroOffsetUpd.BackColor = System.Drawing.SystemColors.Control
Me.chuckSecondChuckZeroOffsetUpd.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.chuckSecondChuckZeroOffsetUpd.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.chuckSecondChuckZeroOffsetUpd.ForeColor = System.Drawing.Color.Red
Me.chuckSecondChuckZeroOffsetUpd.Location = New System.Drawing.Point(376, 408)
Me.chuckSecondChuckZeroOffsetUpd.Name = "chuckSecondChuckZeroOffsetUpd"
Me.chuckSecondChuckZeroOffsetUpd.Size = New System.Drawing.Size(120, 24)
Me.chuckSecondChuckZeroOffsetUpd.TabIndex = 101
Me.chuckSecondChuckZeroOffsetUpd.Text = "0"
'
'chuckSecondChuckZeroOffset
'
Me.chuckSecondChuckZeroOffset.BackColor = System.Drawing.SystemColors.Control
Me.chuckSecondChuckZeroOffset.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.chuckSecondChuckZeroOffset.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.chuckSecondChuckZeroOffset.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.chuckSecondChuckZeroOffset.Location = New System.Drawing.Point(272, 408)
Me.chuckSecondChuckZeroOffset.Name = "chuckSecondChuckZeroOffset"
Me.chuckSecondChuckZeroOffset.Size = New System.Drawing.Size(104, 24)
Me.chuckSecondChuckZeroOffset.TabIndex = 100
Me.chuckSecondChuckZeroOffset.Text = "0"
'
'Label53
'
Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label53.Location = New System.Drawing.Point(8, 408)
Me.Label53.Name = "Label53"
Me.Label53.Size = New System.Drawing.Size(208, 16)
Me.Label53.TabIndex = 99
Me.Label53.Text = "Second Chuck Zero Offset :"
'
'chuckJawSizeUpd
'
Me.chuckJawSizeUpd.BackColor = System.Drawing.SystemColors.Control
Me.chuckJawSizeUpd.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.chuckJawSizeUpd.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.chuckJawSizeUpd.ForeColor = System.Drawing.Color.Red
Me.chuckJawSizeUpd.Location = New System.Drawing.Point(376, 200)
Me.chuckJawSizeUpd.Name = "chuckJawSizeUpd"
Me.chuckJawSizeUpd.Size = New System.Drawing.Size(120, 24)
Me.chuckJawSizeUpd.TabIndex = 98
Me.chuckJawSizeUpd.Text = "0"
'
'chuckJawSize
'
Me.chuckJawSize.BackColor = System.Drawing.SystemColors.Control
Me.chuckJawSize.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.chuckJawSize.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.chuckJawSize.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.chuckJawSize.Location = New System.Drawing.Point(272, 200)
Me.chuckJawSize.Name = "chuckJawSize"
Me.chuckJawSize.Size = New System.Drawing.Size(104, 24)
Me.chuckJawSize.TabIndex = 97
Me.chuckJawSize.Text = "0"
'
'Label52
'
Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label52.Location = New System.Drawing.Point(8, 200)
Me.Label52.Name = "Label52"
Me.Label52.Size = New System.Drawing.Size(144, 16)
Me.Label52.TabIndex = 96
Me.Label52.Text = "Jaw Size :"
'
'chuckJawLengthUpd
'
Me.chuckJawLengthUpd.BackColor = System.Drawing.SystemColors.Control
Me.chuckJawLengthUpd.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.chuckJawLengthUpd.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.chuckJawLengthUpd.ForeColor = System.Drawing.Color.Red
Me.chuckJawLengthUpd.Location = New System.Drawing.Point(376, 168)
Me.chuckJawLengthUpd.Name = "chuckJawLengthUpd"
Me.chuckJawLengthUpd.Size = New System.Drawing.Size(120, 24)
Me.chuckJawLengthUpd.TabIndex = 95
Me.chuckJawLengthUpd.Text = "0"
'
'chuckJawLength
'
Me.chuckJawLength.BackColor = System.Drawing.SystemColors.Control
Me.chuckJawLength.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.chuckJawLength.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.chuckJawLength.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.chuckJawLength.Location = New System.Drawing.Point(272, 168)
Me.chuckJawLength.Name = "chuckJawLength"
Me.chuckJawLength.Size = New System.Drawing.Size(104, 24)
Me.chuckJawLength.TabIndex = 94
Me.chuckJawLength.Text = "0"
'
'Label51
'
Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label51.Location = New System.Drawing.Point(8, 168)
Me.Label51.Name = "Label51"
Me.Label51.Size = New System.Drawing.Size(144, 16)
Me.Label51.TabIndex = 93
Me.Label51.Text = "Jaw Length :"
'
'chuckGrippingLengthUpd
'
Me.chuckGrippingLengthUpd.BackColor = System.Drawing.SystemColors.Control
Me.chuckGrippingLengthUpd.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.chuckGrippingLengthUpd.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.chuckGrippingLengthUpd.ForeColor = System.Drawing.Color.Red
Me.chuckGrippingLengthUpd.Location = New System.Drawing.Point(376, 232)
Me.chuckGrippingLengthUpd.Name = "chuckGrippingLengthUpd"
Me.chuckGrippingLengthUpd.Size = New System.Drawing.Size(120, 24)
Me.chuckGrippingLengthUpd.TabIndex = 92
Me.chuckGrippingLengthUpd.Text = "0"
'
'chuckGrippingLength
'
Me.chuckGrippingLength.BackColor = System.Drawing.SystemColors.Control
Me.chuckGrippingLength.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.chuckGrippingLength.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.chuckGrippingLength.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.chuckGrippingLength.Location = New System.Drawing.Point(272, 232)
Me.chuckGrippingLength.Name = "chuckGrippingLength"
Me.chuckGrippingLength.Size = New System.Drawing.Size(104, 24)
Me.chuckGrippingLength.TabIndex = 91
Me.chuckGrippingLength.Text = "0"
'
'Label50
'
Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label50.Location = New System.Drawing.Point(8, 232)
Me.Label50.Name = "Label50"
Me.Label50.Size = New System.Drawing.Size(144, 16)
Me.Label50.TabIndex = 90
Me.Label50.Text = "Gripping Length :"
'
'chuckGrippingFaceWidthUpd
'
Me.chuckGrippingFaceWidthUpd.BackColor = System.Drawing.SystemColors.Control
Me.chuckGrippingFaceWidthUpd.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.chuckGrippingFaceWidthUpd.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.chuckGrippingFaceWidthUpd.ForeColor = System.Drawing.Color.Red
Me.chuckGrippingFaceWidthUpd.Location = New System.Drawing.Point(376, 264)
Me.chuckGrippingFaceWidthUpd.Name = "chuckGrippingFaceWidthUpd"
Me.chuckGrippingFaceWidthUpd.Size = New System.Drawing.Size(120, 24)
Me.chuckGrippingFaceWidthUpd.TabIndex = 89
Me.chuckGrippingFaceWidthUpd.Text = "0"
'
'chuckGrippingFaceWidth
'
Me.chuckGrippingFaceWidth.BackColor = System.Drawing.SystemColors.Control
Me.chuckGrippingFaceWidth.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.chuckGrippingFaceWidth.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.chuckGrippingFaceWidth.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.chuckGrippingFaceWidth.Location = New System.Drawing.Point(272, 264)
Me.chuckGrippingFaceWidth.Name = "chuckGrippingFaceWidth"
Me.chuckGrippingFaceWidth.Size = New System.Drawing.Size(104, 24)
Me.chuckGrippingFaceWidth.TabIndex = 88
Me.chuckGrippingFaceWidth.Text = "0"
'
'Label49
'
Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label49.Location = New System.Drawing.Point(8, 264)
Me.Label49.Name = "Label49"
Me.Label49.Size = New System.Drawing.Size(144, 16)
Me.Label49.TabIndex = 87
Me.Label49.Text = "Gripping Face Width :"
'
'chuckGrippingFaceToDistanceUpd
'
Me.chuckGrippingFaceToDistanceUpd.BackColor = System.Drawing.SystemColors.Control
Me.chuckGrippingFaceToDistanceUpd.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.chuckGrippingFaceToDistanceUpd.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.chuckGrippingFaceToDistanceUpd.ForeColor = System.Drawing.Color.Red
Me.chuckGrippingFaceToDistanceUpd.Location = New System.Drawing.Point(376, 336)
Me.chuckGrippingFaceToDistanceUpd.Name = "chuckGrippingFaceToDistanceUpd"
Me.chuckGrippingFaceToDistanceUpd.Size = New System.Drawing.Size(120, 24)
Me.chuckGrippingFaceToDistanceUpd.TabIndex = 86
Me.chuckGrippingFaceToDistanceUpd.Text = "0"
'
'chuckGrippingFaceToDistance
'
Me.chuckGrippingFaceToDistance.BackColor = System.Drawing.SystemColors.Control
Me.chuckGrippingFaceToDistance.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.chuckGrippingFaceToDistance.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.chuckGrippingFaceToDistance.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.chuckGrippingFaceToDistance.Location = New System.Drawing.Point(272, 336)
Me.chuckGrippingFaceToDistance.Name = "chuckGrippingFaceToDistance"
Me.chuckGrippingFaceToDistance.Size = New System.Drawing.Size(104, 24)
Me.chuckGrippingFaceToDistance.TabIndex = 85
Me.chuckGrippingFaceToDistance.Text = "0"
'
'Label48
'
Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label48.Location = New System.Drawing.Point(8, 336)
Me.Label48.Name = "Label48"
Me.Label48.Size = New System.Drawing.Size(248, 16)
Me.Label48.TabIndex = 84
Me.Label48.Text = "Gripping Face To Program Zero Distance :"
'
'chuckGrippingDiameterUpd
'
Me.chuckGrippingDiameterUpd.BackColor = System.Drawing.SystemColors.Control
Me.chuckGrippingDiameterUpd.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.chuckGrippingDiameterUpd.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.chuckGrippingDiameterUpd.ForeColor = System.Drawing.Color.Red
Me.chuckGrippingDiameterUpd.Location = New System.Drawing.Point(376, 304)
Me.chuckGrippingDiameterUpd.Name = "chuckGrippingDiameterUpd"
Me.chuckGrippingDiameterUpd.Size = New System.Drawing.Size(120, 24)
Me.chuckGrippingDiameterUpd.TabIndex = 83
Me.chuckGrippingDiameterUpd.Text = "0"
'
'chuckGrippingDiameter
'
Me.chuckGrippingDiameter.BackColor = System.Drawing.SystemColors.Control
Me.chuckGrippingDiameter.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.chuckGrippingDiameter.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.chuckGrippingDiameter.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.chuckGrippingDiameter.Location = New System.Drawing.Point(272, 304)
Me.chuckGrippingDiameter.Name = "chuckGrippingDiameter"
Me.chuckGrippingDiameter.Size = New System.Drawing.Size(104, 24)
Me.chuckGrippingDiameter.TabIndex = 82
Me.chuckGrippingDiameter.Text = "0"
'
'Label47
'
Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label47.Location = New System.Drawing.Point(8, 304)
Me.Label47.Name = "Label47"
Me.Label47.Size = New System.Drawing.Size(144, 16)
Me.Label47.TabIndex = 81
Me.Label47.Text = "Gripping Diameter :"
'
'Label46
'
Me.Label46.Location = New System.Drawing.Point(456, 8)
Me.Label46.Name = "Label46"
Me.Label46.Size = New System.Drawing.Size(112, 24)
Me.Label46.TabIndex = 80
Me.Label46.Text = "Chuck Index Enum :"
'
'chuckIndexEnum
'
Me.chuckIndexEnum.Location = New System.Drawing.Point(576, 8)
Me.chuckIndexEnum.Name = "chuckIndexEnum"
Me.chuckIndexEnum.Size = New System.Drawing.Size(184, 21)
Me.chuckIndexEnum.TabIndex = 79
'
'chuckUpdateButton
'
Me.chuckUpdateButton.Location = New System.Drawing.Point(16, 40)
Me.chuckUpdateButton.Name = "chuckUpdateButton"
Me.chuckUpdateButton.Size = New System.Drawing.Size(104, 24)
Me.chuckUpdateButton.TabIndex = 78
Me.chuckUpdateButton.Text = "Update"
'
'chuckHold
'
Me.chuckHold.BackColor = System.Drawing.SystemColors.Control
Me.chuckHold.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.chuckHold.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.chuckHold.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.chuckHold.Location = New System.Drawing.Point(160, 128)
Me.chuckHold.Name = "chuckHold"
Me.chuckHold.Size = New System.Drawing.Size(336, 24)
Me.chuckHold.TabIndex = 77
Me.chuckHold.Text = ""
'
'Label36
'
Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label36.Location = New System.Drawing.Point(8, 136)
Me.Label36.Name = "Label36"
Me.Label36.Size = New System.Drawing.Size(144, 16)
Me.Label36.TabIndex = 76
Me.Label36.Text = "Chuck Hold :"
'
'tab_tools
'
Me.tab_tools.Controls.Add(Me.txtGroupNo)
Me.tab_tools.Controls.Add(Me.Label324)
Me.tab_tools.Controls.Add(Me.cmdToolGroupLifeStatusSet)
Me.tab_tools.Controls.Add(Me.txtToolGroupLifeStatusValue)
Me.tab_tools.Controls.Add(Me.txtToolGroupLifeStatus)
Me.tab_tools.Controls.Add(Me.Label323)
Me.tab_tools.Controls.Add(Me.Label87)
Me.tab_tools.Controls.Add(Me.cboTool_Standard_DataUnit)
Me.tab_tools.Controls.Add(Me.cmdToolOffsetStandard_SetSubSystem)
Me.tab_tools.Controls.Add(Me.cboToolWearOffsetAxis)
Me.tab_tools.Controls.Add(Me.Label13)
Me.tab_tools.Controls.Add(Me.cboToolsSubSystem)
Me.tab_tools.Controls.Add(Me.Label224)
Me.tab_tools.Controls.Add(Me.cboGaugeStatus)
Me.tab_tools.Controls.Add(Me.cmdAddActualToolLife)
Me.tab_tools.Controls.Add(Me.tulAddToolLife_button)
Me.tab_tools.Controls.Add(Me.tul1ComboToolOffset)
Me.tab_tools.Controls.Add(Me.tul1ComboNoseRComp)
Me.tab_tools.Controls.Add(Me.tulButtonToolWear)
Me.tab_tools.Controls.Add(Me.tulButtonToolOffset)
Me.tab_tools.Controls.Add(Me.tulButtonNoseRComp)
Me.tab_tools.Controls.Add(Me.tulButtonNoseRPattern)
Me.tab_tools.Controls.Add(Me.tulResults)
Me.tab_tools.Controls.Add(Me.TulNoseRCompensationPatternTo)
Me.tab_tools.Controls.Add(Me.Label9)
Me.tab_tools.Controls.Add(Me.Label8)
Me.tab_tools.Controls.Add(Me.TulNoseRCompensationPatternFrom)
Me.tab_tools.Controls.Add(Me.TulAddNoseRCompensation)
Me.tab_tools.Controls.Add(Me.tulSetReferenceToolOffset1)
Me.tab_tools.Controls.Add(Me.tulUpdReferenceToolOffset1)
Me.tab_tools.Controls.Add(Me.tulReferenceToolOffset1)
Me.tab_tools.Controls.Add(Me.Label7)
Me.tab_tools.Controls.Add(Me.tulComboActualToolLife)
Me.tab_tools.Controls.Add(Me.tulSetActualToolLife)
Me.tab_tools.Controls.Add(Me.tulUpdActualToolLife)
Me.tab_tools.Controls.Add(Me.tulActualToolLife)
Me.tab_tools.Controls.Add(Me.Label5)
Me.tab_tools.Controls.Add(Me.TulSetNoseRCompensationPattern)
Me.tab_tools.Controls.Add(Me.TulUpdNoseRCompensationPattern)
Me.tab_tools.Controls.Add(Me.TulNoseRCompensationPattern)
Me.tab_tools.Controls.Add(Me.Label4)
Me.tab_tools.Controls.Add(Me.TulComboNoseRCompensation)
Me.tab_tools.Controls.Add(Me.TulSetNoseRCompensation)
Me.tab_tools.Controls.Add(Me.TulUpdNoseRCompensation)
Me.tab_tools.Controls.Add(Me.TulNoseRCompensation)
Me.tab_tools.Controls.Add(Me.Label3)
Me.tab_tools.Controls.Add(Me.tulComboToolWearOffset)
Me.tab_tools.Controls.Add(Me.tulComboToolLife)
Me.tab_tools.Controls.Add(Me.tulComboToolOffset)
Me.tab_tools.Controls.Add(Me.tulUpdGroupNumber)
Me.tab_tools.Controls.Add(Me.tulSetGroupNumber)
Me.tab_tools.Controls.Add(Me.tulAddToolWearOffset)
Me.tab_tools.Controls.Add(Me.tulUpdLifeStatus)
Me.tab_tools.Controls.Add(Me.tulToolNumber)
Me.tab_tools.Controls.Add(Me.label100)
Me.tab_tools.Controls.Add(Me.tulUpdateButton)
Me.tab_tools.Controls.Add(Me.tulSetToolWearOffset)
Me.tab_tools.Controls.Add(Me.tulUpdToolWearOffset)
Me.tab_tools.Controls.Add(Me.tulToolWearOffset)
Me.tab_tools.Controls.Add(Me.tulSetToolLife)
Me.tab_tools.Controls.Add(Me.tulUpdToolLife)
Me.tab_tools.Controls.Add(Me.tulToolLife)
Me.tab_tools.Controls.Add(Me.tulAddToolOffset)
Me.tab_tools.Controls.Add(Me.tulSetToolOffset)
Me.tab_tools.Controls.Add(Me.tulUpdToolOffset)
Me.tab_tools.Controls.Add(Me.tulToolOffset)
Me.tab_tools.Controls.Add(Me.Label86)
Me.tab_tools.Controls.Add(Me.tulSetToolNumberInGroup)
Me.tab_tools.Controls.Add(Me.tulUpdToolNumberInGroup)
Me.tab_tools.Controls.Add(Me.tulToolNumberInGroup)
Me.tab_tools.Controls.Add(Me.Label85)
Me.tab_tools.Controls.Add(Me.tulMaxToolOffset)
Me.tab_tools.Controls.Add(Me.Label83)
Me.tab_tools.Controls.Add(Me.tulSetLifeStatus)
Me.tab_tools.Controls.Add(Me.tulLifeStatus)
Me.tab_tools.Controls.Add(Me.Label82)
Me.tab_tools.Controls.Add(Me.tulSetReferenceToolOffset3)
Me.tab_tools.Controls.Add(Me.tulSetReferenceToolOffset2)
Me.tab_tools.Controls.Add(Me.tulSetGauseStatus)
Me.tab_tools.Controls.Add(Me.tulUpdReferenceToolOffset3)
Me.tab_tools.Controls.Add(Me.tulUpdReferenceToolOffset2)
Me.tab_tools.Controls.Add(Me.tulReferenceToolOffset3)
Me.tab_tools.Controls.Add(Me.Label74)
Me.tab_tools.Controls.Add(Me.tulReferenceToolOffset2)
Me.tab_tools.Controls.Add(Me.Label75)
Me.tab_tools.Controls.Add(Me.tulGroupNumber)
Me.tab_tools.Controls.Add(Me.Label76)
Me.tab_tools.Controls.Add(Me.tulCurrentToolOffsetNumber)
Me.tab_tools.Controls.Add(Me.Label77)
Me.tab_tools.Controls.Add(Me.tulGauseStatus)
Me.tab_tools.Controls.Add(Me.Label78)
Me.tab_tools.Controls.Add(Me.Label79)
Me.tab_tools.Controls.Add(Me.tulCurrentToolNumber)
Me.tab_tools.Controls.Add(Me.Label80)
Me.tab_tools.Controls.Add(Me.tulCurrentNoseRCompNumber)
Me.tab_tools.Controls.Add(Me.TextBox3)
Me.tab_tools.Controls.Add(Me.TextBox4)
Me.tab_tools.Controls.Add(Me.Label6)
Me.tab_tools.Location = New System.Drawing.Point(4, 22)
Me.tab_tools.Name = "tab_tools"
Me.tab_tools.Size = New System.Drawing.Size(776, 446)
Me.tab_tools.TabIndex = 9
Me.tab_tools.Text = "Tools (Standard)"
'
'txtGroupNo
'
Me.txtGroupNo.ForeColor = System.Drawing.Color.Black
Me.txtGroupNo.Location = New System.Drawing.Point(667, 7)
Me.txtGroupNo.Name = "txtGroupNo"
Me.txtGroupNo.Size = New System.Drawing.Size(64, 20)
Me.txtGroupNo.TabIndex = 239
Me.txtGroupNo.Text = "1"
'
'Label324
'
Me.Label324.Location = New System.Drawing.Point(567, 7)
Me.Label324.Name = "Label324"
Me.Label324.Size = New System.Drawing.Size(93, 16)
Me.Label324.TabIndex = 238
Me.Label324.Text = "Group No."
'
'cmdToolGroupLifeStatusSet
'
Me.cmdToolGroupLifeStatusSet.Location = New System.Drawing.Point(307, 312)
Me.cmdToolGroupLifeStatusSet.Name = "cmdToolGroupLifeStatusSet"
Me.cmdToolGroupLifeStatusSet.Size = New System.Drawing.Size(40, 24)
Me.cmdToolGroupLifeStatusSet.TabIndex = 237
Me.cmdToolGroupLifeStatusSet.Text = "Set"
'
'txtToolGroupLifeStatusValue
'
Me.txtToolGroupLifeStatusValue.ForeColor = System.Drawing.Color.Red
Me.txtToolGroupLifeStatusValue.Location = New System.Drawing.Point(233, 312)
Me.txtToolGroupLifeStatusValue.Name = "txtToolGroupLifeStatusValue"
Me.txtToolGroupLifeStatusValue.Size = New System.Drawing.Size(64, 20)
Me.txtToolGroupLifeStatusValue.TabIndex = 236
Me.txtToolGroupLifeStatusValue.Text = "0"
'
'txtToolGroupLifeStatus
'
Me.txtToolGroupLifeStatus.Location = New System.Drawing.Point(160, 312)
Me.txtToolGroupLifeStatus.Name = "txtToolGroupLifeStatus"
Me.txtToolGroupLifeStatus.ReadOnly = true
Me.txtToolGroupLifeStatus.Size = New System.Drawing.Size(64, 20)
Me.txtToolGroupLifeStatus.TabIndex = 235
Me.txtToolGroupLifeStatus.Text = "0"
'
'Label323
'
Me.Label323.Location = New System.Drawing.Point(7, 319)
Me.Label323.Name = "Label323"
Me.Label323.Size = New System.Drawing.Size(135, 16)
Me.Label323.TabIndex = 234
Me.Label323.Text = "Group Life Status"
'
'Label87
'
Me.Label87.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label87.Location = New System.Drawing.Point(288, 8)
Me.Label87.Name = "Label87"
Me.Label87.Size = New System.Drawing.Size(65, 16)
Me.Label87.TabIndex = 233
Me.Label87.Text = "Data Unit :"
'
'cboTool_Standard_DataUnit
'
Me.cboTool_Standard_DataUnit.Location = New System.Drawing.Point(360, 8)
Me.cboTool_Standard_DataUnit.Name = "cboTool_Standard_DataUnit"
Me.cboTool_Standard_DataUnit.Size = New System.Drawing.Size(127, 21)
Me.cboTool_Standard_DataUnit.TabIndex = 232
'
'cmdToolOffsetStandard_SetSubSystem
'
Me.cmdToolOffsetStandard_SetSubSystem.Location = New System.Drawing.Point(493, 8)
Me.cmdToolOffsetStandard_SetSubSystem.Name = "cmdToolOffsetStandard_SetSubSystem"
Me.cmdToolOffsetStandard_SetSubSystem.Size = New System.Drawing.Size(64, 24)
Me.cmdToolOffsetStandard_SetSubSystem.TabIndex = 226
Me.cmdToolOffsetStandard_SetSubSystem.Text = "Set"
'
'cboToolWearOffsetAxis
'
Me.cboToolWearOffsetAxis.Location = New System.Drawing.Point(664, 280)
Me.cboToolWearOffsetAxis.Name = "cboToolWearOffsetAxis"
Me.cboToolWearOffsetAxis.Size = New System.Drawing.Size(104, 21)
Me.cboToolWearOffsetAxis.TabIndex = 225
'
'Label13
'
Me.Label13.Location = New System.Drawing.Point(312, 80)
Me.Label13.Name = "Label13"
Me.Label13.Size = New System.Drawing.Size(48, 16)
Me.Label13.TabIndex = 224
Me.Label13.Text = "Tool Life"
'
'cboToolsSubSystem
'
Me.cboToolsSubSystem.Location = New System.Drawing.Point(104, 8)
Me.cboToolsSubSystem.Name = "cboToolsSubSystem"
Me.cboToolsSubSystem.Size = New System.Drawing.Size(176, 21)
Me.cboToolsSubSystem.TabIndex = 223
'
'Label224
'
Me.Label224.Location = New System.Drawing.Point(8, 8)
Me.Label224.Name = "Label224"
Me.Label224.Size = New System.Drawing.Size(88, 16)
Me.Label224.TabIndex = 222
Me.Label224.Text = "Sub System"
'
'cboGaugeStatus
'
Me.cboGaugeStatus.Items.AddRange(New Object() {"True", "False"})
Me.cboGaugeStatus.Location = New System.Drawing.Point(272, 139)
Me.cboGaugeStatus.Name = "cboGaugeStatus"
Me.cboGaugeStatus.Size = New System.Drawing.Size(88, 21)
Me.cboGaugeStatus.TabIndex = 221
'
'cmdAddActualToolLife
'
Me.cmdAddActualToolLife.Location = New System.Drawing.Point(712, 112)
Me.cmdAddActualToolLife.Name = "cmdAddActualToolLife"
Me.cmdAddActualToolLife.Size = New System.Drawing.Size(40, 24)
Me.cmdAddActualToolLife.TabIndex = 220
Me.cmdAddActualToolLife.Text = "Add"
'
'tulAddToolLife_button
'
Me.tulAddToolLife_button.Location = New System.Drawing.Point(712, 80)
Me.tulAddToolLife_button.Name = "tulAddToolLife_button"
Me.tulAddToolLife_button.Size = New System.Drawing.Size(40, 24)
Me.tulAddToolLife_button.TabIndex = 219
Me.tulAddToolLife_button.Text = "Add"
'
'tul1ComboToolOffset
'
Me.tul1ComboToolOffset.Location = New System.Drawing.Point(664, 248)
Me.tul1ComboToolOffset.Name = "tul1ComboToolOffset"
Me.tul1ComboToolOffset.Size = New System.Drawing.Size(104, 21)
Me.tul1ComboToolOffset.TabIndex = 212
'
'tul1ComboNoseRComp
'
Me.tul1ComboNoseRComp.Location = New System.Drawing.Point(664, 216)
Me.tul1ComboNoseRComp.Name = "tul1ComboNoseRComp"
Me.tul1ComboNoseRComp.Size = New System.Drawing.Size(104, 21)
Me.tul1ComboNoseRComp.TabIndex = 211
'
'tulButtonToolWear
'
Me.tulButtonToolWear.Location = New System.Drawing.Point(560, 280)
Me.tulButtonToolWear.Name = "tulButtonToolWear"
Me.tulButtonToolWear.Size = New System.Drawing.Size(96, 24)
Me.tulButtonToolWear.TabIndex = 210
Me.tulButtonToolWear.Text = "ToolWearOffset"
'
'tulButtonToolOffset
'
Me.tulButtonToolOffset.Location = New System.Drawing.Point(560, 248)
Me.tulButtonToolOffset.Name = "tulButtonToolOffset"
Me.tulButtonToolOffset.Size = New System.Drawing.Size(96, 24)
Me.tulButtonToolOffset.TabIndex = 209
Me.tulButtonToolOffset.Text = "ToolOffset"
'
'tulButtonNoseRComp
'
Me.tulButtonNoseRComp.Location = New System.Drawing.Point(560, 216)
Me.tulButtonNoseRComp.Name = "tulButtonNoseRComp"
Me.tulButtonNoseRComp.Size = New System.Drawing.Size(96, 24)
Me.tulButtonNoseRComp.TabIndex = 208
Me.tulButtonNoseRComp.Text = "NoseRComp"
'
'tulButtonNoseRPattern
'
Me.tulButtonNoseRPattern.Location = New System.Drawing.Point(560, 184)
Me.tulButtonNoseRPattern.Name = "tulButtonNoseRPattern"
Me.tulButtonNoseRPattern.Size = New System.Drawing.Size(96, 24)
Me.tulButtonNoseRPattern.TabIndex = 206
Me.tulButtonNoseRPattern.Text = "NoseRPattern"
'
'tulResults
'
Me.tulResults.Location = New System.Drawing.Point(552, 312)
Me.tulResults.Multiline = true
Me.tulResults.Name = "tulResults"
Me.tulResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.tulResults.Size = New System.Drawing.Size(208, 112)
Me.tulResults.TabIndex = 205
Me.tulResults.Text = ""
'
'TulNoseRCompensationPatternTo
'
Me.TulNoseRCompensationPatternTo.Location = New System.Drawing.Point(712, 152)
Me.TulNoseRCompensationPatternTo.Name = "TulNoseRCompensationPatternTo"
Me.TulNoseRCompensationPatternTo.Size = New System.Drawing.Size(48, 20)
Me.TulNoseRCompensationPatternTo.TabIndex = 204
Me.TulNoseRCompensationPatternTo.Text = "10"
'
'Label9
'
Me.Label9.Location = New System.Drawing.Point(688, 152)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(24, 16)
Me.Label9.TabIndex = 203
Me.Label9.Text = "To"
'
'Label8
'
Me.Label8.Location = New System.Drawing.Point(560, 152)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(40, 16)
Me.Label8.TabIndex = 202
Me.Label8.Text = "From"
'
'TulNoseRCompensationPatternFrom
'
Me.TulNoseRCompensationPatternFrom.Location = New System.Drawing.Point(608, 152)
Me.TulNoseRCompensationPatternFrom.Name = "TulNoseRCompensationPatternFrom"
Me.TulNoseRCompensationPatternFrom.Size = New System.Drawing.Size(48, 20)
Me.TulNoseRCompensationPatternFrom.TabIndex = 201
Me.TulNoseRCompensationPatternFrom.Text = "1"
'
'TulAddNoseRCompensation
'
Me.TulAddNoseRCompensation.Location = New System.Drawing.Point(480, 388)
Me.TulAddNoseRCompensation.Name = "TulAddNoseRCompensation"
Me.TulAddNoseRCompensation.Size = New System.Drawing.Size(40, 25)
Me.TulAddNoseRCompensation.TabIndex = 200
Me.TulAddNoseRCompensation.Text = "Add"
'
'tulSetReferenceToolOffset1
'
Me.tulSetReferenceToolOffset1.Location = New System.Drawing.Point(344, 194)
Me.tulSetReferenceToolOffset1.Name = "tulSetReferenceToolOffset1"
Me.tulSetReferenceToolOffset1.Size = New System.Drawing.Size(40, 24)
Me.tulSetReferenceToolOffset1.TabIndex = 199
Me.tulSetReferenceToolOffset1.Text = "Set"
'
'tulUpdReferenceToolOffset1
'
Me.tulUpdReferenceToolOffset1.ForeColor = System.Drawing.Color.Red
Me.tulUpdReferenceToolOffset1.Location = New System.Drawing.Point(272, 194)
Me.tulUpdReferenceToolOffset1.Name = "tulUpdReferenceToolOffset1"
Me.tulUpdReferenceToolOffset1.Size = New System.Drawing.Size(64, 20)
Me.tulUpdReferenceToolOffset1.TabIndex = 198
Me.tulUpdReferenceToolOffset1.Text = "0"
'
'tulReferenceToolOffset1
'
Me.tulReferenceToolOffset1.Location = New System.Drawing.Point(200, 194)
Me.tulReferenceToolOffset1.Name = "tulReferenceToolOffset1"
Me.tulReferenceToolOffset1.ReadOnly = true
Me.tulReferenceToolOffset1.Size = New System.Drawing.Size(64, 20)
Me.tulReferenceToolOffset1.TabIndex = 197
Me.tulReferenceToolOffset1.Text = "0"
'
'Label7
'
Me.Label7.Location = New System.Drawing.Point(8, 194)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(136, 16)
Me.Label7.TabIndex = 196
Me.Label7.Text = "Reference ToolOffset 1"
'
'tulComboActualToolLife
'
Me.tulComboActualToolLife.Location = New System.Drawing.Point(536, 112)
Me.tulComboActualToolLife.Name = "tulComboActualToolLife"
Me.tulComboActualToolLife.Size = New System.Drawing.Size(120, 21)
Me.tulComboActualToolLife.TabIndex = 195
'
'tulSetActualToolLife
'
Me.tulSetActualToolLife.Location = New System.Drawing.Point(664, 112)
Me.tulSetActualToolLife.Name = "tulSetActualToolLife"
Me.tulSetActualToolLife.Size = New System.Drawing.Size(40, 24)
Me.tulSetActualToolLife.TabIndex = 194
Me.tulSetActualToolLife.Text = "Set"
'
'tulUpdActualToolLife
'
Me.tulUpdActualToolLife.ForeColor = System.Drawing.Color.Red
Me.tulUpdActualToolLife.Location = New System.Drawing.Point(480, 112)
Me.tulUpdActualToolLife.Name = "tulUpdActualToolLife"
Me.tulUpdActualToolLife.Size = New System.Drawing.Size(48, 20)
Me.tulUpdActualToolLife.TabIndex = 193
Me.tulUpdActualToolLife.Text = "0"
'
'tulActualToolLife
'
Me.tulActualToolLife.Location = New System.Drawing.Point(416, 112)
Me.tulActualToolLife.Name = "tulActualToolLife"
Me.tulActualToolLife.Size = New System.Drawing.Size(56, 20)
Me.tulActualToolLife.TabIndex = 192
Me.tulActualToolLife.Text = "0"
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(328, 112)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(88, 16)
Me.Label5.TabIndex = 191
Me.Label5.Text = "Actual Tool Life"
'
'TulSetNoseRCompensationPattern
'
Me.TulSetNoseRCompensationPattern.Location = New System.Drawing.Point(664, 48)
Me.TulSetNoseRCompensationPattern.Name = "TulSetNoseRCompensationPattern"
Me.TulSetNoseRCompensationPattern.Size = New System.Drawing.Size(40, 24)
Me.TulSetNoseRCompensationPattern.TabIndex = 190
Me.TulSetNoseRCompensationPattern.Text = "Set"
'
'TulUpdNoseRCompensationPattern
'
Me.TulUpdNoseRCompensationPattern.ForeColor = System.Drawing.Color.Red
Me.TulUpdNoseRCompensationPattern.Location = New System.Drawing.Point(608, 48)
Me.TulUpdNoseRCompensationPattern.Name = "TulUpdNoseRCompensationPattern"
Me.TulUpdNoseRCompensationPattern.Size = New System.Drawing.Size(48, 20)
Me.TulUpdNoseRCompensationPattern.TabIndex = 189
Me.TulUpdNoseRCompensationPattern.Text = "0"
'
'TulNoseRCompensationPattern
'
Me.TulNoseRCompensationPattern.Location = New System.Drawing.Point(552, 48)
Me.TulNoseRCompensationPattern.Name = "TulNoseRCompensationPattern"
Me.TulNoseRCompensationPattern.Size = New System.Drawing.Size(56, 20)
Me.TulNoseRCompensationPattern.TabIndex = 188
Me.TulNoseRCompensationPattern.Text = "0"
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(376, 48)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(168, 16)
Me.Label4.TabIndex = 187
Me.Label4.Text = "Nose R Compensation Pattern"
'
'TulComboNoseRCompensation
'
Me.TulComboNoseRCompensation.Location = New System.Drawing.Point(304, 388)
Me.TulComboNoseRCompensation.Name = "TulComboNoseRCompensation"
Me.TulComboNoseRCompensation.Size = New System.Drawing.Size(120, 21)
Me.TulComboNoseRCompensation.TabIndex = 186
'
'TulSetNoseRCompensation
'
Me.TulSetNoseRCompensation.Location = New System.Drawing.Point(432, 388)
Me.TulSetNoseRCompensation.Name = "TulSetNoseRCompensation"
Me.TulSetNoseRCompensation.Size = New System.Drawing.Size(40, 25)
Me.TulSetNoseRCompensation.TabIndex = 185
Me.TulSetNoseRCompensation.Text = "Set"
'
'TulUpdNoseRCompensation
'
Me.TulUpdNoseRCompensation.ForeColor = System.Drawing.Color.Red
Me.TulUpdNoseRCompensation.Location = New System.Drawing.Point(232, 388)
Me.TulUpdNoseRCompensation.Name = "TulUpdNoseRCompensation"
Me.TulUpdNoseRCompensation.Size = New System.Drawing.Size(64, 20)
Me.TulUpdNoseRCompensation.TabIndex = 184
Me.TulUpdNoseRCompensation.Text = "0"
'
'TulNoseRCompensation
'
Me.TulNoseRCompensation.Location = New System.Drawing.Point(160, 388)
Me.TulNoseRCompensation.Name = "TulNoseRCompensation"
Me.TulNoseRCompensation.ReadOnly = true
Me.TulNoseRCompensation.Size = New System.Drawing.Size(56, 20)
Me.TulNoseRCompensation.TabIndex = 183
Me.TulNoseRCompensation.Text = "0"
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(8, 395)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(120, 17)
Me.Label3.TabIndex = 182
Me.Label3.Text = "Nose R Compensation"
'
'tulComboToolWearOffset
'
Me.tulComboToolWearOffset.Location = New System.Drawing.Point(304, 416)
Me.tulComboToolWearOffset.Name = "tulComboToolWearOffset"
Me.tulComboToolWearOffset.Size = New System.Drawing.Size(120, 21)
Me.tulComboToolWearOffset.TabIndex = 181
'
'tulComboToolLife
'
Me.tulComboToolLife.Location = New System.Drawing.Point(536, 80)
Me.tulComboToolLife.Name = "tulComboToolLife"
Me.tulComboToolLife.Size = New System.Drawing.Size(120, 21)
Me.tulComboToolLife.TabIndex = 180
'
'tulComboToolOffset
'
Me.tulComboToolOffset.Location = New System.Drawing.Point(304, 367)
Me.tulComboToolOffset.Name = "tulComboToolOffset"
Me.tulComboToolOffset.Size = New System.Drawing.Size(120, 21)
Me.tulComboToolOffset.TabIndex = 179
'
'tulUpdGroupNumber
'
Me.tulUpdGroupNumber.Location = New System.Drawing.Point(272, 166)
Me.tulUpdGroupNumber.Name = "tulUpdGroupNumber"
Me.tulUpdGroupNumber.Size = New System.Drawing.Size(64, 20)
Me.tulUpdGroupNumber.TabIndex = 178
Me.tulUpdGroupNumber.Text = "0"
'
'tulSetGroupNumber
'
Me.tulSetGroupNumber.Location = New System.Drawing.Point(344, 166)
Me.tulSetGroupNumber.Name = "tulSetGroupNumber"
Me.tulSetGroupNumber.Size = New System.Drawing.Size(40, 25)
Me.tulSetGroupNumber.TabIndex = 177
Me.tulSetGroupNumber.Text = "Set"
'
'tulAddToolWearOffset
'
Me.tulAddToolWearOffset.Location = New System.Drawing.Point(480, 416)
Me.tulAddToolWearOffset.Name = "tulAddToolWearOffset"
Me.tulAddToolWearOffset.Size = New System.Drawing.Size(40, 23)
Me.tulAddToolWearOffset.TabIndex = 176
Me.tulAddToolWearOffset.Text = "Add"
'
'tulUpdLifeStatus
'
Me.tulUpdLifeStatus.Items.AddRange(New Object() {"True", "False"})
Me.tulUpdLifeStatus.Location = New System.Drawing.Point(272, 263)
Me.tulUpdLifeStatus.Name = "tulUpdLifeStatus"
Me.tulUpdLifeStatus.Size = New System.Drawing.Size(120, 21)
Me.tulUpdLifeStatus.TabIndex = 174
'
'tulToolNumber
'
Me.tulToolNumber.Location = New System.Drawing.Point(144, 48)
Me.tulToolNumber.Name = "tulToolNumber"
Me.tulToolNumber.Size = New System.Drawing.Size(64, 20)
Me.tulToolNumber.TabIndex = 172
Me.tulToolNumber.Text = "1"
'
'label100
'
Me.label100.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.label100.Location = New System.Drawing.Point(8, 48)
Me.label100.Name = "label100"
Me.label100.Size = New System.Drawing.Size(136, 16)
Me.label100.TabIndex = 171
Me.label100.Text = "Tool Number/Offset"
'
'tulUpdateButton
'
Me.tulUpdateButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.tulUpdateButton.Location = New System.Drawing.Point(272, 48)
Me.tulUpdateButton.Name = "tulUpdateButton"
Me.tulUpdateButton.Size = New System.Drawing.Size(72, 24)
Me.tulUpdateButton.TabIndex = 167
Me.tulUpdateButton.Text = "Update"
'
'tulSetToolWearOffset
'
Me.tulSetToolWearOffset.Location = New System.Drawing.Point(432, 416)
Me.tulSetToolWearOffset.Name = "tulSetToolWearOffset"
Me.tulSetToolWearOffset.Size = New System.Drawing.Size(40, 23)
Me.tulSetToolWearOffset.TabIndex = 166
Me.tulSetToolWearOffset.Text = "Set"
'
'tulUpdToolWearOffset
'
Me.tulUpdToolWearOffset.ForeColor = System.Drawing.Color.Red
Me.tulUpdToolWearOffset.Location = New System.Drawing.Point(232, 416)
Me.tulUpdToolWearOffset.Name = "tulUpdToolWearOffset"
Me.tulUpdToolWearOffset.Size = New System.Drawing.Size(64, 20)
Me.tulUpdToolWearOffset.TabIndex = 165
Me.tulUpdToolWearOffset.Text = "0"
'
'tulToolWearOffset
'
Me.tulToolWearOffset.Location = New System.Drawing.Point(160, 416)
Me.tulToolWearOffset.Name = "tulToolWearOffset"
Me.tulToolWearOffset.ReadOnly = true
Me.tulToolWearOffset.Size = New System.Drawing.Size(64, 20)
Me.tulToolWearOffset.TabIndex = 164
Me.tulToolWearOffset.Text = "0"
'
'tulSetToolLife
'
Me.tulSetToolLife.Location = New System.Drawing.Point(664, 80)
Me.tulSetToolLife.Name = "tulSetToolLife"
Me.tulSetToolLife.Size = New System.Drawing.Size(40, 24)
Me.tulSetToolLife.TabIndex = 160
Me.tulSetToolLife.Text = "Set"
'
'tulUpdToolLife
'
Me.tulUpdToolLife.ForeColor = System.Drawing.Color.Red
Me.tulUpdToolLife.Location = New System.Drawing.Point(464, 80)
Me.tulUpdToolLife.Name = "tulUpdToolLife"
Me.tulUpdToolLife.Size = New System.Drawing.Size(64, 20)
Me.tulUpdToolLife.TabIndex = 159
Me.tulUpdToolLife.Text = "0"
'
'tulToolLife
'
Me.tulToolLife.Location = New System.Drawing.Point(392, 80)
Me.tulToolLife.Name = "tulToolLife"
Me.tulToolLife.Size = New System.Drawing.Size(64, 20)
Me.tulToolLife.TabIndex = 158
Me.tulToolLife.Text = "0"
'
'tulAddToolOffset
'
Me.tulAddToolOffset.Location = New System.Drawing.Point(480, 367)
Me.tulAddToolOffset.Name = "tulAddToolOffset"
Me.tulAddToolOffset.Size = New System.Drawing.Size(40, 25)
Me.tulAddToolOffset.TabIndex = 155
Me.tulAddToolOffset.Text = "Add"
'
'tulSetToolOffset
'
Me.tulSetToolOffset.Location = New System.Drawing.Point(432, 367)
Me.tulSetToolOffset.Name = "tulSetToolOffset"
Me.tulSetToolOffset.Size = New System.Drawing.Size(40, 25)
Me.tulSetToolOffset.TabIndex = 154
Me.tulSetToolOffset.Text = "Set"
'
'tulUpdToolOffset
'
Me.tulUpdToolOffset.ForeColor = System.Drawing.Color.Red
Me.tulUpdToolOffset.Location = New System.Drawing.Point(232, 367)
Me.tulUpdToolOffset.Name = "tulUpdToolOffset"
Me.tulUpdToolOffset.Size = New System.Drawing.Size(64, 20)
Me.tulUpdToolOffset.TabIndex = 153
Me.tulUpdToolOffset.Text = "0"
'
'tulToolOffset
'
Me.tulToolOffset.Location = New System.Drawing.Point(160, 367)
Me.tulToolOffset.Name = "tulToolOffset"
Me.tulToolOffset.ReadOnly = true
Me.tulToolOffset.Size = New System.Drawing.Size(64, 20)
Me.tulToolOffset.TabIndex = 152
Me.tulToolOffset.Text = "0"
'
'Label86
'
Me.Label86.Location = New System.Drawing.Point(8, 374)
Me.Label86.Name = "Label86"
Me.Label86.Size = New System.Drawing.Size(136, 17)
Me.Label86.TabIndex = 151
Me.Label86.Text = "Tool Offset"
'
'tulSetToolNumberInGroup
'
Me.tulSetToolNumberInGroup.Location = New System.Drawing.Point(307, 340)
Me.tulSetToolNumberInGroup.Name = "tulSetToolNumberInGroup"
Me.tulSetToolNumberInGroup.Size = New System.Drawing.Size(40, 24)
Me.tulSetToolNumberInGroup.TabIndex = 148
Me.tulSetToolNumberInGroup.Text = "Set"
'
'tulUpdToolNumberInGroup
'
Me.tulUpdToolNumberInGroup.ForeColor = System.Drawing.Color.Red
Me.tulUpdToolNumberInGroup.Location = New System.Drawing.Point(232, 340)
Me.tulUpdToolNumberInGroup.Name = "tulUpdToolNumberInGroup"
Me.tulUpdToolNumberInGroup.Size = New System.Drawing.Size(64, 20)
Me.tulUpdToolNumberInGroup.TabIndex = 147
Me.tulUpdToolNumberInGroup.Text = "0"
'
'tulToolNumberInGroup
'
Me.tulToolNumberInGroup.Location = New System.Drawing.Point(160, 340)
Me.tulToolNumberInGroup.Name = "tulToolNumberInGroup"
Me.tulToolNumberInGroup.ReadOnly = true
Me.tulToolNumberInGroup.Size = New System.Drawing.Size(64, 20)
Me.tulToolNumberInGroup.TabIndex = 146
Me.tulToolNumberInGroup.Text = "0"
'
'Label85
'
Me.Label85.Location = New System.Drawing.Point(8, 347)
Me.Label85.Name = "Label85"
Me.Label85.Size = New System.Drawing.Size(136, 15)
Me.Label85.TabIndex = 145
Me.Label85.Text = "Tool Number In Group"
'
'tulMaxToolOffset
'
Me.tulMaxToolOffset.Location = New System.Drawing.Point(200, 291)
Me.tulMaxToolOffset.Name = "tulMaxToolOffset"
Me.tulMaxToolOffset.ReadOnly = true
Me.tulMaxToolOffset.Size = New System.Drawing.Size(64, 20)
Me.tulMaxToolOffset.TabIndex = 134
Me.tulMaxToolOffset.Text = "0"
'
'Label83
'
Me.Label83.Location = New System.Drawing.Point(8, 291)
Me.Label83.Name = "Label83"
Me.Label83.Size = New System.Drawing.Size(136, 16)
Me.Label83.TabIndex = 133
Me.Label83.Text = "Max Tool Offset"
'
'tulSetLifeStatus
'
Me.tulSetLifeStatus.Location = New System.Drawing.Point(400, 263)
Me.tulSetLifeStatus.Name = "tulSetLifeStatus"
Me.tulSetLifeStatus.Size = New System.Drawing.Size(40, 25)
Me.tulSetLifeStatus.TabIndex = 130
Me.tulSetLifeStatus.Text = "Set"
'
'tulLifeStatus
'
Me.tulLifeStatus.Location = New System.Drawing.Point(200, 263)
Me.tulLifeStatus.Name = "tulLifeStatus"
Me.tulLifeStatus.ReadOnly = true
Me.tulLifeStatus.Size = New System.Drawing.Size(64, 20)
Me.tulLifeStatus.TabIndex = 128
Me.tulLifeStatus.Text = "0"
'
'Label82
'
Me.Label82.Location = New System.Drawing.Point(8, 263)
Me.Label82.Name = "Label82"
Me.Label82.Size = New System.Drawing.Size(136, 16)
Me.Label82.TabIndex = 127
Me.Label82.Text = "Life Status"
'
'tulSetReferenceToolOffset3
'
Me.tulSetReferenceToolOffset3.Location = New System.Drawing.Point(344, 243)
Me.tulSetReferenceToolOffset3.Name = "tulSetReferenceToolOffset3"
Me.tulSetReferenceToolOffset3.Size = New System.Drawing.Size(40, 24)
Me.tulSetReferenceToolOffset3.TabIndex = 110
Me.tulSetReferenceToolOffset3.Text = "Set"
'
'tulSetReferenceToolOffset2
'
Me.tulSetReferenceToolOffset2.Location = New System.Drawing.Point(344, 215)
Me.tulSetReferenceToolOffset2.Name = "tulSetReferenceToolOffset2"
Me.tulSetReferenceToolOffset2.Size = New System.Drawing.Size(40, 24)
Me.tulSetReferenceToolOffset2.TabIndex = 109
Me.tulSetReferenceToolOffset2.Text = "Set"
'
'tulSetGauseStatus
'
Me.tulSetGauseStatus.Location = New System.Drawing.Point(368, 139)
Me.tulSetGauseStatus.Name = "tulSetGauseStatus"
Me.tulSetGauseStatus.Size = New System.Drawing.Size(40, 24)
Me.tulSetGauseStatus.TabIndex = 107
Me.tulSetGauseStatus.Text = "Set"
'
'tulUpdReferenceToolOffset3
'
Me.tulUpdReferenceToolOffset3.ForeColor = System.Drawing.Color.Red
Me.tulUpdReferenceToolOffset3.Location = New System.Drawing.Point(272, 243)
Me.tulUpdReferenceToolOffset3.Name = "tulUpdReferenceToolOffset3"
Me.tulUpdReferenceToolOffset3.Size = New System.Drawing.Size(64, 20)
Me.tulUpdReferenceToolOffset3.TabIndex = 102
Me.tulUpdReferenceToolOffset3.Text = "0"
'
'tulUpdReferenceToolOffset2
'
Me.tulUpdReferenceToolOffset2.ForeColor = System.Drawing.Color.Red
Me.tulUpdReferenceToolOffset2.Location = New System.Drawing.Point(272, 215)
Me.tulUpdReferenceToolOffset2.Name = "tulUpdReferenceToolOffset2"
Me.tulUpdReferenceToolOffset2.Size = New System.Drawing.Size(64, 20)
Me.tulUpdReferenceToolOffset2.TabIndex = 101
Me.tulUpdReferenceToolOffset2.Text = "0"
'
'tulReferenceToolOffset3
'
Me.tulReferenceToolOffset3.Location = New System.Drawing.Point(200, 243)
Me.tulReferenceToolOffset3.Name = "tulReferenceToolOffset3"
Me.tulReferenceToolOffset3.ReadOnly = true
Me.tulReferenceToolOffset3.Size = New System.Drawing.Size(64, 20)
Me.tulReferenceToolOffset3.TabIndex = 94
Me.tulReferenceToolOffset3.Text = "0"
'
'Label74
'
Me.Label74.Location = New System.Drawing.Point(8, 243)
Me.Label74.Name = "Label74"
Me.Label74.Size = New System.Drawing.Size(136, 16)
Me.Label74.TabIndex = 93
Me.Label74.Text = "Reference ToolOffset 3"
'
'tulReferenceToolOffset2
'
Me.tulReferenceToolOffset2.Location = New System.Drawing.Point(200, 215)
Me.tulReferenceToolOffset2.Name = "tulReferenceToolOffset2"
Me.tulReferenceToolOffset2.ReadOnly = true
Me.tulReferenceToolOffset2.Size = New System.Drawing.Size(64, 20)
Me.tulReferenceToolOffset2.TabIndex = 92
Me.tulReferenceToolOffset2.Text = "0"
'
'Label75
'
Me.Label75.Location = New System.Drawing.Point(8, 215)
Me.Label75.Name = "Label75"
Me.Label75.Size = New System.Drawing.Size(136, 16)
Me.Label75.TabIndex = 91
Me.Label75.Text = "Reference ToolOffset 2"
'
'tulGroupNumber
'
Me.tulGroupNumber.Location = New System.Drawing.Point(200, 166)
Me.tulGroupNumber.Name = "tulGroupNumber"
Me.tulGroupNumber.ReadOnly = true
Me.tulGroupNumber.Size = New System.Drawing.Size(64, 20)
Me.tulGroupNumber.TabIndex = 90
Me.tulGroupNumber.Text = "0"
'
'Label76
'
Me.Label76.Location = New System.Drawing.Point(8, 166)
Me.Label76.Name = "Label76"
Me.Label76.Size = New System.Drawing.Size(136, 17)
Me.Label76.TabIndex = 89
Me.Label76.Text = "Group Number"
'
'tulCurrentToolOffsetNumber
'
Me.tulCurrentToolOffsetNumber.Location = New System.Drawing.Point(200, 118)
Me.tulCurrentToolOffsetNumber.Name = "tulCurrentToolOffsetNumber"
Me.tulCurrentToolOffsetNumber.ReadOnly = true
Me.tulCurrentToolOffsetNumber.Size = New System.Drawing.Size(64, 20)
Me.tulCurrentToolOffsetNumber.TabIndex = 88
Me.tulCurrentToolOffsetNumber.Text = "0"
'
'Label77
'
Me.Label77.Location = New System.Drawing.Point(8, 118)
Me.Label77.Name = "Label77"
Me.Label77.Size = New System.Drawing.Size(176, 15)
Me.Label77.TabIndex = 87
Me.Label77.Text = "Current Tool Offset Number"
'
'tulGauseStatus
'
Me.tulGauseStatus.Location = New System.Drawing.Point(200, 139)
Me.tulGauseStatus.Name = "tulGauseStatus"
Me.tulGauseStatus.ReadOnly = true
Me.tulGauseStatus.Size = New System.Drawing.Size(64, 20)
Me.tulGauseStatus.TabIndex = 86
Me.tulGauseStatus.Text = "0"
'
'Label78
'
Me.Label78.Location = New System.Drawing.Point(8, 139)
Me.Label78.Name = "Label78"
Me.Label78.Size = New System.Drawing.Size(136, 16)
Me.Label78.TabIndex = 85
Me.Label78.Text = "Gauge Status"
'
'Label79
'
Me.Label79.Location = New System.Drawing.Point(8, 97)
Me.Label79.Name = "Label79"
Me.Label79.Size = New System.Drawing.Size(136, 16)
Me.Label79.TabIndex = 84
Me.Label79.Text = "Current Tool Number"
'
'tulCurrentToolNumber
'
Me.tulCurrentToolNumber.Location = New System.Drawing.Point(200, 97)
Me.tulCurrentToolNumber.Name = "tulCurrentToolNumber"
Me.tulCurrentToolNumber.ReadOnly = true
Me.tulCurrentToolNumber.Size = New System.Drawing.Size(64, 20)
Me.tulCurrentToolNumber.TabIndex = 81
Me.tulCurrentToolNumber.Text = "0"
'
'Label80
'
Me.Label80.Location = New System.Drawing.Point(8, 69)
Me.Label80.Name = "Label80"
Me.Label80.Size = New System.Drawing.Size(186, 17)
Me.Label80.TabIndex = 82
Me.Label80.Text = "Current Nose R Comp Number"
'
'tulCurrentNoseRCompNumber
'
Me.tulCurrentNoseRCompNumber.Location = New System.Drawing.Point(200, 69)
Me.tulCurrentNoseRCompNumber.Name = "tulCurrentNoseRCompNumber"
Me.tulCurrentNoseRCompNumber.ReadOnly = true
Me.tulCurrentNoseRCompNumber.Size = New System.Drawing.Size(64, 20)
Me.tulCurrentNoseRCompNumber.TabIndex = 79
Me.tulCurrentNoseRCompNumber.Text = "0"
'
'TextBox3
'
Me.TextBox3.ForeColor = System.Drawing.Color.Red
Me.TextBox3.Location = New System.Drawing.Point(232, 367)
Me.TextBox3.Name = "TextBox3"
Me.TextBox3.Size = New System.Drawing.Size(64, 20)
Me.TextBox3.TabIndex = 165
Me.TextBox3.Text = "0"
'
'TextBox4
'
Me.TextBox4.Location = New System.Drawing.Point(160, 367)
Me.TextBox4.Name = "TextBox4"
Me.TextBox4.ReadOnly = true
Me.TextBox4.Size = New System.Drawing.Size(64, 20)
Me.TextBox4.TabIndex = 164
Me.TextBox4.Text = "0"
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(8, 423)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(136, 16)
Me.Label6.TabIndex = 163
Me.Label6.Text = "Tool Wear Offset"
'
'TabPage2
'
Me.TabPage2.Controls.Add(Me.Label191)
Me.TabPage2.Controls.Add(Me.mopnhMaxNoofReports)
Me.TabPage2.Controls.Add(Me.objMopnhUpdateButton)
Me.TabPage2.Controls.Add(Me.Label212)
Me.TabPage2.Controls.Add(Me.Label213)
Me.TabPage2.Controls.Add(Me.mopnhTo)
Me.TabPage2.Controls.Add(Me.mopnhFrom)
Me.TabPage2.Controls.Add(Me.GroupBox5)
Me.TabPage2.Controls.Add(Me.GroupBox4)
Me.TabPage2.Controls.Add(Me.CMD_SETOPERATINGHISTORY)
Me.TabPage2.Controls.Add(Me.CMB_OPERATINGHISTORY)
Me.TabPage2.Controls.Add(Me.Label252)
Me.TabPage2.Location = New System.Drawing.Point(4, 22)
Me.TabPage2.Name = "TabPage2"
Me.TabPage2.Size = New System.Drawing.Size(776, 446)
Me.TabPage2.TabIndex = 22
Me.TabPage2.Text = "Macman Operating History"
'
'Label191
'
Me.Label191.Location = New System.Drawing.Point(504, 40)
Me.Label191.Name = "Label191"
Me.Label191.Size = New System.Drawing.Size(168, 24)
Me.Label191.TabIndex = 264
Me.Label191.Text = "Maximum no of operating history"
'
'mopnhMaxNoofReports
'
Me.mopnhMaxNoofReports.Location = New System.Drawing.Point(688, 40)
Me.mopnhMaxNoofReports.Name = "mopnhMaxNoofReports"
Me.mopnhMaxNoofReports.Size = New System.Drawing.Size(72, 20)
Me.mopnhMaxNoofReports.TabIndex = 263
Me.mopnhMaxNoofReports.Text = "0"
'
'objMopnhUpdateButton
'
Me.objMopnhUpdateButton.Location = New System.Drawing.Point(360, 40)
Me.objMopnhUpdateButton.Name = "objMopnhUpdateButton"
Me.objMopnhUpdateButton.TabIndex = 262
Me.objMopnhUpdateButton.Text = "Update"
'
'Label212
'
Me.Label212.Location = New System.Drawing.Point(160, 40)
Me.Label212.Name = "Label212"
Me.Label212.Size = New System.Drawing.Size(32, 23)
Me.Label212.TabIndex = 261
Me.Label212.Text = "To"
'
'Label213
'
Me.Label213.Location = New System.Drawing.Point(16, 40)
Me.Label213.Name = "Label213"
Me.Label213.Size = New System.Drawing.Size(32, 23)
Me.Label213.TabIndex = 260
Me.Label213.Text = "From"
'
'mopnhTo
'
Me.mopnhTo.Location = New System.Drawing.Point(192, 40)
Me.mopnhTo.Name = "mopnhTo"
Me.mopnhTo.TabIndex = 259
Me.mopnhTo.Text = "2"
'
'mopnhFrom
'
Me.mopnhFrom.Location = New System.Drawing.Point(56, 40)
Me.mopnhFrom.Name = "mopnhFrom"
Me.mopnhFrom.TabIndex = 258
Me.mopnhFrom.Text = "1"
'
'GroupBox5
'
Me.GroupBox5.Controls.Add(Me.mopnhPrevAlarmonTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevExternalInputTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevSpindleRunTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevOtherTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevMaintenanceTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevPartWaitingTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevNoOperatorTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevInProSetupTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevNonOperatingTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevCuttingTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevOperatingTime)
Me.GroupBox5.Controls.Add(Me.Label223)
Me.GroupBox5.Controls.Add(Me.Label247)
Me.GroupBox5.Controls.Add(Me.Label250)
Me.GroupBox5.Controls.Add(Me.Label251)
Me.GroupBox5.Controls.Add(Me.Label255)
Me.GroupBox5.Controls.Add(Me.Label257)
Me.GroupBox5.Controls.Add(Me.Label258)
Me.GroupBox5.Controls.Add(Me.Label259)
Me.GroupBox5.Controls.Add(Me.Label260)
Me.GroupBox5.Controls.Add(Me.Label261)
Me.GroupBox5.Controls.Add(Me.Label262)
Me.GroupBox5.Controls.Add(Me.Label263)
Me.GroupBox5.Controls.Add(Me.mopnhPrevRunningTime)
Me.GroupBox5.Location = New System.Drawing.Point(408, 72)
Me.GroupBox5.Name = "GroupBox5"
Me.GroupBox5.Size = New System.Drawing.Size(352, 328)
Me.GroupBox5.TabIndex = 257
Me.GroupBox5.TabStop = false
Me.GroupBox5.Text = "Previousday Operating History"
'
'mopnhPrevAlarmonTime
'
Me.mopnhPrevAlarmonTime.Location = New System.Drawing.Point(120, 288)
Me.mopnhPrevAlarmonTime.Name = "mopnhPrevAlarmonTime"
Me.mopnhPrevAlarmonTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevAlarmonTime.TabIndex = 45
Me.mopnhPrevAlarmonTime.Text = "0"
'
'mopnhPrevExternalInputTime
'
Me.mopnhPrevExternalInputTime.Location = New System.Drawing.Point(120, 264)
Me.mopnhPrevExternalInputTime.Name = "mopnhPrevExternalInputTime"
Me.mopnhPrevExternalInputTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevExternalInputTime.TabIndex = 44
Me.mopnhPrevExternalInputTime.Text = "0"
'
'mopnhPrevSpindleRunTime
'
Me.mopnhPrevSpindleRunTime.Location = New System.Drawing.Point(120, 240)
Me.mopnhPrevSpindleRunTime.Name = "mopnhPrevSpindleRunTime"
Me.mopnhPrevSpindleRunTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevSpindleRunTime.TabIndex = 43
Me.mopnhPrevSpindleRunTime.Text = "0"
'
'mopnhPrevOtherTime
'
Me.mopnhPrevOtherTime.Location = New System.Drawing.Point(120, 216)
Me.mopnhPrevOtherTime.Name = "mopnhPrevOtherTime"
Me.mopnhPrevOtherTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevOtherTime.TabIndex = 42
Me.mopnhPrevOtherTime.Text = "0"
'
'mopnhPrevMaintenanceTime
'
Me.mopnhPrevMaintenanceTime.Location = New System.Drawing.Point(120, 192)
Me.mopnhPrevMaintenanceTime.Name = "mopnhPrevMaintenanceTime"
Me.mopnhPrevMaintenanceTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevMaintenanceTime.TabIndex = 41
Me.mopnhPrevMaintenanceTime.Text = "0"
'
'mopnhPrevPartWaitingTime
'
Me.mopnhPrevPartWaitingTime.Location = New System.Drawing.Point(120, 168)
Me.mopnhPrevPartWaitingTime.Name = "mopnhPrevPartWaitingTime"
Me.mopnhPrevPartWaitingTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevPartWaitingTime.TabIndex = 40
Me.mopnhPrevPartWaitingTime.Text = "0"
'
'mopnhPrevNoOperatorTime
'
Me.mopnhPrevNoOperatorTime.Location = New System.Drawing.Point(120, 144)
Me.mopnhPrevNoOperatorTime.Name = "mopnhPrevNoOperatorTime"
Me.mopnhPrevNoOperatorTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevNoOperatorTime.TabIndex = 39
Me.mopnhPrevNoOperatorTime.Text = "0"
'
'mopnhPrevInProSetupTime
'
Me.mopnhPrevInProSetupTime.Location = New System.Drawing.Point(120, 120)
Me.mopnhPrevInProSetupTime.Name = "mopnhPrevInProSetupTime"
Me.mopnhPrevInProSetupTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevInProSetupTime.TabIndex = 38
Me.mopnhPrevInProSetupTime.Text = "0"
'
'mopnhPrevNonOperatingTime
'
Me.mopnhPrevNonOperatingTime.Location = New System.Drawing.Point(120, 96)
Me.mopnhPrevNonOperatingTime.Name = "mopnhPrevNonOperatingTime"
Me.mopnhPrevNonOperatingTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevNonOperatingTime.TabIndex = 37
Me.mopnhPrevNonOperatingTime.Text = "0"
'
'mopnhPrevCuttingTime
'
Me.mopnhPrevCuttingTime.Location = New System.Drawing.Point(120, 72)
Me.mopnhPrevCuttingTime.Name = "mopnhPrevCuttingTime"
Me.mopnhPrevCuttingTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevCuttingTime.TabIndex = 36
Me.mopnhPrevCuttingTime.Text = "0"
'
'mopnhPrevOperatingTime
'
Me.mopnhPrevOperatingTime.Location = New System.Drawing.Point(120, 48)
Me.mopnhPrevOperatingTime.Name = "mopnhPrevOperatingTime"
Me.mopnhPrevOperatingTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevOperatingTime.TabIndex = 35
Me.mopnhPrevOperatingTime.Text = "0"
'
'Label223
'
Me.Label223.Location = New System.Drawing.Point(32, 288)
Me.Label223.Name = "Label223"
Me.Label223.Size = New System.Drawing.Size(112, 23)
Me.Label223.TabIndex = 34
Me.Label223.Text = "Alarm on Time"
'
'Label247
'
Me.Label247.Location = New System.Drawing.Point(16, 264)
Me.Label247.Name = "Label247"
Me.Label247.Size = New System.Drawing.Size(112, 23)
Me.Label247.TabIndex = 33
Me.Label247.Text = "External input Time"
'
'Label250
'
Me.Label250.Location = New System.Drawing.Point(32, 216)
Me.Label250.Name = "Label250"
Me.Label250.TabIndex = 32
Me.Label250.Text = "Other Time"
'
'Label251
'
Me.Label251.Location = New System.Drawing.Point(16, 192)
Me.Label251.Name = "Label251"
Me.Label251.TabIndex = 31
Me.Label251.Text = "Maintenance Time"
'
'Label255
'
Me.Label255.Location = New System.Drawing.Point(16, 168)
Me.Label255.Name = "Label255"
Me.Label255.TabIndex = 30
Me.Label255.Text = "Part waiting time"
'
'Label257
'
Me.Label257.Location = New System.Drawing.Point(16, 144)
Me.Label257.Name = "Label257"
Me.Label257.TabIndex = 29
Me.Label257.Text = "No Operator Time"
'
'Label258
'
Me.Label258.Location = New System.Drawing.Point(16, 120)
Me.Label258.Name = "Label258"
Me.Label258.TabIndex = 28
Me.Label258.Text = "In-Pro set up Time"
'
'Label259
'
Me.Label259.Location = New System.Drawing.Point(16, 96)
Me.Label259.Name = "Label259"
Me.Label259.Size = New System.Drawing.Size(104, 23)
Me.Label259.TabIndex = 27
Me.Label259.Text = "Non operating Time"
'
'Label260
'
Me.Label260.Location = New System.Drawing.Point(16, 72)
Me.Label260.Name = "Label260"
Me.Label260.TabIndex = 26
Me.Label260.Text = "Cutting TIme"
'
'Label261
'
Me.Label261.Location = New System.Drawing.Point(16, 48)
Me.Label261.Name = "Label261"
Me.Label261.TabIndex = 25
Me.Label261.Text = "Operating Time"
'
'Label262
'
Me.Label262.Location = New System.Drawing.Point(16, 24)
Me.Label262.Name = "Label262"
Me.Label262.Size = New System.Drawing.Size(80, 23)
Me.Label262.TabIndex = 24
Me.Label262.Text = "Running Time"
'
'Label263
'
Me.Label263.Location = New System.Drawing.Point(16, 240)
Me.Label263.Name = "Label263"
Me.Label263.TabIndex = 24
Me.Label263.Text = "Spindle run Time"
'
'mopnhPrevRunningTime
'
Me.mopnhPrevRunningTime.Location = New System.Drawing.Point(120, 24)
Me.mopnhPrevRunningTime.Name = "mopnhPrevRunningTime"
Me.mopnhPrevRunningTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevRunningTime.TabIndex = 24
Me.mopnhPrevRunningTime.Text = "0"
'
'GroupBox4
'
Me.GroupBox4.Controls.Add(Me.mopnhAlarmOnTime)
Me.GroupBox4.Controls.Add(Me.mopnhExternalInputTime)
Me.GroupBox4.Controls.Add(Me.mopnhSpindleRunTime)
Me.GroupBox4.Controls.Add(Me.mopnhOtherTime)
Me.GroupBox4.Controls.Add(Me.mopnhMaintenanceTime)
Me.GroupBox4.Controls.Add(Me.mopnhPartWaitingTime)
Me.GroupBox4.Controls.Add(Me.mopnhNoOperatorTime)
Me.GroupBox4.Controls.Add(Me.mopnhInProSetupTime)
Me.GroupBox4.Controls.Add(Me.mopnhNonOperatingReport)
Me.GroupBox4.Controls.Add(Me.mopnhCuttingTime)
Me.GroupBox4.Controls.Add(Me.mopnhOperatingTime)
Me.GroupBox4.Controls.Add(Me.mopnhRunningTime)
Me.GroupBox4.Controls.Add(Me.Label200)
Me.GroupBox4.Controls.Add(Me.Label201)
Me.GroupBox4.Controls.Add(Me.Label202)
Me.GroupBox4.Controls.Add(Me.Label203)
Me.GroupBox4.Controls.Add(Me.Label204)
Me.GroupBox4.Controls.Add(Me.Label205)
Me.GroupBox4.Controls.Add(Me.Label206)
Me.GroupBox4.Controls.Add(Me.Label207)
Me.GroupBox4.Controls.Add(Me.Label208)
Me.GroupBox4.Controls.Add(Me.Label209)
Me.GroupBox4.Controls.Add(Me.Label210)
Me.GroupBox4.Controls.Add(Me.Label211)
Me.GroupBox4.Location = New System.Drawing.Point(16, 72)
Me.GroupBox4.Name = "GroupBox4"
Me.GroupBox4.Size = New System.Drawing.Size(368, 328)
Me.GroupBox4.TabIndex = 256
Me.GroupBox4.TabStop = false
Me.GroupBox4.Text = "Today Operating History"
'
'mopnhAlarmOnTime
'
Me.mopnhAlarmOnTime.Location = New System.Drawing.Point(128, 288)
Me.mopnhAlarmOnTime.Name = "mopnhAlarmOnTime"
Me.mopnhAlarmOnTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhAlarmOnTime.TabIndex = 23
Me.mopnhAlarmOnTime.Text = "0"
'
'mopnhExternalInputTime
'
Me.mopnhExternalInputTime.Location = New System.Drawing.Point(128, 264)
Me.mopnhExternalInputTime.Name = "mopnhExternalInputTime"
Me.mopnhExternalInputTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhExternalInputTime.TabIndex = 22
Me.mopnhExternalInputTime.Text = "0"
'
'mopnhSpindleRunTime
'
Me.mopnhSpindleRunTime.Location = New System.Drawing.Point(128, 240)
Me.mopnhSpindleRunTime.Name = "mopnhSpindleRunTime"
Me.mopnhSpindleRunTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhSpindleRunTime.TabIndex = 21
Me.mopnhSpindleRunTime.Text = "0"
'
'mopnhOtherTime
'
Me.mopnhOtherTime.Location = New System.Drawing.Point(128, 216)
Me.mopnhOtherTime.Name = "mopnhOtherTime"
Me.mopnhOtherTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhOtherTime.TabIndex = 20
Me.mopnhOtherTime.Text = "0"
'
'mopnhMaintenanceTime
'
Me.mopnhMaintenanceTime.Location = New System.Drawing.Point(128, 192)
Me.mopnhMaintenanceTime.Name = "mopnhMaintenanceTime"
Me.mopnhMaintenanceTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhMaintenanceTime.TabIndex = 19
Me.mopnhMaintenanceTime.Text = "0"
'
'mopnhPartWaitingTime
'
Me.mopnhPartWaitingTime.Location = New System.Drawing.Point(128, 168)
Me.mopnhPartWaitingTime.Name = "mopnhPartWaitingTime"
Me.mopnhPartWaitingTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhPartWaitingTime.TabIndex = 18
Me.mopnhPartWaitingTime.Text = "0"
'
'mopnhNoOperatorTime
'
Me.mopnhNoOperatorTime.Location = New System.Drawing.Point(128, 144)
Me.mopnhNoOperatorTime.Name = "mopnhNoOperatorTime"
Me.mopnhNoOperatorTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhNoOperatorTime.TabIndex = 17
Me.mopnhNoOperatorTime.Text = "0"
'
'mopnhInProSetupTime
'
Me.mopnhInProSetupTime.Location = New System.Drawing.Point(128, 120)
Me.mopnhInProSetupTime.Name = "mopnhInProSetupTime"
Me.mopnhInProSetupTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhInProSetupTime.TabIndex = 16
Me.mopnhInProSetupTime.Text = "0"
'
'mopnhNonOperatingReport
'
Me.mopnhNonOperatingReport.Location = New System.Drawing.Point(128, 96)
Me.mopnhNonOperatingReport.Name = "mopnhNonOperatingReport"
Me.mopnhNonOperatingReport.Size = New System.Drawing.Size(232, 20)
Me.mopnhNonOperatingReport.TabIndex = 15
Me.mopnhNonOperatingReport.Text = "0"
'
'mopnhCuttingTime
'
Me.mopnhCuttingTime.Location = New System.Drawing.Point(128, 72)
Me.mopnhCuttingTime.Name = "mopnhCuttingTime"
Me.mopnhCuttingTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhCuttingTime.TabIndex = 14
Me.mopnhCuttingTime.Text = "0"
'
'mopnhOperatingTime
'
Me.mopnhOperatingTime.Location = New System.Drawing.Point(128, 48)
Me.mopnhOperatingTime.Name = "mopnhOperatingTime"
Me.mopnhOperatingTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhOperatingTime.TabIndex = 13
Me.mopnhOperatingTime.Text = "0"
'
'mopnhRunningTime
'
Me.mopnhRunningTime.Location = New System.Drawing.Point(128, 24)
Me.mopnhRunningTime.Name = "mopnhRunningTime"
Me.mopnhRunningTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhRunningTime.TabIndex = 12
Me.mopnhRunningTime.Text = "0"
'
'Label200
'
Me.Label200.Location = New System.Drawing.Point(8, 288)
Me.Label200.Name = "Label200"
Me.Label200.Size = New System.Drawing.Size(112, 23)
Me.Label200.TabIndex = 11
Me.Label200.Text = "Alarm on Time"
'
'Label201
'
Me.Label201.Location = New System.Drawing.Point(8, 264)
Me.Label201.Name = "Label201"
Me.Label201.Size = New System.Drawing.Size(112, 23)
Me.Label201.TabIndex = 10
Me.Label201.Text = "External input Time"
'
'Label202
'
Me.Label202.Location = New System.Drawing.Point(8, 240)
Me.Label202.Name = "Label202"
Me.Label202.TabIndex = 9
Me.Label202.Text = "Spindle run Time"
'
'Label203
'
Me.Label203.Location = New System.Drawing.Point(8, 224)
Me.Label203.Name = "Label203"
Me.Label203.TabIndex = 8
Me.Label203.Text = "Other Time"
'
'Label204
'
Me.Label204.Location = New System.Drawing.Point(8, 200)
Me.Label204.Name = "Label204"
Me.Label204.TabIndex = 7
Me.Label204.Text = "Maintenance Time"
'
'Label205
'
Me.Label205.Location = New System.Drawing.Point(8, 176)
Me.Label205.Name = "Label205"
Me.Label205.TabIndex = 6
Me.Label205.Text = "Part waiting time"
'
'Label206
'
Me.Label206.Location = New System.Drawing.Point(8, 152)
Me.Label206.Name = "Label206"
Me.Label206.TabIndex = 5
Me.Label206.Text = "No Operator Time"
'
'Label207
'
Me.Label207.Location = New System.Drawing.Point(8, 128)
Me.Label207.Name = "Label207"
Me.Label207.TabIndex = 4
Me.Label207.Text = "In-Pro set up Time"
'
'Label208
'
Me.Label208.Location = New System.Drawing.Point(8, 104)
Me.Label208.Name = "Label208"
Me.Label208.Size = New System.Drawing.Size(104, 23)
Me.Label208.TabIndex = 3
Me.Label208.Text = "Non operating Time"
'
'Label209
'
Me.Label209.Location = New System.Drawing.Point(8, 80)
Me.Label209.Name = "Label209"
Me.Label209.TabIndex = 2
Me.Label209.Text = "Cutting TIme"
'
'Label210
'
Me.Label210.Location = New System.Drawing.Point(8, 56)
Me.Label210.Name = "Label210"
Me.Label210.TabIndex = 1
Me.Label210.Text = "Operating Time"
'
'Label211
'
Me.Label211.Location = New System.Drawing.Point(8, 32)
Me.Label211.Name = "Label211"
Me.Label211.TabIndex = 0
Me.Label211.Text = "Running Time"
'
'CMD_SETOPERATINGHISTORY
'
Me.CMD_SETOPERATINGHISTORY.Location = New System.Drawing.Point(272, 8)
Me.CMD_SETOPERATINGHISTORY.Name = "CMD_SETOPERATINGHISTORY"
Me.CMD_SETOPERATINGHISTORY.Size = New System.Drawing.Size(64, 24)
Me.CMD_SETOPERATINGHISTORY.TabIndex = 255
Me.CMD_SETOPERATINGHISTORY.Text = "Set"
'
'CMB_OPERATINGHISTORY
'
Me.CMB_OPERATINGHISTORY.Location = New System.Drawing.Point(104, 8)
Me.CMB_OPERATINGHISTORY.Name = "CMB_OPERATINGHISTORY"
Me.CMB_OPERATINGHISTORY.Size = New System.Drawing.Size(160, 21)
Me.CMB_OPERATINGHISTORY.TabIndex = 254
'
'Label252
'
Me.Label252.Location = New System.Drawing.Point(16, 8)
Me.Label252.Name = "Label252"
Me.Label252.Size = New System.Drawing.Size(72, 16)
Me.Label252.TabIndex = 253
Me.Label252.Text = "Sub System :"
'
'tab_CMDTool
'
Me.tab_CMDTool.Controls.Add(Me.GroupBox8)
Me.tab_CMDTool.Controls.Add(Me.GroupBox7)
Me.tab_CMDTool.Controls.Add(Me.Label130)
Me.tab_CMDTool.Controls.Add(Me.toolToolNo)
Me.tab_CMDTool.Controls.Add(Me.Label127)
Me.tab_CMDTool.Controls.Add(Me.toolCuttingPositionsCombo)
Me.tab_CMDTool.Controls.Add(Me.Label126)
Me.tab_CMDTool.Controls.Add(Me.toolSubSystemsCombo)
Me.tab_CMDTool.Location = New System.Drawing.Point(4, 22)
Me.tab_CMDTool.Name = "tab_CMDTool"
Me.tab_CMDTool.Size = New System.Drawing.Size(776, 446)
Me.tab_CMDTool.TabIndex = 18
Me.tab_CMDTool.Text = "CMDTool"
'
'GroupBox8
'
Me.GroupBox8.Controls.Add(Me.toolOffsetAxis1Combo)
Me.GroupBox8.Controls.Add(Me.Label124)
Me.GroupBox8.Controls.Add(Me.cmdAddToolOffset)
Me.GroupBox8.Controls.Add(Me.cmdAddToolOffsetCuttingPos)
Me.GroupBox8.Controls.Add(Me.cmdSubToolOffset)
Me.GroupBox8.Controls.Add(Me.cmdSubToolOffsetCuttingPos)
Me.GroupBox8.Controls.Add(Me.toolCalToolOffset)
Me.GroupBox8.Controls.Add(Me.toolCalToolOffsetExe)
Me.GroupBox8.Location = New System.Drawing.Point(16, 112)
Me.GroupBox8.Name = "GroupBox8"
Me.GroupBox8.Size = New System.Drawing.Size(352, 312)
Me.GroupBox8.TabIndex = 33
Me.GroupBox8.TabStop = false
'
'toolOffsetAxis1Combo
'
Me.toolOffsetAxis1Combo.Location = New System.Drawing.Point(152, 24)
Me.toolOffsetAxis1Combo.Name = "toolOffsetAxis1Combo"
Me.toolOffsetAxis1Combo.Size = New System.Drawing.Size(120, 21)
Me.toolOffsetAxis1Combo.TabIndex = 0
'
'Label124
'
Me.Label124.Location = New System.Drawing.Point(32, 24)
Me.Label124.Name = "Label124"
Me.Label124.Size = New System.Drawing.Size(104, 16)
Me.Label124.TabIndex = 1
Me.Label124.Text = "Offset Axis 1 :"
'
'cmdAddToolOffset
'
Me.cmdAddToolOffset.Location = New System.Drawing.Point(16, 64)
Me.cmdAddToolOffset.Name = "cmdAddToolOffset"
Me.cmdAddToolOffset.Size = New System.Drawing.Size(304, 24)
Me.cmdAddToolOffset.TabIndex = 25
Me.cmdAddToolOffset.Text = "Add Constant Tool Offset"
'
'cmdAddToolOffsetCuttingPos
'
Me.cmdAddToolOffsetCuttingPos.Location = New System.Drawing.Point(16, 96)
Me.cmdAddToolOffsetCuttingPos.Name = "cmdAddToolOffsetCuttingPos"
Me.cmdAddToolOffsetCuttingPos.Size = New System.Drawing.Size(304, 24)
Me.cmdAddToolOffsetCuttingPos.TabIndex = 26
Me.cmdAddToolOffsetCuttingPos.Text = "Add Constant Tool Offset with Cutting Position"
'
'cmdSubToolOffset
'
Me.cmdSubToolOffset.Location = New System.Drawing.Point(16, 144)
Me.cmdSubToolOffset.Name = "cmdSubToolOffset"
Me.cmdSubToolOffset.Size = New System.Drawing.Size(304, 24)
Me.cmdSubToolOffset.TabIndex = 29
Me.cmdSubToolOffset.Text = "Subtract Constant Tool Offset"
'
'cmdSubToolOffsetCuttingPos
'
Me.cmdSubToolOffsetCuttingPos.Location = New System.Drawing.Point(16, 176)
Me.cmdSubToolOffsetCuttingPos.Name = "cmdSubToolOffsetCuttingPos"
Me.cmdSubToolOffsetCuttingPos.Size = New System.Drawing.Size(304, 24)
Me.cmdSubToolOffsetCuttingPos.TabIndex = 30
Me.cmdSubToolOffsetCuttingPos.Text = "Subtract Constant Tool Offset with Cutting Position"
'
'toolCalToolOffset
'
Me.toolCalToolOffset.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.toolCalToolOffset.ForeColor = System.Drawing.Color.Black
Me.toolCalToolOffset.Location = New System.Drawing.Point(240, 224)
Me.toolCalToolOffset.Name = "toolCalToolOffset"
Me.toolCalToolOffset.Size = New System.Drawing.Size(80, 26)
Me.toolCalToolOffset.TabIndex = 19
Me.toolCalToolOffset.Text = "0"
'
'toolCalToolOffsetExe
'
Me.toolCalToolOffsetExe.Location = New System.Drawing.Point(16, 224)
Me.toolCalToolOffsetExe.Name = "toolCalToolOffsetExe"
Me.toolCalToolOffsetExe.Size = New System.Drawing.Size(216, 24)
Me.toolCalToolOffsetExe.TabIndex = 18
Me.toolCalToolOffsetExe.Text = "Calculate Tool Offset (Function) :"
'
'GroupBox7
'
Me.GroupBox7.Controls.Add(Me.cmdAddToolWearOffset)
Me.GroupBox7.Controls.Add(Me.toolAddMethod)
Me.GroupBox7.Controls.Add(Me.toolOffsetAxis2Combo)
Me.GroupBox7.Controls.Add(Me.Label125)
Me.GroupBox7.Controls.Add(Me.cmdAddNoseRCuttingPos)
Me.GroupBox7.Controls.Add(Me.cmdAddToolWearOffsetCuttingPos)
Me.GroupBox7.Controls.Add(Me.cmdSubNoseR)
Me.GroupBox7.Controls.Add(Me.cmdSubNoseRCuttingPos)
Me.GroupBox7.Controls.Add(Me.cmdSubToolWearOffsetCuttingPos)
Me.GroupBox7.Controls.Add(Me.toolAutoCalToolOffsetExe)
Me.GroupBox7.Controls.Add(Me.toolMeasureCalToolOffsetExe)
Me.GroupBox7.Controls.Add(Me.Label128)
Me.GroupBox7.Controls.Add(Me.toolSensorDirectionCombo)
Me.GroupBox7.Location = New System.Drawing.Point(384, 8)
Me.GroupBox7.Name = "GroupBox7"
Me.GroupBox7.Size = New System.Drawing.Size(376, 424)
Me.GroupBox7.TabIndex = 32
Me.GroupBox7.TabStop = false
'
'cmdAddToolWearOffset
'
Me.cmdAddToolWearOffset.Location = New System.Drawing.Point(16, 80)
Me.cmdAddToolWearOffset.Name = "cmdAddToolWearOffset"
Me.cmdAddToolWearOffset.Size = New System.Drawing.Size(304, 24)
Me.cmdAddToolWearOffset.TabIndex = 32
Me.cmdAddToolWearOffset.Text = "Add Constant Tool Wear Offset"
'
'toolAddMethod
'
Me.toolAddMethod.Location = New System.Drawing.Point(16, 48)
Me.toolAddMethod.Name = "toolAddMethod"
Me.toolAddMethod.Size = New System.Drawing.Size(304, 24)
Me.toolAddMethod.TabIndex = 11
Me.toolAddMethod.Text = "Add Constant Nose R Comp."
'
'toolOffsetAxis2Combo
'
Me.toolOffsetAxis2Combo.Location = New System.Drawing.Point(136, 16)
Me.toolOffsetAxis2Combo.Name = "toolOffsetAxis2Combo"
Me.toolOffsetAxis2Combo.Size = New System.Drawing.Size(120, 21)
Me.toolOffsetAxis2Combo.TabIndex = 2
'
'Label125
'
Me.Label125.Location = New System.Drawing.Point(16, 16)
Me.Label125.Name = "Label125"
Me.Label125.Size = New System.Drawing.Size(104, 16)
Me.Label125.TabIndex = 3
Me.Label125.Text = "Offset Axis 2 :"
'
'cmdAddNoseRCuttingPos
'
Me.cmdAddNoseRCuttingPos.Location = New System.Drawing.Point(16, 128)
Me.cmdAddNoseRCuttingPos.Name = "cmdAddNoseRCuttingPos"
Me.cmdAddNoseRCuttingPos.Size = New System.Drawing.Size(304, 24)
Me.cmdAddNoseRCuttingPos.TabIndex = 24
Me.cmdAddNoseRCuttingPos.Text = "Add Constant Nose R Comp. with Cutting Position"
'
'cmdAddToolWearOffsetCuttingPos
'
Me.cmdAddToolWearOffsetCuttingPos.Location = New System.Drawing.Point(16, 160)
Me.cmdAddToolWearOffsetCuttingPos.Name = "cmdAddToolWearOffsetCuttingPos"
Me.cmdAddToolWearOffsetCuttingPos.Size = New System.Drawing.Size(304, 24)
Me.cmdAddToolWearOffsetCuttingPos.TabIndex = 27
Me.cmdAddToolWearOffsetCuttingPos.Text = "Add Constant Tool Wear Offset with Cutting Position"
'
'cmdSubNoseR
'
Me.cmdSubNoseR.Location = New System.Drawing.Point(16, 208)
Me.cmdSubNoseR.Name = "cmdSubNoseR"
Me.cmdSubNoseR.Size = New System.Drawing.Size(304, 24)
Me.cmdSubNoseR.TabIndex = 14
Me.cmdSubNoseR.Text = "Subtract Constant Nose R Comp."
'
'cmdSubNoseRCuttingPos
'
Me.cmdSubNoseRCuttingPos.Location = New System.Drawing.Point(16, 240)
Me.cmdSubNoseRCuttingPos.Name = "cmdSubNoseRCuttingPos"
Me.cmdSubNoseRCuttingPos.Size = New System.Drawing.Size(304, 24)
Me.cmdSubNoseRCuttingPos.TabIndex = 28
Me.cmdSubNoseRCuttingPos.Text = "Subtract Constant Nose R Comp. with Cutting Position"
'
'cmdSubToolWearOffsetCuttingPos
'
Me.cmdSubToolWearOffsetCuttingPos.Location = New System.Drawing.Point(16, 272)
Me.cmdSubToolWearOffsetCuttingPos.Name = "cmdSubToolWearOffsetCuttingPos"
Me.cmdSubToolWearOffsetCuttingPos.Size = New System.Drawing.Size(304, 24)
Me.cmdSubToolWearOffsetCuttingPos.TabIndex = 31
Me.cmdSubToolWearOffsetCuttingPos.Text = "Subtract Constant Tool Wear Offset with Cutting Position"
'
'toolAutoCalToolOffsetExe
'
Me.toolAutoCalToolOffsetExe.Location = New System.Drawing.Point(16, 312)
Me.toolAutoCalToolOffsetExe.Name = "toolAutoCalToolOffsetExe"
Me.toolAutoCalToolOffsetExe.Size = New System.Drawing.Size(256, 24)
Me.toolAutoCalToolOffsetExe.TabIndex = 15
Me.toolAutoCalToolOffsetExe.Text = "Auto Calculate Tool Offset (Function) :"
'
'toolMeasureCalToolOffsetExe
'
Me.toolMeasureCalToolOffsetExe.Location = New System.Drawing.Point(16, 376)
Me.toolMeasureCalToolOffsetExe.Name = "toolMeasureCalToolOffsetExe"
Me.toolMeasureCalToolOffsetExe.Size = New System.Drawing.Size(256, 24)
Me.toolMeasureCalToolOffsetExe.TabIndex = 21
Me.toolMeasureCalToolOffsetExe.Text = "Measure Calculate Tool Offset (Function) :"
'
'Label128
'
Me.Label128.Location = New System.Drawing.Point(16, 344)
Me.Label128.Name = "Label128"
Me.Label128.Size = New System.Drawing.Size(112, 16)
Me.Label128.TabIndex = 9
Me.Label128.Text = "Sensor Directions :"
'
'toolSensorDirectionCombo
'
Me.toolSensorDirectionCombo.Location = New System.Drawing.Point(152, 344)
Me.toolSensorDirectionCombo.Name = "toolSensorDirectionCombo"
Me.toolSensorDirectionCombo.Size = New System.Drawing.Size(120, 21)
Me.toolSensorDirectionCombo.TabIndex = 8
'
'Label130
'
Me.Label130.Location = New System.Drawing.Point(16, 80)
Me.Label130.Name = "Label130"
Me.Label130.Size = New System.Drawing.Size(88, 16)
Me.Label130.TabIndex = 13
Me.Label130.Text = "Tool Number(Int) :"
'
'toolToolNo
'
Me.toolToolNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.toolToolNo.ForeColor = System.Drawing.Color.Red
Me.toolToolNo.Location = New System.Drawing.Point(128, 72)
Me.toolToolNo.Name = "toolToolNo"
Me.toolToolNo.Size = New System.Drawing.Size(48, 26)
Me.toolToolNo.TabIndex = 12
Me.toolToolNo.Text = "1"
'
'Label127
'
Me.Label127.Location = New System.Drawing.Point(16, 40)
Me.Label127.Name = "Label127"
Me.Label127.Size = New System.Drawing.Size(104, 16)
Me.Label127.TabIndex = 7
Me.Label127.Text = "Cutting Positions :"
'
'toolCuttingPositionsCombo
'
Me.toolCuttingPositionsCombo.Location = New System.Drawing.Point(128, 40)
Me.toolCuttingPositionsCombo.Name = "toolCuttingPositionsCombo"
Me.toolCuttingPositionsCombo.Size = New System.Drawing.Size(240, 21)
Me.toolCuttingPositionsCombo.TabIndex = 6
'
'Label126
'
Me.Label126.Location = New System.Drawing.Point(16, 8)
Me.Label126.Name = "Label126"
Me.Label126.Size = New System.Drawing.Size(104, 16)
Me.Label126.TabIndex = 5
Me.Label126.Text = "Sub Systems :"
'
'toolSubSystemsCombo
'
Me.toolSubSystemsCombo.Location = New System.Drawing.Point(128, 8)
Me.toolSubSystemsCombo.Name = "toolSubSystemsCombo"
Me.toolSubSystemsCombo.Size = New System.Drawing.Size(240, 21)
Me.toolSubSystemsCombo.TabIndex = 4
'
'Tools2
'
Me.Tools2.Controls.Add(Me.cmdTool2Set)
Me.Tools2.Controls.Add(Me.Panel17)
Me.Tools2.Controls.Add(Me.Label172)
Me.Tools2.Controls.Add(Me.Label173)
Me.Tools2.Controls.Add(Me.cmb_Tool2_DataUnit)
Me.Tools2.Controls.Add(Me.cmb_Tool2_SubSys)
Me.Tools2.Controls.Add(Me.tul2tn)
Me.Tools2.Controls.Add(Me.Label156)
Me.Tools2.Controls.Add(Me.tul2ButtonUpdate)
Me.Tools2.Controls.Add(Me.Label155)
Me.Tools2.Controls.Add(Me.Label154)
Me.Tools2.Controls.Add(Me.tul2pa3)
Me.Tools2.Controls.Add(Me.tul2pa2)
Me.Tools2.Controls.Add(Me.tul2pa1)
Me.Tools2.Controls.Add(Me.tul2ba3)
Me.Tools2.Controls.Add(Me.tul2ba2)
Me.Tools2.Controls.Add(Me.tul2ba1)
Me.Tools2.Controls.Add(Me.tul2Button1)
Me.Tools2.Controls.Add(Me.tul2set1)
Me.Tools2.Controls.Add(Me.tul2get1)
Me.Tools2.Controls.Add(Me.Label151)
Me.Tools2.Controls.Add(Me.tul2Button3)
Me.Tools2.Controls.Add(Me.tul2Button2)
Me.Tools2.Controls.Add(Me.tul2set3)
Me.Tools2.Controls.Add(Me.tul2set2)
Me.Tools2.Controls.Add(Me.tul2get3)
Me.Tools2.Controls.Add(Me.Label152)
Me.Tools2.Controls.Add(Me.tul2get2)
Me.Tools2.Controls.Add(Me.Label153)
Me.Tools2.Location = New System.Drawing.Point(4, 22)
Me.Tools2.Name = "Tools2"
Me.Tools2.Size = New System.Drawing.Size(776, 446)
Me.Tools2.TabIndex = 19
Me.Tools2.Text = "Tool (For B-Axis Control)"
'
'cmdTool2Set
'
Me.cmdTool2Set.Location = New System.Drawing.Point(704, 0)
Me.cmdTool2Set.Name = "cmdTool2Set"
Me.cmdTool2Set.Size = New System.Drawing.Size(56, 24)
Me.cmdTool2Set.TabIndex = 237
Me.cmdTool2Set.Text = "SET"
'
'Panel17
'
Me.Panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel17.Controls.Add(Me.Label166)
Me.Panel17.Controls.Add(Me.txtTool2Input)
Me.Panel17.Controls.Add(Me.Label129)
Me.Panel17.Controls.Add(Me.Label244)
Me.Panel17.Controls.Add(Me.Label243)
Me.Panel17.Controls.Add(Me.Btn_AddCompensation)
Me.Panel17.Controls.Add(Me.Label178)
Me.Panel17.Controls.Add(Me.Cmb_NoseRCompensationAxisIndex)
Me.Panel17.Controls.Add(Me.Btn_GetNose2)
Me.Panel17.Controls.Add(Me.Btn_GetNose)
Me.Panel17.Controls.Add(Me.cmd_Ctools2_setToolOffset)
Me.Panel17.Controls.Add(Me.cmd_Ctools2_AddToolOffset)
Me.Panel17.Controls.Add(Me.txt_CTools2_ToolOffSet)
Me.Panel17.Controls.Add(Me.cbo_Ctools2_getToolOffset)
Me.Panel17.Controls.Add(Me.cbo_Ctools2_ToolOffSetAxisIndex)
Me.Panel17.Controls.Add(Me.txt_CTools2_fromindx)
Me.Panel17.Controls.Add(Me.Label180)
Me.Panel17.Controls.Add(Me.Label181)
Me.Panel17.Controls.Add(Me.txt_CTools2_toindx)
Me.Panel17.Controls.Add(Me.Label182)
Me.Panel17.Controls.Add(Me.Label183)
Me.Panel17.Controls.Add(Me.cbo_Ctools2_Cutpos)
Me.Panel17.Controls.Add(Me.cbo_Ctools2_getToolOffset2)
Me.Panel17.Controls.Add(Me.btn_setCompensation)
Me.Panel17.Controls.Add(Me.txt_CTools2_ToolIntNDX)
Me.Panel17.Controls.Add(Me.txtCTool2_NoseRCompensationPatternSettingValue)
Me.Panel17.Controls.Add(Me.Label184)
Me.Panel17.Location = New System.Drawing.Point(5, 120)
Me.Panel17.Name = "Panel17"
Me.Panel17.Size = New System.Drawing.Size(427, 312)
Me.Panel17.TabIndex = 232
'
'Label166
'
Me.Label166.Location = New System.Drawing.Point(280, 248)
Me.Label166.Name = "Label166"
Me.Label166.Size = New System.Drawing.Size(96, 24)
Me.Label166.TabIndex = 240
Me.Label166.Text = "N.R.Comp Pattern Value"
'
'txtTool2Input
'
Me.txtTool2Input.BackColor = System.Drawing.SystemColors.Window
Me.txtTool2Input.ForeColor = System.Drawing.Color.Red
Me.txtTool2Input.Location = New System.Drawing.Point(112, 112)
Me.txtTool2Input.Name = "txtTool2Input"
Me.txtTool2Input.Size = New System.Drawing.Size(64, 20)
Me.txtTool2Input.TabIndex = 239
Me.txtTool2Input.Text = "0.0"
'
'Label129
'
Me.Label129.Location = New System.Drawing.Point(8, 112)
Me.Label129.Name = "Label129"
Me.Label129.Size = New System.Drawing.Size(40, 24)
Me.Label129.TabIndex = 238
Me.Label129.Text = "Inpput"
'
'Label244
'
Me.Label244.Location = New System.Drawing.Point(136, 176)
Me.Label244.Name = "Label244"
Me.Label244.Size = New System.Drawing.Size(128, 24)
Me.Label244.TabIndex = 237
Me.Label244.Text = "Nose R. Comp Pattern Values"
'
'Label243
'
Me.Label243.Location = New System.Drawing.Point(8, 176)
Me.Label243.Name = "Label243"
Me.Label243.Size = New System.Drawing.Size(120, 32)
Me.Label243.TabIndex = 236
Me.Label243.Text = "Nose R Comp./Offset Values"
'
'Btn_AddCompensation
'
Me.Btn_AddCompensation.Location = New System.Drawing.Point(280, 208)
Me.Btn_AddCompensation.Name = "Btn_AddCompensation"
Me.Btn_AddCompensation.Size = New System.Drawing.Size(136, 32)
Me.Btn_AddCompensation.TabIndex = 11
Me.Btn_AddCompensation.Text = "Add NoseR Compensation"
'
'Label178
'
Me.Label178.Location = New System.Drawing.Point(8, 144)
Me.Label178.Name = "Label178"
Me.Label178.Size = New System.Drawing.Size(88, 23)
Me.Label178.TabIndex = 10
Me.Label178.Text = "Compensation"
'
'Cmb_NoseRCompensationAxisIndex
'
Me.Cmb_NoseRCompensationAxisIndex.Location = New System.Drawing.Point(112, 144)
Me.Cmb_NoseRCompensationAxisIndex.Name = "Cmb_NoseRCompensationAxisIndex"
Me.Cmb_NoseRCompensationAxisIndex.Size = New System.Drawing.Size(120, 21)
Me.Cmb_NoseRCompensationAxisIndex.TabIndex = 9
'
'Btn_GetNose2
'
Me.Btn_GetNose2.Location = New System.Drawing.Point(240, 136)
Me.Btn_GetNose2.Name = "Btn_GetNose2"
Me.Btn_GetNose2.Size = New System.Drawing.Size(176, 32)
Me.Btn_GetNose2.TabIndex = 8
Me.Btn_GetNose2.Text = "Get Nose R Compensation/Pattern"
'
'Btn_GetNose
'
Me.Btn_GetNose.Location = New System.Drawing.Point(240, 104)
Me.Btn_GetNose.Name = "Btn_GetNose"
Me.Btn_GetNose.Size = New System.Drawing.Size(176, 32)
Me.Btn_GetNose.TabIndex = 7
Me.Btn_GetNose.Text = "Get Nose R Compensation/Pattern Range"
'
'cmd_Ctools2_setToolOffset
'
Me.cmd_Ctools2_setToolOffset.Location = New System.Drawing.Point(240, 56)
Me.cmd_Ctools2_setToolOffset.Name = "cmd_Ctools2_setToolOffset"
Me.cmd_Ctools2_setToolOffset.Size = New System.Drawing.Size(176, 23)
Me.cmd_Ctools2_setToolOffset.TabIndex = 3
Me.cmd_Ctools2_setToolOffset.Text = "Set Tool Off Set"
'
'cmd_Ctools2_AddToolOffset
'
Me.cmd_Ctools2_AddToolOffset.Location = New System.Drawing.Point(240, 80)
Me.cmd_Ctools2_AddToolOffset.Name = "cmd_Ctools2_AddToolOffset"
Me.cmd_Ctools2_AddToolOffset.Size = New System.Drawing.Size(176, 23)
Me.cmd_Ctools2_AddToolOffset.TabIndex = 3
Me.cmd_Ctools2_AddToolOffset.Text = "Add Tool Off Set"
'
'txt_CTools2_ToolOffSet
'
Me.txt_CTools2_ToolOffSet.Location = New System.Drawing.Point(8, 208)
Me.txt_CTools2_ToolOffSet.Multiline = true
Me.txt_CTools2_ToolOffSet.Name = "txt_CTools2_ToolOffSet"
Me.txt_CTools2_ToolOffSet.ReadOnly = true
Me.txt_CTools2_ToolOffSet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txt_CTools2_ToolOffSet.Size = New System.Drawing.Size(120, 72)
Me.txt_CTools2_ToolOffSet.TabIndex = 4
Me.txt_CTools2_ToolOffSet.Text = ""
'
'cbo_Ctools2_getToolOffset
'
Me.cbo_Ctools2_getToolOffset.Location = New System.Drawing.Point(240, 8)
Me.cbo_Ctools2_getToolOffset.Name = "cbo_Ctools2_getToolOffset"
Me.cbo_Ctools2_getToolOffset.Size = New System.Drawing.Size(176, 23)
Me.cbo_Ctools2_getToolOffset.TabIndex = 3
Me.cbo_Ctools2_getToolOffset.Text = "Get Tool Off Set Range"
'
'cbo_Ctools2_ToolOffSetAxisIndex
'
Me.cbo_Ctools2_ToolOffSetAxisIndex.Location = New System.Drawing.Point(112, 56)
Me.cbo_Ctools2_ToolOffSetAxisIndex.Name = "cbo_Ctools2_ToolOffSetAxisIndex"
Me.cbo_Ctools2_ToolOffSetAxisIndex.Size = New System.Drawing.Size(120, 21)
Me.cbo_Ctools2_ToolOffSetAxisIndex.TabIndex = 2
'
'txt_CTools2_fromindx
'
Me.txt_CTools2_fromindx.Location = New System.Drawing.Point(112, 8)
Me.txt_CTools2_fromindx.Name = "txt_CTools2_fromindx"
Me.txt_CTools2_fromindx.Size = New System.Drawing.Size(120, 20)
Me.txt_CTools2_fromindx.TabIndex = 1
Me.txt_CTools2_fromindx.Text = "1"
'
'Label180
'
Me.Label180.Location = New System.Drawing.Point(8, 8)
Me.Label180.Name = "Label180"
Me.Label180.Size = New System.Drawing.Size(104, 23)
Me.Label180.TabIndex = 0
Me.Label180.Text = "Index/From Index"
'
'Label181
'
Me.Label181.Location = New System.Drawing.Point(8, 32)
Me.Label181.Name = "Label181"
Me.Label181.Size = New System.Drawing.Size(88, 23)
Me.Label181.TabIndex = 0
Me.Label181.Text = "To Index"
'
'txt_CTools2_toindx
'
Me.txt_CTools2_toindx.Location = New System.Drawing.Point(112, 32)
Me.txt_CTools2_toindx.Name = "txt_CTools2_toindx"
Me.txt_CTools2_toindx.Size = New System.Drawing.Size(120, 20)
Me.txt_CTools2_toindx.TabIndex = 1
Me.txt_CTools2_toindx.Text = "1"
'
'Label182
'
Me.Label182.Location = New System.Drawing.Point(8, 56)
Me.Label182.Name = "Label182"
Me.Label182.Size = New System.Drawing.Size(96, 23)
Me.Label182.TabIndex = 0
Me.Label182.Text = "Offset Axis Index"
'
'Label183
'
Me.Label183.Location = New System.Drawing.Point(8, 80)
Me.Label183.Name = "Label183"
Me.Label183.Size = New System.Drawing.Size(88, 23)
Me.Label183.TabIndex = 0
Me.Label183.Text = "Cutting Position"
'
'cbo_Ctools2_Cutpos
'
Me.cbo_Ctools2_Cutpos.Location = New System.Drawing.Point(112, 80)
Me.cbo_Ctools2_Cutpos.Name = "cbo_Ctools2_Cutpos"
Me.cbo_Ctools2_Cutpos.Size = New System.Drawing.Size(120, 21)
Me.cbo_Ctools2_Cutpos.TabIndex = 2
'
'cbo_Ctools2_getToolOffset2
'
Me.cbo_Ctools2_getToolOffset2.Location = New System.Drawing.Point(240, 32)
Me.cbo_Ctools2_getToolOffset2.Name = "cbo_Ctools2_getToolOffset2"
Me.cbo_Ctools2_getToolOffset2.Size = New System.Drawing.Size(176, 23)
Me.cbo_Ctools2_getToolOffset2.TabIndex = 3
Me.cbo_Ctools2_getToolOffset2.Text = "Get Tool Off Set"
'
'btn_setCompensation
'
Me.btn_setCompensation.Location = New System.Drawing.Point(280, 168)
Me.btn_setCompensation.Name = "btn_setCompensation"
Me.btn_setCompensation.Size = New System.Drawing.Size(136, 40)
Me.btn_setCompensation.TabIndex = 232
Me.btn_setCompensation.Text = "Set Nose R Compensation/Pattern"
'
'txt_CTools2_ToolIntNDX
'
Me.txt_CTools2_ToolIntNDX.Location = New System.Drawing.Point(144, 208)
Me.txt_CTools2_ToolIntNDX.Multiline = true
Me.txt_CTools2_ToolIntNDX.Name = "txt_CTools2_ToolIntNDX"
Me.txt_CTools2_ToolIntNDX.ReadOnly = true
Me.txt_CTools2_ToolIntNDX.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txt_CTools2_ToolIntNDX.Size = New System.Drawing.Size(120, 72)
Me.txt_CTools2_ToolIntNDX.TabIndex = 4
Me.txt_CTools2_ToolIntNDX.Text = ""
'
'txtCTool2_NoseRCompensationPatternSettingValue
'
Me.txtCTool2_NoseRCompensationPatternSettingValue.ForeColor = System.Drawing.Color.Red
Me.txtCTool2_NoseRCompensationPatternSettingValue.Location = New System.Drawing.Point(384, 248)
Me.txtCTool2_NoseRCompensationPatternSettingValue.Name = "txtCTool2_NoseRCompensationPatternSettingValue"
Me.txtCTool2_NoseRCompensationPatternSettingValue.Size = New System.Drawing.Size(32, 20)
Me.txtCTool2_NoseRCompensationPatternSettingValue.TabIndex = 234
Me.txtCTool2_NoseRCompensationPatternSettingValue.Text = ""
'
'Label184
'
Me.Label184.Location = New System.Drawing.Point(280, 280)
Me.Label184.Name = "Label184"
Me.Label184.Size = New System.Drawing.Size(72, 24)
Me.Label184.TabIndex = 235
Me.Label184.Text = "NR Pattern Value"
'
'Label172
'
Me.Label172.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label172.Location = New System.Drawing.Point(231, 0)
Me.Label172.Name = "Label172"
Me.Label172.Size = New System.Drawing.Size(128, 16)
Me.Label172.TabIndex = 226
Me.Label172.Text = "Current Sub System :"
'
'Label173
'
Me.Label173.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label173.Location = New System.Drawing.Point(487, 0)
Me.Label173.Name = "Label173"
Me.Label173.Size = New System.Drawing.Size(80, 16)
Me.Label173.TabIndex = 225
Me.Label173.Text = "Data Unit :"
'
'cmb_Tool2_DataUnit
'
Me.cmb_Tool2_DataUnit.Location = New System.Drawing.Point(575, 0)
Me.cmb_Tool2_DataUnit.Name = "cmb_Tool2_DataUnit"
Me.cmb_Tool2_DataUnit.Size = New System.Drawing.Size(121, 21)
Me.cmb_Tool2_DataUnit.TabIndex = 224
'
'cmb_Tool2_SubSys
'
Me.cmb_Tool2_SubSys.Location = New System.Drawing.Point(367, 0)
Me.cmb_Tool2_SubSys.Name = "cmb_Tool2_SubSys"
Me.cmb_Tool2_SubSys.Size = New System.Drawing.Size(121, 21)
Me.cmb_Tool2_SubSys.TabIndex = 223
'
'tul2tn
'
Me.tul2tn.Location = New System.Drawing.Point(144, 0)
Me.tul2tn.Name = "tul2tn"
Me.tul2tn.Size = New System.Drawing.Size(64, 20)
Me.tul2tn.TabIndex = 222
Me.tul2tn.Text = "1"
'
'Label156
'
Me.Label156.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label156.Location = New System.Drawing.Point(8, 0)
Me.Label156.Name = "Label156"
Me.Label156.Size = New System.Drawing.Size(136, 16)
Me.Label156.TabIndex = 221
Me.Label156.Text = "Tool Number/Offset"
'
'tul2ButtonUpdate
'
Me.tul2ButtonUpdate.Location = New System.Drawing.Point(688, 64)
Me.tul2ButtonUpdate.Name = "tul2ButtonUpdate"
Me.tul2ButtonUpdate.Size = New System.Drawing.Size(72, 24)
Me.tul2ButtonUpdate.TabIndex = 220
Me.tul2ButtonUpdate.Text = "Update"
'
'Label155
'
Me.Label155.Location = New System.Drawing.Point(312, 24)
Me.Label155.Name = "Label155"
Me.Label155.Size = New System.Drawing.Size(136, 16)
Me.Label155.TabIndex = 219
Me.Label155.Text = "B Axis Cutting Position"
'
'Label154
'
Me.Label154.Location = New System.Drawing.Point(160, 24)
Me.Label154.Name = "Label154"
Me.Label154.Size = New System.Drawing.Size(112, 16)
Me.Label154.TabIndex = 218
Me.Label154.Text = "Principal Axis"
'
'tul2pa3
'
Me.tul2pa3.Location = New System.Drawing.Point(152, 88)
Me.tul2pa3.Name = "tul2pa3"
Me.tul2pa3.Size = New System.Drawing.Size(152, 21)
Me.tul2pa3.TabIndex = 217
'
'tul2pa2
'
Me.tul2pa2.Location = New System.Drawing.Point(152, 64)
Me.tul2pa2.Name = "tul2pa2"
Me.tul2pa2.Size = New System.Drawing.Size(152, 21)
Me.tul2pa2.TabIndex = 216
'
'tul2pa1
'
Me.tul2pa1.Location = New System.Drawing.Point(152, 40)
Me.tul2pa1.Name = "tul2pa1"
Me.tul2pa1.Size = New System.Drawing.Size(152, 21)
Me.tul2pa1.TabIndex = 215
'
'tul2ba3
'
Me.tul2ba3.Location = New System.Drawing.Point(304, 88)
Me.tul2ba3.Name = "tul2ba3"
Me.tul2ba3.Size = New System.Drawing.Size(184, 21)
Me.tul2ba3.TabIndex = 214
'
'tul2ba2
'
Me.tul2ba2.Location = New System.Drawing.Point(304, 64)
Me.tul2ba2.Name = "tul2ba2"
Me.tul2ba2.Size = New System.Drawing.Size(184, 21)
Me.tul2ba2.TabIndex = 213
'
'tul2ba1
'
Me.tul2ba1.Location = New System.Drawing.Point(304, 40)
Me.tul2ba1.Name = "tul2ba1"
Me.tul2ba1.Size = New System.Drawing.Size(184, 21)
Me.tul2ba1.TabIndex = 212
'
'tul2Button1
'
Me.tul2Button1.Location = New System.Drawing.Point(640, 40)
Me.tul2Button1.Name = "tul2Button1"
Me.tul2Button1.Size = New System.Drawing.Size(40, 24)
Me.tul2Button1.TabIndex = 211
Me.tul2Button1.Text = "Set"
'
'tul2set1
'
Me.tul2set1.ForeColor = System.Drawing.Color.Red
Me.tul2set1.Location = New System.Drawing.Point(568, 40)
Me.tul2set1.Name = "tul2set1"
Me.tul2set1.Size = New System.Drawing.Size(64, 20)
Me.tul2set1.TabIndex = 210
Me.tul2set1.Text = "0"
'
'tul2get1
'
Me.tul2get1.Location = New System.Drawing.Point(496, 40)
Me.tul2get1.Name = "tul2get1"
Me.tul2get1.ReadOnly = true
Me.tul2get1.Size = New System.Drawing.Size(64, 20)
Me.tul2get1.TabIndex = 209
Me.tul2get1.Text = "0"
'
'Label151
'
Me.Label151.Location = New System.Drawing.Point(8, 40)
Me.Label151.Name = "Label151"
Me.Label151.Size = New System.Drawing.Size(136, 16)
Me.Label151.TabIndex = 208
Me.Label151.Text = "Reference ToolOffset 1"
'
'tul2Button3
'
Me.tul2Button3.Location = New System.Drawing.Point(640, 88)
Me.tul2Button3.Name = "tul2Button3"
Me.tul2Button3.Size = New System.Drawing.Size(40, 24)
Me.tul2Button3.TabIndex = 207
Me.tul2Button3.Text = "Set"
'
'tul2Button2
'
Me.tul2Button2.Location = New System.Drawing.Point(640, 64)
Me.tul2Button2.Name = "tul2Button2"
Me.tul2Button2.Size = New System.Drawing.Size(40, 24)
Me.tul2Button2.TabIndex = 206
Me.tul2Button2.Text = "Set"
'
'tul2set3
'
Me.tul2set3.ForeColor = System.Drawing.Color.Red
Me.tul2set3.Location = New System.Drawing.Point(568, 88)
Me.tul2set3.Name = "tul2set3"
Me.tul2set3.Size = New System.Drawing.Size(64, 20)
Me.tul2set3.TabIndex = 205
Me.tul2set3.Text = "0"
'
'tul2set2
'
Me.tul2set2.ForeColor = System.Drawing.Color.Red
Me.tul2set2.Location = New System.Drawing.Point(568, 64)
Me.tul2set2.Name = "tul2set2"
Me.tul2set2.Size = New System.Drawing.Size(64, 20)
Me.tul2set2.TabIndex = 204
Me.tul2set2.Text = "0"
'
'tul2get3
'
Me.tul2get3.Location = New System.Drawing.Point(496, 88)
Me.tul2get3.Name = "tul2get3"
Me.tul2get3.ReadOnly = true
Me.tul2get3.Size = New System.Drawing.Size(64, 20)
Me.tul2get3.TabIndex = 203
Me.tul2get3.Text = "0"
'
'Label152
'
Me.Label152.Location = New System.Drawing.Point(8, 88)
Me.Label152.Name = "Label152"
Me.Label152.Size = New System.Drawing.Size(136, 16)
Me.Label152.TabIndex = 202
Me.Label152.Text = "Reference ToolOffset 3"
'
'tul2get2
'
Me.tul2get2.Location = New System.Drawing.Point(496, 64)
Me.tul2get2.Name = "tul2get2"
Me.tul2get2.ReadOnly = true
Me.tul2get2.Size = New System.Drawing.Size(64, 20)
Me.tul2get2.TabIndex = 201
Me.tul2get2.Text = "0"
'
'Label153
'
Me.Label153.Location = New System.Drawing.Point(8, 64)
Me.Label153.Name = "Label153"
Me.Label153.Size = New System.Drawing.Size(136, 16)
Me.Label153.TabIndex = 200
Me.Label153.Text = "Reference ToolOffset 2"
'
'Tools3
'
Me.Tools3.Controls.Add(Me.cmdTool3Set)
Me.Tools3.Controls.Add(Me.Label131)
Me.Tools3.Controls.Add(Me.Label132)
Me.Tools3.Controls.Add(Me.cboTool3DataUnit)
Me.Tools3.Controls.Add(Me.cboTool3SubSystem)
Me.Tools3.Controls.Add(Me.Label196)
Me.Tools3.Controls.Add(Me.Label195)
Me.Tools3.Controls.Add(Me.tul3tn)
Me.Tools3.Controls.Add(Me.Label199)
Me.Tools3.Controls.Add(Me.tu3_Update)
Me.Tools3.Controls.Add(Me.Label197)
Me.Tools3.Controls.Add(Me.Label198)
Me.Tools3.Controls.Add(Me.txt_getValue)
Me.Tools3.Controls.Add(Me.tul2AddToolWearOffset)
Me.Tools3.Controls.Add(Me.GetToolWearOffsetButton)
Me.Tools3.Controls.Add(Me.Label194)
Me.Tools3.Controls.Add(Me.tul3get4)
Me.Tools3.Controls.Add(Me.tul3_Set)
Me.Tools3.Controls.Add(Me.txt_double1)
Me.Tools3.Controls.Add(Me.Label192)
Me.Tools3.Controls.Add(Me.Label193)
Me.Tools3.Controls.Add(Me.cmb_ToolWearOffsetAxisIndex)
Me.Tools3.Controls.Add(Me.cmb_CuttingPosition)
Me.Tools3.Controls.Add(Me.txt_ToIndex)
Me.Tools3.Controls.Add(Me.txt_FromIndex)
Me.Tools3.Location = New System.Drawing.Point(4, 22)
Me.Tools3.Name = "Tools3"
Me.Tools3.Size = New System.Drawing.Size(776, 446)
Me.Tools3.TabIndex = 21
Me.Tools3.Text = "Tool Wear (For Multi-Tools System)"
'
'cmdTool3Set
'
Me.cmdTool3Set.Location = New System.Drawing.Point(616, 56)
Me.cmdTool3Set.Name = "cmdTool3Set"
Me.cmdTool3Set.Size = New System.Drawing.Size(56, 24)
Me.cmdTool3Set.TabIndex = 293
Me.cmdTool3Set.Text = "SET"
'
'Label131
'
Me.Label131.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label131.Location = New System.Drawing.Point(16, 56)
Me.Label131.Name = "Label131"
Me.Label131.Size = New System.Drawing.Size(128, 16)
Me.Label131.TabIndex = 292
Me.Label131.Text = "Current Sub System :"
'
'Label132
'
Me.Label132.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label132.Location = New System.Drawing.Point(376, 56)
Me.Label132.Name = "Label132"
Me.Label132.Size = New System.Drawing.Size(80, 16)
Me.Label132.TabIndex = 291
Me.Label132.Text = "Data Unit :"
'
'cboTool3DataUnit
'
Me.cboTool3DataUnit.Location = New System.Drawing.Point(464, 56)
Me.cboTool3DataUnit.Name = "cboTool3DataUnit"
Me.cboTool3DataUnit.Size = New System.Drawing.Size(144, 21)
Me.cboTool3DataUnit.TabIndex = 290
'
'cboTool3SubSystem
'
Me.cboTool3SubSystem.Location = New System.Drawing.Point(152, 56)
Me.cboTool3SubSystem.Name = "cboTool3SubSystem"
Me.cboTool3SubSystem.Size = New System.Drawing.Size(192, 21)
Me.cboTool3SubSystem.TabIndex = 289
'
'Label196
'
Me.Label196.Location = New System.Drawing.Point(16, 184)
Me.Label196.Name = "Label196"
Me.Label196.Size = New System.Drawing.Size(72, 16)
Me.Label196.TabIndex = 288
Me.Label196.Text = "Offset Value"
'
'Label195
'
Me.Label195.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label195.ForeColor = System.Drawing.Color.Red
Me.Label195.Location = New System.Drawing.Point(24, 8)
Me.Label195.Name = "Label195"
Me.Label195.Size = New System.Drawing.Size(736, 40)
Me.Label195.TabIndex = 287
Me.Label195.Text = "Tool Wear For Lathe machine that has Multi-Point System only"
'
'tul3tn
'
Me.tul3tn.Location = New System.Drawing.Point(104, 208)
Me.tul3tn.Name = "tul3tn"
Me.tul3tn.Size = New System.Drawing.Size(48, 20)
Me.tul3tn.TabIndex = 286
Me.tul3tn.Text = "1"
'
'Label199
'
Me.Label199.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label199.Location = New System.Drawing.Point(104, 184)
Me.Label199.Name = "Label199"
Me.Label199.Size = New System.Drawing.Size(88, 16)
Me.Label199.TabIndex = 285
Me.Label199.Text = "Offset Index"
'
'tu3_Update
'
Me.tu3_Update.Location = New System.Drawing.Point(184, 208)
Me.tu3_Update.Name = "tu3_Update"
Me.tu3_Update.Size = New System.Drawing.Size(40, 24)
Me.tu3_Update.TabIndex = 284
Me.tu3_Update.Text = "Get"
'
'Label197
'
Me.Label197.Location = New System.Drawing.Point(312, 136)
Me.Label197.Name = "Label197"
Me.Label197.Size = New System.Drawing.Size(88, 23)
Me.Label197.TabIndex = 283
Me.Label197.Text = "Cutting Position:"
'
'Label198
'
Me.Label198.Location = New System.Drawing.Point(16, 136)
Me.Label198.Name = "Label198"
Me.Label198.Size = New System.Drawing.Size(96, 32)
Me.Label198.TabIndex = 282
Me.Label198.Text = "Tool Wear Offset Axis Index Enum"
'
'txt_getValue
'
Me.txt_getValue.Location = New System.Drawing.Point(464, 232)
Me.txt_getValue.Multiline = true
Me.txt_getValue.Name = "txt_getValue"
Me.txt_getValue.Size = New System.Drawing.Size(288, 192)
Me.txt_getValue.TabIndex = 281
Me.txt_getValue.Text = ""
'
'tul2AddToolWearOffset
'
Me.tul2AddToolWearOffset.Location = New System.Drawing.Point(272, 208)
Me.tul2AddToolWearOffset.Name = "tul2AddToolWearOffset"
Me.tul2AddToolWearOffset.Size = New System.Drawing.Size(40, 24)
Me.tul2AddToolWearOffset.TabIndex = 280
Me.tul2AddToolWearOffset.Text = "Add"
'
'GetToolWearOffsetButton
'
Me.GetToolWearOffsetButton.Location = New System.Drawing.Point(608, 192)
Me.GetToolWearOffsetButton.Name = "GetToolWearOffsetButton"
Me.GetToolWearOffsetButton.Size = New System.Drawing.Size(144, 32)
Me.GetToolWearOffsetButton.TabIndex = 279
Me.GetToolWearOffsetButton.Text = "Get Tool Wear Offset Values"
'
'Label194
'
Me.Label194.Location = New System.Drawing.Point(320, 184)
Me.Label194.Name = "Label194"
Me.Label194.Size = New System.Drawing.Size(80, 23)
Me.Label194.TabIndex = 278
Me.Label194.Text = "Value (double)"
'
'tul3get4
'
Me.tul3get4.ForeColor = System.Drawing.SystemColors.WindowText
Me.tul3get4.Location = New System.Drawing.Point(16, 208)
Me.tul3get4.Name = "tul3get4"
Me.tul3get4.ReadOnly = true
Me.tul3get4.Size = New System.Drawing.Size(48, 20)
Me.tul3get4.TabIndex = 276
Me.tul3get4.Text = "0"
'
'tul3_Set
'
Me.tul3_Set.Location = New System.Drawing.Point(232, 208)
Me.tul3_Set.Name = "tul3_Set"
Me.tul3_Set.Size = New System.Drawing.Size(40, 24)
Me.tul3_Set.TabIndex = 275
Me.tul3_Set.Text = "Set"
'
'txt_double1
'
Me.txt_double1.ForeColor = System.Drawing.Color.Red
Me.txt_double1.Location = New System.Drawing.Point(320, 208)
Me.txt_double1.Name = "txt_double1"
Me.txt_double1.Size = New System.Drawing.Size(48, 20)
Me.txt_double1.TabIndex = 274
Me.txt_double1.Text = "0.0"
'
'Label192
'
Me.Label192.Location = New System.Drawing.Point(528, 176)
Me.Label192.Name = "Label192"
Me.Label192.Size = New System.Drawing.Size(40, 23)
Me.Label192.TabIndex = 269
Me.Label192.Text = "To"
'
'Label193
'
Me.Label193.Location = New System.Drawing.Point(464, 176)
Me.Label193.Name = "Label193"
Me.Label193.Size = New System.Drawing.Size(40, 23)
Me.Label193.TabIndex = 268
Me.Label193.Text = "From"
'
'cmb_ToolWearOffsetAxisIndex
'
Me.cmb_ToolWearOffsetAxisIndex.Location = New System.Drawing.Point(120, 136)
Me.cmb_ToolWearOffsetAxisIndex.Name = "cmb_ToolWearOffsetAxisIndex"
Me.cmb_ToolWearOffsetAxisIndex.Size = New System.Drawing.Size(184, 21)
Me.cmb_ToolWearOffsetAxisIndex.TabIndex = 267
'
'cmb_CuttingPosition
'
Me.cmb_CuttingPosition.Location = New System.Drawing.Point(408, 136)
Me.cmb_CuttingPosition.Name = "cmb_CuttingPosition"
Me.cmb_CuttingPosition.Size = New System.Drawing.Size(152, 21)
Me.cmb_CuttingPosition.TabIndex = 266
'
'txt_ToIndex
'
Me.txt_ToIndex.ForeColor = System.Drawing.Color.Red
Me.txt_ToIndex.Location = New System.Drawing.Point(528, 208)
Me.txt_ToIndex.Name = "txt_ToIndex"
Me.txt_ToIndex.Size = New System.Drawing.Size(48, 20)
Me.txt_ToIndex.TabIndex = 265
Me.txt_ToIndex.Text = "1"
'
'txt_FromIndex
'
Me.txt_FromIndex.ForeColor = System.Drawing.Color.Red
Me.txt_FromIndex.Location = New System.Drawing.Point(464, 208)
Me.txt_FromIndex.Name = "txt_FromIndex"
Me.txt_FromIndex.Size = New System.Drawing.Size(48, 20)
Me.txt_FromIndex.TabIndex = 264
Me.txt_FromIndex.Text = "1"
'
'Tab_Turret
'
Me.Tab_Turret.Controls.Add(Me.txtMaxToolPotPerTurret)
Me.Tab_Turret.Controls.Add(Me.Label175)
Me.Tab_Turret.Controls.Add(Me.cboTurretSides)
Me.Tab_Turret.Controls.Add(Me.GroupBox10)
Me.Tab_Turret.Controls.Add(Me.GroupBox9)
Me.Tab_Turret.Controls.Add(Me.cmdTurretDataUnit)
Me.Tab_Turret.Controls.Add(Me.cmdTurretSubSystem)
Me.Tab_Turret.Controls.Add(Me.cmb_Turret_DataUnit)
Me.Tab_Turret.Controls.Add(Me.cmb_Turret_subsys)
Me.Tab_Turret.Controls.Add(Me.turToolNo)
Me.Tab_Turret.Controls.Add(Me.Label93)
Me.Tab_Turret.Controls.Add(Me.turUpdate)
Me.Tab_Turret.Controls.Add(Me.Label55)
Me.Tab_Turret.Controls.Add(Me.turToolOffsetAxisCombo)
Me.Tab_Turret.Location = New System.Drawing.Point(4, 22)
Me.Tab_Turret.Name = "Tab_Turret"
Me.Tab_Turret.Size = New System.Drawing.Size(776, 446)
Me.Tab_Turret.TabIndex = 16
Me.Tab_Turret.Text = "Turret"
'
'txtMaxToolPotPerTurret
'
Me.txtMaxToolPotPerTurret.Location = New System.Drawing.Point(288, 104)
Me.txtMaxToolPotPerTurret.Name = "txtMaxToolPotPerTurret"
Me.txtMaxToolPotPerTurret.ReadOnly = true
Me.txtMaxToolPotPerTurret.Size = New System.Drawing.Size(80, 20)
Me.txtMaxToolPotPerTurret.TabIndex = 238
Me.txtMaxToolPotPerTurret.Text = ""
'
'Label175
'
Me.Label175.Location = New System.Drawing.Point(16, 104)
Me.Label175.Name = "Label175"
Me.Label175.Size = New System.Drawing.Size(96, 32)
Me.Label175.TabIndex = 237
Me.Label175.Text = "Max Tool Pot per turret:"
'
'cboTurretSides
'
Me.cboTurretSides.Location = New System.Drawing.Point(120, 104)
Me.cboTurretSides.Name = "cboTurretSides"
Me.cboTurretSides.Size = New System.Drawing.Size(160, 21)
Me.cboTurretSides.TabIndex = 236
'
'GroupBox10
'
Me.GroupBox10.Controls.Add(Me.turTurretOffsetAdd)
Me.GroupBox10.Controls.Add(Me.turTurretOffsetSet)
Me.GroupBox10.Controls.Add(Me.turTurretOffsetUpd)
Me.GroupBox10.Controls.Add(Me.turTurretOffset)
Me.GroupBox10.Controls.Add(Me.Label81)
Me.GroupBox10.Location = New System.Drawing.Point(16, 144)
Me.GroupBox10.Name = "GroupBox10"
Me.GroupBox10.Size = New System.Drawing.Size(504, 80)
Me.GroupBox10.TabIndex = 235
Me.GroupBox10.TabStop = false
Me.GroupBox10.Text = "Standard Turret Offset"
'
'turTurretOffsetAdd
'
Me.turTurretOffsetAdd.Location = New System.Drawing.Point(424, 40)
Me.turTurretOffsetAdd.Name = "turTurretOffsetAdd"
Me.turTurretOffsetAdd.Size = New System.Drawing.Size(56, 24)
Me.turTurretOffsetAdd.TabIndex = 13
Me.turTurretOffsetAdd.Text = "Add"
'
'turTurretOffsetSet
'
Me.turTurretOffsetSet.Location = New System.Drawing.Point(352, 40)
Me.turTurretOffsetSet.Name = "turTurretOffsetSet"
Me.turTurretOffsetSet.Size = New System.Drawing.Size(56, 24)
Me.turTurretOffsetSet.TabIndex = 12
Me.turTurretOffsetSet.Text = "Set"
'
'turTurretOffsetUpd
'
Me.turTurretOffsetUpd.ForeColor = System.Drawing.Color.Red
Me.turTurretOffsetUpd.Location = New System.Drawing.Point(272, 40)
Me.turTurretOffsetUpd.Name = "turTurretOffsetUpd"
Me.turTurretOffsetUpd.Size = New System.Drawing.Size(80, 20)
Me.turTurretOffsetUpd.TabIndex = 11
Me.turTurretOffsetUpd.Text = "0"
'
'turTurretOffset
'
Me.turTurretOffset.Location = New System.Drawing.Point(176, 40)
Me.turTurretOffset.Name = "turTurretOffset"
Me.turTurretOffset.ReadOnly = true
Me.turTurretOffset.Size = New System.Drawing.Size(80, 20)
Me.turTurretOffset.TabIndex = 10
Me.turTurretOffset.Text = "0"
'
'Label81
'
Me.Label81.Location = New System.Drawing.Point(16, 40)
Me.Label81.Name = "Label81"
Me.Label81.Size = New System.Drawing.Size(136, 24)
Me.Label81.TabIndex = 9
Me.Label81.Text = "Turret Offset :"
'
'GroupBox9
'
Me.GroupBox9.Controls.Add(Me.Label54)
Me.GroupBox9.Controls.Add(Me.turBAxisTurretOffsetAdd)
Me.GroupBox9.Controls.Add(Me.turBAxisTurretOffsetSet)
Me.GroupBox9.Controls.Add(Me.turBAxisTurretOffsetUpd)
Me.GroupBox9.Controls.Add(Me.turTurretMode)
Me.GroupBox9.Controls.Add(Me.turBAxisTurretOffset)
Me.GroupBox9.Controls.Add(Me.Label88)
Me.GroupBox9.Controls.Add(Me.turBAxisTurretCombo)
Me.GroupBox9.Controls.Add(Me.Label56)
Me.GroupBox9.Location = New System.Drawing.Point(16, 232)
Me.GroupBox9.Name = "GroupBox9"
Me.GroupBox9.Size = New System.Drawing.Size(504, 128)
Me.GroupBox9.TabIndex = 234
Me.GroupBox9.TabStop = false
Me.GroupBox9.Text = "B-Axis Turret Offset"
'
'Label54
'
Me.Label54.Location = New System.Drawing.Point(16, 96)
Me.Label54.Name = "Label54"
Me.Label54.Size = New System.Drawing.Size(136, 24)
Me.Label54.TabIndex = 0
Me.Label54.Text = "B Axis Turret Offset :"
'
'turBAxisTurretOffsetAdd
'
Me.turBAxisTurretOffsetAdd.Location = New System.Drawing.Point(432, 96)
Me.turBAxisTurretOffsetAdd.Name = "turBAxisTurretOffsetAdd"
Me.turBAxisTurretOffsetAdd.Size = New System.Drawing.Size(56, 24)
Me.turBAxisTurretOffsetAdd.TabIndex = 4
Me.turBAxisTurretOffsetAdd.Text = "Add"
'
'turBAxisTurretOffsetSet
'
Me.turBAxisTurretOffsetSet.Location = New System.Drawing.Point(360, 96)
Me.turBAxisTurretOffsetSet.Name = "turBAxisTurretOffsetSet"
Me.turBAxisTurretOffsetSet.Size = New System.Drawing.Size(56, 24)
Me.turBAxisTurretOffsetSet.TabIndex = 3
Me.turBAxisTurretOffsetSet.Text = "Set"
'
'turBAxisTurretOffsetUpd
'
Me.turBAxisTurretOffsetUpd.ForeColor = System.Drawing.Color.Red
Me.turBAxisTurretOffsetUpd.Location = New System.Drawing.Point(272, 96)
Me.turBAxisTurretOffsetUpd.Name = "turBAxisTurretOffsetUpd"
Me.turBAxisTurretOffsetUpd.Size = New System.Drawing.Size(80, 20)
Me.turBAxisTurretOffsetUpd.TabIndex = 2
Me.turBAxisTurretOffsetUpd.Text = "0"
'
'turTurretMode
'
Me.turTurretMode.Location = New System.Drawing.Point(176, 64)
Me.turTurretMode.Name = "turTurretMode"
Me.turTurretMode.ReadOnly = true
Me.turTurretMode.Size = New System.Drawing.Size(80, 20)
Me.turTurretMode.TabIndex = 15
Me.turTurretMode.Text = "0"
'
'turBAxisTurretOffset
'
Me.turBAxisTurretOffset.Location = New System.Drawing.Point(176, 96)
Me.turBAxisTurretOffset.Name = "turBAxisTurretOffset"
Me.turBAxisTurretOffset.ReadOnly = true
Me.turBAxisTurretOffset.Size = New System.Drawing.Size(80, 20)
Me.turBAxisTurretOffset.TabIndex = 1
Me.turBAxisTurretOffset.Text = "0"
'
'Label88
'
Me.Label88.Location = New System.Drawing.Point(16, 64)
Me.Label88.Name = "Label88"
Me.Label88.Size = New System.Drawing.Size(136, 24)
Me.Label88.TabIndex = 14
Me.Label88.Text = "Turret Mode :"
'
'turBAxisTurretCombo
'
Me.turBAxisTurretCombo.Location = New System.Drawing.Point(144, 24)
Me.turBAxisTurretCombo.Name = "turBAxisTurretCombo"
Me.turBAxisTurretCombo.Size = New System.Drawing.Size(144, 21)
Me.turBAxisTurretCombo.TabIndex = 6
'
'Label56
'
Me.Label56.Location = New System.Drawing.Point(8, 24)
Me.Label56.Name = "Label56"
Me.Label56.Size = New System.Drawing.Size(112, 16)
Me.Label56.TabIndex = 8
Me.Label56.Text = "B Axis Turret Offset :"
'
'cmdTurretDataUnit
'
Me.cmdTurretDataUnit.Location = New System.Drawing.Point(296, 16)
Me.cmdTurretDataUnit.Name = "cmdTurretDataUnit"
Me.cmdTurretDataUnit.Size = New System.Drawing.Size(96, 24)
Me.cmdTurretDataUnit.TabIndex = 233
Me.cmdTurretDataUnit.Text = "Data Unit"
'
'cmdTurretSubSystem
'
Me.cmdTurretSubSystem.Location = New System.Drawing.Point(16, 16)
Me.cmdTurretSubSystem.Name = "cmdTurretSubSystem"
Me.cmdTurretSubSystem.Size = New System.Drawing.Size(128, 24)
Me.cmdTurretSubSystem.TabIndex = 232
Me.cmdTurretSubSystem.Text = "Set"
'
'cmb_Turret_DataUnit
'
Me.cmb_Turret_DataUnit.Location = New System.Drawing.Point(400, 16)
Me.cmb_Turret_DataUnit.Name = "cmb_Turret_DataUnit"
Me.cmb_Turret_DataUnit.Size = New System.Drawing.Size(121, 21)
Me.cmb_Turret_DataUnit.TabIndex = 228
'
'cmb_Turret_subsys
'
Me.cmb_Turret_subsys.Location = New System.Drawing.Point(152, 16)
Me.cmb_Turret_subsys.Name = "cmb_Turret_subsys"
Me.cmb_Turret_subsys.Size = New System.Drawing.Size(121, 21)
Me.cmb_Turret_subsys.TabIndex = 227
'
'turToolNo
'
Me.turToolNo.Location = New System.Drawing.Point(400, 64)
Me.turToolNo.Name = "turToolNo"
Me.turToolNo.Size = New System.Drawing.Size(112, 20)
Me.turToolNo.TabIndex = 18
Me.turToolNo.Text = "1"
'
'Label93
'
Me.Label93.Location = New System.Drawing.Point(296, 64)
Me.Label93.Name = "Label93"
Me.Label93.Size = New System.Drawing.Size(80, 24)
Me.Label93.TabIndex = 17
Me.Label93.Text = "Tool Number :"
'
'turUpdate
'
Me.turUpdate.Location = New System.Drawing.Point(552, 16)
Me.turUpdate.Name = "turUpdate"
Me.turUpdate.Size = New System.Drawing.Size(160, 24)
Me.turUpdate.TabIndex = 16
Me.turUpdate.Text = "Update"
'
'Label55
'
Me.Label55.Location = New System.Drawing.Point(16, 64)
Me.Label55.Name = "Label55"
Me.Label55.Size = New System.Drawing.Size(96, 24)
Me.Label55.TabIndex = 7
Me.Label55.Text = "Tool Offset Axis :"
'
'turToolOffsetAxisCombo
'
Me.turToolOffsetAxisCombo.Location = New System.Drawing.Point(120, 64)
Me.turToolOffsetAxisCombo.Name = "turToolOffsetAxisCombo"
Me.turToolOffsetAxisCombo.Size = New System.Drawing.Size(160, 21)
Me.turToolOffsetAxisCombo.TabIndex = 5
'
'tab_variables
'
Me.tab_variables.Controls.Add(Me.GroupBox13)
Me.tab_variables.Controls.Add(Me.Label246)
Me.tab_variables.Controls.Add(Me.varGetAllResults)
Me.tab_variables.Location = New System.Drawing.Point(4, 22)
Me.tab_variables.Name = "tab_variables"
Me.tab_variables.Size = New System.Drawing.Size(776, 446)
Me.tab_variables.TabIndex = 10
Me.tab_variables.Text = "Variables"
'
'GroupBox13
'
Me.GroupBox13.Controls.Add(Me.varSetValue)
Me.GroupBox13.Controls.Add(Me.varEnd)
Me.GroupBox13.Controls.Add(Me.varBegin)
Me.GroupBox13.Controls.Add(Me.varValueUpdate)
Me.GroupBox13.Controls.Add(Me.Label91)
Me.GroupBox13.Controls.Add(Me.varCommonVarNumber)
Me.GroupBox13.Controls.Add(Me.Label92)
Me.GroupBox13.Controls.Add(Me.Label176)
Me.GroupBox13.Controls.Add(Me.cmb_Variable_SubSys)
Me.GroupBox13.Controls.Add(Me.varGetValue)
Me.GroupBox13.Controls.Add(Me.Label90)
Me.GroupBox13.Controls.Add(Me.varValue)
Me.GroupBox13.Controls.Add(Me.varUpdateButton)
Me.GroupBox13.Controls.Add(Me.varGetAllButton)
Me.GroupBox13.Controls.Add(Me.Label89)
Me.GroupBox13.Controls.Add(Me.varNumberOfVars)
Me.GroupBox13.Controls.Add(Me.varAddValue)
Me.GroupBox13.Location = New System.Drawing.Point(8, 8)
Me.GroupBox13.Name = "GroupBox13"
Me.GroupBox13.Size = New System.Drawing.Size(544, 168)
Me.GroupBox13.TabIndex = 235
Me.GroupBox13.TabStop = false
Me.GroupBox13.Text = "Common Variables"
'
'varSetValue
'
Me.varSetValue.Location = New System.Drawing.Point(392, 96)
Me.varSetValue.Name = "varSetValue"
Me.varSetValue.Size = New System.Drawing.Size(40, 24)
Me.varSetValue.TabIndex = 177
Me.varSetValue.Text = "Set"
'
'varEnd
'
Me.varEnd.Location = New System.Drawing.Point(320, 136)
Me.varEnd.Name = "varEnd"
Me.varEnd.Size = New System.Drawing.Size(64, 20)
Me.varEnd.TabIndex = 76
Me.varEnd.Text = "10"
'
'varBegin
'
Me.varBegin.Location = New System.Drawing.Point(176, 136)
Me.varBegin.Name = "varBegin"
Me.varBegin.Size = New System.Drawing.Size(64, 20)
Me.varBegin.TabIndex = 73
Me.varBegin.Text = "1"
'
'varValueUpdate
'
Me.varValueUpdate.ForeColor = System.Drawing.Color.Red
Me.varValueUpdate.Location = New System.Drawing.Point(256, 104)
Me.varValueUpdate.Name = "varValueUpdate"
Me.varValueUpdate.Size = New System.Drawing.Size(64, 20)
Me.varValueUpdate.TabIndex = 71
Me.varValueUpdate.Text = "0"
'
'Label91
'
Me.Label91.Location = New System.Drawing.Point(16, 64)
Me.Label91.Name = "Label91"
Me.Label91.Size = New System.Drawing.Size(152, 16)
Me.Label91.TabIndex = 72
Me.Label91.Text = "Common Variable Number"
'
'varCommonVarNumber
'
Me.varCommonVarNumber.Location = New System.Drawing.Point(176, 72)
Me.varCommonVarNumber.Name = "varCommonVarNumber"
Me.varCommonVarNumber.Size = New System.Drawing.Size(64, 20)
Me.varCommonVarNumber.TabIndex = 69
Me.varCommonVarNumber.Text = "1"
'
'Label92
'
Me.Label92.Location = New System.Drawing.Point(256, 136)
Me.Label92.Name = "Label92"
Me.Label92.Size = New System.Drawing.Size(48, 16)
Me.Label92.TabIndex = 70
Me.Label92.Text = "Between"
'
'Label176
'
Me.Label176.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label176.Location = New System.Drawing.Point(8, 24)
Me.Label176.Name = "Label176"
Me.Label176.Size = New System.Drawing.Size(128, 16)
Me.Label176.TabIndex = 232
Me.Label176.Text = "Current Sub System :"
'
'cmb_Variable_SubSys
'
Me.cmb_Variable_SubSys.Location = New System.Drawing.Point(160, 24)
Me.cmb_Variable_SubSys.Name = "cmb_Variable_SubSys"
Me.cmb_Variable_SubSys.Size = New System.Drawing.Size(192, 21)
Me.cmb_Variable_SubSys.TabIndex = 231
'
'varGetValue
'
Me.varGetValue.Location = New System.Drawing.Point(336, 96)
Me.varGetValue.Name = "varGetValue"
Me.varGetValue.Size = New System.Drawing.Size(48, 24)
Me.varGetValue.TabIndex = 187
Me.varGetValue.Text = "Get"
'
'Label90
'
Me.Label90.Location = New System.Drawing.Point(16, 96)
Me.Label90.Name = "Label90"
Me.Label90.Size = New System.Drawing.Size(152, 16)
Me.Label90.TabIndex = 185
Me.Label90.Text = "Common Variable Value"
'
'varValue
'
Me.varValue.Location = New System.Drawing.Point(176, 104)
Me.varValue.Name = "varValue"
Me.varValue.ReadOnly = true
Me.varValue.Size = New System.Drawing.Size(64, 20)
Me.varValue.TabIndex = 184
Me.varValue.Text = "1"
'
'varUpdateButton
'
Me.varUpdateButton.Location = New System.Drawing.Point(416, 24)
Me.varUpdateButton.Name = "varUpdateButton"
Me.varUpdateButton.Size = New System.Drawing.Size(120, 24)
Me.varUpdateButton.TabIndex = 183
Me.varUpdateButton.Text = "Update"
'
'varGetAllButton
'
Me.varGetAllButton.Location = New System.Drawing.Point(400, 136)
Me.varGetAllButton.Name = "varGetAllButton"
Me.varGetAllButton.Size = New System.Drawing.Size(72, 24)
Me.varGetAllButton.TabIndex = 182
Me.varGetAllButton.Text = "Get All -->"
'
'Label89
'
Me.Label89.Location = New System.Drawing.Point(264, 64)
Me.Label89.Name = "Label89"
Me.Label89.Size = New System.Drawing.Size(200, 16)
Me.Label89.TabIndex = 181
Me.Label89.Text = "Number of Common Variables(Count)"
'
'varNumberOfVars
'
Me.varNumberOfVars.Location = New System.Drawing.Point(472, 72)
Me.varNumberOfVars.Name = "varNumberOfVars"
Me.varNumberOfVars.ReadOnly = true
Me.varNumberOfVars.Size = New System.Drawing.Size(56, 20)
Me.varNumberOfVars.TabIndex = 180
Me.varNumberOfVars.Text = "0"
'
'varAddValue
'
Me.varAddValue.Location = New System.Drawing.Point(440, 96)
Me.varAddValue.Name = "varAddValue"
Me.varAddValue.Size = New System.Drawing.Size(40, 24)
Me.varAddValue.TabIndex = 178
Me.varAddValue.Text = "Add"
'
'Label246
'
Me.Label246.Location = New System.Drawing.Point(568, 8)
Me.Label246.Name = "Label246"
Me.Label246.Size = New System.Drawing.Size(192, 24)
Me.Label246.TabIndex = 233
Me.Label246.Text = "Common variable Values:"
'
'varGetAllResults
'
Me.varGetAllResults.Location = New System.Drawing.Point(560, 40)
Me.varGetAllResults.Multiline = true
Me.varGetAllResults.Name = "varGetAllResults"
Me.varGetAllResults.Size = New System.Drawing.Size(200, 392)
Me.varGetAllResults.TabIndex = 179
Me.varGetAllResults.Text = ""
'
'tab_TailStock
'
Me.tab_TailStock.Controls.Add(Me.cmdTailStockSet)
Me.tab_TailStock.Controls.Add(Me.txtTailStockSpindlePositionSetting)
Me.tab_TailStock.Controls.Add(Me.txtTailStockSpindlePosition)
Me.tab_TailStock.Controls.Add(Me.cmb_Tail_SubSys)
Me.tab_TailStock.Controls.Add(Me.tailstockUpdate)
Me.tab_TailStock.Controls.Add(Me.TailStockLengthUpd)
Me.tab_TailStock.Controls.Add(Me.Label122)
Me.tab_TailStock.Controls.Add(Me.TailStockLength)
Me.tab_TailStock.Controls.Add(Me.TailStockLengthAdd)
Me.tab_TailStock.Controls.Add(Me.TailStockDiameterAdd)
Me.tab_TailStock.Controls.Add(Me.TailStockLengthSet)
Me.tab_TailStock.Controls.Add(Me.TailStockDiameterUpd)
Me.tab_TailStock.Controls.Add(Me.TailStockDiameterSet)
Me.tab_TailStock.Controls.Add(Me.Label121)
Me.tab_TailStock.Controls.Add(Me.TailStockLengthCombo)
Me.tab_TailStock.Controls.Add(Me.Label114)
Me.tab_TailStock.Controls.Add(Me.TailStockDiameter)
Me.tab_TailStock.Controls.Add(Me.TailStockDiameterCombo)
Me.tab_TailStock.Controls.Add(Me.Label97)
Me.tab_TailStock.Controls.Add(Me.Label169)
Me.tab_TailStock.Controls.Add(Me.Label170)
Me.tab_TailStock.Controls.Add(Me.cmb_Tail_Dataunit)
Me.tab_TailStock.Controls.Add(Me.cmd_tailStock_SetAxisPos)
Me.tab_TailStock.Controls.Add(Me.Label171)
Me.tab_TailStock.Controls.Add(Me.cmd_tailStock_AddAxisPos)
Me.tab_TailStock.Controls.Add(Me.cmd_tailStock_CalAxisPos)
Me.tab_TailStock.Location = New System.Drawing.Point(4, 22)
Me.tab_TailStock.Name = "tab_TailStock"
Me.tab_TailStock.Size = New System.Drawing.Size(776, 446)
Me.tab_TailStock.TabIndex = 17
Me.tab_TailStock.Text = "TailStock"
'
'cmdTailStockSet
'
Me.cmdTailStockSet.Location = New System.Drawing.Point(16, 24)
Me.cmdTailStockSet.Name = "cmdTailStockSet"
Me.cmdTailStockSet.Size = New System.Drawing.Size(120, 24)
Me.cmdTailStockSet.TabIndex = 19
Me.cmdTailStockSet.Text = "SET"
'
'txtTailStockSpindlePositionSetting
'
Me.txtTailStockSpindlePositionSetting.ForeColor = System.Drawing.Color.Red
Me.txtTailStockSpindlePositionSetting.Location = New System.Drawing.Point(264, 280)
Me.txtTailStockSpindlePositionSetting.Name = "txtTailStockSpindlePositionSetting"
Me.txtTailStockSpindlePositionSetting.Size = New System.Drawing.Size(80, 20)
Me.txtTailStockSpindlePositionSetting.TabIndex = 18
Me.txtTailStockSpindlePositionSetting.Text = "0.0"
'
'txtTailStockSpindlePosition
'
Me.txtTailStockSpindlePosition.Location = New System.Drawing.Point(176, 280)
Me.txtTailStockSpindlePosition.Name = "txtTailStockSpindlePosition"
Me.txtTailStockSpindlePosition.ReadOnly = true
Me.txtTailStockSpindlePosition.Size = New System.Drawing.Size(80, 20)
Me.txtTailStockSpindlePosition.TabIndex = 17
Me.txtTailStockSpindlePosition.Text = "0.0"
'
'cmb_Tail_SubSys
'
Me.cmb_Tail_SubSys.Location = New System.Drawing.Point(144, 24)
Me.cmb_Tail_SubSys.Name = "cmb_Tail_SubSys"
Me.cmb_Tail_SubSys.Size = New System.Drawing.Size(232, 21)
Me.cmb_Tail_SubSys.TabIndex = 16
'
'tailstockUpdate
'
Me.tailstockUpdate.Location = New System.Drawing.Point(328, 72)
Me.tailstockUpdate.Name = "tailstockUpdate"
Me.tailstockUpdate.Size = New System.Drawing.Size(104, 32)
Me.tailstockUpdate.TabIndex = 14
Me.tailstockUpdate.Text = "Update"
'
'TailStockLengthUpd
'
Me.TailStockLengthUpd.ForeColor = System.Drawing.Color.Red
Me.TailStockLengthUpd.Location = New System.Drawing.Point(264, 240)
Me.TailStockLengthUpd.Name = "TailStockLengthUpd"
Me.TailStockLengthUpd.Size = New System.Drawing.Size(80, 20)
Me.TailStockLengthUpd.TabIndex = 13
Me.TailStockLengthUpd.Text = "0.0"
'
'Label122
'
Me.Label122.Location = New System.Drawing.Point(16, 240)
Me.Label122.Name = "Label122"
Me.Label122.Size = New System.Drawing.Size(104, 24)
Me.Label122.TabIndex = 12
Me.Label122.Text = "TailStock Length :"
'
'TailStockLength
'
Me.TailStockLength.Location = New System.Drawing.Point(176, 240)
Me.TailStockLength.Name = "TailStockLength"
Me.TailStockLength.ReadOnly = true
Me.TailStockLength.Size = New System.Drawing.Size(80, 20)
Me.TailStockLength.TabIndex = 11
Me.TailStockLength.Text = "0"
'
'TailStockLengthAdd
'
Me.TailStockLengthAdd.Location = New System.Drawing.Point(448, 240)
Me.TailStockLengthAdd.Name = "TailStockLengthAdd"
Me.TailStockLengthAdd.Size = New System.Drawing.Size(80, 24)
Me.TailStockLengthAdd.TabIndex = 10
Me.TailStockLengthAdd.Text = "Add"
'
'TailStockDiameterAdd
'
Me.TailStockDiameterAdd.Location = New System.Drawing.Point(448, 192)
Me.TailStockDiameterAdd.Name = "TailStockDiameterAdd"
Me.TailStockDiameterAdd.Size = New System.Drawing.Size(80, 24)
Me.TailStockDiameterAdd.TabIndex = 9
Me.TailStockDiameterAdd.Text = "Add"
'
'TailStockLengthSet
'
Me.TailStockLengthSet.Location = New System.Drawing.Point(352, 240)
Me.TailStockLengthSet.Name = "TailStockLengthSet"
Me.TailStockLengthSet.Size = New System.Drawing.Size(80, 24)
Me.TailStockLengthSet.TabIndex = 8
Me.TailStockLengthSet.Text = "Set"
'
'TailStockDiameterUpd
'
Me.TailStockDiameterUpd.ForeColor = System.Drawing.Color.Red
Me.TailStockDiameterUpd.Location = New System.Drawing.Point(264, 192)
Me.TailStockDiameterUpd.Name = "TailStockDiameterUpd"
Me.TailStockDiameterUpd.Size = New System.Drawing.Size(80, 20)
Me.TailStockDiameterUpd.TabIndex = 7
Me.TailStockDiameterUpd.Text = "0.0"
'
'TailStockDiameterSet
'
Me.TailStockDiameterSet.Location = New System.Drawing.Point(352, 192)
Me.TailStockDiameterSet.Name = "TailStockDiameterSet"
Me.TailStockDiameterSet.Size = New System.Drawing.Size(80, 24)
Me.TailStockDiameterSet.TabIndex = 6
Me.TailStockDiameterSet.Text = "Set"
'
'Label121
'
Me.Label121.Location = New System.Drawing.Point(16, 192)
Me.Label121.Name = "Label121"
Me.Label121.Size = New System.Drawing.Size(112, 24)
Me.Label121.TabIndex = 5
Me.Label121.Text = "TailStock Diameter :"
'
'TailStockLengthCombo
'
Me.TailStockLengthCombo.Location = New System.Drawing.Point(544, 128)
Me.TailStockLengthCombo.Name = "TailStockLengthCombo"
Me.TailStockLengthCombo.Size = New System.Drawing.Size(192, 21)
Me.TailStockLengthCombo.TabIndex = 4
'
'Label114
'
Me.Label114.Location = New System.Drawing.Point(416, 128)
Me.Label114.Name = "Label114"
Me.Label114.Size = New System.Drawing.Size(136, 24)
Me.Label114.TabIndex = 3
Me.Label114.Text = "TailStock Length List :"
'
'TailStockDiameter
'
Me.TailStockDiameter.Location = New System.Drawing.Point(176, 192)
Me.TailStockDiameter.Name = "TailStockDiameter"
Me.TailStockDiameter.ReadOnly = true
Me.TailStockDiameter.Size = New System.Drawing.Size(80, 20)
Me.TailStockDiameter.TabIndex = 2
Me.TailStockDiameter.Text = "0"
'
'TailStockDiameterCombo
'
Me.TailStockDiameterCombo.Location = New System.Drawing.Point(160, 128)
Me.TailStockDiameterCombo.Name = "TailStockDiameterCombo"
Me.TailStockDiameterCombo.Size = New System.Drawing.Size(232, 21)
Me.TailStockDiameterCombo.TabIndex = 1
'
'Label97
'
Me.Label97.Location = New System.Drawing.Point(16, 128)
Me.Label97.Name = "Label97"
Me.Label97.Size = New System.Drawing.Size(136, 24)
Me.Label97.TabIndex = 0
Me.Label97.Text = "TailStock Diameter List :"
'
'Label169
'
Me.Label169.Location = New System.Drawing.Point(400, 24)
Me.Label169.Name = "Label169"
Me.Label169.TabIndex = 15
Me.Label169.Text = "Data unit :"
'
'Label170
'
Me.Label170.Location = New System.Drawing.Point(400, 24)
Me.Label170.Name = "Label170"
Me.Label170.TabIndex = 15
Me.Label170.Text = "Label168"
'
'cmb_Tail_Dataunit
'
Me.cmb_Tail_Dataunit.Location = New System.Drawing.Point(512, 24)
Me.cmb_Tail_Dataunit.Name = "cmb_Tail_Dataunit"
Me.cmb_Tail_Dataunit.Size = New System.Drawing.Size(224, 21)
Me.cmb_Tail_Dataunit.TabIndex = 16
'
'cmd_tailStock_SetAxisPos
'
Me.cmd_tailStock_SetAxisPos.Location = New System.Drawing.Point(352, 280)
Me.cmd_tailStock_SetAxisPos.Name = "cmd_tailStock_SetAxisPos"
Me.cmd_tailStock_SetAxisPos.Size = New System.Drawing.Size(80, 24)
Me.cmd_tailStock_SetAxisPos.TabIndex = 8
Me.cmd_tailStock_SetAxisPos.Text = "Set"
'
'Label171
'
Me.Label171.Location = New System.Drawing.Point(16, 280)
Me.Label171.Name = "Label171"
Me.Label171.Size = New System.Drawing.Size(144, 24)
Me.Label171.TabIndex = 12
Me.Label171.Text = "Tailstock Spindle Position:"
'
'cmd_tailStock_AddAxisPos
'
Me.cmd_tailStock_AddAxisPos.Location = New System.Drawing.Point(448, 280)
Me.cmd_tailStock_AddAxisPos.Name = "cmd_tailStock_AddAxisPos"
Me.cmd_tailStock_AddAxisPos.Size = New System.Drawing.Size(80, 24)
Me.cmd_tailStock_AddAxisPos.TabIndex = 10
Me.cmd_tailStock_AddAxisPos.Text = "Add"
'
'cmd_tailStock_CalAxisPos
'
Me.cmd_tailStock_CalAxisPos.Location = New System.Drawing.Point(544, 280)
Me.cmd_tailStock_CalAxisPos.Name = "cmd_tailStock_CalAxisPos"
Me.cmd_tailStock_CalAxisPos.Size = New System.Drawing.Size(80, 24)
Me.cmd_tailStock_CalAxisPos.TabIndex = 10
Me.cmd_tailStock_CalAxisPos.Text = "Calculate"
'
'tab_spindle
'
Me.tab_spindle.Controls.Add(Me.MaxSpindleRateOverride)
Me.tab_spindle.Controls.Add(Me.Label248)
Me.tab_spindle.Controls.Add(Me.Label167)
Me.tab_spindle.Controls.Add(Me.cmb_Spindle_SubSys)
Me.tab_spindle.Controls.Add(Me.spinSpindleSurfaceSpeed)
Me.tab_spindle.Controls.Add(Me.Label45)
Me.tab_spindle.Controls.Add(Me.Label2)
Me.tab_spindle.Controls.Add(Me.spinComboAxis)
Me.tab_spindle.Controls.Add(Me.spinState)
Me.tab_spindle.Controls.Add(Me.Label73)
Me.tab_spindle.Controls.Add(Me.spinUpdate)
Me.tab_spindle.Controls.Add(Me.spinRateOverride)
Me.tab_spindle.Controls.Add(Me.Label67)
Me.tab_spindle.Controls.Add(Me.spinLoad)
Me.tab_spindle.Controls.Add(Me.Label68)
Me.tab_spindle.Controls.Add(Me.spinOilMist)
Me.tab_spindle.Controls.Add(Me.Label69)
Me.tab_spindle.Controls.Add(Me.spinSpindleMode)
Me.tab_spindle.Controls.Add(Me.Label70)
Me.tab_spindle.Controls.Add(Me.spinCommandRate)
Me.tab_spindle.Controls.Add(Me.Label71)
Me.tab_spindle.Controls.Add(Me.spinActualRate)
Me.tab_spindle.Controls.Add(Me.Label72)
Me.tab_spindle.Location = New System.Drawing.Point(4, 22)
Me.tab_spindle.Name = "tab_spindle"
Me.tab_spindle.Size = New System.Drawing.Size(776, 446)
Me.tab_spindle.TabIndex = 8
Me.tab_spindle.Text = "Spindle"
'
'MaxSpindleRateOverride
'
Me.MaxSpindleRateOverride.BackColor = System.Drawing.SystemColors.Control
Me.MaxSpindleRateOverride.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.MaxSpindleRateOverride.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.MaxSpindleRateOverride.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.MaxSpindleRateOverride.Location = New System.Drawing.Point(405, 368)
Me.MaxSpindleRateOverride.Name = "MaxSpindleRateOverride"
Me.MaxSpindleRateOverride.Size = New System.Drawing.Size(160, 24)
Me.MaxSpindleRateOverride.TabIndex = 93
Me.MaxSpindleRateOverride.Text = "0"
'
'Label248
'
Me.Label248.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label248.Location = New System.Drawing.Point(168, 376)
Me.Label248.Name = "Label248"
Me.Label248.Size = New System.Drawing.Size(144, 16)
Me.Label248.TabIndex = 92
Me.Label248.Text = "Max SpindleRateOverride"
'
'Label167
'
Me.Label167.Location = New System.Drawing.Point(272, 24)
Me.Label167.Name = "Label167"
Me.Label167.TabIndex = 91
Me.Label167.Text = "Sub System :"
'
'cmb_Spindle_SubSys
'
Me.cmb_Spindle_SubSys.Location = New System.Drawing.Point(392, 24)
Me.cmb_Spindle_SubSys.Name = "cmb_Spindle_SubSys"
Me.cmb_Spindle_SubSys.Size = New System.Drawing.Size(121, 21)
Me.cmb_Spindle_SubSys.TabIndex = 90
'
'spinSpindleSurfaceSpeed
'
Me.spinSpindleSurfaceSpeed.BackColor = System.Drawing.SystemColors.Control
Me.spinSpindleSurfaceSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.spinSpindleSurfaceSpeed.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.spinSpindleSurfaceSpeed.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.spinSpindleSurfaceSpeed.Location = New System.Drawing.Point(408, 336)
Me.spinSpindleSurfaceSpeed.Name = "spinSpindleSurfaceSpeed"
Me.spinSpindleSurfaceSpeed.Size = New System.Drawing.Size(160, 24)
Me.spinSpindleSurfaceSpeed.TabIndex = 89
Me.spinSpindleSurfaceSpeed.Text = "0"
'
'Label45
'
Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label45.Location = New System.Drawing.Point(168, 340)
Me.Label45.Name = "Label45"
Me.Label45.Size = New System.Drawing.Size(144, 16)
Me.Label45.TabIndex = 88
Me.Label45.Text = "Spindle Surface Speed :"
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(576, 248)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(136, 16)
Me.Label2.TabIndex = 87
Me.Label2.Text = "Spindle Axis :"
'
'spinComboAxis
'
Me.spinComboAxis.Location = New System.Drawing.Point(576, 272)
Me.spinComboAxis.Name = "spinComboAxis"
Me.spinComboAxis.Size = New System.Drawing.Size(152, 21)
Me.spinComboAxis.TabIndex = 86
'
'spinState
'
Me.spinState.BackColor = System.Drawing.SystemColors.Control
Me.spinState.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.spinState.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.spinState.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.spinState.Location = New System.Drawing.Point(408, 304)
Me.spinState.Name = "spinState"
Me.spinState.Size = New System.Drawing.Size(160, 24)
Me.spinState.TabIndex = 63
Me.spinState.Text = "0"
'
'Label73
'
Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label73.Location = New System.Drawing.Point(168, 308)
Me.Label73.Name = "Label73"
Me.Label73.Size = New System.Drawing.Size(144, 16)
Me.Label73.TabIndex = 62
Me.Label73.Text = "Spindle State :"
'
'spinUpdate
'
Me.spinUpdate.Location = New System.Drawing.Point(320, 56)
Me.spinUpdate.Name = "spinUpdate"
Me.spinUpdate.Size = New System.Drawing.Size(104, 24)
Me.spinUpdate.TabIndex = 61
Me.spinUpdate.Text = "Update"
'
'spinRateOverride
'
Me.spinRateOverride.BackColor = System.Drawing.SystemColors.Control
Me.spinRateOverride.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.spinRateOverride.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.spinRateOverride.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.spinRateOverride.Location = New System.Drawing.Point(408, 272)
Me.spinRateOverride.Name = "spinRateOverride"
Me.spinRateOverride.Size = New System.Drawing.Size(160, 24)
Me.spinRateOverride.TabIndex = 60
Me.spinRateOverride.Text = "0"
'
'Label67
'
Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label67.Location = New System.Drawing.Point(168, 276)
Me.Label67.Name = "Label67"
Me.Label67.Size = New System.Drawing.Size(144, 16)
Me.Label67.TabIndex = 59
Me.Label67.Text = "Spindle Rate Override :"
'
'spinLoad
'
Me.spinLoad.BackColor = System.Drawing.SystemColors.Control
Me.spinLoad.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.spinLoad.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.spinLoad.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.spinLoad.Location = New System.Drawing.Point(408, 160)
Me.spinLoad.Name = "spinLoad"
Me.spinLoad.Size = New System.Drawing.Size(160, 24)
Me.spinLoad.TabIndex = 58
Me.spinLoad.Text = "0"
'
'Label68
'
Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label68.Location = New System.Drawing.Point(168, 164)
Me.Label68.Name = "Label68"
Me.Label68.Size = New System.Drawing.Size(96, 16)
Me.Label68.TabIndex = 57
Me.Label68.Text = "Spindle Load:"
'
'spinOilMist
'
Me.spinOilMist.BackColor = System.Drawing.SystemColors.Control
Me.spinOilMist.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.spinOilMist.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.spinOilMist.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.spinOilMist.Location = New System.Drawing.Point(408, 192)
Me.spinOilMist.Name = "spinOilMist"
Me.spinOilMist.Size = New System.Drawing.Size(160, 24)
Me.spinOilMist.TabIndex = 56
Me.spinOilMist.Text = "0"
'
'Label69
'
Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label69.Location = New System.Drawing.Point(168, 196)
Me.Label69.Name = "Label69"
Me.Label69.Size = New System.Drawing.Size(208, 16)
Me.Label69.TabIndex = 55
Me.Label69.Text = "Oil Mist Condition :"
'
'spinSpindleMode
'
Me.spinSpindleMode.BackColor = System.Drawing.SystemColors.Control
Me.spinSpindleMode.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.spinSpindleMode.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.spinSpindleMode.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.spinSpindleMode.Location = New System.Drawing.Point(408, 232)
Me.spinSpindleMode.Name = "spinSpindleMode"
Me.spinSpindleMode.Size = New System.Drawing.Size(160, 24)
Me.spinSpindleMode.TabIndex = 54
Me.spinSpindleMode.Text = "0"
'
'Label70
'
Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label70.Location = New System.Drawing.Point(168, 236)
Me.Label70.Name = "Label70"
Me.Label70.Size = New System.Drawing.Size(208, 16)
Me.Label70.TabIndex = 53
Me.Label70.Text = "Spindle Mode :"
'
'spinCommandRate
'
Me.spinCommandRate.BackColor = System.Drawing.SystemColors.Control
Me.spinCommandRate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.spinCommandRate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.spinCommandRate.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.spinCommandRate.Location = New System.Drawing.Point(408, 128)
Me.spinCommandRate.Name = "spinCommandRate"
Me.spinCommandRate.Size = New System.Drawing.Size(160, 24)
Me.spinCommandRate.TabIndex = 52
Me.spinCommandRate.Text = "0"
'
'Label71
'
Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label71.Location = New System.Drawing.Point(168, 132)
Me.Label71.Name = "Label71"
Me.Label71.Size = New System.Drawing.Size(208, 16)
Me.Label71.TabIndex = 51
Me.Label71.Text = "Command Spindle Rate :"
'
'spinActualRate
'
Me.spinActualRate.BackColor = System.Drawing.SystemColors.Control
Me.spinActualRate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.spinActualRate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.spinActualRate.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.spinActualRate.Location = New System.Drawing.Point(408, 96)
Me.spinActualRate.Name = "spinActualRate"
Me.spinActualRate.Size = New System.Drawing.Size(160, 24)
Me.spinActualRate.TabIndex = 50
Me.spinActualRate.Text = "0"
'
'Label72
'
Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label72.Location = New System.Drawing.Point(168, 100)
Me.Label72.Name = "Label72"
Me.Label72.Size = New System.Drawing.Size(200, 16)
Me.Label72.TabIndex = 49
Me.Label72.Text = "Actual Spindle Rate :"
'
'MSpindle
'
Me.MSpindle.Controls.Add(Me.Label233)
Me.MSpindle.Controls.Add(Me.mspinSetSubSystem)
Me.MSpindle.Controls.Add(Me.mspinUpdate)
Me.MSpindle.Controls.Add(Me.mspinSubSystemCombo)
Me.MSpindle.Controls.Add(Me.Label44)
Me.MSpindle.Controls.Add(Me.mspinSpindleRateOverrideCombo)
Me.MSpindle.Controls.Add(Me.mspinSpindleRateOverride)
Me.MSpindle.Controls.Add(Me.Label43)
Me.MSpindle.Controls.Add(Me.mspinMSpindleState)
Me.MSpindle.Controls.Add(Me.Label42)
Me.MSpindle.Controls.Add(Me.mspinMSpindleLoad)
Me.MSpindle.Controls.Add(Me.Label41)
Me.MSpindle.Controls.Add(Me.mspinCurrentToolInH1Turret)
Me.MSpindle.Controls.Add(Me.Label40)
Me.MSpindle.Controls.Add(Me.mspinCommandMSpindleRate)
Me.MSpindle.Controls.Add(Me.Label39)
Me.MSpindle.Controls.Add(Me.mspinActualMSpindleRate)
Me.MSpindle.Controls.Add(Me.Label38)
Me.MSpindle.Location = New System.Drawing.Point(4, 22)
Me.MSpindle.Name = "MSpindle"
Me.MSpindle.Size = New System.Drawing.Size(776, 446)
Me.MSpindle.TabIndex = 15
Me.MSpindle.Text = "MSpindle"
'
'Label233
'
Me.Label233.Location = New System.Drawing.Point(576, 112)
Me.Label233.Name = "Label233"
Me.Label233.Size = New System.Drawing.Size(160, 16)
Me.Label233.TabIndex = 17
Me.Label233.Text = "M Spindle Selection"
'
'mspinSetSubSystem
'
Me.mspinSetSubSystem.Location = New System.Drawing.Point(224, 8)
Me.mspinSetSubSystem.Name = "mspinSetSubSystem"
Me.mspinSetSubSystem.Size = New System.Drawing.Size(56, 24)
Me.mspinSetSubSystem.TabIndex = 16
Me.mspinSetSubSystem.Text = "Set"
'
'mspinUpdate
'
Me.mspinUpdate.Location = New System.Drawing.Point(280, 48)
Me.mspinUpdate.Name = "mspinUpdate"
Me.mspinUpdate.Size = New System.Drawing.Size(232, 32)
Me.mspinUpdate.TabIndex = 15
Me.mspinUpdate.Text = "Update"
'
'mspinSubSystemCombo
'
Me.mspinSubSystemCombo.Location = New System.Drawing.Point(96, 8)
Me.mspinSubSystemCombo.Name = "mspinSubSystemCombo"
Me.mspinSubSystemCombo.Size = New System.Drawing.Size(120, 21)
Me.mspinSubSystemCombo.TabIndex = 14
'
'Label44
'
Me.Label44.Location = New System.Drawing.Point(16, 8)
Me.Label44.Name = "Label44"
Me.Label44.Size = New System.Drawing.Size(72, 16)
Me.Label44.TabIndex = 13
Me.Label44.Text = "Sub System"
'
'mspinSpindleRateOverrideCombo
'
Me.mspinSpindleRateOverrideCombo.Location = New System.Drawing.Point(576, 136)
Me.mspinSpindleRateOverrideCombo.Name = "mspinSpindleRateOverrideCombo"
Me.mspinSpindleRateOverrideCombo.Size = New System.Drawing.Size(160, 21)
Me.mspinSpindleRateOverrideCombo.TabIndex = 12
'
'mspinSpindleRateOverride
'
Me.mspinSpindleRateOverride.Location = New System.Drawing.Point(576, 168)
Me.mspinSpindleRateOverride.Name = "mspinSpindleRateOverride"
Me.mspinSpindleRateOverride.Size = New System.Drawing.Size(120, 20)
Me.mspinSpindleRateOverride.TabIndex = 11
Me.mspinSpindleRateOverride.Text = ""
'
'Label43
'
Me.Label43.Location = New System.Drawing.Point(440, 168)
Me.Label43.Name = "Label43"
Me.Label43.Size = New System.Drawing.Size(120, 16)
Me.Label43.TabIndex = 10
Me.Label43.Text = "Spindle Rate Override"
'
'mspinMSpindleState
'
Me.mspinMSpindleState.Location = New System.Drawing.Point(224, 264)
Me.mspinMSpindleState.Name = "mspinMSpindleState"
Me.mspinMSpindleState.Size = New System.Drawing.Size(120, 20)
Me.mspinMSpindleState.TabIndex = 9
Me.mspinMSpindleState.Text = ""
'
'Label42
'
Me.Label42.Location = New System.Drawing.Point(24, 264)
Me.Label42.Name = "Label42"
Me.Label42.Size = New System.Drawing.Size(176, 16)
Me.Label42.TabIndex = 8
Me.Label42.Text = "M Spindle State"
'
'mspinMSpindleLoad
'
Me.mspinMSpindleLoad.Location = New System.Drawing.Point(224, 240)
Me.mspinMSpindleLoad.Name = "mspinMSpindleLoad"
Me.mspinMSpindleLoad.Size = New System.Drawing.Size(120, 20)
Me.mspinMSpindleLoad.TabIndex = 7
Me.mspinMSpindleLoad.Text = ""
'
'Label41
'
Me.Label41.Location = New System.Drawing.Point(24, 240)
Me.Label41.Name = "Label41"
Me.Label41.Size = New System.Drawing.Size(184, 16)
Me.Label41.TabIndex = 6
Me.Label41.Text = "M Spindle Load"
'
'mspinCurrentToolInH1Turret
'
Me.mspinCurrentToolInH1Turret.Location = New System.Drawing.Point(224, 216)
Me.mspinCurrentToolInH1Turret.Name = "mspinCurrentToolInH1Turret"
Me.mspinCurrentToolInH1Turret.Size = New System.Drawing.Size(120, 20)
Me.mspinCurrentToolInH1Turret.TabIndex = 5
Me.mspinCurrentToolInH1Turret.Text = ""
'
'Label40
'
Me.Label40.Location = New System.Drawing.Point(24, 216)
Me.Label40.Name = "Label40"
Me.Label40.Size = New System.Drawing.Size(184, 16)
Me.Label40.TabIndex = 4
Me.Label40.Text = "Current Tool In H1 Turret"
'
'mspinCommandMSpindleRate
'
Me.mspinCommandMSpindleRate.Location = New System.Drawing.Point(224, 192)
Me.mspinCommandMSpindleRate.Name = "mspinCommandMSpindleRate"
Me.mspinCommandMSpindleRate.Size = New System.Drawing.Size(120, 20)
Me.mspinCommandMSpindleRate.TabIndex = 3
Me.mspinCommandMSpindleRate.Text = ""
'
'Label39
'
Me.Label39.Location = New System.Drawing.Point(24, 192)
Me.Label39.Name = "Label39"
Me.Label39.Size = New System.Drawing.Size(184, 16)
Me.Label39.TabIndex = 2
Me.Label39.Text = "Command M Spindle Rate"
'
'mspinActualMSpindleRate
'
Me.mspinActualMSpindleRate.Location = New System.Drawing.Point(224, 168)
Me.mspinActualMSpindleRate.Name = "mspinActualMSpindleRate"
Me.mspinActualMSpindleRate.Size = New System.Drawing.Size(120, 20)
Me.mspinActualMSpindleRate.TabIndex = 1
Me.mspinActualMSpindleRate.Text = ""
'
'Label38
'
Me.Label38.Location = New System.Drawing.Point(24, 168)
Me.Label38.Name = "Label38"
Me.Label38.Size = New System.Drawing.Size(176, 16)
Me.Label38.TabIndex = 0
Me.Label38.Text = "Actual M Spindle Rate"
'
'tab_OptionalParameter
'
Me.tab_OptionalParameter.Controls.Add(Me.GroupBox12)
Me.tab_OptionalParameter.Controls.Add(Me.cmdOptionalParameterSubSystem)
Me.tab_OptionalParameter.Controls.Add(Me.cboOptionalParameterSubSystem)
Me.tab_OptionalParameter.Location = New System.Drawing.Point(4, 22)
Me.tab_OptionalParameter.Name = "tab_OptionalParameter"
Me.tab_OptionalParameter.Size = New System.Drawing.Size(776, 446)
Me.tab_OptionalParameter.TabIndex = 27
Me.tab_OptionalParameter.Text = "Option Parameter"
'
'GroupBox12
'
Me.GroupBox12.Controls.Add(Me.txtLongWordInput)
Me.GroupBox12.Controls.Add(Me.txtWordInput)
Me.GroupBox12.Controls.Add(Me.txtBitInput)
Me.GroupBox12.Controls.Add(Me.cmdWordAdd)
Me.GroupBox12.Controls.Add(Me.cmdLongWordAdd)
Me.GroupBox12.Controls.Add(Me.cmdBitSet)
Me.GroupBox12.Controls.Add(Me.cmdWordSet)
Me.GroupBox12.Controls.Add(Me.cmdLongWordSet)
Me.GroupBox12.Controls.Add(Me.cmdOptionalParameterBitGet)
Me.GroupBox12.Controls.Add(Me.cmdOptionalParameterWordGet)
Me.GroupBox12.Controls.Add(Me.cmdOptionalParameterLongWordGet)
Me.GroupBox12.Controls.Add(Me.txtOptionalParameterLongWord)
Me.GroupBox12.Controls.Add(Me.txtOptionalParameterWord)
Me.GroupBox12.Controls.Add(Me.txtOptionalParameterBit)
Me.GroupBox12.Controls.Add(Me.Label299)
Me.GroupBox12.Controls.Add(Me.txtOptionalParameterBitNo)
Me.GroupBox12.Controls.Add(Me.Label300)
Me.GroupBox12.Controls.Add(Me.txtOptionalParameterLongWordIndex)
Me.GroupBox12.Controls.Add(Me.Label301)
Me.GroupBox12.Controls.Add(Me.txtOptionalParameterWordIndex)
Me.GroupBox12.Controls.Add(Me.Label302)
Me.GroupBox12.Controls.Add(Me.txtOptionalParameterBitIndex)
Me.GroupBox12.Controls.Add(Me.Label303)
Me.GroupBox12.Location = New System.Drawing.Point(16, 48)
Me.GroupBox12.Name = "GroupBox12"
Me.GroupBox12.Size = New System.Drawing.Size(488, 168)
Me.GroupBox12.TabIndex = 238
Me.GroupBox12.TabStop = false
Me.GroupBox12.Text = "Optional Parameter - Bit/Word/LongWord"
'
'txtLongWordInput
'
Me.txtLongWordInput.ForeColor = System.Drawing.Color.Red
Me.txtLongWordInput.Location = New System.Drawing.Point(432, 136)
Me.txtLongWordInput.Name = "txtLongWordInput"
Me.txtLongWordInput.Size = New System.Drawing.Size(48, 20)
Me.txtLongWordInput.TabIndex = 204
Me.txtLongWordInput.Text = "1"
'
'txtWordInput
'
Me.txtWordInput.ForeColor = System.Drawing.Color.Red
Me.txtWordInput.Location = New System.Drawing.Point(432, 96)
Me.txtWordInput.Name = "txtWordInput"
Me.txtWordInput.Size = New System.Drawing.Size(48, 20)
Me.txtWordInput.TabIndex = 203
Me.txtWordInput.Text = "1"
'
'txtBitInput
'
Me.txtBitInput.ForeColor = System.Drawing.Color.Red
Me.txtBitInput.Location = New System.Drawing.Point(432, 56)
Me.txtBitInput.Name = "txtBitInput"
Me.txtBitInput.Size = New System.Drawing.Size(48, 20)
Me.txtBitInput.TabIndex = 202
Me.txtBitInput.Text = "1"
'
'cmdWordAdd
'
Me.cmdWordAdd.Location = New System.Drawing.Point(384, 96)
Me.cmdWordAdd.Name = "cmdWordAdd"
Me.cmdWordAdd.Size = New System.Drawing.Size(40, 24)
Me.cmdWordAdd.TabIndex = 201
Me.cmdWordAdd.Text = "Add"
'
'cmdLongWordAdd
'
Me.cmdLongWordAdd.Location = New System.Drawing.Point(384, 136)
Me.cmdLongWordAdd.Name = "cmdLongWordAdd"
Me.cmdLongWordAdd.Size = New System.Drawing.Size(40, 24)
Me.cmdLongWordAdd.TabIndex = 200
Me.cmdLongWordAdd.Text = "Add"
'
'cmdBitSet
'
Me.cmdBitSet.Location = New System.Drawing.Point(336, 56)
Me.cmdBitSet.Name = "cmdBitSet"
Me.cmdBitSet.Size = New System.Drawing.Size(40, 24)
Me.cmdBitSet.TabIndex = 199
Me.cmdBitSet.Text = "Set"
'
'cmdWordSet
'
Me.cmdWordSet.Location = New System.Drawing.Point(336, 96)
Me.cmdWordSet.Name = "cmdWordSet"
Me.cmdWordSet.Size = New System.Drawing.Size(40, 24)
Me.cmdWordSet.TabIndex = 198
Me.cmdWordSet.Text = "Set"
'
'cmdLongWordSet
'
Me.cmdLongWordSet.Location = New System.Drawing.Point(336, 136)
Me.cmdLongWordSet.Name = "cmdLongWordSet"
Me.cmdLongWordSet.Size = New System.Drawing.Size(40, 24)
Me.cmdLongWordSet.TabIndex = 197
Me.cmdLongWordSet.Text = "Set"
'
'cmdOptionalParameterBitGet
'
Me.cmdOptionalParameterBitGet.Location = New System.Drawing.Point(288, 56)
Me.cmdOptionalParameterBitGet.Name = "cmdOptionalParameterBitGet"
Me.cmdOptionalParameterBitGet.Size = New System.Drawing.Size(40, 24)
Me.cmdOptionalParameterBitGet.TabIndex = 196
Me.cmdOptionalParameterBitGet.Text = "Get"
'
'cmdOptionalParameterWordGet
'
Me.cmdOptionalParameterWordGet.Location = New System.Drawing.Point(288, 96)
Me.cmdOptionalParameterWordGet.Name = "cmdOptionalParameterWordGet"
Me.cmdOptionalParameterWordGet.Size = New System.Drawing.Size(40, 24)
Me.cmdOptionalParameterWordGet.TabIndex = 193
Me.cmdOptionalParameterWordGet.Text = "Get"
'
'cmdOptionalParameterLongWordGet
'
Me.cmdOptionalParameterLongWordGet.Location = New System.Drawing.Point(288, 136)
Me.cmdOptionalParameterLongWordGet.Name = "cmdOptionalParameterLongWordGet"
Me.cmdOptionalParameterLongWordGet.Size = New System.Drawing.Size(40, 24)
Me.cmdOptionalParameterLongWordGet.TabIndex = 190
Me.cmdOptionalParameterLongWordGet.Text = "Get"
'
'txtOptionalParameterLongWord
'
Me.txtOptionalParameterLongWord.Location = New System.Drawing.Point(208, 136)
Me.txtOptionalParameterLongWord.Name = "txtOptionalParameterLongWord"
Me.txtOptionalParameterLongWord.ReadOnly = true
Me.txtOptionalParameterLongWord.Size = New System.Drawing.Size(64, 20)
Me.txtOptionalParameterLongWord.TabIndex = 11
Me.txtOptionalParameterLongWord.Text = "0"
'
'txtOptionalParameterWord
'
Me.txtOptionalParameterWord.Location = New System.Drawing.Point(208, 96)
Me.txtOptionalParameterWord.Name = "txtOptionalParameterWord"
Me.txtOptionalParameterWord.ReadOnly = true
Me.txtOptionalParameterWord.Size = New System.Drawing.Size(64, 20)
Me.txtOptionalParameterWord.TabIndex = 10
Me.txtOptionalParameterWord.Text = "0"
'
'txtOptionalParameterBit
'
Me.txtOptionalParameterBit.Location = New System.Drawing.Point(208, 56)
Me.txtOptionalParameterBit.Name = "txtOptionalParameterBit"
Me.txtOptionalParameterBit.ReadOnly = true
Me.txtOptionalParameterBit.Size = New System.Drawing.Size(64, 20)
Me.txtOptionalParameterBit.TabIndex = 9
Me.txtOptionalParameterBit.Text = "0"
'
'Label299
'
Me.Label299.Location = New System.Drawing.Point(144, 24)
Me.Label299.Name = "Label299"
Me.Label299.Size = New System.Drawing.Size(48, 23)
Me.Label299.TabIndex = 8
Me.Label299.Text = "Bit No."
'
'txtOptionalParameterBitNo
'
Me.txtOptionalParameterBitNo.Location = New System.Drawing.Point(144, 56)
Me.txtOptionalParameterBitNo.Name = "txtOptionalParameterBitNo"
Me.txtOptionalParameterBitNo.Size = New System.Drawing.Size(48, 20)
Me.txtOptionalParameterBitNo.TabIndex = 7
Me.txtOptionalParameterBitNo.Text = "0"
'
'Label300
'
Me.Label300.Location = New System.Drawing.Point(80, 24)
Me.Label300.Name = "Label300"
Me.Label300.Size = New System.Drawing.Size(48, 23)
Me.Label300.TabIndex = 6
Me.Label300.Text = "Index"
'
'txtOptionalParameterLongWordIndex
'
Me.txtOptionalParameterLongWordIndex.Location = New System.Drawing.Point(80, 136)
Me.txtOptionalParameterLongWordIndex.Name = "txtOptionalParameterLongWordIndex"
Me.txtOptionalParameterLongWordIndex.Size = New System.Drawing.Size(48, 20)
Me.txtOptionalParameterLongWordIndex.TabIndex = 5
Me.txtOptionalParameterLongWordIndex.Text = "1"
'
'Label301
'
Me.Label301.Location = New System.Drawing.Point(8, 136)
Me.Label301.Name = "Label301"
Me.Label301.Size = New System.Drawing.Size(64, 24)
Me.Label301.TabIndex = 4
Me.Label301.Text = "Long Word"
'
'txtOptionalParameterWordIndex
'
Me.txtOptionalParameterWordIndex.Location = New System.Drawing.Point(80, 96)
Me.txtOptionalParameterWordIndex.Name = "txtOptionalParameterWordIndex"
Me.txtOptionalParameterWordIndex.Size = New System.Drawing.Size(48, 20)
Me.txtOptionalParameterWordIndex.TabIndex = 3
Me.txtOptionalParameterWordIndex.Text = "1"
'
'Label302
'
Me.Label302.Location = New System.Drawing.Point(8, 96)
Me.Label302.Name = "Label302"
Me.Label302.Size = New System.Drawing.Size(64, 24)
Me.Label302.TabIndex = 2
Me.Label302.Text = "Word"
'
'txtOptionalParameterBitIndex
'
Me.txtOptionalParameterBitIndex.Location = New System.Drawing.Point(80, 56)
Me.txtOptionalParameterBitIndex.Name = "txtOptionalParameterBitIndex"
Me.txtOptionalParameterBitIndex.Size = New System.Drawing.Size(48, 20)
Me.txtOptionalParameterBitIndex.TabIndex = 1
Me.txtOptionalParameterBitIndex.Text = "1"
'
'Label303
'
Me.Label303.Location = New System.Drawing.Point(8, 56)
Me.Label303.Name = "Label303"
Me.Label303.Size = New System.Drawing.Size(64, 24)
Me.Label303.TabIndex = 0
Me.Label303.Text = "Bit"
'
'cmdOptionalParameterSubSystem
'
Me.cmdOptionalParameterSubSystem.Location = New System.Drawing.Point(16, 8)
Me.cmdOptionalParameterSubSystem.Name = "cmdOptionalParameterSubSystem"
Me.cmdOptionalParameterSubSystem.Size = New System.Drawing.Size(184, 24)
Me.cmdOptionalParameterSubSystem.TabIndex = 237
Me.cmdOptionalParameterSubSystem.Text = "Sub System"
'
'cboOptionalParameterSubSystem
'
Me.cboOptionalParameterSubSystem.ItemHeight = 13
Me.cboOptionalParameterSubSystem.Location = New System.Drawing.Point(216, 8)
Me.cboOptionalParameterSubSystem.Name = "cboOptionalParameterSubSystem"
Me.cboOptionalParameterSubSystem.Size = New System.Drawing.Size(184, 21)
Me.cboOptionalParameterSubSystem.TabIndex = 236
'
'tab_PLC
'
Me.tab_PLC.Controls.Add(Me.grpIOVariables)
Me.tab_PLC.Location = New System.Drawing.Point(4, 22)
Me.tab_PLC.Name = "tab_PLC"
Me.tab_PLC.Size = New System.Drawing.Size(776, 446)
Me.tab_PLC.TabIndex = 28
Me.tab_PLC.Text = "I/O"
'
'grpIOVariables
'
Me.grpIOVariables.Controls.Add(Me.Label297)
Me.grpIOVariables.Controls.Add(Me.cboIOVariableTypes)
Me.grpIOVariables.Controls.Add(Me.cmdIOGetBit)
Me.grpIOVariables.Controls.Add(Me.cmdIOGetWord)
Me.grpIOVariables.Controls.Add(Me.cmdIOGetLongWord)
Me.grpIOVariables.Controls.Add(Me.txtIOLongWord)
Me.grpIOVariables.Controls.Add(Me.txtIOWord)
Me.grpIOVariables.Controls.Add(Me.txtIOBit)
Me.grpIOVariables.Controls.Add(Me.Label296)
Me.grpIOVariables.Controls.Add(Me.txtIOBitNo)
Me.grpIOVariables.Controls.Add(Me.Label295)
Me.grpIOVariables.Controls.Add(Me.txtIOLongWordIndex)
Me.grpIOVariables.Controls.Add(Me.Label294)
Me.grpIOVariables.Controls.Add(Me.txtIOWordIndex)
Me.grpIOVariables.Controls.Add(Me.Label293)
Me.grpIOVariables.Controls.Add(Me.txtIOBitIndex)
Me.grpIOVariables.Controls.Add(Me.Label292)
Me.grpIOVariables.Location = New System.Drawing.Point(8, 16)
Me.grpIOVariables.Name = "grpIOVariables"
Me.grpIOVariables.Size = New System.Drawing.Size(384, 200)
Me.grpIOVariables.TabIndex = 235
Me.grpIOVariables.TabStop = false
Me.grpIOVariables.Text = "I/O Variables"
'
'Label297
'
Me.Label297.Location = New System.Drawing.Point(8, 16)
Me.Label297.Name = "Label297"
Me.Label297.Size = New System.Drawing.Size(120, 24)
Me.Label297.TabIndex = 198
Me.Label297.Text = "I/O Variables Type:"
'
'cboIOVariableTypes
'
Me.cboIOVariableTypes.Location = New System.Drawing.Point(136, 16)
Me.cboIOVariableTypes.Name = "cboIOVariableTypes"
Me.cboIOVariableTypes.Size = New System.Drawing.Size(240, 21)
Me.cboIOVariableTypes.TabIndex = 197
'
'cmdIOGetBit
'
Me.cmdIOGetBit.Location = New System.Drawing.Point(336, 80)
Me.cmdIOGetBit.Name = "cmdIOGetBit"
Me.cmdIOGetBit.Size = New System.Drawing.Size(40, 24)
Me.cmdIOGetBit.TabIndex = 196
Me.cmdIOGetBit.Text = "Get"
'
'cmdIOGetWord
'
Me.cmdIOGetWord.Location = New System.Drawing.Point(336, 120)
Me.cmdIOGetWord.Name = "cmdIOGetWord"
Me.cmdIOGetWord.Size = New System.Drawing.Size(40, 24)
Me.cmdIOGetWord.TabIndex = 193
Me.cmdIOGetWord.Text = "Get"
'
'cmdIOGetLongWord
'
Me.cmdIOGetLongWord.Location = New System.Drawing.Point(336, 160)
Me.cmdIOGetLongWord.Name = "cmdIOGetLongWord"
Me.cmdIOGetLongWord.Size = New System.Drawing.Size(40, 24)
Me.cmdIOGetLongWord.TabIndex = 190
Me.cmdIOGetLongWord.Text = "Get"
'
'txtIOLongWord
'
Me.txtIOLongWord.Location = New System.Drawing.Point(208, 160)
Me.txtIOLongWord.Name = "txtIOLongWord"
Me.txtIOLongWord.ReadOnly = true
Me.txtIOLongWord.Size = New System.Drawing.Size(120, 20)
Me.txtIOLongWord.TabIndex = 11
Me.txtIOLongWord.Text = "0"
'
'txtIOWord
'
Me.txtIOWord.Location = New System.Drawing.Point(208, 120)
Me.txtIOWord.Name = "txtIOWord"
Me.txtIOWord.ReadOnly = true
Me.txtIOWord.Size = New System.Drawing.Size(64, 20)
Me.txtIOWord.TabIndex = 10
Me.txtIOWord.Text = "0"
'
'txtIOBit
'
Me.txtIOBit.Location = New System.Drawing.Point(208, 80)
Me.txtIOBit.Name = "txtIOBit"
Me.txtIOBit.ReadOnly = true
Me.txtIOBit.Size = New System.Drawing.Size(24, 20)
Me.txtIOBit.TabIndex = 9
Me.txtIOBit.Text = "0"
'
'Label296
'
Me.Label296.Location = New System.Drawing.Point(144, 48)
Me.Label296.Name = "Label296"
Me.Label296.Size = New System.Drawing.Size(48, 23)
Me.Label296.TabIndex = 8
Me.Label296.Text = "Bit No."
'
'txtIOBitNo
'
Me.txtIOBitNo.Location = New System.Drawing.Point(144, 80)
Me.txtIOBitNo.Name = "txtIOBitNo"
Me.txtIOBitNo.Size = New System.Drawing.Size(48, 20)
Me.txtIOBitNo.TabIndex = 7
Me.txtIOBitNo.Text = "0"
'
'Label295
'
Me.Label295.Location = New System.Drawing.Point(80, 48)
Me.Label295.Name = "Label295"
Me.Label295.Size = New System.Drawing.Size(48, 23)
Me.Label295.TabIndex = 6
Me.Label295.Text = "Index"
'
'txtIOLongWordIndex
'
Me.txtIOLongWordIndex.Location = New System.Drawing.Point(80, 160)
Me.txtIOLongWordIndex.Name = "txtIOLongWordIndex"
Me.txtIOLongWordIndex.Size = New System.Drawing.Size(48, 20)
Me.txtIOLongWordIndex.TabIndex = 5
Me.txtIOLongWordIndex.Text = "1"
'
'Label294
'
Me.Label294.Location = New System.Drawing.Point(8, 152)
Me.Label294.Name = "Label294"
Me.Label294.Size = New System.Drawing.Size(64, 32)
Me.Label294.TabIndex = 4
Me.Label294.Text = "Long Word I/O"
'
'txtIOWordIndex
'
Me.txtIOWordIndex.Location = New System.Drawing.Point(80, 120)
Me.txtIOWordIndex.Name = "txtIOWordIndex"
Me.txtIOWordIndex.Size = New System.Drawing.Size(48, 20)
Me.txtIOWordIndex.TabIndex = 3
Me.txtIOWordIndex.Text = "1"
'
'Label293
'
Me.Label293.Location = New System.Drawing.Point(8, 120)
Me.Label293.Name = "Label293"
Me.Label293.Size = New System.Drawing.Size(64, 24)
Me.Label293.TabIndex = 2
Me.Label293.Text = "Word I/O"
'
'txtIOBitIndex
'
Me.txtIOBitIndex.Location = New System.Drawing.Point(80, 80)
Me.txtIOBitIndex.Name = "txtIOBitIndex"
Me.txtIOBitIndex.Size = New System.Drawing.Size(48, 20)
Me.txtIOBitIndex.TabIndex = 1
Me.txtIOBitIndex.Text = "1"
'
'Label292
'
Me.Label292.Location = New System.Drawing.Point(8, 80)
Me.Label292.Name = "Label292"
Me.Label292.Size = New System.Drawing.Size(64, 24)
Me.Label292.TabIndex = 0
Me.Label292.Text = "Bit I/O"
'
'tab_CurrentAlarm
'
Me.tab_CurrentAlarm.Controls.Add(Me.cboCurrentAlarm_SubSystem)
Me.tab_CurrentAlarm.Controls.Add(Me.Label96)
Me.tab_CurrentAlarm.Controls.Add(Me.cmdCurrentAlarm_Update)
Me.tab_CurrentAlarm.Controls.Add(Me.GroupBox20)
Me.tab_CurrentAlarm.Location = New System.Drawing.Point(4, 22)
Me.tab_CurrentAlarm.Name = "tab_CurrentAlarm"
Me.tab_CurrentAlarm.Size = New System.Drawing.Size(776, 446)
Me.tab_CurrentAlarm.TabIndex = 29
Me.tab_CurrentAlarm.Text = "Current Alarm"
'
'cboCurrentAlarm_SubSystem
'
Me.cboCurrentAlarm_SubSystem.Location = New System.Drawing.Point(512, 8)
Me.cboCurrentAlarm_SubSystem.Name = "cboCurrentAlarm_SubSystem"
Me.cboCurrentAlarm_SubSystem.Size = New System.Drawing.Size(248, 21)
Me.cboCurrentAlarm_SubSystem.TabIndex = 186
'
'Label96
'
Me.Label96.Location = New System.Drawing.Point(424, 8)
Me.Label96.Name = "Label96"
Me.Label96.Size = New System.Drawing.Size(80, 16)
Me.Label96.TabIndex = 185
Me.Label96.Text = "Sub System :"
'
'cmdCurrentAlarm_Update
'
Me.cmdCurrentAlarm_Update.Location = New System.Drawing.Point(8, 8)
Me.cmdCurrentAlarm_Update.Name = "cmdCurrentAlarm_Update"
Me.cmdCurrentAlarm_Update.Size = New System.Drawing.Size(112, 32)
Me.cmdCurrentAlarm_Update.TabIndex = 87
Me.cmdCurrentAlarm_Update.Text = "Update"
'
'GroupBox20
'
Me.GroupBox20.Controls.Add(Me.txtCurrentAlarm_AlarmCharacterString)
Me.GroupBox20.Controls.Add(Me.txtCurrentAlarm_AlarmCode)
Me.GroupBox20.Controls.Add(Me.PictureBox2)
Me.GroupBox20.Controls.Add(Me.txtCurrentAlarm_ObjectMessage)
Me.GroupBox20.Controls.Add(Me.txtCurrentAlarm_AlarmMessage)
Me.GroupBox20.Controls.Add(Me.txtCurrentAlarm_AlarmLevel)
Me.GroupBox20.Controls.Add(Me.txtCurrentAlarm_ObjectNumber)
Me.GroupBox20.Controls.Add(Me.txtCurrentAlarm_AlarmNumber)
Me.GroupBox20.Controls.Add(Me.PictureBox3)
Me.GroupBox20.Location = New System.Drawing.Point(4, 56)
Me.GroupBox20.Name = "GroupBox20"
Me.GroupBox20.Size = New System.Drawing.Size(760, 376)
Me.GroupBox20.TabIndex = 86
Me.GroupBox20.TabStop = false
Me.GroupBox20.Text = "Current OSP Alarm"
'
'txtCurrentAlarm_AlarmCharacterString
'
Me.txtCurrentAlarm_AlarmCharacterString.Location = New System.Drawing.Point(280, 336)
Me.txtCurrentAlarm_AlarmCharacterString.Name = "txtCurrentAlarm_AlarmCharacterString"
Me.txtCurrentAlarm_AlarmCharacterString.ReadOnly = true
Me.txtCurrentAlarm_AlarmCharacterString.Size = New System.Drawing.Size(472, 20)
Me.txtCurrentAlarm_AlarmCharacterString.TabIndex = 10
Me.txtCurrentAlarm_AlarmCharacterString.Text = ""
'
'txtCurrentAlarm_AlarmCode
'
Me.txtCurrentAlarm_AlarmCode.Location = New System.Drawing.Point(280, 304)
Me.txtCurrentAlarm_AlarmCode.Name = "txtCurrentAlarm_AlarmCode"
Me.txtCurrentAlarm_AlarmCode.ReadOnly = true
Me.txtCurrentAlarm_AlarmCode.Size = New System.Drawing.Size(472, 20)
Me.txtCurrentAlarm_AlarmCode.TabIndex = 9
Me.txtCurrentAlarm_AlarmCode.Text = ""
'
'PictureBox2
'
Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"),System.Drawing.Image)
Me.PictureBox2.Location = New System.Drawing.Point(8, 24)
Me.PictureBox2.Name = "PictureBox2"
Me.PictureBox2.Size = New System.Drawing.Size(744, 96)
Me.PictureBox2.TabIndex = 8
Me.PictureBox2.TabStop = false
'
'txtCurrentAlarm_ObjectMessage
'
Me.txtCurrentAlarm_ObjectMessage.Location = New System.Drawing.Point(280, 264)
Me.txtCurrentAlarm_ObjectMessage.Name = "txtCurrentAlarm_ObjectMessage"
Me.txtCurrentAlarm_ObjectMessage.ReadOnly = true
Me.txtCurrentAlarm_ObjectMessage.Size = New System.Drawing.Size(472, 20)
Me.txtCurrentAlarm_ObjectMessage.TabIndex = 7
Me.txtCurrentAlarm_ObjectMessage.Text = ""
'
'txtCurrentAlarm_AlarmMessage
'
Me.txtCurrentAlarm_AlarmMessage.Location = New System.Drawing.Point(280, 232)
Me.txtCurrentAlarm_AlarmMessage.Name = "txtCurrentAlarm_AlarmMessage"
Me.txtCurrentAlarm_AlarmMessage.ReadOnly = true
Me.txtCurrentAlarm_AlarmMessage.Size = New System.Drawing.Size(232, 20)
Me.txtCurrentAlarm_AlarmMessage.TabIndex = 6
Me.txtCurrentAlarm_AlarmMessage.Text = ""
'
'txtCurrentAlarm_AlarmLevel
'
Me.txtCurrentAlarm_AlarmLevel.Location = New System.Drawing.Point(280, 200)
Me.txtCurrentAlarm_AlarmLevel.Name = "txtCurrentAlarm_AlarmLevel"
Me.txtCurrentAlarm_AlarmLevel.ReadOnly = true
Me.txtCurrentAlarm_AlarmLevel.Size = New System.Drawing.Size(128, 20)
Me.txtCurrentAlarm_AlarmLevel.TabIndex = 5
Me.txtCurrentAlarm_AlarmLevel.Text = ""
'
'txtCurrentAlarm_ObjectNumber
'
Me.txtCurrentAlarm_ObjectNumber.Location = New System.Drawing.Point(280, 168)
Me.txtCurrentAlarm_ObjectNumber.Name = "txtCurrentAlarm_ObjectNumber"
Me.txtCurrentAlarm_ObjectNumber.ReadOnly = true
Me.txtCurrentAlarm_ObjectNumber.Size = New System.Drawing.Size(56, 20)
Me.txtCurrentAlarm_ObjectNumber.TabIndex = 4
Me.txtCurrentAlarm_ObjectNumber.Text = ""
'
'txtCurrentAlarm_AlarmNumber
'
Me.txtCurrentAlarm_AlarmNumber.Location = New System.Drawing.Point(280, 136)
Me.txtCurrentAlarm_AlarmNumber.Name = "txtCurrentAlarm_AlarmNumber"
Me.txtCurrentAlarm_AlarmNumber.ReadOnly = true
Me.txtCurrentAlarm_AlarmNumber.Size = New System.Drawing.Size(56, 20)
Me.txtCurrentAlarm_AlarmNumber.TabIndex = 3
Me.txtCurrentAlarm_AlarmNumber.Text = ""
'
'PictureBox3
'
Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"),System.Drawing.Image)
Me.PictureBox3.Location = New System.Drawing.Point(8, 128)
Me.PictureBox3.Name = "PictureBox3"
Me.PictureBox3.Size = New System.Drawing.Size(264, 232)
Me.PictureBox3.TabIndex = 1
Me.PictureBox3.TabStop = false
'
'tab_ballscrew
'
Me.tab_ballscrew.Controls.Add(Me.cmdPECSet)
Me.tab_ballscrew.Controls.Add(Me.cmb_BallScrew_DataUnit)
Me.tab_ballscrew.Controls.Add(Me.cmb_BallScrew_SubSystem)
Me.tab_ballscrew.Controls.Add(Me.bsBAxisIntervalAdd)
Me.tab_ballscrew.Controls.Add(Me.bsBAxisIntervalSet)
Me.tab_ballscrew.Controls.Add(Me.bsBAxisIntervalUpdate)
Me.tab_ballscrew.Controls.Add(Me.bsBAxisInterval)
Me.tab_ballscrew.Controls.Add(Me.Label28)
Me.tab_ballscrew.Controls.Add(Me.bsIntervalCombo)
Me.tab_ballscrew.Controls.Add(Me.bsDataPointCombo)
Me.tab_ballscrew.Controls.Add(Me.Label115)
Me.tab_ballscrew.Controls.Add(Me.bsPecPoint)
Me.tab_ballscrew.Controls.Add(Me.bsBAxisStartPositionAdd)
Me.tab_ballscrew.Controls.Add(Me.bsBAxisStartPositionSet)
Me.tab_ballscrew.Controls.Add(Me.bsBAxisDataPointAdd)
Me.tab_ballscrew.Controls.Add(Me.bsBAxisDataPointSet)
Me.tab_ballscrew.Controls.Add(Me.bsIntervalAdd)
Me.tab_ballscrew.Controls.Add(Me.bsIntervalSet)
Me.tab_ballscrew.Controls.Add(Me.bsDataPointAdd)
Me.tab_ballscrew.Controls.Add(Me.bsDataPointSet)
Me.tab_ballscrew.Controls.Add(Me.bsBAxisStartPositionUpdate)
Me.tab_ballscrew.Controls.Add(Me.bsBAxisDataPointUpdate)
Me.tab_ballscrew.Controls.Add(Me.bsIntervalUpdate)
Me.tab_ballscrew.Controls.Add(Me.bsDataPointUpdate)
Me.tab_ballscrew.Controls.Add(Me.bsBAxisStartPosition)
Me.tab_ballscrew.Controls.Add(Me.Label31)
Me.tab_ballscrew.Controls.Add(Me.bsBAxisDataPoint)
Me.tab_ballscrew.Controls.Add(Me.Label30)
Me.tab_ballscrew.Controls.Add(Me.bsInterval)
Me.tab_ballscrew.Controls.Add(Me.Label29)
Me.tab_ballscrew.Controls.Add(Me.ballscrewUpdateButton)
Me.tab_ballscrew.Controls.Add(Me.bsDataPoint)
Me.tab_ballscrew.Controls.Add(Me.Label27)
Me.tab_ballscrew.Controls.Add(Me.Label161)
Me.tab_ballscrew.Controls.Add(Me.Label162)
Me.tab_ballscrew.Location = New System.Drawing.Point(4, 22)
Me.tab_ballscrew.Name = "tab_ballscrew"
Me.tab_ballscrew.Size = New System.Drawing.Size(776, 446)
Me.tab_ballscrew.TabIndex = 2
Me.tab_ballscrew.Text = "Ballscrew"
'
'cmdPECSet
'
Me.cmdPECSet.Location = New System.Drawing.Point(672, 16)
Me.cmdPECSet.Name = "cmdPECSet"
Me.cmdPECSet.Size = New System.Drawing.Size(56, 24)
Me.cmdPECSet.TabIndex = 87
Me.cmdPECSet.Text = "SET"
'
'cmb_BallScrew_DataUnit
'
Me.cmb_BallScrew_DataUnit.Location = New System.Drawing.Point(472, 16)
Me.cmb_BallScrew_DataUnit.Name = "cmb_BallScrew_DataUnit"
Me.cmb_BallScrew_DataUnit.Size = New System.Drawing.Size(176, 21)
Me.cmb_BallScrew_DataUnit.TabIndex = 85
'
'cmb_BallScrew_SubSystem
'
Me.cmb_BallScrew_SubSystem.Location = New System.Drawing.Point(152, 16)
Me.cmb_BallScrew_SubSystem.Name = "cmb_BallScrew_SubSystem"
Me.cmb_BallScrew_SubSystem.Size = New System.Drawing.Size(208, 21)
Me.cmb_BallScrew_SubSystem.TabIndex = 84
'
'bsBAxisIntervalAdd
'
Me.bsBAxisIntervalAdd.Location = New System.Drawing.Point(472, 344)
Me.bsBAxisIntervalAdd.Name = "bsBAxisIntervalAdd"
Me.bsBAxisIntervalAdd.Size = New System.Drawing.Size(64, 24)
Me.bsBAxisIntervalAdd.TabIndex = 83
Me.bsBAxisIntervalAdd.Text = "Add"
'
'bsBAxisIntervalSet
'
Me.bsBAxisIntervalSet.Location = New System.Drawing.Point(392, 344)
Me.bsBAxisIntervalSet.Name = "bsBAxisIntervalSet"
Me.bsBAxisIntervalSet.Size = New System.Drawing.Size(72, 24)
Me.bsBAxisIntervalSet.TabIndex = 82
Me.bsBAxisIntervalSet.Text = "Set"
'
'bsBAxisIntervalUpdate
'
Me.bsBAxisIntervalUpdate.BackColor = System.Drawing.SystemColors.Control
Me.bsBAxisIntervalUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.bsBAxisIntervalUpdate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.bsBAxisIntervalUpdate.ForeColor = System.Drawing.Color.Red
Me.bsBAxisIntervalUpdate.Location = New System.Drawing.Point(312, 344)
Me.bsBAxisIntervalUpdate.Name = "bsBAxisIntervalUpdate"
Me.bsBAxisIntervalUpdate.Size = New System.Drawing.Size(72, 24)
Me.bsBAxisIntervalUpdate.TabIndex = 81
Me.bsBAxisIntervalUpdate.Text = "0.00"
'
'bsBAxisInterval
'
Me.bsBAxisInterval.BackColor = System.Drawing.SystemColors.Control
Me.bsBAxisInterval.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.bsBAxisInterval.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.bsBAxisInterval.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.bsBAxisInterval.Location = New System.Drawing.Point(208, 344)
Me.bsBAxisInterval.Name = "bsBAxisInterval"
Me.bsBAxisInterval.Size = New System.Drawing.Size(88, 24)
Me.bsBAxisInterval.TabIndex = 80
Me.bsBAxisInterval.Text = "0.00"
'
'Label28
'
Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label28.Location = New System.Drawing.Point(40, 344)
Me.Label28.Name = "Label28"
Me.Label28.Size = New System.Drawing.Size(96, 16)
Me.Label28.TabIndex = 79
Me.Label28.Text = "B Axis Interval :"
'
'bsIntervalCombo
'
Me.bsIntervalCombo.Location = New System.Drawing.Point(392, 280)
Me.bsIntervalCombo.Name = "bsIntervalCombo"
Me.bsIntervalCombo.Size = New System.Drawing.Size(144, 21)
Me.bsIntervalCombo.TabIndex = 78
'
'bsDataPointCombo
'
Me.bsDataPointCombo.Location = New System.Drawing.Point(392, 248)
Me.bsDataPointCombo.Name = "bsDataPointCombo"
Me.bsDataPointCombo.Size = New System.Drawing.Size(144, 21)
Me.bsDataPointCombo.TabIndex = 77
'
'Label115
'
Me.Label115.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label115.Location = New System.Drawing.Point(32, 184)
Me.Label115.Name = "Label115"
Me.Label115.Size = New System.Drawing.Size(80, 16)
Me.Label115.TabIndex = 76
Me.Label115.Text = "PEC Point:"
'
'bsPecPoint
'
Me.bsPecPoint.Location = New System.Drawing.Point(120, 184)
Me.bsPecPoint.Name = "bsPecPoint"
Me.bsPecPoint.Size = New System.Drawing.Size(104, 20)
Me.bsPecPoint.TabIndex = 75
Me.bsPecPoint.Text = "1"
'
'bsBAxisStartPositionAdd
'
Me.bsBAxisStartPositionAdd.Location = New System.Drawing.Point(472, 376)
Me.bsBAxisStartPositionAdd.Name = "bsBAxisStartPositionAdd"
Me.bsBAxisStartPositionAdd.Size = New System.Drawing.Size(64, 24)
Me.bsBAxisStartPositionAdd.TabIndex = 72
Me.bsBAxisStartPositionAdd.Text = "Add"
'
'bsBAxisStartPositionSet
'
Me.bsBAxisStartPositionSet.Location = New System.Drawing.Point(392, 376)
Me.bsBAxisStartPositionSet.Name = "bsBAxisStartPositionSet"
Me.bsBAxisStartPositionSet.Size = New System.Drawing.Size(72, 24)
Me.bsBAxisStartPositionSet.TabIndex = 71
Me.bsBAxisStartPositionSet.Text = "Set"
'
'bsBAxisDataPointAdd
'
Me.bsBAxisDataPointAdd.Location = New System.Drawing.Point(472, 312)
Me.bsBAxisDataPointAdd.Name = "bsBAxisDataPointAdd"
Me.bsBAxisDataPointAdd.Size = New System.Drawing.Size(64, 24)
Me.bsBAxisDataPointAdd.TabIndex = 70
Me.bsBAxisDataPointAdd.Text = "Add"
'
'bsBAxisDataPointSet
'
Me.bsBAxisDataPointSet.Location = New System.Drawing.Point(392, 312)
Me.bsBAxisDataPointSet.Name = "bsBAxisDataPointSet"
Me.bsBAxisDataPointSet.Size = New System.Drawing.Size(72, 24)
Me.bsBAxisDataPointSet.TabIndex = 69
Me.bsBAxisDataPointSet.Text = "Set"
'
'bsIntervalAdd
'
Me.bsIntervalAdd.Location = New System.Drawing.Point(608, 280)
Me.bsIntervalAdd.Name = "bsIntervalAdd"
Me.bsIntervalAdd.Size = New System.Drawing.Size(56, 24)
Me.bsIntervalAdd.TabIndex = 68
Me.bsIntervalAdd.Text = "Add"
'
'bsIntervalSet
'
Me.bsIntervalSet.Location = New System.Drawing.Point(544, 280)
Me.bsIntervalSet.Name = "bsIntervalSet"
Me.bsIntervalSet.Size = New System.Drawing.Size(56, 24)
Me.bsIntervalSet.TabIndex = 67
Me.bsIntervalSet.Text = "Set"
'
'bsDataPointAdd
'
Me.bsDataPointAdd.Location = New System.Drawing.Point(608, 248)
Me.bsDataPointAdd.Name = "bsDataPointAdd"
Me.bsDataPointAdd.Size = New System.Drawing.Size(56, 24)
Me.bsDataPointAdd.TabIndex = 66
Me.bsDataPointAdd.Text = "Add"
'
'bsDataPointSet
'
Me.bsDataPointSet.Location = New System.Drawing.Point(544, 248)
Me.bsDataPointSet.Name = "bsDataPointSet"
Me.bsDataPointSet.Size = New System.Drawing.Size(56, 24)
Me.bsDataPointSet.TabIndex = 65
Me.bsDataPointSet.Text = "Set"
'
'bsBAxisStartPositionUpdate
'
Me.bsBAxisStartPositionUpdate.BackColor = System.Drawing.SystemColors.Control
Me.bsBAxisStartPositionUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.bsBAxisStartPositionUpdate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.bsBAxisStartPositionUpdate.ForeColor = System.Drawing.Color.Red
Me.bsBAxisStartPositionUpdate.Location = New System.Drawing.Point(312, 376)
Me.bsBAxisStartPositionUpdate.Name = "bsBAxisStartPositionUpdate"
Me.bsBAxisStartPositionUpdate.Size = New System.Drawing.Size(72, 24)
Me.bsBAxisStartPositionUpdate.TabIndex = 64
Me.bsBAxisStartPositionUpdate.Text = "0.00"
'
'bsBAxisDataPointUpdate
'
Me.bsBAxisDataPointUpdate.BackColor = System.Drawing.SystemColors.Control
Me.bsBAxisDataPointUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.bsBAxisDataPointUpdate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.bsBAxisDataPointUpdate.ForeColor = System.Drawing.Color.Red
Me.bsBAxisDataPointUpdate.Location = New System.Drawing.Point(312, 312)
Me.bsBAxisDataPointUpdate.Name = "bsBAxisDataPointUpdate"
Me.bsBAxisDataPointUpdate.Size = New System.Drawing.Size(72, 24)
Me.bsBAxisDataPointUpdate.TabIndex = 63
Me.bsBAxisDataPointUpdate.Text = "0.00"
'
'bsIntervalUpdate
'
Me.bsIntervalUpdate.BackColor = System.Drawing.SystemColors.Control
Me.bsIntervalUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.bsIntervalUpdate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.bsIntervalUpdate.ForeColor = System.Drawing.Color.Red
Me.bsIntervalUpdate.Location = New System.Drawing.Point(312, 280)
Me.bsIntervalUpdate.Name = "bsIntervalUpdate"
Me.bsIntervalUpdate.Size = New System.Drawing.Size(72, 24)
Me.bsIntervalUpdate.TabIndex = 62
Me.bsIntervalUpdate.Text = "0.00"
'
'bsDataPointUpdate
'
Me.bsDataPointUpdate.BackColor = System.Drawing.SystemColors.Control
Me.bsDataPointUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.bsDataPointUpdate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.bsDataPointUpdate.ForeColor = System.Drawing.Color.Red
Me.bsDataPointUpdate.Location = New System.Drawing.Point(312, 248)
Me.bsDataPointUpdate.Name = "bsDataPointUpdate"
Me.bsDataPointUpdate.Size = New System.Drawing.Size(72, 24)
Me.bsDataPointUpdate.TabIndex = 61
Me.bsDataPointUpdate.Text = "0.00"
'
'bsBAxisStartPosition
'
Me.bsBAxisStartPosition.BackColor = System.Drawing.SystemColors.Control
Me.bsBAxisStartPosition.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.bsBAxisStartPosition.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.bsBAxisStartPosition.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.bsBAxisStartPosition.Location = New System.Drawing.Point(208, 376)
Me.bsBAxisStartPosition.Name = "bsBAxisStartPosition"
Me.bsBAxisStartPosition.Size = New System.Drawing.Size(88, 24)
Me.bsBAxisStartPosition.TabIndex = 60
Me.bsBAxisStartPosition.Text = "0.00"
'
'Label31
'
Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label31.Location = New System.Drawing.Point(40, 376)
Me.Label31.Name = "Label31"
Me.Label31.Size = New System.Drawing.Size(128, 16)
Me.Label31.TabIndex = 59
Me.Label31.Text = "B Axis Start Position :"
'
'bsBAxisDataPoint
'
Me.bsBAxisDataPoint.BackColor = System.Drawing.SystemColors.Control
Me.bsBAxisDataPoint.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.bsBAxisDataPoint.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.bsBAxisDataPoint.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.bsBAxisDataPoint.Location = New System.Drawing.Point(208, 312)
Me.bsBAxisDataPoint.Name = "bsBAxisDataPoint"
Me.bsBAxisDataPoint.Size = New System.Drawing.Size(88, 24)
Me.bsBAxisDataPoint.TabIndex = 58
Me.bsBAxisDataPoint.Text = "0.00"
'
'Label30
'
Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label30.Location = New System.Drawing.Point(40, 312)
Me.Label30.Name = "Label30"
Me.Label30.Size = New System.Drawing.Size(128, 16)
Me.Label30.TabIndex = 57
Me.Label30.Text = "B Axis Data Point:"
'
'bsInterval
'
Me.bsInterval.BackColor = System.Drawing.SystemColors.Control
Me.bsInterval.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.bsInterval.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.bsInterval.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.bsInterval.Location = New System.Drawing.Point(208, 280)
Me.bsInterval.Name = "bsInterval"
Me.bsInterval.Size = New System.Drawing.Size(88, 24)
Me.bsInterval.TabIndex = 56
Me.bsInterval.Text = "0.00"
'
'Label29
'
Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label29.Location = New System.Drawing.Point(40, 280)
Me.Label29.Name = "Label29"
Me.Label29.Size = New System.Drawing.Size(80, 16)
Me.Label29.TabIndex = 55
Me.Label29.Text = "Interval :"
'
'ballscrewUpdateButton
'
Me.ballscrewUpdateButton.Location = New System.Drawing.Point(328, 88)
Me.ballscrewUpdateButton.Name = "ballscrewUpdateButton"
Me.ballscrewUpdateButton.Size = New System.Drawing.Size(104, 24)
Me.ballscrewUpdateButton.TabIndex = 52
Me.ballscrewUpdateButton.Text = "Update"
'
'bsDataPoint
'
Me.bsDataPoint.BackColor = System.Drawing.SystemColors.Control
Me.bsDataPoint.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.bsDataPoint.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.bsDataPoint.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.bsDataPoint.Location = New System.Drawing.Point(208, 248)
Me.bsDataPoint.Name = "bsDataPoint"
Me.bsDataPoint.Size = New System.Drawing.Size(88, 24)
Me.bsDataPoint.TabIndex = 23
Me.bsDataPoint.Text = "0.00"
'
'Label27
'
Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label27.Location = New System.Drawing.Point(40, 248)
Me.Label27.Name = "Label27"
Me.Label27.Size = New System.Drawing.Size(88, 16)
Me.Label27.TabIndex = 22
Me.Label27.Text = "Data Point:"
'
'Label161
'
Me.Label161.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label161.Location = New System.Drawing.Point(24, 16)
Me.Label161.Name = "Label161"
Me.Label161.Size = New System.Drawing.Size(128, 16)
Me.Label161.TabIndex = 76
Me.Label161.Text = "Current Sub System :"
'
'Label162
'
Me.Label162.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label162.Location = New System.Drawing.Point(384, 24)
Me.Label162.Name = "Label162"
Me.Label162.Size = New System.Drawing.Size(80, 16)
Me.Label162.TabIndex = 76
Me.Label162.Text = "Data Unit :"
'
'tab_MacManAlarmHistory
'
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahTo)
Me.tab_MacManAlarmHistory.Controls.Add(Me.Label137)
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahFrom)
Me.tab_MacManAlarmHistory.Controls.Add(Me.Label138)
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahResults)
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahButtonResults)
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahAlarmObject)
Me.tab_MacManAlarmHistory.Controls.Add(Me.Label135)
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahAlarmSubSystemSet)
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahAlarmSubSystemCombo)
Me.tab_MacManAlarmHistory.Controls.Add(Me.Label134)
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahUpdateButton)
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahAlarmIndex)
Me.tab_MacManAlarmHistory.Controls.Add(Me.Label107)
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahMaxAlarmCount)
Me.tab_MacManAlarmHistory.Controls.Add(Me.Label98)
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahAlarmCount)
Me.tab_MacManAlarmHistory.Controls.Add(Me.Label101)
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahAlarmTime)
Me.tab_MacManAlarmHistory.Controls.Add(Me.Label102)
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahAlarmNumber)
Me.tab_MacManAlarmHistory.Controls.Add(Me.Label103)
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahAlarmMessage)
Me.tab_MacManAlarmHistory.Controls.Add(Me.Label104)
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahAlarmDate)
Me.tab_MacManAlarmHistory.Controls.Add(Me.Label105)
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahAlarmCode)
Me.tab_MacManAlarmHistory.Controls.Add(Me.Label106)
Me.tab_MacManAlarmHistory.Location = New System.Drawing.Point(4, 22)
Me.tab_MacManAlarmHistory.Name = "tab_MacManAlarmHistory"
Me.tab_MacManAlarmHistory.Size = New System.Drawing.Size(776, 446)
Me.tab_MacManAlarmHistory.TabIndex = 12
Me.tab_MacManAlarmHistory.Text = "MacMan Alarm History"
'
'mahTo
'
Me.mahTo.Location = New System.Drawing.Point(672, 32)
Me.mahTo.Name = "mahTo"
Me.mahTo.Size = New System.Drawing.Size(64, 20)
Me.mahTo.TabIndex = 212
Me.mahTo.Text = "2"
'
'Label137
'
Me.Label137.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label137.Location = New System.Drawing.Point(616, 32)
Me.Label137.Name = "Label137"
Me.Label137.Size = New System.Drawing.Size(48, 16)
Me.Label137.TabIndex = 211
Me.Label137.Text = "To"
'
'mahFrom
'
Me.mahFrom.Location = New System.Drawing.Point(520, 32)
Me.mahFrom.Name = "mahFrom"
Me.mahFrom.Size = New System.Drawing.Size(64, 20)
Me.mahFrom.TabIndex = 210
Me.mahFrom.Text = "1"
'
'Label138
'
Me.Label138.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label138.Location = New System.Drawing.Point(464, 32)
Me.Label138.Name = "Label138"
Me.Label138.Size = New System.Drawing.Size(48, 16)
Me.Label138.TabIndex = 209
Me.Label138.Text = "From"
'
'mahResults
'
Me.mahResults.Location = New System.Drawing.Point(280, 88)
Me.mahResults.Multiline = true
Me.mahResults.Name = "mahResults"
Me.mahResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.mahResults.Size = New System.Drawing.Size(480, 336)
Me.mahResults.TabIndex = 208
Me.mahResults.Text = ""
'
'mahButtonResults
'
Me.mahButtonResults.Location = New System.Drawing.Point(584, 56)
Me.mahButtonResults.Name = "mahButtonResults"
Me.mahButtonResults.Size = New System.Drawing.Size(72, 24)
Me.mahButtonResults.TabIndex = 207
Me.mahButtonResults.Text = "Update"
'
'mahAlarmObject
'
Me.mahAlarmObject.Location = New System.Drawing.Point(128, 264)
Me.mahAlarmObject.Name = "mahAlarmObject"
Me.mahAlarmObject.Size = New System.Drawing.Size(144, 20)
Me.mahAlarmObject.TabIndex = 186
Me.mahAlarmObject.Text = ""
'
'Label135
'
Me.Label135.Location = New System.Drawing.Point(16, 264)
Me.Label135.Name = "Label135"
Me.Label135.Size = New System.Drawing.Size(104, 16)
Me.Label135.TabIndex = 185
Me.Label135.Text = "Alarm Object :"
'
'mahAlarmSubSystemSet
'
Me.mahAlarmSubSystemSet.Location = New System.Drawing.Point(336, 8)
Me.mahAlarmSubSystemSet.Name = "mahAlarmSubSystemSet"
Me.mahAlarmSubSystemSet.Size = New System.Drawing.Size(64, 24)
Me.mahAlarmSubSystemSet.TabIndex = 184
Me.mahAlarmSubSystemSet.Text = "Set"
'
'mahAlarmSubSystemCombo
'
Me.mahAlarmSubSystemCombo.Location = New System.Drawing.Point(168, 8)
Me.mahAlarmSubSystemCombo.Name = "mahAlarmSubSystemCombo"
Me.mahAlarmSubSystemCombo.Size = New System.Drawing.Size(160, 21)
Me.mahAlarmSubSystemCombo.TabIndex = 183
'
'Label134
'
Me.Label134.Location = New System.Drawing.Point(24, 8)
Me.Label134.Name = "Label134"
Me.Label134.Size = New System.Drawing.Size(136, 16)
Me.Label134.TabIndex = 182
Me.Label134.Text = "Sub System :"
'
'mahUpdateButton
'
Me.mahUpdateButton.Location = New System.Drawing.Point(240, 40)
Me.mahUpdateButton.Name = "mahUpdateButton"
Me.mahUpdateButton.Size = New System.Drawing.Size(72, 24)
Me.mahUpdateButton.TabIndex = 181
Me.mahUpdateButton.Text = "Update"
'
'mahAlarmIndex
'
Me.mahAlarmIndex.Location = New System.Drawing.Point(168, 40)
Me.mahAlarmIndex.Name = "mahAlarmIndex"
Me.mahAlarmIndex.Size = New System.Drawing.Size(64, 20)
Me.mahAlarmIndex.TabIndex = 180
Me.mahAlarmIndex.Text = "1"
'
'Label107
'
Me.Label107.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label107.Location = New System.Drawing.Point(24, 40)
Me.Label107.Name = "Label107"
Me.Label107.Size = New System.Drawing.Size(136, 16)
Me.Label107.TabIndex = 179
Me.Label107.Text = "Alarm Index :"
'
'mahMaxAlarmCount
'
Me.mahMaxAlarmCount.Location = New System.Drawing.Point(128, 240)
Me.mahMaxAlarmCount.Name = "mahMaxAlarmCount"
Me.mahMaxAlarmCount.Size = New System.Drawing.Size(144, 20)
Me.mahMaxAlarmCount.TabIndex = 178
Me.mahMaxAlarmCount.Text = ""
'
'Label98
'
Me.Label98.Location = New System.Drawing.Point(16, 240)
Me.Label98.Name = "Label98"
Me.Label98.Size = New System.Drawing.Size(104, 16)
Me.Label98.TabIndex = 177
Me.Label98.Text = "Max Alarm Count :"
'
'mahAlarmCount
'
Me.mahAlarmCount.Location = New System.Drawing.Point(128, 216)
Me.mahAlarmCount.Name = "mahAlarmCount"
Me.mahAlarmCount.Size = New System.Drawing.Size(144, 20)
Me.mahAlarmCount.TabIndex = 176
Me.mahAlarmCount.Text = ""
'
'Label101
'
Me.Label101.Location = New System.Drawing.Point(16, 216)
Me.Label101.Name = "Label101"
Me.Label101.Size = New System.Drawing.Size(104, 16)
Me.Label101.TabIndex = 175
Me.Label101.Text = "Alarm Count :"
'
'mahAlarmTime
'
Me.mahAlarmTime.Location = New System.Drawing.Point(128, 192)
Me.mahAlarmTime.Name = "mahAlarmTime"
Me.mahAlarmTime.Size = New System.Drawing.Size(144, 20)
Me.mahAlarmTime.TabIndex = 174
Me.mahAlarmTime.Text = ""
'
'Label102
'
Me.Label102.Location = New System.Drawing.Point(16, 192)
Me.Label102.Name = "Label102"
Me.Label102.Size = New System.Drawing.Size(104, 16)
Me.Label102.TabIndex = 173
Me.Label102.Text = "Alarm Time :"
'
'mahAlarmNumber
'
Me.mahAlarmNumber.Location = New System.Drawing.Point(128, 168)
Me.mahAlarmNumber.Name = "mahAlarmNumber"
Me.mahAlarmNumber.Size = New System.Drawing.Size(144, 20)
Me.mahAlarmNumber.TabIndex = 172
Me.mahAlarmNumber.Text = ""
'
'Label103
'
Me.Label103.Location = New System.Drawing.Point(16, 168)
Me.Label103.Name = "Label103"
Me.Label103.Size = New System.Drawing.Size(104, 16)
Me.Label103.TabIndex = 171
Me.Label103.Text = "Alarm Number :"
'
'mahAlarmMessage
'
Me.mahAlarmMessage.Location = New System.Drawing.Point(128, 144)
Me.mahAlarmMessage.Name = "mahAlarmMessage"
Me.mahAlarmMessage.Size = New System.Drawing.Size(144, 20)
Me.mahAlarmMessage.TabIndex = 170
Me.mahAlarmMessage.Text = ""
'
'Label104
'
Me.Label104.Location = New System.Drawing.Point(16, 144)
Me.Label104.Name = "Label104"
Me.Label104.Size = New System.Drawing.Size(104, 16)
Me.Label104.TabIndex = 169
Me.Label104.Text = "Alarm Message :"
'
'mahAlarmDate
'
Me.mahAlarmDate.Location = New System.Drawing.Point(128, 120)
Me.mahAlarmDate.Name = "mahAlarmDate"
Me.mahAlarmDate.Size = New System.Drawing.Size(144, 20)
Me.mahAlarmDate.TabIndex = 168
Me.mahAlarmDate.Text = ""
'
'Label105
'
Me.Label105.Location = New System.Drawing.Point(16, 120)
Me.Label105.Name = "Label105"
Me.Label105.Size = New System.Drawing.Size(104, 16)
Me.Label105.TabIndex = 167
Me.Label105.Text = "Alarm Date :"
'
'mahAlarmCode
'
Me.mahAlarmCode.Location = New System.Drawing.Point(128, 96)
Me.mahAlarmCode.Name = "mahAlarmCode"
Me.mahAlarmCode.Size = New System.Drawing.Size(144, 20)
Me.mahAlarmCode.TabIndex = 166
Me.mahAlarmCode.Text = ""
'
'Label106
'
Me.Label106.Location = New System.Drawing.Point(16, 96)
Me.Label106.Name = "Label106"
Me.Label106.Size = New System.Drawing.Size(104, 16)
Me.Label106.TabIndex = 165
Me.Label106.Text = "Alarm Code :"
'
'ErrorLog
'
Me.ErrorLog.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.ErrorLog.ForeColor = System.Drawing.Color.Red
Me.ErrorLog.Location = New System.Drawing.Point(40, 488)
Me.ErrorLog.Multiline = true
Me.ErrorLog.Name = "ErrorLog"
Me.ErrorLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.ErrorLog.Size = New System.Drawing.Size(680, 56)
Me.ErrorLog.TabIndex = 5
Me.ErrorLog.Text = ""
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(0, 488)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(32, 16)
Me.Label1.TabIndex = 5
Me.Label1.Text = "Log"
'
'txtCurrentAlarmNumber
'
Me.txtCurrentAlarmNumber.Location = New System.Drawing.Point(728, 488)
Me.txtCurrentAlarmNumber.Name = "txtCurrentAlarmNumber"
Me.txtCurrentAlarmNumber.Size = New System.Drawing.Size(72, 24)
Me.txtCurrentAlarmNumber.TabIndex = 5
Me.txtCurrentAlarmNumber.Text = "Clear Log"
'
'ComboBox1
'
Me.ComboBox1.Location = New System.Drawing.Point(184, 48)
Me.ComboBox1.Name = "ComboBox1"
Me.ComboBox1.Size = New System.Drawing.Size(176, 21)
Me.ComboBox1.TabIndex = 0
'
'frmMain
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(802, 549)
Me.Controls.Add(Me.ErrorLog)
Me.Controls.Add(Me.Tab_IO)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.txtCurrentAlarmNumber)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
Me.MaximizeBox = false
Me.Name = "frmMain"
Me.Text = "THINC Lathe Sample Application"
Me.Tab_IO.ResumeLayout(false)
Me.tab_axis.ResumeLayout(false)
Me.Panel4.ResumeLayout(false)
Me.CATC.ResumeLayout(false)
Me.tab_Program2.ResumeLayout(false)
Me.GroupBox18.ResumeLayout(false)
Me.tab_program.ResumeLayout(false)
Me.GroupBox1.ResumeLayout(false)
Me.Panel8.ResumeLayout(false)
Me.tab_MacmanOperatingReport.ResumeLayout(false)
Me.GroupBox6.ResumeLayout(false)
Me.GroupBox2.ResumeLayout(false)
Me.GroupBox3.ResumeLayout(false)
Me.tab_spec.ResumeLayout(false)
Me.GroupBox17.ResumeLayout(false)
Me.tab_views.ResumeLayout(false)
Me.Panel12.ResumeLayout(false)
Me.tab_ToolStandard2.ResumeLayout(false)
Me.Tool2InputPanel.ResumeLayout(false)
Me.TabPage3.ResumeLayout(false)
Me.GroupBox14.ResumeLayout(false)
Me.tab_MacmanOperatingHistory.ResumeLayout(false)
Me.tab_workpiece.ResumeLayout(false)
Me.Panel1.ResumeLayout(false)
Me.Panel9.ResumeLayout(false)
Me.Panel10.ResumeLayout(false)
Me.tab_machine.ResumeLayout(false)
Me.GroupBox19.ResumeLayout(false)
Me.tab_axis_2.ResumeLayout(false)
Me.GroupBox11.ResumeLayout(false)
Me.UserParameterDroopDataAxis.ResumeLayout(false)
Me.tab_MultiTools.ResumeLayout(false)
Me.Panel.ResumeLayout(false)
Me.GroupBox21.ResumeLayout(false)
Me.Tab_MacManMachiningReport.ResumeLayout(false)
CType(Me.grdMMMachiningReports,System.ComponentModel.ISupportInitialize).EndInit
Me.tab_Chuck.ResumeLayout(false)
Me.tab_tools.ResumeLayout(false)
Me.TabPage2.ResumeLayout(false)
Me.GroupBox5.ResumeLayout(false)
Me.GroupBox4.ResumeLayout(false)
Me.tab_CMDTool.ResumeLayout(false)
Me.GroupBox8.ResumeLayout(false)
Me.GroupBox7.ResumeLayout(false)
Me.Tools2.ResumeLayout(false)
Me.Panel17.ResumeLayout(false)
Me.Tools3.ResumeLayout(false)
Me.Tab_Turret.ResumeLayout(false)
Me.GroupBox10.ResumeLayout(false)
Me.GroupBox9.ResumeLayout(false)
Me.tab_variables.ResumeLayout(false)
Me.GroupBox13.ResumeLayout(false)
Me.tab_TailStock.ResumeLayout(false)
Me.tab_spindle.ResumeLayout(false)
Me.MSpindle.ResumeLayout(false)
Me.tab_OptionalParameter.ResumeLayout(false)
Me.GroupBox12.ResumeLayout(false)
Me.tab_PLC.ResumeLayout(false)
Me.grpIOVariables.ResumeLayout(false)
Me.tab_CurrentAlarm.ResumeLayout(false)
Me.GroupBox20.ResumeLayout(false)
Me.tab_ballscrew.ResumeLayout(false)
Me.tab_MacManAlarmHistory.ResumeLayout(false)
Me.ResumeLayout(false)

    End Sub

#End Region



    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            globalTimer = New System.Windows.Forms.Timer
            globalTimer.Interval = 100

            'init combos
            cboMultiToolSubSystem.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.SubSystemEnum))
            cboMultiToolEdges.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum))

            cboATCToolKind.DataSource = System.Enum.GetValues(GetType(Okuma.CLCMDAPI.Enumerations.SettingToolKindEnum))
            cboATCToolSize.DataSource = System.Enum.GetValues(GetType(Okuma.CLCMDAPI.Enumerations.SettingToolSizeEnum))
            cboATCReturnMagazine.DataSource = System.Enum.GetValues(GetType(Okuma.CLCMDAPI.Enumerations.ReturnMagazineEnum))

            cboATCTurretStation.DataSource = System.Enum.GetValues(GetType(Okuma.CLCMDAPI.Enumerations.TurretStationEnum))
            Dim intStationNo As Integer


            intStationNo = cboATCTurretStation.SelectedValue
            cboCurrentAlarm_SubSystem.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.SubSystemEnum))


            cboGraphMode.DataSource = System.Enum.GetValues(GetType(Okuma.CLCMDAPI.Enumerations.GraphModeEnum))
            cboShiftEnlargeScaleFrame.DataSource = System.Enum.GetValues(GetType(Okuma.CLCMDAPI.Enumerations.EnlargeScaleFrameShiftEnum))
            cboEnlargeScaleFrame.DataSource = System.Enum.GetValues(GetType(Okuma.CLCMDAPI.Enumerations.EnlargeScaleFrameEnum))


            cboZeroShiftAxis.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.AxisIndex4Enum))
            cboAxis2DataUnit.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.DataUnitEnum))
            cboAxis2SubSystem.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.SubSystemEnum))
            cboUserParameterVariableLimitCoordinate.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.UserParameterVariableLimitEnum))
            cboOptionalParameterSubSystem.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.SubSystemEnum))
            cboUserParameterVariableLimitAxis.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.AxisIndex5Enum))
            cboAxis2UserParameterDroopData.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.AxisIndex4Enum))
            cboIOVariableTypes.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.IOTypeEnum))
            cboTurretSides.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.TurretEnum))
            TailStockDiameterCombo.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.TailStockDiameterEnum))
            cmb_Tail_Dataunit.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.DataUnitEnum))

            cboTool3DataUnit.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.DataUnitEnum))
            cboTool3SubSystem.DataSource = System.Enum.GetValues(GetType(Okuma.CLCMDAPI.Enumerations.SubSystemEnum))

            cboTool_Standard_DataUnit.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.DataUnitEnum))
            cboToolsSubSystem.DataSource = System.Enum.GetValues(GetType(Okuma.CLCMDAPI.Enumerations.SubSystemEnum))
            tulUpdLifeStatus.DataSource = System.Enum.GetValues(GetType(ToolLifeStatusEnum))
            cboGaugeStatus.DataSource = System.Enum.GetValues(GetType(ToolGaugeStatusEnum))
            tulComboToolOffset.DataSource = System.Enum.GetValues(GetType(ToolOffsetAxisIndexEnum))
            tulComboToolLife.DataSource = System.Enum.GetValues(GetType(ToolLifeConditionEnum))
            tulComboToolWearOffset.DataSource = System.Enum.GetValues(GetType(NoseRCompensationAxisIndexEnum))
            TulComboNoseRCompensation.DataSource = System.Enum.GetValues(GetType(NoseRCompensationAxisIndexEnum))
            tulComboActualToolLife.DataSource = System.Enum.GetValues(GetType(ToolLifeConditionEnum))
            wkCounterCombo.DataSource = System.Enum.GetValues(GetType(WorkpieceCounterEnum))
            wkZeroOffsetCombo.DataSource = System.Enum.GetValues(GetType(AxisIndex4Enum))
            specCombo.DataSource = System.Enum.GetValues(GetType(OptionSpecEnum))
            mspinSpindleRateOverrideCombo.DataSource = System.Enum.GetValues(GetType(MSpindleEnum))
            mspinSubSystemCombo.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.SubSystemEnum))
            progMCodesCombo.DataSource = System.Enum.GetValues(GetType(MCodesEnum))

            bsDataPointCombo.DataSource = System.Enum.GetValues(GetType(AxisIndex2Enum))
            bsIntervalCombo.DataSource = System.Enum.GetValues(GetType(AxisIndex3Enum))
            spinComboAxis.DataSource = System.Enum.GetValues(GetType(SpindleAxisIndexEnum))
            chuckIndexEnum.DataSource = System.Enum.GetValues(GetType(ChuckIndexEnum))
            chuckHoldCombo.DataSource = System.Enum.GetValues(GetType(ChuckGrippingEnum))
            turBAxisTurretCombo.DataSource = System.Enum.GetValues(GetType(BAxisTurretOffsetPositionEnum))
            turToolOffsetAxisCombo.DataSource = System.Enum.GetValues(GetType(ToolOffsetAxisIndexEnum))
            '        TailStockDiameterCombo.DataSource = System.Enum.GetValues(GetType(TailStockDiameterEnum))
            TailStockLengthCombo.DataSource = System.Enum.GetValues(GetType(TailStockLengthEnum))
            axis1Combo.DataSource = System.Enum.GetValues(GetType(AxisIndex1Enum))
            axis2Combo.DataSource = System.Enum.GetValues(GetType(AxisIndex2Enum))
            axisAllCombo.DataSource = System.Enum.GetValues(GetType(AllAxisIndexEnum))
            toolOffsetAxis1Combo.DataSource = System.Enum.GetValues(GetType(Okuma.CLCMDAPI.Enumerations.OffsetAxisIndexEnum))
            toolOffsetAxis2Combo.DataSource = System.Enum.GetValues(GetType(Okuma.CLCMDAPI.Enumerations.OffsetAxisIndex2Enum))
            Me.toolCuttingPositionsCombo.DataSource = System.Enum.GetValues(GetType(Okuma.CLCMDAPI.Enumerations.CuttingPositionEnum))
            Me.toolSensorDirectionCombo.DataSource = System.Enum.GetValues(GetType(Okuma.CLCMDAPI.Enumerations.SensorDirectionEnum))
            Me.toolSubSystemsCombo.DataSource = System.Enum.GetValues(GetType(Okuma.CLCMDAPI.Enumerations.SubSystemEnum))
            McORSubSystemCombo.DataSource = System.Enum.GetValues(GetType(MacManSubSystemEnum))
            Me.mahAlarmSubSystemCombo.DataSource = System.Enum.GetValues(GetType(MacManSubSystemEnum))

            Me.mohSubSystemCombo.DataSource = System.Enum.GetValues(GetType(MacManSubSystemEnum))

            Me.tul1ComboNoseRComp.DataSource = System.Enum.GetValues(GetType(NoseRCompensationAxisIndexEnum))
            Me.tul1ComboToolOffset.DataSource = System.Enum.GetValues(GetType(ToolOffsetAxisIndexEnum))
            Me.cboToolWearOffsetAxis.DataSource = System.Enum.GetValues(GetType(ToolWearOffsetAxisIndexEnum))
            Me.tul2pa1.DataSource = System.Enum.GetValues(GetType(PrincipalAxisEnum))
            Me.tul2pa2.DataSource = System.Enum.GetValues(GetType(PrincipalAxisEnum))
            Me.tul2pa3.DataSource = System.Enum.GetValues(GetType(PrincipalAxisEnum))
            Me.tul2ba1.DataSource = System.Enum.GetValues(GetType(BAxisCuttingPositionEnum))
            Me.tul2ba2.DataSource = System.Enum.GetValues(GetType(BAxisCuttingPositionEnum))
            Me.tul2ba3.DataSource = System.Enum.GetValues(GetType(BAxisCuttingPositionEnum))
            Me.chuckWorkTypeCombo.DataSource = System.Enum.GetValues(GetType(WorkTypeEnum))
            'indexforhelp

            Me.cmb_Currentsubsystem.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.SubSystemEnum))
            Me.cmb_Currentdataunit.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.DataUnitEnum))
            Me.cmb_BallScrew_SubSystem.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.SubSystemEnum))
            Me.cmb_BallScrew_DataUnit.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.DataUnitEnum))
            Me.cmb_Chuck_SubSys.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.SubSystemEnum))
            Me.cmb_Chuck_Dataunit.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.DataUnitEnum))
            Me.cmb_Machine_SubSys.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.SubSystemEnum))
            Me.cmb_Program_SubSys.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.SubSystemEnum))
            Me.cmb_Spindle_SubSys.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.SubSystemEnum))
            Me.cmb_Tail_SubSys.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.SubSystemEnum))
            Me.cmb_Tool2_SubSys.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.SubSystemEnum))
            Me.cmb_Tool2_DataUnit.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.DataUnitEnum))
            Me.cmb_Turret_subsys.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.SubSystemEnum))
            Me.cmb_Turret_DataUnit.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.DataUnitEnum))
            Me.cmb_Variable_SubSys.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.SubSystemEnum))
            Me.Cmb_NoseRCompensationAxisIndex.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.NoseRCompensationAxisIndexEnum))
            Me.cbo_Ctools2_ToolOffSetAxisIndex.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum))
            Me.cbo_Ctools2_Cutpos.DataSource = System.Enum.GetValues(GetType(Okuma.CLCMDAPI.Enumerations.CuttingPositionEnum))

            '------
            Me.cboMultiToolLifeCondition.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.ToolLifeConditionEnum))
            Me.cboMultiToolHolder.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum))
            Me.cboMultiToolEdges.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum))
            '-------DataZen Added
            Me.cmb_ToolWearOffsetAxisIndex.DataSource = System.Enum.GetValues(GetType(ToolWearOffsetAxisIndexEnum))
            Me.cmb_CuttingPosition.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.CuttingPositionEnum))
            Me.Cmb_rptPeriod.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.ReportPeriodEnum))
            Me.Cmb_ChangeScreen.DataSource = System.Enum.GetValues(GetType(Okuma.ClCMDAPI.Enumerations.PanelGroupEnum))


            ScheduleProgramCycleCompleteCombo.DataSource = System.Enum.GetValues(GetType(MachineSideEnum))
            cboCycleCompleteCombo.DataSource = System.Enum.GetValues(GetType(MachineSideEnum))
            CMB_OPERATINGHISTORY.DataSource = System.Enum.GetValues(GetType(MacManSubSystemEnum))
            Me.cmb_WorkpieceDataunit.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.DataUnitEnum))


            cboWorkpieceSubSystem.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.SubSystemEnum))
            cboMachiningReportSubSystem.DataSource = System.Enum.GetValues(GetType(Okuma.CLDATAPI.Enumerations.MacManSubSystemEnum))





            objMachine = New DataAPI.CMachine("LatheTestApp")


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' It is important to create the DataAPI.CMachine object first and call the Init method to initialize the 
            ' communication with NC, explicitly.
            ' Before exiting the application, it can call objMachine.Close to close the communication with NC.
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            objMachine.Init()

            objAxis = New DataAPI.CAxis
            objAxis2 = New DataAPI.CAxis
            objSpindle = New DataAPI.CSpindle
            objBallScrew = New DataAPI.CBallScrew
            objTool = New DataAPI.CTools
            m_objMultiTool = New DataAPI.CTools

            objVariables = New DataAPI.CVariables
            objWorkpiece = New DataAPI.CWorkpiece
            objSpec = New DataAPI.CSpec
            objMSpindle = New DataAPI.CMSpindle
            objProgram = New DataAPI.CProgram
            objChuck = New DataAPI.CChuck
            objTurret = New DataAPI.CTurret
            objTailStock = New DataAPI.CTailStock
            objATC = New DataAPI.CATC

            objMor = New DataAPI.MacMan.COperatingReport
            objMcAH = New DataAPI.MacMan.CAlarmHistory


            objMopnh = New DataAPI.MacMan.COperatingHistory
            objMcOH = New DataAPI.MacMan.COperationHistory

            objOptionalParameter = New Okuma.CLDATAPI.DataAPI.COptionalParameter

            objIO = New Okuma.CLDATAPI.DataAPI.CIO



            objCMDTool = New CommandAPI.CTools
            objCMDMachine = New CommandAPI.CMachine
            objCMDProgram = New CommandAPI.CProgram
            objCMDSpec = New CommandAPI.CSpec
            objSimulation = New CommandAPI.CSimulation
            m_objCmdATC = New CommandAPI.CATC

            objMeh = New Okuma.CLDATAPI.DataAPI.MacMan.CMachiningReport



            ' Add sample application version to form caption 
            Dim objVersion As System.Version
            Dim strVersion As String

            objVersion = [Assembly].GetExecutingAssembly.GetName().Version

            strVersion = String.Format("{0}.{1}.{2}.{3}", objVersion.Major.ToString, objVersion.Minor.ToString, objVersion.Build.ToString, objVersion.Revision.ToString)
            Me.Text = String.Format("{0} - {1}", "THINC Lathe Sample Application", strVersion)


            Exit Sub

        Catch ex As Exception
            Dim objForm As frmMessage
            Dim strLabelMessage As String
            Dim strTextMessage As String


            Dim strVersion As String
            Dim objVersion As System.Version

            objVersion = [Assembly].GetExecutingAssembly.GetName().Version

            strVersion = String.Format("{0}.{1}.{2}.{3}", objVersion.Major.ToString, objVersion.Minor.ToString, objVersion.Build.ToString, objVersion.Revision.ToString)


            strLabelMessage = String.Format("{0}{1}", "Please contact OKUMA Software department to resolve problem.", ControlChars.CrLf + ControlChars.CrLf)
            strLabelMessage = strLabelMessage + String.Format("Please send the entire error message to api@okuma.com for futher investigate.")

            strTextMessage = String.Format("THINC Lathe Sample Application version {0}.{1}{2}", strVersion, ControlChars.CrLf + ControlChars.CrLf, ex.Message)
            objForm = New frmMessage(strLabelMessage, strTextMessage, MessageBoxIcon.Stop)
            objForm.ShowDialog()
            Application.Exit()
        End Try

    End Sub

    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        objMachine.Close()
    End Sub
    Private Sub DisplayError(ByVal moduleName As String, ByVal errMsg As String)
        Me.ErrorLog.Text = Now() & " - " & moduleName & ": " & errMsg & vbCrLf & Me.ErrorLog.Text

    End Sub

    Private Sub clearLogButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCurrentAlarmNumber.Click
        Me.ErrorLog.Text = ""
    End Sub

#Region "Axis Tab"


    Private Sub UpdateMcAlarmHistory()
        On Error GoTo sd
        Dim alarmIndex As Int16
        Dim mahAlarmObj As DataAPI.MacMan.CAlarm
        alarmIndex = CInt(Me.mahAlarmIndex.Text)
        mahAlarmObj = objMcAH.GetAlarm(alarmIndex)

        Me.mahAlarmCode.Text = mahAlarmObj.Code
        Me.mahAlarmCount.Text = objMcAH.GetCount
        Me.mahAlarmDate.Text = mahAlarmObj.Date
        Me.mahAlarmMessage.Text = mahAlarmObj.Message
        Me.mahAlarmNumber.Text = mahAlarmObj.Number
        Me.mahAlarmTime.Text = mahAlarmObj.Time
        Me.mahMaxAlarmCount.Text = objMcAH.GetMaxCount

        Me.mahAlarmObject.Text = mahAlarmObj.Object

        Exit Sub

sd:

        DisplayError("MacMan Alarm History", Err.Description)
        Resume Next
    End Sub
    Public Sub Update_Chuck()
        On Error GoTo sd

        objChuck.SetSubSystem(cmb_Chuck_SubSys.SelectedItem)
        objChuck.SetDataUnit(cmb_Chuck_Dataunit.SelectedItem)

        Me.chuckGrippingDiameter.Text = objChuck.GetGrippingDiameter(Me.chuckIndexEnum.SelectedValue)
        Me.chuckGrippingFaceToDistance.Text = objChuck.GetGrippingFaceToProgramZeroDistance(Me.chuckIndexEnum.SelectedValue)
        Me.chuckGrippingFaceWidth.Text = objChuck.GetGrippingFaceWidth(Me.chuckIndexEnum.SelectedValue)
        Me.chuckGrippingLength.Text = objChuck.GetGrippingLength(Me.chuckIndexEnum.SelectedValue)
        Me.chuckJawLength.Text = objChuck.GetJawLength(Me.chuckIndexEnum.SelectedValue)
        Me.chuckJawSize.Text = objChuck.GetJawSize(Me.chuckIndexEnum.SelectedValue)
        Me.chuckSecondChuckZeroOffset.Text = objChuck.GetSecondChuckZeroOffset()

        Me.chuckHold.Text = System.Enum.GetNames(GetType(ChuckGrippingEnum)).GetValue(objChuck.GetChuckHold(Me.chuckIndexEnum.SelectedValue))

        Me.chuckWorkType.Text = System.Enum.GetNames(GetType(WorkTypeEnum)).GetValue(objChuck.GetWorkType)




        Exit Sub

sd:

        DisplayError("Chuck", Err.Description)
        Resume Next
    End Sub

    Private Sub Update_Axis()
        On Error GoTo sd

        'Try
        Dim curAxisEnum1 As AxisIndex1Enum
        Dim curAxisEnum2 As AxisIndex2Enum
        Dim curAxisEnumAll As AllAxisIndexEnum

        objAxis.SetSubSystem(cmb_Currentsubsystem.SelectedItem)
        objAxis.SetDataUnit(cmb_Currentdataunit.SelectedItem)

        curAxisEnum1 = Me.axis1Combo.SelectedValue
        curAxisEnum2 = Me.axis2Combo.SelectedValue
        curAxisEnumAll = Me.axisAllCombo.SelectedValue


        Me.AxisActualFeedrate.Text = objAxis.GetActualFeedrate

        Me.AxiscommandFeedRate.Text = objAxis.GetCommandFeedrate
        Me.AxisfeedHold.Text = objAxis.GetFeedHold
        Me.AxisfeedrateOverride.Text = objAxis.GetFeedrateOverride
        Me.AxismaxFeedrateOverride.Text = objAxis.GetMaxFeedrateOverride

        lbl_FeedRate.Text = System.Enum.GetNames(GetType(FeedrateTypeEnum)).GetValue(objAxis.GetFeedrateType())


        Me.axisName.Text = objAxis.GetAxisName(curAxisEnumAll)
        Me.txtAxisType.Text = System.Enum.GetNames(GetType(AxisTypeEnum)).GetValue(objAxis.GetAxisType(curAxisEnumAll))


        Me.AxisAPMachineCoord.Text = objAxis.GetActualPositionMachineCoord(curAxisEnum1)
        Me.AxisAPProgramCoord.Text = objAxis.GetActualPositionProgramCoord(curAxisEnum1)
        Me.AxisdistanceTarget.Text = objAxis.GetDistanceToTargetPosition(curAxisEnum1)
        Me.AxistargetPosition.Text = objAxis.GetTargetPosition(curAxisEnum1)


        Me.AxisAPEncoderCoord.Text = objAxis.GetActualPositionEncoderCoord(curAxisEnum2)
        Me.axisLoad.Text = objAxis.GetAxisLoad(curAxisEnum2)


        Me.AxisBAxisLoad.Text = objAxis.GetBAxisLoad


        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        '    MsgBox(ex.StackTrace)
        'End Try


        Exit Sub
sd:
        DisplayError("CAxis", Err.Description)
        Resume Next

    End Sub

    Private Sub axisTimerStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles axisTimerStart.Click
        globalTimer.Enabled = True
    End Sub

    Private Sub AxisTimerStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AxisTimerStop.Click
        globalTimer.Enabled = False
    End Sub

    Private Sub globalTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles globalTimer.Tick
        Update_Axis()
    End Sub
#End Region

    Private Sub spinUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spinUpdate.Click
        Try
            objSpindle.SetSubSystem(cmb_Spindle_SubSys.SelectedItem)


            Me.spinActualRate.Text = objSpindle.GetActualSpindlerate
            Me.spinCommandRate.Text = objSpindle.GetCommandSpindlerate
            Me.spinLoad.Text = objSpindle.GetSpindleLoad
            Me.spinSpindleMode.Text = objSpindle.GetSpindleMode
            Me.spinState.Text = System.Enum.GetNames(GetType(SpindleStateEnum)).GetValue(objSpindle.GetSpindleState)
            Me.spinSpindleSurfaceSpeed.Text = objSpindle.GetSpindleSurfaceSpeed
            Me.spinRateOverride.Text = objSpindle.GetSpindlerateOverride(Me.spinComboAxis.SelectedValue)
            Me.MaxSpindleRateOverride.Text = objSpindle.GetMaxSpindlerateOverride

        Catch ae As ApplicationException
            DisplayError("CSpindle", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CSpindle", ex.Message)
        End Try

    End Sub



    Private Sub varUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles varUpdateButton.Click

        Try
            objVariables.SetSubSystem(cmb_Variable_SubSys.SelectedItem)


            Me.varValue.Text = objVariables.GetCommonVariableValue(CInt(Me.varCommonVarNumber.Text))
            Me.varNumberOfVars.Text = objVariables.GetCommonVariableCount

        Catch ae As ApplicationException
            DisplayError("CVariable", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CVariable", ex.Message)
        End Try
    End Sub

    Private Sub varSetValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles varSetValue.Click
        Try
            objVariables.SetCommonVariableValue(CInt(Me.varCommonVarNumber.Text), CDbl(Me.varValueUpdate.Text))
            Me.varValue.Text = objVariables.GetCommonVariableValue(CInt(Me.varCommonVarNumber.Text))

        Catch ae As ApplicationException
            DisplayError("CVariable", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CVariable", ex.Message)
        End Try
    End Sub

    Private Sub varAddValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles varAddValue.Click
        Try
            objVariables.AddCommonVariableValue(CInt(Me.varCommonVarNumber.Text), CDbl(Me.varValueUpdate.Text))
            Me.varValue.Text = objVariables.GetCommonVariableValue(CInt(Me.varCommonVarNumber.Text))

        Catch ae As ApplicationException
            DisplayError("CVariable", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CVariable", ex.Message)
        End Try
    End Sub

    Private Sub varGetAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles varGetAllButton.Click
        Dim varRes As Double()
        Dim curRes As Double
        Dim intIndex As Integer


        Try
            Me.varGetAllResults.Text = ""

            intIndex = CInt(Me.varBegin.Text)

            varRes = objVariables.GetCommonVariableValues(CInt(Me.varBegin.Text), CInt(Me.varEnd.Text))

            For Each curRes In varRes
                Me.varGetAllResults.Text += intIndex.ToString & vbTab & curRes & vbCrLf
                intIndex = intIndex + 1
            Next


        Catch ae As ApplicationException
            DisplayError("CVariable", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CVariable", ex.Message)
        End Try
    End Sub



    Private Sub tulSetReferenceToolOffset2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetReferenceToolOffset2.Click
        Try
            objTool.SetReferenceToolOffset2(CInt(Me.tulToolNumber.Text), CInt(Me.tulUpdReferenceToolOffset2.Text))
            Updatetools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetReferenceToolOffset3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetReferenceToolOffset3.Click
        Try
            objTool.SetReferenceToolOffset3(CInt(Me.tulToolNumber.Text), CInt(Me.tulUpdReferenceToolOffset3.Text))
            Updatetools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub



    Private Sub tulSetToolLife_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolLife.Click
        Try
            objTool.SetToolLife(Me.tulComboToolLife.SelectedValue, CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdToolLife.Text))
            Updatetools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub


    Private Sub tulSetGauseStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetGauseStatus.Click
        Try
            objTool.SetGaugeStatus(CInt(Me.tulToolNumber.Text), Me.cboGaugeStatus.SelectedValue)
            Updatetools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetToolNumberInGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolNumberInGroup.Click
        Try
            objTool.SetToolNumberInGroup(CInt(Me.tulUpdToolNumberInGroup.Text), CInt(Me.tulToolNumber.Text))
            Updatetools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetToolOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolOffset.Click
        Try
            objTool.SetToolOffset(CInt(Me.tulToolNumber.Text), Me.tulComboToolOffset.SelectedValue, CDbl(Me.tulUpdToolOffset.Text))
            Updatetools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetGroupNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetGroupNumber.Click
        Try
            objTool.SetGroupNo(CInt(Me.tulToolNumber.Text), CInt(Me.tulUpdGroupNumber.Text))
            Updatetools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub


    Private Sub tulSetToolWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolWearOffset.Click
        Try
            objTool.SetToolWearOffset(CInt(tulToolNumber.Text), Me.tulComboToolWearOffset.SelectedValue, CDbl(tulUpdToolWearOffset.Text))
            Updatetools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub



    Private Sub TulSetNoseRCompensation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TulSetNoseRCompensation.Click
        Try
            objTool.SetNoseRCompensation(CInt(Me.tulToolNumber.Text), Me.TulComboNoseRCompensation.SelectedValue, CDbl(Me.TulUpdNoseRCompensation.Text))
            Updatetools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub TulSetNoseRCompensationPattern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TulSetNoseRCompensationPattern.Click
        Try
            objTool.SetNoseRCompensationPattern(CInt(Me.tulToolNumber.Text), CInt(Me.TulUpdNoseRCompensationPattern.Text))
            Updatetools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetActualToolLife_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetActualToolLife.Click
        Try
            objTool.SetActualToolLife(Me.tulComboActualToolLife.SelectedValue, CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdActualToolLife.Text))
            Updatetools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetReferenceToolOffset1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetReferenceToolOffset1.Click
        Try
            objTool.SetReferenceToolOffset1(CInt(Me.tulToolNumber.Text), CInt(Me.tulUpdReferenceToolOffset1.Text))
            Updatetools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulAddToolOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulAddToolOffset.Click
        Try
            objTool.AddToolOffset(CInt(Me.tulToolNumber.Text), Me.tulComboToolOffset.SelectedValue, CDbl(Me.tulUpdToolOffset.Text))
            Updatetools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulAddToolWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulAddToolWearOffset.Click
        Try
            objTool.AddToolWearOffset(CInt(Me.tulToolNumber.Text), Me.tulComboToolWearOffset.SelectedValue, CDbl(Me.tulUpdToolWearOffset.Text))
            Updatetools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub TulAddNoseRCompensation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TulAddNoseRCompensation.Click
        Try
            objTool.AddNoseRCompensation(CInt(Me.tulToolNumber.Text), Me.TulComboNoseRCompensation.SelectedValue, CDbl(Me.TulUpdNoseRCompensation.Text))
            Updatetools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

#Region "Workpiece"
    Private Sub cmd_addWorkpiece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_addWorkpiece.Click
        Try
            objWorkpiece.AddWorkpieceCounter(Me.wkCounterCombo.SelectedValue, CInt(Me.wkUpdateCounter.Text))

        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub


    Private Sub wkUpdateValsWithNoParams_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkUpdateValsWithNoParams.Click
        Try
            objWorkpiece.SetSubSystem(cboWorkpieceSubSystem.SelectedItem)
            objWorkpiece.SetDataUnit(cmb_WorkpieceDataunit.SelectedItem)


        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try


    End Sub

    Private Sub wkGetCounterValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkGetCounterValue.Click
        Try
            Dim cnt As Int32
            cnt = objWorkpiece.GetWorkpieceCounter(wkCounterCombo.SelectedValue)
            Me.wkCounterValue.Text = cnt
        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub

    Private Sub wkSetCounterValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkSetCounterValue.Click
        Try
            objWorkpiece.SetWorkpieceCounter(Me.wkCounterCombo.SelectedValue, CInt(Me.wkUpdateCounter.Text))

        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub

    Private Sub wkSetZeroOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkSetZeroOffset.Click
        Try

            objWorkpiece.SetZeroOffset(Me.wkZeroOffsetCombo.SelectedValue, CDbl(Me.wkUpdateZeroOffset.Text))
            Me.wkZeroOffset.Text = objWorkpiece.GetZeroOffset(wkZeroOffsetCombo.SelectedValue)

        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub

    Private Sub wkGetZeroOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkGetZeroOffset.Click
        Try
            Me.wkZeroOffset.Text = objWorkpiece.GetZeroOffset(wkZeroOffsetCombo.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub

    Private Sub wkAddZeroOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkAddZeroOffset.Click
        Try
            objWorkpiece.AddZeroOffset(Me.wkZeroOffsetCombo.SelectedValue, CDbl(Me.wkUpdateZeroOffset.Text))
            Me.wkZeroOffset.Text = objWorkpiece.GetZeroOffset(wkZeroOffsetCombo.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub

    Private Sub wkCalZeroOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkCalZeroOffset.Click
        Try
            objWorkpiece.CalZeroOffset(Me.wkZeroOffsetCombo.SelectedValue, CDbl(Me.wkUpdateZeroOffset.Text))
            Me.wkZeroOffset.Text = objWorkpiece.GetZeroOffset(wkZeroOffsetCombo.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub


    Private Sub cmdGetZeroShift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetZeroShift.Click
        Try
            Me.txtZeroShift.Text = objWorkpiece.GetZeroShift(Me.cboZeroShiftAxis.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub

    Private Sub cmdSetZeroShift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetZeroShift.Click
        Try
            objWorkpiece.SetZeroShift(Me.cboZeroShiftAxis.SelectedValue, CDbl(Me.txtZeroShiftInput.Text))
        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub

    Private Sub cmdAddZeroShift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddZeroShift.Click
        Try
            objWorkpiece.AddZeroShift(Me.cboZeroShiftAxis.SelectedValue, CDbl(Me.txtZeroShiftInput.Text))
        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub

    Private Sub cmdCalZeroShift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalZeroShift.Click
        Try
            objWorkpiece.CalZeroShift(Me.cboZeroShiftAxis.SelectedValue, CDbl(Me.txtZeroShiftInput.Text))
        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub

#End Region






    Private Sub varGetValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles varGetValue.Click

        Try


            Me.varValue.Text = objVariables.GetCommonVariableValue(CInt(Me.varCommonVarNumber.Text))

        Catch ae As ApplicationException
            DisplayError("CVariable", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CVariable", ex.Message)
        End Try
    End Sub

    Private Sub tulSetLifeStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetLifeStatus.Click
        Try

            objTool.SetLifeStatus(CInt(Me.tulToolNumber.Text), Me.tulUpdLifeStatus.SelectedValue)         ', Me.tulUpdToolStatus.Text)
            Updatetools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub





    Private Sub ballscrewUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ballscrewUpdateButton.Click
        ballscrewUpdate()
    End Sub



    Private Sub bsDataPointSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsDataPointSet.Click
        Dim curAxisEnum As AxisIndex2Enum
        Try

            curAxisEnum = Me.bsDataPointCombo.SelectedValue
            objBallScrew.SetDataPoint(CInt(Me.bsPecPoint.Text), curAxisEnum, CDbl(Me.bsDataPointUpdate.Text))
            Me.bsDataPoint.Text = objBallScrew.GetDataPoint(CInt(Me.bsPecPoint.Text), curAxisEnum)
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub

    Private Sub bsIntervalSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsIntervalSet.Click
        Try

            objBallScrew.SetInterval(Me.bsIntervalCombo.SelectedValue, CDbl(Me.bsIntervalUpdate.Text))
            'objBallScrew.SetInterval(Me.txt_intvalue.Text)
            Me.bsInterval.Text = objBallScrew.GetInterval(Me.bsIntervalCombo.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub


    Private Sub bsDataPointAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsDataPointAdd.Click
        'Dim curAxisEnum As AxisIndexEnum
        Try
            'curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)
            objBallScrew.AddDataPoint(CInt(Me.bsPecPoint.Text), Me.bsDataPointCombo.SelectedValue, CDbl(Me.bsDataPointUpdate.Text))
            Me.bsDataPoint.Text = objBallScrew.GetDataPoint(CInt(Me.bsPecPoint.Text), Me.bsDataPointCombo.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub

    Private Sub bsIntervalAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsIntervalAdd.Click
        Try

            objBallScrew.AddInterval(Me.bsIntervalCombo.SelectedValue, CDbl(Me.bsIntervalUpdate.Text))
            Me.bsInterval.Text = objBallScrew.GetInterval(Me.bsIntervalCombo.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub


    Private Sub bsBAxisStartPositionSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsBAxisStartPositionSet.Click

        Try

            objBallScrew.SetBAxisStartPosition(CDbl(Me.bsBAxisStartPositionUpdate.Text))
            ballscrewUpdate()
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub

    Private Sub bsBAxisStartPositionAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bsBAxisStartPositionAdd.Click

        Try

            objBallScrew.AddBAxisStartPosition(CDbl(Me.bsBAxisStartPositionUpdate.Text))
            ballscrewUpdate()
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub

    Private Sub bsBAxisDataPointSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsBAxisDataPointSet.Click

        Try

            objBallScrew.SetBAxisDataPoint(CInt(Me.bsPecPoint.Text), CDbl(Me.bsBAxisDataPointUpdate.Text))
            ballscrewUpdate()
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub

    Private Sub bsBAxisDataPointAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bsBAxisDataPointAdd.Click
        Try

            objBallScrew.AddBAxisDataPoint(CInt(Me.bsPecPoint.Text), CDbl(Me.bsBAxisDataPointUpdate.Text))
            ballscrewUpdate()
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub

    Private Sub bsBAxisIntervalSet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bsBAxisIntervalSet.Click
        Try

            objBallScrew.SetBAxisInterval(CDbl(Me.bsBAxisIntervalUpdate.Text))
            ballscrewUpdate()
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub

    Private Sub bsBAxisIntervalAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bsBAxisIntervalAdd.Click
        Try

            objBallScrew.AddBAxisInterval(CDbl(Me.bsBAxisIntervalUpdate.Text))
            ballscrewUpdate()
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub




    Private Sub chuckGrippingDiameterSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chuckGrippingDiameterSet.Click

        Try

            objChuck.SetGrippingDiameter(Me.chuckIndexEnum.SelectedValue, CDbl(Me.chuckGrippingDiameterUpd.Text))
            Update_Chuck()
        Catch ae As ApplicationException
            DisplayError("CChuck", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CChuck", ex.Message)
        End Try
    End Sub

    Private Sub chuckGrippingFaceToDistanceSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chuckGrippingFaceToDistanceSet.Click

        Try

            objChuck.SetGrippingFaceToProgramZeroDistance(Me.chuckIndexEnum.SelectedValue, CDbl(Me.chuckGrippingFaceToDistanceUpd.Text))
            Update_Chuck()
        Catch ae As ApplicationException
            DisplayError("CChuck", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CChuck", ex.Message)
        End Try
    End Sub

    Private Sub chuckGrippingFaceWidthSet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chuckGrippingFaceWidthSet.Click
        Try

            objChuck.SetGrippingFaceWidth(Me.chuckIndexEnum.SelectedValue, CDbl(Me.chuckGrippingFaceWidthUpd.Text))
            Update_Chuck()
        Catch ae As ApplicationException
            DisplayError("CChuck", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CChuck", ex.Message)
        End Try
    End Sub

    Private Sub chuckGrippingLengthSet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chuckGrippingLengthSet.Click
        Try

            objChuck.SetGrippingLength(Me.chuckIndexEnum.SelectedValue, CDbl(Me.chuckGrippingLengthUpd.Text))
            Update_Chuck()
        Catch ae As ApplicationException
            DisplayError("CChuck", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CChuck", ex.Message)
        End Try
    End Sub

    Private Sub chuckJawLengthSet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chuckJawLengthSet.Click
        Try

            objChuck.SetJawLength(Me.chuckIndexEnum.SelectedValue, CDbl(Me.chuckJawLengthUpd.Text))
            Update_Chuck()
        Catch ae As ApplicationException
            DisplayError("CChuck", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CChuck", ex.Message)
        End Try
    End Sub

    Private Sub chuckJawSizeSet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chuckJawSizeSet.Click
        Try

            objChuck.SetJawSize(Me.chuckIndexEnum.SelectedValue, CDbl(Me.chuckJawSizeUpd.Text))
            Update_Chuck()
        Catch ae As ApplicationException
            DisplayError("CChuck", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CChuck", ex.Message)
        End Try
    End Sub

    Private Sub chuckSecondChuckZeroOffsetSet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chuckSecondChuckZeroOffsetSet.Click
        Try

            objChuck.SetSecondChuckZeroOffset(CDbl(Me.chuckSecondChuckZeroOffsetUpd.Text))
            Update_Chuck()
        Catch ae As ApplicationException
            DisplayError("CChuck", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CChuck", ex.Message)
        End Try
    End Sub

    Private Sub chuckUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chuckUpdateButton.Click
        Update_Chuck()
    End Sub


    Private Sub chuckHoldSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chuckHoldSet.Click
        Try

            objChuck.SetChuckHold(Me.chuckIndexEnum.SelectedValue, Me.chuckHoldCombo.SelectedValue)
            Update_Chuck()
        Catch ae As ApplicationException
            DisplayError("CChuck", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CChuck", ex.Message)
        End Try
    End Sub

    Private Sub chuckGrippingDiameterAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chuckGrippingDiameterAdd.Click

        Try

            objChuck.AddGrippingDiameter(Me.chuckIndexEnum.SelectedValue, CDbl(Me.chuckGrippingDiameterUpd.Text))
            Update_Chuck()
        Catch ae As ApplicationException
            DisplayError("CChuck", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CChuck", ex.Message)
        End Try
    End Sub

    Private Sub chuckGrippingFaceToDistanceAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chuckGrippingFaceToDistanceAdd.Click

        Try

            objChuck.AddGrippingFaceToProgramZeroDistance(Me.chuckIndexEnum.SelectedValue, CDbl(Me.chuckGrippingFaceToDistanceUpd.Text))
            Update_Chuck()
        Catch ae As ApplicationException
            DisplayError("CChuck", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CChuck", ex.Message)
        End Try
    End Sub

    Private Sub chuckGrippingFaceWidthAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chuckGrippingFaceWidthAdd.Click
        Try

            objChuck.AddGrippingFaceWidth(Me.chuckIndexEnum.SelectedValue, CDbl(Me.chuckGrippingFaceWidthUpd.Text))
            Update_Chuck()
        Catch ae As ApplicationException
            DisplayError("CChuck", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CChuck", ex.Message)
        End Try
    End Sub

    Private Sub chuckGrippingLengthAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chuckGrippingLengthAdd.Click
        Try

            objChuck.AddGrippingLength(Me.chuckIndexEnum.SelectedValue, CDbl(Me.chuckGrippingLengthUpd.Text))
            Update_Chuck()
        Catch ae As ApplicationException
            DisplayError("CChuck", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CChuck", ex.Message)
        End Try
    End Sub

    Private Sub chuckJawLengthAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chuckJawLengthAdd.Click
        Try

            objChuck.AddJawLength(Me.chuckIndexEnum.SelectedValue, CDbl(Me.chuckJawLengthUpd.Text))
            Update_Chuck()
        Catch ae As ApplicationException
            DisplayError("CChuck", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CChuck", ex.Message)
        End Try
    End Sub

    Private Sub chuckJawSizeAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chuckJawSizeAdd.Click
        Try

            objChuck.AddJawSize(Me.chuckIndexEnum.SelectedValue, CDbl(Me.chuckJawSizeUpd.Text))
            Update_Chuck()
        Catch ae As ApplicationException
            DisplayError("CChuck", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CChuck", ex.Message)
        End Try
    End Sub

    Private Sub chuckSecondChuckZeroOffsetAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chuckSecondChuckZeroOffsetAdd.Click
        Try

            objChuck.AddSecondChuckZeroOffset(CDbl(Me.chuckSecondChuckZeroOffsetUpd.Text))
            Update_Chuck()
        Catch ae As ApplicationException
            DisplayError("CChuck", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CChuck", ex.Message)
        End Try
    End Sub

    Private Sub chuckGrippingDiameterCal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chuckGrippingDiameterCal.Click

        Try

            objChuck.CalGrippingDiameter(Me.chuckIndexEnum.SelectedValue, CDbl(Me.chuckGrippingDiameterUpd.Text))
            Update_Chuck()
        Catch ae As ApplicationException
            DisplayError("CChuck", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CChuck", ex.Message)
        End Try
    End Sub

    Private Sub chuckGrippingFaceToDistanceCal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chuckGrippingFaceToDistanceCal.Click

        Try

            objChuck.CalGrippingFaceToProgramZeroDistance(Me.chuckIndexEnum.SelectedValue, CDbl(Me.chuckGrippingFaceToDistanceUpd.Text))
            Update_Chuck()
        Catch ae As ApplicationException
            DisplayError("CChuck", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CChuck", ex.Message)
        End Try
    End Sub

    Private Sub turBAxisTurretOffsetSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles turBAxisTurretOffsetSet.Click
        Try

            objTurret.SetBAxisTurretOffset(CInt(Me.turToolNo.Text), Me.turToolOffsetAxisCombo.SelectedValue, Me.turBAxisTurretCombo.SelectedValue, CDbl(Me.turBAxisTurretOffsetUpd.Text))

            Update_Turret()
        Catch ae As ApplicationException
            DisplayError("CTurret", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTurret", ex.Message)
        End Try
    End Sub

    Private Sub turBAxisTurretOffsetAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles turBAxisTurretOffsetAdd.Click
        Try

            objTurret.AddBAxisTurretOffset(CInt(Me.turToolNo.Text), Me.turToolOffsetAxisCombo.SelectedValue, Me.turBAxisTurretCombo.SelectedValue, CDbl(Me.turBAxisTurretOffsetUpd.Text))

            Update_Turret()
        Catch ae As ApplicationException
            DisplayError("CTurret", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTurret", ex.Message)
        End Try
    End Sub

    Private Sub turTurretOffsetSet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles turTurretOffsetSet.Click
        Try

            objTurret.SetTurretOffset(CInt(Me.turToolNo.Text), Me.turToolOffsetAxisCombo.SelectedValue, CDbl(Me.turTurretOffsetUpd.Text))

            Update_Turret()
        Catch ae As ApplicationException
            DisplayError("CTurret", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTurret", ex.Message)
        End Try
    End Sub

    Private Sub turTurretOffsetAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles turTurretOffsetAdd.Click
        Try

            objTurret.AddTurretOffset(CInt(Me.turToolNo.Text), Me.turToolOffsetAxisCombo.SelectedValue, CDbl(Me.turTurretOffsetUpd.Text))

            Update_Turret()
        Catch ae As ApplicationException
            DisplayError("CTurret", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTurret", ex.Message)
        End Try
    End Sub

    Private Sub turUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles turUpdate.Click
        Update_Turret()
    End Sub

    Private Sub mspinUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mspinUpdate.Click
        Update_MSpindle()
    End Sub

    Private Sub TailStockDiameterSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TailStockDiameterSet.Click
        Try
            objTailStock.SetDiameter(Me.TailStockDiameterCombo.SelectedValue, CDbl(Me.TailStockDiameterUpd.Text))
            Update_TailStock()
        Catch ae As ApplicationException
            DisplayError("CTailStock", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTailStock", ex.Message)
        End Try
    End Sub

    Private Sub TailStockDiameterAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TailStockDiameterAdd.Click
        Try
            objTailStock.AddDiameter(Me.TailStockDiameterCombo.SelectedValue, CDbl(Me.TailStockDiameterUpd.Text))
            Update_TailStock()
        Catch ae As ApplicationException
            DisplayError("CTailStock", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTailStock", ex.Message)
        End Try
    End Sub

    Private Sub TailStockLengthAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TailStockLengthAdd.Click
        Try
            objTailStock.AddLength(Me.TailStockLengthCombo.SelectedValue, CDbl(Me.TailStockLengthUpd.Text))
            Update_TailStock()
        Catch ae As ApplicationException
            DisplayError("CTailStock", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTailStock", ex.Message)
        End Try
    End Sub

    Private Sub TailStockLengthSet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TailStockLengthSet.Click
        Try
            objTailStock.SetLength(Me.TailStockLengthCombo.SelectedValue, CDbl(Me.TailStockLengthUpd.Text))
            Update_TailStock()
        Catch ae As ApplicationException
            DisplayError("CTailStock", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTailStock", ex.Message)
        End Try
    End Sub

    Private Sub tailstockUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tailstockUpdate.Click
        Update_TailStock()
    End Sub


#Region "Machine"
    Private Sub macMDIExecButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles macMDIExecButton.Click

        Try
            objCMDMachine.InputMDI(Me.macMDICommand.Text)

        Catch ae As ApplicationException
            DisplayError("Command CMachine.InputMDI", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("Command CMachine.InputMDI", ex.Message)
        End Try

    End Sub
    Private Sub machineUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles machineUpdateButton.Click


        Dim strMachine As String

        Try


            objMachine.SetSubSystem(cmb_Machine_SubSys.SelectedItem)

            txtMachine.Text = ""
            strMachine = strMachine & "Execution Mode: " & System.Enum.GetName(GetType(ExecutionModeEnum), objMachine.GetExecutionMode) & vbCrLf
            strMachine = strMachine & "Operation Mode: " & System.Enum.GetName(GetType(OperationModeEnum), objMachine.GetOperationMode) & vbCrLf
            strMachine = strMachine & "Panel Mode: " & System.Enum.GetName(GetType(PanelModeEnum), objMachine.GetPanelMode) & vbCrLf
            strMachine = strMachine & "Display Unit System : " & objMachine.GetOperationUnitSystemDisplay() & vbCrLf

            strMachine = strMachine & "NC Alarm Status Light: " & System.Enum.GetName(GetType(OnOffStateEnum), objMachine.GetNCStatus(NCStatusEnum.Alarm)) & vbCrLf
            strMachine = strMachine & "NC STM Status Light: " & System.Enum.GetName(GetType(OnOffStateEnum), objMachine.GetNCStatus(NCStatusEnum.STM)) & vbCrLf
            strMachine = strMachine & "NC LIMIT Status Light: " & System.Enum.GetName(GetType(OnOffStateEnum), objMachine.GetNCStatus(NCStatusEnum.Limit)) & vbCrLf
            strMachine = strMachine & "NC PROGRAM STOP Status Light: " & System.Enum.GetName(GetType(OnOffStateEnum), objMachine.GetNCStatus(NCStatusEnum.ProgramStop)) & vbCrLf
            strMachine = strMachine & "NC SLIDE HOLD Status Light: " & System.Enum.GetName(GetType(OnOffStateEnum), objMachine.GetNCStatus(NCStatusEnum.SlideHold)) & vbCrLf

            txtMachine.Text = strMachine

        Catch ae As ApplicationException
            DisplayError("machineUpdateButton_Click", ae.Message)
        Catch ex As Exception
            DisplayError("machineUpdateButton_Click", ex.Message)
        End Try
    End Sub
#End Region


    Private Sub mspinSetSubSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mspinSetSubSystem.Click

        Try
            objMSpindle.SetSubSystem(mspinSubSystemCombo.SelectedItem)

        Catch ae As ApplicationException
            DisplayError("CMSpindle", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMSpindle", ex.Message)
        End Try

    End Sub




    Private Sub toolAddMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAddMethod.Click
        Try
            objCMDTool.AddConstantNoseRadiusCompensation(CInt(Me.toolToolNo.Text), Me.toolOffsetAxis2Combo.SelectedValue, Me.toolSubSystemsCombo.SelectedValue)

        Catch ae As ApplicationException
            DisplayError("CMDTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMDTool", ex.Message)
        End Try
    End Sub

    Private Sub toolSubtractMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubNoseR.Click
        Try
            objCMDTool.SubtractConstantNoseRadiusCompensation(CInt(Me.toolToolNo.Text), Me.toolOffsetAxis2Combo.SelectedValue, Me.toolSubSystemsCombo.SelectedValue)

        Catch ae As ApplicationException
            DisplayError("CMDTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMDTool", ex.Message)
        End Try
    End Sub

    Private Sub toolAutoCalToolOffsetExe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAutoCalToolOffsetExe.Click
        Try
            objCMDTool.AutoCalculateToolOffset(CInt(Me.toolToolNo.Text), Me.toolOffsetAxis2Combo.SelectedValue, Me.toolSubSystemsCombo.SelectedValue)

        Catch ae As ApplicationException
            DisplayError("CMDTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMDTool", ex.Message)
        End Try

    End Sub


    Private Sub toolCalToolOffsetExe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolCalToolOffsetExe.Click
        Try
            objCMDTool.CalculateToolOffset(CInt(Me.toolToolNo.Text), Me.toolOffsetAxis1Combo.SelectedValue, Me.toolSubSystemsCombo.SelectedValue, CDbl(Me.toolCalToolOffset.Text))

        Catch ae As ApplicationException
            DisplayError("CMDTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMDTool", ex.Message)
        End Try
    End Sub

    Private Sub toolMeasureCalToolOffsetExe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolMeasureCalToolOffsetExe.Click
        Try
            objCMDTool.MeasureCalculateToolOffset(CInt(Me.toolToolNo.Text), Me.toolOffsetAxis2Combo.SelectedValue, Me.toolSensorDirectionCombo.SelectedValue, Me.toolSubSystemsCombo.SelectedValue)

        Catch ae As ApplicationException
            DisplayError("CMDTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMDTool", ex.Message)
        End Try
    End Sub





    Private Sub mahUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mahUpdateButton.Click
        UpdateMcAlarmHistory()
    End Sub

    Private Sub mahAlarmSubSystemSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mahAlarmSubSystemSet.Click
        Try
            objMcAH = New DataAPI.MacMan.CAlarmHistory(Me.mahAlarmSubSystemCombo.SelectedValue)
            objMcAH.SetSubSystem(Me.mahAlarmSubSystemCombo.SelectedValue)
            UpdateMcAlarmHistory()
        Catch ae As ApplicationException
            DisplayError("MacMan", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("MacMan", ex.Message)
        End Try
    End Sub



    Private Sub mohUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mohUpdateButton.Click
        On Error GoTo sd
        Dim opIndex As Int16
        Dim mohObject As DataAPI.MacMan.COperation

        opIndex = CInt(Me.mohOperationIndex.Text)

        mohObject = objMcOH.GetOperationHistory(opIndex)

        'Me.mohHistoryObject.Text = mohObject.Date & vbCrLf & mohObject.Data & vbCrLf & mohObject.Time
        Me.mohOperationData.Text = mohObject.Data
        Me.mohOperationDate.Text = mohObject.Date
        Me.mohOperationTime.Text = mohObject.Time
        Me.mohCount.Text = objMcOH.GetCount
        Me.mohMaxCount.Text = objMcOH.GetMaxCount

        Exit Sub

sd:

        DisplayError("MacMan Operating Report", Err.Description)
        Resume Next
    End Sub

    Private Sub mohSubSystemSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mohSubSystemSet.Click
        Try
            objMcOH.SetSubSystem(Me.mohSubSystemCombo.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("MacMan", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("MacMan", ex.Message)
        End Try
    End Sub

    Private Sub mohButtonResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mahButtonResults.Click
        Dim mohObject As DataAPI.MacMan.CAlarm
        Dim mohObjects As ArrayList
        Dim intIndex As Integer

        Try
            Me.mahResults.Text = ""
            intIndex = CInt(Me.mahFrom.Text)
            Me.mahResults.Text += "Index" & vbTab & "Date" & vbTab & vbTab & "Time" & vbTab & "Number" & vbTab & "Object" & vbTab & "Code" & vbTab & "Message" & vbCrLf
            mohObjects = objMcAH.GetAlarms(CInt(Me.mahFrom.Text), CInt(Me.mahTo.Text))
            For Each mohObject In mohObjects
                Me.mahResults.Text += intIndex.ToString & vbTab & mohObject.Date & vbTab & mohObject.Time & vbTab & mohObject.Number & vbTab & mohObject.Object & vbTab & mohObject.Code & vbTab & mohObject.Message & vbCrLf
                intIndex = intIndex + 1
            Next
        Catch ae As ApplicationException
            DisplayError("Macman Alarm History", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("Macman Alarm History", ex.Message)
        End Try
    End Sub

    Private Sub mohButtonResults_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mohButtonResults.Click
        Dim mohObject As DataAPI.MacMan.COperation
        Dim mohObjects As ArrayList

        Try
            Me.mohResults.Text = ""
            mohObjects = objMcOH.GetOperationHistory(CInt(Me.mohFrom.Text), CInt(Me.mohTo.Text))
            For Each mohObject In mohObjects
                Me.mohResults.Text += mohObject.Date & vbTab & mohObject.Data & vbTab & mohObject.Time & vbCrLf
            Next
        Catch ae As ApplicationException
            DisplayError("Macman Operation History", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("Macman Operation History", ex.Message)
        End Try
    End Sub



#Region "Program"
    Private Sub progSelectProgramButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles progSelectProgramButton.Click
        Try
            objCMDProgram.SelectMainProgram(prog1.Text, prog2.Text, prog3.Text, prog4.Text)
        Catch ae As ApplicationException
            DisplayError("CMD program", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMD Program", ex.Message)
        End Try
    End Sub

    Private Sub progCancelProgramButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles progCancelProgramButton.Click
        Try
            objCMDProgram.CancelMainProgram()
        Catch ae As ApplicationException
            DisplayError("CMD program", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMD Program", ex.Message)
        End Try
    End Sub

    Private Sub progButtonCycleStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles progButtonCycleStatus.Click

        Try
            Me.TxtProgrameCycleComplete.Text = objProgram.ScheduleProgramCycleComplete(ScheduleProgramCycleCompleteCombo.SelectedValue)
            Me.TxtCycleComplte.Text = objProgram.CycleComplete(cboCycleCompleteCombo.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("CProgram", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub
    Private Sub progButtonGetRunProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles progButtonGetRunProgram.Click
        Dim rp As String()
        Dim currp As String
        Dim rpoint As Int32
        Dim epoint As Int32
        Dim pname As String


        Try
            progRunningPrograms.Clear()

            Me.TxtRunningPrograme.Text = objProgram.GetRunningProgramName()
            progMCodes.Text = objProgram.GetMCodes(Me.progMCodesCombo.SelectedValue)



            rp = objProgram.GetRunningProgram(CInt(Me.progRow.Text), CInt(Me.progColumn.Text), rpoint, epoint)

            Me.progExecutePoint.Text = epoint
            Me.progRead.Text = rpoint

            For Each currp In rp
                progRunningPrograms.Text += currp & vbCrLf
            Next


        Catch ae As ApplicationException
            DisplayError("CProgram", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub

    Private Sub progUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles progUpdateButton.Click

        Dim activeProgramFname As String
        Dim activeProgramName As String
        Dim currentBlockNumber As Int32
        Dim defaultProgramPath As String
        Dim execSequenceNumber As String
        Dim gCodes As String
        Dim mCodes As String
        Dim executeBlock As String

        Try

            activeProgramFname = objProgram.GetActiveProgramFileName
            activeProgramName = objProgram.GetActiveProgramName
            currentBlockNumber = objProgram.GetCurrentBlockNumber
            defaultProgramPath = objProgram.GetDefaultProgramPath
            executeBlock = objProgram.GetExecuteBlock
            execSequenceNumber = objProgram.GetExecutedSequenceNumber
            gCodes = objProgram.GetGCodes

        Catch ae As ApplicationException
            DisplayError("CProgram", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try

        Me.progNoParams.Text = "Active Program Filename: " & activeProgramFname & vbCrLf _
            & "Active Program File Name: " & activeProgramFname & vbCrLf _
            & "Active Program Name: " & activeProgramName & vbCrLf _
            & "Current Block Number: " & currentBlockNumber & vbCrLf _
            & "Default Program Path: " & defaultProgramPath & vbCrLf _
            & "Execute Block: " & executeBlock & vbCrLf _
            & "Execution Sequence Number: " & execSequenceNumber & vbCrLf _
            & "G Codes: " & gCodes & vbCrLf
    End Sub


    Private Sub progGetMCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles progGetMCodes.Click

        Try
            progMCodes.Text = objProgram.GetMCodes(Me.progMCodesCombo.SelectedValue)

        Catch ae As ApplicationException
            DisplayError("CProgram", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub

    Private Sub cmdSelectProgramLSide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectProgramLSide.Click
        Try
            objCMDProgram.SelectMainProgramLSide(prog1.Text, prog2.Text, prog3.Text, prog4.Text)

        Catch ae As ApplicationException
            DisplayError("CProgram", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub

    Private Sub cmdSelectProgramRSide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectProgramRSide.Click
        Try
            objCMDProgram.SelectMainProgramRSide(prog1.Text, prog2.Text, prog3.Text, prog4.Text)

        Catch ae As ApplicationException
            DisplayError("CProgram", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub

    Private Sub cmdSelectScheduleProgramLSide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectScheduleProgramLSide.Click
        Try
            objCMDProgram.SelectScheduleProgramLSide(prog1.Text)

        Catch ae As ApplicationException
            DisplayError("CProgram", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub

    Private Sub cmdSelectScheduleProgramRSide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectScheduleProgramRSide.Click
        Try
            objCMDProgram.SelectScheduleProgramRSide(prog1.Text)

        Catch ae As ApplicationException
            DisplayError("CProgram", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub

    Private Sub cmdSelectScheduleProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectScheduleProgram.Click
        Try
            objCMDProgram.SelectScheduleProgram(prog1.Text)

        Catch ae As ApplicationException
            DisplayError("CProgram", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub
#End Region



    Private Sub tulButtonNoseRPattern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulButtonNoseRPattern.Click
        Dim toolNum As Int16
        toolNum = CInt(Me.tulToolNumber.Text)

        Dim vNosePattern As Integer()
        Dim dr As Double
        Dim a As Int16
        Try
            Me.tulResults.Text = ""
            vNosePattern = objTool.GetNoseRCompensationPattern(CInt(Me.TulNoseRCompensationPatternFrom.Text), CInt(Me.TulNoseRCompensationPatternTo.Text))
            For Each dr In vNosePattern
                a = a + 1
                Me.tulResults.Text += a & " - " & dr & vbCrLf
            Next
        Catch ae As ApplicationException
            DisplayError("Ctool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulButtonNoseRComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulButtonNoseRComp.Click
        Dim toolNum As Int16
        toolNum = CInt(Me.tulToolNumber.Text)

        Dim vNosePattern As Double()
        Dim dr As Double
        Dim a As Int16
        Try
            Me.tulResults.Text = ""
            vNosePattern = objTool.GetNoseRCompensation(CInt(Me.TulNoseRCompensationPatternFrom.Text), CInt(Me.TulNoseRCompensationPatternTo.Text), Me.tul1ComboNoseRComp.SelectedValue)
            For Each dr In vNosePattern
                a = a + 1
                Me.tulResults.Text += a & " - " & dr & vbCrLf
            Next
        Catch ae As ApplicationException
            DisplayError("Ctool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulButtonToolOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulButtonToolOffset.Click
        Dim toolNum As Int16
        toolNum = CInt(Me.tulToolNumber.Text)

        Dim vNosePattern As Double()
        Dim dr As Double
        Dim a As Int16
        Try
            Me.tulResults.Text = ""
            vNosePattern = objTool.GetToolOffset(CInt(Me.TulNoseRCompensationPatternFrom.Text), CInt(Me.TulNoseRCompensationPatternTo.Text), Me.tul1ComboToolOffset.SelectedValue)
            For Each dr In vNosePattern
                a = a + 1
                Me.tulResults.Text += a & " - " & dr & vbCrLf
            Next
        Catch ae As ApplicationException
            DisplayError("Ctool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulButtonToolWear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulButtonToolWear.Click
        Dim toolNum As Int16
        toolNum = CInt(Me.tulToolNumber.Text)
        Dim toolwear As Double
        Dim vNosePattern As Double()
        Dim dr As Double
        Dim a As Int16
        Try
            Me.tulResults.Text = ""

            vNosePattern = objTool.GetToolWearOffset(CInt(Me.TulNoseRCompensationPatternFrom.Text), CInt(Me.TulNoseRCompensationPatternTo.Text), Me.cboToolWearOffsetAxis.SelectedItem)
            For Each dr In vNosePattern
                a = a + 1
                Me.tulResults.Text += a & " - " & dr & vbCrLf
            Next


        Catch ae As ApplicationException
            DisplayError("Ctool:", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool:", ex.Message)
        End Try
    End Sub



#Region "tools 2"
    Private Sub tul2ButtonUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tul2ButtonUpdate.Click
        tul2Update()

    End Sub
    Private Sub tul2Update()
        On Error GoTo sd
        Dim toolnum As Int16
        Dim enBAxisCuttingPosition As Okuma.CLDATAPI.Enumerations.BAxisCuttingPositionEnum
        Dim enAxis As Okuma.CLDATAPI.Enumerations.PrincipalAxisEnum

        toolnum = CInt(Me.tul2tn.Text)

        enAxis = tul2pa1.SelectedValue
        enBAxisCuttingPosition = tul2ba1.SelectedValue
        Me.tul2get1.Text = objTool.GetReferenceToolOffset1(enAxis, enBAxisCuttingPosition, toolnum)

        enAxis = tul2pa2.SelectedValue
        enBAxisCuttingPosition = tul2ba2.SelectedValue
        Me.tul2get2.Text = objTool.GetReferenceToolOffset2(enAxis, enBAxisCuttingPosition, toolnum)

        enAxis = tul2pa3.SelectedValue
        enBAxisCuttingPosition = tul2ba3.SelectedValue
        Me.tul2get3.Text = objTool.GetReferenceToolOffset3(enAxis, enBAxisCuttingPosition, toolnum)

        Exit Sub

sd:

        DisplayError("CTool:  ", Err.Description)
        Resume Next
    End Sub

    Private Sub tul2Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tul2Button1.Click
        Try
            Dim enBAxisCuttingPosition As Okuma.CLDATAPI.Enumerations.BAxisCuttingPositionEnum
            Dim enAxis As Okuma.CLDATAPI.Enumerations.PrincipalAxisEnum
            Dim intToolNo As Integer
            Dim intRefOffsetNo As Integer

            enAxis = tul2pa1.SelectedValue
            enBAxisCuttingPosition = tul2ba1.SelectedValue

            intToolNo = CInt(Me.tul2tn.Text)
            intRefOffsetNo = CInt(Me.tul2set1.Text)


            objTool.SetReferenceToolOffset1(enAxis, enBAxisCuttingPosition, intToolNo, intRefOffsetNo)

            tul2Update()
        Catch ae As ApplicationException
            DisplayError("Ctool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tul2Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tul2Button2.Click
        Try
            Dim enBAxisCuttingPosition As Okuma.CLDATAPI.Enumerations.BAxisCuttingPositionEnum
            Dim enAxis As Okuma.CLDATAPI.Enumerations.PrincipalAxisEnum
            Dim intToolNo As Integer
            Dim intRefOffsetNo As Integer

            enAxis = tul2pa2.SelectedValue
            enBAxisCuttingPosition = tul2ba2.SelectedValue

            intToolNo = CInt(Me.tul2tn.Text)
            intRefOffsetNo = CInt(Me.tul2set2.Text)


            objTool.SetReferenceToolOffset2(enAxis, enBAxisCuttingPosition, intToolNo, intRefOffsetNo)
            tul2Update()
        Catch ae As ApplicationException
            DisplayError("Ctool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tul2Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tul2Button3.Click
        Try
            Dim enBAxisCuttingPosition As Okuma.CLDATAPI.Enumerations.BAxisCuttingPositionEnum
            Dim enAxis As Okuma.CLDATAPI.Enumerations.PrincipalAxisEnum
            Dim intToolNo As Integer
            Dim intRefOffsetNo As Integer

            enAxis = tul2pa3.SelectedValue
            enBAxisCuttingPosition = tul2ba3.SelectedValue

            intToolNo = CInt(Me.tul2tn.Text)
            intRefOffsetNo = CInt(Me.tul2set3.Text)


            objTool.SetReferenceToolOffset3(enAxis, enBAxisCuttingPosition, intToolNo, intRefOffsetNo)

            tul2Update()
        Catch ae As ApplicationException
            DisplayError("Ctool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub
#End Region


    Private Sub chuckButtonSetWorkType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chuckButtonSetWorkType.Click
        Try
            objChuck.SetWorkType(Me.chuckWorkTypeCombo.SelectedValue)

            Update_Chuck()
        Catch ex As Exception
            DisplayError("Chuck:  ", ex.Message)

        End Try


    End Sub

    Private Sub cmd_tailStock_SetAxisPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_tailStock_SetAxisPos.Click
        Try
            objTailStock.SetTailstockSpindlePosition(txtTailStockSpindlePositionSetting.Text)
            Update_TailStock()
        Catch ex As Exception
            DisplayError("CTailStock", ex.Message)
        End Try

    End Sub

    Private Sub cmd_tailStock_AddAxisPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_tailStock_AddAxisPos.Click
        Try
            objTailStock.AddTailstockSpindlePosition(txtTailStockSpindlePositionSetting.Text)
            Update_TailStock()
        Catch ex As Exception
            DisplayError("CTailStock", ex.Message)
        End Try
    End Sub

    Private Sub cmd_tailStock_CalAxisPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_tailStock_CalAxisPos.Click
        Try
            objTailStock.CalTailstockSpindlePosition(txtTailStockSpindlePositionSetting.Text)
            Update_TailStock()
        Catch ex As Exception
            DisplayError("CTailStock", ex.Message)
        End Try
    End Sub



    Private Sub cmd_Ctools2_setToolOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Ctools2_setToolOffset.Click
        Dim enAxis As Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum
        Dim enCutting As Okuma.CLDATAPI.Enumerations.CuttingPositionEnum

        Try
            enAxis = CInt(cbo_Ctools2_ToolOffSetAxisIndex.SelectedItem)
            enCutting = CInt(cbo_Ctools2_Cutpos.SelectedItem)


            objTool.SetToolOffset(Convert.ToInt32(txt_CTools2_fromindx.Text), enAxis, enCutting, Convert.ToDouble(txtTool2Input.Text))

        Catch ex As Exception
            DisplayError("CTools", ex.Message)
        End Try
    End Sub

    Private Sub cmd_Ctools2_AddToolOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Ctools2_AddToolOffset.Click
        Dim enAxis As Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum
        Dim enCutting As Okuma.CLDATAPI.Enumerations.CuttingPositionEnum

        Try
            enAxis = CInt(cbo_Ctools2_ToolOffSetAxisIndex.SelectedItem)
            enCutting = CInt(cbo_Ctools2_Cutpos.SelectedItem)


            objTool.AddToolOffset(Convert.ToInt32(txt_CTools2_fromindx.Text), enAxis, enCutting, Convert.ToDouble(txtTool2Input.Text))
        Catch ex As Exception
            DisplayError("CTools", ex.Message)
        End Try

    End Sub

    Private Sub Btn_GetNose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_GetNose.Click

        Dim nose_arr As Array
        Dim intindx As Integer()
        Dim i As Integer
        Dim toolindx As Double()
        Dim intCount As Integer
        Dim intIndex As Integer
        Dim intOffsetIndex As Integer
        Try

            txt_CTools2_ToolOffSet.Clear()
            txt_CTools2_ToolIntNDX.Clear()


            nose_arr = objTool.GetNoseRCompensation(Convert.ToInt32(txt_CTools2_fromindx.Text), Convert.ToInt32(txt_CTools2_toindx.Text), Cmb_NoseRCompensationAxisIndex.SelectedItem, cbo_Ctools2_Cutpos.SelectedItem)
            intindx = objTool.GetNoseRCompensationPattern(Convert.ToInt32(txt_CTools2_fromindx.Text), Convert.ToInt32(txt_CTools2_toindx.Text), cbo_Ctools2_Cutpos.SelectedItem)

            intCount = UBound(nose_arr)

            intOffsetIndex = Convert.ToInt32(txt_CTools2_fromindx.Text)
            For intIndex = 0 To intCount
                txt_CTools2_ToolOffSet.Text += String.Format("Index {0} = {1}", intOffsetIndex.ToString, nose_arr(intIndex)) + vbCrLf
                intOffsetIndex = intOffsetIndex + 1
            Next
            intOffsetIndex = Convert.ToInt32(txt_CTools2_fromindx.Text)
            For intIndex = 0 To intCount
                txt_CTools2_ToolIntNDX.Text += String.Format("Index {0} = {1}", intOffsetIndex.ToString, intindx(intIndex)) + vbCrLf
                intOffsetIndex = intOffsetIndex + 1
            Next
        Catch ex As Exception
            DisplayError("CTools", ex.Message)
        End Try
    End Sub

    Private Sub Btn_GetNose2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_GetNose2.Click
        Dim enAxis As Okuma.CLDATAPI.Enumerations.NoseRCompensationAxisIndexEnum
        Dim enCutting As Okuma.CLDATAPI.Enumerations.CuttingPositionEnum
        Dim nose_db As Double
        Dim intNoseRPattern As Integer


        Try
            enAxis = CInt(Cmb_NoseRCompensationAxisIndex.SelectedItem)
            enCutting = CInt(cbo_Ctools2_Cutpos.SelectedItem)


            nose_db = objTool.GetNoseRCompensation(Convert.ToInt32(txt_CTools2_fromindx.Text), enAxis, enCutting)
            intNoseRPattern = objTool.GetNoseRCompensationPattern(Convert.ToInt32(txt_CTools2_fromindx.Text), enCutting)
            txt_CTools2_ToolOffSet.Text = "Index " & Convert.ToInt32(txt_CTools2_fromindx.Text).ToString + " = " + nose_db.ToString
            txt_CTools2_ToolIntNDX.Text = "Index " & Convert.ToInt32(txt_CTools2_fromindx.Text).ToString + " = " + intNoseRPattern.ToString

        Catch ex As Exception
            DisplayError("CTools", ex.Message)
        End Try
    End Sub

    Private Sub btn_setCompensation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setCompensation.Click


        Try
            objTool.SetNoseRCompensation(Convert.ToInt32(txt_CTools2_fromindx.Text), Cmb_NoseRCompensationAxisIndex.SelectedItem, cbo_Ctools2_Cutpos.SelectedItem, Convert.ToDouble(txtTool2Input.Text))
            objTool.SetNoseRCompensationPattern(Convert.ToInt32(txt_CTools2_fromindx.Text), cbo_Ctools2_Cutpos.SelectedItem, Convert.ToInt32(txtCTool2_NoseRCompensationPatternSettingValue.Text))
        Catch ex As Exception
            DisplayError("CTools", ex.Message)
        End Try
    End Sub

    Private Sub Btn_AddCompensation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AddCompensation.Click

        Try
            objTool.AddNoseRCompensation(Convert.ToInt32(txt_CTools2_fromindx.Text), Cmb_NoseRCompensationAxisIndex.SelectedItem, cbo_Ctools2_Cutpos.SelectedItem, Convert.ToDouble(txtTool2Input.Text))

        Catch ex As Exception
            DisplayError("CTools", ex.Message)
        End Try
    End Sub

    'Private Sub Tool2Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool2Add.Click
    '    Try
    '        objTool.AddToolOffset(CInt(Me.tul2pa1.SelectedValue), CInt(Me.tul2ba1.SelectedValue), CInt(Me.tul2tn.Text), CInt(Me.tul2set1.Text))
    '        tul2Update()
    '    Catch ae As ApplicationException
    '        DisplayError("Ctool", ae.Message)
    '        'Exit Sub
    '    Catch ex As Exception
    '        DisplayError("CTool", ex.Message)
    '    End Try
    'End Sub

    Private Sub Btn_setOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            objTool.SetToolOffset(CInt(Me.tul2pa1.SelectedValue), CInt(Me.tul2ba1.SelectedValue), CInt(Me.tul2tn.Text), CInt(Me.tul2set1.Text))
            tul2Update()
        Catch ae As ApplicationException
            DisplayError("Ctool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub


  



 



    Private Sub tu3_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tu3_Update.Click
        tul3Update()
    End Sub
    Private Sub tul3Update()
        On Error GoTo sd
        Dim toolnum As Int32
        Dim int_wearoffsetindex As Okuma.CLDATAPI.Enumerations.ToolWearOffsetAxisIndexEnum
        Dim int_principleaxisbase As Okuma.CLDATAPI.Enumerations.CuttingPositionEnum


        toolnum = CInt(Me.tul3tn.Text)
        int_principleaxisbase = CInt(cmb_CuttingPosition.SelectedItem)
        int_wearoffsetindex = CInt(cmb_ToolWearOffsetAxisIndex.SelectedItem)

        Me.tul3get4.Text = objTool.GetToolWearOffset(toolnum, int_wearoffsetindex, int_principleaxisbase)

        Exit Sub
sd:
        DisplayError("CTool:  ", Err.Description)
        Resume Next
    End Sub

    Private Sub GetToolWearOffsetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetToolWearOffsetButton.Click
        Dim a As Double()
        Dim rp As Double
        Dim intIndex As Integer


        Dim int_wearoffsetindex As Okuma.CLDATAPI.Enumerations.ToolWearOffsetAxisIndexEnum
        Dim int_principleaxisbase As Okuma.CLDATAPI.Enumerations.CuttingPositionEnum

        Try

            int_wearoffsetindex = CInt(cmb_ToolWearOffsetAxisIndex.SelectedItem)
            int_principleaxisbase = CInt(cmb_CuttingPosition.SelectedItem)

            txt_getValue.Text = ""

            intIndex = CInt(txt_FromIndex.Text)

            a = objTool.GetToolWearOffset(CInt(txt_FromIndex.Text), CInt(txt_ToIndex.Text), int_wearoffsetindex, int_principleaxisbase)
            For Each rp In a
                txt_getValue.Text += "Index " & intIndex.ToString() & " = " & rp & vbCrLf
                intIndex = intIndex + 1

            Next

        Catch ex As Exception
            DisplayError("CTools", ex.Message)
        End Try
    End Sub

    Private Sub tul3_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tul3_Set.Click
        Dim int_wearoffsetindex As Okuma.CLDATAPI.Enumerations.ToolWearOffsetAxisIndexEnum
        Dim int_principleaxisbase As Okuma.CLDATAPI.Enumerations.CuttingPositionEnum

        Try

            int_wearoffsetindex = CInt(cmb_ToolWearOffsetAxisIndex.SelectedItem)
            int_principleaxisbase = CInt(cmb_CuttingPosition.SelectedItem)
            objTool.SetToolWearOffset(CInt(tul3tn.Text), int_wearoffsetindex, int_principleaxisbase, Convert.ToDouble(txt_double1.Text))

            tul3Update()
        Catch ae As ApplicationException
            DisplayError("Ctool", ae.Message)

        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tul2AddToolWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tul2AddToolWearOffset.Click
        Dim int_wearoffsetindex As Okuma.CLDATAPI.Enumerations.ToolWearOffsetAxisIndexEnum
        Dim int_principleaxisbase As Okuma.CLDATAPI.Enumerations.CuttingPositionEnum

        Try

            int_wearoffsetindex = CInt(cmb_ToolWearOffsetAxisIndex.SelectedItem)
            int_principleaxisbase = CInt(cmb_CuttingPosition.SelectedItem)
            objTool.AddToolWearOffset(CInt(tul3tn.Text), int_wearoffsetindex, int_principleaxisbase, Convert.ToDouble(txt_double1.Text))

            tul3Update()

        Catch ae As ApplicationException
            DisplayError("Ctool", ae.Message)

        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub cbo_Ctools2_getToolOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Ctools2_getToolOffset.Click

        Dim toolindx As Double()
        Dim intCount As Integer
        Dim intIndex As Integer
        Dim intOffsetIndex As Integer


        Try

            txt_CTools2_ToolOffSet.Clear()

            toolindx = objTool.GetToolOffset(Convert.ToInt32(txt_CTools2_fromindx.Text), Convert.ToInt32(txt_CTools2_toindx.Text), cbo_Ctools2_ToolOffSetAxisIndex.SelectedItem, cbo_Ctools2_Cutpos.SelectedItem)
            intCount = UBound(toolindx)

            intOffsetIndex = Convert.ToInt32(txt_CTools2_fromindx.Text)
            For intIndex = 0 To intCount
                txt_CTools2_ToolOffSet.Text += String.Format("Index {0} = {1}", intOffsetIndex.ToString, toolindx(intIndex)) + vbCrLf
                intOffsetIndex = intOffsetIndex + 1
            Next

        Catch ex As Exception
            DisplayError("CTools", ex.Message)
        End Try

    End Sub

    Private Sub cbo_Ctools2_getToolOffset2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Ctools2_getToolOffset2.Click

        Dim d As Double
        Dim enAxis As Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum
        Dim enCutting As Okuma.CLDATAPI.Enumerations.CuttingPositionEnum

        Try
            enAxis = CInt(cbo_Ctools2_ToolOffSetAxisIndex.SelectedItem)
            enCutting = CInt(cbo_Ctools2_Cutpos.SelectedItem)
            d = objTool.GetToolOffset(Convert.ToInt32(txt_CTools2_fromindx.Text), enAxis, enCutting)

            txt_CTools2_ToolOffSet.Text = d.ToString

        Catch ae As ApplicationException
            DisplayError("Ctool2", ae.Message)

        Catch ex As Exception
            DisplayError("CTool2", ex.Message)
        End Try

    End Sub




    Private Sub macReportUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles macReportUpdateButton.Click
        On Error GoTo sd
        Dim Mac_reportObject As Okuma.CLDATAPI.DataAPI.MacMan.CMachining
        Dim int_PeriodReport As Int32
        Dim opIndex As Int16
        int_PeriodReport = CInt(Me.Cmb_rptPeriod.SelectedItem)
        opIndex = CInt(Me.MacReport_Index.Text)
        Mac_reportObject = objMeh.GetMachiningReport(opIndex, int_PeriodReport)
        Me.MacReport_count.Text = objMeh.GetCount(int_PeriodReport)
        Me.macreport_maxcount.Text = objMeh.GetMaxCount(int_PeriodReport)

        Me.MacreportTime.Text = Mac_reportObject.StartTime
        Me.Macreportdate.Text = Mac_reportObject.StartDate

        Me.macreport_cuttingtime.Text = Mac_reportObject.CuttingTime
        Me.macreport_Operatingtime.Text = Mac_reportObject.OperatingTime
        Me.macreport_Runningtime.Text = Mac_reportObject.RunningTime
        Me.Macreport_filename.Text = Mac_reportObject.MainProgramFileName
        Me.MacReport_programname.Text = Mac_reportObject.MainProgramName
        txtMachiningReport_NoOfWork.Text = Mac_reportObject.NumberOfWork


        Exit Sub
sd:

        DisplayError("MacMan Machining  Report", Err.Description)
        Resume Next
    End Sub
    Private Sub cmdMMMachiningReportsSubSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMMMachiningReportsSubSystem.Click

        Try
            objMeh.SetSubSystem(cboMachiningReportSubSystem.SelectedValue)
        Catch ex As Exception
            DisplayError("MacMan Machining  Report", ex.Message)
        End Try
    End Sub

    Private Sub macreport_result_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles macreport_result.Click
        Dim Mac_reportObject As Okuma.CLDATAPI.DataAPI.MacMan.CMachining
        Dim int_PeriodReport As Int32
        Dim mac_objects As ArrayList
        Dim opIndex As Int16


        Dim Mac_reportObjects As ArrayList

        Try
            int_PeriodReport = CInt(Me.Cmb_rptPeriod.SelectedItem)
            opIndex = CInt(Me.txtFrom.Text)
            mac_objects = objMeh.GetMachiningReports(CInt(txtFrom.Text), CInt(txtto.Text), int_PeriodReport)

            grdMMMachiningReports.DataSource = mac_objects
            grdMMMachiningReports.Refresh()



        Catch ae As ApplicationException
            DisplayError("MacMan Machining  Report", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("MacMan Machining  Report", ex.Message)
        End Try
    End Sub

    Private Sub cmd_ChangeScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChangeScreen.Click
        Dim objview As Okuma.ClCMDAPI.CommandAPI.CViews
        Dim int_panalenum As Int32
        Try
            int_panalenum = CInt(Cmb_ChangeScreen.SelectedItem)
            objview = New Okuma.ClCMDAPI.CommandAPI.CViews
            objview.ChangeScreen(int_panalenum, txt_screenname.Text)
        Catch ae As ApplicationException
            DisplayError("Cview", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("Cview", ex.Message)
        End Try
    End Sub

    Private Sub tulAddToolLife_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulAddToolLife_button.Click
        Try
            objTool.AddToolLife(Me.tulComboToolLife.SelectedValue, CInt(Me.tulToolNumber.Text), Convert.ToDouble(Me.tulUpdToolLife.Text))
            Updatetools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub


    Private Sub CMD_SETOPERATINGHISTORY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_SETOPERATINGHISTORY.Click
        Try
            objMopnh.SetSubSystem(Me.CMB_OPERATINGHISTORY.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("MacMan", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("MacMan", ex.Message)
        End Try
    End Sub




#Region "Private Function"
    Private Function ArrayToString(ByRef arInt() As Int32) As String
        Dim str As System.String = ""

        Dim intCount As Integer
        Dim intIndex As Integer

        intCount = UBound(arInt)

        For intIndex = 0 To intCount
            str = str + CStr(arInt(intIndex)) + "-"
        Next

        Return str

    End Function
#End Region

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    UpdateMachiningReport()
    'End Sub

    '    Private Sub UpdateMachiningReport()
    '        On Error GoTo sd
    '        Dim Mac_reportObject As New MacMan.CMachining
    '        Dim int_PeriodReport As Int32
    '        Dim opIndex As Int16
    '        int_PeriodReport = CInt(Me.Cmb_rptPeriod.SelectedItem)
    '        opIndex = CInt(Me.MacReport_Index.Text)

    '        Mac_reportObject = objMeh.GetMachiningReport(opIndex, int_PeriodReport)

    '        Me.macreport_maxcount.Text = objMeh.GetMaxCount(int_PeriodReport)
    '        Me.macreport_cuttingtime.Text = Mac_reportObject.CuttingTime
    '        Me.macreport_Operatingtime.Text = Mac_reportObject.OperatingTime
    '        Me.macreport_Runningtime.Text = Mac_reportObject.RunningTime
    '        Me.Macreport_filename.Text = Mac_reportObject.MainProgramFileName
    '        Me.MacReport_programname.Text = Mac_reportObject.MainProgramName
    '        Me.MacReport_NoOfWork.Text = Mac_reportObject.NumberOfWork

    '        Me.Macreportdate.Text = Mac_reportObject.StartDate
    '        Me.MacReportStartTime.Text = Mac_reportObject.StartTime

    '        Me.MacReport_count.Text = objMeh.GetCount(int_PeriodReport)


    '        Exit Sub
    'sd:

    '        DisplayError("MacMan Machining  Report", Err.Description)
    '        Resume Next
    '    End Sub

    Private Sub cmdAddActualToolLife_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddActualToolLife.Click
        Try
            objTool.AddActualToolLife(Me.tulComboActualToolLife.SelectedValue, CInt(Me.tulToolNumber.Text), CInt(Me.tulUpdActualToolLife.Text))
            Updatetools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub


    Private Sub objMopnhUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles objMopnhUpdateButton.Click

        On Error GoTo sd



        Me.mopnhAlarmOnTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.AlarmOnTime))
        Me.mopnhCuttingTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.CuttingTime))
        Me.mopnhExternalInputTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.ExternalInputTime))
        Me.mopnhInProSetupTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.InProcessSetupTime))
        Me.mopnhMaintenanceTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.MaintenanceTime))
        Me.mopnhNonOperatingReport.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.NonOperatingTime))
        Me.mopnhNoOperatorTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.NoOperatorTime))
        Me.mopnhOperatingTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.OperatingTime))
        Me.mopnhOtherTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.OtherTime))
        Me.mopnhPartWaitingTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.PartWaitingTime))
        Me.mopnhRunningTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.RunningTime))
        Me.mopnhSpindleRunTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.SpindleRunTime))

        Me.mopnhPrevAlarmonTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.AlarmOnTime))
        Me.mopnhPrevCuttingTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.CuttingTime))
        Me.mopnhPrevExternalInputTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.ExternalInputTime))
        Me.mopnhPrevInProSetupTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.InProcessSetupTime))
        Me.mopnhPrevMaintenanceTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.MaintenanceTime))
        Me.mopnhPrevNonOperatingTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.NonOperatingTime))
        Me.mopnhPrevNoOperatorTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.NoOperatorTime))
        Me.mopnhPrevOperatingTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.OperatingTime))
        Me.mopnhPrevOtherTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.OtherTime))
        Me.mopnhPrevPartWaitingTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.PartWaitingTime))
        Me.mopnhPrevRunningTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.RunningTime))
        Me.mopnhPrevSpindleRunTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.SpindleRunTime))

        Me.mopnhMaxNoofReports.Text = objMopnh.GetMaxCount()
        Exit Sub

sd:

        DisplayError("MacMan Operating History Report", Err.Description)
        Resume Next
    End Sub

    Private Sub morUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles morUpdateButton.Click
        On Error GoTo sd

        objMor.SetSubSystem(McORSubSystemCombo.SelectedValue)

        Me.morNonoperatingCondition.Text = System.Enum.GetNames(GetType(NonOperatingConditionEnum)).GetValue(objMor.GetNonOperatingCondition)
        Me.morOperatingStatus.Text = System.Enum.GetNames(GetType(OperatingStatusEnum)).GetValue(objMor.GetOperatingStatus)

        Me.morDateOfOperatingReport.Text = objMor.GetTodayOperatingReportDate()
        Me.morMaxNoOfOpReport.Text = objMor.GetMaxCount()

        Me.morOperatingTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.OperatingTime)
        Me.morRunningTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.RunningTime)
        Me.morCuttingTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.CuttingTime)
        Me.morNonOPeratingTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.NonOperatingTime)
        Me.morInProSetupTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.InProcessSetupTime)
        Me.morNoOperatorTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.NoOperatorTime)
        Me.morPartWaitingTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.PartWaitingTime)
        Me.mormaintenanceTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.MaintenanceTime)
        Me.morOtherTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.OtherTime)
        Me.morSpindleRunTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.SpindleRunTime)
        Me.morExternalInputTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.ExternalInputTime)
        Me.morAlarmOnTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.AlarmOnTime)




        Me.morPrevDateOfOperatingRept.Text = objMor.GetPreviousOperatingReportDate()

        Me.morPrevAlarmOnTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.AlarmOnTime)
        Me.morPrevCuttingTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.CuttingTime)
        Me.morPrevInProSetupTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.InProcessSetupTime)
        Me.morPrevMaintenanceTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.MaintenanceTime)
        Me.morPrevNonOperatingTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.NonOperatingTime)
        Me.morPrevNoOperatorTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.NoOperatorTime)
        Me.morPrevOperatingTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.OperatingTime)
        Me.morPrevOtherTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.OtherTime)
        Me.morPrevPartwaitingTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.PartWaitingTime)
        Me.morPrevRunningTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.RunningTime)
        Me.morPrevSpindleRunTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.SpindleRunTime)
        Me.morPrevExternalInputTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.ExternalInputTime)


        Me.morPeriodDateOfOperatingReport.Text = objMor.GetPeriodOperatingReportDate()

        Me.morPeriodAlarmOnTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.AlarmOnTime)
        Me.morPeriodCuttingTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.CuttingTime)
        Me.morPeriodExternalInputTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.ExternalInputTime)
        Me.morPeriodInproSetupTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.InProcessSetupTime)
        Me.morPeriodMaintenanceTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.MaintenanceTime)
        Me.morPeriodNonOperatingTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.NonOperatingTime)
        Me.morPeriodNoOperatorTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.NoOperatorTime)
        Me.morPeriodOperatingTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.OperatingTime)
        Me.morPeriodOtherTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.OtherTime)
        Me.morPeriodPartWaitingTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.PartWaitingTime)
        Me.morPeriodRunningTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.RunningTime)
        Me.morPeriodSpindleRunTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.SpindleRunTime)

        Exit Sub
sd:

        DisplayError("MacmMan Operating Report", Err.Description)
        Resume Next
    End Sub



    Private Sub axisUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles axisUpdateButton.Click
        Update_Axis()

    End Sub

    Private Sub cmdToolOffsetStandard_SetSubSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolOffsetStandard_SetSubSystem.Click
        objTool.SetSubSystem(Me.cboToolsSubSystem.SelectedValue)
        objTool.SetDataUnit(cboTool_Standard_DataUnit.SelectedValue)
    End Sub

    Private Sub cmdAddNoseRCuttingPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNoseRCuttingPos.Click
        Try
            objCMDTool.AddConstantNoseRadiusCompensation(CInt(Me.toolToolNo.Text), Me.toolOffsetAxis2Combo.SelectedValue, Me.toolSubSystemsCombo.SelectedValue, Me.toolCuttingPositionsCombo.SelectedValue)

        Catch ae As ApplicationException
            DisplayError("CMDTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMDTool", ex.Message)
        End Try
    End Sub

    Private Sub cmdAddToolOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToolOffset.Click
        Try
            objCMDTool.AddConstantToolOffset(CInt(Me.toolToolNo.Text), Me.toolOffsetAxis1Combo.SelectedValue, Me.toolSubSystemsCombo.SelectedValue)

        Catch ae As ApplicationException
            DisplayError("CMDTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMDTool", ex.Message)
        End Try
    End Sub

    Private Sub cmdAddToolOffsetCuttingPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToolOffsetCuttingPos.Click
        Try
            objCMDTool.AddConstantToolOffset(CInt(Me.toolToolNo.Text), Me.toolOffsetAxis1Combo.SelectedValue, Me.toolSubSystemsCombo.SelectedValue, Me.toolCuttingPositionsCombo.SelectedValue)

        Catch ae As ApplicationException
            DisplayError("CMDTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMDTool", ex.Message)
        End Try
    End Sub

    Private Sub cmdAddToolWearOffsetCuttingPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToolWearOffsetCuttingPos.Click
        Try
            objCMDTool.AddConstantToolWear(CInt(Me.toolToolNo.Text), Me.toolOffsetAxis2Combo.SelectedValue, Me.toolSubSystemsCombo.SelectedValue, Me.toolCuttingPositionsCombo.SelectedValue)

        Catch ae As ApplicationException
            DisplayError("CMDTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMDTool", ex.Message)
        End Try
    End Sub

    Private Sub cmdSubNoseRCuttingPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubNoseRCuttingPos.Click
        Try
            objCMDTool.SubtractConstantNoseRadiusCompensation(CInt(Me.toolToolNo.Text), Me.toolOffsetAxis2Combo.SelectedValue, Me.toolSubSystemsCombo.SelectedValue, Me.toolCuttingPositionsCombo.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("CMDTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMDTool", ex.Message)
        End Try
    End Sub

    Private Sub cmdSubToolOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubToolOffset.Click
        Try
            objCMDTool.SubtractConstantToolOffset(CInt(Me.toolToolNo.Text), Me.toolOffsetAxis1Combo.SelectedValue, Me.toolSubSystemsCombo.SelectedValue)

        Catch ae As ApplicationException
            DisplayError("CMDTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMDTool", ex.Message)
        End Try
    End Sub

    Private Sub cmdSubToolOffsetCuttingPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubToolOffsetCuttingPos.Click
        Try
            objCMDTool.SubtractConstantToolOffset(CInt(Me.toolToolNo.Text), Me.toolOffsetAxis1Combo.SelectedValue, Me.toolSubSystemsCombo.SelectedValue, Me.toolCuttingPositionsCombo.SelectedValue)

        Catch ae As ApplicationException
            DisplayError("CMDTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMDTool", ex.Message)
        End Try
    End Sub

    Private Sub cmdSubToolWearOffsetCuttingPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubToolWearOffsetCuttingPos.Click
        Try
            objCMDTool.SubtractConstantToolWear(CInt(Me.toolToolNo.Text), Me.toolOffsetAxis2Combo.SelectedValue, Me.toolSubSystemsCombo.SelectedValue, Me.toolCuttingPositionsCombo.SelectedValue)

        Catch ae As ApplicationException
            DisplayError("CMDTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMDTool", ex.Message)
        End Try
    End Sub

    Private Sub cmdAddToolWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToolWearOffset.Click
        Try
            objCMDTool.AddConstantToolWear(CInt(Me.toolToolNo.Text), Me.toolOffsetAxis2Combo.SelectedValue, Me.toolSubSystemsCombo.SelectedValue)

        Catch ae As ApplicationException
            DisplayError("CMDTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMDTool", ex.Message)
        End Try
    End Sub


#Region "Simulation"
    Private Sub cmdChangeReal3DSpindleMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeReal3DSpindleMode.Click
        Try
            objSimulation.ChangeReal3DSpindleMode()

        Catch ex As Exception
            DisplayError("CSimulation", ex.Message)
        End Try
    End Sub

    Private Sub cmdDeleteGraphWork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteGraphWork.Click
        Try
            objSimulation.DeleteGraphWork()

        Catch ex As Exception
            DisplayError("CSimulation", ex.Message)
        End Try
    End Sub

    Private Sub cmdSelect2D3DGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelect2D3DGraph.Click
        Try
            objSimulation.Select2D3DGraph()

        Catch ex As Exception
            DisplayError("CSimulation", ex.Message)
        End Try
    End Sub

    Private Sub cmdSelectGraphLineAnimate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectGraphLineAnimate.Click
        Try
            objSimulation.SelectGraphLineAnimate()

        Catch ex As Exception
            DisplayError("CSimulation", ex.Message)
        End Try
    End Sub

    Private Sub cmdStartGraphWork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStartGraphWork.Click
        Try
            objSimulation.StartGraphWork()

        Catch ex As Exception
            DisplayError("CSimulation", ex.Message)
        End Try
    End Sub

    Private Sub cmdAutoScaleAnimate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAutoScaleAnimate.Click
        Try
            objSimulation.AutoScaleAnimate()

        Catch ex As Exception
            DisplayError("CSimulation", ex.Message)
        End Try

    End Sub

    Private Sub cmdChangeEnlargeScaleFrame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeEnlargeScaleFrame.Click
        Try
            objSimulation.ChangeEnlargeScaleFrame(cboEnlargeScaleFrame.SelectedItem)

        Catch ex As Exception
            DisplayError("CSimulation", ex.Message)
        End Try
    End Sub

    Private Sub cmdNormalScale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNormalScale.Click
        Try

            objSimulation.ChangeNormalScale(CDbl(txtNormalScaleValue.Text))

        Catch ex As Exception
            DisplayError("CSimulation", ex.Message)
        End Try
    End Sub

    Private Sub cmdShiftEnlargeScaleFrame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShiftEnlargeScaleFrame.Click
        Try
            objSimulation.ShiftEnlargeScaleFrame(cboShiftEnlargeScaleFrame.SelectedItem)

        Catch ex As Exception
            DisplayError("CSimulation", ex.Message)
        End Try
    End Sub


    Private Sub cmdChangeGraphMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeGraphMode.Click
        Try
            objSimulation.ChangeGraphMode(cboGraphMode.SelectedItem)

        Catch ex As Exception
            DisplayError("CSimulation", ex.Message)
        End Try
    End Sub
#End Region


    Private Sub cmdTurretSubSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTurretSubSystem.Click
        Try
            objTurret.SetSubSystem(Me.cmb_Turret_subsys.SelectedItem)
        Catch ae As ApplicationException
            DisplayError("CTurret", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTurret", ex.Message)
        End Try
    End Sub

    Private Sub cmdTurretDataUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTurretDataUnit.Click
        Try
            objTurret.SetDataUnit(Me.cmb_Turret_DataUnit.SelectedItem)
        Catch ae As ApplicationException
            DisplayError("CTurret", ae.Message)
        Catch ex As Exception
            DisplayError("CTurret", ex.Message)
        End Try
    End Sub

    Private Sub cmdTool2Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTool2Set.Click
        Try

            objTool.SetSubSystem(cmb_Tool2_SubSys.SelectedItem)
            objTool.SetDataUnit(cmb_Tool2_DataUnit.SelectedItem)

        Catch ex As Exception
            DisplayError("CTools", ex.Message)
        End Try
    End Sub



    Private Sub cmdTool3Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTool3Set.Click
        Try

            objTool.SetSubSystem(cboTool3SubSystem.SelectedItem)
            objTool.SetDataUnit(cboTool3DataUnit.SelectedItem)

        Catch ex As Exception
            DisplayError("CTools", ex.Message)
        End Try
    End Sub

    Private Sub cmdPECSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPECSet.Click
        Try

            objBallScrew.SetSubSystem(cmb_BallScrew_SubSystem.SelectedItem)
            objBallScrew.SetDataUnit(cmb_BallScrew_DataUnit.SelectedItem)

        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub

    Private Sub cmdProgramSubSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProgramSubSystem.Click
        Try
            objProgram.SetSubSystem(cmb_Program_SubSys.SelectedItem)
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub


    Private Sub cmdTailStockSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTailStockSet.Click
        Try
            objTailStock.SetSubSystem(cmb_Tail_SubSys.SelectedItem)
            objTailStock.SetDataUnit(cmb_Tail_Dataunit.SelectedItem)
        Catch ex As Exception
            DisplayError("CTailStock", ex.Message)
        End Try
    End Sub

#Region "PLC I/O"
    Private Sub cmdIOGetBit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIOGetBit.Click
        Try
            Me.txtIOBit.Text = objIO.GetBitIO(Me.cboIOVariableTypes.SelectedValue, CInt(Me.txtIOBitIndex.Text), CInt(Me.txtIOBitNo.Text))
        Catch ae As ApplicationException
            DisplayError("I/O Variables", ae.Message)
        Catch ex As Exception
            DisplayError("I/O Variables", ex.Message)
        End Try
    End Sub
    Private Sub cmdIOGetWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIOGetWord.Click
        Try
            Me.txtIOWord.Text = objIO.GetWordIO(Me.cboIOVariableTypes.SelectedValue, CInt(Me.txtIOWordIndex.Text))
        Catch ae As ApplicationException
            DisplayError("I/O Variables", ae.Message)
        Catch ex As Exception
            DisplayError("I/O Variables", ex.Message)
        End Try
    End Sub
    Private Sub cmdIOGetLongWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIOGetLongWord.Click
        Try
            Me.txtIOLongWord.Text = objIO.GetLongWordIO(Me.cboIOVariableTypes.SelectedValue, CInt(Me.txtIOLongWordIndex.Text))
        Catch ae As ApplicationException
            DisplayError("I/O Variables", ae.Message)
        Catch ex As Exception
            DisplayError("I/O Variables", ex.Message)
        End Try
    End Sub
#End Region


#Region "Axis 2"
    Private Sub cmdAxis2DataUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAxis2DataUnit.Click
        Try
            objAxis2.SetDataUnit(Me.cboAxis2DataUnit.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("Axis 2", ae.Message)
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdAxis2SubSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAxis2SubSystem.Click
        Try
            objAxis2.SetSubSystem(Me.cboAxis2SubSystem.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("Axis 2", ae.Message)
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdUserParameterDroopDataGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserParameterDroopDataGet.Click
        Try
            txtUserParameterDroopData.Text = objAxis2.GetUserParameterDroopData(cboAxis2UserParameterDroopData.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("Axis 2", ae.Message)
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdUserParameterDroopDataSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserParameterDroopDataSet.Click
        Try
            objAxis2.SetUserParameterDroopData(cboAxis2UserParameterDroopData.SelectedValue, CDbl(txtUserParameterDroopDataInput.Text))
        Catch ae As ApplicationException
            DisplayError("Axis 2", ae.Message)
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdUserParameterDroopDataAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserParameterDroopDataAdd.Click
        Try
            objAxis2.AddUserParameterDroopData(cboAxis2UserParameterDroopData.SelectedValue, CDbl(txtUserParameterDroopDataInput.Text))
        Catch ae As ApplicationException
            DisplayError("Axis 2", ae.Message)
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdUserParameterVariableLimitGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserParameterVariableLimitGet.Click
        Try
            Me.txtUserParameterLimit.Text = objAxis2.GetUserParameterVariableLimit(Me.cboUserParameterVariableLimitCoordinate.SelectedValue, Me.cboUserParameterVariableLimitAxis.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("Axis 2", ae.Message)
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub


    Private Sub cmdUserParameterVariableLimitSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserParameterVariableLimitSet.Click
        Try
            objAxis2.SetUserParameterVariableLimit(Me.cboUserParameterVariableLimitCoordinate.SelectedValue, Me.cboUserParameterVariableLimitAxis.SelectedValue, CDbl(Me.txtUserParameterLimitInput.Text))
        Catch ae As ApplicationException
            DisplayError("Axis 2", ae.Message)
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdUserParameterVariableLimitAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserParameterVariableLimitAdd.Click
        Try
            objAxis2.AddUserParameterVariableLimit(Me.cboUserParameterVariableLimitCoordinate.SelectedValue, Me.cboUserParameterVariableLimitAxis.SelectedValue, CDbl(Me.txtUserParameterLimitInput.Text))
        Catch ae As ApplicationException
            DisplayError("Axis 2", ae.Message)
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub

    'Private Sub cmdBaxisUserParameterVariableLimitGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBaxisUserParameterVariableLimitGet.Click
    '    Try
    '        Me.txtBAxisUserParameterLimit.Text = objAxis2.GetBAxisUserParameterVariableLimit(Me.cboBAxisUserParameterVariableLimitCoordinate.SelectedValue)
    '    Catch ae As ApplicationException
    '        DisplayError("Axis 2", ae.Message)
    '    Catch ex As Exception
    '        DisplayError("Axis 2", ex.Message)
    '    End Try
    'End Sub

    'Private Sub cmdBAxisUserParameterVariableLimitSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBAxisUserParameterVariableLimitSet.Click
    '    Try
    '        objAxis2.SetBAxisUserParameterVariableLimit(Me.cboBAxisUserParameterVariableLimitCoordinate.SelectedValue, CDbl(Me.txtBAxisUserParameterLimitInput.Text))
    '    Catch ae As ApplicationException
    '        DisplayError("Axis 2", ae.Message)
    '    Catch ex As Exception
    '        DisplayError("Axis 2", ex.Message)
    '    End Try
    'End Sub

    'Private Sub cmdBAxisUserParameterVariableLimitAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBAxisUserParameterVariableLimitAdd.Click
    '    Try
    '        objAxis2.AddBAxisUserParameterVariableLimit(Me.cboBAxisUserParameterVariableLimitCoordinate.SelectedValue, CDbl(Me.txtBAxisUserParameterLimitInput.Text))
    '    Catch ae As ApplicationException
    '        DisplayError("Axis 2", ae.Message)
    '    Catch ex As Exception
    '        DisplayError("Axis 2", ex.Message)
    '    End Try
    'End Sub

    'Private Sub cmdBAxisUserParameterDroopDataGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBAxisUserParameterDroopDataGet.Click
    '    Try
    '        txtBAxisUserParameterDroopData.Text = objAxis2.GetBAxisUserParameterDroopData()
    '    Catch ae As ApplicationException
    '        DisplayError("Axis 2", ae.Message)
    '    Catch ex As Exception
    '        DisplayError("Axis 2", ex.Message)
    '    End Try
    'End Sub

    'Private Sub cmdBAxisUserParameterDroopDataSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBAxisUserParameterDroopDataSet.Click
    '    Try
    '        objAxis2.SetBAxisUserParameterDroopData(CDbl(txtBAxisUserParameterDroopDataInput.Text))
    '    Catch ae As ApplicationException
    '        DisplayError("Axis 2", ae.Message)
    '    Catch ex As Exception
    '        DisplayError("Axis 2", ex.Message)
    '    End Try
    'End Sub

    'Private Sub cmdBAxisUserParameterDroopDataAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBAxisUserParameterDroopDataAdd.Click
    '    Try
    '        objAxis2.AddBAxisUserParameterDroopData(CDbl(txtBAxisUserParameterDroopDataInput.Text))
    '    Catch ae As ApplicationException
    '        DisplayError("Axis 2", ae.Message)
    '    Catch ex As Exception
    '        DisplayError("Axis 2", ex.Message)
    '    End Try
    'End Sub

#End Region

#Region "Optional Parameter"
    Private Sub cmdOptionalParameterBitGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOptionalParameterBitGet.Click
        Try
            Me.txtOptionalParameterBit.Text = objOptionalParameter.GetNCOptionalParameterBit(CInt(Me.txtOptionalParameterBitIndex.Text), CInt(Me.txtOptionalParameterBitNo.Text))
        Catch ae As ApplicationException
            DisplayError("Optional Parameter", ae.Message)
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdOptionalParameterWordGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOptionalParameterWordGet.Click
        Try
            txtOptionalParameterWord.Text = objOptionalParameter.GetNCOptionalParameterWord(CInt(Me.txtOptionalParameterWordIndex.Text))
        Catch ae As ApplicationException
            DisplayError("Optional Parameter", ae.Message)
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdOptionalParameterLongWordGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOptionalParameterLongWordGet.Click
        Try
            txtOptionalParameterLongWord.Text = objOptionalParameter.GetNCOptionalParameterLongWord(CInt(Me.txtOptionalParameterLongWordIndex.Text))
        Catch ae As ApplicationException
            DisplayError("Optional Parameter", ae.Message)
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub


    Private Sub cmdBitSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBitSet.Click
        Try
            objOptionalParameter.SetNCOptionalParameterBit(CInt(Me.txtOptionalParameterBitIndex.Text), CInt(Me.txtOptionalParameterBitNo.Text), CBool(txtBitInput.Text))
        Catch ae As ApplicationException
            DisplayError("Optional Parameter", ae.Message)
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdWordSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWordSet.Click
        Try
            objOptionalParameter.SetNCOptionalParameterWord(CInt(Me.txtOptionalParameterWordIndex.Text), CInt(txtWordInput.Text))
        Catch ae As ApplicationException
            DisplayError("Optional Parameter", ae.Message)
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdLongWordSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLongWordSet.Click
        Try
            objOptionalParameter.SetNCOptionalParameterLongWord(CInt(Me.txtOptionalParameterLongWordIndex.Text), CInt(txtLongWordInput.Text))
        Catch ae As ApplicationException
            DisplayError("Optional Parameter", ae.Message)
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdWordAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWordAdd.Click
        Try
            objOptionalParameter.AddNCOptionalParameterWord(CInt(Me.txtOptionalParameterWordIndex.Text), CInt(txtWordInput.Text))
        Catch ae As ApplicationException
            DisplayError("Optional Parameter", ae.Message)
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdLongWordAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLongWordAdd.Click
        Try
            objOptionalParameter.AddNCOptionalParameterLongWord(CInt(Me.txtOptionalParameterLongWordIndex.Text), CInt(txtLongWordInput.Text))
        Catch ae As ApplicationException
            DisplayError("Optional Parameter", ae.Message)
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdOptionalParameterSubSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOptionalParameterSubSystem.Click

        Try

            objOptionalParameter.SetSubSystem(cboOptionalParameterSubSystem.SelectedItem)

        Catch ae As ApplicationException
            DisplayError("Optional Parameter", ae.Message)
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub


#End Region


#Region "Spec Code"
    Private Sub specUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles specUpdateButton.Click
        Dim curSpecEnum As OptionSpecEnum

        Try
            curSpecEnum = Me.specCombo.SelectedValue

            Me.specCode.Text = objSpec.GetOptionSpecCode(curSpecEnum)
            Me.specSaddleSpec.Text = objSpec.Get2SaddleSpec

            txtVersion.Text = objCMDSpec.GetInterfaceVersion()


            txtMachineName.Text = objSpec.GetMachineName()
            txtMachineSerial.Text = objSpec.GetMachineSerialNumber()


        Catch ae As ApplicationException
            DisplayError("CSpec", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CSpec", ex.Message)
        End Try
    End Sub
    Private Sub cmdGetSpecCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetSpecCode.Click
        Try
            txtSpecCode.Text = objSpec.GetSpecCode(CInt(txtSpecCodeIndex.Text), CInt(txtSpecCodeBit.Text))

        Catch ae As ApplicationException
            DisplayError("CSpec", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("CSpec", ne.Message)
        Catch ex As Exception
            DisplayError("CSpec", ex.Message)
        End Try
    End Sub

    Private Sub cmdGetBSpecCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetBSpecCode.Click
        Try
            txtSpecCode.Text = objSpec.GetBSpecCode(CInt(txtSpecCodeIndex.Text), CInt(txtSpecCodeBit.Text))

        Catch ae As ApplicationException
            DisplayError("CSpec", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("CSpec", ne.Message)
        Catch ex As Exception
            DisplayError("CSpec", ex.Message)
        End Try
    End Sub
#End Region


#Region "Current Alarm"


    Private Sub cmdCurrentAlarm_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCurrentAlarm_Update.Click
        Dim objCurrentAlarm As CCurrentAlarm
        Try
            objMachine.SetSubSystem(cboCurrentAlarm_SubSystem.SelectedItem)

            objCurrentAlarm = objMachine.GetCurrentAlarm()

            txtCurrentAlarm_AlarmNumber.Text = objCurrentAlarm.AlarmNumber()
            txtCurrentAlarm_ObjectNumber.Text = objCurrentAlarm.ObjectNumber
            txtCurrentAlarm_ObjectMessage.Text = objCurrentAlarm.ObjectMessage()
            txtCurrentAlarm_AlarmMessage.Text = objCurrentAlarm.AlarmMessage()
            txtCurrentAlarm_AlarmCharacterString.Text = objCurrentAlarm.AlarmCharacterString()
            txtCurrentAlarm_AlarmCode.Text = objCurrentAlarm.AlarmCode()
            txtCurrentAlarm_AlarmLevel.Text = System.Enum.GetName(GetType(OSPAlarmLevelEnum), objCurrentAlarm.AlarmLevel())


        Catch ae As ApplicationException
            DisplayError("Current Alarm", ae.Message)
        Catch ex As Exception
            DisplayError("Current Alarm", ex.Message)
        End Try
    End Sub
#End Region

#Region "Program - 2"
    Private Sub cmdProgram2_SequenceRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProgram2_SequenceRestart.Click
        Try
            objCMDProgram.SequenceRestart(txtProgram2_Sequence.Text, CInt(txtProgram2_OrderNumber.Text))
        Catch ex As Exception
            DisplayError("Program 2", ex.Message)
        End Try
    End Sub
#End Region


#Region "ATC"
    Private Sub atcUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atcUpdate.Click
        Dim potNumber As Int16
        Dim intToolNo As Integer
        Dim intStationNo As Integer
        Dim toolprop As Okuma.CLDATAPI.Structures.ToolProperty

        Try
            potNumber = CInt(txtATCPotNo.Text)
            intToolNo = CInt(Me.txtATCToolNo.Text)
            intStationNo = cboATCTurretStation.SelectedValue

            Me.atcResults.Text = ""

            Me.atcResults.Text += "Tool kind: " & System.Enum.GetNames(GetType(ToolKindEnum)).GetValue(objATC.GetToolKind(potNumber)) & vbCrLf
            Me.atcResults.Text += "Tool number: " & objATC.GetToolNo(potNumber) & vbCrLf
            Me.atcResults.Text += "Tool size: " & System.Enum.GetNames(GetType(ToolSizeEnum)).GetValue(objATC.GetToolSize(potNumber)) & vbCrLf

            Try
                Me.atcResults.Text += "Max pot of main magazine: " & objATC.GetMaxPots(MagazineTypeEnum.MainMagazine).ToString & vbCrLf

            Catch ex As Exception

            End Try
            Try
                Me.atcResults.Text += "Max pot of sub magazine: " & objATC.GetMaxPots(MagazineTypeEnum.SubMagazine).ToString & vbCrLf

            Catch ex As Exception
                Me.atcResults.Text += "Max pot of sub magazine: No Sub Magazine" & vbCrLf
            End Try
            Me.atcResults.Text += "Magazine Property: " & objATC.GetMagazineProperty().ToString & vbCrLf
            toolprop = objATC.GetNextTool()
            Me.atcResults.Text += String.Format("Next Tool: Tool No {0}, Tool Kind {1}, Tool Size {2}", toolprop.intToolNo.ToString, toolprop.enToolKind.ToString, toolprop.enToolSize.ToString) + vbCrLf
            Me.atcResults.Text += "Pot No given Tool No: " & objATC.GetPotNo(intToolNo).ToString() & vbCrLf


            Me.atcResults.Text += "ATC Type: " & objATC.GetATCType().ToString() & vbCrLf

            toolprop = objATC.GetToolInStation(intStationNo)
            Me.atcResults.Text += String.Format("Tool in station: Tool No = {0}, Tool Kind = {1}, Tool Size = {2}", toolprop.intToolNo.ToString, toolprop.enToolKind.ToString, toolprop.enToolSize.ToString) + vbCrLf


            Me.atcResults.Text += "Is Reserved Pot: " & objATC.IsReservedPot(potNumber).ToString & vbCrLf

            Me.atcResults.Text += "Tool in ready station: " & objATC.GetToolInReadyStation().ToString() & vbCrLf

        Catch ae As ApplicationException
            DisplayError("atcUpdate_Click", ae.Message)
        Catch ex As Exception
            DisplayError("atcUpdate_Click", ex.Message)
        End Try



    End Sub


    Private Sub cmdRegisterTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRegisterTool.Click
        Try
            Dim intPotNo As Integer
            Dim intToolNo As Integer
            Dim enToolKind As Okuma.CLCMDAPI.Enumerations.SettingToolKindEnum
            Dim enToolSize As Okuma.CLCMDAPI.Enumerations.SettingToolSizeEnum
            Dim enReturnMagazine As Okuma.CLCMDAPI.Enumerations.ReturnMagazineEnum

            enToolKind = cboATCToolKind.SelectedItem
            enToolSize = cboATCToolSize.SelectedItem
            enReturnMagazine = cboATCReturnMagazine.SelectedItem

            intToolNo = CInt(txtATCToolNo.Text)
            intPotNo = CInt(txtATCPotNo.Text)

            m_objCmdATC.RegisterToolPot(intPotNo, intToolNo, enToolKind, enToolSize, enReturnMagazine)
        Catch ae As ApplicationException
            DisplayError("cmdRegisterTool_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdRegisterTool_Click", ex.Message)
        End Try
    End Sub

    Private Sub cmdATCUnRegisterTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdATCUnRegisterTool.Click
        Try
            Dim intPotNo As Integer
            intPotNo = CInt(txtATCPotNo.Text)

            m_objCmdATC.UnRegisterToolPot(intPotNo)
        Catch ae As ApplicationException
            DisplayError("cmdATCUnRegisterTool_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdATCUnRegisterTool_Click", ex.Message)
        End Try
    End Sub

    Private Sub cmdATCSetToolInStation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdATCSetToolInStation.Click
        Try
            Dim intPotNo As Integer
            Dim intToolNo As Integer
            Dim enToolKind As Okuma.CLCMDAPI.Enumerations.SettingToolKindEnum
            Dim enToolSize As Okuma.CLCMDAPI.Enumerations.SettingToolSizeEnum
            Dim enReturnMagazine As Okuma.CLCMDAPI.Enumerations.ReturnMagazineEnum
            Dim enTurretStation As Okuma.CLCMDAPI.Enumerations.TurretStationEnum

            enToolKind = cboATCToolKind.SelectedItem
            enToolSize = cboATCToolSize.SelectedItem
            enReturnMagazine = cboATCReturnMagazine.SelectedItem
            enTurretStation = cboATCTurretStation.SelectedItem

            intToolNo = CInt(txtATCToolNo.Text)

            m_objCmdATC.SetToolInStation(intToolNo, enToolKind, enToolSize, enReturnMagazine, enTurretStation)
        Catch ae As ApplicationException
            DisplayError("cmdATCSetToolInStation_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdATCSetToolInStation_Click", ex.Message)
        End Try
    End Sub

    Private Sub cmdATCSetNextTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdATCSetNextTool.Click
        Try
            Dim intToolNo As Integer
            Dim enToolKind As Okuma.CLCMDAPI.Enumerations.SettingToolKindEnum
            Dim enToolSize As Okuma.CLCMDAPI.Enumerations.SettingToolSizeEnum
            Dim enReturnMagazine As Okuma.CLCMDAPI.Enumerations.ReturnMagazineEnum

            enToolKind = cboATCToolKind.SelectedItem
            enToolSize = cboATCToolSize.SelectedItem
            enReturnMagazine = cboATCReturnMagazine.SelectedItem


            intToolNo = CInt(txtATCToolNo.Text)


            m_objCmdATC.SetNextTool(intToolNo, enToolKind, enToolSize, enReturnMagazine)
        Catch ae As ApplicationException
            DisplayError("cmdATCSetNextTool_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdATCSetNextTool_Click", ex.Message)
        End Try
    End Sub

 

    Private Sub cmdMagazinePosition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMagazinePosition.Click
        Try
            txtMagazinePosition.Text = objATC.GetMagazinePosition(CInt(txtMagazineNumber.Text)).ToString()
        Catch ae As ApplicationException
            DisplayError("cmdMagazinePosition_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMagazinePosition_Click", ex.Message)
        End Try
    End Sub
#End Region

#Region "Multi-Tools"
#Region "Multi-Tools - Group No"
    Private Sub cmdMultiTool_GroupNoGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_GroupNoGet.Click
        Try
            Dim intEdgeNo As Integer
            Dim enToolHolder As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum
            Dim enMultiEdges As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum

            intEdgeNo = CInt(txt_edgenumber.Text)
            enToolHolder = CInt(cboMultiToolHolder.SelectedValue)
            enMultiEdges = CInt(cboMultiToolEdges.SelectedValue)


            txtMultiTool_GroupNo.Text = m_objMultiTool.GetGroupNo(enToolHolder, enMultiEdges, intEdgeNo).ToString()
        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_GroupNoGet_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_GroupNoGet_Click", ex.Message)
        End Try
    End Sub
    Private Sub cmdMultiTool_GroupNoSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_GroupNoSet.Click
        Try
            Dim intEdgeNo As Integer
            Dim enToolHolder As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum
            Dim enMultiEdges As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum

            intEdgeNo = CInt(txt_edgenumber.Text)
            enToolHolder = CInt(cboMultiToolHolder.SelectedValue)
            enMultiEdges = CInt(cboMultiToolEdges.SelectedValue)


            m_objMultiTool.SetGroupNo(enToolHolder, enMultiEdges, intEdgeNo, CInt(txtMultiTool_GroupNoValue.Text))
        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_GroupNoSet_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_GroupNoSet_Click", ex.Message)
        End Try
    End Sub



#End Region

#Region "Multi-Tools - Tool Life Set"
    Private Sub cmdMultiTool_ToolSetGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolSetGet.Click
        Try
            Dim intEdgeNo As Integer
            Dim enToolHolder As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum
            Dim enMultiEdges As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum
            Dim enToolLifeCondition As Okuma.CLDATAPI.Enumerations.ToolLifeConditionEnum

            intEdgeNo = CInt(txt_edgenumber.Text)
            enToolHolder = CInt(cboMultiToolHolder.SelectedValue)
            enMultiEdges = CInt(cboMultiToolEdges.SelectedValue)
            enToolLifeCondition = CInt(cboMultiToolLifeCondition.SelectedValue)


            txtMultiTool_ToolLifeSet.Text = m_objMultiTool.GetToolLife(enToolLifeCondition, enToolHolder, enMultiEdges, intEdgeNo).ToString()
        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolSetGet_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolSetGet_Click", ex.Message)
        End Try
    End Sub

    Private Sub cmdMultiTool_ToolSetSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolSetSet.Click
        Try
            Dim intEdgeNo As Integer
            Dim enToolHolder As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum
            Dim enMultiEdges As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum
            Dim enToolLifeCondition As Okuma.CLDATAPI.Enumerations.ToolLifeConditionEnum

            intEdgeNo = CInt(txt_edgenumber.Text)
            enToolHolder = CInt(cboMultiToolHolder.SelectedValue)
            enMultiEdges = CInt(cboMultiToolEdges.SelectedValue)
            enToolLifeCondition = CInt(cboMultiToolLifeCondition.SelectedValue)


            m_objMultiTool.SetToolLife(enToolLifeCondition, enToolHolder, enMultiEdges, intEdgeNo, CDbl(txtMultiTool_ToolLifeSetValue.Text))
        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolSetSet_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolSetSet_Click", ex.Message)
        End Try
    End Sub

    Private Sub cmdMultiTool_ToolSetAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolSetAdd.Click
        Try
            Dim intEdgeNo As Integer
            Dim enToolHolder As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum
            Dim enMultiEdges As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum
            Dim enToolLifeCondition As Okuma.CLDATAPI.Enumerations.ToolLifeConditionEnum

            intEdgeNo = CInt(txt_edgenumber.Text)
            enToolHolder = CInt(cboMultiToolHolder.SelectedValue)
            enMultiEdges = CInt(cboMultiToolEdges.SelectedValue)
            enToolLifeCondition = CInt(cboMultiToolLifeCondition.SelectedValue)


            m_objMultiTool.AddToolLife(enToolLifeCondition, enToolHolder, enMultiEdges, intEdgeNo, CDbl(txtMultiTool_ToolLifeSetValue.Text))
        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolSetAdd_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolSetAdd_Click", ex.Message)
        End Try
    End Sub

#End Region

#Region "Multi-Tools - Tool Life Actual"

    Private Sub cmdMultiTool_ToolLifeActualGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolLifeActualGet.Click
        Try
            Dim intEdgeNo As Integer
            Dim enToolHolder As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum
            Dim enMultiEdges As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum
            Dim enToolLifeCondition As Okuma.CLDATAPI.Enumerations.ToolLifeConditionEnum

            intEdgeNo = CInt(txt_edgenumber.Text)
            enToolHolder = CInt(cboMultiToolHolder.SelectedValue)
            enMultiEdges = CInt(cboMultiToolEdges.SelectedValue)
            enToolLifeCondition = CInt(cboMultiToolLifeCondition.SelectedValue)

            txtMultiTool_ToolLifeActual.Text = m_objMultiTool.GetActualToolLife(enToolLifeCondition, enToolHolder, enMultiEdges, intEdgeNo).ToString()
        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolLifeActualGet_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolLifeActualGet_Click", ex.Message)
        End Try
    End Sub

    Private Sub cmdMultiTool_ToolLifeActualSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolLifeActualSet.Click
        Try
            Dim intEdgeNo As Integer
            Dim enToolHolder As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum
            Dim enMultiEdges As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum
            Dim enToolLifeCondition As Okuma.CLDATAPI.Enumerations.ToolLifeConditionEnum

            intEdgeNo = CInt(txt_edgenumber.Text)
            enToolHolder = CInt(cboMultiToolHolder.SelectedValue)
            enMultiEdges = CInt(cboMultiToolEdges.SelectedValue)
            enToolLifeCondition = CInt(cboMultiToolLifeCondition.SelectedValue)

            m_objMultiTool.SetActualToolLife(enToolLifeCondition, enToolHolder, enMultiEdges, intEdgeNo, CDbl(txtMultiTool_ToolLifeActualValue.Text))
        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolLifeActualSet_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolLifeActualSet_Click", ex.Message)
        End Try
    End Sub
    Private Sub cmdMultiTool_ToolLifeActualAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolLifeActualAdd.Click
        Try
            Dim intEdgeNo As Integer
            Dim enToolHolder As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum
            Dim enMultiEdges As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum
            Dim enToolLifeCondition As Okuma.CLDATAPI.Enumerations.ToolLifeConditionEnum

            intEdgeNo = CInt(txt_edgenumber.Text)
            enToolHolder = CInt(cboMultiToolHolder.SelectedValue)
            enMultiEdges = CInt(cboMultiToolEdges.SelectedValue)
            enToolLifeCondition = CInt(cboMultiToolLifeCondition.SelectedValue)


            m_objMultiTool.AddActualToolLife(enToolLifeCondition, enToolHolder, enMultiEdges, intEdgeNo, CDbl(txtMultiTool_ToolLifeActualValue.Text))
        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolLifeActualAdd_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolLifeActualAdd_Click", ex.Message)
        End Try
    End Sub

#End Region

#Region "Multi-Tools - Tool Life Gauge"
    Private Sub cmdMultiTool_ToolGaugeGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolGaugeGet.Click
        Try
            Dim intEdgeNo As Integer
            Dim enToolHolder As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum
            Dim enMultiEdges As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum

            intEdgeNo = CInt(txt_edgenumber.Text)
            enToolHolder = CInt(cboMultiToolHolder.SelectedValue)
            enMultiEdges = CInt(cboMultiToolEdges.SelectedValue)

            txtMultiTool_ToolLifeGauge.Text = m_objMultiTool.GetGaugeStatus(enToolHolder, enMultiEdges, intEdgeNo).ToString()

        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolGaugeGet_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolGaugeGet_Click", ex.Message)
        End Try
    End Sub
    Private Sub cmdMultiTool_ToolGaugeSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolGaugeSet.Click
        Try
            Dim intEdgeNo As Integer
            Dim enToolHolder As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum
            Dim enMultiEdges As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum

            intEdgeNo = CInt(txt_edgenumber.Text)
            enToolHolder = CInt(cboMultiToolHolder.SelectedValue)
            enMultiEdges = CInt(cboMultiToolEdges.SelectedValue)

            m_objMultiTool.SetGaugeStatus(enToolHolder, enMultiEdges, intEdgeNo, CInt(txtMultiTool_ToolLifeGaugeValue.Text))
        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolGaugeSet_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolGaugeSet_Click", ex.Message)
        End Try
    End Sub

#End Region

#Region "Multi-Tools - Tool Life"
    Private Sub cmdMultiTool_ToolLifeStatusGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolLifeStatusGet.Click
        Try
            Dim intEdgeNo As Integer
            Dim enToolHolder As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum
            Dim enMultiEdges As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum

            intEdgeNo = CInt(txt_edgenumber.Text)
            enToolHolder = CInt(cboMultiToolHolder.SelectedValue)
            enMultiEdges = CInt(cboMultiToolEdges.SelectedValue)

            txtMultiTool_ToolLifeStatus.Text = m_objMultiTool.GetLifeStatus(enToolHolder, enMultiEdges, intEdgeNo).ToString()

        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolLifeStatusGet_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolLifeStatusGet_Click", ex.Message)
        End Try
    End Sub
    Private Sub cmdMultiTool_ToolLifeStatusSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolLifeStatusSet.Click
        Try
            Dim intEdgeNo As Integer
            Dim enToolHolder As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum
            Dim enMultiEdges As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum

            intEdgeNo = CInt(txt_edgenumber.Text)
            enToolHolder = CInt(cboMultiToolHolder.SelectedValue)
            enMultiEdges = CInt(cboMultiToolEdges.SelectedValue)

            m_objMultiTool.SetLifeStatus(enToolHolder, enMultiEdges, intEdgeNo, CInt(txtMultiTool_ToolLifeStatusValue.Text))

        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolLifeStatusSet_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolLifeStatusSet_Click", ex.Message)
        End Try
    End Sub
#End Region

#Region "Multi-Tools - Tool In Group"
    Private Sub cmdMultiTool_ToolInGroupGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolInGroupGet.Click
        Try
            Dim intGroupNo As Integer

            intGroupNo = CInt(txtMultiTool_GroupNoInput.Text)
            txtMultiTool_ToolInGroup.Text = m_objMultiTool.GetToolNumberInGroup2(intGroupNo).ToString()

        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolInGroupGet_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolInGroupGet_Click", ex.Message)
        End Try
    End Sub
    Private Sub cmdMultiTool_ToolInGroupSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolInGroupSet.Click
        Try
            Dim intGroupNo As Integer

            intGroupNo = CInt(txtMultiTool_GroupNoInput.Text)
            m_objMultiTool.SetToolNumberInGroup2(intGroupNo, CInt(txtMultiTool_ToolInGroupValue.Text))

        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolInGroupSet_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolInGroupSet_Click", ex.Message)
        End Try
    End Sub

#End Region


#Region "Multi-Tools - Group Edge"
    Private Sub cmdMultiTool_GroupEdgeGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_GroupEdgeGet.Click
        Try
            Dim intGroupNo As Integer

            intGroupNo = CInt(txtMultiTool_GroupNoInput.Text)
            txtMultiTool_GroupEdge.Text = m_objMultiTool.GetCurrentEdge(intGroupNo).ToString()

        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_GroupEdgeGet_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_GroupEdgeGet_Click", ex.Message)
        End Try
    End Sub
    Private Sub cmdMultiTool_GroupEdgeSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_GroupEdgeSet.Click
        Try
            Dim intGroupNo As Integer

            intGroupNo = CInt(txtMultiTool_GroupNoInput.Text)
            m_objMultiTool.SetCurrentEdge(intGroupNo, CInt(txtMultiTool_GroupEdgeValue.Text))

        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_GroupEdgeSet_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_GroupEdgeSet_Click", ex.Message)
        End Try
    End Sub

#End Region

#Region "Multi-Tools - Tool Group Life"
    Private Sub cmdMultiTool_ToolGroupLifeGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolGroupLifeGet.Click
        Try
            Dim intGroupNo As Integer

            intGroupNo = CInt(txtMultiTool_GroupNoInput.Text)
            txtMultiTool_ToolGroupLife.Text = m_objMultiTool.GetGroupToolLifeStatus2(intGroupNo).ToString()

        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolGroupLifeSet_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolGroupLifeSet_Click", ex.Message)
        End Try
    End Sub

    Private Sub cmdMultiTool_ToolGroupLifeSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolGroupLifeSet.Click
        Try
            Dim intGroupNo As Integer

            intGroupNo = CInt(txtMultiTool_GroupNoInput.Text)
            m_objMultiTool.SetGroupToolLifeStatus2(intGroupNo, CInt(txtMultiTool_ToolGroupLifeValue.Text))

        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolGroupLifeSet_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolGroupLifeSet_Click", ex.Message)
        End Try
    End Sub

#End Region

#Region "Multi-Tools - Entry Tool No"
    Private Sub cmdMultiTool_EntryToolNoGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_EntryToolNoGet.Click
        Try
            Dim intGroupNo As Integer
            Dim intEntryToolNo As Integer

            intGroupNo = CInt(txtMultiTool_GroupNoInput.Text)
            intEntryToolNo = CInt(txtMultiTool_EntryToolNoInput.Text)
            txtMultiTool_EntryToolNo.Text = m_objMultiTool.GetToolGroupEntry2(intGroupNo, intEntryToolNo).ToString()

        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_EntryToolNoGet_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_EntryToolNoGet_Click", ex.Message)
        End Try
    End Sub


#End Region


#Region "Multi-Tools - Reference Tool Offset 1"
    Private Sub cmdMultiTool_ToolRef1Get_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolRef1Get.Click
        Try
            Dim intEdgeNo As Integer
            Dim enToolHolder As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum
            Dim enMultiEdges As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum

            intEdgeNo = CInt(txt_edgenumber.Text)
            enToolHolder = CInt(cboMultiToolHolder.SelectedValue)
            enMultiEdges = CInt(cboMultiToolEdges.SelectedValue)
            txtMultiTool_ToolRef1.Text = m_objMultiTool.GetReferenceToolOffset1(enToolHolder, enMultiEdges, intEdgeNo).ToString()

        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolRef1Get_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolRef1Get_Click", ex.Message)
        End Try
    End Sub
    Private Sub cmdMultiTool_ToolRef1Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolRef1Set.Click
        Try
            Dim intEdgeNo As Integer
            Dim enToolHolder As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum
            Dim enMultiEdges As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum

            intEdgeNo = CInt(txt_edgenumber.Text)
            enToolHolder = CInt(cboMultiToolHolder.SelectedValue)
            enMultiEdges = CInt(cboMultiToolEdges.SelectedValue)
            m_objMultiTool.SetReferenceToolOffset1(enToolHolder, enMultiEdges, intEdgeNo, CInt(txtMultiTool_ToolRef1Value.Text))

        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolRef1Set_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolRef1Set_Click", ex.Message)
        End Try
    End Sub
#End Region
#Region "Multi-Tools - Reference Tool Offset 2"
    Private Sub cmdMultiTool_ToolRef2Get_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolRef2Get.Click
        Try
            Dim intEdgeNo As Integer
            Dim enToolHolder As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum
            Dim enMultiEdges As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum

            intEdgeNo = CInt(txt_edgenumber.Text)
            enToolHolder = CInt(cboMultiToolHolder.SelectedValue)
            enMultiEdges = CInt(cboMultiToolEdges.SelectedValue)
            txtMultiTool_ToolRef2.Text = m_objMultiTool.GetReferenceToolOffset2(enToolHolder, enMultiEdges, intEdgeNo).ToString()

        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolRef2Get_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolRef2Get_Click", ex.Message)
        End Try
    End Sub
    Private Sub cmdMultiTool_ToolRef2Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolRef2Set.Click
        Try
            Dim intEdgeNo As Integer
            Dim enToolHolder As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum
            Dim enMultiEdges As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum

            intEdgeNo = CInt(txt_edgenumber.Text)
            enToolHolder = CInt(cboMultiToolHolder.SelectedValue)
            enMultiEdges = CInt(cboMultiToolEdges.SelectedValue)
            m_objMultiTool.SetReferenceToolOffset2(enToolHolder, enMultiEdges, intEdgeNo, CInt(txtMultiTool_ToolRef2Value.Text))

        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolRef2Set_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolRef2Set_Click", ex.Message)
        End Try
    End Sub
#End Region
#Region "Multi-Tools - Reference Tool Offset 3"


    Private Sub cmdMultiTool_ToolRef3Get_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolRef3Get.Click
        Try
            Dim intEdgeNo As Integer
            Dim enToolHolder As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum
            Dim enMultiEdges As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum

            intEdgeNo = CInt(txt_edgenumber.Text)
            enToolHolder = CInt(cboMultiToolHolder.SelectedValue)
            enMultiEdges = CInt(cboMultiToolEdges.SelectedValue)
            txtMultiTool_ToolRef3.Text = m_objMultiTool.GetReferenceToolOffset3(enToolHolder, enMultiEdges, intEdgeNo).ToString()

        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolRef3Get_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolRef3Get_Click", ex.Message)
        End Try
    End Sub
    Private Sub cmdMultiTool_ToolRef3Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMultiTool_ToolRef3Set.Click
        Try
            Dim intEdgeNo As Integer
            Dim enToolHolder As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolHolderEnum
            Dim enMultiEdges As Okuma.CLDATAPI.Enumerations.MultiEdgesAngleToolEnum

            intEdgeNo = CInt(txt_edgenumber.Text)
            enToolHolder = CInt(cboMultiToolHolder.SelectedValue)
            enMultiEdges = CInt(cboMultiToolEdges.SelectedValue)
            m_objMultiTool.SetReferenceToolOffset3(enToolHolder, enMultiEdges, intEdgeNo, CInt(txtMultiTool_ToolRef3Value.Text))

        Catch ae As ApplicationException
            DisplayError("cmdMultiTool_ToolRef3Set_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdMultiTool_ToolRef3Set_Click", ex.Message)
        End Try
    End Sub
#End Region
#End Region

#Region " Tool Standard"
    Private Sub tulUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulUpdateButton.Click
        Updatetools()
    End Sub

    Public Sub Updatetools()
        On Error GoTo sd

        Dim toolNum As Int16
        Dim intGroupNo As Int32

        toolNum = CInt(Me.tulToolNumber.Text)

        Me.tulCurrentNoseRCompNumber.Text = objTool.GetCurrentNoseRCompNumber
        Me.tulCurrentToolNumber.Text = objTool.GetCurrentToolNumber
        Me.tulCurrentToolOffsetNumber.Text = objTool.GetCurrentToolOffsetNumber
        Me.tulGauseStatus.Text = System.Enum.GetNames(GetType(ToolGaugeStatusEnum)).GetValue(objTool.GetGaugeStatus(toolNum))
        Me.tulGroupNumber.Text = objTool.GetGroupNo(toolNum)
        Me.tulLifeStatus.Text = objTool.GetLifeStatus(toolNum)
        Me.tulMaxToolOffset.Text = objTool.GetMaxToolOffset

        Me.tulReferenceToolOffset1.Text = objTool.GetReferenceToolOffset1(toolNum)
        Me.tulReferenceToolOffset2.Text = objTool.GetReferenceToolOffset2(toolNum)
        Me.tulReferenceToolOffset3.Text = objTool.GetReferenceToolOffset3(toolNum)                                                                        'etReferenceToolOffset3(toolNum)
        'Me.tulUpdLifeStatus.DataSource = System.Enum.GetNames(GetType(ToolLifeStatusEnum)).GetValue(objTool.GetLifeStatus(toolNum))
        Me.tulToolLife.Text = objTool.GetToolLife(Me.tulComboToolLife.SelectedValue, CInt(toolNum))
        Me.tulActualToolLife.Text = objTool.GetActualToolLife(Me.tulComboActualToolLife.SelectedValue, CInt(toolNum))
        Me.tulToolWearOffset.Text = objTool.GetToolWearOffset(toolNum, Me.tulComboToolWearOffset.SelectedValue)

        Me.TulNoseRCompensation.Text = objTool.GetNoseRCompensation(toolNum, Me.TulComboNoseRCompensation.SelectedValue)
        'Me.TulNoseRCompensationPattern.Text = objTool.GetNoseRCompensationPattern(CInt(Me.TulNoseRCompensationPatternFrom.Text), CInt(Me.TulNoseRCompensationPatternTo.Text))
        Me.tulToolOffset.Text = objTool.GetToolOffset(toolNum, Me.tulComboToolOffset.SelectedValue)

        Exit Sub
sd:
        DisplayError("CTool", Err.Description)
        Resume Next
    End Sub

    Private Sub cmdToolEntryNoGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolEntryNoGet.Click
        Try
            Dim intGroupNo As Integer
            Dim intEntryNo As Integer
            intEntryNo = CInt(Me.txtTool2EntryToolIndex.Text)
            intGroupNo = CInt(Me.txtTool2GroupNoInput.Text)

            Me.txtTool2EntryNo.Text = objTool.GetToolGroupEntry(intGroupNo, intEntryNo).ToString()

        Catch ae As ApplicationException
            DisplayError("cmdToolEntryNoGet_Click", ae.Message)
        Catch ex As Exception
            DisplayError("cmdToolEntryNoGet_Click", ex.Message)
        End Try
    End Sub

#End Region



    Private Sub Tab_IO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab_IO.SelectedIndexChanged

    End Sub
End Class
