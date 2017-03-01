using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
  class GeneticAlgoritm
  {
    /// <summary>
    ///  Число хромосом, (хромосомы - номера вершин).
    /// </summary>
    readonly int _chromosomeCount;

    /// <summary>
    /// Количество особей в поколении.
    /// </summary>
    int speciesCount;

    /// <summary>
    /// Приспособленности детей.
    /// </summary>
    int[] z_children;

    Random r;

    public GeneticAlgoritm(int chromosomeCount, int speciesCount)
    {
      _chromosomeCount = chromosomeCount;
      this.speciesCount = speciesCount;
      z_children = new int[this.speciesCount];

      r = new Random();
    }

    public string StartGeneticAlgoritm(DataGridView Matrix, DataGridView Result)
    {
      bool fatal = false;
      int iteration = 0;
      int[,] generation_chield = new int[speciesCount, _chromosomeCount];// Поколение детей

      while (true)
      {
        iteration++;
        Result.Rows.Add();
        Result.Rows[iteration - 1].Cells[0].Value = iteration.ToString();
        int[,] generation_parent = new int[speciesCount, _chromosomeCount];// Поколение родителей
        int[,] pair = new int[speciesCount, 2];
        // Приспособлености родителей.
        int[,] z_parent = new int[speciesCount, 2];

        // Генерация поколения.
        CreateGeneration(Result, iteration, fatal, generation_parent, generation_chield);

        // Оцека приспособленности особей-родителей.
        AssessmentFitnessOfIndividualsParents(Matrix, Result, z_parent, generation_parent, iteration);

        // Генерация пар для обмена.
        GenerationPair(Result, pair, iteration);

        // Сортировка приспособленностей.
        Sort(z_parent);

        // Выбор половины "лучших" особей.
        SelectionBest(Result, pair, z_parent, iteration);

        // Кроссинговер.
        Crossingover(Result, generation_chield, generation_parent, pair, iteration);

        // Оцека приспособленности особей-потомков.
        AssessmentFitnessOfIndividualsDescendants(Matrix, Result, z_children, generation_chield, iteration);

        // Если все потомки одинаковы, то это "вырождение".
        fatal = Fatal(fatal);

        // Если есть особь с приспособленностью на 1 меньньше кол-ва вершин, то завершаем алгоритм
        for (int i = 0; i < speciesCount; i++)
        {
          if (z_children[i] == _chromosomeCount - 1)
          {
            string species = "";
            for (int j = 0; j < _chromosomeCount; j++)
              species += generation_chield[i, j] + ",";
            return species;
          }
        }
      }
    }

    /// <summary>
    /// Генерация поколения.
    /// </summary>
    /// <param name="Result"></param>
    /// <param name="n_generation"></param>
    /// <param name="fatal"></param>
    /// <param name="generation_parent"></param>
    /// <param name="generation_chield"></param>
    private void CreateGeneration(DataGridView Result, int n_generation, bool fatal, int[,] generation_parent,
      int[,] generation_chield)
    {
      if ((n_generation == 1) || (fatal)) // Если счетчик поколений 0 или произошло вырождение,то генерируем поколелие
      {
        for (int i = 0; i < speciesCount; i++)
        {
          string species = "";
          int[] buff = new int[_chromosomeCount];
          buff = Generate(_chromosomeCount);
          for (int j = 0; j < _chromosomeCount; j++)
          {
            generation_parent[i, j] = buff[j];
            species += generation_parent[i, j].ToString() + ',';
          }
          Result.Rows[n_generation - 1].Cells[1].Value += species + "\n";
        }
      }
      //иначе потомки становятся родителями
      else
        for (int i = 0; i < speciesCount; i++)
        {
          string species = "";
          for (int j = 0; j < _chromosomeCount; j++)
          {
            generation_parent[i, j] = generation_chield[i, j];
            species += generation_parent[i, j].ToString() + ',';
          }
          Result.Rows[n_generation - 1].Cells[1].Value += species + "\n";
        }
    }

    /// <summary>
    /// Генерация особей без совпадающих хромосом.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    int[] Generate(int n)
    {
      int[] a = new int[n];
      Random r = new Random();
      a[0] = r.Next(n);
      for (int i = 0; i < n; i++)
      {
        bool flag = true;
        while (flag)
        {
          int number = r.Next(n);
          int j;
          for (j = 0; j < i + 1; ++j)
            if (number == a[j]) break;
          if (j == i + 1)
          {
            a[i + 1] = number;
            flag = false;
          }
          if ((i + 1) == n) break;
        }
      }
      return a;
    }

    /// <summary>
    /// Оцека приспособленности особей-родителей.
    /// </summary>
    /// <param name="Matrix"></param>
    /// <param name="Result"></param>
    /// <param name="z_p"></param>
    /// <param name="generation_parent"></param>
    /// <param name="n_generation"></param>
    private void AssessmentFitnessOfIndividualsParents(DataGridView Matrix, DataGridView Result, int[,] z_p, int[,] generation_parent, int n_generation)
    {
      for (int i = 0; i < speciesCount; i++)
      {
        z_p[i, 0] = 0;
        for (int j = 0; j < _chromosomeCount - 1; j++)
        {
          int x = generation_parent[i, j];
          int x1 = generation_parent[i, j + 1];
          if (Convert.ToInt32(Matrix.Rows[x].Cells[x1].Value) == 1)
            //Если между вершинами есть связь, то увеличиваем приспособленность 
            z_p[i, 0]++;
        }
        Result.Rows[n_generation - 1].Cells[2].Value += z_p[i, 0].ToString();
      }
    }

    /// <summary>
    /// Генерация пар для обмена.
    /// </summary>
    /// <param name="Result"></param>
    /// <param name="pair"></param>
    /// <param name="n_generation"></param>
    private void GenerationPair(DataGridView Result, int[,] pair, int n_generation)
    {
      for (int i = 0; i < speciesCount; i++)
      {
        string species = "";
        pair[i, 0] = r.Next(speciesCount);
        int buff = r.Next(speciesCount);
        while (buff == pair[i, 0])
          buff = r.Next(speciesCount);
        pair[i, 1] = buff;
        species = pair[i, 0] + "," + pair[i, 1];
        Result.Rows[n_generation - 1].Cells[3].Value += species + "\n";
      }
    }

    /// <summary>
    /// Сортировка приспособленностей.
    /// </summary>
    /// <param name="z_p"></param>
    private void Sort(int[,] z_p)
    {
      for (int i = 0; i < speciesCount; i++)
        z_p[i, 1] = i;
      for (int i = 0; i < speciesCount - 1; i++)
      {
        int i1 = i;
        for (int j = i + 1; j < speciesCount; j++)
          if (z_p[j, 0] < z_p[i1, 0])
            i1 = j;
        if (i1 > i)
        {
          int b = z_p[i1, 0];
          z_p[i1, 0] = z_p[i, 0];
          z_p[i, 0] = b;
          b = z_p[i1, 1];
          z_p[i1, 1] = z_p[i, 1];
          z_p[i, 1] = b;
        }
      }
    }

    /// <summary>
    /// Выбор половины "лучших" особей.
    /// </summary>
    /// <param name="Result"></param>
    /// <param name="pair"></param>
    /// <param name="z_p"></param>
    /// <param name="n_generation"></param>
    private void SelectionBest(DataGridView Result, int[,] pair, int[,] z_p, int n_generation)
    {
      int c = speciesCount - 1;
      for (int i = speciesCount - 1; i > 0; i = i - 2)
      {
        string species = "";
        pair[c, 0] = z_p[i, 1];
        pair[c, 1] = z_p[i - 1, 1];
        c--;
        Result.Rows[n_generation - 1].Cells[3].Value += species + "\n";
      }
    }

    /// <summary>
    /// Кроссинговер.
    /// </summary>
    /// <param name="Result"></param>
    /// <param name="generation_chield"></param>
    /// <param name="generation_parent"></param>
    /// <param name="pair"></param>
    /// <param name="n_generation"></param>
    private void Crossingover(DataGridView Result, int[,] generation_chield, int[,] generation_parent, int[,] pair,
      int n_generation)
    {
      for (int i = 0; i < speciesCount; i++)
      {
        string species = "";
        int buffer = r.Next(1, _chromosomeCount);
        for (int j = 0; j < buffer; j++)
          generation_chield[i, j] = generation_parent[pair[i, 0], j];
        for (int j = buffer; j < _chromosomeCount; j++)
          generation_chield[i, j] = generation_parent[pair[i, 1], j];
        //--Проверка на совпадение хромосом и уничтожение одинаковых хромосом------------------- 
        for (int i1 = 0; i1 < _chromosomeCount; i1++)
          for (int j = 0; j < _chromosomeCount; j++)
            if ((generation_chield[i, i1] == generation_chield[i, j]) && (i1 != j)) //Если совпали
            {
              int n = j;
              while (n != 0) //Пока число различных хромосом не 0, то
              {
                int number = r.Next(_chromosomeCount);
                generation_chield[i, j] = number; // Замена совпадающей хромосомы на рандом 
                for (int j1 = 0; j1 < j; j1++)
                  if (generation_chield[i, j] != generation_chield[i, j1]) //Проверка, не совпадает новая хромосома с остальными
                    n--;
                  else
                  {
                    n = j;
                  }
              }
            }
        for (int j = 0; j < _chromosomeCount; j++)
          species += generation_chield[i, j].ToString() + ",";
        Result.Rows[n_generation - 1].Cells[4].Value += species + ";" + buffer.ToString() + "\n";
      }
    }

    /// <summary>
    /// Оцека приспособленности особей-потомков.
    /// </summary>
    /// <param name="Matrix"></param>
    /// <param name="Result"></param>
    /// <param name="z_c"></param>
    /// <param name="generation_chield"></param>
    /// <param name="n_generation"></param>
    private void AssessmentFitnessOfIndividualsDescendants(DataGridView Matrix, DataGridView Result, int[] z_c,
      int[,] generation_chield, int n_generation)
    {
      for (int i = 0; i < speciesCount; i++)
      {
        z_c[i] = 0;
        for (int j = 0; j < _chromosomeCount - 1; j++)
        {
          int x = generation_chield[i, j];
          int x1 = generation_chield[i, j + 1];
          if (Convert.ToInt32(Matrix.Rows[x].Cells[x1].Value) == 1)
            //Если между вершинами есть связь, то увеличиваем приспособленность 
            z_c[i]++;
        }
        Result.Rows[n_generation - 1].Cells[5].Value += z_c[i].ToString();
      }
    }

    /// <summary>
    /// Если все потомки одинаковы, то это "вырождение".
    /// </summary>
    /// <param name="fatal"></param>
    /// <returns></returns>
    private bool Fatal(bool fatal)
    {
      for (int i = 0; i < speciesCount; i++)
      {
        if (z_children[0] != z_children[i])
        {
          fatal = false;
          break;
        }
        else
          fatal = true;
      }
      return fatal;
    }

  }
}
