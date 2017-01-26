using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;




namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
  
        
        private void button1_Click(object sender, EventArgs e)
        {
            int chromosome = Convert.ToInt32(textBox1.Text); //Число хромосом, (хромосомы - номера вершин)
            int count_species = Convert.ToInt32(textBox2.Text);
            int[] z_c = new int[count_species];
            bool fatal = false;
            bool finish=false;
            int n_generation = 0;
            int[,] generation_chield = new int[count_species, chromosome];// Поколение детей
            while (!finish)
            {            
                n_generation++;
                Result.Rows.Add();
                Result.Rows[n_generation - 1].Cells[0].Value = n_generation.ToString(); 
                int[,] generation_parent = new int[count_species, chromosome];//Поколение родителей
                int[,] pair = new int[count_species, 2];
                int[,] z_p = new int[count_species,2];
                //---------------------------Генерация поколения--------------------------------
                if ((n_generation == 1)||(fatal==true)) //Если счетчик поколений 0 или произошло вырождение,то генерируем поколелие
                {
                    for (int i = 0; i < count_species; i++)
                    {
                        string species = "";
                        int[] buff = new int[chromosome];
                        buff = Generate(chromosome);
                        Thread.Sleep(1000);
                        for (int j = 0; j < chromosome; j++)
                        {
                            generation_parent[i, j] = buff[j];
                            species += generation_parent[i, j].ToString() + ',';
                        }
                        Result.Rows[n_generation - 1].Cells[1].Value += species + "\n";
                    }
                }
                    //иначе потомки становятся родителями
                else
                    for (int i = 0; i < count_species; i++)
                    {
                        string species = "";
                        for (int j = 0; j < chromosome; j++)
                        {
                            generation_parent[i, j] = generation_chield[i, j];
                            species += generation_parent[i, j].ToString() + ',';
                        }
                        Result.Rows[n_generation - 1].Cells[1].Value += species + "\n";
                    }
                //--------------------------Оцека приспособленности особей-родителей------------------
                for (int i = 0; i < count_species; i++)
                {
                    z_p[i,0] = 0;
                    for (int j = 0; j < chromosome - 1; j++)
                    {
                        int x = generation_parent[i, j];
                        int x1 = generation_parent[i, j + 1];
                        if (Convert.ToInt32(Matrix.Rows[x].Cells[x1].Value) == 1) //Если между вершинами есть связь, то увеличиваем приспособленность 
                            z_p[i,0]++;
                    }
                    Result.Rows[n_generation - 1].Cells[2].Value += z_p[i,0].ToString();
                }
                //-------------------------Генерация пар для обмена -------------
                Random r = new Random();
                for (int i = 0; i < count_species; i++)
                {
                    string species = "";
                    pair[i, 0] = r.Next(count_species);
                    int buff = r.Next(count_species);
                    while (buff == pair[i, 0])
                        buff = r.Next(count_species);
                    pair[i, 1] = buff;
                    species = pair[i, 0].ToString() + "," + pair[i, 1].ToString();
                    Result.Rows[n_generation - 1].Cells[3].Value += species + "\n";
                }
                //--------------------Сортировка приспособленностей---------------------
               for (int i = 0; i < count_species; i++)
                    z_p[i, 1] = i;
                for (int i = 0; i < count_species-1; i++)
                {

                    int i1 = i;
                    for (int j = i + 1; j < count_species; j++)
                        if (z_p[j, 0] < z_p[i1, 0]) i1 = j;
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
                //-----------------Выбор половины "лучших" особей---------------------
                int c = count_species-1;
                for (int i = count_species-1 ; i>0; i=i-2)
                {
                    string species = "";
                    pair[c, 0] = z_p[i,1];
                    pair[c, 1] = z_p[i - 1,1];
                    c--;
                    Result.Rows[n_generation - 1].Cells[3].Value += species + "\n";
                }
                //--------------Кроссинговер-------------------------------
                for (int i = 0; i < count_species; i++)
                {
                    string species = "";
                    int buffer = r.Next(1, chromosome);
                    for (int j = 0; j < buffer; j++)
                        generation_chield[i, j] = generation_parent[pair[i, 0], j];
                    for (int j = buffer; j < chromosome; j++)
                        generation_chield[i, j] = generation_parent[pair[i, 1], j];
                //--Проверка на совпадение хромосом и уничтожение одинаковых хромосом------------------- 
                    for (int i1 = 0; i1 < chromosome; i1++)
                        for (int j = 0; j < chromosome; j++)
                            if ((generation_chield[i, i1] == generation_chield[i, j]) && (i1 != j)) //Если совпали
                            {
                                int n = j;
                                while (n != 0) //Пока число различных хромосом не 0, то
                                {
                                    int number = r.Next(chromosome);
                                    generation_chield[i, j] = number;// Замена совпадающей хромосомы на рандом 
                                    for (int j1 = 0; j1 < j; j1++) 
                                        if (generation_chield[i, j] != generation_chield[i, j1]) //Проверка, не совпадает новая хромосома с остальными
                                            n--;
                                        else
                                        {
                                            n = j;
                                        }
                                }
                            }
                    for (int j = 0; j < chromosome; j++)
                        species += generation_chield[i, j].ToString() + ",";
                    Result.Rows[n_generation - 1].Cells[4].Value += species + ";" + buffer.ToString() + "\n";
                }
                //--------------------------Оцека приспособленности особей-потомков-------------
                for (int i = 0; i < count_species; i++)
                {
                    z_c[i] = 0;
                    for (int j = 0; j < chromosome - 1; j++)
                    {
                        int x = generation_chield[i, j];
                        int x1 = generation_chield[i, j + 1];
                        if (Convert.ToInt32(Matrix.Rows[x].Cells[x1].Value) == 1) //Если между вершинами есть связь, то увеличиваем приспособленность 
                            z_c[i]++;
                    }
                    Result.Rows[n_generation - 1].Cells[5].Value += z_c[i].ToString();
                }
               //Если все потомки одинаковы, то это "вырождение"
                for (int i = 0; i < count_species; i++)
                {
                    if (z_c[0] != z_c[i])
                    {
                        fatal = false;
                        break;
                    }
                    else
                        fatal = true;
                }
                //---------------------Если есть особь с приспособленностью н 1 меньньше кол-ва вершин, то завершаем алгоритм
                for (int i = 0; i < count_species; i++)
                {
                    if (z_c[i] == chromosome - 1)
                    {
                        string species = "";
                        for (int j = 0; j < chromosome; j++)
                            species += generation_chield[i, j].ToString() + ",";
                        textBox3.Text = species;
                        finish = true;
                        break;
                    }
                }
            }

        }

        //Генерация особей без совпадающих хромосом
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
        
      
        private void button2_Click(object sender, EventArgs e)
        {
            Matrix.RowCount = Convert.ToInt32(textBox1.Text);
            Matrix.ColumnCount = Matrix.RowCount;
            for (int i = 0; i < Matrix.ColumnCount; i++)
            {
                Matrix.Columns[i].Width = 30;
                for (int j = 0; j < Matrix.ColumnCount; j++)
                    Matrix.Rows[j].Cells[i].Value = "0";
               
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                StreamReader f = new StreamReader(filename);
                string s = "";
                int j = 0;
                int z = 0;
                while (true)
                {
                    s = f.ReadLine();
                    if (s == null) break;
                    if (z == 0)
                    {
                        int l = s.Length;
                        textBox1.Text = l.ToString();
                        Matrix.RowCount = l;
                        Matrix.ColumnCount = Matrix.RowCount;
                        for (int i = 0; i < Matrix.ColumnCount; i++)
                            Matrix.Columns[i].Width = 30;
                        z++;
                    }
                    for (int i=0;i<Matrix.ColumnCount;i++)
                        Matrix.Rows[j].Cells[i].Value=s[i].ToString();
                    j++;
                }
                f.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                StreamWriter f = new StreamWriter(filename);
                string s = "";                
                for (int j = 0; j < Matrix.RowCount; j++)
                {
                     for (int i = 0; i < Matrix.RowCount; i++)
                    s += Matrix.Rows[j].Cells[i].Value.ToString();
                     f.WriteLine(s);
                     s = "";
                }
                f.Close();
            }
        }

        

      
    }
}
