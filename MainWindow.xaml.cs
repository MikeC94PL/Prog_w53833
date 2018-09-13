using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace w53833_Prog
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    
    
    public partial class MainWindow : Window
    {
        public GridView gridView = new GridView();
        

        public MainWindow()
        {
            
            InitializeComponent();
            gridView.AllowsColumnReorder = true;
        }

        /// <summary>
        /// Obsługa przycisku tworzenia nowej tabeli
        /// </summary>
        public void MakeTable_Click(object sender, RoutedEventArgs e)
        {
            gridView.Columns.Clear();
            
            Peolpe.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Id",
                DisplayMemberBinding = new Binding("Id")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Name",
                DisplayMemberBinding = new Binding("Name")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "SurName",
                DisplayMemberBinding = new Binding("SurName")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "NrAlbum",
                DisplayMemberBinding = new Binding("NrAlbum")
            });
        }

        /// <summary>
        /// Dodawanie rekordu danych
        /// </summary>
        /// <param name="aN">Imię</param>
        /// <param name="aSN">Nazwisko</param>
        /// <param name="aA">Nr Albumu</param>
        private void AddRecord(string aN, string aSN, string aA)
        {
            int IdC = Peolpe.Items.Count + 1;
            this.Peolpe.Items.Add(new Person { Id = IdC, Name = aN, SurName=aSN, NrAlbum = aA });
        }

        /// <summary>
        /// Dodawanie atrybutu danych
        /// </summary>
        /// <param name="attName">Nazwa nowej kolumny</param>
        private void AddColumn(string attName)
        {
            if (gridView.Columns.Count != 0)
            {
                if (MessageBox.Show(("Czy na pewno chcesz dodać kolumnę " + attName + " do listy? "), "Zapytanie", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Peolpe.View = gridView;
                    var newAtt = new GridViewColumn()
                    {

                        Header = attName,
                        DisplayMemberBinding = new Binding(attName)
                    };
                    gridView.Columns.Add(newAtt);
                }
                else
                {
                    // Return
                }
            }
            else
            {
                MessageBox.Show("Najpierw musi być wygenerowana podstawowa baza, zawierająca ID. ");
            }
        }

        /// <summary>
        /// Obsługa przycisku tworzenia rekordu danych
        /// </summary>
        private void Accept_Record_Click(object sender, RoutedEventArgs e)
        {
            AddRecord(StringName_Record.Text, StringSurName_Record.Text, StringAlbum_Record.Text);
        }

        /// <summary>
        /// Obsługa przycisku tworzenia atrybutu danych
        /// </summary>
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            string attName = StringName.Text;
            AddColumn(attName);
        }
        
    }

    /// <summary>
    /// Encja bazy danych
    /// </summary>
    public class Person
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string SurName { get; set; }
        public string NrAlbum { get; set; }
        public List<float> Grades { get; set; }
        public List<bool> Presence { get; set; }
    }
}
/// <sumary>
/// Obsługa przycisku tworzenia nowej tabeli
/// </sumary>
///  <sumary>
/// Dodawanie rekordu danych
/// </sumary>
///  <summary>
/// Dodawanie atrybutu danych 
/// </summary>
/// <sumary>
/// Obsługa przycisku tworzenia rekordu danych
/// </sumary>
/// <sumary>
/// Obsługa przycisku tworzenia atrybutu danych
/// </sumary>
