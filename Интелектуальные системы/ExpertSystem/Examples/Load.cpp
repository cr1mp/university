// Load.cpp : �ਬ�� ����㧪� ������ �� 䠩�� ���� ������, ᮧ�������
//            �����窮� �ᯥ�⭮� ��⥬� ExpertSystem
//

#include <stdio.h>
#include <conio.h>
#include <windows.h>

// ��ॢ���� ��ப� �� ANSI-����஢�� � OEM-����஢��
char* ansi2oem(char *s)
{
	unsigned int len = strlen(s);

	if (len)
		AnsiToOemBuff(s, s, len);

	return s;
}

// ��⠥� ��ப� �� 䠩��
int read_string(char *s, FILE *file, unsigned int max_len)
{
	unsigned int len;

	// ��⠥� ����� ��ப�
	fread(&len, sizeof(unsigned int), 1, file);

	if (len && len < max_len)
	{
		// ��⠥� ��ப�
		fread(s, len, 1, file);
		s[len] = 0;

		return 0;
	}
	return -1;
}

void main(int argc, char* argv[])
{
	if (argc < 2)
	{
		printf("����室��� 㪠���� ��� 䠩�� ���� ������!\r\n");
		return;
	}

	FILE *kb_file = fopen(argv[1], "rb");
	if (kb_file == NULL)
	{
		printf("�� 㤠���� ������ 䠩� ���� ������!\r\n");
		return;
	}

	unsigned int magic;

	// ��⠥� ᨣ������ 䠩�� ���� ������
	fread(&magic, sizeof(unsigned int), 1, kb_file);
	if (magic != 0x773E975E)
	{
		printf("����ୠ� ᨣ����� 䠩�� ���� ������!\r\n");
		fclose(kb_file);

		return;
	}

	unsigned int kb_file_version;

	// ��⠥� ����� 䠩�� ���� ������
	fread(&kb_file_version, sizeof(unsigned int), 1, kb_file);

	unsigned int facts_cnt;

	// ��⠥� ������⢮ 䠪⮢ � ���� ������
	fread(&facts_cnt, sizeof(unsigned int), 1, kb_file);

	unsigned int id, len, fact_type;
	int rc;
	double truth;
	char s[1024];

	// ��⠥� �� 䠪�� � �뢮��� �� �� �࠭
	for (int fact_num=0; fact_num<facts_cnt; fact_num++)
	{
		printf("���� %u\r\n", fact_num);

		// ��⠥� �����䨪��� 䠪�
		fread(&id, sizeof(unsigned int), 1, kb_file);
		printf("\tID: %u\r\n", id);

		// ��⠥� ��ப� "��ꥪ�"
		rc = read_string(s, kb_file, sizeof(s));
		if (!rc)
			printf("\t��ꥪ�: %s\r\n", ansi2oem(s));

		// ��⠥� ��ப� "��ਡ��"
		rc = read_string(s, kb_file, sizeof(s));
		if (!rc)
			printf("\t��ਡ��: %s\r\n", ansi2oem(s));

		// ��⠥� ��ப� "���祭��"
		rc = read_string(s, kb_file, sizeof(s));
		if (!rc)
			printf("\t���祭��: %s\r\n", ansi2oem(s));

		// ��⠥� ���⮢�୮��� 䠪�
		fread(&truth, sizeof(double), 1, kb_file);
		printf("\t���⮢�୮���: %1.2f\r\n", truth);

		// ��⠥� ⨯ 䠪�
		fread(&fact_type, sizeof(unsigned int), 1, kb_file);
		printf("\t���: ");
		switch (fact_type)
		{
		case 0: printf("�஬������\r\n"); break;
		case 1: printf("��室��\r\n"); break;
		case 2: printf("१������騩\r\n");
		}
	}

	unsigned int rules_cnt, conclusions_cnt;

	// ��⠥� ������⢮ �ࠢ�� � ���� ������
	fread(&rules_cnt, sizeof(unsigned int), 1, kb_file);

	// ��⠥� �� �ࠢ��� � �뢮��� �� �� �࠭
	for (int rule_num=0; rule_num<rules_cnt; rule_num++)
	{
		printf("�ࠢ��� %u\r\n", rule_num);

		// ��⠥� �����䨪��� �ࠢ���
		fread(&id, sizeof(unsigned int), 1, kb_file);
		printf("\tID: %u\r\n", id);

		// ��⠥� ��ப� "���"
		rc = read_string(s, kb_file, sizeof(s));
		if (!rc)
			printf("\t���: %s\r\n", ansi2oem(s));

		// ��⠥� ��ப� "���뫪�"
		rc = read_string(s, kb_file, sizeof(s));
		if (!rc)
			printf("\t���뫪�: %s\r\n", ansi2oem(s));

		// ��⠥� ������⢮ �����䨪��஢ � �����祭��
		fread(&conclusions_cnt, sizeof(unsigned int), 1, kb_file);
		if (conclusions_cnt)
		{
			printf("\t�����祭��: ");
			for (int c_num=0; c_num<conclusions_cnt; c_num++)
			{
				// ��⠥� �����䨪��� 䠪�
				fread(&id, sizeof(unsigned int), 1, kb_file);
				printf(c_num ? ", %u":"%u", id);
			}
			printf("\r\n");
		}

		// ��⠥� ���⮢�୮��� �ࠢ���
		fread(&truth, sizeof(double), 1, kb_file);
		printf("\t���⮢�୮���: %1.2f\r\n", truth);
	}

	unsigned int questions_cnt;

	// ��⠥� ������⢮ ����ᮢ � ���� ������
	fread(&questions_cnt, sizeof(unsigned int), 1, kb_file);

	// ��⠥� �� ������ � �뢮��� �� �� �࠭
	for (int question_num=0; question_num<questions_cnt; question_num++)
	{
		printf("����� %u\r\n", question_num);

		// ��⠥� �����䨪��� �����
		fread(&id, sizeof(unsigned int), 1, kb_file);
		printf("\tID: %u\r\n", id);

		// ��⠥� ��ப� "�����"
		rc = read_string(s, kb_file, sizeof(s));
		if (!rc)
			printf("\t�����: %s\r\n", ansi2oem(s));

		// ��⠥� �����䨪��� 䠪� �⢥� "��"
		fread(&id, sizeof(unsigned int), 1, kb_file);
		printf("\t��: %u\r\n", id);

		// ��⠥� �����䨪��� 䠪� �⢥� "���"
		fread(&id, sizeof(unsigned int), 1, kb_file);
		printf("\t���: %u\r\n", id);
	}

	fclose(kb_file);
}

