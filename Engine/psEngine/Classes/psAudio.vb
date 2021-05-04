Imports System.Runtime.InteropServices
Imports Microsoft.DirectX

Public Class psAudio

#Region "MP3"
    Structure psAudioBuffer
        Dim Name As String
        Dim Audio As AudioVideoPlayback.Audio
    End Structure

    Dim Audios() As psAudioBuffer
    Dim WithEvents Audio As AudioVideoPlayback.Audio

    Private Sub PlayMP3(ByVal Filename As String, ByVal Volume As Integer)
        If Compiled Then Filename = GetRelativeFile(Filename)
        Dim i As Integer
        If Not (Audios Is Nothing) Then
            For i = 1 To UBound(Audios)
                If Audios(i).Name = Filename AndAlso Not Audios(i).Audio.Disposed Then Exit For
            Next
        End If
        Volume = (100 - Volume) * -100
        Try
            If i = 0 Then
                Audio = New AudioVideoPlayback.Audio(Filename)
            Else
                Audio = Audios(i).Audio
            End If
            Audio.Volume = Volume
            Audio.Play()
        Catch
        End Try
    End Sub

    Private Sub StopMP3()
        If Audio Is Nothing Then Exit Sub
        If Audio.Disposed Then Exit Sub
        Audio.Stop()
    End Sub

    Private Sub PauseMP3()
        If Audio Is Nothing Then Exit Sub
        If Audio.Disposed Then Exit Sub
        Audio.Pause()
    End Sub

    Private Sub ResumeMP3()
        If Audio Is Nothing Then Exit Sub
        If Audio.Disposed Then Exit Sub
        Audio.Play()
    End Sub

    Private Sub Audio_Ending(ByVal sender As Object, ByVal e As System.EventArgs) Handles Audio.Ending
        Audio.SeekCurrentPosition(0, AudioVideoPlayback.SeekPositionFlags.AbsolutePositioning)
        Audio.Play()
    End Sub

    Sub DisposeMP3()
        If Not Audio Is Nothing AndAlso Not Audio.Disposed Then
            Audio.Dispose()
        End If
    End Sub

    Sub OnLoad()
        If DataOnly Then Exit Sub

        'Preload audio files
        Dim MP3Files As New ArrayList
        Try
            For i As Integer = 1 To UBound(Game.maps)
                If Game.maps(i).Music <> "" AndAlso Game.maps(i).Music.EndsWith(".mp3") Then MP3Files.Add(Game.maps(i).Music)
            Next
            For i As Integer = 1 To UBound(Game.windows.Windows)
                If Game.windows.Windows(i).Music <> "" AndAlso Game.windows.Windows(i).Music.EndsWith(".mp3") Then MP3Files.Add(Game.windows.Windows(i).Music)
            Next
            Dim tmpStart As Integer
            Dim tmpCode As String = Game.Code
            Dim tmpFile As String
            Do
                tmpStart = tmpCode.IndexOf(".mp3""", tmpStart + 1)
                If tmpStart = -1 Then Exit Do
                For i As Integer = tmpStart To 1 Step -1
                    If tmpCode.Chars(i) = """" Then
                        tmpFile = tmpCode.Substring(i + 1, tmpStart - i + 3)
                        If MP3Files.Contains(tmpFile) = False Then
                            MP3Files.Add(tmpFile)
                        End If
                        Exit For
                    End If
                Next
            Loop Until tmpStart = -1
        Catch
        End Try

        ReDim Audios(0)
        For i As Integer = 0 To MP3Files.Count - 1
            ReDim Preserve Audios(UBound(Audios) + 1)
            Audios(UBound(Audios)).Name = GetRelativeFile(MP3Files(i))
            Try
                Audios(UBound(Audios)).Audio = New AudioVideoPlayback.Audio(GetRelativeFile(MP3Files(i)))
            Catch
            End Try
        Next
    End Sub
#End Region

#Region "Sound"
    Structure psSoundBuffer
        Dim buffer As DirectSound.Buffer
        Dim Used As Boolean
        Dim StartTime As Single
        Dim Filename As String
    End Structure

    Private Device As DirectSound.Device
    Private Sound() As psSoundBuffer
    Const MaxSounds As Byte = 100

    Sub Init()
        Try
            Device = New DirectSound.Device
            Device.SetCooperativeLevel(Game.p, DirectSound.CooperativeLevel.Normal)
            ReDim Sound(100)
        Catch
        End Try
    End Sub

    Sub PlaySound(ByVal Filename As String, Optional ByVal Volume As Integer = 100, Optional ByVal Pan As Integer = 0, Optional ByVal Frequency As Integer = 22)
        If Compiled Then Filename = GetRelativeFile(Filename)

        Volume = (100 - Volume) * -100
        Pan *= 100
        Frequency *= 1000

        'Find a unused sound buffer, or stop the sound
        'that was played the earliest
        Dim FirstSound As Single = Timer
        Dim FirstSoundIndex As Byte
        Dim i As Byte
        For i = 1 To MaxSounds
            If Sound(i).Used = False Then
                GoTo FoundASound
            Else
                If Not Sound(i).buffer.Status.Playing Then
                    GoTo FoundASound
                End If
                If Sound(i).StartTime < FirstSound Then
                    FirstSound = Sound(i).StartTime
                    FirstSoundIndex = i
                End If
            End If
        Next
        i = FirstSoundIndex
FoundASound:

        Try
            If Sound(i).Filename <> Filename Then
                'Destroy the current buffer
                If Not (Sound(i).buffer Is Nothing) Then
                    Sound(i).buffer.Dispose()
                    Sound(i).buffer = Nothing
                End If

                'Load the sound
                Dim fmt As DirectSound.WaveFormat
                Dim desc As New DirectSound.BufferDescription(fmt)
                desc.ControlVolume = True
                desc.ControlFrequency = True
                desc.ControlPan = True
                Sound(UBound(Sound)).buffer = New DirectSound.Buffer(Filename, desc, Device)
            End If
DoneLoading:
            With Sound(UBound(Sound))
                .Used = True
                .Filename = Filename

                'Set options
                .buffer.Volume = Volume
                .buffer.Pan = Pan
                .buffer.Frequency = Frequency

                'Play the sound
                .buffer.Play(0, DirectSound.BufferPlayFlags.Default)
                .StartTime = Timer
            End With
        Catch ex As Exception
            MessageBox.Show(String.Format(GetString("error_LoadSounds"), Filename, ex.Message), GetString("error_LoadSoundsTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub StopSounds()
        If Sound Is Nothing Then Return
        For i As Integer = 1 To MaxSounds
            If (i < Sound.Length) Then
                If Sound(i).Used Then
                    Try
                        Sound(i).buffer.Stop()
                    Catch
                    End Try
                End If
            End If
        Next
    End Sub
#End Region

    Dim PlayingMIDI As Boolean
    Dim MIDIFilename As String
    Dim LoadingMIDI As Boolean
    Dim CurMusic As String

    Sub PlayMusic(ByVal Filename As String, ByVal Volume As Integer)
        Try
            If Compiled Then Filename = GetRelativeFile(Filename)
            If Filename = CurMusic Then Exit Sub
            StopMIDI()
            StopMP3()
            If Not (MIDI Is Nothing) Then MIDI.CloseFile()
            If Filename Is Nothing OrElse Filename = "" Then Exit Sub
            If Filename.ToLower.EndsWith(".mid") Then
                PlayingMIDI = True
                MIDIFilename = Filename
                LoadingMIDI = True
                PlayMIDI(Filename)
            Else
                PlayingMIDI = False
                PlayMP3(Filename, Volume)
            End If
            CurMusic = Filename
        Catch
        End Try
    End Sub

    Sub PlayMusicNow(ByVal Filename As String, ByVal Volume As Integer)
        PlayMusic(Filename, Volume)
    End Sub

    Sub StopMusic()
        If PlayingMIDI Then
            Try
                StopMIDI()
            Catch
            End Try
        Else
            StopMP3()
        End If
        CurMusic = ""
    End Sub

    Sub PauseMusic()
        If PlayingMIDI Then
            PauseMIDI()
        Else
            PauseMP3()
        End If
    End Sub

    Sub ResumeMusic()
        If PlayingMIDI Then
            ResumeMIDI()
        Else
            ResumeMP3()
        End If
    End Sub

    Private Sub NewMIDIEvent(ByVal type As MIDIEventType, Optional ByVal param As String = "")
        If MIDIEvents Is Nothing OrElse MIDIEvents.Length = 0 Then ReDim MIDIEvents(0)
        ReDim Preserve MIDIEvents(UBound(MIDIEvents) + 1)
        MIDIEvents(UBound(MIDIEvents)).Type = type
        MIDIEvents(UBound(MIDIEvents)).param = param
    End Sub

#Region "MIDI"
    Private Sub LoadMIDI(ByVal Filename As String)
        MIDI = New MidiFile(Filename)
    End Sub

    Private Sub PlayMIDI(ByVal Filename As String)
        Try
            LoadMIDI(Filename)
            MIDI.Play()
        Catch
        End Try
    End Sub

    Private Sub PauseMIDI()
        If MIDI Is Nothing Then Exit Sub
        Try
            MIDI.Paused = True
        Catch
        End Try
    End Sub

    Private Sub ResumeMIDI()
        If MIDI Is Nothing Then Exit Sub
        Try
            MIDI.Paused = False
        Catch
        End Try
    End Sub

    Private Sub StopMIDI()
        If MIDI Is Nothing Then Exit Sub
        LoadingMIDI = False
        Try
            MIDI.StopPlay()
            MIDI.CloseFile()
        Catch
        End Try
    End Sub

    Sub UpdateMusic()
        If PlayingMIDI Then
            Try
                If MIDI.Position >= MIDI.Length Then
                    MIDI.Position = 0
                    MIDI.Play()
                End If
            Catch
            End Try
        End If
    End Sub

    '
    '    MidiFile class
    '      written in VB.NET                          Version: 1.0
    '      by The KPD-Team                            Date: 2002/02/02
    '      Copyright © 2002                           Comments to: KPDTeam@allapi.net
    '                                                 URL: http://www.allapi.net/
    '
    '
    '   You are free to use this class file in your own applications,
    '   but you are expressly forbidden from selling or otherwise
    '   distributing this code as source without prior written consent.
    '   This includes both posting samples on a web site or otherwise
    '   reproducing it in text or html format.
    '
    '   Although much care has gone into the programming of this class
    '   file, The KPD-Team does not accept any responsibility for damage
    '   caused by possible errors in this class and/or by misuse of this
    '   class.
    '

    'Imports System
    'Imports System.IO
    'Imports System.Text


    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    Public Structure MCI_OPEN_PARMS
        Public dwCallback As Integer
        Public wDeviceID As Integer
        Public lpstrDeviceType As String
        Public lpstrElementName As String
        Public lpstrAlias As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
    Public Structure MCI_PLAY_PARMS
        Public dwCallback As Integer
        Public dwFrom As Integer
        Public dwTo As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
    Public Structure MCI_STATUS_PARMS
        Public dwCallback As Integer
        Public dwReturn As Integer
        Public dwItem As Integer
        Public dwTrack As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
    Public Structure MCI_SEQ_SET_PARMS
        Public dwCallback As Integer
        Public dwTimeFormat As Integer
        Public dwAudio As Integer
        Public dwTempo As Integer
        Public dwPort As Integer
        Public dwSlave As Integer
        Public dwMaster As Integer
        Public dwOffset As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
    Public Structure MCI_SEEK_PARMS
        Public dwCallback As Integer
        Public dwTo As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
    Public Structure MCI_GENERIC_PARMS
        Public dwCallback As Integer
    End Structure

    ''' <summary>This is an abstract representation of a MIDI file.</summary>
    Public Class MidiFile
        Private Const MCI_OPEN As Integer = &H803
        Private Const MCI_OPEN_TYPE As Integer = &H2000
        Private Const MCI_OPEN_ELEMENT As Integer = &H200
        Private Const MCI_CLOSE As Integer = &H804
        Private Const MCI_PLAY As Integer = &H806
        Private Const MCI_PAUSE As Integer = &H809
        Private Const MCI_RESUME As Integer = &H855
        Private Const MCI_STOP As Integer = &H808
        Private Const MCI_STATUS As Integer = &H814
        Private Const MCI_WAIT As Integer = &H2
        Private Const MCI_SEEK As Integer = &H807
        Private Const MCI_TO As Integer = &H8
        Private Const MCI_STATUS_ITEM As Integer = &H100
        Private Const MCI_STATUS_LENGTH As Integer = &H1
        Private Const MCI_STATUS_POSITION As Integer = &H2
        Private Const MCI_STATUS_MODE As Integer = &H4
        Private Const MCI_STRING_OFFSET As Integer = 512
        Private Const MCI_MODE_PAUSE As Integer = (MCI_STRING_OFFSET + 17)
        Private Const MCI_MODE_PLAY As Integer = (MCI_STRING_OFFSET + 14)
        Private Declare Ansi Function mciSendCommand Lib "winmm.dll" Alias "mciSendCommandA" (ByVal wDeviceID As Integer, ByVal uMessage As Integer, ByVal dwParam1 As Integer, ByVal dwParam2 As IntPtr) As Integer
        Private Declare Ansi Function mciSendCommandOpen Lib "winmm.dll" Alias "mciSendCommandA" (ByVal wDeviceID As Integer, ByVal uMessage As Integer, ByVal dwParam1 As Integer, ByRef dwParam2 As MCI_OPEN_PARMS) As Integer
        Private Declare Ansi Function mciSendCommandStatus Lib "winmm.dll" Alias "mciSendCommandA" (ByVal wDeviceID As Integer, ByVal uMessage As Integer, ByVal dwParam1 As Integer, ByRef dwParam2 As MCI_STATUS_PARMS) As Integer
        Private Declare Ansi Function mciSendCommandSeek Lib "winmm.dll" Alias "mciSendCommandA" (ByVal wDeviceID As Integer, ByVal uMessage As Integer, ByVal dwParam1 As Integer, ByRef dwParam2 As MCI_SEEK_PARMS) As Integer
        Private Declare Ansi Function mciSendCommandGeneric Lib "winmm.dll" Alias "mciSendCommandA" (ByVal wDeviceID As Integer, ByVal uMessage As Integer, ByVal dwParam1 As Integer, ByRef dwParam2 As MCI_GENERIC_PARMS) As Integer

        ''' <summary>Constructs a new MifiFile object.</summary>
        ''' <param name="Filename">The MIDI file to load.</param>
        ''' <exceptions cref="ArgumentNullException">Thrown when the specified Filename parameter is null (VB.NET: Nothing).</exceptions>
        Public Sub New(ByVal Filename As String)
            If Filename Is Nothing Then
                Throw New ArgumentNullException
            End If
            m_Filename = Filename
            OpenFile()
        End Sub

        ''' <summary>Starts playing the MIDI file.</summary>
        ''' <exceptions cref="MediaException">Thrown when an error occured while playing the file.</exceptions>
        Public Sub Play()
            If Playing Then Exit Sub
            If mciSendCommand(DeviceID, MCI_PLAY, 0, IntPtr.Zero) <> 0 Then
                Throw New MediaException(GetString("error_MIDIError"))
            End If
        End Sub

        ''' <summary>Stops the playback of the MIDI file.</summary>
        ''' <exceptions cref="MediaException">Thrown when an error occured while trying to stop the playback of the file.</exceptions>
        Public Sub StopPlay()
            If Playing Then
                If mciSendCommand(DeviceID, MCI_STOP, 0, IntPtr.Zero) <> 0 Then
                    Throw New MediaException(GetString("error_MIDIError"))
                End If
            End If
            Position = 0
        End Sub

        ''' <summary>Specifies whether the MIDI file is currently paused or not.</summary>
        ''' <value>True when the file is paused, False otherwise.</value>
        Public Property Paused() As Boolean
            Get
                Dim mciStatusParms As New MCI_STATUS_PARMS
                mciStatusParms.dwItem = MCI_STATUS_MODE
                If mciSendCommandStatus(DeviceID, MCI_STATUS, MCI_WAIT Or MCI_STATUS_ITEM, mciStatusParms) <> 0 Then
                    Throw New MediaException(GetString("error_MIDIError"))
                End If
                Return (mciStatusParms.dwReturn = MCI_MODE_PAUSE)
            End Get
            Set(ByVal Value As Boolean)
                Dim mciGenericParms As New MCI_GENERIC_PARMS
                If Value Then
                    If mciSendCommandGeneric(DeviceID, MCI_PAUSE, MCI_WAIT, mciGenericParms) <> 0 Then
                        Throw New MediaException(GetString("error_MIDIError"))
                    End If
                Else
                    Play()
                End If
            End Set
        End Property

        ''' <summary>Gets the name of the MIDI file.</summary>
        ''' <value>The name of the MIDI file.</value>
        Public ReadOnly Property Filename() As String
            Get
                Return m_Filename
            End Get
        End Property

        ''' <summary>Gets the length of the MIDI file.</summary>
        ''' <value>The length of the MIDI file.</value>
        Public ReadOnly Property Length() As Integer
            Get
                Return m_Length
            End Get
        End Property

        ''' <summary>Specifies whether the MIDI file is currently playing.</summary>
        ''' <value>True if the MIDI file is currently playing, False otherwise.</value>
        Public ReadOnly Property Playing() As Boolean
            Get
                Dim mciStatusParms As New MCI_STATUS_PARMS
                mciStatusParms.dwItem = MCI_STATUS_MODE
                If mciSendCommandStatus(DeviceID, MCI_STATUS, MCI_WAIT Or MCI_STATUS_ITEM, mciStatusParms) <> 0 Then
                    Throw New MediaException(GetString("error_MIDIError"))
                End If
                Return (mciStatusParms.dwReturn = MCI_MODE_PLAY)
            End Get
        End Property

        ''' <summary>Specifies the position in the MIDI file.</summary>
        ''' <value>The position in the MIDI file.</value>
        Public Property Position() As Integer
            Get
                Dim mciStatusParms As New MCI_STATUS_PARMS
                mciStatusParms.dwItem = MCI_STATUS_POSITION
                If mciSendCommandStatus(DeviceID, MCI_STATUS, MCI_WAIT Or MCI_STATUS_ITEM, mciStatusParms) <> 0 Then
                    Throw New MediaException(GetString("error_MIDIError"))
                End If
                Return mciStatusParms.dwReturn
            End Get
            Set(ByVal Value As Integer)
                Dim WasPLaying As Boolean = True 'CHANGED FROM Playing
                Dim mciSeekParms As New MCI_SEEK_PARMS
                mciSeekParms.dwTo = Value
                If mciSendCommandSeek(DeviceID, MCI_SEEK, MCI_WAIT Or MCI_TO, mciSeekParms) <> 0 Then
                    Throw New MediaException(GetString("error_MIDIError"))
                End If
                If WasPLaying Then ' MCI stops playback when seeking to a new position
                    Play()  ' so we must manually restart it
                End If
            End Set
        End Property

        ''' <summary>Specifies the ID of the opened MIDI device.</summary>
        ''' <remarks>Used interally only.</remarks>
        ''' <value>The ID of the opened MIDI device.</value>
        Protected Property DeviceID() As Integer
            Get
                Return m_DeviceID
            End Get
            Set(ByVal Value As Integer)
                m_DeviceID = Value
            End Set
        End Property

        ''' <summary>Called when the class gets GCed.</summary>
        Protected Overrides Sub Finalize()
            CloseFile()
        End Sub

        ''' <summary>Opens a MIDI file.</summary>
        ''' <remarks>Used interally only.</remarks>
        ''' <exceptions cref="MediaException">Thrown when there was an error opening the file.</exceptions>
        ''' <exceptions cref="FileNotFoundException">Thrown when the specified file could not be found.</exceptions>
        Protected Sub OpenFile()
            If Not IO.File.Exists(Filename) Then
                Throw New IO.FileNotFoundException
            End If
            Dim mciOpenParms As New MCI_OPEN_PARMS
            mciOpenParms.lpstrDeviceType = "sequencer"
            mciOpenParms.lpstrElementName = Filename
            If mciSendCommandOpen(0, MCI_OPEN, MCI_OPEN_TYPE Or MCI_OPEN_ELEMENT, mciOpenParms) <> 0 Then
                Throw New MediaException(GetString("error_MIDIDevice"))
            End If
            ' The device opened successfully; get the device ID.
            DeviceID = mciOpenParms.wDeviceID
            ' Get the length of the MIDI file
            Dim mciStatusParms As New MCI_STATUS_PARMS
            mciStatusParms.dwItem = MCI_STATUS_LENGTH
            If mciSendCommandStatus(DeviceID, MCI_STATUS, MCI_WAIT Or MCI_STATUS_ITEM, mciStatusParms) <> 0 Then
                Throw New MediaException(GetString("error_MIDIError"))
            End If
            m_Length = mciStatusParms.dwReturn
        End Sub

        ''' <summary>Used internally to close a wave file and free the used memory.</summary>
        Public Sub CloseFile()
            mciSendCommand(DeviceID, MCI_CLOSE, 0, IntPtr.Zero)
        End Sub

        ' Private variables
        Private m_Filename As String
        Private mciPlayParms As New MCI_PLAY_PARMS
        Private mciSeqSetParms As New MCI_SEQ_SET_PARMS
        Private m_DeviceID As Integer
        Private m_Length As Integer
    End Class

    ''' <summary>
    ''' The exception that is thrown when an error occurs while opening and/or playing a WAVE file.
    ''' </summary>
    Public Class MediaException
        Inherits Exception

        ''' <summary>Constructs a new MediaException object.</summary>
        ''' <param name="Message">Specifies the error message.</param>
        Public Sub New(ByVal Message As String)
            MyBase.New(Message)
        End Sub

        ''' <summary>Returns a string representation of this object.</summary>	
        ''' <returns>A string representation of this MediaException.</returns>
        Public Overrides Function ToString() As String
            Return "MediaException: " & MyBase.Message & " " & MyBase.StackTrace
        End Function
    End Class
#End Region
End Class
