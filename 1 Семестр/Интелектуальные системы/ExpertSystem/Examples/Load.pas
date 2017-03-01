{  Load.pas : �ਬ�� ����㧪� ������ �� 䠩�� ���� ������, ᮧ�������
              �����窮� �ᯥ�⭮� ��⥬� ExpertSystem }
Uses
  Crt,
  Strings;

Function ReadString(Var S: Array of Char; Var F: File; MaxLen: Integer): Integer;
Var
  Len : LongInt;
Begin
  S[0] := #0;

  { ��⠥� ����� ��ப� }
  BlockRead(F, Len, SizeOf(LongInt));

  If ((Len > 0) and (Len < MaxLen)) then
  Begin
    BlockRead(F, S, Len);
    S[Len] := #0;

    ReadString := 0;
    Exit;
  End; { IF }

  ReadString := -1;
End; { READSTRING }

Var
  KBFile         : File;
  Magic,
  KBFileVersion,
  FactNum,
  RuleNum,
  QuestionNum,
  FactsCnt,
  RulesCnt,
  QuestionsCnt,
  ID,
  FactType,
  ConclusionNum,
  ConclusionsCnt : LongInt;
  RC             : Integer;
  S              : Array [0..1023] of Char;
  Truth          : Double;

Procedure ShowANSIString;
Var
  Code : Byte;
  PS   : PChar;
  I    : LongInt;
  Len  : LongInt;
Begin
  PS  := StrNew(S);
  Len := StrLen(PS);

  { ��ॢ���� ��ப� �� ANSI-����஢�� � OEM-����஢�� }
  For I := 0 to Len-1 do
  Begin
    Code := Ord(PS[I]);

    If (Code in [192..255]) then
      If (Code in [192..239]) then
        Code := Code-64
      else
        Code := Code-16
    else
      If (Code = 133) then
        Code := 168
      else If (Code = 165) then
        Code := 184;

    PS[I] := Char(Code);
  End; { FOR }

  Write(PS);
  StrDispose(PS);
End; { SHOWANSISTRING }

