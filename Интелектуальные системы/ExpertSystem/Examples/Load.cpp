// Load.cpp : Пример загрузки данных из файла базы знаний, созданного
//            оболочкой экспертной системы ExpertSystem
//

#include <stdio.h>
#include <conio.h>
#include <windows.h>

// Переводит строку из ANSI-кодировки в OEM-кодировку
char* ansi2oem(char *s)
{
	unsigned int len = strlen(s);

	if (len)
		AnsiToOemBuff(s, s, len);

	return s;
}

// Читает строку из файла
int read_string(char *s, FILE *file, unsigned int max_len)
{
	unsigned int len;

	// Читаем длину строки
	fread(&len, sizeof(unsigned int), 1, file);

	if (len && len < max_len)
	{
		// Читаем строку
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
		printf("Необходимо указать имя файла базы знаний!\r\n");
		return;
	}

	FILE *kb_file = fopen(argv[1], "rb");
	if (kb_file == NULL)
	{
		printf("Не удалось открыть файл базы знаний!\r\n");
		return;
	}

	unsigned int magic;

	// Читаем сигнатуру файла базы знаний
	fread(&magic, sizeof(unsigned int), 1, kb_file);
	if (magic != 0x773E975E)
	{
		printf("Неверная сигнатура файла базы знаний!\r\n");
		fclose(kb_file);

		return;
	}

	unsigned int kb_file_version;

	// Читаем версию файла базы знаний
	fread(&kb_file_version, sizeof(unsigned int), 1, kb_file);

	unsigned int facts_cnt;

	// Читаем количество фактов в базе знаний
	fread(&facts_cnt, sizeof(unsigned int), 1, kb_file);

	unsigned int id, len, fact_type;
	int rc;
	double truth;
	char s[1024];

	// Читаем все факты и выводим их на экран
	for (int fact_num=0; fact_num<facts_cnt; fact_num++)
	{
		printf("Факт %u\r\n", fact_num);

		// Читаем идентификатор факта
		fread(&id, sizeof(unsigned int), 1, kb_file);
		printf("\tID: %u\r\n", id);

		// Читаем строку "Объект"
		rc = read_string(s, kb_file, sizeof(s));
		if (!rc)
			printf("\tОбъект: %s\r\n", ansi2oem(s));

		// Читаем строку "Атрибут"
		rc = read_string(s, kb_file, sizeof(s));
		if (!rc)
			printf("\tАтрибут: %s\r\n", ansi2oem(s));

		// Читаем строку "Значение"
		rc = read_string(s, kb_file, sizeof(s));
		if (!rc)
			printf("\tЗначение: %s\r\n", ansi2oem(s));

		// Читаем достоверность факта
		fread(&truth, sizeof(double), 1, kb_file);
		printf("\tДостоверность: %1.2f\r\n", truth);

		// Читаем тип факта
		fread(&fact_type, sizeof(unsigned int), 1, kb_file);
		printf("\tТип: ");
		switch (fact_type)
		{
		case 0: printf("промежуточный\r\n"); break;
		case 1: printf("исходный\r\n"); break;
		case 2: printf("результирующий\r\n");
		}
	}

	unsigned int rules_cnt, conclusions_cnt;

	// Читаем количество правил в базе знаний
	fread(&rules_cnt, sizeof(unsigned int), 1, kb_file);

	// Читаем все правила и выводим их на экран
	for (int rule_num=0; rule_num<rules_cnt; rule_num++)
	{
		printf("Правило %u\r\n", rule_num);

		// Читаем идентификатор правила
		fread(&id, sizeof(unsigned int), 1, kb_file);
		printf("\tID: %u\r\n", id);

		// Читаем строку "Имя"
		rc = read_string(s, kb_file, sizeof(s));
		if (!rc)
			printf("\tИмя: %s\r\n", ansi2oem(s));

		// Читаем строку "Посылка"
		rc = read_string(s, kb_file, sizeof(s));
		if (!rc)
			printf("\tПосылка: %s\r\n", ansi2oem(s));

		// Читаем количество идентификаторов в заключении
		fread(&conclusions_cnt, sizeof(unsigned int), 1, kb_file);
		if (conclusions_cnt)
		{
			printf("\tЗаключение: ");
			for (int c_num=0; c_num<conclusions_cnt; c_num++)
			{
				// Читаем идентификатор факта
				fread(&id, sizeof(unsigned int), 1, kb_file);
				printf(c_num ? ", %u":"%u", id);
			}
			printf("\r\n");
		}

		// Читаем достоверность правила
		fread(&truth, sizeof(double), 1, kb_file);
		printf("\tДостоверность: %1.2f\r\n", truth);
	}

	unsigned int questions_cnt;

	// Читаем количество вопросов в базе знаний
	fread(&questions_cnt, sizeof(unsigned int), 1, kb_file);

	// Читаем все вопросы и выводим их на экран
	for (int question_num=0; question_num<questions_cnt; question_num++)
	{
		printf("Вопрос %u\r\n", question_num);

		// Читаем идентификатор вопроса
		fread(&id, sizeof(unsigned int), 1, kb_file);
		printf("\tID: %u\r\n", id);

		// Читаем строку "Текст"
		rc = read_string(s, kb_file, sizeof(s));
		if (!rc)
			printf("\tТекст: %s\r\n", ansi2oem(s));

		// Читаем идентификатор факта ответа "Да"
		fread(&id, sizeof(unsigned int), 1, kb_file);
		printf("\tДа: %u\r\n", id);

		// Читаем идентификатор факта ответа "Нет"
		fread(&id, sizeof(unsigned int), 1, kb_file);
		printf("\tНет: %u\r\n", id);
	}

	fclose(kb_file);
}

