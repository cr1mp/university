{  Load.pas : Пример загрузки данных из файла базы знаний, созданного
              оболочкой экспертной системы ExpertSystem }
Uses
  Crt,
  Strings;

Function ReadString(Var S: Array of Char; Var F: File; MaxLen: Integer): Integer;
Var
  Len : LongInt;
Begin
  S[0] := #0;

  { Читаем длину строки }
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

  { Переводим строку из ANSI-кодировки в OEM-кодировку }
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
    WriteLn('Необходимо указать имя файла базы знаний!');
    Exit;
  End; { IF }

  {$I-}
  Assign(KBFile, ParamStr(1));
  Reset(KBFile, 1);
  {$I+}
  If (IOResult <> 0) then
  Begin
    WriteLn('Не удалось открыть файл базы знаний!');
    Exit;
  End; { IF }


  { Читаем сигнатуру файла базы знаний }
  BlockRead(KBFile, Magic, SizeOf(LongInt));
  If (Magic <> $773E975E) then
	Begin
    WriteLn('Неверная сигнатура файла базы знаний!');
    Close(KBFile);

    Exit;
	End; { IF }


  { Читаем версию файла базы знаний }
  BlockRead(KBFile, KBFileVersion, SizeOf(LongInt));

  { Читаем количество фактов в базе знаний }
  BlockRead(KBFile, FactsCnt, SizeOf(LongInt));

  { Читаем все факты и выводим их на экран }
  For FactNum := 1 to FactsCnt do
  Begin
    WriteLn('Факт ', (FactNum-1));

    { Читаем идентификатор факта }
    BlockRead(KBFile, ID, SizeOf(LongInt));
    WriteLn('    ID: ', ID);

    { Читаем строку "Объект" }
    RC := ReadString(S, KBFile, SizeOf(S));
    If (RC = 0) then
    Begin
      Write('    Объект: ');
      ShowANSIString;
      WriteLn;
    End; { IF }

    { Читаем строку "Атрибут" }
    RC := ReadString(S, KBFile, SizeOf(S));
    If (RC = 0) then
    Begin
      Write('    Атрибут: ');
      ShowANSIString;
      WriteLn;
    End; { IF }

    { Читаем строку "Значение" }
    RC := ReadString(S, KBFile, SizeOf(S));
    If (RC = 0) then
    Begin
      Write('    Значение: ');
      ShowANSIString;
      WriteLn;
    End; { IF }

    { Читаем достоверность факта }
    BlockRead(KBFile, Truth, SizeOf(Double));
    WriteLn('    Достоверность: ', Truth:2:1);

    { Читаем тип факта }
    BlockRead(KBFile, FactType, SizeOf(LongInt));
    Write('    Тип: ');

    Case FactType of
      0: WriteLn('промежуточный');
      1: WriteLn('исходный');
      2: WriteLn('результирующий');
    End; { CASE }
  End; { FOR }

  { Читаем количество правил в базе знаний }
  BlockRead(KBFile, RulesCnt, SizeOf(LongInt));

  { Читаем все правила и выводим их на экран }
  For RuleNum := 1 to RulesCnt do
  Begin
    WriteLn('Правило ', (RuleNum-1));

    { Читаем идентификатор правила }
    BlockRead(KBFile, ID, SizeOf(LongInt));
    WriteLn('    ID: ', ID);

    { Читаем строку "Имя" }
    RC := ReadString(S, KBFile, SizeOf(S));
    If (RC = 0) then
    Begin
      Write('    Имя: ');
      ShowANSIString;
      WriteLn;
    End; { IF }

    { Читаем строку "Посылка" }
    RC := ReadString(S, KBFile, SizeOf(S));
    If (RC = 0) then
    Begin
      Write('    Посылка: ');
      ShowANSIString;
      WriteLn;
    End; { IF }

    { Читаем количество идентификаторов в заключении }
    BlockRead(KBFile, ConclusionsCnt, SizeOf(LongInt));
    If (ConclusionsCnt > 0) then
    Begin
      Write('    Заключение: ');
      For ConclusionNum := 1 to ConclusionsCnt do
      Begin
        { Читаем идентификатор факта }
        BlockRead(KBFile, ID, SizeOf(LongInt));
        If (ConclusionNum <> 1) then
          Write(', ');
        Write(ID);
      End; { FOR }
      WriteLn;
    End; { IF }

    { Читаем достоверность правила }
    BlockRead(KBFile, Truth, SizeOf(Double));
    WriteLn('    Достоверность: ', Truth:2:1);
  End; { FOR }

  { Читаем количество вопросов в базе знаний }
  BlockRead(KBFile, QuestionsCnt, SizeOf(LongInt));

  { Читаем все вопросы и выводим их на экран }
  For QuestionNum := 1 to QuestionsCnt do
  Begin
    WriteLn('Вопрос ', (QuestionNum-1));

    { Читаем идентификатор вопроса }
    BlockRead(KBFile, ID, SizeOf(LongInt));
    WriteLn('    ID: ', ID);

    { Читаем строку "Текст" }
    RC := ReadString(S, KBFile, SizeOf(S));
    If (RC = 0) then
    Begin
      Write('    Текст: ');
      ShowANSIString;
      WriteLn;
    End; { IF }

    { Читаем идентификатор факта ответа "Да" }
    BlockRead(KBFile, ID, SizeOf(LongInt));
    WriteLn('    Да: ', ID);

    { Читаем идентификатор факта ответа "Нет" }
    BlockRead(KBFile, ID, SizeOf(LongInt));
    WriteLn('    Нет: ', ID);
  End; { FOR }


  Close(KBFile);
End.