Begin
  If (ParamCount < 1) then
  Begin
    WriteLn('����室��� 㪠���� ��� 䠩�� ���� ������!');
    Exit;
  End; { IF }

  {$I-}
  Assign(KBFile, ParamStr(1));
  Reset(KBFile, 1);
  {$I+}
  If (IOResult <> 0) then
  Begin
    WriteLn('�� 㤠���� ������ 䠩� ���� ������!');
    Exit;
  End; { IF }


  { ��⠥� ᨣ������ 䠩�� ���� ������ }
  BlockRead(KBFile, Magic, SizeOf(LongInt));
  If (Magic <> $773E975E) then
	Begin
    WriteLn('����ୠ� ᨣ����� 䠩�� ���� ������!');
    Close(KBFile);

    Exit;
	End; { IF }


  { ��⠥� ����� 䠩�� ���� ������ }
  BlockRead(KBFile, KBFileVersion, SizeOf(LongInt));

  { ��⠥� ������⢮ 䠪⮢ � ���� ������ }
  BlockRead(KBFile, FactsCnt, SizeOf(LongInt));

  { ��⠥� �� 䠪�� � �뢮��� �� �� �࠭ }
  For FactNum := 1 to FactsCnt do
  Begin
    WriteLn('���� ', (FactNum-1));

    { ��⠥� �����䨪��� 䠪� }
    BlockRead(KBFile, ID, SizeOf(LongInt));
    WriteLn('    ID: ', ID);

    { ��⠥� ��ப� "��ꥪ�" }
    RC := ReadString(S, KBFile, SizeOf(S));
    If (RC = 0) then
    Begin
      Write('    ��ꥪ�: ');
      ShowANSIString;
      WriteLn;
    End; { IF }

    { ��⠥� ��ப� "��ਡ��" }
    RC := ReadString(S, KBFile, SizeOf(S));
    If (RC = 0) then
    Begin
      Write('    ��ਡ��: ');
      ShowANSIString;
      WriteLn;
    End; { IF }

    { ��⠥� ��ப� "���祭��" }
    RC := ReadString(S, KBFile, SizeOf(S));
    If (RC = 0) then
    Begin
      Write('    ���祭��: ');
      ShowANSIString;
      WriteLn;
    End; { IF }

    { ��⠥� ���⮢�୮��� 䠪� }
    BlockRead(KBFile, Truth, SizeOf(Double));
    WriteLn('    ���⮢�୮���: ', Truth:2:1);

    { ��⠥� ⨯ 䠪� }
    BlockRead(KBFile, FactType, SizeOf(LongInt));
    Write('    ���: ');

    Case FactType of
      0: WriteLn('�஬������');
      1: WriteLn('��室��');
      2: WriteLn('१������騩');
    End; { CASE }
  End; { FOR }

  { ��⠥� ������⢮ �ࠢ�� � ���� ������ }
  BlockRead(KBFile, RulesCnt, SizeOf(LongInt));

  { ��⠥� �� �ࠢ��� � �뢮��� �� �� �࠭ }
  For RuleNum := 1 to RulesCnt do
  Begin
    WriteLn('�ࠢ��� ', (RuleNum-1));

    { ��⠥� �����䨪��� �ࠢ��� }
    BlockRead(KBFile, ID, SizeOf(LongInt));
    WriteLn('    ID: ', ID);

    { ��⠥� ��ப� "���" }
    RC := ReadString(S, KBFile, SizeOf(S));
    If (RC = 0) then
    Begin
      Write('    ���: ');
      ShowANSIString;
      WriteLn;
    End; { IF }

    { ��⠥� ��ப� "���뫪�" }
    RC := ReadString(S, KBFile, SizeOf(S));
    If (RC = 0) then
    Begin
      Write('    ���뫪�: ');
      ShowANSIString;
      WriteLn;
    End; { IF }

    { ��⠥� ������⢮ �����䨪��஢ � �����祭�� }
    BlockRead(KBFile, ConclusionsCnt, SizeOf(LongInt));
    If (ConclusionsCnt > 0) then
    Begin
      Write('    �����祭��: ');
      For ConclusionNum := 1 to ConclusionsCnt do
      Begin
        { ��⠥� �����䨪��� 䠪� }
        BlockRead(KBFile, ID, SizeOf(LongInt));
        If (ConclusionNum <> 1) then
          Write(', ');
        Write(ID);
      End; { FOR }
      WriteLn;
    End; { IF }

    { ��⠥� ���⮢�୮��� �ࠢ��� }
    BlockRead(KBFile, Truth, SizeOf(Double));
    WriteLn('    ���⮢�୮���: ', Truth:2:1);
  End; { FOR }

  { ��⠥� ������⢮ ����ᮢ � ���� ������ }
  BlockRead(KBFile, QuestionsCnt, SizeOf(LongInt));

  { ��⠥� �� ������ � �뢮��� �� �� �࠭ }
  For QuestionNum := 1 to QuestionsCnt do
  Begin
    WriteLn('����� ', (QuestionNum-1));

    { ��⠥� �����䨪��� ����� }
    BlockRead(KBFile, ID, SizeOf(LongInt));
    WriteLn('    ID: ', ID);

    { ��⠥� ��ப� "�����" }
    RC := ReadString(S, KBFile, SizeOf(S));
    If (RC = 0) then
    Begin
      Write('    �����: ');
      ShowANSIString;
      WriteLn;
    End; { IF }

    { ��⠥� �����䨪��� 䠪� �⢥� "��" }
    BlockRead(KBFile, ID, SizeOf(LongInt));
    WriteLn('    ��: ', ID);

    { ��⠥� �����䨪��� 䠪� �⢥� "���" }
    BlockRead(KBFile, ID, SizeOf(LongInt));
    WriteLn('    ���: ', ID);
  End; { FOR }


  Close(KBFile);
End.